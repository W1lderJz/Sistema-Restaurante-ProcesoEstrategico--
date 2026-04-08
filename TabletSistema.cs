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
using static Proyecto_restaurante.Pedidos;

namespace Proyecto_restaurante
{
    public partial class TabletSistema : Form
    {
        public TabletSistema()
        {
            InitializeComponent();
        }

        public string NombreUsuario;
        public int IdUsuario = 0;
        private int Autorizar = 0;
        private int IDMesa = 0;
        private int idMesaSeleccionada = 0;
        private int NumeroMesa = 0;
        private int EditarEstado = 0;

        private string IdClientePersonaST = "1"; // Cliente al contado

        private int CuentaSeparada = 0;
        private int OrdenGrupo = 0;
        public int EliminarFila = 0;
        private int PedidoID;
        private decimal Total;

        private int PasoActual = 0;

        decimal TotalPedido = 0m;
        decimal TotalAplicado = 0m;
        decimal TotalRestante = 0;

        private decimal totalAcumulado = 0;
        private decimal subtotalAcumulado = 0;
        public string comprobanteFinal;
        bool cargandoOrden = false;
        private int gruposMinimos = 1;

        bool modoUnion = false;
        bool modoSeparar = false;

        bool modoEntregar = false;

        private bool facturarDesdeMesa = false;

        List<int> mesasDelGrupo = new List<int>();

        List<int> mesasSeleccionadasUnion = new List<int>();

        private List<Panel> ordenesSeleccionadas = new List<Panel>();

        private List<CuentaItem> listaGrupos = new List<CuentaItem>();

        string conexionString = ConexionBD.ConexionSQL();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("¿Desea volver?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmar == DialogResult.Yes)
            {
                mesasOcupadas.Visible = true;
                mesasOcupadas.BringToFront();
                panelComanda.Visible = false;
                infoAdicional.Visible = false;
                mesapanel.Visible = false;
                barraAcciones.Visible = false;
                panelOrdenar.Visible = false;
                detalleorden.Rows.Clear();
                txtcodigoproducto.Clear();
                txtnombreproducto.Clear();
                txtprecioproducto.Clear();
                txtiva.Clear();
                CuentaSeparada = 0;
                AvisoCuentaSeparada.Visible = false;
                panelCuentaSeparada.Enabled = false;
                grupoCuenta.Items.Clear();
                RecalcularTotales();
                siguiente.Enabled = false;

                button1.Visible = false;
            }
        }

        private void TabletSistema_Load(object sender, EventArgs e)
        {
            if (!cargandoOrden)
                tipoComp.SelectedIndex = 1;

            cajerolabel.Text = "     Mesero: " + NombreUsuario;

            flowMesaOcupada.Controls.Clear();

            MostrarMesasOcupadas();

            List<MesaInfo> mesas = new List<MesaInfo>();

            using (SqlConnection cn = new SqlConnection(conexionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT IdMesa, Numero, Capacidad, Ocupado, Reservado, IdGrupo, EsPrincipal FROM Mesa where Ocupado = 1", cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mesas.Add(new MesaInfo
                    {
                        Id = Convert.ToInt32(dr["IdMesa"]),
                        Numero = dr["Numero"] == DBNull.Value ? "?" : dr["Numero"].ToString(),
                        Capacidad = dr["Capacidad"] == DBNull.Value ? "0" : dr["Capacidad"].ToString(),
                        Reservado = dr["Reservado"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Reservado"]),
                        Ocupado = dr["Ocupado"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Ocupado"]),
                        IdGrupo = dr["IdGrupo"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IdGrupo"]),
                        EsPrincipal = dr["EsPrincipal"] == DBNull.Value ? 0 : Convert.ToInt32(dr["EsPrincipal"])
                    });
                }
            }

            var individuales = mesas.Where(m => m.IdGrupo == 0).ToList();
            foreach (var mesa in individuales)
            {
                var btn = CrearBotonMesa(
                    mesa.Id,
                    mesa.Numero,
                    mesa.Capacidad,
                    mesa.Ocupado,
                    mesa.Reservado,
                    new List<string>()
                );
                flowMesaOcupada.Controls.Add(btn);
            }

            var grupos = mesas
            .Where(m => m.IdGrupo > 0)
            .GroupBy(m => m.IdGrupo);

            foreach (var grupo in grupos)
            {
                var principal = grupo.FirstOrDefault(m => m.EsPrincipal == 1) ?? grupo.First();

                var secundarias = grupo
                    .Where(m => m.Id != principal.Id)
                    .ToList();

                var unidas = secundarias
                .Select(m => m.Numero)
                .ToList();


                int capacidadTotal = grupo.Sum(m => int.TryParse(m.Capacidad, out int c) ? c : 0);

                var btn = CrearBotonMesa(
                    principal.Id,
                    principal.Numero,
                    capacidadTotal.ToString(),
                    principal.Ocupado,
                    principal.Reservado,
                    unidas
                );

                flowMesaOcupada.Controls.Add(btn);
            }
            NotifComanda();
            Comprobantes();
        }

        private void MostrarMesasOcupadas()
        {
            mesapanel.Visible = true;
            panelOrdenar.Visible = false;
            infoAdicional.Visible = false;

            EditarEstado = 1;
            PasoActual = 0;

            var mesas = ObtenerMesas("WHERE Ocupado = 1");
            ConstruirBotonesMesas(mesas);
        }

        public class MesaInfo
        {
            public int Id { get; set; }
            public string Numero { get; set; }
            public string Capacidad { get; set; }
            public int Reservado { get; set; }
            public int Ocupado { get; set; }
            public int IdGrupo { get; set; }
            public int EsPrincipal { get; set; }

            public List<string> ListaMesas { get; set; } = new List<string>();
        }

        private void Comprobantes()
        {
            if (cargandoOrden) return;

            int tipo = tipoComp.SelectedIndex == 0 ? 1 : 2;

            string query = "SELECT TOP 1 SecuenciaActual FROM Comprobantes WHERE Tipo = @Tipo ORDER BY IdComprobante DESC";

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Tipo", tipo);

                    object resultado = cmd.ExecuteScalar();

                    int nuevaSecuencia = 1;

                    if (resultado != null && resultado != DBNull.Value)
                        nuevaSecuencia = Convert.ToInt32(resultado) + 1;

                    Comprobantetxt.Text = nuevaSecuencia.ToString("D8");
                }
            }
        }

