using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_restaurante
{
    public partial class TelevisionSistema : Form
    {
        public TelevisionSistema()
        {
            InitializeComponent();
        }

        System.Windows.Forms.Timer Recargar;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Recargar_Tick(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        private void TelevisionSistema_Load(object sender, EventArgs e)
        {
            Recargar = new System.Windows.Forms.Timer();
            Recargar.Interval = 15000;
            Recargar.Tick += Recargar_Tick;
            Recargar.Start();

            CargarOrdenes();
        }

        private void CargarOrdenes()
        {
            panelOrdenes.Controls.Clear();

            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();

                string query = @"
                SELECT CM.IdComanda,
                       CM.IdPedido,
                       CM.IdProducto,
                       PV.Nombre,
                       CM.Cantidad,
	                   MS.Numero as MesaNumero,
                       CM.Cuenta,
                       CM.Estado
                FROM Comanda CM
                INNER JOIN ProductoVenta PV ON CM.IdProducto = PV.IdProducto
                INNER JOIN Mesa MS ON CM.IdMesa = MS.IdMesa
                WHERE CM.Estado = 'Cocina'
                ORDER BY CM.IdPedido, CM.IdComanda";

                SqlCommand cmd = new SqlCommand(query, conexion);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int idPedido = Convert.ToInt32(dr["IdPedido"]);
                        int cuenta = Convert.ToInt32(dr["Cuenta"]);
                        int idProducto = Convert.ToInt32(dr["IdProducto"]);
                        string nombre = dr["Nombre"].ToString();
                        decimal cantidad = Convert.ToDecimal(dr["Cantidad"]);
                        int numero = Convert.ToInt32(dr["MesaNumero"]);

                        Image img = CargarImagen(idProducto);

                        panelOrdenes.Controls.Add(
                            PanelComanda(idPedido, cuenta, nombre, numero, (int)cantidad, img)
                        );
                    }
                }
            }
        }

        private Panel PanelComanda(int idPedido, int cuenta, string nombre, int numero, int cantidad, Image imagen)
        {
            Panel ficha = new Panel();
            ficha.Width = 200;
            ficha.Height = 270;
            ficha.BackColor = Color.White;
            ficha.Margin = new Padding(15);
            ficha.BorderStyle = BorderStyle.FixedSingle;

            Label lblPedido = new Label();
            lblPedido.Text = $"Orden: {idPedido}, Mesa: {numero},\nCuenta: {cuenta}";
            lblPedido.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPedido.AutoSize = true;
            lblPedido.Location = new Point(5, 5);

            PictureBox pic = new PictureBox();
            pic.Size = new Size(130, 100);
            pic.Location = new Point(20, 30);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Image = imagen;

            Label lblNombre = new Label();
            lblNombre.Text = nombre.ToUpper();
            lblNombre.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblNombre.AutoSize = false;
            lblNombre.TextAlign = ContentAlignment.MiddleCenter;
            lblNombre.Width = 170;
            lblNombre.Location = new Point(0, 140);

            Label lblCantidad = new Label();
            lblCantidad.Text = $"CANTIDAD: {cantidad}";
            lblCantidad.Font = new Font("Segoe UI", 14);
            lblCantidad.AutoSize = false;
            lblCantidad.Width = 170;
            lblCantidad.TextAlign = ContentAlignment.MiddleCenter;
            lblCantidad.Location = new Point(0, 170);

            ficha.Controls.Add(lblPedido);
            ficha.Controls.Add(pic);
            ficha.Controls.Add(lblNombre);
            ficha.Controls.Add(lblCantidad);

            return ficha;
        }

        private Image CargarImagen(int idProducto)
        {
            string basePath = @"C:\SistemaArchivos\Productos\";
            string[] extensiones = { ".jpg", ".png", ".jpeg" };

            foreach (string ext in extensiones)
            {
                string ruta = Path.Combine(basePath, idProducto + ext);
                if (File.Exists(ruta))
                {
                    try
                    {
                        using (var temp = new Bitmap(ruta))
                        {
                            return new Bitmap(temp);
                        }
                    }
                    catch { }
                }
            }

            return null;
        }

    }
}
