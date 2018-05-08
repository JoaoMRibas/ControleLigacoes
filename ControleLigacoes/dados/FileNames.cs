using System;

namespace ControleLigacoes.dados
{
    public static class FileNames
    {
        public static string GetFileName<T>()
        {
            Type type = typeof(T);

            if (type == typeof(Cliente))
            {
                return "clientes.json";
            }

            if (type == typeof(Usuario))
            {
                return "usuarios.json";
            }

            if (type == typeof(Ligacao))
            {
                return "ligacoes.json";
            }

            if (type == typeof(HistoricoStatus))
            {
                return "historicoStatus.json";
            }

            throw new ArgumentException();
        }
    }
}