using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core.Model
{
    public class Categories
    {
        [Key]
        public int ID { get; set; }

        public string Category_Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
