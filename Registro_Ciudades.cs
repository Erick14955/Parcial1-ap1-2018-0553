﻿using Parcial1_ap1_2018_0553.BLL;
using Parcial1_ap1_2018_0553.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_ap1_2018_0553
{
    public partial class Registro_Ciudades : Form
    {
        public Registro_Ciudades()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            NombretextBox.Clear();
        }

        private void LlenarCampos(Ciudad ciudad)
        {
            IDnumericUpDown.Value = ciudad.CiudadID;
            NombretextBox.Text = ciudad.Nombre_Ciudad;
        }

        private Ciudad LlenarClase()
        {
            Ciudad ciudad = new Ciudad();
            ciudad.CiudadID = (int)IDnumericUpDown.Value;
            ciudad.Nombre_Ciudad = NombretextBox.Text;

            return ciudad;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Ciudad ciudad = new Ciudad();
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            ciudad = CiudadBLL.Buscar(id);

            if(ciudad != null)
            {
                MessageBox.Show("La ciudad ha sido encontrada");
                LlenarCampos(ciudad);
            }
            else
            {
                MessageBox.Show("La ciudad no ha sido encontrada o no esta registrada");
            }
        }

        private bool Validar()
        {
            bool paso = true;

            if(NombretextBox.Text == string.Empty)
            {
                ErroreserrorProvider.SetError(NombretextBox, "Este campo no puede quedar vacio");
                NombretextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Ciudad ciudad = CiudadBLL.Buscar((int)IDnumericUpDown.Value);

            return (ciudad != null);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Ciudad ciudad;
            bool paso = false;
            if (!Validar())
            {
                return;
            }

            ciudad = LlenarClase();
            paso = CiudadBLL.Guardar(ciudad);

            if (!ExisteEnLaBaseDeDatos())
            {
                Limpiar();
                MessageBox.Show("Usuario guardado correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("Usuario modificado correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            ErroreserrorProvider.Clear();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Limpiar();
            if (CiudadBLL.Eliminar(id))
            {
                MessageBox.Show("Usuario eliminado correctamente", "Proceso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ErroreserrorProvider.SetError(IDnumericUpDown, "ID no existe en la base de datos");
            }
        }
    }
}
