using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Fonts;
using System.IO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Proyecto_restaurante.menu;

namespace Proyecto_restaurante
{
    public partial class Compras : Form
    {

        private readonly string conexionString = ConexionBD.ConexionSQL();


        private decimal subtotalAcumulado = 0;
        private decimal impuestosAcumulados = 0;
        private decimal totalAcumulado = 0;
        private int cantidadTotalUnidades = 0;


        private int productoSeleccionadoId = 0;
        private string unidadSeleccionada = "";
        private decimal itbisSeleccionadoPorciento = 0; // 0 = exento, 18 = 18%

        // Responsable que viene de la pantalla de login / menu principal
        public string responsableCompra;
        private int sistemas = 0;
        private string rutaCompras = @"C:\SistemaArchivos\Compras";

        public Compras()
        {
            InitializeComponent();


            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            ConfigurarGridDetalle();
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            FechaCompra.Value = SistemaFecha.FechaActual;

            LimpiarFormulario();

            if (!string.IsNullOrWhiteSpace(responsableCompra))
            {
                ResponsableCompratxt.Text = responsableCompra;
            }

            // IdEmpleadoResponsable fijo = 1 si esta vacio
            /* if (string.IsNullOrWhiteSpace(IdRespoCompratxt.Text))
                 IdRespoCompratxt.Text = "1";
            */
            IdRespoCompratxt.Clear();
            ResponsableCompratxt.Clear();
            IdRespoCompratxt.ReadOnly = true;
            ResponsableCompratxt.ReadOnly = true;

            ProvInformalChk.Checked = false;
            ActualizarUIInformal();
        }

        private void buscarprodbtn_Click(object sender, EventArgs e)
        {
            MostrarPanelIngredientes();
            CargarProductosEnPanel("");
        }

        private void txtbusquedapanelprod_TextChanged(object sender, EventArgs e)
        {
            string texto = txtbusquedapanelprod.Text.Trim();
            CargarProductosEnPanel(texto);
        }
        private void recargaringredbtn_Click(object sender, EventArgs e)
        {
            txtbusquedapanelprod.Clear();
            CargarProductosEnPanel("");
        }

        private void saliringredbtn_Click(object sender, EventArgs e)
        {
            OcultarPanelIngredientes();
        }

        private void tablaingrediente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = tablaingrediente.Rows[e.RowIndex];


            productoSeleccionadoId = Convert.ToInt32(row.Cells["IdProducto"].Value);
            string nombre = row.Cells["Nombre"].Value.ToString();
            decimal precioCompra = Convert.ToDecimal(row.Cells["PrecioCompra"].Value);

            unidadSeleccionada = row.Cells["Unidad"].Value.ToString();

            object itbisObj = row.Cells["Itbis"].Value;
            itbisSeleccionadoPorciento = 0;
            if (itbisObj != null && itbisObj != DBNull.Value)
            {
                itbisSeleccionadoPorciento = Convert.ToDecimal(itbisObj);  // ej. 0 o 18
            }


            IdIngredientetxt.Text = productoSeleccionadoId.ToString();
            txtnombre.Text = nombre;
            txtpreciocompra.Text = precioCompra.ToString("0.00");
            itbisingredtxt.Text = itbisSeleccionadoPorciento.ToString("0.##");

            OcultarPanelIngredientes();

            NumericUpCantidad.Value = NumericUpCantidad.Minimum;
            AgregarBtn.Enabled = true;
        }

        private void AgregarBtn_Click(object sender, EventArgs e)
        {
            AgregarLineaDetalle();
        }

        private void ComprarBtn_Click(object sender, EventArgs e)
        {
            GuardarCompraPendiente();
        }

        private void NuevoBtn_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            compraEnEdicionId = null;
            ActualizarUIInformal();


            if (!string.IsNullOrWhiteSpace(responsableCompra))
            {
                ResponsableCompratxt.Text = responsableCompra;
            }

            if (string.IsNullOrWhiteSpace(IdRespoCompratxt.Text))
                IdRespoCompratxt.Text = "1";

