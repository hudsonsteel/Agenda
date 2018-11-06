using Agenda.Dominio.Core.Interface.Entidades;
using System;

namespace Agenda.Dominio.Interfaces.ICrud
{
    public interface IUpdate<T> : IDisposable where T : IEntidade
    {
        void Update(T entidade);
    }
}
