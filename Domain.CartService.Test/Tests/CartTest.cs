using Domain.CartService.Controllers;
using Domain.CartService.Entities;
using Domain.CartService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CartService.Test.Tests
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public async void Create()
        {
            var context = Guid.NewGuid().ToString();
            var cart = new CartCreateModel() { ExternalId = context };
            var repo = DataHelper.GetRepository<CartEntity>();
            var ctrl = new CartsController(repo, null);
            var result = await ctrl.Create(cart);
            var created = (await ctrl.Get(result.Value.Id)).Value;
            Assert.IsNotNull(created);
            Assert.IsTrue(created.ExternalId == context);
            DataHelper.Cleanup(repo, created.Id);

        }
        [TestMethod]
        public async void Read()
        {
            var context = Guid.NewGuid().ToString();
            var cart = new CartCreateModel() { ExternalId = context };
            var repo = DataHelper.GetRepository<CartEntity>();
            var ctrl = new CartsController(repo, null);
            var result = await ctrl.Create(cart);
            var created = (await ctrl.Get(result.Value.Id)).Value;
            Assert.IsNotNull(created);
            Assert.IsTrue(created.ExternalId == context);
            DataHelper.Cleanup(repo, created.Id);
        }

        [TestMethod]
        public async void ReadNotFound()
        {
            var repo = DataHelper.GetRepository<CartEntity>();
            var ctrl = new CartsController(repo, null);
            var result = await ctrl.Get(Guid.NewGuid().ToString());
          
        }

        [TestMethod]
        public void Update()
        {

        }
        [TestMethod]
        public void UpdateNotFound()
        {

        }


        [TestMethod]
        public void Delete()
        {

        }
        [TestMethod]
        public void DeleteNotFound()
        {

        }
    }
}
