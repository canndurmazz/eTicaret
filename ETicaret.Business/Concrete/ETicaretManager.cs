using AutoMapper;
using eTicaret.DataAccsess.Abstract;
using eTicaret.Entities;
using ETicaret.Business.Abstract;
using ETicaret.Conctrats;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.Concrete

{
    public class ETicaretManager : IETicaretService

    {
        private IETicaretRepository _eticaretRepository;
        private readonly IMapper mapper;

        public ETicaretManager(IETicaretRepository eticaretRepository, IMapper mapper)
        {
            _eticaretRepository = eticaretRepository;
            this.mapper = mapper;
        }
        #region C A T E G O R Y
        public CategoryDto CreateCategory(CategoryDto category)
        {
            var request = mapper.Map<Category>(category);
            return mapper.Map<CategoryDto>(_eticaretRepository.CreateCategory(request));
        }
        public void DeleteCategoryById(int ıd)
        {
            _eticaretRepository.DeleteCategoryById(ıd);
        }
        public CategoryDto GetCategoryById(int ıd)
        {
            var request = _eticaretRepository.GetCategoryById(ıd);
            return mapper.Map<CategoryDto>(request);
        }
        public CategoryDto UpdateCategory(CategoryDto category)
        {
            var ctg = _eticaretRepository.GetCategoryById(category.CategoryId);
            mapper.Map(category, ctg);
            var updatedCategory = _eticaretRepository.UpdateCategory(ctg);
            return mapper.Map<CategoryDto>(updatedCategory);
        }
        public List<CategoryDto> GetAllCategories()
        {
            var categories = _eticaretRepository.GetAllCategories();
            return mapper.Map<List<CategoryDto>>(categories);
        }
        public CategoryDto GetProductByCategoryId(int ıd)
        {
            var request = _eticaretRepository.GetProductByCategoryId(ıd);
            return mapper.Map<CategoryDto>(request);
        }
        #endregion

        #region P R O D U C T
        public ProductDto CreateProduct(int ıd)
        {
            var request = _eticaretRepository.CreateProduct(ıd);
            return mapper.Map<ProductDto>(request);
        }
        //public ProductDto CreateProduct(ProductDto product)
        //{
        //    var request = mapper.Map<Product>(product);
        //    return mapper.Map<ProductDto>(_eticaretRepository.CreateProduct(request));
        //}
        public void DeleteProductById(int ıd)
        {
            _eticaretRepository.DeleteProductById(ıd);
        }
        public List<ProductDto> GetAllProduct()
        {
            var products = _eticaretRepository.GetAllProduct();
            return mapper.Map<List<ProductDto>>(products);
        }
        public ProductDto GetProductById(int ıd)
        {
            var request = _eticaretRepository.GetProductById(ıd);
            return mapper.Map<ProductDto>(request);
        }

        public ProductDto UpdateProduct(ProductDto product)
        {
            var prd = _eticaretRepository.GetProductById(product.ProductId);
            //prd.Price = product.Price;
            mapper.Map(product, prd);
            var updatedProduct = _eticaretRepository.UpdateProduct(prd);
            return mapper.Map<ProductDto>(updatedProduct);
        }

        public ProductDto UpdateProductStock(int ıd, int newstock)
        {
            var request = _eticaretRepository.UpdateProductStock(ıd, newstock);
            return mapper.Map<ProductDto>(request);

        }

        #endregion

        #region W A T İ N G   P R O D U C T 
        public List<WaitingProductDto> GetAllWaitingProduct()
        {
            var products = _eticaretRepository.GetAllWaitingProduct();
            return mapper.Map<List<WaitingProductDto>>(products);
        }

        public WaitingProductDto GetWaitingProductById(int ıd)
        {
            var request = _eticaretRepository.GetWaitingProductById(ıd);
            return mapper.Map<WaitingProductDto>(request);
        }

        public WaitingProductDto UpdateWaitingProduct(WaitingProductDto product)
        {
            var prd = _eticaretRepository.GetWaitingProductById(product.WaitingProductId);
            mapper.Map(product, prd);
            var updatedProduct = _eticaretRepository.UpdateWaitingProduct(prd);
            return mapper.Map<WaitingProductDto>(updatedProduct);
        }

        public WaitingProductDto CreateWaitingProduct(WaitingProductDto product)
        {

            var request = mapper.Map<WaitingProduct>(product);
            return mapper.Map<WaitingProductDto>(_eticaretRepository.CreateWaitingProduct(request));
        }

        public void DeleteWaitingProductById(int ıd)
        {
            _eticaretRepository.DeleteWaitingProductById(ıd);
        }





        #endregion

        #region C U S T O M E R
        public List<CustomerDto> GetAllCustomer()
        {
            var customers = _eticaretRepository.GetAllCustomer();
            return mapper.Map<List<CustomerDto>>(customers);
        }

        public CustomerDto GetCustomertById(int ıd)
        {
            var request = _eticaretRepository.GetCustomertById(ıd);
            return mapper.Map<CustomerDto>(request);
        }
        public CustomerDto CreateCustomer(CustomerDto customer)
        {
            var request = mapper.Map<Customer>(customer);
            return mapper.Map<CustomerDto>(_eticaretRepository.CreateCustomer(request));
        }

        public CustomerDto UpdateCustomer(CustomerDto customer)
        {
            var cst = _eticaretRepository.GetCustomertById(customer.CustomerId);
            mapper.Map(customer, cst);
            var updatedCustomer = _eticaretRepository.UpdateCustomer(cst);
            return mapper.Map<CustomerDto>(updatedCustomer);
        }

        public void DeleteCustomerById(int ıd)
        {
            _eticaretRepository.DeleteCustomerById(ıd);
        }

        #endregion

        #region S H O P P İ N G     
        public ShoppingDto CreateShopping(ShoppingDto shopping)
        {
            var request = mapper.Map<Shopping>(shopping);
            return mapper.Map<ShoppingDto>(_eticaretRepository.CreateShopping(request));
        }
        public List<ShoppingDto> GetAllShopping()
        {
            var shoppings = _eticaretRepository.GetAllShopping();
            return mapper.Map<List<ShoppingDto>>(shoppings);
        }
        public ShoppingDto GetShoppingById(int ıd)
        {
            var request = _eticaretRepository.GetShoppingById(ıd);
            return mapper.Map<ShoppingDto>(request);
        }
        public void ReturnShoppingById(int ıd)
        {
            _eticaretRepository.ReturnShoppingById(ıd);
        }

        public void DeleteShoppingById(int ıd)
        {
            _eticaretRepository.DeleteShoppingById(ıd);
        }

        #endregion

        #region C O M P A N Y

        public List<CompanyDto> GetAllCompanies()
        {        
            var companies = _eticaretRepository.GetAllCompanies();
            return mapper.Map<List<CompanyDto>>(companies);
        }

        public CompanyDto GetCompanyById(int ıd)
        {
            var request = _eticaretRepository.GetCompanyById(ıd);
            return mapper.Map<CompanyDto>(request);
        }

        public CompanyDto CreateCompany(CompanyDto company)
        {
            var request = mapper.Map<Company>(company);
            return mapper.Map<CompanyDto>(_eticaretRepository.CreateCompany(request));
        }

        public CompanyDto UpdateCompany(CompanyDto company)
        {
            var ctg = _eticaretRepository.GetCompanyById(company.CompanyId);
            mapper.Map(company, ctg);
            var updatedCompany = _eticaretRepository.UpdateCompany(ctg);
            return mapper.Map<CompanyDto>(updatedCompany);
        }
       

        public void DeleteCompanyById(int ıd)
        {
            _eticaretRepository.GetCompanyById(ıd);
        }

        #endregion

        #region C H A N G E   L O G

        public List<ChangeLogDto> GetAllChangeLog()
        {
            var changelogs = _eticaretRepository.GetAllChangeLogs();
            return mapper.Map<List<ChangeLogDto>>(changelogs);
        }


        #endregion

        #region A D M İ N
         
        public List<AdminDto> GetAdmins()
        {
            var admins = _eticaretRepository.GetAdmins();
            return mapper.Map<List<AdminDto>>(admins);
        }
        #endregion
    }
}
