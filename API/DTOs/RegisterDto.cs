﻿using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    [MaxLength(100)]
    public required string Username {get; set;}

    [Required]
    [MinLength(8)]
    public required string Password {get; set;}
}
