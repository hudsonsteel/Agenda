using Agenda.Infra.Interfaces.Servico;
using System;
using System.Data.SqlClient;
using System.Text;

namespace Agenda.Infra.Servico
{
    public class SqlServerVerifyServico : ISqlServerVerifyServico
    {
        private readonly string connectionString;
        public SqlServerVerifyServico()
        {
            //(localdb)\MSSQLLocalDB
            //DESKTOP-MVG3E2S\SQLEXPRESS
            connectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=True;" + "Database=master";
        }
        public void CriarBancoDeDados(string nomeBanco)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sb = new System.Text.StringBuilder(30);
                sb.AppendLine($@"CREATE DATABASE {nomeBanco}");
                ExecutarComando(sb);
            }

            CriarContato();
            CriarContatoEmail();
            CriarContatoTelefone();
            CriarStoredEvent();
        }

        private void ExecutarComando(StringBuilder sb)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sb.ToString();
                command.ExecuteNonQuery();
            }
        }
        public bool CheckExistBancoDeDados(string nomeBanco)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand($"SELECT db_id('{nomeBanco}')", connection))
                {
                    try
                    {
                        connection.Open();
                        return (command.ExecuteScalar() != DBNull.Value);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }
        public void CriarContato()
        {
            var sb = new System.Text.StringBuilder(574);
            sb.AppendLine(@"USE [AgendaTelefonica]");
            sb.AppendLine(@"");
            sb.AppendLine(@"SET ANSI_NULLS ON");
            sb.AppendLine(@"");
            sb.AppendLine(@"SET QUOTED_IDENTIFIER ON");
            sb.AppendLine(@"");
            sb.AppendLine(@"CREATE TABLE [dbo].[Contato](");
            sb.AppendLine(@"	[IdContato] [int] IDENTITY(1,1) NOT NULL,");
            sb.AppendLine(@"	[Nome] [nvarchar](150) NOT NULL,");
            sb.AppendLine(@"	[DtCadastro] [datetime] NOT NULL,");
            sb.AppendLine(@"	[DtExcluido] [datetime] NULL,");
            sb.AppendLine(@" CONSTRAINT [PK_Contato] PRIMARY KEY CLUSTERED ");
            sb.AppendLine(@"(");
            sb.AppendLine(@"	[IdContato] ASC");
            sb.AppendLine(@")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");
            sb.AppendLine(@") ON [PRIMARY]");
            sb.AppendLine(@"");

            ExecutarComando(sb);
        }
        public void CriarContatoEmail()
        {
            var sb = new System.Text.StringBuilder(874);
            sb.AppendLine(@"USE [AgendaTelefonica]");
            sb.AppendLine(@"");
            sb.AppendLine(@"SET ANSI_NULLS ON");
            sb.AppendLine(@"");
            sb.AppendLine(@"SET QUOTED_IDENTIFIER ON");
            sb.AppendLine(@"");
            sb.AppendLine(@"CREATE TABLE [dbo].[ContatoEmail](");
            sb.AppendLine(@"	[IdContatoEmail] [int] IDENTITY(1,1) NOT NULL,");
            sb.AppendLine(@"	[IdContato] [int] NOT NULL,");
            sb.AppendLine(@"	[Email] [nvarchar](100) NOT NULL,");
            sb.AppendLine(@"	[DtCadastro] [datetime] NOT NULL,");
            sb.AppendLine(@"	[DtExcluido] [datetime] NULL,");
            sb.AppendLine(@" CONSTRAINT [PK_ContatoEmail] PRIMARY KEY CLUSTERED ");
            sb.AppendLine(@"(");
            sb.AppendLine(@"	[IdContatoEmail] ASC");
            sb.AppendLine(@")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");
            sb.AppendLine(@") ON [PRIMARY]");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"ALTER TABLE [dbo].[ContatoEmail]  WITH CHECK ADD  CONSTRAINT [FK_ContatoEmail_Contato] FOREIGN KEY([IdContato])");
            sb.AppendLine(@"REFERENCES [dbo].[Contato] ([IdContato])");
            sb.AppendLine(@"");
            sb.AppendLine(@"ALTER TABLE [dbo].[ContatoEmail] CHECK CONSTRAINT [FK_ContatoEmail_Contato]");

            ExecutarComando(sb);
        }
        public void CriarContatoTelefone()
        {
            var sb = new System.Text.StringBuilder(927);
            sb.AppendLine(@"USE [AgendaTelefonica]");
            sb.AppendLine(@"");
            sb.AppendLine(@"/****** Object:  Table [dbo].[ContatoTelefone]    Script Date: 22/10/2018 15:04:15 ******/");
            sb.AppendLine(@"SET ANSI_NULLS ON");
            sb.AppendLine(@"");
            sb.AppendLine(@"SET QUOTED_IDENTIFIER ON");
            sb.AppendLine(@"");
            sb.AppendLine(@"CREATE TABLE [dbo].[ContatoTelefone](");
            sb.AppendLine(@"	[IdContatoTelefone] [int] IDENTITY(1,1) NOT NULL,");
            sb.AppendLine(@"	[IdContato] [int] NOT NULL,");
            sb.AppendLine(@"	[Telefone] [nvarchar](50) NOT NULL,");
            sb.AppendLine(@"	[DtCadastro] [datetime] NOT NULL,");
            sb.AppendLine(@"	[DtExcluido] [datetime] NULL,");
            sb.AppendLine(@" CONSTRAINT [PK_ContatoTelefone] PRIMARY KEY CLUSTERED ");
            sb.AppendLine(@"(");
            sb.AppendLine(@"	[IdContatoTelefone] ASC");
            sb.AppendLine(@")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");
            sb.AppendLine(@") ON [PRIMARY]");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"ALTER TABLE [dbo].[ContatoTelefone]  WITH CHECK ADD  CONSTRAINT [FK_ContatoTelefone_Contato] FOREIGN KEY([IdContato])");
            sb.AppendLine(@"REFERENCES [dbo].[Contato] ([IdContato])");
            sb.AppendLine(@"");
            sb.AppendLine(@"ALTER TABLE [dbo].[ContatoTelefone] CHECK CONSTRAINT [FK_ContatoTelefone_Contato]");

            ExecutarComando(sb);
        }

        public void CriarStoredEvent()
        {
            var sb = new System.Text.StringBuilder(411);
            sb.AppendLine(@"USE [AgendaTelefonica]");
            sb.AppendLine(@"");
            sb.AppendLine(@"SET ANSI_NULLS ON");
            sb.AppendLine(@"");
            sb.AppendLine(@"SET QUOTED_IDENTIFIER ON");
            sb.AppendLine(@"");
            sb.AppendLine(@"SET ANSI_PADDING ON");
            sb.AppendLine(@"");
            sb.AppendLine(@"CREATE TABLE [dbo].[StoredEvent](");
            sb.AppendLine(@"	[Id] [varchar](max) NOT NULL,");
            sb.AppendLine(@"	[Dados] [varchar](max) NOT NULL,");
            sb.AppendLine(@"	[Usuario] [varchar](max) NOT NULL,");
            sb.AppendLine(@"	[MensagemTipo] [varchar](100) NOT NULL,");
            sb.AppendLine(@"	[AggregateId] [bigint] NOT NULL,");
            sb.AppendLine(@"	[DataCadastro] [datetime] NOT NULL");
            sb.AppendLine(@") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]");
            sb.AppendLine(@"");
            sb.AppendLine(@"SET ANSI_PADDING OFF");

            ExecutarComando(sb);
        }
    }
}
