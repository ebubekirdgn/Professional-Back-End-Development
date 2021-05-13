using DevFramework.Core.Entities;
using System.Collections.Generic;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}