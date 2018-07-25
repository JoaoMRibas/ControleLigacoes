using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using ControleLigacoes.cadastros;
using ControleLigacoes.dados;
using ControleLigacoes.dados.password;
using Menu = ControleLigacoes.cadastros.Menu;

namespace ControleLigacoes
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }


    }
}
