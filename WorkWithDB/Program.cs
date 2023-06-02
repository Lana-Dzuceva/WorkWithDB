﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WorkWithDB
{
    internal class Program
    {
        static void send_request(string connect, string sqlCommand)
        {
            MySqlConnection mysql_connection = new MySqlConnection(connect);

            mysql_connection.Open();
            MySqlCommand mysql_query = mysql_connection.CreateCommand();
            MySqlDataReader mysql_result;
            mysql_query.CommandText = sqlCommand;
            mysql_result = mysql_query.ExecuteReader();
            while (mysql_result.Read())
            {
                Console.WriteLine("{0}", mysql_result.GetString(1));
            }
            mysql_connection.Close();
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Lana");
            string host = "localhost"; // Имя хоста
            string database = "mysql"; // Имя базы данных
            string user = "root"; // Имя пользователя
            string password = ""; // Пароль пользователя

            string Connect = "Database=" + database + ";Datasource=" + host + ";User=" + user + ";Password=" + password;
            List<string> commands = new List<string>
            {
             "CREATE SCHEMA `anime` ;",

             "CREATE TABLE `anime`.`anime` (" +
                "  `id` INT NOT NULL,  `title` VARCHAR(80) NOT NULL," +
                " `release_year` INT NOT NULL DEFAULT 2003," +
                "  `author` VARCHAR(55) NOT NULL DEFAULT 'Super cool secret author'," +
                "  PRIMARY KEY (`id`));",

            "ALTER TABLE `anime`.`anime` " +
               "CHANGE COLUMN `id` `id` INT NOT NULL AUTO_INCREMENT ;",

            "INSERT INTO `anime`.`anime` " +
               "(`title`, `release_year`, `author`)" +
               " VALUES ('Naruto', '2002', 'Masashi Kishimoto');",

            "SELECT * FROM `anime`.`anime`;",


             "CREATE TABLE `anime`.`users` (" +
                                   " `id` INT NOT NULL AUTO_INCREMENT," +
                                   "  `name` VARCHAR(45) NOT NULL," +
                                   " `email` VARCHAR(45) NOT NULL," +
                                   "  `password` VARCHAR(45) NOT NULL," +
                                   "  PRIMARY KEY (`id`));",

            "INSERT INTO `anime`.`users` " +
               "(`name`, `email`, `password`)" +
               " VALUES ('Lana', 'ld@gmail.com', '12345');",

            "CREATE TABLE `anime`.`viewed_anime` (" +
               "  `id` INT NOT NULL AUTO_INCREMENT," +
               "  `id_user` INT NOT NULL," +
               "  `id_anime` INT NOT NULL," +
               "  PRIMARY KEY (`id`)," +
               "  INDEX `viewed_anime anime_idx` (`id_anime` ASC) VISIBLE," +
               "  INDEX `viewed anime users_idx` (`id_user` ASC) VISIBLE," +
               "  CONSTRAINT `viewed_anime anime`" +
               "    FOREIGN KEY (`id_anime`)" +
               "    REFERENCES `anime`.`anime` (`id`)" +
               "    ON DELETE NO ACTION" +
               "    ON UPDATE NO ACTION," +
               "  CONSTRAINT `viewed anime users`" +
               "   FOREIGN KEY (`id_user`)" +
               "    REFERENCES `anime`.`users` (`id`)" +
               "    ON DELETE NO ACTION" +
               "    ON UPDATE NO ACTION);"
        };

        // не работает
        //for (int i = 0; i < 5; i++)
        //{

        //    mysql_query.CommandText = "INSERT INTO `anime`.`anime` " +
        //                    "(`title`, `release_year`)" +
        //                    $" VALUES ('аниме{i}', '200{i}');";
        //    mysql_result = mysql_query.ExecuteReader();
        //    while (mysql_result.Read())
        //    {
        //        Console.WriteLine("{0}", mysql_result.GetString(1));
        //    }

        //}


        var userCommand = "";
        Console.WriteLine("Привет дорогой гость тебе доступны команды 1 - добавить в таблицу,\n 2 - удалить,  0 - закончить все и выйти");






        }
}
}
