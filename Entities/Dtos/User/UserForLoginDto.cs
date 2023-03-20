﻿using Core.Entities;

namespace Entities.Dtos.User
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
