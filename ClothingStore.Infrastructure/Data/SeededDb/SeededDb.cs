using Azure.Core.Pipeline;
using ClothingStore.Infrastructure.Data.Models;
using ClothingStoreAgain.Data.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.Json;
using static ClothingStore.Infrastructure.Data.ImageConverter.ImageConverter;

namespace ClothingStore.Infrastructure.Data.SeededDb
{
    public class SeededDb
    {

        public SeededDb()
        {
            SeedSizes();
            SeedUsers();
            
            SeedBrands();
            SeedColours();
            SeedGender();
            SeedCategories();
            SeedProducts();
            SeedProductPictures();
            SeedProductItems();
            SeedComment();
        
            
        }

        public IdentityRole Admin { get; set; }

        public IdentityRole User { get; set; }

        public IdentityUserRole<string> IdentityUserRole { get; set; }

        public Size S { get; set; }

        public Size M { get; set; }

        public Size L { get; set; }

        public Size ShoeSize { get; set; }

        public Size SockSize { get; set; }
        public IdentityUser Pesho { get; set; }
        public Brand Nike { get; set; }
        public Brand Flair { get; set; }
        public Brand Adidas { get; set; }
        public Category Jacket { get; set; }
        public Category tracksuit { get; set; }

        public Category Socks { get; set; }

        public Category Shoes { get; set; }

        public Colour Black { get; set; }

        public Colour White { get; set; }

        public Colour Red { get; set; }

        public Comment Comment1 { get; set; }
        public Comment Comment2 { get; set; }

        public Comment Comment3 { get; set; }

        public Gender Male { get; set; }

        public Gender Female { get; set; }

        public Product Product4 { get; set; }

        public Product Product5 { get; set; }
        public Product Product2 { get; set; }

        public Product Product3 { get; set; }

        public ProductImage ProductImage1 { get; set; }

        public ProductImage ProductImage2 { get; set; }

        public ProductImage ProductImage3 { get; set; }

        public ProductImage ProductImage4 { get; set; }

        public ProductItem ProductItem1 { get; set; }

        public ProductItem ProductItem2 { get; set; }

        public ProductItem ProductItem3 { get; set; }
        

        public ProductItem ProductItem4 { get; set; }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            Pesho = new IdentityUser()
            {
                Id = "e484920a-cb22-45bf-9ace-843a04361194",
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "Pesho@gmail.com",
                NormalizedEmail = "PESHO@GMAIL.COM",

            };

            Admin = new IdentityRole()
            { 
              Id = "c6c3988d-9285-4569-bb8a-9eff133165da",
              Name = "Admin",
              NormalizedName = "admin".ToUpper(),
              ConcurrencyStamp = "c6c3988d-9285-4569-bb8a-9eff133165da"

            };

            Pesho.PasswordHash = hasher.HashPassword(Pesho, "Pesho123");


            IdentityUserRole = new IdentityUserRole<string>()
            {
                RoleId= Admin.Id,
                UserId = Pesho.Id,
                
            };
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
                Name = "Red"


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


        }
        private void SeedCategories()
        {
            tracksuit = new Category()
            {
                Id = 1,
                CategoryName = "tracksuit",
                GenderId = Male.Id,

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
            Jacket = new Category()
            {
                Id = 4,
                CategoryName = "Jacket",
                GenderId = Female.Id,

            };



        }
        private void SeedProducts()
        {
            Product4 = new Product()
            {
                Id = 1,
                Name = "FlairAncung",
                Description = "Very good for something",
                CategoryId = tracksuit.Id,
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
                Name = "NikeSocks",
                Description = "Very bad for something else",
                CategoryId = Socks.Id,
                Rating = 4,
                BrandId = Nike.Id,


            };
            Product5 = new Product
            {
                Id = 4,
                Name = "Adidas Jacket",
                Description = "Very bad for summer",
                CategoryId = Jacket.Id,
                Rating = 5,
                BrandId = Adidas.Id,


            };
        }
        private void SeedProductPictures()
        {
            ProductImage1 = new ProductImage()
            {
                Id = 1,
                ColourId = Black.Id,
                ProductId = Product4.Id,
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
            ProductImage4 = new ProductImage()
            {
                Id = 4,
                ColourId = Black.Id,
                ProductId = Product5.Id,
                Image = ImageToByteArray("C:\\Users\\Acer\\source\\repos\\ClothingStoreAgain\\ClothingStoreAgain\\wwwroot\\Photos\\Addidas Jacket.jpg"),
                Price = 75
            };


        }

        private void SeedProductItems()
        {
            ProductItem1 = new ProductItem()
            {
                Id = 1,
                ProductImageId = ProductImage1.Id,
                SizeId = L.Id,
                Quantity = 50

            };
            ProductItem2 = new ProductItem()
            {
                Id = 2,
                ProductImageId = 2,
                SizeId = ShoeSize.Id,
                Quantity = 30

            };
            ProductItem3 = new ProductItem()
            {
                Id = 3,
                ProductImageId = 3,
                SizeId = SockSize.Id,
                Quantity = 70

            };


            ProductItem4 = new ProductItem()
            {
                Id = 4,
                ProductImageId = ProductImage4.Id,
                SizeId = M.Id,
                Quantity = 80

            };
        }
        private void SeedComment()
        {
            Comment1 = new Comment()
            {
                Id = 1,
                CommentText = "I liked it very much",
                ProductItemId = ProductItem4.Id,
                UserId = Pesho.Id,
                DateTime = DateTime.Now,
                Likes = 0,
                Rating = 5,
            };
            Comment2 = new Comment()
            {
                Id = 2,
                CommentText = "I liked it very much, but not that much",
                ProductItemId = 2,
                UserId = Pesho.Id,
                DateTime = DateTime.Now,
                Likes = 0,
                Rating = 3,
            };
            Comment3 = new Comment()
            {
                Id = 3,
                CommentText = "Fuck this shit",
                ProductItemId = 3,
                UserId = Pesho.Id,
                DateTime = DateTime.Now,
                Likes = 0,
                Rating = 1,
            };

        }
       
        


        private void SeedSizes()
        {
            L = new Size()
            {
                Id = 1,
                Name = "L"

            };
            M = new Size()
            {
                Id = 2,
                Name = "M"

            };
            S = new Size()
            {
                Id = 3,
                Name = "S"

            };

            ShoeSize = new Size()
            {
                Id = 4,
                Name = "42"


            };
            SockSize = new Size()
            {
                Id = 5,
                Name = "44"

            };



        }

    }
}
