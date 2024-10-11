namespace ClothingStore.Core.Models
{
    public class ProductItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public byte[] Image { get; set; }

        public string ImgIrl { get; set; } = string.Empty;

        public decimal Price  { get; set; }

        public IEnumerable<string> Sizes { get; set; } = new List<string>();

        public IEnumerable<ColourViewModel> Colours { get; set; } = new List<ColourViewModel>();

        public string Brand { get; set; } =string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}