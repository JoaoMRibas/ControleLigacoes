using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

       
    }
}
