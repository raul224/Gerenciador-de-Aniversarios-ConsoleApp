using GerenciadorAniversarios_Repositorio.BancoDeDados;
using GerenciadorAniversariosConsole.Entity;
using GerenciadorAniversariosConsole.Repository;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GerenciadorAniversariosConsole
{
    class Program
    {
        private static GerenciadorAniversarios_Repositorio.BancoDeDados.RepositorioPessoas repositorioPessoas = new GerenciadorAniversarios_Repositorio.BancoDeDados.RepositorioPessoas();
        static void Main(string[] args)
        {
            var sair = false;
            while(!sair)
            {
                ExibeOpcoes();
                var entrada = Convert.ToInt16(Console.ReadLine());
                switch (entrada)
                {
                    case 1: //Cadastrar
                        cadastrarPessoa();
                        break;
                    case 2: //Atualizar
                        atualizarPessoa();
                        break;
                    case 3: //Excluir
                        deletarPessoa();
                        break;
                    case 4: //Pesquisar
                        pesquisarPessoa();
                        break;
                    case 5: //Listar
                        listarPessoas();
                        break;
                    case 6: //Sair
                        Console.WriteLine("Saindo...");
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção invalida, tente uma das sugeridas");
                        break;
                }
            }
        }
        private static void cadastrarPessoa()
        {
            Console.WriteLine("Digite o nome da pessoa que deseja adicionar:");
            String nomePessoa = Console.ReadLine();
            Console.WriteLine("Digite o sobre nome da pessoa que deseja  adicionar:");
            String sobreNomePessoa = Console.ReadLine();
            Console.WriteLine("Digite a data de aniversario da pessoa no formato dd/MM/YYYY:");
            var aniversarioPessoa = Convert.ToDateTime(Console.ReadLine());
            Pessoa pessoa = new Pessoa(nomePessoa, sobreNomePessoa, aniversarioPessoa);
            repositorioPessoas.Create(pessoa);
            Console.WriteLine();
        }
        private static void atualizarPessoa()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificado do cliente");

            var id = Convert.ToInt32(Console.ReadLine());
            var pessoa = repositorioPessoas.getPessoa(id);

            if (pessoa == null)
            {
                Console.WriteLine("Pessoa não encontrado");
            }
            else
            {
                Console.WriteLine("Informe o nome da pessoa");
                pessoa.nome = Console.ReadLine();

                Console.WriteLine("Informe o sobre nome da pessoa");
                pessoa.sobreNome = Console.ReadLine();

                Console.WriteLine("Informe o aniversario da pessoa");
                pessoa.aniversario = Convert.ToDateTime(Console.ReadLine());

                repositorioPessoas.Update(pessoa, id);

                Console.WriteLine("Cliente atualizado com sucesso!");
            }
        }
        private static void deletarPessoa()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificador do cliente para realizar a exclusão");

            var id = Convert.ToInt32(Console.ReadLine());

            var pessoa = repositorioPessoas.getPessoa(id);

            if (pessoa == null)
                Console.WriteLine("Cliente não encontrado");
            else
            {
                repositorioPessoas.Delete(pessoa);
                Console.WriteLine("Cliente excluido com sucesso");
            }
        }
        private static void pesquisarPessoa()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificado do cliente");

            var id = Convert.ToInt32(Console.ReadLine());
            Pessoa pessoa = repositorioPessoas.getPessoa(id);

            Console.WriteLine("");
            Console.WriteLine($"Exibindo Cliente com o identificador {id}");

            Console.WriteLine($"Nome completo: {pessoa.nome} {pessoa.sobreNome}.");
            Console.WriteLine($"Data de aniversario: {pessoa.aniversario}.");

            int diasParaAniversario = calculaDiasAteAniversario(pessoa.aniversario);
            if (diasParaAniversario != 0)
            {
                Console.WriteLine($"Faltam {diasParaAniversario} dias para esse aniversário.");
            }
            else
            {
                Console.WriteLine("O aniversário é hoje!");
            }

            Console.WriteLine();
        }
        private static void listarPessoas()
        {
            Console.WriteLine("Exibindo pessoas");
            Console.WriteLine();
            var listaPessoas = repositorioPessoas.GetAll();
            Console.WriteLine(JsonConvert.SerializeObject(listaPessoas, Formatting.Indented));
        }
        private static int calculaDiasAteAniversario(DateTime dataAniversario)
        {
            DateTime dataHoje = DateTime.Now;
            int anoAtual = DateTime.Now.Year;
            int AnoNascimento = dataAniversario.Year;
            DateTime novaDataAniversairio = dataAniversario.AddYears(anoAtual - AnoNascimento);

            int comparacao = DateTime.Compare(novaDataAniversairio, dataHoje);

            if(comparacao < 0) //menor que zero t1 anterior a t2.
            {
                DateTime novaDataAniversarioAumenta = novaDataAniversairio.AddYears(1);
                return novaDataAniversarioAumenta.Subtract(dataHoje).Days;
            } else if(comparacao > 0)
            {
                return novaDataAniversairio.Subtract(dataHoje).Days;
            } else
            {
                return 0;
            }
        }

        private static void ExibeOpcoes()
        {
            Console.WriteLine("Selecione uma das opções, entrado com o número");
            Console.WriteLine("1 - Cadastrar uma pessoa");
            Console.WriteLine("2 - Atualizar uma pessoa");
            Console.WriteLine("3 - Para excluir uma pessoa");
            Console.WriteLine("4 - Para Pesquisar uma pessoa");
            Console.WriteLine("5 - Para exibir todos as pessoas");
            Console.WriteLine("6 - Para sair");
        }
    }
}
