using System.Collections.Generic;
using DIO.Games.Interfaces;
using DIO.Games.Models;

namespace DIO.Games.Repositorio
{
    public class GameRepositorio : IRepositorio<Game>
    {
        private List<Game> ListaGames = new List<Game>();

        public void Atualizar(int id, Game game)
        {
            ListaGames[id] = game;
        }

        public void Excluir(int id)
        {
            ListaGames[id].Excluir();
        }

        public void Inserir(Game game)
        {
            ListaGames.Add(game);
        }

        public List<Game> Lista()
        {
            return ListaGames;
        }

        public int ProximoId()
        {
            return ListaGames.Count;
        }

        public Game RetornaPorId(int id)
        {            
            return ListaGames[id];
        }
    }
}