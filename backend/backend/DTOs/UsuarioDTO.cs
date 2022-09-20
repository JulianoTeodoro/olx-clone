﻿using backend.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UsuarioDTO
    {
        public string? UserName { get; set; }
        public string? Sobrenome { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }

        public ICollection<Ads>? Ads { get; set; }
    }
}