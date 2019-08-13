using crreportes.dados;
using Npgsql;
using SGP.Modelo;
using System;
using System.Data;
using System.Windows.Forms;

namespace crreportes.DAO
{
    public class cadastro_empresaDAO
    {
        #region VARIAVEIS

        private NpgsqlDataReader dataReader;

        #endregion

        #region INSTANCIAS

        cadastro_empresa cadastroEmpresa;

        #endregion


        //selecionar empresa
        public cadastro_empresa SelecionarEmpresa(int cod_empresa)
        {
            cadastroEmpresa = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                try
                {
                    Conexao.Conectar();
                    cmd.Connection = Conexao.con;
                    cmd.CommandText = $"SELECT * FROM cadastro_empresa " +
                                      $"WHERE cod_empresa = {cod_empresa}"
                                      ;

                    dataReader = cmd.ExecuteReader();

                    if (dataReader.HasRows == true)
                    {
                        dataReader.Read();

                        try
                        {
                            cadastroEmpresa = new cadastro_empresa()
                            {
                                cod_empresa = Convert.ToInt32(dataReader["cod_empresa"].ToString()),
                                razao_social = dataReader["razao_social"].ToString(),
                                nome_fantasia = dataReader["nome_fantasia"].ToString(),
                                logotipo = dataReader["logotipo"].ToString(),
                                endereco = dataReader["endereco"].ToString(),
                                bairro = dataReader["bairro"].ToString(),
                                numero = dataReader["numero"].ToString(),
                                cidade = dataReader["cidade"].ToString(),
                                telefone = dataReader["telefone"].ToString(),
                                estado = dataReader["estado"].ToString(),
                                cep = dataReader["cep"].ToString(),
                                cnpj = dataReader["cnpj"].ToString(),
                            };
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message + "Cadastro_EmpresaDAO, SelecionarEmpresa()", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    else
                        cadastroEmpresa = new cadastro_empresa();

                    dataReader.Close();
                    Conexao.Desconectar();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "Cadastro_EmpresaDAO, SelecionarEmpresa()", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return cadastroEmpresa;
            }
        }

    }
}
