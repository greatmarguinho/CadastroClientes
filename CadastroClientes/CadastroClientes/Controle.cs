using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes
{
    public class Controle
    {
        public int ID = 0;
        List<Cliente> listaClientes = new List<Cliente>();
        public void apresentaMenu()
        {
            int opcao = 0;

            Console.Clear();

            Console.WriteLine("[1] - Cadastrar");
            Console.WriteLine("[2] - Editar");
            Console.WriteLine("[3] - Excluir");
            Console.WriteLine("[4] - Listar todos");

            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                opcao = 0;
            }

            Console.Clear();
            switch(opcao)
            {
                default:
                    Console.WriteLine("Opcao invalida");
                    Console.WriteLine("Pressione Enter para continuar...");
                    Console.ReadLine();
                    apresentaMenu();
                    break;

                case 1:
                    cadastrar();
                    apresentaMenu();
                    break;

                case 2:
                    editar();
                    apresentaMenu();
                    break;

                case 3:
                    excluir();
                    apresentaMenu();
                    break;

                case 4:
                    listarTodos();
                    apresentaMenu();
                    break;
                    
            } 
            
        }

        public void cadastrar()
        {
            Console.WriteLine("Informe o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe o endereco: ");
            string endereco = Console.ReadLine();

            Console.WriteLine("Informe o telefone");
            string telefone = Console.ReadLine();

            Console.WriteLine("Informe o email:");
            string email = Console.ReadLine();

            Cliente cliente = new Cliente(ID++, nome, endereco, telefone, email);
            listaClientes.Add(cliente);
        }

        public void editar()
        {
            Console.WriteLine("Informe o ID: ");
            int id = int.Parse(Console.ReadLine());
            int index = listaClientes.FindIndex(p => p.id == id);


            Console.WriteLine("Informe o nome: ");
            Console.WriteLine("Nome antigo " + listaClientes[index].Nome);
            listaClientes[index].Nome = Console.ReadLine();

            Console.WriteLine("Informe o endereco: ");
            Console.WriteLine("Endereco antigo " + listaClientes[index].Endereco);
            listaClientes[index].Endereco = Console.ReadLine();

            Console.WriteLine("Informe o telefone: ");
            Console.WriteLine("Telefone antigo " + listaClientes[index].Telefone);
            listaClientes[index].Telefone = Console.ReadLine();

            Console.WriteLine("Informe o email: ");
            Console.WriteLine("Email antigo " + listaClientes[index].Email);
            listaClientes[index].Email = Console.ReadLine();
        }

        public void excluir()
        {
            Console.WriteLine("Informe o ID a ser excluido: ");
            int id = int.Parse(Console.ReadLine());
            int index = listaClientes.FindIndex(p => p.id == id);
            listaClientes.Remove(listaClientes[index]);
        }
        public void listarTodos()
        {
            foreach (var cliente in listaClientes)
            {
                Console.WriteLine(cliente.Id + " | " + cliente.Nome + " | " + cliente.Endereco + " | " + cliente.Telefone + " | " + cliente.Email);
            }

            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }

        public void lerArquivo(string caminhoArquivo)
        {

            using (StreamReader reader = new StreamReader(caminhoArquivo))
            {
                while (!reader.EndOfStream)
                {
                    string linha = reader.ReadLine();
                    string[] campos = linha.Split(';');

                       int coluna1 = int.Parse(campos[0]); //id
                    string coluna2 = campos[1]; //nome
                    string coluna3 = campos[2]; //endereco
                    string coluna4 = campos[3]; //telefone
                    string coluna5 = campos[4]; //email

                    Cliente cliente = new Cliente(coluna1, coluna2, coluna3, coluna4, coluna5);
                    listaClientes.Add(cliente);
                    if (coluna1 > ID)
                    {
                    ID = coluna1;
                    }
                    //Console.WriteLine($"Coluna1: {coluna1}, Coluna2: {coluna2}");
                }
                ID++;
                //Console.Read();
            }
        }
    }
}
