using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities.Enums
{
    public enum Permission
    {
        GetByUserEmail,
        GetByUserFullName,
        GetByPublishedYear,
        GetAllProduct,


        CreateUser,
        GetByRole,
        GetByUserId,
        UpdateUser,
        DeleteUser,
        DeletePproduct,
        UpdateProduct,
        AddProduct,


        GetAllUser,
        GetById,
        GetByName,
        GetByCategory,
        GetByPrice,

        GetUserPDF


    }
}
