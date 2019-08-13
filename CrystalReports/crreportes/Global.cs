

using System;

namespace crreportes
{
    public static class Global
    {
        private static string domain;
        public static string Campos;//STRING DE CAMPOS SQL
        public static string Valores;//STRING VALUES SQL
        public static string query;//STRING QUERY SQL
        public static string criterio;//STRING CRITERIO
        public static string criterio_select;//STRING SELECT 

        //PEGA O CAMINHO
        public static string PegarCaminho()
        {
            if (String.IsNullOrEmpty(domain))
                domain = AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("\\bin\\Debug\\", "").Replace("\\bin\\x64\\Debug\\", "").Replace("\\bin\\x86\\Debug\\", "");

            return domain;
        }
    }
}
