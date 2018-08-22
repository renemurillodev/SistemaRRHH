﻿using System;
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
    public partial class ListaEmpleados : Form
    {
        private Empleados empleados = new Empleados();
        
        public ListaEmpleados()
        {
            InitializeComponent();
        }

        private void ListaEmpleados_Load(object sender, EventArgs e)
        {
            CargarGrid();
            CargarNombres();
        }

        void CargarNombres()
        {
            using (DBEntities db = new DBEntities())
            {
                comboBox1.DataSource = db.Empleados.ToList<Empleados>();

                comboBox1.DisplayMember = "NombreCompleto";
                comboBox1.ValueMember = "Id";
            }
        }

        void CargarGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (DBEntities db = new DBEntities())
            {
                dataGridView1.DataSource = db.Empleados.ToList<Empleados>();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtApellido_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            string apellido = txtApellido.Text.Trim();
            using (DBEntities db = new DBEntities())
            {

                IQueryable<Empleados> obj = from q in db.Empleados
                                            where q.Apellidos.Contains(apellido)
                                            select q;
                List<Empleados> employee = obj.ToList();

                if (employee == null)
                {
                    MessageBox.Show("El empleado que intenta buscar no existe");
                }
                else
                {
                    
                    dataGridView1.DataSource = employee;
                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RegistroEmpleados registro = new RegistroEmpleados();
            if(dataGridView1.CurrentRow.Index != -1)
            {
                registro.texto = Convert.ToString(dataGridView1.CurrentRow.Cells["Id"].Value);

                
                registro.Show();
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AsignarCargos cargos = new AsignarCargos();
            if (dataGridView1.CurrentRow.Index != -1)
            {
                cargos.id = Convert.ToString(dataGridView1.CurrentRow.Cells["Id"].Value);


                cargos.Show();
            }
        }

        private void btnCargo_Click(object sender, EventArgs e)
        {

        }
    }
}
