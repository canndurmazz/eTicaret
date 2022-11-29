using eTicaret.Entities;
using ETicaret.Conctrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.Abstract
{
    public interface IETicaretService
    {
        List<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(int ıd);
        CategoryDto CreateCategory(CategoryDto category);
        CategoryDto UpdateCategory(CategoryDto category);
        CategoryDto GetProductByCategoryId(int ıd);
        void DeleteCategoryById(int ıd);


        List<ProductDto> GetAllProduct();
        ProductDto GetProductById(int ıd);
        ProductDto UpdateProduct(ProductDto product);
        ProductDto UpdateProductStock(int ıd, int newstock);
        //ProductDto CreateProduct(ProductDto product);
        ProductDto CreateProduct(int ıd);
        void DeleteProductById(int ıd);


        List<WaitingProductDto> GetAllWaitingProduct();
        WaitingProductDto GetWaitingProductById(int ıd);
        WaitingProductDto UpdateWaitingProduct(WaitingProductDto product);
        WaitingProductDto CreateWaitingProduct(WaitingProductDto product);
        void DeleteWaitingProductById(int ıd);



        List<CustomerDto> GetAllCustomer();
        CustomerDto GetCustomertById(int ıd);
        CustomerDto CreateCustomer(CustomerDto customer);
        CustomerDto UpdateCustomer(CustomerDto customer);
        void DeleteCustomerById(int ıd);

        ShoppingDto CreateShopping(ShoppingDto shopping);
        List<ShoppingDto> GetAllShopping();
        void ReturnShoppingById(int ıd);
        ShoppingDto GetShoppingById(int ıd);
        void DeleteShoppingById(int ıd);


        List<CompanyDto> GetAllCompanies();
        CompanyDto GetCompanyById(int ıd);
        CompanyDto CreateCompany(CompanyDto company);
        CompanyDto UpdateCompany(CompanyDto company);
        void DeleteCompanyById(int ıd);

        List<AdminDto> GetAdmins();
        List<ChangeLogDto> GetAllChangeLog();      
    }
}
