
using NewsDemo.Common;
using NewsDemo.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Net.Http.Headers;

namespace NewsDemo
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                Configuration = builder.Build();
                ConfigItems.Configuration = Configuration;

            }
            catch (Exception ex)
            {
            }
        }

        public IConfigurationRoot Configuration { get; }

        // this method gets called by the runtime. use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // register all services
            ServiceRegistry.RegisterServices(services);

            //Automapper

            services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(30));


            // If using IIS: - for Sitemap
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // add cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.SetIsOriginAllowed(origin => true)
                                                                .AllowAnyMethod()
                                                                .AllowAnyHeader()
                                                                .AllowCredentials());
            });

            // add anti-forgery
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "CSRF-TOKEN-LGPATH-HEADER";
                options.Cookie.Name = "CSRF-TOKEN-LGPATH-COOKIE";
                options.FormFieldName = "CSRF-TOKEN-LGPATH-FORM";
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            // add authentication
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                options.SlidingExpiration = true;
            });

            // configure application cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/account/access-denied";
                options.Cookie.Name = "LGPathLabAppCookie";
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            services.Configure<FormOptions>(o =>
            {
                // o.MultipartBodyLengthLimit = 104857600; // 100 MB
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = long.MaxValue; // <-- !!! long.MaxValue
                o.MultipartBoundaryLengthLimit = int.MaxValue;
                o.MultipartHeadersCountLimit = int.MaxValue;
                o.MultipartHeadersLengthLimit = int.MaxValue;
            });

            services.AddControllers();

            // Add SignalR service
            services.AddSignalR();

            //services.AddDirectoryBrowser();
        }

        // this method gets called by the runtime. use this method to configure the http request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/404");
                // the default hsts value is 30 days. you may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseCookiePolicy();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseSession();



            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpHelper.Configure(httpContextAccessor);
            SessionUtility.Configure(httpContextAccessor);

            // for lower case url in address bar

            //app.UseMiddleware<DosAttackMiddleware>();
          
            // add new mappings
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".m3u8"] = "application/x-mpegURL";
            provider.Mappings[".vtt"] = "text/vtt";
            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider,
                // added to get better light-house score
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 5;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + durationInSeconds;
                }
            });

            //var fileProvider = new PhysicalFileProvider(Path.Combine(env.WebRootPath, ""));
            //app.UseDirectoryBrowser(new DirectoryBrowserOptions
            //{
            //    FileProvider = fileProvider,
            //    RequestPath = ""
            //});
            //app.UseSoapEndpoint<ITestSoapService>("/testservice.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");

                endpoints.MapControllerRoute(
                     name: "LGPathLab",
                     pattern: "{controller=account}/{action=login}"
                );

            });


        }
    }
}
