using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_restaurante
{
    public partial class ConsProveedor : Form
    {
        public ConsProveedor()
        {
            InitializeComponent();
        }
        public int ProveedorID;
        public int PersonaID;

        private void agregar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            PersonaID = 0;
            ProveedorID = 0;
            nombreprovtxt.Focus();
        }

        private System.Windows.Forms.ToolTip toolTip1;

        private void ConsProveedor_Load(object sender, EventArgs e)
        {
            toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(recargarbtn, "Recargar");
            toolTip1.SetToolTip(informalfiltro, "Proveedor Informal");
            toolTip1.SetToolTip(filtro, "Estado");
            toolTip1.SetToolTip(eliminarbtn, "Limpiar filtros");

            string conexionString = ConexionBD.ConexionSQL();

            try
            {
                string consultaEmpleados = @"
                SELECT 
                    pr.IdProveedor,
                    p.NombreCompleto,
                    pd.Numero AS Cedula
                FROM Proveedor pr
                LEFT JOIN Persona p ON pr.IdPersona = p.IdPersona
                LEFT JOIN PersonaDocumento pd ON p.IdPersona = pd.IdPersona
                WHERE pr.Activo = 1 AND p.Activo = 1;";

                using (SqlDataAdapter adaptador = new SqlDataAdapter(consultaEmpleados, conexionString))
                {
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    provdt.DataSource = dt;
                }

                string consultaUltimoID = "SELECT ISNULL(MAX(IdEmpleado) + 1, 0) FROM Empleado";

                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(consultaUltimoID, conexion))
                    {
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null && resultado != DBNull.Value)
                        {
                            idprovtxt.Text = resultado.ToString();
                        }
                        else
                        {
                            idprovtxt.Text = "?";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los datos: {ex.Message}");
            }

            string consultaId = "SELECT ISNULL(MAX(IdProveedor), 0) + 1 FROM Proveedor";

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(consultaId, con))
                {
                    idprovtxt.Text = cmd.ExecuteScalar()?.ToString() ?? "1";
                }
            }

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();

                string consultaTipoDoc = "SELECT IdTipoDocumento, Nombre FROM TipoDocumento";

                SqlDataAdapter da = new SqlDataAdapter(consultaTipoDoc, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                tipodoccmbx.DataSource = null;
                tipodoccmbx.DataSource = dt;
                tipodoccmbx.DisplayMember = "Nombre";
                tipodoccmbx.ValueMember = "IdTipoDocumento";

                if (dt.Rows.Count > 0)
                    tipodoccmbx.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void RestablecerFormulario()
        {
            imagenprov.Image = Proyecto_restaurante.Properties.Resources.perfilcliente;
            nombreprovtxt.Text = "";
            identtxt.Text = "";

            ProveedorID = 0;
            PersonaID = 0;

            estadochk.Checked = true;
            nombreprovtxt.Focus();
        }

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            Regex letrasRegex = new Regex(@"^[a-zA-Z\s]+$");
            Regex numerosRegex = new Regex(@"^[\d-]+$");

            if (string.IsNullOrWhiteSpace(nombreprovtxt.Text) || string.IsNullOrWhiteSpace(identtxt.Text))
            {
                MessageBox.Show("No debe dejar campos vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!letrasRegex.IsMatch(nombreprovtxt.Text))
            {
                MessageBox.Show("El nombre solo debe contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                SqlTransaction trans = conexion.BeginTransaction();

                try
                {
                    if (ProveedorID == 0)
                    {
                        string nuevaPersona = @"
                        INSERT INTO Persona (Nombre, Email, Activo, CreadoEn)
                        VALUES (@Nombre, @Email, @Activo, GETDATE());
                        SELECT SCOPE_IDENTITY();";

                        using (SqlCommand insertarPersona = new SqlCommand(nuevaPersona, conexion, trans))
                        {
                            insertarPersona.Parameters.AddWithValue("@Nombre", nombreprovtxt.Text);
                            insertarPersona.Parameters.AddWithValue("@Email", correotxt.Text);
                            insertarPersona.Parameters.AddWithValue("@Activo", estadochk.Checked ? 1 : 0);

                            PersonaID = Convert.ToInt32(insertarPersona.ExecuteScalar());
                        }

                        string nuevoProveedor = @"
                        INSERT INTO Proveedor (IdPersona, IdTipoDoc, Informal)
                        VALUES (@IdPersona, @IdTipoDoc, @Informal)";

                        using (SqlCommand insertarProveedor = new SqlCommand(nuevoProveedor, conexion, trans))
                        {
                            insertarProveedor.Parameters.AddWithValue("@IdPersona", PersonaID);
                            insertarProveedor.Parameters.AddWithValue("@IdTipoDoc", Convert.ToInt32(tipodoccmbx.SelectedValue));
                            insertarProveedor.Parameters.AddWithValue("@Informal", informalchk.Checked ? 1 : 0);

                            insertarProveedor.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("Proveedor registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RestablecerFormulario();
                        ConsProveedor_Load(sender, e);
                    }
                    else
                    {
                        string actualizarPersona = @"
                        UPDATE Persona 
                        SET Nombre = @Nombre, Email = @Email, Activo = @Activo
                        WHERE IdPersona = @IdPersona";

                        using (SqlCommand actualizarCommand = new SqlCommand(actualizarPersona, conexion, trans))
                        {
                            actualizarCommand.Parameters.AddWithValue("@IdPersona", PersonaID);
                            actualizarCommand.Parameters.AddWithValue("@Nombre", nombreprovtxt.Text);
                            actualizarCommand.Parameters.AddWithValue("@Email", correotxt.Text);
                            actualizarCommand.Parameters.AddWithValue("@Activo", estadochk.Checked ? 1 : 0);
                            actualizarCommand.ExecuteNonQuery();
                        }

                        string actualizarProveedor = @"
                        UPDATE Proveedor
                        SET IdTipoDoc = @IdTipoDoc, Informal = @Informal
                        WHERE IdProveedor = @IdProveedor";

                        using (SqlCommand actualizarProveedorCmd = new SqlCommand(actualizarProveedor, conexion, trans))
                        {
                            actualizarProveedorCmd.Parameters.AddWithValue("@IdProveedor", ProveedorID);
                            actualizarProveedorCmd.Parameters.AddWithValue("@IdTipoDoc", Convert.ToInt32(tipodoccmbx.SelectedValue));
                            actualizarProveedorCmd.Parameters.AddWithValue("@Informal", informalchk.Checked ? 1 : 0);
                            actualizarProveedorCmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("Proveedor actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RestablecerFormulario();
                        ConsProveedor_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void seleccionimagenbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Seleccionar imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string codigoCliente = idprovtxt.Text;
                    string destinoCarpeta = @"C:\SistemaArchivos\Proveedor";
                    string extension = Path.GetExtension(openFileDialog.FileName);
                    string nuevaRuta = Path.Combine(destinoCarpeta, codigoCliente + extension);

                    try
                    {
                        imagenprov.Image = null;

                        if (File.Exists(nuevaRuta))
                        {
                            string tempFileName = Path.Combine(destinoCarpeta, Path.GetRandomFileName());
                            File.Move(nuevaRuta, tempFileName);

                            File.Delete(tempFileName);
                        }

                        File.Copy(openFileDialog.FileName, nuevaRuta, true);

                        imagenprov.Image = Image.FromFile(nuevaRuta);

                        MessageBox.Show("Imagen asociada al proveedor con éxito.");
                        identtxt.Enabled = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al copiar la imagen: " + ex.Message);
                    }
                }
            }
        }

        private void identtxt_TextChanged(object sender, EventArgs e)
        {
            string posicion = identtxt.Text; posicion = posicion.Replace("-", "");

            if (posicion.Length > 11)
            {
                posicion = posicion.Substring(0, 11);
            }

            if (posicion.Length > 3)
            {
                posicion = posicion.Insert(3, "-");
            }
            if (posicion.Length > 11)
            {
                posicion = posicion.Insert(11, "-");
            }

            identtxt.Text = posicion; identtxt.SelectionStart = identtxt.Text.Length;
        }

        private void provdt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = provdt.Rows[e.RowIndex];
                int idProveedor = Convert.ToInt32(fila.Cells["IdProveedor"].Value);

                string rutaImagenes = @"C:\SistemaArchivos\Proveedor\";
                string rutaImagenCliente = Path.Combine(rutaImagenes, idProveedor + ".jpg");

                if (File.Exists(rutaImagenCliente))
                {
                    clienteimg.Image = Image.FromFile(rutaImagenCliente);
                }
                else
                {
                    clienteimg.Image = Proyecto_restaurante.Properties.Resources.perfilcliente;
                }
            }
        }
    }
}
