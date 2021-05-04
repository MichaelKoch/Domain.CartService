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
            
        }
        [TestMethod]
        public void Read()
        {

        }

        [TestMethod]
        public void ReadNotFound()
        {

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
