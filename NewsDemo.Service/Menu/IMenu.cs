using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsDemo.Service.Menu
{
    public interface IMenu
    {
        List<NewsDemo.Domain.Model.Menu> get_all_menu();
        Task<int> InsertMenuAsync(NewsDemo.Domain.Model.Menu menu);
    }
}
