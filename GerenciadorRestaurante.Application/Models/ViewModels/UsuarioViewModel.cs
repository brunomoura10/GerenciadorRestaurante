﻿using GerenciadorRestaurante.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NomeUsuario { get; set; }
        public Permissao Permissao { get; set; }
    }
}
