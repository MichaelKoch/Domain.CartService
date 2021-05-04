using Domain.CartService.Entities;
using RestMongo.Models;
using RestMongo.Repositories;
using System.Collections.Generic;
using System.Linq;


public static class DataHelper
    {
        internal static void Cleanup(MongoRepository<CartItemEntity> repo, string cartId)
        {
            var inserted = repo.AsQueryable().Where(c => c.CartId == cartId).ToList();
            repo.DeleteById(inserted.Select(i => i.Id).ToList());
        }
        internal static void Cleanup(MongoRepository<CartEntity> repo, string cartId)
        {
            var inserted = repo.AsQueryable().Where(c => c.Id == cartId).ToList();
            repo.DeleteById(inserted.Select(i => i.Id).ToList());
        }

        internal static MongoRepository<TType> GetRepository<TType>() where TType : BaseDocument
        {
            return new MongoRepository<TType>(ConfigHelper.GetMongoConfig());
        }

        
        internal static IList<CartItemEntity> CreateItemsTestData(string cardID, long count)
        {
            var retVal = new List<CartItemEntity>();
            for (int i = 0; i < count; i++)
            {
                retVal.Add(new CartItemEntity() { CartId = cardID, Quantity = 10 });
            }
            return retVal;
        }

        internal static IList<CartEntity> CreateCartTestData(string externalID, long count)
        {
            var retVal = new List<CartEntity>();
            for (int i = 0; i < count; i++)
            {
                retVal.Add(new CartEntity() { ExternalId = externalID });
            }
            return retVal;
        }
    }

