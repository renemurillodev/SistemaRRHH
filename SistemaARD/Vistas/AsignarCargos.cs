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
    public partial class AsignarCargos : Form
    {
        public string id = "";
        public AsignarCargos()
        {
            InitializeComponent();
        }

        private void AsignarCargos_Load(object sender, EventArgs e)
        {
            CargarNombres();
            LlenarCargos();
        }

        void CargarNombres()
        {
            using (DBEntities db = new DBEntities())
            {
                cbxEmpleados.DataSource = db.Empleados.ToList<Empleados>();

                cbxEmpleados.DisplayMember = "NombreCompleto";
                cbxEmpleados.ValueMember = "Id";
            }
        }

        void LlenarCargos()
        {
            using (DBEntities db = new DBEntities())
            {
                cbxCargos.DataSource = db.Cargos.ToList<Cargos>();

                cbxCargos.DisplayMember = "Nombre";
                cbxCargos.ValueMember = "Id";
            }
        }
    }
}
