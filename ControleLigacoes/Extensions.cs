using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ControleLigacoes
{
    public static class Extensions
    {
        static Extensions()
        {
            SetDebug();
        }

        /// <summary>
        /// Define se a versão atual é uma versão de Debug
        /// </summary>
        public static bool EhDebug { get; private set; }

        [Conditional("DEBUG")]
        private static void SetDebug()
        {
            EhDebug = true;
        }

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
