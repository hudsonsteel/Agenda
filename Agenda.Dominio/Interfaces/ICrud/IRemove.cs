using Agenda.Dominio.Core.Interface.Entidades;
using System;

namespace Agenda.Dominio.Interfaces.ICrud
{
    public interface IRemove<T> : IDisposable where T : IEntidade
    {
        void Remove(T entidade);
    }
}
