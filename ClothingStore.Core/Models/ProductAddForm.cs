using Azure.Core.Pipeline;
using ClothingStore.Core.Constants;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using static ClothingStore.Core.Constants.Constants.ProductForumConstants;
using static ClothingStore.Core.Constants.MessageConstants;

namespace ClothingStore.Core.Models
{
    public class ProductAddForm
    {
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Product name")]
        [StringLength(MaxProductNameLenght, MinimumLength = MinProductNameLenght, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Description")]
        [StringLength(MaxDescriptionLenght, MinimumLength = MinDescriptionLenght, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Gender")]
        public IEnumerable<GenderViewModel> Genders { get; set; } = new List<GenderViewModel>();
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Category")]
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Brand")]

        public IEnumerable<BrandViewModel> Brands { get; set; } = new List<BrandViewModel>();
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Colour")]
        public IEnumerable<ColourViewModel> Colours { get; set; } = new List<ColourViewModel>();
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image")]
        
        public byte[] Image { get; set; } = null!;
       
        public string ImageType { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Price")]
        [Range(MinPrice, MaxPrice, ErrorMessage = LengthMessage)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Size")]
        [StringLength(MaxSizeLeght, MinimumLength = MinSizeLeght, ErrorMessage = LengthMessage)]
        [RegularExpression("^[A-Z0-9]+$", ErrorMessage = MessageConstants.SizesError)]
        public string Size { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Quantity")]
        [Range(MinQuantity, MaxQuantity, ErrorMessage = LengthMessage)]
        public int Quantity { get; set; }

        public int GenderId { get; set; }

        public int ColourId { get; set; }

        public int BrandId { get; set; }
       
        public int Sizeid { get; set; }

        public string CategoryName { get; set; } = string.Empty;

    }
}
