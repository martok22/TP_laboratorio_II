using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> aux = new List<string>();
                Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
                archivos.leer(out aux);
                foreach (string linea in aux)
                {
                    if (linea!=null)
                        this.lstHistorial.Items.Add(linea);
                }
            }
            catch(Exception excp)
            {
                throw new Exception(excp.Message, excp);
            }
            
 
        }
    }
}
