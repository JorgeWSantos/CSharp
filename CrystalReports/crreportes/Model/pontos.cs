using System;
using System.Collections.Generic;

namespace crreportes.Modelo
{
    class pontos
    {
        public int cod_ponto { get; set; }
        public int cod_funcionario { get; set; }
        public string nome_funcionario { get; set; }
        public string cargo { get; set; }
        public DateTime data { get; set; }
        public TimeSpan? entrada_inicio_expediente { get; set; }
        public TimeSpan? saida_inicio_expediente { get; set; }
        public TimeSpan? entrada_final_expediente { get; set; }
        public TimeSpan? saida_final_expediente { get; set; }
        public TimeSpan? entrada_extra { get; set; }
        public TimeSpan? saida_extra { get; set; }
        public decimal valor_hr { get; set; }
        public TimeSpan? total_hr_dia { get; set; }
        public decimal valor_dia { get; set; }
        public TimeSpan? total_hr_extra { get; set; }
        public decimal valor_hr_extra_dia { get; set; }
        public string dia_semana { get; set; }
        public int cod_hora_extra { get; set; }

        //public virtual funcionarios funcionarios { get; set; }
    }
}
