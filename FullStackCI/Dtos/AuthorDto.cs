// 1. Modificar tu AuthorDto para incluir HATEOAS
using FullStackCI.Dtos;
using FullStackCI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FullStackCI.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public int BirthYear { get; set; }

        // HATEOAS
        public List<LinkDto> Enlaces { get; set; } = new();
    }
}
