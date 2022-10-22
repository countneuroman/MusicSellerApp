﻿using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}