            IdRespoCompratxt.ReadOnly = true;
            ResponsableCompratxt.ReadOnly = true;
        }

        private void BusquedaProvBtn_Click(object sender, EventArgs e)
        {
            MostrarPanelProveedores();
            CargarProveedoresEnPanel("");
        }

        private void txtprovbusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtprovbusqueda.Text.Trim();
            CargarProveedoresEnPanel(filtro);
        }

        private void recargarprovbtn_Click(object sender, EventArgs e)
        {
            txtprovbusqueda.Clear();
            CargarProveedoresEnPanel("");
        }

        private void checkactivoprov_CheckedChanged(object sender, EventArgs e)
        {
            CargarProveedoresEnPanel(txtprovbusqueda.Text.Trim());
        }

        private void checkprovinformal_CheckedChanged(object sender, EventArgs e)
        {
            CargarProveedoresEnPanel(txtprovbusqueda.Text.Trim());
        }

        private void tablaprov_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = tablaprov.Rows[e.RowIndex];

            int idPersonaProveedor = Convert.ToInt32(row.Cells["IdPersona"].Value);
            string nombreCompleto = row.Cells["NombreCompleto"].Value.ToString();
            string telefono = row.Cells["Telefono"].Value?.ToString();
            string direccion = row.Cells["Direccion"].Value?.ToString();
            bool informal = Convert.ToBoolean(row.Cells["Informal"].Value);

            idproveedortxt.Text = idPersonaProveedor.ToString();
            txtnombrecompleto.Text = nombreCompleto;

            TelefProvTxt.Text = string.IsNullOrWhiteSpace(telefono) ? "No definido" : telefono;
            DireccionProvTxt.Text = string.IsNullOrWhiteSpace(direccion) ? "No definido" : direccion;

            TelefProvTxt.ForeColor = string.IsNullOrWhiteSpace(telefono) ? Color.DimGray : Color.White;
            DireccionProvTxt.ForeColor = string.IsNullOrWhiteSpace(direccion) ? Color.DimGray : Color.White;


            ProvInformalChk.Checked = informal;
            ActualizarUIInformal();

            OcultarPanelProveedores();
        }

        private void salirprovbtn_Click(object sender, EventArgs e)
        {
            OcultarPanelProveedores();
        }

        private void ConfigurarGridDetalle()
        {
            detallecompra.Columns.Clear();
            detallecompra.AutoGenerateColumns = false;
            detallecompra.AllowUserToAddRows = false;

            detallecompra.ReadOnly = true;
            detallecompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            detallecompra.MultiSelect = false;

            var colId = new DataGridViewTextBoxColumn
            {
                Name = "IdProducto",
                HeaderText = "ID",
                Width = 60
            };
            detallecompra.Columns.Add(colId);

            var colNombre = new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Producto",
                Width = 180
            };
            detallecompra.Columns.Add(colNombre);

            var colUnidad = new DataGridViewTextBoxColumn
            {
                Name = "Unidad",
                HeaderText = "Unidad",
                Width = 80
            };
            detallecompra.Columns.Add(colUnidad);

            var colCant = new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                Width = 80
            };
            detallecompra.Columns.Add(colCant);

            var colCosto = new DataGridViewTextBoxColumn
            {
                Name = "CostoUnitario",
                HeaderText = "Costo",
                Width = 90
            };
            detallecompra.Columns.Add(colCosto);

            var colSub = new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                Width = 100
            };
            detallecompra.Columns.Add(colSub);

            var colItbis = new DataGridViewTextBoxColumn
            {
                Name = "ItbisPorciento",
                HeaderText = "ITBIS %",
                Visible = false
            };
            detallecompra.Columns.Add(colItbis);
        }

        private void MostrarPanelIngredientes()
        {
            PanelIngredientes.Location = new Point(0, 0);
            PanelIngredientes.Visible = true;
        }

        private void OcultarPanelIngredientes()
        {
            PanelIngredientes.Visible = false;
            PanelIngredientes.Location = new Point(4, 444);
        }

        private void MostrarPanelProveedores()
        {
            PanelProv.Location = new Point(0, 0);
            PanelProv.Visible = true;
        }

        private void OcultarPanelProveedores()
        {
            PanelProv.Visible = false;
            PanelProv.Location = new Point(4, 444);
        }


        private void LimpiarFormulario()
        {

            txtidcompra.Clear();
            compraEnEdicionId = null;
            idproveedortxt.Clear();
            txtnombrecompleto.Clear();
            TelefProvTxt.Clear();
            DireccionProvTxt.Clear();

            FechaCompra.Value = DateTime.Now;

            productoSeleccionadoId = 0;
            unidadSeleccionada = "";
            itbisSeleccionadoPorciento = 0;

            IdIngredientetxt.Clear();
            txtnombre.Clear();
            txtpreciocompra.Clear();
            itbisingredtxt.Clear();

            NumericUpCantidad.Value = NumericUpCantidad.Minimum;
            detallecompra.Rows.Clear();

            subtotalAcumulado = 0;
            impuestosAcumulados = 0;
            totalAcumulado = 0;
            cantidadTotalUnidades = 0;

            CantArticuloLabel.Text = "0";
            SubtotalLabel.Text = "0.00";
            ItbisLabel.Text = "0.00";
            TotalLabel.Text = "0.00";

            ComprarBtn.Enabled = false;
            AgregarBtn.Enabled = false;

            ConfigurarModoCabecera(false);

            ProvInformalChk.Checked = false;
            ActualizarUIInformal();

            CargarSiguienteNumeroCompra();
        }


        private void RecalcularTotales()
        {
            subtotalAcumulado = 0;
            impuestosAcumulados = 0;
            totalAcumulado = 0;
            cantidadTotalUnidades = 0;

            foreach (DataGridViewRow row in detallecompra.Rows)
            {
                if (row.IsNewRow) continue;

                decimal cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                decimal costoUnit = Convert.ToDecimal(row.Cells["CostoUnitario"].Value);
                decimal subtotalLinea = cantidad * costoUnit;

                row.Cells["Subtotal"].Value = subtotalLinea;

                subtotalAcumulado += subtotalLinea;
                cantidadTotalUnidades += (int)cantidad;

                decimal itbisLineaPorc = 0;
                if (row.Cells["ItbisPorciento"].Value != null &&
                    row.Cells["ItbisPorciento"].Value != DBNull.Value)
                {
                    itbisLineaPorc = Convert.ToDecimal(row.Cells["ItbisPorciento"].Value);
                }

                if (itbisLineaPorc > 0)
                {
                    decimal impuestoLinea = subtotalLinea * (itbisLineaPorc / 100m);
                    impuestosAcumulados += impuestoLinea;
                }
            }

            totalAcumulado = subtotalAcumulado + impuestosAcumulados;

            CantArticuloLabel.Text = cantidadTotalUnidades.ToString();
            SubtotalLabel.Text = subtotalAcumulado.ToString("F2");
            ItbisLabel.Text = impuestosAcumulados.ToString("F2");
            TotalLabel.Text = totalAcumulado.ToString("F2");

            ComprarBtn.Enabled = detallecompra.Rows.Count > 0;
        }


        private void CargarSiguienteNumeroCompra()
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                string sql = "SELECT ISNULL(MAX(IdCompra), 0) + 1 FROM Compra;";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    object resultado = cmd.ExecuteScalar();
                    int nuevoId = Convert.ToInt32(resultado);
                    txtidcompra.Text = nuevoId.ToString();
                }
            }
        }

        private void CargarProductosEnPanel(string filtro)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();

                string sql = @"
                    SELECT 
                    p.IdProducto,
                    p.Nombre,
                    ISNULL(p.PrecioCompra, 0) AS PrecioCompra,
                    ISNULL(p.Itbis, 0) AS Itbis,
                    u.Nombre AS Unidad,
                    t.Ingrediente,
                    t.Bebida
                    FROM ProductoVenta p
                    INNER JOIN ProductoTipo t   ON p.IdProductoTipo = t.IdProductoTipo
                    INNER JOIN UnidadMedida u   ON p.IdUnidadMedida = u.IdUnidadMedida
                    WHERE (t.Ingrediente = 1 OR t.Bebida = 1)
                    AND (@soloActivos = 0 OR p.Activo = 1)
                    AND (@f = '' OR p.Nombre LIKE '%' + @f + '%')
                    ORDER BY p.Nombre;";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@f", filtro ?? "");
                    da.SelectCommand.Parameters.AddWithValue("@soloActivos",
                        checkingredactivo.Checked ? 1 : 0);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    tablaingrediente.DataSource = dt;

                    if (tablaingrediente.Columns.Contains("IdProducto"))
                        tablaingrediente.Columns["IdProducto"].HeaderText = "ID";
                    if (tablaingrediente.Columns.Contains("Nombre"))
                        tablaingrediente.Columns["Nombre"].HeaderText = "Producto";
                    if (tablaingrediente.Columns.Contains("PrecioCompra"))
                        tablaingrediente.Columns["PrecioCompra"].HeaderText = "Precio compra";
                    if (tablaingrediente.Columns.Contains("Unidad"))
                        tablaingrediente.Columns["Unidad"].HeaderText = "Unidad";
                    if (tablaingrediente.Columns.Contains("Itbis"))
                        tablaingrediente.Columns["Itbis"].HeaderText = "ITBIS %";

                    /* Opcional: esconder estas columnas, solo son para filtro interno
                    if (tablaingrediente.Columns.Contains("Ingrediente"))
                        tablaingrediente.Columns["Ingrediente"].Visible = false;
                    if (tablaingrediente.Columns.Contains("Bebida"))
                        tablaingrediente.Columns["Bebida"].Visible = false;
                    */
                }
            }
        }


        private void CargarProveedoresEnPanel(string filtro)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();

                bool soloActivos = checkactivoprov.Checked;
                bool soloInformales = checkprovinformal.Checked;

                string sql = @"
                        SELECT 
                        p.IdProveedor,
                        per.IdPersona,
                        per.NombreCompleto,
                        ISNULL(t.Numero, '') AS Telefono,
                        ISNULL(d.Direccion, '') AS Direccion,
                        p.Informal,
                        p.Activo
                        FROM Proveedor p
                        INNER JOIN Persona per ON p.IdPersona = per.IdPersona
                        LEFT JOIN PersonaTelefono t 
                        ON t.IdPersona = per.IdPersona AND t.EsPrincipal = 1
                        LEFT JOIN PersonaDireccion d 
                        ON d.IdPersona = per.IdPersona AND d.EsPrincipal = 1
                        WHERE (@f = '' OR per.NombreCompleto LIKE '%' + @f + '%' OR t.Numero LIKE '%' + @f + '%')
                        AND (@soloActivos = 0 OR p.Activo = 1)
                        AND (@soloInformales = 0 OR p.Informal = 1)
                        ORDER BY per.NombreCompleto;";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@f", filtro ?? "");
                    da.SelectCommand.Parameters.AddWithValue("@soloActivos", soloActivos ? 1 : 0);
                    da.SelectCommand.Parameters.AddWithValue("@soloInformales", soloInformales ? 1 : 0);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    tablaprov.DataSource = dt;

                    if (tablaprov.Columns.Contains("IdProveedor"))
                        tablaprov.Columns["IdProveedor"].HeaderText = "Id Prov.";
                    if (tablaprov.Columns.Contains("IdPersona"))
                        tablaprov.Columns["IdPersona"].HeaderText = "Id Persona";
                    if (tablaprov.Columns.Contains("NombreCompleto"))
                        tablaprov.Columns["NombreCompleto"].HeaderText = "Nombre";
                    if (tablaprov.Columns.Contains("Telefono"))
                        tablaprov.Columns["Telefono"].HeaderText = "Teléfono";
                    if (tablaprov.Columns.Contains("Direccion"))
                        tablaprov.Columns["Direccion"].HeaderText = "Dirección";
                }
            }
        }

        private void AgregarLineaDetalle()
        {
            if (productoSeleccionadoId <= 0)
            {
                MessageBox.Show("Seleccione un Producto primero.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                MessageBox.Show("El nombre del Producto está vacío.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtpreciocompra.Text))
            {
                MessageBox.Show("Indique el costo de compra.");
                return;
            }

            if (!decimal.TryParse(txtpreciocompra.Text.Trim(), out decimal costoUnit) || costoUnit < 0)
            {
                MessageBox.Show("Costo inválido.");
                return;
            }

            decimal cantidad = NumericUpCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.");
                return;
            }


            int rowIndex = detallecompra.Rows.Add();
            DataGridViewRow rowDetalle = detallecompra.Rows[rowIndex];

            rowDetalle.Cells["IdProducto"].Value = productoSeleccionadoId;
            rowDetalle.Cells["Nombre"].Value = txtnombre.Text.Trim();
            rowDetalle.Cells["Unidad"].Value = unidadSeleccionada;
            rowDetalle.Cells["Cantidad"].Value = cantidad;
            rowDetalle.Cells["CostoUnitario"].Value = costoUnit;
            rowDetalle.Cells["ItbisPorciento"].Value = itbisSeleccionadoPorciento;


            RecalcularTotales();


            productoSeleccionadoId = 0;
            unidadSeleccionada = "";
            itbisSeleccionadoPorciento = 0;

            IdIngredientetxt.Clear();
            txtnombre.Clear();
            txtpreciocompra.Clear();
            itbisingredtxt.Clear();
            NumericUpCantidad.Value = NumericUpCantidad.Minimum;
            AgregarBtn.Enabled = false;
        }

        private void GuardarCompraPendiente()
        {
            if (detallecompra.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en la compra.");
                return;
            }

            if (!int.TryParse(idproveedortxt.Text, out int idProveedor))
            {
                MessageBox.Show("Seleccione un proveedor válido antes de guardar la compra.");
                return;
            }

            int? idEmpleadoResponsable = null;

            if (int.TryParse(IdRespoCompratxt.Text, out int idEmp) && idEmp > 0)
            {
                idEmpleadoResponsable = idEmp;
            }

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    int idCompraGenerada;

                    if (compraEnEdicionId.HasValue)
                    {
                        string sqlUpdate = @"
                        UPDATE Compra
                        SET Fecha = @Fecha,
                        IdProveedorPersona = @IdProveedor,
                        Subtotal = @Subtotal,
                        Impuestos = @Impuestos,
                        Total = @Total
                        WHERE IdCompra = @IdCompra
                        AND Estado = 'Pendiente';";

                        using (SqlCommand cmdUp = new SqlCommand(sqlUpdate, con, tran))
                        {

                            cmdUp.Parameters.AddWithValue("@Fecha", FechaCompra.Value);

                            cmdUp.Parameters.AddWithValue("@IdProveedor", idProveedor);
                            cmdUp.Parameters.AddWithValue("@Subtotal", subtotalAcumulado);
                            cmdUp.Parameters.AddWithValue("@Impuestos", impuestosAcumulados);
                            cmdUp.Parameters.AddWithValue("@Total", totalAcumulado);
                            cmdUp.Parameters.AddWithValue("@IdCompra", compraEnEdicionId.Value);

                            int filasCab = cmdUp.ExecuteNonQuery();
                            if (filasCab == 0)
                            {
                                tran.Rollback();
                                MessageBox.Show("No se pudo actualizar la compra. Verifique que siga en estado Pendiente.");
                                return;
                            }
                        }

                        string sqlBorrarDet = "DELETE FROM DetalleCompra WHERE IdCompra = @IdCompra;";
                        using (SqlCommand cmdDel = new SqlCommand(sqlBorrarDet, con, tran))
                        {
                            cmdDel.Parameters.AddWithValue("@IdCompra", compraEnEdicionId.Value);
                            cmdDel.ExecuteNonQuery();
                        }

                        idCompraGenerada = compraEnEdicionId.Value;
                    }
                    else
                    {
                        string sqlCompra = @"
                            INSERT INTO Compra
                            (Fecha, FechaRecepcion, IdProveedorPersona, Subtotal, Impuestos, Total, Estado, IdEmpleadoResponsable)
                            VALUES (@Fecha, NULL, @IdProveedor, @Subtotal, @Impuestos, @Total, 'Pendiente', @IdEmpleado);
                            SELECT SCOPE_IDENTITY();";

                        using (SqlCommand cmdCompra = new SqlCommand(sqlCompra, con, tran))
                        {

                            cmdCompra.Parameters.AddWithValue("@Fecha", FechaCompra.Value);

                            cmdCompra.Parameters.AddWithValue("@IdProveedor", idProveedor);
                            cmdCompra.Parameters.AddWithValue("@Subtotal", subtotalAcumulado);
                            cmdCompra.Parameters.AddWithValue("@Impuestos", impuestosAcumulados);
                            cmdCompra.Parameters.AddWithValue("@Total", totalAcumulado);

                            if (idEmpleadoResponsable.HasValue)
                                cmdCompra.Parameters.AddWithValue("@IdEmpleado", idEmpleadoResponsable.Value);
                            else
                                cmdCompra.Parameters.AddWithValue("@IdEmpleado", DBNull.Value);

                            object result = cmdCompra.ExecuteScalar();
                            idCompraGenerada = Convert.ToInt32(result);
                        }
                    }

                    string sqlDetalle = @"
                        INSERT INTO DetalleCompra
                        (IdCompra, IdProducto, Cantidad, CostoUnitario)
                        VALUES (@IdCompra, @IdProducto, @Cantidad, @CostoUnitario);";

                    foreach (DataGridViewRow row in detallecompra.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int idProd = Convert.ToInt32(row.Cells["IdProducto"].Value);
                        decimal cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                        decimal costoUnit = Convert.ToDecimal(row.Cells["CostoUnitario"].Value);

                        using (SqlCommand cmdDet = new SqlCommand(sqlDetalle, con, tran))
                        {
                            cmdDet.Parameters.AddWithValue("@IdCompra", idCompraGenerada);
                            cmdDet.Parameters.AddWithValue("@IdProducto", idProd);
                            cmdDet.Parameters.AddWithValue("@Cantidad", cantidad);
                            cmdDet.Parameters.AddWithValue("@CostoUnitario", costoUnit);

                            cmdDet.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();

                    if (compraEnEdicionId.HasValue)
                        MessageBox.Show("Compra pendiente actualizada correctamente.");
                    else
                        MessageBox.Show("Compra registrada como Pendiente.");

                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error al guardar la compra: " + ex.Message);
                }
            }
        }


        private void checkingredactivo_CheckedChanged(object sender, EventArgs e)
        {
            CargarProductosEnPanel(txtbusquedapanelprod.Text.Trim());
        }

        private void eliminarbtn_Click(object sender, EventArgs e)
        {
            txtbusquedapanelprod.Clear();
            checkingredactivo.Checked = true;
            CargarProductosEnPanel("");
        }

        private void eliminarbtn2_Click(object sender, EventArgs e)
        {
            txtprovbusqueda.Clear();
            checkactivoprov.Checked = true;
            checkprovinformal.Checked = false;
            CargarProveedoresEnPanel("");
        }

        private void CargarHistorialCompras()
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();

                string sql = @"
                SELECT 
                c.IdCompra,
                c.Fecha,
                p.NombreCompleto AS Proveedor,
                c.Estado,
                c.Subtotal,
                c.Impuestos,
                c.Total
                FROM Compra c
                INNER JOIN Persona p ON c.IdProveedorPersona = p.IdPersona
                WHERE c.Fecha >= @desde
                AND c.Fecha < DATEADD(DAY, 1, @hasta)";

                if (!TodosChk.Checked)
                {
                    if (PendienteChk.Checked)
                        sql += " AND c.Estado = 'Pendiente'";
                    else if (RecibidaChk.Checked)
                        sql += " AND c.Estado = 'Recibida'";
                    else if (AnuladoChk.Checked)
                        sql += " AND c.Estado = 'Anulada'";
                }

                if (!string.IsNullOrWhiteSpace(BusquedaCompraTxt.Text))
                {
                    sql += @"
                    AND (p.NombreCompleto LIKE '%' + @buscar + '%' 
                    OR CAST(c.IdCompra AS varchar(10)) LIKE '%' + @buscar + '%')";
                }

                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@desde", fecini.Value.Date);
                    da.SelectCommand.Parameters.AddWithValue("@hasta", fecfin.Value.Date);
                    da.SelectCommand.Parameters.AddWithValue("@buscar", BusquedaCompraTxt.Text.Trim());

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    TablaDatosCompra.DataSource = dt;
                }
            }

            ConfigurarGridHistorial();
        }

        private void ConfigurarGridHistorial()
        {
            if (TablaDatosCompra.Columns.Contains("IdCompra"))
                TablaDatosCompra.Columns["IdCompra"].HeaderText = "N°";

            if (TablaDatosCompra.Columns.Contains("Fecha"))
                TablaDatosCompra.Columns["Fecha"].HeaderText = "Fecha";

            if (TablaDatosCompra.Columns.Contains("Proveedor"))
                TablaDatosCompra.Columns["Proveedor"].HeaderText = "Proveedor";

            if (TablaDatosCompra.Columns.Contains("Estado"))
                TablaDatosCompra.Columns["Estado"].HeaderText = "Estado";

            if (TablaDatosCompra.Columns.Contains("Subtotal"))
                TablaDatosCompra.Columns["Subtotal"].HeaderText = "Subtotal";

            if (TablaDatosCompra.Columns.Contains("Impuestos"))
                TablaDatosCompra.Columns["Impuestos"].HeaderText = "ITBIS";

            if (TablaDatosCompra.Columns.Contains("Total"))
                TablaDatosCompra.Columns["Total"].HeaderText = "Total";

            if (TablaDatosCompra.Columns.Contains("Subtotal"))
                TablaDatosCompra.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
            if (TablaDatosCompra.Columns.Contains("Impuestos"))
                TablaDatosCompra.Columns["Impuestos"].DefaultCellStyle.Format = "N2";
            if (TablaDatosCompra.Columns.Contains("Total"))
                TablaDatosCompra.Columns["Total"].DefaultCellStyle.Format = "N2";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == TabPageHistorialCompras)
            {
                CargarHistorialCompras();
            }
        }

        private void fecini_ValueChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == TabPageHistorialCompras)
                CargarHistorialCompras();
        }

        private void fecfin_ValueChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == TabPageHistorialCompras)
                CargarHistorialCompras();
        }

        private void BusquedaCompraTxt_TextChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == TabPageHistorialCompras)
                CargarHistorialCompras();
        }

        private void PendienteChk_CheckedChanged(object sender, EventArgs e)
        {
            if (PendienteChk.Checked)
            {
                RecibidaChk.Checked = false;
                AnuladoChk.Checked = false;
                TodosChk.Checked = false;
            }

            if (tabControl1.SelectedTab == TabPageHistorialCompras)
                CargarHistorialCompras();
        }

        private void RecibidaChk_CheckedChanged(object sender, EventArgs e)
        {
            if (RecibidaChk.Checked)
            {
                PendienteChk.Checked = false;
                AnuladoChk.Checked = false;
                TodosChk.Checked = false;
            }

            if (tabControl1.SelectedTab == TabPageHistorialCompras)
                CargarHistorialCompras();
        }

        private void AnuladoChk_CheckedChanged(object sender, EventArgs e)
        {
            if (AnuladoChk.Checked)
            {
                PendienteChk.Checked = false;
                RecibidaChk.Checked = false;
                TodosChk.Checked = false;
            }

            if (tabControl1.SelectedTab == TabPageHistorialCompras)
                CargarHistorialCompras();
        }

        private void TodosChk_CheckedChanged(object sender, EventArgs e)
        {
            if (TodosChk.Checked)
            {
                PendienteChk.Checked = false;
                RecibidaChk.Checked = false;
                AnuladoChk.Checked = false;
            }

            if (tabControl1.SelectedTab == TabPageHistorialCompras)
                CargarHistorialCompras();
        }

        private int? ObtenerIdCompraSeleccionada()
        {
            if (TablaDatosCompra.CurrentRow == null || TablaDatosCompra.CurrentRow.IsNewRow)
                return null;

            object val = TablaDatosCompra.CurrentRow.Cells["IdCompra"].Value;
            if (val == null || val == DBNull.Value)
                return null;

            return Convert.ToInt32(val);
        }

        private void ConfirmarRecepcionBtn_Click(object sender, EventArgs e)
        {
            int? idCompra = ObtenerIdCompraSeleccionada();
            if (!idCompra.HasValue)
            {
                MessageBox.Show("Seleccione una compra en la lista.");
                return;
            }

            string estadoActual = TablaDatosCompra.CurrentRow.Cells["Estado"].Value?.ToString();

            if (estadoActual == "Recibida")
            {
                MessageBox.Show("Esta compra ya está marcada como Recibida.");
                return;
            }

            if (estadoActual == "Anulada")
            {
                MessageBox.Show("No se puede recibir una compra Anulada.");
                return;
            }

            var resp = MessageBox.Show(
                "¿Confirmar recepción de esta compra y actualizar el stock?",
                "Confirmar recepción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    string sqlUpdateCompra = @"
                    UPDATE Compra
                    SET Estado = 'Recibida',
                    FechaRecepcion = SYSDATETIME()
                    WHERE IdCompra = @IdCompra
                    AND Estado = 'Pendiente';";

                    int rowsCompra;
                    using (SqlCommand cmd = new SqlCommand(sqlUpdateCompra, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@IdCompra", idCompra.Value);
                        rowsCompra = cmd.ExecuteNonQuery();
                    }

                    if (rowsCompra == 0)
                    {
                        tran.Rollback();
                        MessageBox.Show("La compra ya fue procesada o no está en estado Pendiente.");
                        CargarHistorialCompras();
                        return;
                    }

                    string sqlDetalle = @"
                    SELECT IdProducto, Cantidad
                    FROM DetalleCompra
                    WHERE IdCompra = @IdCompra;";

                    var items = new System.Collections.Generic.List<(int IdProd, decimal Cant)>();

                    using (SqlCommand cmdDet = new SqlCommand(sqlDetalle, con, tran))
                    {
                        cmdDet.Parameters.AddWithValue("@IdCompra", idCompra.Value);

                        using (SqlDataReader dr = cmdDet.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                int idProd = dr.GetInt32(0);
                                decimal cantidad = dr.GetDecimal(1);
                                items.Add((idProd, cantidad));
                            }
                        }
                    }

                    string sqlStock = @"
                    UPDATE ProductoVenta
                    SET Existencia = ISNULL(Existencia,0) + @Cantidad
                    WHERE IdProducto = @IdProducto;";

                    using (SqlCommand cmdStock = new SqlCommand(sqlStock, con, tran))
                    {
                        cmdStock.Parameters.Add("@Cantidad", SqlDbType.Decimal);
                        cmdStock.Parameters.Add("@IdProducto", SqlDbType.Int);

                        foreach (var item in items)
                        {
                            cmdStock.Parameters["@Cantidad"].Value = item.Cant;
                            cmdStock.Parameters["@IdProducto"].Value = item.IdProd;
                            cmdStock.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    MessageBox.Show("Compra marcada como Recibida y stock actualizado.");
                    CargarHistorialCompras();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error al confirmar la recepción: " + ex.Message);
                }
            }
        }

        private void CancelarBtn_Click(object sender, EventArgs e)
        {

            int? idCompra = ObtenerIdCompraSeleccionada();
            if (!idCompra.HasValue)
            {
                MessageBox.Show("Seleccione una compra en la lista.");
                return;
            }

            string estadoActual = TablaDatosCompra.CurrentRow.Cells["Estado"].Value?.ToString();

            if (estadoActual == "Recibida")
            {
                MessageBox.Show("No se puede anular una compra ya Recibida.");
                return;
            }

            if (estadoActual == "Anulada")
            {
                MessageBox.Show("Esta compra ya está Anulada.");
                return;
            }

            var resp = MessageBox.Show("¿Seguro que desea anular esta compra?",
              "Anular compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();

                string sql = @"
                UPDATE Compra
                SET Estado = 'Anulada'
                WHERE IdCompra = @IdCompra
                AND Estado = 'Pendiente';";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@IdCompra", idCompra.Value);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        MessageBox.Show("No se pudo anular la compra. Verifique el estado actual.");
                    }
                    else
                    {
                        MessageBox.Show("Compra anulada correctamente.");
                    }
                }
            }

            CargarHistorialCompras();
        }


        private int? compraEnEdicionId = null;

        private void ActualizarUIInformal()
        {

            ProvInformalChk.AutoCheck = false;
            ProvInformalChk.Enabled = false;


            ProvInformalChk.ForeColor = ProvInformalChk.Checked
                ? Color.LightSalmon
                : Color.Gainsboro;
        }

        private void detallecompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = detallecompra.Rows[e.RowIndex];

            productoSeleccionadoId = Convert.ToInt32(row.Cells["IdProducto"].Value);
            unidadSeleccionada = row.Cells["Unidad"].Value.ToString();

            decimal itbisLinea = 0;
            if (row.Cells["ItbisPorciento"].Value != null && row.Cells["ItbisPorciento"].Value != DBNull.Value)
                itbisLinea = Convert.ToDecimal(row.Cells["ItbisPorciento"].Value);

            itbisSeleccionadoPorciento = itbisLinea;

            IdIngredientetxt.Text = productoSeleccionadoId.ToString();
            txtnombre.Text = row.Cells["Nombre"].Value.ToString();
            txtpreciocompra.Text = Convert.ToDecimal(row.Cells["CostoUnitario"].Value).ToString("0.00");
            NumericUpCantidad.Value = Convert.ToDecimal(row.Cells["Cantidad"].Value);

            detallecompra.Rows.RemoveAt(e.RowIndex);
            RecalcularTotales();

            AgregarBtn.Enabled = true;
        }

        private void ConfigurarModoCabecera(bool esEdicion)
        {

            idproveedortxt.ReadOnly = true;
            txtnombrecompleto.ReadOnly = true;
            TelefProvTxt.ReadOnly = true;
            DireccionProvTxt.ReadOnly = true;
            IdRespoCompratxt.ReadOnly = true;
            ResponsableCompratxt.ReadOnly = true;
            ProvInformalChk.Enabled = false;

            BusquedaProvBtn.Enabled = !esEdicion;
        }

        private void TablaDatosCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = TablaDatosCompra.Rows[e.RowIndex];

            if (fila.Cells["IdCompra"].Value == null)
                return;

            int idCompra = Convert.ToInt32(fila.Cells["IdCompra"].Value);
            string estado = fila.Cells["Estado"].Value?.ToString();

            if (estado != "Pendiente")
            {
                MessageBox.Show("Solo se pueden editar compras en estado Pendiente.");
                return;
            }

            CargarCompraParaEdicion(idCompra);
            tabControl1.SelectedTab = tabPageReg;
        }
        private void CargarCompraParaEdicion(int idCompra)
        {

            LimpiarFormulario();
            compraEnEdicionId = idCompra;
            txtidcompra.Text = idCompra.ToString();

            ConfigurarModoCabecera(true);

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();

                string sqlCab = @"
                SELECT 
                c.Fecha,
                c.IdProveedorPersona,
                prov.Informal AS EsInformal,
                perProv.NombreCompleto AS NombreProveedor,
                tel.Numero   AS Telefono,
                dir.Direccion,
                c.IdEmpleadoResponsable,
                perResp.NombreCompleto AS NombreResponsable
                FROM Compra c
                LEFT JOIN Persona perProv 
                ON c.IdProveedorPersona = perProv.IdPersona
                LEFT JOIN Proveedor prov
                ON prov.IdPersona = perProv.IdPersona
                LEFT JOIN PersonaTelefono tel 
                ON perProv.IdPersona = tel.IdPersona AND tel.EsPrincipal = 1
                LEFT JOIN PersonaDireccion dir 
                ON perProv.IdPersona = dir.IdPersona AND dir.EsPrincipal = 1
                LEFT JOIN Empleado emp
                ON c.IdEmpleadoResponsable = emp.IdEmpleado
                LEFT JOIN Persona perResp
                ON emp.IdPersona = perResp.IdPersona
                WHERE c.IdCompra = @IdCompra;";

                using (SqlCommand cmdCab = new SqlCommand(sqlCab, con))
                {
                    cmdCab.Parameters.AddWithValue("@IdCompra", idCompra);

                    using (SqlDataReader dr = cmdCab.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            FechaCompra.Value = Convert.ToDateTime(dr["Fecha"]);

                            if (dr["IdProveedorPersona"] != DBNull.Value)
                                idproveedortxt.Text = dr["IdProveedorPersona"].ToString();
                            else
                                idproveedortxt.Text = "";


                            txtnombrecompleto.Text = dr["NombreProveedor"] == DBNull.Value
                                ? ""
                                : dr["NombreProveedor"].ToString();


                            string tel = dr["Telefono"] == DBNull.Value ? "" : dr["Telefono"].ToString();
                            string dir = dr["Direccion"] == DBNull.Value ? "" : dr["Direccion"].ToString();

                            TelefProvTxt.Text = string.IsNullOrWhiteSpace(tel) ? "No definido" : tel;
                            DireccionProvTxt.Text = string.IsNullOrWhiteSpace(dir) ? "No definido" : dir;

                            TelefProvTxt.ForeColor =
                                string.IsNullOrWhiteSpace(tel) ? Color.DimGray : Color.White;
                            DireccionProvTxt.ForeColor =
                                string.IsNullOrWhiteSpace(dir) ? Color.DimGray : Color.White;

                            bool informal = false;
                            if (dr["EsInformal"] != DBNull.Value)
                                informal = Convert.ToBoolean(dr["EsInformal"]);

                            ProvInformalChk.Checked = informal;
                            ActualizarUIInformal();

                            if (dr["IdEmpleadoResponsable"] != DBNull.Value)
                                IdRespoCompratxt.Text = dr["IdEmpleadoResponsable"].ToString();

                            if (dr["NombreResponsable"] != DBNull.Value)
                                ResponsableCompratxt.Text = dr["NombreResponsable"].ToString();
                        }
                    }
                }

                string sqlDet = @"
                SELECT 
                dc.IdProducto,
                p.Nombre,
                u.Nombre AS Unidad,
                dc.Cantidad,
                dc.CostoUnitario,
                ISNULL(p.Itbis, 0) AS ItbisPorciento
                FROM DetalleCompra dc
                INNER JOIN ProductoVenta p ON dc.IdProducto = p.IdProducto
                INNER JOIN UnidadMedida u ON p.IdUnidadMedida = u.IdUnidadMedida
                WHERE dc.IdCompra = @IdCompra
                ORDER BY dc.IdDetalle;";

                using (SqlCommand cmdDet = new SqlCommand(sqlDet, con))
                {
                    cmdDet.Parameters.AddWithValue("@IdCompra", idCompra);

                    using (SqlDataReader drDet = cmdDet.ExecuteReader())
                    {
                        while (drDet.Read())
                        {
                            int rowIndex = detallecompra.Rows.Add();
                            DataGridViewRow row = detallecompra.Rows[rowIndex];

                            row.Cells["IdProducto"].Value = drDet["IdProducto"];
                            row.Cells["Nombre"].Value = drDet["Nombre"];
                            row.Cells["Unidad"].Value = drDet["Unidad"];
                            row.Cells["Cantidad"].Value = drDet["Cantidad"];
                            row.Cells["CostoUnitario"].Value = drDet["CostoUnitario"];
                            row.Cells["ItbisPorciento"].Value = drDet["ItbisPorciento"];
                        }
                    }
                }
            }

            RecalcularTotales();
        }

        private void EditarBtn_Click(object sender, EventArgs e)
        {
            int? idCompra = ObtenerIdCompraSeleccionada();
            if (!idCompra.HasValue)
            {
                MessageBox.Show("Seleccione una compra en la lista.");
                return;
            }

            string estado = TablaDatosCompra.CurrentRow.Cells["Estado"].Value?.ToString();

            if (estado != "Pendiente")
            {
                MessageBox.Show("Solo se pueden editar compras en estado Pendiente.");
                return;
            }

            CargarCompraParaEdicion(idCompra.Value);
            tabControl1.SelectedTab = tabPageReg;
        }

        private void ImprimirBtn_Click(object sender, EventArgs e)
        {
            int? idCompra = ObtenerIdCompraSeleccionada();
            if (!idCompra.HasValue)
            {
                MessageBox.Show("Seleccione una compra en la lista.");
                return;
            }

            string estado = TablaDatosCompra.CurrentRow.Cells["Estado"].Value?.ToString() ?? "";

            if (estado == "Pendiente")
            {
                MessageBox.Show("Esta compra está PENDIENTE. El PDF se generará como provisional.");
            }
            else if (estado == "Anulada")
            {
                MessageBox.Show("Esta compra está ANULADA. El PDF se generará marcado como anulada.");
            }

            GenerarCompraPDF(idCompra.Value);
        }

        void GenerarCompraPDF(int idCompra)
        {
            try
            {
                string folderPath = @"C:\SistemaArchivos\Compras\";
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, $"Compra_{idCompra}.pdf");

                PdfDocument document = new PdfDocument();
                document.Info.Title = $"Compra {idCompra}";

                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont titleFont = new XFont("Segoe UI", 18, XFontStyleEx.Bold);
                XFont sectionFont = new XFont("Segoe UI", 12, XFontStyleEx.Bold);
                XFont labelFont = new XFont("Segoe UI", 11, XFontStyleEx.Bold);
                XFont textFont = new XFont("Segoe UI", 11, XFontStyleEx.Regular);
                XFont smallFont = new XFont("Segoe UI", 9, XFontStyleEx.Regular);
                XFont watermarkFont = new XFont("Segoe UI", 40, XFontStyleEx.Bold);

                double marginLeft = 40;
                double marginRight = 40;
                double currentY = 45;
                double rowH = 18;

                var pen = new XPen(XColors.Black, 0.7);

                double usableW = page.Width - marginLeft - marginRight;
                double rightEdge = marginLeft + usableW;

                string proveedor = "", responsable = "", fechaCompra = "", estado = "", fechaRecepcion = "";
                decimal subtotal = 0, itbis = 0, total = 0;

                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    con.Open();

                    string sqlCab = @"
                        SELECT 
                        c.IdCompra,
                        c.Fecha,
                        c.FechaRecepcion,
                        c.Estado,
                        c.Subtotal,
                        c.Impuestos,
                        c.Total,
                        prov.NombreCompleto AS NombreProveedor,
                        ISNULL(emp.NombreCompleto,'') AS NombreResponsable
                        FROM Compra c
                        INNER JOIN Persona prov ON c.IdProveedorPersona = prov.IdPersona
                        LEFT JOIN Empleado e ON c.IdEmpleadoResponsable = e.IdEmpleado
                        LEFT JOIN Persona emp ON e.IdPersona = emp.IdPersona
                        WHERE c.IdCompra = @id;";

                    using (SqlCommand cmd = new SqlCommand(sqlCab, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idCompra);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (!dr.Read())
                            {
                                MessageBox.Show("No se encontró la compra seleccionada.");
                                return;
                            }

                            fechaCompra = Convert.ToDateTime(dr["Fecha"]).ToString("dd/MM/yyyy HH:mm");
                            estado = dr["Estado"].ToString();

                            subtotal = Convert.ToDecimal(dr["Subtotal"]);
                            itbis = Convert.ToDecimal(dr["Impuestos"]);
                            total = Convert.ToDecimal(dr["Total"]);

                            proveedor = dr["NombreProveedor"].ToString();
                            responsable = dr["NombreResponsable"].ToString();

                            if (dr["FechaRecepcion"] != DBNull.Value)
                                fechaRecepcion = Convert.ToDateTime(dr["FechaRecepcion"]).ToString("dd/MM/yyyy HH:mm");
                        }
                    }
                }

                string titulo = "COMPROBANTE DE COMPRA";
                if (estado == "Pendiente") titulo = "COMPROBANTE DE COMPRA (PROVISIONAL)";
                if (estado == "Anulada") titulo = "COMPROBANTE DE COMPRA (ANULADA)";

                gfx.DrawString(titulo, titleFont, XBrushes.Black,
                    new XRect(0, currentY, page.Width, 30), XStringFormats.TopCenter);

                currentY += 45;

                if (estado == "Anulada")
                {
                    gfx.Save();
                    gfx.TranslateTransform(page.Width / 2, (page.Height / 2) + 70);
                    gfx.RotateTransform(-25);
                    gfx.DrawString("ANULADA", watermarkFont, XBrushes.LightGray,
                        new XRect(-320, -30, 640, 60), XStringFormats.TopCenter);
                    gfx.Restore();
                }

                void DrawLabelValue(string label, string value)
                {
                    gfx.DrawString(label, labelFont, XBrushes.Black, marginLeft, currentY);
                    gfx.DrawString(value, textFont, XBrushes.Black, marginLeft + 150, currentY);
                    currentY += rowH;
                }

                DrawLabelValue("Compra:", idCompra.ToString());
                DrawLabelValue("Proveedor:", proveedor);
                DrawLabelValue("Fecha compra:", fechaCompra);

                if (!string.IsNullOrWhiteSpace(responsable))
                    DrawLabelValue("Responsable:", responsable);

                DrawLabelValue("Estado:", estado);

                if (estado == "Recibida" && !string.IsNullOrWhiteSpace(fechaRecepcion))
                    DrawLabelValue("Fecha recepción:", fechaRecepcion);

                if (estado == "Pendiente")
                {
                    currentY += 4;
                    gfx.DrawString("Nota: Este documento es provisional hasta confirmar la recepción.",
                        smallFont, XBrushes.Black, marginLeft, currentY);
                    currentY += rowH;
                }

                currentY += 10;
                gfx.DrawLine(pen, marginLeft, currentY, rightEdge, currentY);
                currentY += 22;

                gfx.DrawString("DETALLE", sectionFont, XBrushes.Black, marginLeft, currentY);
                currentY += 18;

                double colProdX = marginLeft;
                double colCantX = marginLeft + usableW * 0.70;
                double colCostoX = marginLeft + usableW * 0.83;
                double colSubX = marginLeft + usableW * 0.98;

                currentY += 8;
                gfx.DrawLine(pen, marginLeft, currentY, rightEdge, currentY);
                currentY += 10;

                gfx.DrawString("Producto", labelFont, XBrushes.Black, colProdX, currentY);
                gfx.DrawString("Cant.", labelFont, XBrushes.Black, new XRect(colCantX - 60, currentY, 60, 20), XStringFormats.TopRight);
                gfx.DrawString("Costo", labelFont, XBrushes.Black, new XRect(colCostoX - 70, currentY, 70, 20), XStringFormats.TopRight);
                gfx.DrawString("Subtotal", labelFont, XBrushes.Black, new XRect(colSubX - 80, currentY, 80, 20), XStringFormats.TopRight);

                currentY += 18;
                gfx.DrawLine(pen, marginLeft, currentY, rightEdge, currentY);
                currentY += 8;

                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    con.Open();

                    string sqlDet = @"
                SELECT 
                p.Nombre,
                dc.Cantidad,
                dc.CostoUnitario,
                dc.Subtotal
                FROM DetalleCompra dc
                INNER JOIN ProductoVenta p ON p.IdProducto = dc.IdProducto
                WHERE dc.IdCompra = @id
                ORDER BY dc.IdDetalle;";

                    using (SqlCommand cmd = new SqlCommand(sqlDet, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idCompra);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string prod = dr["Nombre"].ToString();
                                decimal cant = Convert.ToDecimal(dr["Cantidad"]);
                                decimal costo = Convert.ToDecimal(dr["CostoUnitario"]);
                                decimal sub = Convert.ToDecimal(dr["Subtotal"]);

                                if (prod.Length > 50) prod = prod.Substring(0, 50) + "...";

                                gfx.DrawString(prod, textFont, XBrushes.Black, colProdX, currentY);
                                gfx.DrawString(cant.ToString("0.###"), textFont, XBrushes.Black,
                                    new XRect(colCantX - 60, currentY, 60, 20), XStringFormats.TopRight);
                                gfx.DrawString(costo.ToString("N2"), textFont, XBrushes.Black,
                                    new XRect(colCostoX - 70, currentY, 70, 20), XStringFormats.TopRight);
                                gfx.DrawString(sub.ToString("N2"), textFont, XBrushes.Black,
                                    new XRect(colSubX - 80, currentY, 80, 20), XStringFormats.TopRight);

                                currentY += rowH;

                                if (currentY > page.Height - 170)
                                {
                                    gfx.DrawLine(pen, marginLeft, currentY + 6, rightEdge, currentY + 6);

                                    page = document.AddPage();
                                    gfx = XGraphics.FromPdfPage(page);

                                    usableW = page.Width - marginLeft - marginRight;
                                    rightEdge = marginLeft + usableW;

                                    colCantX = marginLeft + usableW * 0.70;
                                    colCostoX = marginLeft + usableW * 0.83;
                                    colSubX = marginLeft + usableW * 0.98;

                                    currentY = 50;

                                    gfx.DrawString(titulo, titleFont, XBrushes.Black,
                                        new XRect(0, currentY, page.Width, 30), XStringFormats.TopCenter);

                                    currentY += 55;

                                    gfx.DrawLine(pen, marginLeft, currentY, rightEdge, currentY);
                                    currentY += 10;

                                    gfx.DrawString("Producto", labelFont, XBrushes.Black, colProdX, currentY);
                                    gfx.DrawString("Cant.", labelFont, XBrushes.Black, new XRect(colCantX - 60, currentY, 60, 20), XStringFormats.TopRight);
                                    gfx.DrawString("Costo", labelFont, XBrushes.Black, new XRect(colCostoX - 70, currentY, 70, 20), XStringFormats.TopRight);
                                    gfx.DrawString("Subtotal", labelFont, XBrushes.Black, new XRect(colSubX - 80, currentY, 80, 20), XStringFormats.TopRight);

                                    currentY += 18;
                                    gfx.DrawLine(pen, marginLeft, currentY, rightEdge, currentY);
                                    currentY += 8;
                                }
                            }
                        }
                    }
                }

                gfx.DrawLine(pen, marginLeft, currentY + 6, rightEdge, currentY + 6);
                currentY += 28;

                double totalsLabelX = marginLeft + usableW * 0.62;
                double totalsValueRight = rightEdge;
                double totalsValueW = 170;

                gfx.DrawString("SUBTOTAL:", labelFont, XBrushes.Black, totalsLabelX, currentY);
                gfx.DrawString($"RD$ {subtotal:N2}", labelFont, XBrushes.Black,
                    new XRect(totalsValueRight - totalsValueW, currentY, totalsValueW, 20), XStringFormats.TopRight);
                currentY += 18;

                gfx.DrawString("ITBIS:", labelFont, XBrushes.Black, totalsLabelX, currentY);
                gfx.DrawString($"RD$ {itbis:N2}", labelFont, XBrushes.Black,
                    new XRect(totalsValueRight - totalsValueW, currentY, totalsValueW, 20), XStringFormats.TopRight);
                currentY += 26;

                gfx.DrawString("TOTAL:", titleFont, XBrushes.Black, totalsLabelX, currentY);
                gfx.DrawString($"RD$ {total:N2}", titleFont, XBrushes.Black,
                    new XRect(totalsValueRight - totalsValueW, currentY, totalsValueW, 24), XStringFormats.TopRight);

                gfx.DrawString("Gloria Restaurant - Compras", smallFont, XBrushes.Black,
                    new XRect(marginLeft, page.Height - 50, page.Width, 20), XStringFormats.TopLeft);

                document.Save(filePath);

                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });

                MessageBox.Show("PDF generado correctamente.", "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
        }

        private void deslizarBtn_Click(object sender, EventArgs e)
        {
            if (sistemas == 0)
            {
                deslizarBtn.Image = Proyecto_restaurante.Properties.Resources.flechaderecharoja;
                opcionesCarpeta.Visible = true;   // <- si tu panel se llama diferente, cámbialo aquí
                sistemas = 1;
            }
            else
            {
                deslizarBtn.Image = Proyecto_restaurante.Properties.Resources.flechaizquierdaroja;
                opcionesCarpeta.Visible = false;  // <- si tu panel se llama diferente, cámbialo aquí
                sistemas = 0;
            }
        }

        private void carpetaComprasBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(rutaCompras))
                    Directory.CreateDirectory(rutaCompras);

                System.Diagnostics.Process.Start("explorer.exe", rutaCompras);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la carpeta: " + ex.Message);
            }
        }

        private void eliminarComprasBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(rutaCompras))
                {
                    MessageBox.Show("La carpeta no existe.");
                    return;
                }

                var archivos = Directory.GetFiles(rutaCompras, "*.pdf");

                if (archivos.Length == 0)
                {
                    MessageBox.Show("No hay comprobantes PDF para eliminar.");
                    return;
                }

                DialogResult r = MessageBox.Show(
                    $"Se eliminarán {archivos.Length} archivos PDF.\n¿Desea continuar?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (r == DialogResult.No)
                    return;

                foreach (var archivo in archivos)
                    File.Delete(archivo);

                MessageBox.Show("Todos los comprobantes de compras han sido eliminados.");
                deslizarBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar comprobantes: " + ex.Message);
            }
        }


    }


}
