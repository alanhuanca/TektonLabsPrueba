using Tekton.Dominio.Common;

namespace Tekton.Dominio
{
    public class Product : BaseDomainModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;         
        public decimal Price { get; set; }
    }

    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }

    public class DiscountProduct
    {
        public int Discount { get; set; }
        public string? ProductId { get; set; }
    }
}
