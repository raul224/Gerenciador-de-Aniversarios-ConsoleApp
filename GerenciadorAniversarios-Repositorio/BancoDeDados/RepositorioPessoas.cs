using Dapper;
using GerenciadorAniversariosConsole.Entity;
using GerenciadorAniversariosConsole.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GerenciadorAniversarios_Repositorio.BancoDeDados
{
    public class RepositorioPessoas : IRepositorioPessoas
    {
        private string Connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=gerenciadorAniversariosConsole;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Create(Pessoa pessoa)
        {
            using (SqlConnection conecta = new SqlConnection(Connection))
            {
                var sql = @"dbo.CriaPessoa";

                conecta.Execute(sql, new
                {
                    Nome = pessoa.nome,
                    SobreNome = pessoa.sobreNome,
                    Aniversario = pessoa.aniversario
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Delete(Pessoa pessoa)
        {
            using (SqlConnection conecta = new SqlConnection(Connection))
            {
                var sql = @"dbo.DeletaPessoa";
                conecta.Execute(sql, new
                {
                    IdPessoa = pessoa.id,
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Pessoa getPessoa(int id)
        {
            using (SqlConnection conecta = new SqlConnection(Connection))
            {
                var sql = @"dbo.SelectPessoaPeloId";
                conecta.Open();

                var command = conecta.CreateCommand();

                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@IdPessoa", id));

                var result = command.ExecuteReader();

                Pessoa pessoa = null;

                while (result.Read())
                {
                    pessoa = new Pessoa();
                    pessoa.id = Convert.ToInt32(result[0]);
                    pessoa.nome = result[1].ToString();
                    pessoa.sobreNome = result[2].ToString();
                    pessoa.aniversario = Convert.ToDateTime(result[3]);
                }

                conecta.Close();

                return pessoa;
            }
        }

        public void Update(Pessoa pessoa, int id)
        {
            using (SqlConnection conecta = new SqlConnection(Connection))
            {
                var sql = @"dbo.UpdatePessoa";

                conecta.Execute(sql, new
                {
                    Nome = pessoa.nome,
                    SobreNome = pessoa.sobreNome,
                    Aniversario = pessoa.aniversario,
                    Id = id
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<Pessoa> GetAll()
        {
            using (SqlConnection conecta = new SqlConnection(Connection))
            {
                var sql = @"[dbo].[SelectAllPessoas]";

                var resultado = conecta.Query<Pessoa>(sql, commandType: System.Data.CommandType.StoredProcedure);

                return resultado.AsList();
            }
        }
    }
}
