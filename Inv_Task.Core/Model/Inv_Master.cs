using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core.Model
{
    public class Inv_Master
    {
        [Key]
        public int ID { get; set; }

        public int Code { get; set; }
        public DateTime InvoiceDate { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; }


        public int Customer_Id { get; set; }

        [ForeignKey("Customer_Id")]
        public Customers Customers { get; set; }
        public List<Inv_Details>? Inv_Details { get; set; }


    }
}
