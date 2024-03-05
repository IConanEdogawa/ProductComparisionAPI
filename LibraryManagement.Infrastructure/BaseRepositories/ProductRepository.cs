using LibraryManagement.Application.Abstractions;
using LibraryManagement.Domain.Entities.Models;
using LibraryManagement.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.BaseRepositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductComparisionDbContext context) : base(context) 
        { 
        
        }
    }
}
