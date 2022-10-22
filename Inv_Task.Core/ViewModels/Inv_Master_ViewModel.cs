using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core.ViewModels
{
    public class Inv_Master_ViewModel
    {
        public int? id { get; set; }
        public int code { get; set; }
        public DateTime invoiceDate { get; set; }
       
        public int customer_Id { get; set; }

        public List<Inv_Details_ViewModel> Inv_Details { get; set; }
    }

}
