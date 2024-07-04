using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsDemo.Domain.Model
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public short AccountType { get; set; }
        public int SortOrder { get; set; }
    }
}
