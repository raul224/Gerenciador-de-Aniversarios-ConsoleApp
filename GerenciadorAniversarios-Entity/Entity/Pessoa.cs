using GerenciadorAniversariosConsole.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorAniversariosConsole.Entity
{
    public class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobreNome { get; set; }
        public DateTime aniversario { get; set; }

        public Pessoa(string nome, string sobreNome, DateTime aniversario)
        {
            this.nome = nome;
            this.sobreNome = sobreNome;
            this.aniversario = aniversario;
        }

        public Pessoa()
        {
        }

        public void Save(IRepositorioPessoas repositorio)
        {
            repositorio.Create(this);
        }

    }
}
