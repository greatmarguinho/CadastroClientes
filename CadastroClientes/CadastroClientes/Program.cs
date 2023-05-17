using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controle controle = new Controle();
            controle.lerArquivo(@"C:\Users\Marco Antonio\Downloads\teste.csv");    //caminho do arquivo csv
            controle.apresentaMenu();
        }
    }
}
