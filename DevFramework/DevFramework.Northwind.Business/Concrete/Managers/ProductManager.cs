using DevFramework.Core.Aspects.PostSharp;
using DevFramework.Core.Aspects.PostSharp.CacheAspects;
using DevFramework.Core.Aspects.PostSharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private readonly IQueryableRepository<Product> _queryable;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        // Sepetten ürün ekleme silme işlemleri gibi yerlerde gecerlidir.
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }
         
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            //Business code
            _productDal.Update(product1);
        }
    }
}