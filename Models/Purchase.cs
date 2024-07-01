namespace fromscratch_back.Models;

public class Purchase
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public IEnumerable<PurchaseItem>? PurchaseItems { get; set; }
    }

    public class PurchaseItem
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
