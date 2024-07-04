using Microsoft.AspNetCore.Http;

namespace NewsDemo.Common
{
    public static class SessionUtility
    {
        private static IHttpContextAccessor HttpContextAccessor = null!;

        /// <summary>
        /// Configures the specified HTTP context accessor.
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void Set(string key, byte[] value)
        {
            HttpContextAccessor.HttpContext.Session.Set(key, value);
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Get(string key)
        {
            return HttpContextAccessor.HttpContext.Session.Get(key);
        }

        /// <summary>
        /// Sets the string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void SetString(string key, string value)
        {
            HttpContextAccessor.HttpContext.Session.SetString(key, value);
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public static string GetString(string key)
        {
            return HttpContextAccessor.HttpContext.Session.GetString(key);
        }

        /// <summary>
        /// Sets the int.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void SetInt(string key, int value)
        {
            HttpContextAccessor.HttpContext.Session.SetInt32(key, value);
        }

        /// <summary>
        /// Gets the int.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Int32.</returns>
        public static int? GetInt(string key)
        {
            return HttpContextAccessor.HttpContext.Session.GetInt32(key);
        }

        /// <summary>
        /// Sets the boolean.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetBoolean(string key, bool value)
        {
            HttpContextAccessor.HttpContext.Session.SetBoolean(key, value);
        }

        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool? GetBoolean(string key)
        {
            return HttpContextAccessor.HttpContext.Session.GetBoolean(key);
        }

        /// <summary>
        /// Sets the object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void SetObject(string key, object value)
        {
            HttpContextAccessor.HttpContext.Session.SetObjectAsJson(key, value);
        }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public static T? GetObject<T>(string key)
        {
            return HttpContextAccessor.HttpContext.Session.GetObjectFromJson<T>(key);
        }
    }
}
