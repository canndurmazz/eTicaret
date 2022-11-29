using AutoMapper;
using eTicaret.Entities;
using ETicaret.Conctrats;

namespace ETicaret.Business.AutoMapperProfile
{
    public class ETicaretMapProfile : Profile
    {
        public ETicaretMapProfile()
        {           
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductInformation,ProductInformationDto>().ReverseMap();
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();         
            CreateMap<AddressType, AddressTypeDto>().ReverseMap();
            CreateMap<PaymentType, PaymentTypeDto>().ReverseMap();
            CreateMap<ChangeLog, ChangeLogDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyProduct, CompanyProductDto>().ReverseMap();
            CreateMap<CompanyEarning, CompanyEarningDto>().ReverseMap();
            CreateMap<Admin, AdminDto>().ReverseMap();
            CreateMap<Shopping,ShoppingDto>().ReverseMap();
            CreateMap<WaitingProduct, WaitingProductDto>().ReverseMap();
            CreateMap<WaitingStock, WaitingStockDto>().ReverseMap();
            CreateMap<WaitingProductInformation, WaitingProductInformationDto>().ReverseMap();
        }
    }
}
