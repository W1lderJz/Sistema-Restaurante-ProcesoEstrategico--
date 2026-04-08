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
using static Proyecto_restaurante.menu;

namespace Proyecto_restaurante
{
    public partial class Reservacion : Form
    {
        public Reservacion()
        {
            InitializeComponent();


        }

        private int ReservaID = 0;
        private int? ClienteIDReserva = null;
        private Button botonActivo = null;
        private int idMesaSeleccionada = -1;

        private class MesaInfoReserva
        {
            public int Id { get; set; }
            public bool Ocupado { get; set; }
            public bool Reservado { get; set; }
        }
        private int? ObtenerIdReservaSeleccionada()
        {
            if (ReservacionMesasDGV.CurrentRow == null ||
                ReservacionMesasDGV.CurrentRow.IsNewRow)
                return null;

            if (ReservacionMesasDGV.CurrentRow.Cells["IdReserva"].Value == null)
                return null;

            return Convert.ToInt32(ReservacionMesasDGV.CurrentRow.Cells["IdReserva"].Value);
        }


        private void BtnMesa_Click(object sender, EventArgs e)
        {
            Button btnSeleccionado = sender as Button;
            if (btnSeleccionado == null) return;

            if (botonActivo != null && botonActivo != btnSeleccionado)
            {
                var infoAnterior = botonActivo.Tag as MesaInfoReserva;
                if (infoAnterior != null)
                {
                    if (infoAnterior.Ocupado)
                        botonActivo.BackColor = Color.LightCoral;
                    else if (infoAnterior.Reservado)
                        botonActivo.BackColor = Color.MediumPurple;
                    else
                        botonActivo.BackColor = Color.LightGreen;
                }
            }

            botonActivo = btnSeleccionado;
            botonActivo.BackColor = Color.DodgerBlue;

            var info = botonActivo.Tag as MesaInfoReserva;
            idMesaSeleccionada = (info != null) ? info.Id : -1;
        }

