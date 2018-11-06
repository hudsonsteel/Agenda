using Agenda.Dominio.Core.Interface.Entidades;
using System;

namespace Agenda.Dominio.Interfaces.ICrud
{
    public interface IAdd<T> : IDisposable where T : IEntidade
    {
        void Add(T entidade);
    }
}
