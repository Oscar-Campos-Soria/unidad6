using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace unidad6
{
    public partial class Form1 : Form
    {

        private string filePath = "datos.bin";

        public Form1()
        {
            InitializeComponent();
        }

       
       
        private void btn_Click(object sender, EventArgs e)
        {

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("No se encontró el archivo de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int entero;
                double decimalNumber;

                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    entero = reader.ReadInt32();
                    decimalNumber = reader.ReadDouble();
                }

                lblEntero.Text = "Entero: " + entero.ToString();
                lblDecimal.Text = "Decimal: " + decimalNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            {
                try
                {
                    int entero;
                    double decimalNumber;

                    if (!int.TryParse(txtEntero.Text, out entero) || !double.TryParse(txtDecimal.Text, out decimalNumber))
                    {
                        MessageBox.Show("Por favor ingrese un entero y un número decimal válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                    {
                        writer.Write(entero);
                        writer.Write(decimalNumber);
                    }

                    MessageBox.Show("Datos guardados correctamente en el archivo binario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}


