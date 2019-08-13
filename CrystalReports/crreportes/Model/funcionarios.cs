using System;
using System.Collections.Generic;

namespace crreportes.Modelo
{
    class funcionarios
    {
        //funcionarios
        public int cod_funcionario { get; set; }
        public string nome_funcionario { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string cep { get; set; }
        public string telefone { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public DateTime data_nasc { get; set; }
        public string status { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime hora { get; set; }
        public decimal valor_hr { get; set; }
        public string nr { get; set; }
        public decimal salario { get; set; }
        public string cargo { get; set; }
        public DateTime data_admissao { get; set; }
        public int cod_empresa { get; set; }
        public DateTime data_atualizacao { get; set; }
        public string observacao { get; set; }
        public string primeiro_nome { get; set; }
        public string selecionado { get; set; }
        public string numero { get; set; }
        public string area_atividade { get; set; }
        public TimeSpan? inicio_jornada_noturna { get; set; }
        public TimeSpan? termino_jornada_noturna { get; set; }
        public TimeSpan? total_jornada_noturna { get; set; }
        public TimeSpan? hora_noturna { get; set; }
        public decimal acrescimo_noturno { get; set; }

        //public virtual List<pontos> pontos { get; set; }

    }
}
