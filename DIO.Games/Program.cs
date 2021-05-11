using System;
using DIO.Games.Enumerables;
using DIO.Games.Models;
using DIO.Games.Repositorio;

namespace DIO.Games
{    
    class Program
    {
        static GameRepositorio gameRepositorio = new GameRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarGames();
						break;
					case "2":
						InserirGame();
						break;
					case "3":
						AtualizarGame();
						break;
					case "4":
						ExcluirGame();
						break;
					case "5":
						VisualizarGame();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirGame()
		{
			Console.Write("Digite o id do game: ");
			int indiceGame = int.Parse(Console.ReadLine());

			gameRepositorio.Excluir(indiceGame);
		}

        private static void VisualizarGame()
		{
			Console.Write("Digite o id do game: ");
			int indiceGame = int.Parse(Console.ReadLine());

			var game = gameRepositorio.RetornaPorId(indiceGame);

			Console.WriteLine(game);
		}

        private static void AtualizarGame()
		{
			Console.Write("Digite o id do Game: ");
			int indiceGame = int.Parse(Console.ReadLine());
			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Game: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento do Game: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Game: ");
			string entradaDescricao = Console.ReadLine();

			Game atualizarGame = new Game(id: indiceGame,
										  genero: (Genero)entradaGenero,
										  titulo: entradaTitulo,
										  ano: entradaAno,
										  descricao: entradaDescricao);

			gameRepositorio.Atualizar(indiceGame, atualizarGame);
		}

        private static void ListarGames()
		{
			Console.WriteLine("Listar games");

			var listaGames = gameRepositorio.Lista();

			if (listaGames.Count == 0)
			{
				Console.WriteLine("Nenhum game cadastrado.");
				return;
			}

			foreach (var game in listaGames)
			{
                var excluido = game.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", game.retornaId(), game.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirGame()
		{
			Console.WriteLine("Inserir novo game");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do game: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento do Game: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do  Game: ");
			string entradaDescricao = Console.ReadLine();

			Game Game = new Game(id: gameRepositorio.ProximoId(),
								 genero: (Genero)entradaGenero,
								 titulo: entradaTitulo,
								 ano: entradaAno,
								 descricao: entradaDescricao);

			gameRepositorio.Inserir(Game);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Games a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar games");
			Console.WriteLine("2- Inserir novo game");
			Console.WriteLine("3- Atualizar game");
			Console.WriteLine("4- Excluir game");
			Console.WriteLine("5- Visualizar game");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();

			Console.WriteLine();
            
			return opcaoUsuario;
		}
    }
}
