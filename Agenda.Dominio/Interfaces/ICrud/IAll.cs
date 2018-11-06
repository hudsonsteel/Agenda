using Agenda.Dominio.Core.Interface.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Dominio.Interfaces.ICrud
{
    public interface IAll<T> : IDisposable where T : IEntidade
    {
        ICollection<T> GetAll();
    }
}
