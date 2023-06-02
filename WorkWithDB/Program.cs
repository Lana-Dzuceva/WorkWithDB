using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WorkWithDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Lana");
            string host = "localhost"; // Имя хоста
            string database = "mysql"; // Имя базы данных
            string user = "root"; // Имя пользователя
            string password = ""; // Пароль пользователя

            string Connect = "Database=" + database + ";Datasource=" + host + ";User=" + user + ";Password=" + password;
            MySqlConnection mysql_connection = new MySqlConnection(Connect);
            
            mysql_connection.Open();
            MySqlCommand mysql_query = mysql_connection.CreateCommand();
            
            MySqlDataReader mysql_result;
            //mysql_query.CommandText = "CREATE SCHEMA `anime` ;";
            //mysql_query.CommandText = "CREATE TABLE `anime`.`anime` (" +
            //    "  `id` INT NOT NULL,\r\n  `title` VARCHAR(80) NOT NULL," +
            //    " `release_year` INT NOT NULL DEFAULT 2003," +
            //    "  `author` VARCHAR(55) NOT NULL DEFAULT 'Super cool secret author'," +
            //    "  PRIMARY KEY (`id`));";
            //mysql_query.CommandText = "ALTER TABLE `anime`.`anime` " +
            //    "CHANGE COLUMN `id` `id` INT NOT NULL AUTO_INCREMENT ;";
            mysql_query.CommandText = "INSERT INTO `anime`.`anime` " +
                "(`title`, `release_year`, `author`)" +
                " VALUES ('Naruto', '2002', 'Masashi Kishimoto');";
            mysql_query.CommandText = "SELECT * FROM `anime`.`anime`;";
            mysql_result = mysql_query.ExecuteReader();

            while (mysql_result.Read())
            {
                Console.WriteLine("{0}", mysql_result.GetString(1));
            }
        }
    }
}
