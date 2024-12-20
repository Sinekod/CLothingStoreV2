using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models;
using ClothingStore.Core.Services;
using ClothingStore.Infrastructure.Data;
using ClothingStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ClothingStoreTestingAgain
{
    public class ProductServiceProductTesting
    {
        private ClothingStoreDbContext context;
        private IServiceProducts products;
        private ICommentService commentService;
        private UserManager<IdentityUser> userManager;
        private IOrderService orderService;
        public IdentityUser User { get; set; }
        public Brand Nike { get; set; }
        public Colour Black { get; set; }

        public Gender Male { get; set; }

        public Category Tracksuit { get; set; }

        public Product Product4 { get; set; }

        public ProductImage ProductImage1 { get; set; }

        public Size L { get; set; }

        public ProductItem ProductItem1 { get; set; }

        public Comment Comment1 { get; set; }

        [SetUp]
        public void Setup()
        {


            var options = new DbContextOptionsBuilder<ClothingStoreDbContext>()
                .UseInMemoryDatabase(databaseName: "CreditsInMemoryDb")
                .Options;

            var hasher = new PasswordHasher<IdentityUser>();
            context = new ClothingStoreDbContext(options);

            User = new IdentityUser()
            {
                Id = "e484920a-cb22-45bf-9ace-843a04361194",
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "Pesho@gmail.com",
                NormalizedEmail = "PESHO@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "123456")
            };

            Nike = new Brand() { Id = 1, Name = "Nike" };
            Black = new Colour() { Id = 1, Name = "Black" };
            Male = new Gender() { Id = 1, Name = "Male" };
            Tracksuit = new Category() { Id = 1, CategoryName = "tracksuit", GenderId = Male.Id };
            Product4 = new Product() { Id = 1, Name = "FlairAncung", Description = "Very good for something", CategoryId = Tracksuit.Id, Rating = 3, BrandId = Nike.Id };
            ProductImage1 = new ProductImage() { Id = 1, ColourId = Black.Id, ProductId = Product4.Id, Image = File.ReadAllBytes("C:\\Users\\Acer\\source\\repos\\ClothingStoreAgain\\ClothingStoreAgain\\wwwroot\\Photos\\FlairAncung.jpg"), Price = 120, SalePrice = 90 };
            L = new Size() { Id = 1, Name = "L" };
            ProductItem1 = new ProductItem() { Id = 1, ProductImageId = ProductImage1.Id, SizeId = L.Id, Quantity = 50 };
            Comment1 = new Comment() { Id = 1, CommentText = "Test", ProductItemId = ProductItem1.Id, UserId = User.Id, DateTime = DateTime.Now, Likes = 0, Rating = 5 };

            context.Database.EnsureDeleted();
            context.Brands.Add(Nike);
            context.Colours.Add(Black);
            context.Genders.Add(Male);
            context.Categories.Add(Tracksuit);
            context.Sizes.Add(L);
            context.Products.Add(Product4);
            context.ProductImages.Add(ProductImage1);
            context.ProductItems.Add(ProductItem1);
            context.Comments.Add(Comment1);
            context.Users.Add(User);
            context.SaveChanges();

            products = new ProductService(context);

            // Setup real UserManager
            var userStore = new UserStore<IdentityUser>(context);
            var optionsAccessor = Options.Create(new IdentityOptions());
            var passwordHasher = new PasswordHasher<IdentityUser>();
            var userValidators = new List<IUserValidator<IdentityUser>> { new UserValidator<IdentityUser>() };
            var passwordValidators = new List<IPasswordValidator<IdentityUser>> { new PasswordValidator<IdentityUser>() };
            var keyNormalizer = new UpperInvariantLookupNormalizer();
            var errors = new IdentityErrorDescriber();
            var services = new ServiceCollection().BuildServiceProvider();
            var logger = new LoggerFactory().CreateLogger<UserManager<IdentityUser>>();

            userManager = new UserManager<IdentityUser>(
                userStore,
                optionsAccessor,
                passwordHasher,
                userValidators,
                passwordValidators,
                keyNormalizer,
                errors,
                services,
                logger
            );

            commentService = new CommentService(context, products, userManager);
            orderService = new OrderServices(context, products);

        }

        [Test]
        public async Task CheckProductExist_ProductExists_ReturnsTrue()
        {
            var exist = await products.CheckProductItem(1);

            Assert.IsTrue(exist);


        }
        [Test]
        [TestCase(1)]
        public async Task CheckColourExistById_Products(int number)
        {
            var result = await products.CheckColourExist(number);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task CheckIfBrandExistById_ReturnsTrue()
        {
            var result = await products.CheckBrandExist(1);

            Assert.IsTrue(result);


        }

        [Test]
        public async Task CheckIf_GetProductItemreturnsTheCorrectProductItem()
        {
            var product = await products.GetProductItem(1);


            Assert.IsNotNull(product);
            Assert.AreSame(product, ProductItem1);


        }
        [Test]
        public async Task CheckIf_GetSizeById_ReturnsTheCorrectSize()
        {
            var size = await products.GetSizeById(1);

            Assert.IsNotNull(size);
            Assert.AreEqual(size, L);

        }
        [Test]

        public async Task CheckIf_GetColourId_ReturnsTheCorrecerColour()
        {
            var result = await products.GetColourById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, Black);

        }
        [Test]
        public async Task CheckIf_GetAllBrands_ReturnsAllTheBrands()
        {
            var brands = await products.GetAllBrands();
            Assert.IsNotNull(brands);

            Assert.AreEqual(1, brands.Count());


        }
        [Test]
        public async Task CheckIf_GetAllCategories_ReturnsAllTheCategories()
        {
            var categories = await products.GetAllCategories();
            Assert.IsNotNull(categories);
            Assert.AreEqual(1, categories.Count());



        }
        [Test]
        public async Task GetAllcolours_ReturnsAllTheColours()
        {
            var colours = await products.GetAllColours();

            Assert.AreEqual(1, colours.Count());
            Assert.IsNotNull(colours);


        }

        [Test]
        public async Task CheckIf_GetAllGendders_ReturnsAllTheGenders()
        {
            var genders = await products.GetAllGenders();
            Assert.IsNotNull(genders);
            Assert.AreEqual(1, genders.Count());


        }
        [Test]
        public async Task ChecksCategoryExists()
        {
            var category = await products.CheckCategoryExists("tracksuit", 1);

            Assert.IsTrue(category);

        }
        [Test]
        public async Task GetSizeByName_ReturnsName()
        {
            var sizeName = await products.GetSizeByName("L");
            Assert.IsNotNull(sizeName);
            Assert.AreEqual(sizeName.Name, L.Name);


        }
        [Test]
        public async Task CheckIFproductSizeExist_ReturnsTheRighrThing()
        {
            var result = await products.CheckIfProductSizeExists("L");
            Assert.IsNotNull(result);
            Assert.IsTrue(result);


        }
        [Test]
        public async Task CheckIfProductNameExists_ReturnsTheCorrectAnswer()
        {
            var result = await products.CheckIfProductNameExists(Product4.Name);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

        }
        [Test]
        public async Task ShowDetailsReturnsTheCorespondingProduct()
        {
            var result = await products.ShowDetails(1);
            IEnumerable<ColourViewModel> colours = await products.GetAllColoursForProduct(1);
            IEnumerable<SizeViewModel> sizes = await products.GetAllSizesForProduct(1);

            ProductItemViewModel productImageViewModel = new ProductItemViewModel()
            {
                Id = 1,
                Price = ProductImage1.Price,
                Name = ProductImage1.Product.Name,
                Description = ProductImage1.Product.Description,
                Colours = colours,
                Sizes = sizes,
                Image = ProductImage1.Image,
                Brand = ProductImage1.Product.Brand.Name,
                Category = ProductImage1.Product.Category.CategoryName


            };
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, productImageViewModel.Name);

        }

        [Test]
        public async Task GetAllSizesForAProduct_ReturnsTheCorrectSize()
        {
            var sizes = await products.GetAllSizesForProduct(1);
            var sizeViewModel = new SizeViewModel()
            {
                Id = 1,
                Name = "L",

            };
            var result = sizes.Any(s => s.Id == sizeViewModel.Id && s.Name == sizeViewModel.Name);
            Assert.IsTrue(result);



        }
        [Test]
        public async Task GetAllProductAsyncReturnrsAllTheProducts()
        {
            var allProducts = await products.GetAllProductsImageAsync();
            var result = allProducts.Any(p => p.Id == ProductImage1.Id);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
            Assert.AreEqual(allProducts.Count(), 1);

        }
        [Test]
        public async Task CheckProductExist_ReturnsTrue()
        {
            var result = await products.CheckProductExist(1);

            Assert.IsTrue(result);

        }
        [Test]
        public async Task CheckAddComment_AddsCommentToAProduct()
        {
            var commentViewModel = new CommentViewModel()
            {
                Id = ProductItem1.Id,
                UserName = User.UserName,
                ProductId = 1,
                Text = "Test",
                DateTime = DateTime.Now.ToString(),
                Rating = 5,

            };


            var addComment = await commentService.AddComment(commentViewModel, 1);

            Assert.IsNotNull(addComment);
            Assert.AreEqual(addComment.CommentText, Comment1.CommentText);
            Assert.AreEqual(addComment.Rating, Comment1.Rating);

        }
        [Test]
        public async Task CheckCommentExist_ReturnsTrue()
        {
            var result = await commentService.CheckCommentExist(1);

            Assert.IsTrue(result);

        }
        [Test]
        public async Task CheckIfUserIsTheOwnerOfTheComment()
        {
            var userName = User.UserName;
            var commentId = Comment1.Id;
            var result = await commentService.CheckIfUserIsOwner(userName, commentId);
            Assert.IsTrue(result);

        }
        [Test]
        public async Task DeleteComment_Check()
        {
            var userName = User.UserName;
            var commentId = Comment1.Id;
            await commentService.DeleteComment(commentId, userName);
            var result = await commentService.CheckCommentExist(commentId);
            Assert.IsFalse(result);


        }
        [Test]
        public async Task GetCommentsForProduct()
        {
            var comments = await commentService.ShowComentsForProduct(1);

            Assert.IsNotNull(comments);
            Assert.AreEqual(comments.Count(), 1);

        }
        [Test]
        public async Task PlaceOrderTest()
        {
            var productViewModelList = new List<CartProductViewModel>();

            CartProductViewModel productImageViewModel = new CartProductViewModel()
            {
                Id = 1,
                Price = ProductImage1.Price,
                Name = ProductImage1.Product.Name,
                Colour = ProductImage1.Colour.Name,
                Brand = ProductImage1.Product.Brand.Name,
                Quantity = 10,
                Size = "L",
                ImgUrl = string.Empty,



            };
            productViewModelList.Add(productImageViewModel);
            var order = await orderService.PlaceOrder(productViewModelList);
            Assert.IsNotNull(productViewModelList);
            Assert.AreEqual(order.Count(), 1);


        }




    }
}