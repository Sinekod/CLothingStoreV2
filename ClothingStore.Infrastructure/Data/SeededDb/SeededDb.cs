using ClothingStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static ClothingStore.Infrastructure.Data.ImageConverter.ImageConverter;

namespace ClothingStore.Infrastructure.Data.SeededDb
{
    public class SeededDb
    {

        public SeededDb()
        {
            SeedUsers();
            SeedBrands();
            SeedColours();
            SeedGender();
            SeedCategories();
            SeedProducts();
            SeedProductPictures();
            SeedProductItems();
            SeedComment();
            SeedOrers();
            DeliveryToAddress();

        }



        public IdentityUser User { get; set; }
        public Brand Nike { get; set; }
        public Brand Flair { get; set; }
        public Brand Adidas { get; set; }

        public Category Pants { get; set; }

        public Category Socks { get; set; }

        public Category Shoes { get; set; }

        public Colour Black { get; set; }

        public Colour White { get; set; }

        public Colour Red { get; set; }


        public Comment Comment1 { get; set; }
        public Comment Comment2 { get; set; }

        public Comment Comment3 { get; set; }

        public DeliveryToAddress DeliveryToAddress1 { get; set; }

        public Gender Male { get; set; }

        public Gender Female { get; set; }

        public Gender Bisexual { get; set; }

        public Order Order1 { get; set; }

        public Product Product1 { get; set; }

        public Product Product2 { get; set; }

        public Product Product3 { get; set; }

        public ProductImage ProductImage1 { get; set; }

        public ProductImage ProductImage2 { get; set; }

        public ProductImage ProductImage3 { get; set; }

        public ProductItem ProductItem1 { get; set; }

        public ProductItem ProductItem2 { get; set; }

        public ProductItem ProductItem3 { get; set; }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            User = new IdentityUser()
            {
                Id = "e484920a-cb22-45bf-9ace-843a04361194",
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "Pesho@gmail.com",
                NormalizedEmail = "PESHO@GMAIL.COM",

            };
            User.PasswordHash = hasher.HashPassword(User, "Pesho123");

        }
        private void SeedBrands()
        {
            Nike = new Brand()
            {
                Id = 1,
                Name = "Nike"

            };
            Adidas = new Brand()
            {
                Id = 2,
                Name = "Adidas"

            };
            Flair = new Brand()
            {
                Id = 3,
                Name = "Flair"

            };
        }
        private void SeedColours()
        {
            Black = new Colour()
            {
                Id = 1,
                Name = "Black"

            };
            White = new Colour()
            {
                Id = 2,
                Name = "White"
            };
            Red = new Colour()
            {
                Id = 3,
                Name = "red"


            };


        }
        private void SeedGender()
        {
            Male = new Gender()
            {
                Id = 1,
                Name = "Male"
            };
            Female = new Gender()
            {
                Id = 2,
                Name = "Female"
            };
            Bisexual = new Gender()
            {
                Id = 3,
                Name = "Bisexual"
            };

        }
        private void SeedCategories()
        {
            Pants = new Category()
            {
                Id = 1,
                CategoryName = "Pants",
                GenderId = Bisexual.Id,

            };
            Shoes = new Category()
            {
                Id = 2,
                CategoryName = "Shoes",
                GenderId = Male.Id,

            };
            Socks = new Category()
            {
                Id = 3,
                CategoryName = "Socks",
                GenderId = Female.Id,

            };



        }
        private void SeedProducts()
        {
            Product1 = new Product()
            {
                Id = 1,
                Name = "FlairAncung",
                Description = "Very good for something",
                CategoryId = Pants.Id,
                Rating = 3,
                BrandId = Flair.Id,

            };
            Product2 = new Product()
            {
                Id = 2,
                Name = "ShoesAdidas",
                Description = "Very good for something else",
                CategoryId = Shoes.Id,
                Rating = 2,
                BrandId = Adidas.Id,

            };
            Product3 = new Product()
            {
                Id = 3,
                Name = "Product3",
                Description = "Very bad for something else",
                CategoryId = Socks.Id,
                Rating = 4,
                BrandId = Nike.Id,


            };

        }
        private void SeedProductPictures()
        {
            ProductImage1 = new ProductImage()
            {
                Id = 1,
                ColourId = Black.Id,
                ProductId = 1,
                Image = ImageToByteArray("C:\\Users\\Acer\\source\\repos\\ClothingStoreAgain\\ClothingStoreAgain\\wwwroot\\Photos\\FlairAncung.jpg"),
                Price = 120,
                SalePrice = 90,

            };
            ProductImage2 = new ProductImage()
            {
                Id = 2,
                ColourId = White.Id,
                ProductId = 2,
                Image = ImageToByteArray("C:\\Users\\Acer\\source\\repos\\ClothingStoreAgain\\ClothingStoreAgain\\wwwroot\\Photos\\AdidasShoes.png"),
                Price = 150,

            };
            ProductImage3 = new ProductImage()
            {
                Id = 3,
                ColourId = White.Id,
                ProductId = 3,
                Image = ImageToByteArray("C:\\Users\\Acer\\source\\repos\\ClothingStoreAgain\\ClothingStoreAgain\\wwwroot\\Photos\\NikeSocks.jpg"),
                Price = 20,

            };

        }

        private void SeedProductItems()
        {
            ProductItem1 = new ProductItem()
            {
                Id = 1,
                ProductImageId = 1,
                Size = "L",
                Quantity = 50

            };
            ProductItem2 = new ProductItem()
            {
                Id = 2,
                ProductImageId = 2,
                Size = "42",
                Quantity = 30

            };
            ProductItem3 = new ProductItem()
            {
                Id = 3,
                ProductImageId = 3,
                Size = "40",
                Quantity = 70

            };

        }
        private void SeedComment()
        {
            Comment1 = new Comment()
            {
                Id = 1,
                CommentText = "I liked it very much",
                ProductItemId = 1,
            };
            Comment2 = new Comment()
            {
                Id = 2,
                CommentText = "I liked it very much, but not that much",
                ProductItemId = 2,
            };
            Comment3 = new Comment()
            {
                Id = 3,
                CommentText = "Fuck this shit",
                ProductItemId = 3,
            };

        }
        private void SeedOrers()
        {
            Order1 = new Order()
            {
                Id = 1,
                UserId = User.Id,
                ProductItemId = 1,
                Quantity = 2,
                DateWhenOrdered = DateTime.Now,


            };

        }
        private void DeliveryToAddress()
        {
            DeliveryToAddress1 = new DeliveryToAddress()
            {
                Id = 1,
                CityName = "Sofia",
                PhoneNumber = "089 236 7845",
                Number = 5,
                StreetName = "Ivan Vazov",
                OrderId = Order1.Id,


            };


        }


    }
}
