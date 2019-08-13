using Npgsql;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace crreportes.dados
{
    public static class Conexao
    {

        public static string StringConexao = $@"Server=localhost; port=5432; Database=pontobd; UserId=postgres; Password=useregospostgresql@15";

        public static NpgsqlConnection con = new NpgsqlConnection(StringConexao);

        //CONECTAR
        public static void Conectar()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} Conexao, Conectar()", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //DESCONECTAR
        public static void Desconectar()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} Conexao, Desconectar()", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
