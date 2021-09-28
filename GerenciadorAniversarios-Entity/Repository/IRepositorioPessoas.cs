using System;
using System.Collections.Generic;
using System.Text;
using GerenciadorAniversariosConsole.Entity;

namespace GerenciadorAniversariosConsole.Repository
{
    public interface IRepositorioPessoas
    {
        void Create(Pessoa pessoa);
        void Update(Pessoa pessoa, int id);
        void Delete(Pessoa pessoa);
        Pessoa getPessoa(int id);
        List<Pessoa> GetAll();
    }
}
