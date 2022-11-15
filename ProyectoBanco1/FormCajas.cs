﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoBanco1
{
    public partial class FormCajas : Form
    {
        private Banco banco;

        public delegate void TransfDelegado();
        public TransfDelegado ventanaInicio;
        public FormCajas(Banco banco)
        {
            InitializeComponent();
            this.banco = banco;
            recargar();
        }

        //Agregar una Caja de Ahorro al cliente actual
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea agregar una nueva caja de ahorro a su nombre?", "Cajas de ahorro", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                banco.altaCajaAhorro(banco.usuarioActual);
                recargar();
            }
        }

        //Eliminar una Caja de Ahorro del cliente actual
        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Eliminará la caja de ahorro seleccionada. Desea continuar?", "Cajas de ahorro", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int selectedIndex = dataGridView1.CurrentRow.Index;
                int id = int.Parse(dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString());
                if (selectedIndex > -1)
                {
                    banco.bajaCajaAhorro(banco.usuarioActual, id);
                    dataGridView1.Rows.Remove(dataGridView1.Rows[selectedIndex]);
                }
                recargar();
            }
        }
        //Regresar
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.ventanaInicio();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        //Depositar
        private void button4_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            int id = int.Parse(dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString());
            if (selectedIndex > -1)
            {
                banco.depositar(id, double.Parse(textBox1.Text));
                recargar();
            }
        }

        //Retirar
        private void button8_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            int id = int.Parse(dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString());
            if (selectedIndex > -1)
            {
                banco.retirar(id, float.Parse(textBox2.Text));
            }
            recargar();
        }
        //Transferir
        private void button5_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            int idOrigen = int.Parse(dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString());

            int selectedCombo = comboBox1.SelectedIndex;
            int cbuDestino = int.Parse(comboBox1.Items[selectedCombo].ToString());

            if (selectedIndex > -1)
            {
                banco.transferir(idOrigen, cbuDestino, float.Parse(textBox3.Text));
            }
            recargar();
        }
        //Recarga la informacion del programa al seleccionar cada celda
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentRow.Index;
            label1.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
            label5.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
            label7.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
            label9.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();

            comboBox1.Items.Clear();
            foreach (CajaDeAhorro caja in banco.cajas)
            {
                if (label7.Text != caja.cbu.ToString()) comboBox1.Items.Add(caja.cbu);
            }
        }
        //Recarga la informacion del programa luego de realizar una accion
        private void recargar()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            foreach (CajaDeAhorro caja in banco.obtenerCajas())
            {
                dataGridView1.Rows.Add(caja.id, caja.cbu, caja.saldo);
            }


            dataGridView1.CurrentCell = null;
            dataGridView2.CurrentCell = null;
            label1.Text = "Seleccione una caja de ahorro";
            label5.Text = "Seleccione una caja de ahorro";
            label7.Text = "Seleccione una caja de ahorro";
            label9.Text = "Seleccione una caja de ahorro";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void FormCajas_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridView2.Rows.Clear();
            foreach (var mov in banco.obtenerMovimientos())
            {
                int selectedIndex = dataGridView1.CurrentRow.Index;
                if (mov.idCaja == (Int32.Parse(dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString())))
                {
                    dataGridView2.Rows.Add(mov.id, mov.detalle, mov.monto, mov.fecha);
                }
            }
        }
    }
}
