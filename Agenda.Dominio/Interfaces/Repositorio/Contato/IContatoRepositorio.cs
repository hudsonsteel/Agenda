using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces.ICrud;
using System.Collections;
using System.Collections.Generic;

namespace Agenda.Dominio.Interfaces.Repositorio
{
    public interface IContatoRepositorio : ICrud<Contato>
    {
        ICollection<Contato> GetAllAtivos();
    }
}
