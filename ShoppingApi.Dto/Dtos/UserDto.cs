﻿using ShoppingApi.Base.Dto;

namespace ShoppingApi.Dto.Dtos
{
    public class UserDto : BaseDto
    {
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime LastActivity { get; set; }

        public string FullName
        {
            get { return Name + " " + Surname; }
        }
    }
}
