using DevFramework.Core.Entities;
using System.Collections.Generic;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class UserRole : IEntity
    {
        public int Id { get; set; } 
        public int RoleId { get; set; }
        public int UserId { get; set; }

    }
}