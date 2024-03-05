using LibraryManagement.Application.Abstractions;
using LibraryManagement.Application.Abstractions.IService;
using LibraryManagement.Domain.Entities.DTOs;
using LibraryManagement.Domain.Entities.Models;

namespace LibraryManagement.Application.Services.BookService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _bookRepository;

        public ProductService(IProductRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<string> Add(ProductDTO prodDTO)
        {
            var product = new Product()
            {
                ProductName = prodDTO.ProductName,
                CategoryName = prodDTO.CategoryName,
                ExpiryDate = DateTime.UtcNow,
                Price = prodDTO.Price
            };

            if(product != null)
            {
                await _bookRepository.Create(product);
                return "Added";
            }
            return "Failed";
        }

        public async Task<string> Delete(int id)
        {
            var result = await _bookRepository.Delete(x => x.ProductId == id);
            if (result)
            {
                return "Deleted";
            }
            else
            {
                return "Failed";
            }
           
        }



        public async Task<List<Product>> GetByName(string name)
        {
            var result = await _bookRepository.GetAll();
            return result.Where(x=> x.ProductName == name).ToList();
        }

        public async Task<List<Product>> GetByCategory(string Category)
        {
            var result = await _bookRepository.GetAll();
            return result.Where(x => x.CategoryName == Category).ToList();
        }




        public async Task<Product> GetById(int id)
        {
            var result = await _bookRepository.GetByAny(x=>x.ProductId == id);
            return result;
        }



        public async Task<string> Update(int id, ProductDTO prodDTO)
        {
            var res = await _bookRepository.GetByAny(x=> x.ProductId == id);
            
            if(res != null)
            {


                res.ProductName = prodDTO.ProductName;
                res.CategoryName = prodDTO.CategoryName;
                res.ExpiryDate = prodDTO.ExpiryDate;
                res.Price = prodDTO.Price;
                res.ProductId = id;
               

                var result = await _bookRepository.Update(res);
                if(result != null)
                {
                    return "Updated";
                }
                return "Failed";
            }
            return "Failed";
        }

        public async Task<List<Product>> GetAll()
        {
            var result = await _bookRepository.GetAll();
            return result.ToList();
        }

        public async Task<List<Product>> GetByPrice(double price)
        {
            var result = await _bookRepository.GetAll();
            return result.Where(x => x.Price == price).ToList();
        }
    }
}
