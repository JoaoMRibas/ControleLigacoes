using System.Diagnostics;
using System.Windows.Forms;

namespace ControleLigacoes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Inicializa();

        }

        public void Inicializa()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine(System.Guid.NewGuid().ToString());
                
            }
            
        }
    }

}
