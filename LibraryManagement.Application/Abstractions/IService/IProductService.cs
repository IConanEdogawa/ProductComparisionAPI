using LibraryManagement.Domain.Entities.DTOs;
using LibraryManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Abstractions.IService
{
    public interface IProductService
    {
        public Task<string> Add(ProductDTO bookDTO);
        public Task<Product> GetById(int id);
        public Task<List<Product>> GetAll();
        public Task<List<Product>> GetByName(string name);
        public Task<List<Product>> GetByCategory(string category);
        public Task<List<Product>> GetByPrice(double price);
        public Task<string> Delete(int id);
        public Task<string> Update(int id, ProductDTO productDTO);
    }
}