        private void Reservacion_Load(object sender, EventArgs e)
        {
            ConfigurarDateTimePickersReserva();

            PanelClientes.Visible = false;

            try
            {
                LiberarReservasVencidas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar reservas vencidas: " + ex.Message);
            }

            PrepararNuevaReserva();
            CargarMesasDisponiblesReserva();

            fecini.Value = DateTime.Today;
            fecfin.Value = DateTime.Today;
            CargarReservas();
        }
        private void ConfigurarDateTimePickersReserva()
        {
            fechacreacionreserva.Format = DateTimePickerFormat.Short;
            fecreservacion.Format = DateTimePickerFormat.Custom;

            fecreservacion.CustomFormat = "dd/MM/yyyy HH:mm";
            fecreservacion.ShowUpDown = true;
        }
        private void PrepararNuevaReserva()
        {
            ReservaID = 0;
            ClienteIDReserva = null;
            idMesaSeleccionada = -1;
            botonActivo = null;

            CargarProximoIdReserva();

            fechacreacionreserva.Value = SistemaFecha.FechaActual;
            fecreservacion.Value = SistemaFecha.FechaActual;

            idclientetxt.Clear();
            txtnombrecompleto.Clear();
            txtnumero_cliente.Clear();

            CantidadPersonasNUD.Value = 1;

            notapanel.Visible = false;
            notatxt.Text = "Escribir nota aquí...";
            notatxt.ForeColor = Color.Gray;

            CargarMesasDisponiblesReserva();
        }
        private void CargarProximoIdReserva()
        {
            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                string sql = "SELECT ISNULL(MAX(IdReserva), 0) + 1 FROM Reserva;";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    object res = cmd.ExecuteScalar();
                    txtidreserva.Text = Convert.ToInt32(res).ToString();
                }
            }
        }
        private void nuevobtn_Click(object sender, EventArgs e)
        {
            try
            {
                LiberarReservasVencidas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar reservas vencidas: " + ex.Message);
            }

            PrepararNuevaReserva();
        }

        private void CargarMesasDisponiblesReserva()
        {
            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();

                string sql = @"
                SELECT 
                m.IdMesa,
                m.IdSala,
                s.Nombre AS NombreSala,
                m.Numero,
                m.Capacidad,
                m.Ocupado,
                ISNULL(m.Reservado,0) AS Reservado
                FROM Mesa m
                INNER JOIN Sala s ON m.IdSala = s.IdSala
                ORDER BY s.Nombre, m.Numero;";

                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    flowmesa.Controls.Clear();
                    botonActivo = null;
                    idMesaSeleccionada = -1;

                    while (dr.Read())
                    {
                        int idMesa = Convert.ToInt32(dr["IdMesa"]);
                        int numero = Convert.ToInt32(dr["Numero"]);
                        string nombreSala = dr["NombreSala"].ToString();
                        int capacidad = Convert.ToInt32(dr["Capacidad"]);
                        bool ocupado = Convert.ToBoolean(dr["Ocupado"]);
                        bool reservado = Convert.ToBoolean(dr["Reservado"]);

                        Button btnMesa = new Button
                        {
                            Width = 150,
                            Height = 100,
                            Margin = new Padding(10),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            Cursor = Cursors.Hand,
                            Tag = new MesaInfoReserva
                            {
                                Id = idMesa,
                                Ocupado = ocupado,
                                Reservado = reservado
                            }
                        };

                        if (ocupado)
                            btnMesa.BackColor = Color.LightCoral;
                        else if (reservado)
                            btnMesa.BackColor = Color.MediumPurple;
                        else
                            btnMesa.BackColor = Color.LightGreen;

                        btnMesa.Text =
                            $"Mesa #{numero}\n" +
                            $"Sala: {nombreSala}\n" +
                            $"Asientos: {capacidad}";

                        btnMesa.Click += BtnMesa_Click;

                        flowmesa.Controls.Add(btnMesa);
                    }
                }
            }
        }
        private void LiberarReservasVencidas()
        {
            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {

                    string sqlCancelVencidas = @"
                                    UPDATE Reserva
                                    SET Estado = 'cancelada'
                                    WHERE Estado = 'solicitada'
                                    AND FechaHora < SYSDATETIME();";

                    using (SqlCommand cmd = new SqlCommand(sqlCancelVencidas, con, tran))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    string sqlLiberarMesas = @"
                    UPDATE m
                    SET m.Reservado = 0
                    FROM Mesa m
                    WHERE ISNULL(m.Reservado,0) = 1
                    AND NOT EXISTS (
                    SELECT 1
                    FROM Reserva r
                    WHERE r.IdMesa = m.IdMesa
                    AND r.Estado IN ('solicitada','confirmada')
                    AND r.FechaHora >= SYSDATETIME()
                    );";

                    using (SqlCommand cmd = new SqlCommand(sqlLiberarMesas, con, tran))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        private void guardareservabtn_Click(object sender, EventArgs e)
        {
            if (idMesaSeleccionada <= 0)
            {
                MessageBox.Show("Debe seleccionar una mesa.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtnombrecompleto.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }

            if (CantidadPersonasNUD.Value <= 0)
            {
                MessageBox.Show("La cantidad de personas debe ser mayor que 0.");
                return;
            }

            int idMesa = idMesaSeleccionada;
            DateTime fechaReserva = fecreservacion.Value;
            int personas = (int)CantidadPersonasNUD.Value;
            string nombreCliente = txtnombrecompleto.Text.Trim();

            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();

                // ✅ VALIDACIÓN SIMPLE EN BD (por si el panel estaba desactualizado)
                string sqlCheck = "SELECT Ocupado, ISNULL(Reservado,0) AS Reservado FROM Mesa WHERE IdMesa = @IdMesa;";
                using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, con))
                {
                    cmdCheck.Parameters.AddWithValue("@IdMesa", idMesa);

                    using (SqlDataReader dr = cmdCheck.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            bool ocupado = Convert.ToBoolean(dr["Ocupado"]);
                            bool reservado = Convert.ToBoolean(dr["Reservado"]);

                            if (ocupado || reservado)
                            {
                                MessageBox.Show("Esa mesa ya no está disponible. Presiona Nuevo para recargar.");
                                return;
                            }
                        }
                    }
                }

                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    if (ReservaID == 0)
                    {
                        string sqlInsert = @"
                                INSERT INTO Reserva
                                (IdMesa, FechaHora, Personas, Cliente, Estado, CreadoEn)
                                VALUES
                                (@IdMesa, @FechaHora, @Personas, @Cliente, 'solicitada', SYSDATETIME());
                                SELECT CAST(SCOPE_IDENTITY() AS int);";

                        using (SqlCommand cmd = new SqlCommand(sqlInsert, con, trans))
                        {
                            cmd.Parameters.AddWithValue("@IdMesa", idMesa);
                            cmd.Parameters.AddWithValue("@FechaHora", fechaReserva);
                            cmd.Parameters.AddWithValue("@Personas", personas);
                            cmd.Parameters.AddWithValue("@Cliente", nombreCliente);

                            ReservaID = (int)cmd.ExecuteScalar();
                            txtidreserva.Text = ReservaID.ToString();
                        }

                        string sqlUpdateMesa = @"
                            UPDATE Mesa
                            SET Reservado = 1
                            WHERE IdMesa = @IdMesa;";

                        using (SqlCommand cmdMesa = new SqlCommand(sqlUpdateMesa, con, trans))
                        {
                            cmdMesa.Parameters.AddWithValue("@IdMesa", idMesa);
                            cmdMesa.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string sqlUpdate = @"
                            UPDATE Reserva
                            SET IdMesa    = @IdMesa,
                            FechaHora = @FechaHora,
                            Personas  = @Personas,
                            Cliente   = @Cliente
                            WHERE IdReserva = @IdReserva;";

                        using (SqlCommand cmd = new SqlCommand(sqlUpdate, con, trans))
                        {
                            cmd.Parameters.AddWithValue("@IdReserva", ReservaID);
                            cmd.Parameters.AddWithValue("@IdMesa", idMesa);
                            cmd.Parameters.AddWithValue("@FechaHora", fechaReserva);
                            cmd.Parameters.AddWithValue("@Personas", personas);
                            cmd.Parameters.AddWithValue("@Cliente", nombreCliente);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    MessageBox.Show("Reserva guardada correctamente.");

                    PrepararNuevaReserva();          
                    CargarMesasDisponiblesReserva();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error al guardar la reserva: " + ex.Message);
                }
            }
        }


        private void buscarclientebtn_Click(object sender, EventArgs e)
        {
            PanelClientes.Visible = !PanelClientes.Visible;

            if (PanelClientes.Visible)
            {
                PanelClientes.BringToFront();
                txtbuscador.Text = "";
                filtrochk.Checked = true;
                CargarClientesReserva("", true);
                txtbuscador.Focus();
            }
        }

        private void notabtn_Click(object sender, EventArgs e)
        {
            notapanel.Visible = !notapanel.Visible;
            if (notapanel.Visible)
                notatxt.Focus();
        }

        private void notatxt_Enter(object sender, EventArgs e)
        {
            if (notatxt.Text == "Escribir nota aquí...")
            {
                notatxt.Text = "";
                notatxt.ForeColor = Color.Black;
            }
        }
        private void notatxt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(notatxt.Text))
            {
                notatxt.Text = "Escribir nota aquí...";
                notatxt.ForeColor = Color.Gray;
            }
        }

        private void CargarClientesReserva(string filtroTexto, bool soloActivos)
        {
            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();

                string sql = @"
                SELECT 
                c.IdCliente,
                p.NombreCompleto,
                p.Email,
                c.Activo
                FROM Cliente c
                INNER JOIN Persona p ON c.IdPersona = p.IdPersona
                WHERE 1 = 1 
                AND c.IdCliente > 1";

                if (!string.IsNullOrWhiteSpace(filtroTexto))
                {
                    sql += @"
                    AND (
                    p.NombreCompleto LIKE @filtro
                    OR p.Email LIKE @filtro)";
                }

                if (soloActivos)
                {
                    sql += " AND c.Activo = 1 AND p.Activo = 1";
                }

                sql += " ORDER BY p.NombreCompleto;";

                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    if (!string.IsNullOrWhiteSpace(filtroTexto))
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtroTexto + "%");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        tabladatoscliente.DataSource = dt;
                    }
                }
            }

            if (tabladatoscliente.Columns.Contains("IdCliente"))
                tabladatoscliente.Columns["IdCliente"].HeaderText = "ID";
            if (tabladatoscliente.Columns.Contains("NombreCompleto"))
                tabladatoscliente.Columns["NombreCompleto"].HeaderText = "Nombre";
            if (tabladatoscliente.Columns.Contains("Email"))
                tabladatoscliente.Columns["Email"].HeaderText = "Correo";
            if (tabladatoscliente.Columns.Contains("Activo"))
                tabladatoscliente.Columns["Activo"].HeaderText = "Activo";
        }

        private void txtbuscador_TextChanged(object sender, EventArgs e)
        {
            CargarClientesReserva(txtbuscador.Text.Trim(), filtrochk.Checked);
        }

        private void filtrochk_CheckedChanged(object sender, EventArgs e)
        {
            CargarClientesReserva(txtbuscador.Text.Trim(), filtrochk.Checked);
        }

        private void recargarbtn_Click(object sender, EventArgs e)
        {
            txtbuscador.Clear();
            filtrochk.Checked = true;
            CargarClientesReserva("", true);
        }

        private void eliminarbtn_Click(object sender, EventArgs e)
        {
            txtbuscador.Clear();
        }

        private void tabladatoscliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = tabladatoscliente.Rows[e.RowIndex];
            if (fila.Cells["IdCliente"].Value == null) return;

            ClienteIDReserva = Convert.ToInt32(fila.Cells["IdCliente"].Value);
            idclientetxt.Text = ClienteIDReserva.ToString();
            txtnombrecompleto.Text = fila.Cells["NombreCompleto"].Value?.ToString();

            PanelClientes.Visible = false;
        }
        private void salirclientebtn_Click(object sender, EventArgs e)
        {
            PanelClientes.Visible = false;
        }

        private void CargarReservas(string texto = "")
        {
            string conexionString = ConexionBD.ConexionSQL();

            DateTime desde = fecini.Value.Date;
            DateTime hasta = fecfin.Value.Date;

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();

                string sql = @"
                        SELECT 
                        r.IdReserva,
                        r.FechaHora,
                        r.Personas,
                        r.Cliente,
                        r.Estado,
                        m.Numero      AS NumeroMesa,
                        s.Nombre      AS Sala
                        FROM Reserva r
                        INNER JOIN Mesa m ON r.IdMesa = m.IdMesa
                        INNER JOIN Sala s ON m.IdSala = s.IdSala
                        WHERE 
                        r.FechaHora >= @Desde
                        AND r.FechaHora < DATEADD(day, 1, @Hasta)
                        AND (
                        @Texto = '' OR
                        CAST(r.IdReserva AS varchar(10)) LIKE @Filtro OR
                        r.Cliente LIKE @Filtro OR
                        CAST(m.Numero AS varchar(10)) LIKE @Filtro OR
                        s.Nombre LIKE @Filtro
                        ) ORDER BY r.FechaHora DESC;";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);

                    string filtro = string.IsNullOrWhiteSpace(texto) ? "" : texto.Trim();
                    cmd.Parameters.AddWithValue("@Texto", filtro);
                    cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ReservacionMesasDGV.DataSource = dt;
                    }
                }
            }

            if (ReservacionMesasDGV.Columns.Contains("IdReserva"))
                ReservacionMesasDGV.Columns["IdReserva"].HeaderText = "ID";
            if (ReservacionMesasDGV.Columns.Contains("FechaHora"))
                ReservacionMesasDGV.Columns["FechaHora"].HeaderText = "Fecha / Hora";
            if (ReservacionMesasDGV.Columns.Contains("Personas"))
                ReservacionMesasDGV.Columns["Personas"].HeaderText = "Personas";
            if (ReservacionMesasDGV.Columns.Contains("Cliente"))
                ReservacionMesasDGV.Columns["Cliente"].HeaderText = "Cliente";
            if (ReservacionMesasDGV.Columns.Contains("Estado"))
                ReservacionMesasDGV.Columns["Estado"].HeaderText = "Estado";
            if (ReservacionMesasDGV.Columns.Contains("NumeroMesa"))
                ReservacionMesasDGV.Columns["NumeroMesa"].HeaderText = "Mesa";
            if (ReservacionMesasDGV.Columns.Contains("Sala"))
                ReservacionMesasDGV.Columns["Sala"].HeaderText = "Sala";
        }
        private void fecini_ValueChanged(object sender, EventArgs e)
        {
            CargarReservas(txtbusquedareserva.Text);
        }

        private void fecfin_ValueChanged(object sender, EventArgs e)
        {
            CargarReservas(txtbusquedareserva.Text);
        }
        private void txtbusquedareserva_TextChanged(object sender, EventArgs e)
        {
            CargarReservas(txtbusquedareserva.Text);
        }
        private void ordenbtn_Click(object sender, EventArgs e)
        {
            int? id = ObtenerIdReservaSeleccionada();
            if (id == null)
            {
                MessageBox.Show("Seleccione una reservación en la lista.");
                return;
            }

            DialogResult r = MessageBox.Show("¿Marcar esta reservación como CONFIRMADA?",
                                             "Confirmar", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    int idMesa = 0;

                    string sqlGetMesa = "SELECT IdMesa FROM Reserva WHERE IdReserva = @Id;";
                    using (SqlCommand cmdGet = new SqlCommand(sqlGetMesa, con, tran))
                    {
                        cmdGet.Parameters.AddWithValue("@Id", id.Value);
                        object res = cmdGet.ExecuteScalar();
                        if (res != null && res != DBNull.Value)
                            idMesa = Convert.ToInt32(res);
                    }

                    string sql = "UPDATE Reserva SET Estado = 'confirmada' WHERE IdReserva = @Id;";
                    using (SqlCommand cmd = new SqlCommand(sql, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@Id", id.Value);
                        cmd.ExecuteNonQuery();
                    }

                    if (idMesa > 0)
                    {
                        string sqlMesa = "UPDATE Mesa SET Reservado = 1 WHERE IdMesa = @IdMesa;";
                        using (SqlCommand cmdMesa = new SqlCommand(sqlMesa, con, tran))
                        {
                            cmdMesa.Parameters.AddWithValue("@IdMesa", idMesa);
                            cmdMesa.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();

                    MessageBox.Show("Reservación confirmada.");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error al confirmar: " + ex.Message);
                }
            }

            CargarReservas(txtbusquedareserva.Text);
            CargarMesasDisponiblesReserva();
        }

        private void cancelarreservabtn_Click(object sender, EventArgs e)
        {
            int? id = ObtenerIdReservaSeleccionada();
            if (id == null)
            {
                MessageBox.Show("Seleccione una reservación en la lista.");
                return;
            }

            DialogResult r = MessageBox.Show("¿Cancelar esta reservación?",
                                             "Cancelar", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);
            if (r != DialogResult.Yes) return;

            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    int idMesa = 0;
                    string estadoActual = "";

                    string sqlGet = "SELECT IdMesa, Estado FROM Reserva WHERE IdReserva = @Id;";
                    using (SqlCommand cmdGet = new SqlCommand(sqlGet, con, tran))
                    {
                        cmdGet.Parameters.AddWithValue("@Id", id.Value);

                        using (SqlDataReader dr = cmdGet.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                idMesa = Convert.ToInt32(dr["IdMesa"]);
                                estadoActual = dr["Estado"]?.ToString() ?? "";
                            }
                            else
                            {
                                tran.Rollback();
                                MessageBox.Show("No se encontró la reservación.");
                                return;
                            }
                        }
                    }

                    if (estadoActual == "cancelada")
                    {
                        tran.Rollback();
                        MessageBox.Show("Esa reservación ya estaba cancelada.");
                        return;
                    }

                    string sqlCancel = "UPDATE Reserva SET Estado = 'cancelada' WHERE IdReserva = @Id;";
                    using (SqlCommand cmd = new SqlCommand(sqlCancel, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@Id", id.Value);
                        cmd.ExecuteNonQuery();
                    }

                    if (idMesa > 0)
                    {
                        string sqlHayOtras = @"
                            SELECT COUNT(*) 
                            FROM Reserva
                            WHERE IdMesa = @IdMesa
                            AND Estado IN ('solicitada','confirmada');";

                        int activas = 0;
                        using (SqlCommand cmdCount = new SqlCommand(sqlHayOtras, con, tran))
                        {
                            cmdCount.Parameters.AddWithValue("@IdMesa", idMesa);
                            activas = Convert.ToInt32(cmdCount.ExecuteScalar());
                        }

                        if (activas == 0)
                        {
                            string sqlFreeMesa = "UPDATE Mesa SET Reservado = 0 WHERE IdMesa = @IdMesa;";
                            using (SqlCommand cmdFree = new SqlCommand(sqlFreeMesa, con, tran))
                            {
                                cmdFree.Parameters.AddWithValue("@IdMesa", idMesa);
                                cmdFree.ExecuteNonQuery();
                            }
                        }
                    }

                    tran.Commit();
                    MessageBox.Show("Reservación cancelada y mesa actualizada.");

                    CargarReservas(txtbusquedareserva.Text);
                    CargarMesasDisponiblesReserva();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error al cancelar: " + ex.Message);
                }
            }
        }

        private void RegresarBtn_Click(object sender, EventArgs e)
        {
            PanelClientes.Visible = false;

            if (tabladatoscliente.CurrentRow != null)
                tabladatoscliente.ClearSelection();

            txtnombrecompleto.Focus();
        }
    }
}
