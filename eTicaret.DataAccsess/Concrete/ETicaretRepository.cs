using eTicaret.DataAccsess.Abstract;
using eTicaret.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eTicaret.DataAccsess.Concrete
{
    public class ETicaretRepository : IETicaretRepository
    {
        private readonly ETicaretDbContext context;
        public ETicaretRepository(ETicaretDbContext context)
        {
            this.context = context;
        }
        #region C A T E G O R Y
        public Category CreateCategory(Category category)
        {             
            context.Categories.Add(category);           
            context.SaveChanges();
            return category;
        }

        public Category GetCategoryById(int ıd)
        {
            var categoris = context.Categories.Select(p => p.CategoryId).ToList();
            if (categoris.Contains(ıd))
            {
                return context.Categories.SingleOrDefault(c => c.CategoryId == ıd);
            }
            else
            {
                throw new Exception("Kategori bulunamadı, bulunamayan kategori id" + " " + ıd);
            }          
        }

        public Category GetProductByCategoryId(int ıd)
        {
            var category = context.Categories.Include(p => p.Products).ThenInclude(p =>  p.Stock).Include(p=>p.Products).ThenInclude(p=>p.ProductInformation).SingleOrDefault(p => p.CategoryId == ıd);
            if (category == null)
            {
                throw new Exception("Kategori bulunamadı, bulunamayan kategori id" + " " + ıd);
            }
            else
                return category;
        }

        public void DeleteCategoryById(int ıd)
        {
            var deletedCategory = GetCategoryById(ıd);
            context.Categories.Remove(deletedCategory);
            context.SaveChanges();
        }
        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }
        public Category UpdateCategory(Category category)
        {
            if (category == null)
            {
                throw new Exception("Kategori bulunamadı, bulunamayan kategori id" + " " + category.CategoryId);
            }
            else
            {
                var cıd = context.Categories.Single(p => p.CategoryId == category.CategoryId);
                context.Categories.Update(category);
                context.SaveChanges();
                return category;
            }     
           
        }
        #endregion

        #region P R O D U C T
        public List<Product> GetAllProduct()
        {
            return context.Products.Include(p => p.ProductInformation).Include(p => p.Stock).ToList();
        }

        public Product GetProductById(int ıd)
        {
            var shoppings = context.Products.Select(p => p.ProductId).ToList();
            if (shoppings.Contains(ıd))
            {
                return context.Products.Include(p => p.ProductInformation).Include(p => p.Stock).FirstOrDefault(c => c.ProductId == ıd);
            }
            else
            {
                throw new Exception("Ürün bulunamadı, bulunamayan ürün id" + " " + ıd);
            }
        }


        public void DeleteProductById(int ıd)
        {          
            var deleteProduct = GetProductById(ıd);                   
            var company = GetCompanyById(deleteProduct.CompanyId);
            var companyProduct = company.CompanyProduct;
            UpdateCompany(company);
            context.Products.Remove(deleteProduct);
            var ps = context.Products.Count(p => p.CompanyId == deleteProduct.CompanyId)-1;
            companyProduct.ProductCount = ps;
            UpdateCompany(company);
            context.SaveChanges();
        }
        //public Product CreateProduct(Product product)
        //{
        //    if (product.Price < 0)
        //    {
        //        throw new Exception("Fiyat İçin Negatif Değer Girilemez.");
        //    }
        //    else
        //    {
        //        context.Products.Add(product);
        //        var company = GetCompanyById(product.CompanyId);
        //        if (company != null)
        //        {
        //            var companyProduct = company.CompanyProduct;
        //            var ps = context.Products.Count(p => p.CompanyId == product.CompanyId) + 1;
        //            companyProduct.ProductCount = ps;
        //            UpdateCompany(company);

        //        }
        //        else
        //        {
        //            throw new Exception("Şirket bulunamadı, bulunamayan şirket id" + " " + company.CompanyId);
        //        }
        //    }
        //    var request = GetWaitingProductById(1);
        //    var request2 = GetProductById(8);
        //    context.SaveChanges();
        //    return product;
        //}
        public Product CreateProduct(int ıd)
        {
            var request = GetWaitingProductById(ıd);
            Product product = new();
            product.CategoryId = request.CategoryId;
            product.CompanyId = request.CompanyId;
            product.Name = request.Name;
            product.Price = request.Price;
            var stock = request.Stock.StockProduct;

            product.Stock = new() { StockProduct = request.Stock.StockProduct,SoldProduct= request.Stock.SoldProduct };
            product.ProductInformation = new() { Information = request.ProductInformation.Information };
            context.Products.Add(product);
            var company = GetCompanyById(request.CompanyId);
            var companyProduct = company.CompanyProduct;
            var ps = context.Products.Count(p => p.CompanyId == product.CompanyId) + 1;
            if (ps == 0)
            {
                companyProduct.ProductCount = 0;
            }
            else
            {
                companyProduct.ProductCount = ps;
            }
            UpdateCompany(company);
            context.WaitingProducts.Remove(request);
            context.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {

            if (product == null)
            {
                throw new Exception("Ürün bulunamadı, bulunamayan ürün id" + " " + product.ProductId);
            }
            else
            {
                if (product.Price > 0)
                {
                    context.Products.Update(product);
                    context.SaveChanges();
                    return product;
                }
                else
                {
                    throw new Exception("Fiyat İçin Negatif Veya '0' Değer Girilemez.");
                }
            }      
        }

        public Product UpdateProductStock(int ıd, int newstock)
        {
            if (newstock >= 0)
            {
                var prd = GetProductById(ıd);
                prd.Stock.StockProduct = newstock;
                context.Products.Update(prd);
                context.SaveChanges();
                return prd;
            }
            else
            {
                throw new Exception("Stock İçin Negatif Değer Girilemez.");
            }
        }
        #endregion

        #region W A İ T İ N G   P R O D U C T
        public WaitingProduct CreateWaitingProduct(WaitingProduct product)
        {
            var categories = context.Categories.Select(p => p.CategoryId).ToList();
            if (product.Price < 0)
            {
                throw new Exception("Fiyat İçin Negatif Değer Girilemez.");
            }
            else
            {
                context.WaitingProducts.Add(product);
                var company = GetCompanyById(product.CompanyId);
                if (company != null)
                {
                    if (categories.Contains(product.CategoryId))
                    {                      
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Kategori bulunamadı, bulunamayan kategori id" + " " + product.CategoryId);
                    }
                }
                else
                {
                    throw new Exception("Şirket bulunamadı, bulunamayan şirket id" + " " + company.CompanyId);
                }
            }
            return product;
        }
        public WaitingProduct UpdateWaitingProduct(WaitingProduct product)
        {

            if (product == null)
            {
                throw new Exception("Ürün bulunamadı, bulunamayan ürün id" + " " + product.WaitingProductId);
            }
            else
            {
                if (product.Price > 0)
                {
                    context.WaitingProducts.Update(product);
                    context.SaveChanges();
                    return product;
                }
                else
                {
                    throw new Exception("Fiyat İçin Negatif veya '0' Değer Girilemez.");
                }
            }
        }
        public void DeleteWaitingProductById(int ıd)
        {
            var deleteProduct = GetWaitingProductById(ıd);
            context.WaitingProducts.Remove(deleteProduct);
            context.SaveChanges();
        }
        public WaitingProduct GetWaitingProductById(int ıd)
        {
            var waitingproducts = context.WaitingProducts.Select(p => p.WaitingProductId).ToList();
            if (waitingproducts.Contains(ıd))
            {
                return context.WaitingProducts.Include(p => p.ProductInformation).Include(p => p.Stock).FirstOrDefault(c => c.WaitingProductId == ıd);
            }
            else
            {
                throw new Exception("Ürün bulunamadı, bulunamayan ürün id" + " " + ıd);
            }
        }
        public List<WaitingProduct> GetAllWaitingProduct()
        {
            return context.WaitingProducts.Include(p => p.ProductInformation).Include(p => p.Stock).ToList();
        }
        #endregion

        #region C U S T O M E R
        public List<Customer> GetAllCustomer()
        {
            return context.Customers.Include(p => p.Address).ToList();
        }

        public Customer GetCustomertById(int ıd)
        {
            var customers = context.Customers.Select(p=>p.CustomerId).ToList();
            if (customers.Contains(ıd))
            {
                return context.Customers.Include(p => p.Address).FirstOrDefault(c => c.CustomerId == ıd);
            }
            else
            {
                throw new Exception("Müşteri bulunamadı, bulunamayan müşteri id" + " " + ıd);
            }
        }

        public Customer CreateCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            if (customer.CustomerId != null)
            {
                context.Customers.Update(customer);
                context.SaveChanges();
                return customer;
            }
            else
                throw new Exception("Müşteri bulunamadı, bulunamayan müşteri id" + " " + customer.CustomerId);
        }

        public void DeleteCustomerById(int ıd)
        {
            var customers = context.Customers.Select(p => p.CustomerId).ToList();
            if (customers.Contains(ıd))
            {
                var deleteCustomer = GetCustomertById(ıd);
                context.Customers.Remove(deleteCustomer);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Müşteri bulunamadı, bulunamayan müşteri id" + " " + ıd);
            }
        }
        #endregion

        #region S H O P P İ N G 
        public Shopping CreateShopping(Shopping shopping)
        {
            var customer = GetCustomertById(shopping.CustomerId);
            var product = GetProductById(shopping.ProductId);         
            var company = GetCompanyById(product.CompanyId);
            var category = GetCategoryById(product.CategoryId);
            var stockproduct = product.Stock.StockProduct;
            var soldproduct = product.Stock.SoldProduct;
            var companyEarning = company.CompanyEarning;
            double earning,kesinti;
            if (stockproduct >= shopping.Piece)
             {
                try
                {
                product.Stock.StockProduct = product.Stock.StockProduct - shopping.Piece;
                product.Stock.SoldProduct = product.Stock.SoldProduct + shopping.Piece;
                double count = (double)(product.Price * shopping.Piece);
                    double share = (double)category.Share;
                    if (share > 0.0)
                    {
                        double oran = (double)(category.Share);
                        kesinti = (double)oran * shopping.Piece;
                        earning = count - kesinti;
                    }
                    else
                    {
                        kesinti = 0;
                        earning = count;
                    }
                    shopping.Share = (double)category.Share;
                    shopping.CompanyId = product.CompanyId;
                    shopping.ProductId = product.ProductId;
                    shopping.Earning = earning;
                    shopping.CustomerId = customer.CustomerId;
                    shopping.Count = count;
                    shopping.Created = DateTime.UtcNow;
                    shopping.SitesEarning = kesinti;
                    companyEarning.TotalEarning = (int)context.Shoppings.Sum(s => s.Earning);

                    context.Shoppings.Add(shopping);
                    context.SaveChanges();
                  }
                  catch (DbUpdateConcurrencyException ex)
                  {
                    ex.Entries.Single().Reload();
                    context.SaveChanges();
                  }
                  return shopping;
            }
            else
                  {
                    throw new Exception("Yeterli Stok Yok");
                  }
        }
        public void ReturnShoppingById(int ıd)
        {
            var shoppings = context.Shoppings.ToList();

            var shopping = GetShoppingById(ıd);
            var customer = GetCustomertById(shopping.CustomerId);
            var product = GetProductById(shopping.ProductId);
            var company = GetCompanyById(product.CompanyId);
            var category = GetCategoryById(product.CategoryId);
            var companyEarning = company.CompanyEarning;        
            if (shoppings != null)
            {
                product.Stock.SoldProduct = product.Stock.SoldProduct - shopping.Piece;
                product.Stock.StockProduct = product.Stock.StockProduct + shopping.Piece;
                context.Shoppings.Remove(shopping);
                context.Products.Update(product);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Sipariş bulunamadı, bulunamayan sipariş id" + " " + ıd);
            }

        }
        public Shopping GetShoppingById(int ıd)
        {
            var shoppings = context.Shoppings.Select(p=>p.ShoppingId).ToList();
            if (shoppings.Contains(ıd))
            {
                return context.Shoppings.FirstOrDefault(c => c.ShoppingId == ıd);
            }
            else
            {
                throw new Exception("Sipariş bulunamadı, bulunamayan sipariş id" + " " + ıd);
            }
        }
        public void DeleteShoppingById(int ıd)
        {
            var shoppings = context.Shoppings.Select(p => p.ShoppingId).ToList();
            if (shoppings.Contains(ıd))
            {
                var deleteShopping = GetShoppingById(ıd);
                context.Shoppings.Remove(deleteShopping);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Sipariş bulunamadı, bulunamayan sipariş id" + " " + ıd);
            }

        }     
        public List<Shopping> GetAllShopping()
        {
            return context.Shoppings.ToList();
        }


        #endregion

        #region C O M P A N Y
        public List<Company> GetAllCompanies()
        {
            return context.Companies.Include(p=>p.CompanyEarning).Include(p=>p.CompanyProduct).ToList();
        }

        public Company GetCompanyById(int ıd)
        {
            var companies = context.Companies.Select(p=>p.CompanyId).ToList();
            if (companies.Contains(ıd))
            {
                return context.Companies.Include(p => p.CompanyEarning).Include(p => p.CompanyProduct).FirstOrDefault(p => p.CompanyId == ıd);
            }
            else
            {
                throw new Exception("Şirket bulunamadı, bulunamayan şirket id" + " " + ıd);
            }

        }
        
        public Company CreateCompany(Company company)
        {        
            context.Companies.Add(company);
            context.SaveChanges();
            return company;
        }

        public Company UpdateCompany(Company company)
        {
            if (company != null)
            {
                context.Companies.Update(company);
                context.SaveChanges();
                return company;
            }
            else
            {
                throw new Exception("Şirket bulunamadı, bulunamayan şirket id" + " " + company.CompanyId);
            }
          
        }

        public void DeleteCompanyById(int ıd)
        {
            var companies = context.Companies.Select(p => p.CompanyId).ToList();
            if (companies.Contains(ıd))
            {
                var deletedCompany = GetCompanyById(ıd);
                context.Companies.Remove(deletedCompany);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Şirket bulunamadı, bulunamayan şirket id" + " " +ıd);
            }
        }

        #endregion

        #region C H A N G E   L O G
        public List<ChangeLog> GetAllChangeLogs()
        {
           return context.ChangeLogs.ToList();
        }
        #endregion

        #region A D M İ N
        public List<Admin> GetAdmins()
        {
            return context.Admins.ToList();
        }
        #endregion

    }
}