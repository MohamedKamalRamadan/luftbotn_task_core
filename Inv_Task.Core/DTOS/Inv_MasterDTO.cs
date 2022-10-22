using Inv_Task.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Task.Core.ViewModel
{
    public class Inv_MasterDTO   
    {
        public int ID { get; set; }
        public int Code { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public int Customer_Id { get; set; }

        public CustomerDTO Customers { get; set; }

        public List<Inv_DetailsDTO> Inv_Details { get; set; }
    }


}
