using Agenda.Dominio.Core.Interface.Entidades;
using System;

namespace Agenda.Dominio.Interfaces.ICrud
{
    public interface IFind<T> : IDisposable where T : IEntidade
    {
        T Find(long id);
    }
}
