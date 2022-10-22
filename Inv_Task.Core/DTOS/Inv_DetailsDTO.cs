namespace Inv_Task.Core.ViewModel
{
    public class Inv_DetailsDTO
    {
        public int ID { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Item_Id { get; set; }
        public  ItemsDTO Items { get; set; }
    }


}
