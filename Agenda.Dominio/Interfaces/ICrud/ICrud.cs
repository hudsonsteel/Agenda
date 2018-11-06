using Agenda.Dominio.Core.Interface.Entidades;
using System;

namespace Agenda.Dominio.Interfaces.ICrud
{
    public interface ICrud<T> : IAdd<T>, IAll<T>, IRemove<T>, IFind<T>, IUpdate<T>, IDisposable where T : IEntidade
    {
    }
}
