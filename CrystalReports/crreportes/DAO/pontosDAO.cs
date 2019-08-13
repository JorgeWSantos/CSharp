using crreportes.dados;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace crreportes.DAO
{
    public class pontosDAO
    {
        DataTable dt;

        //SELECIONA PONTO POR data E cod_funcionario
        public DataTable Report_SelecionarTodosPonto()
        {
            using (dt = new DataTable())
            {
                try
                {
                    Conexao.Conectar();

                    //string query = $"select p.cod_ponto, p.data, f.cod_funcionario, f.nome_funcionario, f.cargo from pontos as p " +
                    //               $"inner join funcionarios as f " +
                    //               $"on f.cod_funcionario = p.cod_funcionario " 
                    //               ;

                    string query = $"select * from pontos " +
                                    $"where cod_ponto = (select MAX(cod_ponto) from pontos) "
                                   ;


                    using (var dataAdapter = new NpgsqlDataAdapter(query, Conexao.con))
                        dataAdapter.Fill(dt);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.Message} pontosDAO, Report_SelecionarTodosPonto()", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return dt;
        }
    }
}
