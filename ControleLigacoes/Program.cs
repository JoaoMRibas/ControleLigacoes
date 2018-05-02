using System;
using System.Windows.Forms;
using ControleLigacoes.cadastros;
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
            Application.Run(new Menu());
        }
    }
}
