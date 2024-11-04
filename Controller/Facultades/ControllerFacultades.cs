using Refuerzo2024.Model.DAO;
using Refuerzo2024.View.Estudiantes;
using Refuerzo2024.View.Facultades_y_Especialidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Refuerzo2024.Controller.Facultades
{
    internal class ControllerFacultades
    {

        ViewFacultades objFacultades;

        public ControllerFacultades(ViewFacultades objFacultades)
        {
            this.objFacultades = objFacultades;
            objFacultades.Load += new EventHandler(cargainicial);
            objFacultades.btnAgregar.Click += new EventHandler(RegistrarFacultad);
            objFacultades.dgvFacultades.CellClick += new DataGridViewCellEventHandler(SeleccionarDato);
            objFacultades.btnActualizar.Click += new EventHandler(ActualizarFacultad);
            objFacultades.btnEliminar.Click += new EventHandler(EliminarFacultad);
            objFacultades.btnBuscar.Click += new EventHandler(BuscarFacultad);

        }

        public void SeleccionarDato(object sender, DataGridViewCellEventArgs e)
        {
            //Capturar la fila a la que se le dió click
            int pos = objFacultades.dgvFacultades.CurrentRow.Index;
            //Enviar los datos del DataGridView hacia los controles
            objFacultades.txtID.Text = objFacultades.dgvFacultades[0, pos].Value.ToString();
            objFacultades.txtNombres.Text = objFacultades.dgvFacultades[1, pos].Value.ToString();
        }


        public void cargainicial(object sender, EventArgs e)
        {
            cargarDTG();
        }

        public void cargarDTG()
        {
            DAOFacultades obj = new DAOFacultades();
            //Se crea un DataSet que almacenará los valores que retorne el metodo.
            DataSet ds = obj.ObtenerFacultades();
            //Llenamos el combobox
            objFacultades.dgvFacultades.DataSource = ds.Tables["Facultades"];
        }
        public void RegistrarFacultad(object sender, EventArgs e)
        {
            DAOFacultades data = new DAOFacultades();
            //Guardar en los atributos del DTO todos los valores contenidos en los componentes del formulario
            data.NombreFacultad = objFacultades.txtNombres.Text.Trim();
            //Se invoca al metodo RegistrarEstudiante y se verifica si su retorno es TRUE, de ser así significa que los datos pudieron ser registrados correctamente, de lo contrario, no se pudo registrar los valores.
            if (data.RegistrarFacultad() == true)
            {
                MessageBox.Show("Datos registrados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cargarDTG();
        }



        public void ActualizarFacultad(object sender, EventArgs e)
        {
            DAOFacultades data = new DAOFacultades();
            //Guardar en los atributos del DTO todos los valores contenidos en los componentes del formulario
            data.IdFacultad = (objFacultades.txtID.Text.Trim());
            data.NombreFacultad = objFacultades.txtNombres.Text.Trim();
            if (data.ActualizarFacultad() == true)
            {
                MessageBox.Show("Los datos fueron actualizados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarDTG();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados.", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EliminarFacultad(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(objFacultades.txtID.Text.Trim()))
            {
                MessageBox.Show("Seleccione un registro", "Seleccione un valor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOFacultades data = new DAOFacultades();
                data.IdFacultad = (objFacultades.txtID.Text.Trim());
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (data.EliminarFacultad() == true)
                    {
                        MessageBox.Show("El dato fue eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDTG();
                    }
                    else
                    {
                        MessageBox.Show("El registro no pudo ser eliminado", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void BuscarFacultad(object sender, EventArgs e)
        {
            DAOFacultades data = new DAOFacultades();
            DataSet ds = data.BuscarFacultad(objFacultades.txtBuscar.Text.Trim());
            objFacultades.dgvFacultades.DataSource = ds.Tables["Facultades"];
        }










    }

}

