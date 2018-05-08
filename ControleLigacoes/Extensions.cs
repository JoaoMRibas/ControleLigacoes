using System;
using System.Collections.Generic;
using System.IO;
using ControleLigacoes.dados;
using Newtonsoft.Json;

namespace ControleLigacoes
{
    public static class Extensions
    {
        #region Json

        /// <summary>
        /// Serializar um objeto para JSON
        /// </summary>
        public static string Serialize<T>(this T value)
        {
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// Deserializar um objeto a partir de JSON
        /// </summary>
        public static T Deserialize<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        #endregion

        #region Guid

        public static bool IsEmpty(this Guid guid)
        {
            return Guid.Empty.Equals(guid);
        }

        #endregion

        #region Carregar Dados

        public static List<T> CarregarDados<T>()
        {
            return CarregarDados<T>(FileNames.GetFileName<T>());
        }

        public static List<T> CarregarDados<T>(this string fileName)
        {
            string dados = File.ReadAllText($"C:\\Users\\user\\Desktop\\Teste\\{fileName}");
            return dados.Deserialize<List<T>>();
        }

        #endregion
    }
}
