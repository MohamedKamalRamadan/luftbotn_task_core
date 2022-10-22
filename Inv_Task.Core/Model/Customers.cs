using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core.Model
{
    public class Customers
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [StringLength(15)]
        public string? Phone { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        public bool IsDeleted { get; set; }


    }
}
