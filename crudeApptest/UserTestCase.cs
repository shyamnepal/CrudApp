using CrudeApp.Controllers;
using CrudeApp.Data;
using CrudeApp.Data.Services;
using CrudeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using Moq;

namespace crudeApptest
{
    public class UserTestCase
    {
        private readonly Mock<IUserServices> _mockServices;
        private readonly UsersController _controller;
       
        public UserTestCase()
        {
           
            _mockServices = new Mock<IUserServices>();
            _controller = new UsersController(_mockServices.Object);
        }
        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {

         

            var result = _controller.Index().Result;
            var viewResult = Assert.IsType<ViewResult>(result);
           

            


        }
    }
}