using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaARD.Vistas
{
    public partial class RegistrarDepartamentos : Form
    {
        Departamentos dptos = new Departamentos();
        public RegistrarDepartamentos()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre");
            }
            else
            {
                dptos.Nombre = txtNombre.Text.Trim();
                using (DBEntities db = new DBEntities())
                {
                    db.Departamentos.Add(dptos);
                    db.SaveChanges();
                }
                MessageBox.Show("Departamento almacenado con éxito");
                txtNombre.Text = "";
            }
            
        }
    }
}