        private Button botonActivo = null;

        private void BtnMesa_Click(object sender, EventArgs e)
        {
            Button btnSeleccionado = sender as Button;

            if (botonActivo != null)
            {
                dynamic anterior = botonActivo.Tag;
                botonActivo.BackColor = (anterior.Estado == 1) ?
                    Color.LightCoral : Color.LightGreen;
            }

            botonActivo = btnSeleccionado;
            btnSeleccionado.BackColor = Color.DodgerBlue;

            dynamic mesa = btnSeleccionado.Tag;
            idMesaSeleccionada = mesa.Id;
            siguiente.Enabled = true;
        }

        private void nuevaOrden_Click(object sender, EventArgs e)
        {
            EditarEstado = 0;
            PasoActual = 0;

            var mesas = ObtenerMesas("WHERE Ocupado = 0");
            ConstruirBotonesMesas(mesas);

            PasoActual = 0;

            mesapanel.Location = new Point(11, 64);
            mesapanel.BringToFront();
            mesapanel.Visible = true;

            panelOrdenar.Visible = false;
            infoAdicional.Visible = false;

            barraAcciones.Location = new Point(11, 699);
            barraAcciones.BringToFront();
            barraAcciones.Visible = true;

            mesapanel.Visible = true;
            panelOrdenar.Visible = false;
            infoAdicional.Visible = false;

            CargarMesasDisponibles();

            PasoActual = 0;
            atras.Enabled = false;

            if (detalleorden.ColumnCount == 0)
            {
                detalleorden.Columns.Add("cuenta", "CT.");
                detalleorden.Columns.Add("codigoProducto", "ID");
                detalleorden.Columns.Add("nombreProducto", "Nombre");
                detalleorden.Columns.Add("precio", "$");
                detalleorden.Columns.Add("itbis", "IT");
                detalleorden.Columns.Add("cantidad", "Cant.");
            }
            button1.Visible = true;
        }

        private void CargarMesasDisponibles()
        {
            panelMesas.Controls.Clear();

            List<MesaInfo> mesas = ObtenerMesas("WHERE Ocupado = 0");

            ConstruirBotonesMesas(mesas);
        }

        private Button CrearBotonMesa(int id, string numero, string capacidad, int ocupado, int reservado, List<string> unidas)
        {
            Button btn = new Button();
            btn.Width = 150;
            btn.Height = 100;
            btn.Margin = new Padding(10);
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            if (reservado == 1)
                btn.BackColor = Color.MediumPurple;
            else if (ocupado == 1)
                btn.BackColor = Color.LightCoral;
            else
                btn.BackColor = Color.LightGreen;

            btn.Tag = new
            {
                Id = id,
                Numero = numero,
                Estado = ocupado,
                Reservado = reservado,
                ListaMesas = unidas
            };

            string textoUnidas = unidas.Count > 0 ? string.Join(", ", unidas) : "-";

            btn.Text =
                $"Mesa #{numero}\n" +
                $"Unidas: {textoUnidas}\n" +
                $"Capacidad: {capacidad}";

            btn.Click += BtnMesa_Click;
            return btn;
        }

        private void BtnCrearOrden()
        {
            dynamic mesaInfo = botonActivo.Tag;

            int idMesa = mesaInfo.Id;
            List<string> unidas = mesaInfo.ListaMesas;

            idMesaSeleccionada = idMesa;
            mesasDelGrupo = new List<int>() { idMesa };
            mesasDelGrupo.AddRange(unidas.Select(u => Convert.ToInt32(u)));

            string textoMesas = string.Join(", ", mesasDelGrupo);

            IDMesa = idMesa;

            MesaLabel.Text = $"     Mesa asignada: {textoMesas}";

            EditarEstado = 0;
        }

        private void CargarMenu()
        {
            MenuFlowP.Controls.Clear();

            using (SqlConnection cn = new SqlConnection(conexionString))
            {
                cn.Open();

                string sql = @"
                SELECT 
                    p.IdProducto,
                    p.Nombre,
                    p.PrecioVenta,
                    p.Itbis,
                    c.Nombre AS Categoria
                FROM ProductoVenta p
                LEFT JOIN CategoriaProducto c ON p.IdCategoria = c.IdCategoria
                WHERE p.Activo = 1 AND p.IdProductoTipo = 2 or p.IdProductoTipo = 3";


                using (SqlCommand cmd = new SqlCommand(sql, cn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr["IdProducto"]);
                        string nombre = dr["Nombre"].ToString();
                        string categoria = dr["Categoria"].ToString();
                        decimal precio = Convert.ToDecimal(dr["PrecioVenta"]);
                        decimal itbis = Convert.ToDecimal(dr["Itbis"]);

                        MenuFlowP.Controls.Add(
                            CrearTarjetaProducto(id, nombre, categoria, precio, itbis)
                        );
                    }
                }
            }

            siguiente.Enabled = false;
        }

