using Karma.Business.Abstract;
using Karma.DataAccess.Migrations;
using Karma.Entities;
using Karma.Entities.Concrete;
using Karma.MvcUI.Identity;
using Karma.MvcUI.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Karma.MvcUI.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;
        private readonly IOrderService _orderService;
        private readonly ICampaignService _campaignService;
        private readonly IShowcaseProductsService _showcaseProductsService;
        private readonly UserManager<AppIdentityUser> _userManager;


        public AdminController(IShowcaseProductsService showcaseProductsService, IOrderService orderService, ICampaignService campaignService, IProductService productService, IBrandService brandService, ICategoryService categoryService, IImageService imageService, UserManager<AppIdentityUser> userManager)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
            _imageService = imageService;
            _orderService = orderService;
            _userManager = userManager;
            _campaignService = campaignService;
            _showcaseProductsService = showcaseProductsService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = _productService.GetAll();
            AdminProductsViewModel model = new AdminProductsViewModel()
            {
                Products = products
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var product = _productService.GetById(Id);
            var brands = _brandService.GetAll();
            var categories = _categoryService.GetAll();
            EditProductViewModel model = new EditProductViewModel()
            {
                Product = product,
                BrandListItem = (from x in brands
                                 select new SelectListItem
                                 {
                                     Value = x.BrandId.ToString(),
                                     Text = x.BrandName
                                 }).ToList(),
                CategoryListItem = (from x in categories
                                    select new SelectListItem
                                    {
                                        Value = x.CategoryId.ToString(),
                                        Text = x.CategoryName
                                    }).ToList()
            };
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Products");
        }
        public IActionResult DecreasingProducts()
        {
            var products = _productService.GetProductLessThan5Quantity();
            AdminProductsViewModel model = new AdminProductsViewModel()
            {
                Products = products
            };
            return View(model);
        }
        public IActionResult OutOfStock()
        {
            var products = _productService.OutOfStock();
            AdminProductsViewModel model = new AdminProductsViewModel()
            {
                Products = products
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult DeleteImage(int id, int productId)
        {
            try
            {
                _imageService.DeactiveImage(id);
                return Redirect("~/Admin/Edit/" + productId);
            }
            catch (Exception)
            {

                return Json(BadRequest());
            }

        }
        [HttpPost]
        public IActionResult UploadImage(int ProductId, IFormFile file)
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);
            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                file.CopyTo(stream);
            }
            Image image = new Image()
            {
                Url = filePath,
                ProductId = ProductId
            };
            _imageService.Add(image);
            System.IO.File.Delete(filePath);
            return Redirect("~/Admin/Edit/" + ProductId);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            var brands = _brandService.GetAll();
            var categories = _categoryService.GetAll();
            EditProductViewModel model = new EditProductViewModel()
            {
                BrandListItem = (from x in brands
                                 select new SelectListItem
                                 {
                                     Value = x.BrandId.ToString(),
                                     Text = x.BrandName
                                 }).ToList(),
                CategoryListItem = (from x in categories
                                    select new SelectListItem
                                    {
                                        Value = x.CategoryId.ToString(),
                                        Text = x.CategoryName
                                    }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _productService.Add(product);
                int ProductId = _productService.GetByProductName(product.ProductName).ProductId;
                return Redirect("~/Admin/Edit/" + ProductId);
            }
            catch (Exception ex)
            {
                TempData.Add("bilgi", "Yükleme Sırasında Hata : " + ex.Message);
                return RedirectToAction("AddProduct");
                throw;
            }
        }
        [HttpGet]
        public IActionResult AddProductImage(int productId)
        {
            return View(productId);
        }
        [HttpGet]
        public IActionResult Categories()
        {
            var categories = _categoryService.GetAllActive();
            AdminCategoriesViewModel model = new AdminCategoriesViewModel()
            {
                AllCategories = categories
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult CategoryEdit(int CategoryId)
        {
            var category = _categoryService.GetById(CategoryId);
            CategoryEditViewModel model = new CategoryEditViewModel()
            {
                Category = category
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult CategoryEdit(Category category)
        {
            var Category = _categoryService.GetById(category.CategoryId);
            Category.Active = category.Active;
            Category.CategoryName = category.CategoryName;
            _categoryService.Update(Category);
            return Redirect("~/Admin/CategoryEdit?categoryId=" + category.CategoryId);
        }
        [HttpGet]
        public IActionResult DeleteCategoryImage(int categoryId)
        {
            try
            {

                var category = _categoryService.GetById(categoryId);
                System.IO.File.Delete(category.ImagePath);
                category.ImagePath = "";
                _categoryService.Update(category);
                return Redirect("~/Admin/CategoryEdit?categoryId=" + categoryId);
            }
            catch (Exception ex)
            {

                return Json(BadRequest());
            }

        }
        [HttpPost]
        public IActionResult UploadCategoryImage(int categoryId, IFormFile file)
        {

            var filePath = Path.Combine("wwwroot\\KarmaUI\\img\\kategori", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                file.CopyTo(stream);
            }
            var category = _categoryService.GetById(categoryId);
            category.ImagePath = filePath;
            _categoryService.Update(category);
            return Redirect("~/Admin/CategoryEdit?categoryId=" + categoryId);
        }
        [HttpGet]
        public IActionResult Brands()
        {
            var brands = _brandService.GetAll();
            AdminBrandsViewModel model = new AdminBrandsViewModel()
            {
                Brands = brands
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult BrandEdit(int brandId)
        {
            var brand = _brandService.GetById(brandId);
            BrandEditViewModel model = new BrandEditViewModel()
            {
                Brand = brand
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult BrandEdit(Brand brand)
        {
            var Brandd = _brandService.GetById(brand.BrandId);
            Brandd.Active = brand.Active;
            Brandd.BrandName = brand.BrandName;
            _brandService.Update(Brandd);
            return Redirect("~/Admin/BrandEdit?brandId=" + brand.BrandId);
        }
        [HttpGet]
        public IActionResult DeleteBrandImage(int brandId)
        {
            try
            {

                var brand = _brandService.GetById(brandId);
                System.IO.File.Delete(brand.BrandLogo);
                brand.BrandLogo = "";
                _brandService.Update(brand);
                return Redirect("~/Admin/CategoryEdit?brandId=" + brandId);
            }
            catch (Exception ex)
            {

                return Json(BadRequest());
            }

        }
        [HttpPost]
        public IActionResult UploadBrandImage(int brandId, IFormFile file)
        {

            var filePath = Path.Combine("wwwroot\\KarmaUI\\img\\brand", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                file.CopyTo(stream);
            }
            var brand = _brandService.GetById(brandId);
            brand.BrandLogo = filePath;
            _brandService.Update(brand);
            return Redirect("~/Admin/BrandEdit?brandId=" + brandId);
        }
        [HttpGet]
        public IActionResult ActiveOrders()
        {
            var orders = _orderService.GetAll(1).OrderBy(x => x.Status);
            List<OrdersListModel> ordersList = new List<OrdersListModel>();
            foreach (var order in orders)
            {
                OrdersListModel orderr = new OrdersListModel();
                orderr.UserName = _userManager.FindByIdAsync(order.UserId).Result.UserName;
                orderr.UserId = order.UserId;
                orderr.OrderId = order.OrderId;
                orderr.Total = order.Total;
                orderr.Detail = order.Detail;
                orderr.Status = order.Status;
                orderr.Date = order.Date;
                ordersList.Add(orderr);
            }
            OrderViewModel model = new OrderViewModel()
            {
                Orders = ordersList
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult PostedOrders()
        {
            var orders = _orderService.GetAll(2).OrderBy(x => x.Status);
            List<OrdersListModel> ordersList = new List<OrdersListModel>();
            foreach (var order in orders)
            {
                OrdersListModel orderr = new OrdersListModel();
                orderr.UserName = _userManager.FindByIdAsync(order.UserId).Result.UserName;
                orderr.UserId = order.UserId;
                orderr.OrderId = order.OrderId;
                orderr.Total = order.Total;
                orderr.Detail = order.Detail;
                orderr.Status = order.Status;
                orderr.Date = order.Date;
                ordersList.Add(orderr);
            }
            OrderViewModel model = new OrderViewModel()
            {
                Orders = ordersList
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult CompletedOrders()
        {
            var orders = _orderService.GetAll(3).OrderBy(x => x.Status);
            List<OrdersListModel> ordersList = new List<OrdersListModel>();
            foreach (var order in orders)
            {
                OrdersListModel orderr = new OrdersListModel();
                orderr.UserName = _userManager.FindByIdAsync(order.UserId).Result.UserName;
                orderr.UserId = order.UserId;
                orderr.OrderId = order.OrderId;
                orderr.Total = order.Total;
                orderr.Detail = order.Detail;
                orderr.Status = order.Status;
                orderr.Date = order.Date;
                ordersList.Add(orderr);
            }
            OrderViewModel model = new OrderViewModel()
            {
                Orders = ordersList
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult GetOrder(int Id)
        {
            var order = _orderService.Get(Id);
            var orderDetail = JsonConvert.DeserializeObject<Cart>(order.Detail) == null ? null : JsonConvert.DeserializeObject<Cart>(order.Detail);
            OrderModel model = new OrderModel()
            {
                Order = orderDetail,
                OrderId = Id
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult PostedOrder(int orderId)
        {
            var order = _orderService.Get(orderId);
            order.Status = 2;
            _orderService.Update(order);
            return RedirectToAction("ActiveOrders");
        }
        [HttpGet]
        public IActionResult CompletedOrder(int orderId)
        {
            var order = _orderService.Get(orderId);
            order.Status = 3;
            _orderService.Update(order);
            return RedirectToAction("PostedOrders");
        }
        public IActionResult CampaignProducts()
        {
            var products = _productService.GetAll();
            var campaignedProduct = _campaignService.GetAllActive();
            CampaignProductsPageViewModel model = new CampaignProductsPageViewModel()
            {
                Products = products,
                CampaignedProducts = campaignedProduct
            };
            return View(model);
        }
        public IActionResult AddCampaignProduct(int productId, string campaignPrice)
        {
            var FindProduct = _productService.GetById(productId);
            campaignPrice = campaignPrice.Replace('.', ',');
            CampaignProduct product = new CampaignProduct()
            {
                Product = FindProduct,
                Active = true,
                NewPrice = Convert.ToDouble(campaignPrice)
            };
            _campaignService.Add(product);
            return RedirectToAction("CampaignProducts");
        }
        public IActionResult RemoveCampaignProduct(int campaignId)
        {
            var product = _campaignService.GetById(campaignId);
            _campaignService.Delete(product);
            return RedirectToAction("CampaignProducts");
        }
        public IActionResult UpcomingProducts()
        {
            var products = _productService.GetUpcomingProducts();
            UpcomingViewModel model = new UpcomingViewModel
            {
                Products = products
            };
            return View();
        }
        public IActionResult ShowcaseProducts()
        {
            var allProducts = _productService.GetAll();
            var products = _showcaseProductsService.GetList();
            ShowcaseProductsViewModel model = new ShowcaseProductsViewModel()
            {
                ShowcaseProducts = products,
                Products = allProducts,
            };
            return View(model);
        }
        public IActionResult AddShowcase(int productId)
        {
            var product = _productService.GetById(productId);
            ShowcaseProducts showcaseProducts = new ShowcaseProducts()
            {
                Product = product
            };
            _showcaseProductsService.Add(showcaseProducts);
            return RedirectToAction("ShowcaseProducts");
        }
        public IActionResult DeleteFromShowcase(int showcaseId)
        {
            var showcase = _showcaseProductsService.Get(showcaseId);
            _showcaseProductsService.Delete(showcase);
            return RedirectToAction("ShowcaseProducts");
        }
    }
}
