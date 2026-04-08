using PdfSharp.Drawing;
using PdfSharp.Pdf;
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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        public int TipoReporte = 0;

        string conexionString = ConexionBD.ConexionSQL();

        bool UsaFechaRep(int tipo)
        {
            return tipo == 1   // Ventas
                || tipo == 2   // Platos vendidos
                || tipo == 4   // Compras
                || tipo == 5   // Clientes
                || tipo == 6   // Proveedores
                || tipo == 7;  // Empleados
        }

        private void repVentas_CheckedChanged(object sender, EventArgs e)
        {
            if (repVentas.Checked == true)
            {
                TipoReporte = 1;
                repPlatosVendidos.Checked = false;
                repStock.Checked = false;
                repCompras.Checked = false;
                repClientes.Checked = false;
                repProv.Checked = false;
                repEmpleados.Checked = false;
                generarPDFbtn.Enabled = true;

                repVentasPanel.Location = new Point(328, 2);
                repVentasPanel.BringToFront();
                repVentasPanel.Visible = true;

                FechaInicio.Enabled = true;
                FechaFin.Enabled = true;
            }
        }

        private void repPlatosVendidos_CheckedChanged(object sender, EventArgs e)
        {
            if (repPlatosVendidos.Checked == true)
            {
                TipoReporte = 2;
                repVentas.Checked = false;
                repStock.Checked = false;
                repCompras.Checked = false;
                repClientes.Checked = false;
                repProv.Checked = false;
                repEmpleados.Checked = false;
                generarPDFbtn.Enabled = true;

                RepPlatosPanel.Location = new Point(328, 2);
                RepPlatosPanel.BringToFront();
                RepPlatosPanel.Visible = true;

                FechaInicio.Enabled = true;
                FechaFin.Enabled = true;
            }
        }

        private void repStock_CheckedChanged(object sender, EventArgs e)
        {
            if (repStock.Checked == true)
            {
                TipoReporte = 3;
                repPlatosVendidos.Checked = false;
                repVentas.Checked = false;
                repCompras.Checked = false;
                repClientes.Checked = false;
                repProv.Checked = false;
                repEmpleados.Checked = false;
                generarPDFbtn.Enabled = true;

                RepStockPanel.Location = new Point(328, 2);
                RepStockPanel.BringToFront();
                RepStockPanel.Visible = true;

                FechaInicio.Enabled = false;
                FechaFin.Enabled = false;
            }
        }

        private void repCompras_CheckedChanged(object sender, EventArgs e)
        {
            if (repCompras.Checked == true)
            {
                TipoReporte = 4;
                repPlatosVendidos.Checked = false;
                repStock.Checked = false;
                repVentas.Checked = false;
                repClientes.Checked = false;
                repProv.Checked = false;
                repEmpleados.Checked = false;
                generarPDFbtn.Enabled = true;

                RepComprasPanel.Location = new Point(328, 2);
                RepComprasPanel.BringToFront();
                RepComprasPanel.Visible = true;

                FechaInicio.Enabled = true;
                FechaFin.Enabled = true;
            }
        }

        private void repClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (repClientes.Checked == true)
            {
                TipoReporte = 5;
                repPlatosVendidos.Checked = false;
                repStock.Checked = false;
                repCompras.Checked = false;
                repVentas.Checked = false;
                repProv.Checked = false;
                repEmpleados.Checked = false;
                generarPDFbtn.Enabled = true;

                RepClientesPanel.Location = new Point(328, 2);
                RepClientesPanel.BringToFront();
                RepClientesPanel.Visible = true;

                FechaInicio.Enabled = true;
                FechaFin.Enabled = true;
            }
        }

        private void repProv_CheckedChanged(object sender, EventArgs e)
        {
            if (repProv.Checked == true)
            {
                TipoReporte = 6;
                repPlatosVendidos.Checked = false;
                repStock.Checked = false;
                repCompras.Checked = false;
                repClientes.Checked = false;
                repVentas.Checked = false;
                repEmpleados.Checked = false;
                generarPDFbtn.Enabled = true;

                RepProvPanel.Location = new Point(328, 2);
                RepProvPanel.BringToFront();
                RepProvPanel.Visible = true;

                FechaInicio.Enabled = true;
                FechaFin.Enabled = true;
            }
        }

        private void repEmpleados_CheckedChanged(object sender, EventArgs e)
        {
            if (repEmpleados.Checked == true)
            {
                TipoReporte = 7;
                repPlatosVendidos.Checked = false;
                repStock.Checked = false;
                repCompras.Checked = false;
                repClientes.Checked = false;
                repProv.Checked = false;
                repVentas.Checked = false;
                generarPDFbtn.Enabled = true;

                RepEmpleadosPanel.Location = new Point(328, 2);
                RepEmpleadosPanel.BringToFront();
                RepEmpleadosPanel.Visible = true;

                FechaInicio.Enabled = true;
                FechaFin.Enabled = true;
            }
        }

        private (string Sp, string Carpeta, string Titulo) ObtenerConfigReporte()
        {
            switch (TipoReporte)
            {
                case 1: return ("sp_ReporteVentas", "Ventas", "REPORTE DE VENTAS");
                case 2: return ("sp_ReportePlatosMasVendidos", "PlatosVendidos", "PLATOS MÁS VENDIDOS");
                case 3: return ("sp_ReporteStock", "Stock", "STOCK EN ALMACÉN");
                case 4: return ("dbo.sp_ReporteCompras", "Compras", "COMPRAS REALIZADAS");
                case 5: return ("sp_ReporteClientes", "Clientes", "REPORTE DE CLIENTES");
                case 6: return ("sp_ReporteProveedores", "Proveedores", "REPORTE DE PROVEEDORES");
                case 7: return ("sp_ReporteEmpleados", "Empleados", "REPORTE DE EMPLEADOS");
                default: return ("", "", "");
            }
        }

        private void generarPDFbtn_Click(object sender, EventArgs e)
        {
            var config = ObtenerConfigReporte();
            if (string.IsNullOrEmpty(config.Sp)) return;

            using (SqlConnection con = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand(config.Sp, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (UsaFechaRep(TipoReporte))
                {
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date)
                        .Value = FechaInicio.Value.Date;

                    cmd.Parameters.Add("@FechaFin", SqlDbType.Date)
                        .Value = FechaFin.Value.Date;
                }

                con.Open();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para generar el reporte.", "Información");
                    return;
                }

                GenerarReportePDF(dt, config.Titulo, config.Carpeta);
            }
        }

        private void GenerarReportePDF(DataTable dt, string titulo, string carpeta)
        {
            try
            {
                string basePath = @"C:\SistemaArchivos\Reportes\";
                string folderPath = Path.Combine(basePath, carpeta);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fileName = $"{titulo}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string filePath = Path.Combine(folderPath, fileName);

                PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
                document.Info.Title = titulo;

                PdfSharp.Pdf.PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont titleFont = new XFont("Segoe UI", 18, XFontStyleEx.Bold);
                XFont headerFont = new XFont("Segoe UI", 11, XFontStyleEx.Bold);
                XFont textFont = new XFont("Segoe UI", 11, XFontStyleEx.Regular);

                double marginLeft = 30;
                double currentY = 40;
                double lineHeight = 18;

                gfx.DrawString(titulo, titleFont, XBrushes.Black,
                    new XRect(0, currentY, page.Width, 40), XStringFormats.TopCenter);

                currentY += 50;

                gfx.DrawString($"Desde: {FechaInicio.Value:dd/MM/yyyy}  Hasta: {FechaFin.Value:dd/MM/yyyy}",
                    textFont, XBrushes.Black, marginLeft, currentY);

                currentY += 30;

                double x = marginLeft;
                foreach (DataColumn col in dt.Columns)
                {
                    gfx.DrawString(col.ColumnName, headerFont, XBrushes.Black, x, currentY);
                    x += 120;
                }

                currentY += lineHeight;
                gfx.DrawLine(XPens.Black, marginLeft, currentY, page.Width - marginLeft, currentY);
                currentY += 10;

                foreach (DataRow row in dt.Rows)
                {
                    x = marginLeft;

                    foreach (DataColumn col in dt.Columns)
                    {
                        gfx.DrawString(row[col].ToString(), textFont, XBrushes.Black, x, currentY);
                        x += 120;
                    }

                    currentY += lineHeight;

                    if (currentY > page.Height - 40)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        currentY = 40;
                    }
                }

                document.Save(filePath);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
        }

        public int sistemas = 0;

        private void deslizar_Click(object sender, EventArgs e)
        {
            if (sistemas == 0)
            {
                deslizar.Image = Proyecto_restaurante.Properties.Resources.flechaderecharoja;
                opcionesCarpeta.Visible = true;
                sistemas = 1;
            }
            else
            {
                deslizar.Image = Proyecto_restaurante.Properties.Resources.flechaizquierdaroja;
                opcionesCarpeta.Visible = false;
                sistemas = 0;
            }
        }

        private string rutaReportes = @"C:\SistemaArchivos\Reportes";

        private void carpetaReportes_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(rutaReportes))
                    Directory.CreateDirectory(rutaReportes);

                System.Diagnostics.Process.Start("explorer.exe", rutaReportes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la carpeta: " + ex.Message);
            }
        }

        private void eliminarReportes_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(rutaReportes))
                {
                    MessageBox.Show("La carpeta de reportes no existe.");
                    return;
                }

                var archivos = Directory.GetFiles(
                    rutaReportes,
                    "*.pdf",
                    SearchOption.AllDirectories
                );

                if (archivos.Length == 0)
                {
                    MessageBox.Show("No hay reportes PDF para eliminar.");
                    return;
                }

                DialogResult r = MessageBox.Show(
                    $"Se eliminarán {archivos.Length} archivos PDF dentro de las carpetas de reportes.\n\n¿Desea continuar?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (r != DialogResult.Yes)
                    return;

                foreach (var archivo in archivos)
                {
                    File.Delete(archivo);
                }

                MessageBox.Show("Todos los reportes PDF han sido eliminados correctamente.");
                deslizar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar los reportes: " + ex.Message);
            }
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            repVentas.Focus();
        }
    }
}