        private Panel CrearTarjetaProducto(int id, string nombre, string categoria, decimal precio, decimal itbis)
        {
            Panel card = new Panel();
            card.Width = 180;
            card.Height = 220;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.BackColor = Color.WhiteSmoke;
            card.Cursor = Cursors.Hand;
            card.Margin = new Padding(10);

            PictureBox img = new PictureBox();
            img.Size = new Size(160, 120);
            img.Location = new Point(10, 10);
            img.SizeMode = PictureBoxSizeMode.Zoom;

            string imgPath = $@"C:\SistemaArchivos\Productos\{id}.jpg";

            if (File.Exists(imgPath))
                img.Image = Image.FromFile(imgPath);
            else
                img.Image = Properties.Resources.paisaje;

            Label lblNombre = new Label();
            lblNombre.Text = nombre;
            lblNombre.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNombre.AutoSize = false;
            lblNombre.Width = 160;
            lblNombre.Location = new Point(10, 135);

            Label lblCategoria = new Label();
            lblCategoria.Text = categoria;
            lblCategoria.Font = new Font("Segoe UI", 9);
            lblCategoria.ForeColor = Color.Gray;
            lblCategoria.AutoSize = false;
            lblCategoria.Width = 160;
            lblCategoria.Location = new Point(10, 155);

            Label lblPrecio = new Label();
            lblPrecio.Text = $"RD$ {precio:N2}";
            lblPrecio.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPrecio.ForeColor = Color.SeaGreen;
            lblPrecio.AutoSize = false;
            lblPrecio.Width = 160;
            lblPrecio.Location = new Point(10, 175);

            card.Controls.Add(img);
            card.Controls.Add(lblNombre);
            card.Controls.Add(lblCategoria);
            card.Controls.Add(lblPrecio);

            card.Click += (s, e) => SeleccionarProducto(id, nombre, precio, itbis);
            img.Click += (s, e) => SeleccionarProducto(id, nombre, precio, itbis);
            lblNombre.Click += (s, e) => SeleccionarProducto(id, nombre, precio, itbis);
            lblCategoria.Click += (s, e) => SeleccionarProducto(id, nombre, precio, itbis);
            lblPrecio.Click += (s, e) => SeleccionarProducto(id, nombre, precio, itbis);


            return card;
        }

        private void SeleccionarProducto(int id, string nombre, decimal precio, decimal itbis)
        {
            txtcodigoproducto.Text = id.ToString();
            txtnombreproducto.Text = nombre;
            txtprecioproducto.Text = precio.ToString("N2");
            txtiva.Text = itbis.ToString("N2");

            numCantidad.Value = 1;
            numCantidad.Focus();
        }

        private void editarOrden_Click(object sender, EventArgs e)
        {
            EditarEstado = 1;

            mesapanel.Visible = true;
            panelOrdenar.Visible = false;
            infoAdicional.Visible = false;

            CargarMesasOcupadas();

            PasoActual = 0;
            atras.Enabled = false;
        }

        private void CargarMesasOcupadas()
        {
            panelMesas.Controls.Clear();

            List<MesaInfo> mesas = ObtenerMesas("WHERE Ocupado = 1");

            ConstruirBotonesMesas(mesas);
        }

