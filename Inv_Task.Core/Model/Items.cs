using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core.Model
{
    

    public class Items
    {

        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Item_Name { get; set; }

        public decimal Qty { get; set; }
        public decimal Price { get; set; }

        [NotMapped]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Total_Price {
            get { return Qty * Price; }
        }

        public bool IsDeleted { get; set; }

        public int Store_Id { get; set; }
        public int Category_Id { get; set; }


        [ForeignKey("Store_Id")]
        public virtual Stores Stores { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Categories Categories { get; set; }


    }
}
