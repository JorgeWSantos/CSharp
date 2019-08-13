using System;

namespace SGP.Modelo
{
    public class cadastro_empresa
    {
        public int cod_empresa { get; set; }
        public String razao_social { get; set; }
        public String nome_fantasia { get; set; }
        public String cnpj { get; set; }
        public String endereco { get; set; }
        public String numero { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public String cep { get; set; }
        public String telefone { get; set; }
        public String estado { get; set; }
        public String logotipo { get; set; }
        public String status { get; set; }
        public Boolean selecionado { get; set; }
    }
}
