using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core.Model
{
    public class Stores
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string StoreName { get; set; }

        public bool IsDeleted { get; set; }


    }
}
