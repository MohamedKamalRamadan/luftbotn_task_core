using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core.Model
{
    public class Inv_Details
    {
        [Key]
        public int ID { get; set; } 

        public int Inv_Master_Id { get; set; }
        public int Item_Id { get; set; }

        public decimal Qty { get; set; }
        public decimal Price { get; set; }

        [NotMapped]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Total
        {
            get { return Qty * Price; }
        }

        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("Inv_Master_Id")]
        public virtual Inv_Master Inv_Master { get; set; }

        [ForeignKey("Item_Id")]
        public virtual Items Items { get; set; }
    }
}
