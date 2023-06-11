using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Milestone.Models;

namespace Milestone.Services
{
    public class GameDAO : IGameService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Milestone;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<GameDTO> GetSavedGames()
        {
            List<GameDTO> savedGames = new List<GameDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlStatement = "SELECT * FROM Games";

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GameDTO game = new GameDTO
                    {
                        Id = (int)reader["ID"],
                        ButtonState = (int)reader["ButtonState"],
                        Live = (bool)reader["Live"],
                        Row = (int)reader["Row"],
                        Column = (int)reader["Column"],
                        Visited = (bool)reader["Visited"],
                        Neighbors = (int)reader["Neighbors"],
                        ImageName = (string)reader["ImageName"],
                        Flagged = (bool)reader["Flagged"],
                        SaveDateTime = (DateTime)reader["SaveDateTime"]
                    };

                    savedGames.Add(game);
                }
            }

            return savedGames;
        }

        public GameDTO GetGameById(int gameId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlStatement = "SELECT * FROM Games WHERE ID = @GameId";

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@GameId", gameId);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    GameDTO game = new GameDTO
                    {
                        Id = (int)reader["ID"],
                        ButtonState = (int)reader["ButtonState"],
                        Live = (bool)reader["Live"],
                        Row = (int)reader["Row"],
                        Column = (int)reader["Column"],
                        Visited = (bool)reader["Visited"],
                        Neighbors = (int)reader["Neighbors"],
                        ImageName = (string)reader["ImageName"],
                        Flagged = (bool)reader["Flagged"],
                        SaveDateTime = (DateTime)reader["SaveDateTime"]
                    };

                    return game;
                }
            }

            return null;
        }

        public void SaveGame(GameDTO game)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlStatement = "INSERT INTO Games (ButtonState, Live, Row, Column, Visited, Neighbors, ImageName, Flagged, SaveDateTime) " +
                                      "VALUES (@ButtonState, @Live, @Row, @Column, @Visited, @Neighbors, @ImageName, @Flagged, @SaveDateTime)";

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@ButtonState", game.ButtonState);
                command.Parameters.AddWithValue("@Live", game.Live);
                command.Parameters.AddWithValue("@Row", game.Row);
                command.Parameters.AddWithValue("@Column", game.Column);
                command.Parameters.AddWithValue("@Visited", game.Visited);
                command.Parameters.AddWithValue("@Neighbors", game.Neighbors);
                command.Parameters.AddWithValue("@ImageName", game.ImageName);
                command.Parameters.AddWithValue("@Flagged", game.Flagged);
                command.Parameters.AddWithValue("@SaveDateTime", game.SaveDateTime);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteGame(int gameId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlStatement = "DELETE FROM Games WHERE ID = @GameId";

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@GameId", gameId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}