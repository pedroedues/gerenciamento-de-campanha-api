﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.CriarCampanha
{
    public class CriarCampanhaCommandValidator : AbstractValidator<CriarCampanhaCommand>
    {
        public CriarCampanhaCommandValidator()
        {
        }
    }
}
