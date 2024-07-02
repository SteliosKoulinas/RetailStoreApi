namespace fromscratch_back.Models;

public class Purchase
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public IEnumerable<PurchaseItem>? PurchaseItems { get; set; }
    }

    public class PurchaseItem
    {
        public Guid Id { get; set; }
        public Guid PurchaseId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
