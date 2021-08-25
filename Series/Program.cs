using System;
using System.Collections.Generic;
using System.Linq;

namespace Series
{
    class Program
    { static biblioteca serierepositorio = new biblioteca();
        static void Main(string[] args)
        {
             string op = opçaousuario();
            while (op.ToUpper() != "X")
            {
                switch (op)
                {
                    case "1":
                        Listarserie();
                        break;

                        
                    case "2":
                        inserirserie();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        deletar();
                        break;
                    case "5":
                        visualizar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();



                }
                op = opçaousuario();
            }
    
        
        
        
        
        
        
        
        
        }
        private static void Listarserie()
        {
            Console.WriteLine("Listar séries");

            var lista = serierepositorio.lista();
            


            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;

            }




            string genero = "";
            while (genero.ToUpper() != "F")
            {
                foreach (var series in lista)
                {
                    var excluido = series.retornaExcluido();

                    Console.WriteLine("#ID {0}: - {1} {2}", series.retornaid(), series.retornatitulo(), (excluido ? "*Excluído*" : ""));
                }
                Console.WriteLine("digite F se deseja filtra por genero");
                genero = Console.ReadLine(); }
            foreach (int i in Enum.GetValues(typeof(generos)))
            {

                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(generos), i));
            }

            Console.WriteLine("escolha uma opçao entre os generos acima:");
            Console.WriteLine();
            int entrada = int.Parse(Console.ReadLine());
            generos ge = (generos)entrada;
            var filmes = lista.Where(f => f.retornagenero() == ge).ToList();
            foreach(var filme in filmes)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaid(), filme.retornatitulo(), (excluido ? "*Excluído*" : ""));
            }









            return;
                
            

         
            
           
            



            
        }
        private static void inserirserie()
        {
            Console.WriteLine("deseja inserir uma nova serie? Selecione 'S' para continuar ou 'X' para retornar");
            string voltar =  Console.ReadLine();
            ;
            while(voltar.ToUpper() != "S") { return; }
           
            Console.WriteLine("inserir serie :");
            foreach (int i in Enum.GetValues(typeof(generos)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(generos), i));
              }
            

            Console.WriteLine("escolha uma opçao entre os generos acima:");
            Console.WriteLine();
           int entradagenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o Título da Série: ");
            Console.WriteLine();
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            Console.WriteLine();
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            Console.WriteLine();
            string entradaDescricao = Console.ReadLine();
            series novaserie = new series(
                                        id: serierepositorio.proximoid(),
                                         Descriçao:entradaDescricao,
                                        genero: (generos)entradagenero,
                                         Titulo: entradaTitulo,
                                         Ano: entradaAno
                                        ); 
            serierepositorio.insere(novaserie);
            

          

        }
        private static void Atualizar()

        {
            Console.WriteLine("deseja atualizar uma nova serie? Selecione 'S' para continuar ou 'X' para retornar");
            string voltar = Console.ReadLine();
            var lista = serierepositorio.lista();
            
            while (voltar.ToUpper() != "S") { return; }

            
            foreach(var series in lista)
            {
                var excluido = series.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", series.retornaid(), series.retornatitulo(), (excluido ? "*Excluído*" : ""));

            }
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = serierepositorio.retornaporid(indiceSerie);
            foreach (int i in Enum.GetValues(typeof(generos)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(generos), i));
            }
            Console.Write($"Digite o gênero entre as opções acima para alterar de {serie.retornagenero()} para : ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write($"Digite o Título da Série para alterar de {serie.retornatitulo()} para : ");
            string entradaTitulo = Console.ReadLine();

            Console.Write($"Digite o Ano de Início da Série para alterar de {serie.retornaano()} para : ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write($"Digite a Descrição da Série para alterar de {serie.retornadescriçao()} para: ");
            string entradaDescricao = Console.ReadLine();

            series atualizaSerie = new series(id: indiceSerie,
                                        genero: (generos)entradaGenero,
                                        Titulo: entradaTitulo,
                                        Ano: entradaAno,
                                        Descriçao: entradaDescricao);
            serierepositorio.atualizar(indiceSerie,atualizaSerie);

        }
        private static void deletar()

        { var lista = serierepositorio.lista();
            if (lista.Count > 0)
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());
                var serie = serierepositorio.retornaporid(indiceSerie);
                Console.WriteLine($"deseja deletar {serie.retornatitulo()} digite S Caso contrario digite X para sair");
                var select = Console.ReadLine();
                while (select.ToUpper() != "X")
                { serierepositorio.excluir(indiceSerie); }
                return;
            }
            Console.WriteLine("Nao existe Series.");
            return;
            
        }
        private static void visualizar()
        {
            Console.WriteLine(serierepositorio.lista());
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = serierepositorio.retornaporid(indiceSerie);

            Console.WriteLine(serie);
        }
        private static string opçaousuario()
        {
            Console.WriteLine();
            Console.WriteLine("NetSeries");
            Console.WriteLine("escolha a opçao desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar todas as Series");
            Console.WriteLine("2- inserir Serie");
            Console.WriteLine("3- Atualizar Series");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- visualizar serie");
            Console.WriteLine("C-Limpar console");
            Console.WriteLine("X- sair");
            Console.WriteLine();
            string opçao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opçao;

        }
        
        }

    }






    
