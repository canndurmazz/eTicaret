using eTicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.DataAccsess.Abstract
{
    public interface IETicaretRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int ıd);
        Category CreateCategory(Category category);
        Category UpdateCategory(Category category);
        Category GetProductByCategoryId(int ıd);
        void DeleteCategoryById(int ıd);



        List<Product> GetAllProduct();
        Product GetProductById(int ıd);
        Product UpdateProductStock(int ıd, int newstock);
        Product UpdateProduct(Product product);
        //Product CreateProduct(Product product);
        Product CreateProduct(int ıd);
        void DeleteProductById(int ıd);


        List<WaitingProduct> GetAllWaitingProduct();
        WaitingProduct GetWaitingProductById(int ıd);
        WaitingProduct UpdateWaitingProduct(WaitingProduct product);
        WaitingProduct CreateWaitingProduct(WaitingProduct product);
        void DeleteWaitingProductById(int ıd);


        List<Customer> GetAllCustomer();
        Customer GetCustomertById(int ıd);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomerById(int ıd);


        Shopping CreateShopping(Shopping shopping);
        List<Shopping> GetAllShopping();
        Shopping GetShoppingById(int ıd);
        void ReturnShoppingById(int ıd);
        void DeleteShoppingById(int ıd);


        List<Company> GetAllCompanies();
        Company GetCompanyById(int ıd);
        Company CreateCompany(Company company);
        Company UpdateCompany(Company company);
        void DeleteCompanyById(int ıd);

        List<Admin> GetAdmins();
        List<ChangeLog> GetAllChangeLogs();
    }
}
