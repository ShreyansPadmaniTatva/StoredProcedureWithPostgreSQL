using Dapper;
using NewsDemo.Comman;
using NewsDemo.Common;
using NewsDemo.Data;
using NewsDemo.Domain.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsDemo.Service.Menu
{
    [TransientDependency(ServiceType = typeof(IMenu))]
    public class Menu : IMenu
    {
        private readonly IDapperService _dapperService;

        public Menu(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        /// <summary>
        /// Blocks a client user identified by the specified client user ID.
        /// </summary>
        public List<NewsDemo.Domain.Model.Menu> get_all_menu()
        {
            try
            {
                using (var connection = new NpgsqlConnection("Host=localhost;Database=HalloDoc;Username=postgres;Password=1936"))
                {
                    connection.Open();

                    // Use Dapper's Query method to call the PostgreSQL function
                    var menuItems = connection.Query<NewsDemo.Domain.Model.Menu>("SELECT * FROM get_menu_items()").ToList();
                    return menuItems;
                }
            }catch (Exception ex)
            {

                return null;
            }
            
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public async Task<int> InsertMenuAsync(NewsDemo.Domain.Model.Menu menu)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection("Host=localhost;Database=HalloDoc;Username=postgres;Password=1936"))
            {
                dbConnection.Open();
                var parameters = new
                {
                    p_id = menu.MenuId,
                    p_name = menu.Name,
                    p_accounttype = menu.AccountType,
                    p_sortorder = menu.SortOrder
                };
                return await dbConnection.ExecuteAsync("CALL add_menu_item(@p_id, @p_name, @p_accounttype, @p_sortorder)", parameters);
            }
        }
    }
}
