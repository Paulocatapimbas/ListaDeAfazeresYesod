using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    private static string connectionString;

    static void Main(string[] args)
    {
        // Load configuration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        connectionString = configuration.GetConnectionString("dados");
       var opcao = menu();
        switch (opcao)
        {
            case 1:
                criar_tarefa();
                break;
            case 2:
                ver_tarefa();
                break;
            case 3:
               
                break;
            case 4:
                deletar_tarefa();
                break;
        }
    }
    static int menu()
    {
        Console.WriteLine("    Escolha uma opção");
        Console.WriteLine("1 - Adicionar nova tarefa");
        Console.WriteLine("2 - Ver tarefa");
        Console.WriteLine("3 - Editar tarefa");
        Console.WriteLine("4 - Deletar tarefa");
        int opcao = int.Parse(Console.ReadLine());
        return opcao;
    }

    static void criar_tarefa()
    {
        Console.Write("Digite a tarefa: ");
        var tarefa = Console.ReadLine();
        Console.WriteLine("Digite a data da tarefa");
        var data = Console.ReadLine();
        Console.WriteLine("Digite a prioridade da tarefa");
        var prioridade = Console.ReadLine();

        // Connect to MySQL database and insert data
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "INSERT INTO cad_tarefas(tarefa, data_tarefa, Prioridade ) VALUES (@tarefa, @data, @prioridade)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tarefa", tarefa);
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@prioridade", prioridade);
                command.ExecuteNonQuery();
            }
        }
    }
    static void ver_tarefa()
    {
        {
            Console.Write("Digite o id da tarefa que deseja ver: ");
            var id = Console.ReadLine();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT id,tarefa,data,prioridade FROM cad_tarefas WHERE id = @id) VALUES (@id, @tarefa,";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@tarefa", tarefa);
                    command.Parameters.AddWithValue("@data", data);
                    command.Parameters.AddWithValue("@prioridade", prioridade);
                    command.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine(

        }
    }
    static void deletar_tarefa()
    {
        Console.Write("Digite o id da tarefa que deseja deletar: ");
        var id = Console.ReadLine();
        // Connect to MySQL database and insert data
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "delete from cad_tarefas where id = @id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

    }

}
