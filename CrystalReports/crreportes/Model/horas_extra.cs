using System;

namespace crreportes.Modelo
{
    class horas_extra
    {
        public int cod_hora_extra { get; set; }
        public decimal segunda_feira { get; set; }
        public decimal terca_feira { get; set; }
        public decimal quarta_feira { get; set; }
        public decimal quinta_feira { get; set; }
        public decimal sexta_feira { get; set; }
        public decimal sabado { get; set; }
        public decimal domingo { get; set; }
        public decimal feriado { get; set; }
        public DateTime? data { get; set; }
        public TimeSpan? hora { get; set; }
        public int cod_usuario_sessao { get; set; }
    }
}
