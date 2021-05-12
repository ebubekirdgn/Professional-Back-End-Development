using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.PostSharp;
using DevFramework.Core.Aspects.PostSharp.AuthorizationAspects;
using DevFramework.Core.Aspects.PostSharp.CacheAspects;
using DevFramework.Core.Aspects.PostSharp.PerformanceAspects;
using DevFramework.Core.Aspects.PostSharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace DevFramework.Northwind.Business.Concrate.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        /// <summary>
        /// Perfornance Süresini 2 saniyeyi geçmemesi için yazılır.
        /// </summary>
        /// <returns></returns>
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        [SecuredOperation(Roles ="Admin")]
        public List<Product> GetAll()
        {
            //3 sn. uyutuyoruz öyle devam et dedik.Çunku methodlarımız hızlı calısıyor.5 sn.Default
            //deger verdiğimiz için uyutmak zaman harcatmak zorunda kaldık.
            // Thread.Sleep(3000);

            return _productDal.GetList();
        }
        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            //  Business Codes
            _productDal.Update(product2);
        }
    }
}