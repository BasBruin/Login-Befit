﻿using BusnLogic;
using DalMSSQL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Login.Controllers
{
    [ApiController]
    [EnableCors]
    public class LoginController : Controller
    {
        private UserContainer uc;

        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration ic)
        {
            _configuration = ic;
            uc = new UserContainer(new UserMSSQLDAL(_configuration["db:ConnectionString"]));
        }


        [HttpGet]
        [Route("api/[controller]CheckPassword")]
        public int? CheckPassword(string Username, string Password)
        {
            int? id = uc.FindByUsernameAndPassword(Username, Password);
            if (id == null)
            {
                return 0;
            }
            else
            {
                return id;
            }
            
        }
    }
}
