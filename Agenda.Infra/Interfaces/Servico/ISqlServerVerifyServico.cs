namespace Agenda.Infra.Interfaces.Servico
{
    public interface ISqlServerVerifyServico
    {
        bool CheckExistBancoDeDados(string nomeBanco);
        void CriarBancoDeDados(string nomeBanco);

        void CriarContato();
        void CriarContatoEmail();
        void CriarContatoTelefone();
        void CriarStoredEvent();
    }
}
