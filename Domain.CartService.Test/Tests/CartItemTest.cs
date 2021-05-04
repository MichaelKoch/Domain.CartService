using Domain.CartService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CartService.Test.Tests
{
    [TestClass]
    public class CartItemTest
    {
        [TestMethod]
        public void Create()
        {
            var context = Guid.NewGuid().ToString();
            var cart = new CartCreateModel();
            throw new NotImplementedException();
        }
        
        [TestMethod]
        public void Read()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ReadNotFound()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Update()
        {
            throw new NotImplementedException();
        }
        
        [TestMethod]
        public void UpdateNotFound()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Delete()
        {
            throw new NotImplementedException();
        }
        
        [TestMethod]
        public void DeleteNotFound()
        {

            throw new NotImplementedException();
        }
    }
}
