﻿using FluentValidation.Results;
using GestaoDePessoas.Dominio.Core.Messages;

namespace GestaoDePessoas.Dominio.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
