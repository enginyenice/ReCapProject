﻿/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Entities;

namespace Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}