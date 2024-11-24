using System.ComponentModel.DataAnnotations;
using static ClothingStore.Core.Constants.MessageConstants;

namespace ClothingStore.Core.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public int ProductId { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        public string Text { get; set; } = string.Empty;

        public string DateTime { get; set; } = string.Empty;
        [Required(ErrorMessage =RequiredMessage)]
        public int Rating { get; set;  }

        public int Likes { get; set; }

    }
}
