namespace Inv_Task.Core.ViewModels
{
    public class Inv_Details_ViewModel
    {
        public int Item_Id { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
         public DateTime CreationDate { get; set; } = DateTime.Now;
    }

}