        private List<MesaInfo> ObtenerMesas(string filtro)
        {
            List<MesaInfo> mesas = new List<MesaInfo>();

            using (SqlConnection cn = new SqlConnection(conexionString))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand($@"
                SELECT IdMesa, Numero, Capacidad, Ocupado, Reservado, IdGrupo, EsPrincipal 
                FROM Mesa {filtro}", cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mesas.Add(new MesaInfo
                    {
                        Id = Convert.ToInt32(dr["IdMesa"]),
                        Numero = dr["Numero"]?.ToString(),
                        Capacidad = dr["Capacidad"]?.ToString(),
                        Ocupado = Convert.ToInt32(dr["Ocupado"]),
                        Reservado = Convert.ToInt32(dr["Reservado"]),
                        IdGrupo = Convert.ToInt32(dr["IdGrupo"]),
                        EsPrincipal = Convert.ToInt32(dr["EsPrincipal"])
                    });
                }
            }

            return mesas;
        }


        private void ConstruirBotonesMesas(List<MesaInfo> mesas)
        {
            panelMesas.Controls.Clear();

            var individuales = mesas.Where(m => m.IdGrupo == 0).ToList();

            foreach (var mesa in individuales)
            {
                panelMesas.Controls.Add(
                    CrearBotonMesa(
                        mesa.Id,
                        mesa.Numero,
                        mesa.Capacidad,
                        mesa.Ocupado,
                        mesa.Reservado,
                        mesa.ListaMesas
                    )
                );
            }

            var grupos = mesas.Where(m => m.IdGrupo > 0).GroupBy(m => m.IdGrupo);

            foreach (var grupo in grupos)
            {
                MesaInfo principal = grupo.FirstOrDefault(m => m.EsPrincipal == 1) ?? grupo.First();

                var secundarias = grupo.Where(m => m.Id != principal.Id).ToList();
                var unidas = secundarias.Select(x => x.Numero).ToList();

                principal.Capacidad = grupo.Sum(m => Convert.ToInt32(m.Capacidad)).ToString();
                principal.ListaMesas = unidas;

                panelMesas.Controls.Add(
                    CrearBotonMesa(
                        principal.Id,
                        principal.Numero,
                        principal.Capacidad,
                        principal.Ocupado,
                        principal.Reservado,
                        principal.ListaMesas
                    )
                );
            }
        }

        private void CargarOrdenDeMesa(int idMesa, int numMesa)
        {
            using (SqlConnection cn = new SqlConnection(conexionString))
            {
                cn.Open();

                string sqlCOM = @"
                SELECT TOP 1 IdPedido, Fecha, IdMesa, IdClientePersona, 
                       NombreCliente, Total, Nota, Comprobante
                FROM Pedido
                WHERE IdMesa = @IdMesa AND Estado = 'Pendiente'
                ORDER BY Fecha DESC;";

                int idPedido = 0;

                using (SqlCommand cmd = new SqlCommand(sqlCOM, cn))
                {
                    cmd.Parameters.AddWithValue("@IdMesa", idMesa);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.Read())
                        {
                            MessageBox.Show("La mesa no tiene ordenes pendientes.");
                            PasoActual = 1;
                            atras_Click(null, null);
                            return;
                        }

                        idPedido = Convert.ToInt32(dr["IdPedido"]);
                        PedidoID = idPedido;

                        fechapedido.Value = Convert.ToDateTime(dr["Fecha"]);
                        idclientetxt.Text = dr["IdClientePersona"].ToString();
                        txtnombrecompleto.Text = dr["NombreCliente"].ToString();
                        labeltotal.Text = Convert.ToDecimal(dr["Total"]).ToString();
                        notatxt.Text = dr["Nota"] == DBNull.Value ? "" : dr["Nota"].ToString();

                        cargandoOrden = true;

                        Comprobantetxt.Text = dr["Comprobante"] == DBNull.Value ? "" : dr["Comprobante"].ToString();

                        MesaLabel.Text = $"     Mesa asignada: {NumeroMesa}";
                    }
                }

                DetalleOrden(idPedido, cn);

                var cuentas = ObtenerCuentasDelPedido(idPedido);

                grupoCuenta.Items.Clear();

                grupoCuenta.DataSource = null;

                gruposMinimos = cuentas.Count;

                listaGrupos = cuentas.Select(c => new CuentaItem { Cuenta = c }).ToList();

                grupoCuenta.DisplayMember = "NombreGrupo";
                grupoCuenta.ValueMember = "Cuenta";
                grupoCuenta.DataSource = listaGrupos;

                if (grupoCuenta.Items.Count > 0)
                {
                    grupoCuenta.SelectedIndex = 0;
                    panelCuentaSeparada.Enabled = true;
                    AvisoCuentaSeparada.Visible = true;
                }

                tipoComp.SelectedIndex = -1;

                tipoComp.Enabled = false;

                cargandoOrden = false;

                mesapanel.Location = new Point(11, 64);
                mesapanel.Visible = true;
                PasoActual = 0;
            }
        }

        private List<decimal> ObtenerCuentasDelPedido(int idPedido)
        {
            List<decimal> cuentas = new List<decimal>();

            string sql = @"SELECT DISTINCT Cuenta 
                   FROM DetallePedido 
                   WHERE IdPedido = @IdPedido
                   ORDER BY Cuenta";

            using (SqlConnection cn = new SqlConnection(conexionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdPedido", idPedido);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cuentas.Add(Convert.ToDecimal(dr["Cuenta"]));
                        }
                    }
                }
            }

            return cuentas;
        }

        private void DetalleOrden(int idPedido, SqlConnection cn)
        {
            string sqlDet = @"
            SELECT  d.IdProducto,
                    d.Cuenta,
                    p.Nombre,
                    d.PrecioUnitario,
                    p.Itbis,
                    d.Cantidad,
                    d.Cantidad * d.PrecioUnitario AS Importe
            FROM DetallePedido d
            INNER JOIN ProductoVenta p ON p.IdProducto = d.IdProducto
            WHERE d.IdPedido =  @IdPedido;";

            using (SqlCommand cmd = new SqlCommand(sqlDet, cn))
            {
                cmd.Parameters.AddWithValue("@IdPedido", idPedido);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    detalleorden.Rows.Clear();

                    while (dr.Read())
                    {
                        int fila = detalleorden.Rows.Add();

                        detalleorden.Rows[fila].Cells["cuenta"].Value = dr["Cuenta"];
                        detalleorden.Rows[fila].Cells["nombreProducto"].Value = dr["Nombre"];
                        detalleorden.Rows[fila].Cells["precio"].Value = dr["PrecioUnitario"];
                        detalleorden.Rows[fila].Cells["ITBIS"].Value = dr["Itbis"];
                        detalleorden.Rows[fila].Cells["cantidad"].Value = dr["Cantidad"];
                        detalleorden.Rows[fila].Cells["subtotal"].Value = dr["Importe"];
                    }
                }
            }
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            if (PasoActual == 0)
            {
                if (idMesaSeleccionada == 0)
                {
                    MessageBox.Show("Debe seleccionar una mesa.");
                    return;
                }

                mesapanel.Visible = false;
                panelOrdenar.Visible = true;

                if (EditarEstado == 0)
                {
                    BtnCrearOrden();
                    CargarMenu();
                }
                else
                {
                    CargarOrdenDeMesa(idMesaSeleccionada, NumeroMesa);
                }

                PasoActual = 1;
                mesapanel.Visible = false;
                panelOrdenar.Location = new Point(11, 64);
                panelOrdenar.BringToFront();
                panelOrdenar.Visible = true;
                mesasOcupadas.Visible = false;

                PasoActual = 1;
                atras.Enabled = true;
            }
            else if (PasoActual == 1 && panelOrdenar.Visible)
            {
                panelOrdenar.Visible = false;
                infoAdicional.Location = new Point(11, 64);
                infoAdicional.BringToFront();
                infoAdicional.Visible = true;

                siguiente.Text = "Guardar";
                siguiente.BackColor = Color.SeaGreen;

                PasoActual = 2;
            }
            else if (PasoActual == 2 && infoAdicional.Visible)
            {
                infoAdicional.Visible = false;
                MessageBox.Show("Orden Terminada.");
                PasoActual = 3;

                GuardarOrden();
                atras.Enabled = false;
            }
        }

        private void atras_Click(object sender, EventArgs e)
        {
            if (PasoActual == 1)
            {
                panelOrdenar.Visible = false;
                mesapanel.Visible = true;

                PasoActual = 0;
                atras.Enabled = false;

                detalleorden.Rows.Clear();
                txtcodigoproducto.Clear();
                txtnombreproducto.Clear();
                txtprecioproducto.Clear();
                txtiva.Clear();
                CuentaSeparada = 0;
                AvisoCuentaSeparada.Visible = false;
                panelCuentaSeparada.Enabled = false;
                grupoCuenta.Items.Clear();
                RecalcularTotales();
                return;
            }
            else if (PasoActual == 2)
            {
                infoAdicional.Visible = false;
                panelOrdenar.Visible = true;

                siguiente.Text = "Siguiente";
                siguiente.BackColor = SystemColors.ButtonHighlight;

                PasoActual = 1;
            }
        }

        private void GuardarOrden()
        {
            bool commitRealizado = false;
            int idPedidoGenerado = 0;

            if (EditarEstado == 0)
            {
                comprobanteFinal = GenerarComprobante();
            }

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    if (EditarEstado == 0)
                    {
                        string queryPedido = @"
                        INSERT INTO Pedido 
                        (Fecha, IdMesa, Origen, IdClientePersona, NombreCliente, Estado, Total, Nota, Comprobante, CreadoPor)
                        VALUES 
                        (@Fecha, @IdMesa, @Origen, @IdClientePersona, @NombreCliente, @Estado, @Total, @Nota, @Comprobante, @Usuario);
                        SELECT SCOPE_IDENTITY();";

                        SqlCommand cmdPedido = new SqlCommand(queryPedido, conexion, transaccion);

                        cmdPedido.Parameters.AddWithValue("@Fecha", fechapedido.Value);
                        cmdPedido.Parameters.AddWithValue("@IdMesa", idMesaSeleccionada);
                        cmdPedido.Parameters.AddWithValue("@Origen", "Local");
                        cmdPedido.Parameters.AddWithValue("@IdClientePersona", Convert.ToInt32(IdClientePersonaST));
                        cmdPedido.Parameters.AddWithValue("@NombreCliente", txtnombrecompleto.Text);
                        cmdPedido.Parameters.AddWithValue("@Estado", "Pendiente");
                        cmdPedido.Parameters.AddWithValue("@Total", Convert.ToDecimal(labeltotal.Text));
                        cmdPedido.Parameters.AddWithValue("@Nota", notatxt.Text);
                        cmdPedido.Parameters.AddWithValue("@Comprobante", comprobanteFinal);
                        cmdPedido.Parameters.AddWithValue("@Usuario", IdUsuario);

                        idPedidoGenerado = Convert.ToInt32(cmdPedido.ExecuteScalar());

                        ActualizarSecuencia(tipoComp.SelectedIndex == 0 ? 1 : 2);
                    }
                    else if (EditarEstado == 1)
                    {
                        idPedidoGenerado = PedidoID;

                        string queryUpdatePedido = @"
                        UPDATE Pedido
                        SET Fecha = @Fecha,
                            IdMesa = @IdMesa,
                            IdClientePersona = @IdClientePersona,
                            NombreCliente = @NombreCliente,
                            Total = @Total,
                            Nota = @Nota
                        WHERE IdPedido = @IdPedido";

                        SqlCommand cmdUpdate = new SqlCommand(queryUpdatePedido, conexion, transaccion);

                        cmdUpdate.Parameters.AddWithValue("@Fecha", fechapedido.Value);
                        cmdUpdate.Parameters.AddWithValue("@IdMesa", idMesaSeleccionada);
                        cmdUpdate.Parameters.AddWithValue("@IdClientePersona", Convert.ToInt32(IdClientePersonaST));
                        cmdUpdate.Parameters.AddWithValue("@NombreCliente", txtnombrecompleto.Text);
                        cmdUpdate.Parameters.AddWithValue("@Total", Convert.ToDecimal(labeltotal.Text));
                        cmdUpdate.Parameters.AddWithValue("@Nota", notatxt.Text);
                        cmdUpdate.Parameters.AddWithValue("@IdPedido", PedidoID);
                        cmdUpdate.ExecuteNonQuery();

                        SqlCommand cmdDeleteDetalle = new SqlCommand(
                            "DELETE FROM DetallePedido WHERE IdPedido = @IdPedido",
                            conexion, transaccion);
                        cmdDeleteDetalle.Parameters.AddWithValue("@IdPedido", PedidoID);
                        cmdDeleteDetalle.ExecuteNonQuery();

                        SqlCommand cmdDeleteComanda = new SqlCommand(
                            "DELETE FROM Comanda WHERE IdPedido = @IdPedido AND Estado = 'Cocina'",
                            conexion, transaccion);
                        cmdDeleteComanda.Parameters.AddWithValue("@IdPedido", PedidoID);
                        cmdDeleteComanda.ExecuteNonQuery();
                    }

                    string queryDetalle = @"
                    INSERT INTO DetallePedido (IdPedido, IdProducto, Cantidad, PrecioUnitario, Cuenta)
                    VALUES (@IdPedido, @IdProducto, @Cantidad, @PrecioUnitario, @Cuenta);";

                    foreach (DataGridViewRow fila in detalleorden.Rows)
                    {
                        if (fila.IsNewRow) continue;

                        SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion);
                        cmdDetalle.Parameters.AddWithValue("@IdPedido", idPedidoGenerado);
                        cmdDetalle.Parameters.AddWithValue("@IdProducto", Convert.ToInt32(fila.Cells["codigoProducto"].Value));
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", Convert.ToDecimal(fila.Cells["Cantidad"].Value));
                        cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", Convert.ToDecimal(fila.Cells["Precio"].Value));
                        cmdDetalle.Parameters.AddWithValue("@Cuenta", Convert.ToDecimal(fila.Cells["cuenta"].Value));

                        cmdDetalle.ExecuteNonQuery();
                    }

                    string queryInsertarComanda = @"
                    INSERT INTO Comanda (IdPedido, IdMesa, IdProducto, Cantidad, Estado, Cuenta)
                    VALUES (@IdPedido, @IdMesa, @IdProducto, @Cantidad, @Estado, @Cuenta);";

                    foreach (DataGridViewRow fila in detalleorden.Rows)
                    {
                        if (fila.IsNewRow) continue;

                        SqlCommand cmdComanda = new SqlCommand(queryInsertarComanda, conexion, transaccion);

                        cmdComanda.Parameters.AddWithValue("@IdPedido", idPedidoGenerado);
                        cmdComanda.Parameters.AddWithValue("@IdMesa", idMesaSeleccionada);
                        cmdComanda.Parameters.AddWithValue("@IdProducto", Convert.ToInt32(fila.Cells["codigoProducto"].Value));
                        cmdComanda.Parameters.AddWithValue("@Cantidad", Convert.ToDecimal(fila.Cells["Cantidad"].Value));
                        cmdComanda.Parameters.AddWithValue("@Cuenta", Convert.ToDecimal(fila.Cells["cuenta"].Value));
                        cmdComanda.Parameters.AddWithValue("@Estado", "Cocina");

                        cmdComanda.ExecuteNonQuery();
                    }

                    string queryMesa = "UPDATE Mesa SET Ocupado = 1 WHERE IdMesa = @IdMesa";

                    foreach (int mesa in mesasDelGrupo)
                    {
                        SqlCommand cmdMesa = new SqlCommand(queryMesa, conexion, transaccion);
                        cmdMesa.Parameters.AddWithValue("@IdMesa", mesa);
                        cmdMesa.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                    commitRealizado = true;

                    if (commitRealizado == true && EditarEstado == 0)
                        MessageBox.Show("Orden creada con éxito.");
                    else if (commitRealizado == true && EditarEstado == 1)
                        MessageBox.Show("Orden actualizada con éxito.");

                    EditarEstado = 0;
                    mesasOcupadas.Visible = true;
                    mesasOcupadas.BringToFront();
                    barraAcciones.Visible = false;
                    infoAdicional.Visible = false;
                    panelOrdenar.Visible = false;
                    mesapanel.Visible = false;
                    TabletSistema_Load(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la orden: " + ex.Message);

                    if (!commitRealizado)
                    {
                        try { transaccion.Rollback(); } catch { }
                    }

                    EditarEstado = 0;
                    mesasOcupadas.Visible = true;
                    mesasOcupadas.BringToFront();
                    barraAcciones.Visible = false;
                    infoAdicional.Visible = false;
                    panelOrdenar.Visible = false;
                    mesapanel.Visible = false;
                    TabletSistema_Load(null, null);
                }
            }
        }

        private string GenerarComprobante()
        {
            string prefijo = "";

            if (tipoComp.SelectedIndex == 0)
                prefijo = "B01";
            else if (tipoComp.SelectedIndex == 1)
                prefijo = "B02";

            string secuencia = Comprobantetxt.Text;

            secuencia = int.Parse(secuencia).ToString("00000000");

            return prefijo + secuencia;
        }

        private void ActualizarSecuencia(int tipo)
        {
            string sql = @"
            UPDATE Comprobantes
            SET SecuenciaActual = SecuenciaActual + 1
            WHERE Tipo = @Tipo";

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Tipo", tipo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void mas_Click(object sender, EventArgs e)
        {
            if (numCantidad.Value < numCantidad.Maximum)
            {
                numCantidad.Value += 1;
            }
        }

        private void menos_Click(object sender, EventArgs e)
        {
            if (numCantidad.Value > numCantidad.Minimum)
            {
                numCantidad.Value -= 1;
            }
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            string codigoProducto = txtcodigoproducto.Text;
            string nombreProducto = txtnombreproducto.Text;

            if (txtcodigoproducto.Text == "")
            {
                MessageBox.Show("Agregar producto.");
                return;
            }

            if (!decimal.TryParse(txtprecioproducto.Text, out decimal precio))
            {
                MessageBox.Show("Precio inválido.");
                return;
            }

            if (!decimal.TryParse(txtiva.Text, out decimal itbis))
            {
                MessageBox.Show("ITBIS inválido.");
                return;
            }

            int cantidad = (int)numCantidad.Value;

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(detalleorden);

            if (grupoCuenta.Items.Count > 0 || CuentaSeparada == 1)
            {
                int grupoNumero = Convert.ToInt32(grupoCuenta.SelectedValue);

                row.Cells[0].Value = grupoNumero;
                row.Cells[1].Value = codigoProducto;
                row.Cells[2].Value = nombreProducto;
                row.Cells[3].Value = precio;
                row.Cells[4].Value = itbis;
                row.Cells[5].Value = cantidad;
            }
            else
            {
                row.Cells[0].Value = "0";
                row.Cells[1].Value = codigoProducto;
                row.Cells[2].Value = nombreProducto;
                row.Cells[3].Value = precio;
                row.Cells[4].Value = itbis;
                row.Cells[5].Value = cantidad;
            }

            detalleorden.Rows.Add(row);

            RecalcularTotales();

            txtcodigoproducto.Clear();
            txtnombreproducto.Clear();
            txtprecioproducto.Clear();
            txtiva.Clear();
            numCantidad.Value = 1;

            siguiente.Enabled = true;
        }

        private void RecalcularTotales()
        {
            decimal subtotal = 0;
            decimal total = 0;

            foreach (DataGridViewRow fila in detalleorden.Rows)
            {
                if (fila.IsNewRow) continue;

                decimal precio = Convert.ToDecimal(fila.Cells["precio"].Value);
                decimal itbis = Convert.ToDecimal(fila.Cells["itbis"].Value);
                int cantidad = Convert.ToInt32(fila.Cells["cantidad"].Value);

                decimal sub = precio * cantidad;
                decimal tot = sub + (sub * (itbis / 100));

                subtotal += sub;
                total += tot;
            }

            labelsubtotal.Text = subtotal.ToString("F2");
            labeltotal.Text = total.ToString("F2");
        }

        private void buscarclientebtn_Click(object sender, EventArgs e)
        {
            panelclientes.Location = new Point(13, 14);
            panelclientes.BringToFront();
            panelclientes.Visible = true;

            string consultaCliente = @"
            SELECT 
                e.IdCliente,
                e.IdPersona,
                p.NombreCompleto AS Nombre,
                pd.Numero AS Cedula,
                tl.Numero AS Telefono,
                pd.IdTipoDocumento AS TipoDoc
            FROM Cliente e
            LEFT JOIN Persona p ON e.IdPersona = p.IdPersona
            LEFT JOIN PersonaDocumento pd ON p.IdPersona = pd.IdPersona
            LEFT JOIN PersonaTelefono tl ON p.IdPersona = tl.IdPersona AND tl.EsPrincipal = 1
            WHERE e.Activo = 1 AND p.Activo = 1 AND e.IdCliente > 1;"; //Esto es para que no traiga AL CONTADO directamente sino que traiga los demas clientes

            using (SqlDataAdapter adaptador = new SqlDataAdapter(consultaCliente, conexionString))
            {
                DataTable dt = new DataTable();

                adaptador.Fill(dt);

                tablaclientes.DataSource = dt;

                if (tablaclientes.Columns.Contains("TipoDoc"))
                    tablaclientes.Columns["TipoDoc"].Visible = false;

                if (tablaclientes.Columns.Contains("IdPersona"))
                    tablaclientes.Columns["IdPersona"].Visible = false;

            }
        }

        private void salirCliente_Click(object sender, EventArgs e)
        {
            panelclientes.Location = new Point(642, 7);
            panelclientes.Visible = false;
        }

        private void separarcuenta_Click(object sender, EventArgs e)
        {
            if (CuentaSeparada == 1)
            {
                MessageBox.Show("La cuenta ya está separada.");
                return;
            }
            else
            {
                DialogResult confirmar = MessageBox.Show("Activar Cuenta Separada LIMPIA la orden actual", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmar == DialogResult.Yes)
                {
                    panelCuentaSeparada.Enabled = true;
                    CuentaSeparada = 1;
                    separarcuenta.BackColor = Color.Gold;
                    detalleorden.Rows.Clear();
                    nuevoGrupo.PerformClick();
                    AvisoCuentaSeparada.Visible = true;
                    separarcuenta.Enabled = false;
                }
            }
        }

        private void nuevoGrupo_Click(object sender, EventArgs e)
        {
            decimal nuevaCuenta;

            if (listaGrupos.Count == 0)
                nuevaCuenta = 1;
            else
                nuevaCuenta = listaGrupos.Max(g => g.Cuenta) + 1;

            listaGrupos.Add(new CuentaItem { Cuenta = nuevaCuenta });

            RefrescarComboGrupos();

            grupoCuenta.SelectedValue = nuevaCuenta;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listaGrupos.Count <= gruposMinimos)
            {
                MessageBox.Show("No puede eliminar más grupos.\nLa orden original tiene " + gruposMinimos + " grupos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            decimal cuentaActual = Convert.ToDecimal(grupoCuenta.SelectedValue);

            var grupo = listaGrupos.FirstOrDefault(g => g.Cuenta == cuentaActual);
            listaGrupos.Remove(grupo);

            RefrescarComboGrupos();

            if (grupoCuenta.Items.Count > 0)
                grupoCuenta.SelectedIndex = grupoCuenta.Items.Count - 1;
        }

        private void RefrescarComboGrupos()
        {
            grupoCuenta.DataSource = null;
            grupoCuenta.DisplayMember = "NombreGrupo";
            grupoCuenta.ValueMember = "Cuenta";
            grupoCuenta.DataSource = listaGrupos.ToList();
        }

        private void eliminarFila_Click(object sender, EventArgs e)
        {
            if (EditarEstado == 1)
            {
                int filasActuales = detalleorden.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);

                int filasSeleccionadas = detalleorden.SelectedRows.Count;

                if (filasActuales - filasSeleccionadas <= 0)
                {
                    MessageBox.Show("No puede eliminar todas las filas de una orden existente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            foreach (DataGridViewRow fila in detalleorden.SelectedRows)
            {
                if (!fila.IsNewRow)
                    detalleorden.Rows.Remove(fila);
            }

            RecalcularTotales();
            RecalcularGruposMinimos();
            LimpiarGruposVacios();
        }

        private void RecalcularGruposMinimos()
        {
            var gruposConProductos =
                detalleorden.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["cuenta"].Value != null && r.Cells["cuenta"].Value.ToString() != "")
                .Select(r => Convert.ToDecimal(r.Cells["cuenta"].Value))
                .Distinct()
                .ToList();

            gruposMinimos = gruposConProductos.Count == 0 ? 1 : gruposConProductos.Count;
        }

        private void LimpiarGruposVacios()
        {
            var gruposConProductos =
                detalleorden.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["cuenta"].Value != null && r.Cells["cuenta"].Value.ToString() != "")
                .Select(r => Convert.ToDecimal(r.Cells["cuenta"].Value))
                .Distinct()
                .ToList();

            listaGrupos = listaGrupos
                .Where(g => gruposConProductos.Contains(g.Cuenta))
                .ToList();

            RefrescarComboGrupos();
        }

        private void tablaclientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idclientetxt.Clear();
                txtnombrecompleto.Clear();
                rnc.Clear();
                numerotxt.Clear();

                DataGridViewRow row = tablaclientes.Rows[e.RowIndex];
                string idCLiente = row.Cells["IdCliente"].Value.ToString();
                string nombreCompleto = row.Cells["Nombre"].Value.ToString();
                string CedulaCliente = row.Cells["Cedula"].Value.ToString();
                string telefono = row.Cells["Telefono"].Value.ToString();
                string IdClientePersona = row.Cells["IdPersona"].Value.ToString();

                idclientetxt.Text = idCLiente;
                txtnombrecompleto.Text = nombreCompleto;
                rnc.Text = CedulaCliente;
                numerotxt.Text = telefono;
                IdClientePersonaST = IdClientePersona;

                int tipoDoc = Convert.ToInt32(tablaclientes.CurrentRow.Cells["TipoDoc"].Value);

                if (tipoDoc == 1)
                {
                    tipodoccmbx.SelectedIndex = 1;
                }
                else if (tipoDoc == 5) //Por alguna razón el RNC está como 5 en la base de datos
                {
                    tipodoccmbx.SelectedIndex = 0;
                }
            }

            panelclientes.Visible = false;
            panelclientes.Location = new Point(803, 532);
        }

        private void tipoComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Comprobantes();
        }

        private void comandaVer_Click(object sender, EventArgs e)
        {
            CargarComanda();

            panelComanda.Location = new Point(11, 64);
            panelComanda.BringToFront();
            panelComanda.Visible = true;
            button1.Visible = true;
        }

        private void CargarComanda()
        {
            flowComanda.Controls.Clear();

            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();

                string query = @"
                SELECT CM.IdPedido, CM.Cuenta, CM.IdProducto, PV.Nombre, CM.Cantidad
                FROM Comanda CM
                INNER JOIN ProductoVenta PV ON CM.IdProducto = PV.IdProducto
                WHERE CM.Estado = 'Cocina'
                ORDER BY CM.IdPedido, CM.Cuenta";

                SqlCommand cmd = new SqlCommand(query, conexion);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int idPedido = Convert.ToInt32(dr["IdPedido"]);
                        int idProducto = Convert.ToInt32(dr["IdProducto"]);
                        int cuenta = Convert.ToInt32(dr["Cuenta"]);
                        string nombre = dr["Nombre"].ToString();
                        int cantidad = Convert.ToInt32(dr["Cantidad"]);

                        Image img = CargarImagen(Convert.ToInt32(dr["IdProducto"]));

                        Panel card = BotonComanda(idPedido, cuenta, nombre, cantidad, img, idProducto);

                        flowComanda.Controls.Add(card);
                    }
                }
            }
        }

        private Panel BotonComanda(int idPedido, int cuenta, string nombre, int cantidad, Image imagen, int idProducto)
        {
            Panel card = new Panel();
            card.Width = 200;
            card.Height = 260;
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(15);
            card.Cursor = Cursors.Hand;

            card.Tag = new
            {
                Pedido = idPedido,
                Cuenta = cuenta,
                Producto = nombre,
                Cantidad = cantidad,
                IdProducto = idProducto
            };

            PictureBox pic = new PictureBox();
            pic.Width = 190;
            pic.Height = 120;
            pic.Top = 5;
            pic.Left = 5;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Image = imagen ?? Properties.Resources.paisaje;

            Label lbl = new Label();
            lbl.Width = 190;
            lbl.Height = 120;
            lbl.Left = 5;
            lbl.Top = 130;
            lbl.TextAlign = ContentAlignment.TopLeft;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lbl.Text =
                $"ORDEN: {idPedido}\n" +
                $"CUENTA: {cuenta}\n\n" +
                $"{nombre.ToUpper()}\n" +
                $"CANTIDAD: {cantidad}";

            card.Click += BotonComanda_Click;
            pic.Click += BotonComanda_Click;
            lbl.Click += BotonComanda_Click;

            card.Controls.Add(pic);
            card.Controls.Add(lbl);

            return card;
        }


        private void BotonComanda_Click(object sender, EventArgs e)
        {
            if (!modoEntregar)
                return;

            Panel card = ObtenerPanelPadre(sender);
            if (card == null) return;

            if (ordenesSeleccionadas.Contains(card))
            {
                ordenesSeleccionadas.Remove(card);
                card.BackColor = Color.White;
            }
            else
            {
                ordenesSeleccionadas.Add(card);
                card.BackColor = Color.LightBlue;
            }
        }

        private Panel ObtenerPanelPadre(object sender)
        {
            if (sender is Panel p) return p;
            if (sender is Control c && c.Parent is Panel p2) return p2;
            return null;
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

        private void salirComanda_Click(object sender, EventArgs e)
        {
            panelComanda.Visible = false;
            mesasOcupadas.BringToFront();
            panelComanda.Location = new Point(1419, 5);
            NotifComanda();

        }

        private void NotifComanda()
        {
            string sql = "SELECT COUNT(*) FROM Comanda WHERE Estado = 'Cocina'";

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                    if (cantidad > 0)
                    {
                        ordenesNotif.Visible = true;
                    }
                    else
                    {
                        ordenesNotif.Visible = false;
                    }
                }
            }
        }

        private void SiEntrega_Click(object sender, EventArgs e)
        {
            if (ordenesSeleccionadas.Count == 0)
            {
                MessageBox.Show("No hay órdenes seleccionadas.");
                return;
            }

            using (SqlConnection cn = new SqlConnection(conexionString))
            {
                cn.Open();

                foreach (var btn in ordenesSeleccionadas)
                {
                    dynamic info = btn.Tag;

                    SqlCommand cmd = new SqlCommand(
                    @"UPDATE Comanda 
                    SET Estado = 'Entregado'
                    WHERE IdPedido = @p AND Cuenta = @c AND IdProducto = @prod",
                    cn);

                    cmd.Parameters.AddWithValue("@p", info.Pedido);
                    cmd.Parameters.AddWithValue("@c", info.Cuenta);
                    cmd.Parameters.AddWithValue("@prod", info.IdProducto);

                    cmd.ExecuteNonQuery();
                }

                EntregarOrden.BackColor = Color.FromArgb(224, 224, 224);
            }

            MessageBox.Show("Órdenes marcadas como entregadas.");
            CargarComanda();
        }

        private void NoEntrega_Click(object sender, EventArgs e)
        {
            modoEntregar = false;
            ordenesSeleccionadas.Clear();
            LimpiarSeleccionVisual();
            SiEntrega.Visible = false;
            NoEntrega.Visible = false;

            EntregarOrden.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void LimpiarSeleccionVisual()
        {
            foreach (Control ctrl in flowComanda.Controls)
            {
                if (ctrl is Panel panel)
                    panel.BackColor = Color.White;
            }
        }

        private void EntregarOrden_Click(object sender, EventArgs e)
        {
            modoEntregar = true;
            EntregarOrden.BackColor = Color.Gold;
            SiEntrega.Visible = true;
            NoEntrega.Visible = true;
        }
    }
}