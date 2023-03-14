using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            //string jsonInput = File.ReadAllText(@"../../../Datasets/categories-products.json");

            string result = GetSoldProducts(context);
            Console.WriteLine(result);
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDto[] users = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            HashSet<User> validUsers = new HashSet<User>();

            foreach (var u in users)
            {
                User user = new User()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                };

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductsDto[] productDtos =
                 JsonConvert.DeserializeObject<ImportProductsDto[]>(inputJson);

            HashSet<Product> validProducts = new HashSet<Product>();

            foreach (ImportProductsDto pr in productDtos)
            {
                Product product = new Product()
                {
                    Name = pr.Name,
                    Price = pr.Price,
                    SellerId = pr.SellerId,
                    BuyerId = pr.BuyerId
                };

                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ImportCategoryDto[] categories =
                JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            HashSet<Category> validCategories = new HashSet<Category>();

            foreach (var c in categories)
            {
                if (String.IsNullOrEmpty(c.Name))
                {
                    continue;
                }

                Category category = new Category()
                {
                    Name = c.Name
                };

                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoryProductDto[] categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            HashSet<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();

            foreach (ImportCategoryProductDto cp in categoryProductDtos)
            {
                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                };

                validCategoryProducts.Add(categoryProduct);
            }

            context.CategoriesProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                                    .Select(ps => new
                                    {
                                        name = ps.Name,
                                        price = ps.Price,
                                        buyerFirstName = ps.Buyer.FirstName,
                                        buyerLastName = ps.Buyer.LastName
                                    })
                                    .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}