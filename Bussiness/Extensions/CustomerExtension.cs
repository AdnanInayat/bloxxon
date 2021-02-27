using Bussiness.ViewModels;
using Data.Models;

namespace Bussiness.Extensions
{
    public static class CustomerExtension
    {
        public static CustomerComboModel ToComboModel(this tCustomer entity)
        {
            if (entity == null) return null;
            return new CustomerComboModel
            {
                Id = entity.Id,
                Name = $"{entity.Firstname} {entity.Lastname}"
            };
        }
    }
}
