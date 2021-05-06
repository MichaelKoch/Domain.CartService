using Domain.CartService.Controllers;
using Domain.CartService.Entities;
using Domain.CartService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestMongo;
using System;

namespace Domain.CartService.Test.Tests
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Create()
        {
            var context = Guid.NewGuid().ToString();
            var cart = new CartCreateModel() { ExternalId = context, CustomerId = "CUSOMTERID" };
            var repo = DataHelper.GetRepository<CartEntity>();
            var ctrl = new CartsController(repo, null);
            var result = ctrl.Create(cart).Result;
            var created = (ctrl.Get(result.Value.Id).Result).Value;
            Assert.IsNotNull(created);
            Assert.IsTrue(created.ExternalId == context);
            Assert.IsTrue(created.CustomerId == "CUSOMTERID");
            DataHelper.Cleanup(repo, created.Id);
        }
        [TestMethod]
        public void Read()
        {
            var context = Guid.NewGuid().ToString();
            var cart = new CartCreateModel() { ExternalId = context };
            var repo = DataHelper.GetRepository<CartEntity>();
            var ctrl = new CartsController(repo, null);
            var result = ctrl.Create(cart).Result;
            var created = (ctrl.Get(result.Value.Id).Result).Value;
            Assert.IsNotNull(created);
            Assert.IsTrue(created.ExternalId == context);
            DataHelper.Cleanup(repo, created.Id);
        }

        [TestMethod]
        public void ReadNotFound()
        {
            var repo = DataHelper.GetRepository<CartEntity>();
            var ctrl = new CartsController(repo, null);
            var result = (ctrl.Get(Guid.NewGuid().ToString()).Result).Result;
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Update()
        {
            var context = Guid.NewGuid().ToString();
            var cart = new CartCreateModel() { ExternalId = context };
            var repo = DataHelper.GetRepository<CartEntity>();
            var ctrl = new CartsController(repo, null);
            var result = ctrl.Create(cart).Result;
            var created = (ctrl.Get(result.Value.Id).Result).Value;
            Assert.IsNotNull(created);
            Assert.IsTrue(created.ExternalId == context);
            created.CustomerId = "TESTCUSTOMER";
            var updateResult = ctrl.Update(created.Id, created.Transform<CartUpdateModel>()).Result;
            var updated = (ctrl.Get(result.Value.Id).Result).Value;
            Assert.IsTrue(updated.CustomerId == "TESTCUSTOMER");
            DataHelper.Cleanup(repo, created.Id);

        }
        [TestMethod]
        public void UpdateNotFound()
        {
            var repo = DataHelper.GetRepository<CartEntity>();
            var ctrl = new CartsController(repo, null);
            var result = ctrl.Update(Guid.NewGuid().ToString(), new CartUpdateModel()).Result;
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


        [TestMethod]
        public void Delete()
        {
            var context = Guid.NewGuid().ToString();
            var cart = new CartCreateModel() { ExternalId = context };
            var repo = DataHelper.GetRepository<CartEntity>();
            var ctrl = new CartsController(repo, null);
            var result = ctrl.Create(cart).Result;
            var created = (ctrl.Get(result.Value.Id).Result).Value;
            Assert.IsNotNull(created);
            ctrl.Delete(created.Id).Wait();
            var notThere = (ctrl.Get(result.Value.Id).Result).Result;
            Assert.IsInstanceOfType(notThere, typeof(NotFoundResult));
            DataHelper.Cleanup(repo, created.Id);
        }
        [TestMethod]
        public void DeleteNotFound()
        {
            var repo = DataHelper.GetRepository<CartEntity>();
            var ctrl = new CartsController(repo, null);
            var result = (ctrl.Get(Guid.NewGuid().ToString()).Result).Result;
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }
    }
}
