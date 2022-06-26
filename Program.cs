using DIO_Series.Classes;
using DIO_Series.Enum;
using System;

namespace DIO_Series
{
    class Program
    {
        private static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X") 
            {
                if (opcaoUsuario.Equals("1"))
                {
                    ListarSeries();
                }
                else if (opcaoUsuario.Equals("2"))
                {
                    InserirSerie();
                }
                else if (opcaoUsuario.Equals("3"))
                {
                    AtualizarSerie();
                }
                else if (opcaoUsuario.Equals("4"))
                {
                    ExcluirSerie();
                }
                else if (opcaoUsuario.Equals("5"))
                {
                   VizualizarSerie();
                }
                else if (opcaoUsuario.Equals("C"))
                {
                    Console.Clear();
                }
                else throw new ArgumentOutOfRangeException();

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");

            Console.ReadLine();
        }

        private static void ListarSeries() 
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();
            if (lista.Count == 0) 
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach(var serie in lista) 
            {
                var excluido = serie.ReturnExcluido();

                Console.WriteLine("#ID - {0}: - {1} {2}", serie.ReturnID(), serie.ReturnTitulo(),excluido?"*Excluído":"");
            }
        }

        private static void InserirSerie() 
        {
            Console.WriteLine("Inserir uma nova série");

            foreach(int i in System.Enum.GetValues(typeof(Genero))) 
            {
                Console.WriteLine("{0} - {1}", i,System.Enum.Parse(typeof(Genero),i.ToString()));
            }
            Console.WriteLine("Digite o número do Genênro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o Ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id:repositorio.ProximoID(),genero:(Genero)entradaGenero,titulo:entradaTitulo,
                descricao:entradaDescricao,ano:entradaAno);
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie() 
        {
            Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.Parse(typeof(Genero), i.ToString()));
            }
            Console.WriteLine("Digite o número do Genênro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o Ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: repositorio.ProximoID(), genero: (Genero)entradaGenero, titulo: entradaTitulo,
               descricao: entradaDescricao, ano: entradaAno);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie() 
        {
            Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VizualizarSerie() 
        {
            Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorID(indiceSerie);

            Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario() 
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!");
            Console.WriteLine("Informe a opção desejada!");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Vizualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string respostaUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return respostaUsuario;
        
        }
    }
}
