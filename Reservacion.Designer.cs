namespace Proyecto_restaurante
{
    partial class Reservacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reservacion));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            PanelClientes = new Panel();
            RegresarBtn = new Button();
            eliminarbtn = new Button();
            label17 = new Label();
            label19 = new Label();
            txtbuscador = new TextBox();
            tabladatoscliente = new DataGridView();
            recargarbtn = new Button();
            panel7 = new Panel();
            label21 = new Label();
            filtrochk = new CheckBox();
            detallepanelcompleto = new Panel();
            bloqueopanel = new Panel();
            pictureBox3 = new PictureBox();
            label13 = new Label();
            devueltapanel = new Panel();
            devueltatxt = new TextBox();
            label32 = new Label();
            label31 = new Label();
            button13 = new Button();
            panel12 = new Panel();
            pagadotxt = new TextBox();
            label30 = new Label();
            totalpagar = new TextBox();
            label29 = new Label();
            detallepagopanel = new Panel();
            tabControl2 = new TabControl();
            tabPage3 = new TabPage();
            efectivodt = new DataGridView();
            label18 = new Label();
            label16 = new Label();
            button3 = new Button();
            pagarefectivo = new Button();
            aplicarefectivo = new Button();
            totalrealef = new TextBox();
            efectivotxt = new TextBox();
            tabPage5 = new TabPage();
            tarjetacmbx = new ComboBox();
            tarjetadt = new DataGridView();
            label27 = new Label();
            label23 = new Label();
            label24 = new Label();
            button6 = new Button();
            pagartarjeta = new Button();
            aplicartarjeta = new Button();
            totalrealtar = new TextBox();
            tarjetaref = new TextBox();
            tabPage4 = new TabPage();
            transferenciadt = new DataGridView();
            bancocmbx = new ComboBox();
            label28 = new Label();
            label25 = new Label();
            label26 = new Label();
            button10 = new Button();
            pagartransf = new Button();
            aplicartransf = new Button();
            totalrealtransf = new TextBox();
            bancoref = new TextBox();
            label15 = new Label();
            flowmesa = new FlowLayoutPanel();
            panel2 = new Panel();
            label4 = new Label();
            label3 = new Label();
            panel8 = new Panel();
            notabtn = new Button();
            CantidadPersonasNUD = new NumericUpDown();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            fecreservacion = new DateTimePicker();
            notapanel = new Panel();
            notatxt = new TextBox();
            panel1 = new Panel();
            panel4 = new Panel();
            fechacreacionreserva = new DateTimePicker();
            nuevobtn = new Button();
            label11 = new Label();
            guardareservabtn = new Button();
            txtnumero_cliente = new TextBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label20 = new Label();
            label1 = new Label();
            buscarclientebtn = new Button();
            idclientetxt = new TextBox();
            txtidreserva = new TextBox();
            txtnombrecompleto = new TextBox();
            tabPage2 = new TabPage();
            label14 = new Label();
            label10 = new Label();
            txtbusquedareserva = new TextBox();
            panel3 = new Panel();
            cancelarreservabtn = new Button();
            label8 = new Label();
            ordenbtn = new Button();
            label9 = new Label();
            fecini = new DateTimePicker();
            fecfin = new DateTimePicker();
            ReservacionMesasDGV = new DataGridView();
            panel10 = new Panel();
            label12 = new Label();
            pendientechk = new CheckBox();
            todoschk = new CheckBox();
            canceladochk = new CheckBox();
            panel6 = new Panel();
            toolTip1 = new ToolTip(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            PanelClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabladatoscliente).BeginInit();
            panel7.SuspendLayout();
            detallepanelcompleto.SuspendLayout();
            bloqueopanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            devueltapanel.SuspendLayout();
            panel12.SuspendLayout();
            detallepagopanel.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)efectivodt).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tarjetadt).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)transferenciadt).BeginInit();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CantidadPersonasNUD).BeginInit();
            notapanel.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReservacionMesasDGV).BeginInit();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 12F);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(850, 510);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(87, 128, 87);
            tabPage1.Controls.Add(PanelClientes);
            tabPage1.Controls.Add(detallepanelcompleto);
            tabPage1.Controls.Add(flowmesa);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel8);
            tabPage1.Controls.Add(panel1);
            tabPage1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage1.ForeColor = SystemColors.ControlText;
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(842, 476);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Reservar";
            // 
            // PanelClientes
            // 
            PanelClientes.BackColor = Color.FromArgb(64, 64, 64);
            PanelClientes.Controls.Add(RegresarBtn);
            PanelClientes.Controls.Add(eliminarbtn);
            PanelClientes.Controls.Add(label17);
            PanelClientes.Controls.Add(label19);
            PanelClientes.Controls.Add(txtbuscador);
            PanelClientes.Controls.Add(tabladatoscliente);
            PanelClientes.Controls.Add(recargarbtn);
            PanelClientes.Controls.Add(panel7);
            PanelClientes.Dock = DockStyle.Fill;
            PanelClientes.Location = new Point(3, 3);
            PanelClientes.Name = "PanelClientes";
            PanelClientes.Size = new Size(836, 470);
            PanelClientes.TabIndex = 11;
            PanelClientes.Visible = false;
            // 
            // RegresarBtn
            // 
            RegresarBtn.Cursor = Cursors.Hand;
            RegresarBtn.Image = Properties.Resources.atrás;
            RegresarBtn.Location = new Point(735, 11);
            RegresarBtn.Name = "RegresarBtn";
            RegresarBtn.Size = new Size(87, 39);
            RegresarBtn.TabIndex = 161;
            RegresarBtn.Text = "          ";
            RegresarBtn.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(RegresarBtn, "Regresar");
            RegresarBtn.UseVisualStyleBackColor = true;
            RegresarBtn.Click += RegresarBtn_Click;
            // 
            // eliminarbtn
            // 
            eliminarbtn.Cursor = Cursors.Hand;
            eliminarbtn.Image = Properties.Resources.limpio;
            eliminarbtn.Location = new Point(799, 84);
            eliminarbtn.Name = "eliminarbtn";
            eliminarbtn.Size = new Size(31, 29);
            eliminarbtn.TabIndex = 56;
            toolTip1.SetToolTip(eliminarbtn, "Limpiar Busqueda");
            eliminarbtn.UseVisualStyleBackColor = true;
            eliminarbtn.Click += eliminarbtn_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = SystemColors.Control;
            label17.Location = new Point(357, 13);
            label17.Name = "label17";
            label17.Size = new Size(104, 32);
            label17.TabIndex = 57;
            label17.Text = "Clientes";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.White;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label19.ForeColor = SystemColors.Control;
            label19.Image = Properties.Resources.busqueda;
            label19.Location = new Point(682, 89);
            label19.Name = "label19";
            label19.Size = new Size(18, 21);
            label19.TabIndex = 52;
            label19.Text = "  ";
            // 
            // txtbuscador
            // 
            txtbuscador.CharacterCasing = CharacterCasing.Upper;
            txtbuscador.Font = new Font("Segoe UI", 12F);
            txtbuscador.ForeColor = SystemColors.ScrollBar;
            txtbuscador.Location = new Point(3, 85);
            txtbuscador.Name = "txtbuscador";
            txtbuscador.PlaceholderText = "Buscar Cliente";
            txtbuscador.Size = new Size(701, 29);
            txtbuscador.TabIndex = 53;
            txtbuscador.TextChanged += txtbuscador_TextChanged;
            // 
            // tabladatoscliente
            // 
            tabladatoscliente.AllowUserToAddRows = false;
            tabladatoscliente.AllowUserToDeleteRows = false;
            tabladatoscliente.AllowUserToResizeRows = false;
            tabladatoscliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabladatoscliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabladatoscliente.Location = new Point(3, 119);
            tabladatoscliente.MultiSelect = false;
            tabladatoscliente.Name = "tabladatoscliente";
            tabladatoscliente.ReadOnly = true;
            tabladatoscliente.RowHeadersVisible = false;
            tabladatoscliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabladatoscliente.Size = new Size(827, 351);
            tabladatoscliente.TabIndex = 54;
            tabladatoscliente.CellDoubleClick += tabladatoscliente_CellDoubleClick;
            // 
            // recargarbtn
            // 
            recargarbtn.Cursor = Cursors.Hand;
            recargarbtn.Image = Properties.Resources.actualizar;
            recargarbtn.Location = new Point(10, 23);
            recargarbtn.Name = "recargarbtn";
            recargarbtn.Size = new Size(29, 29);
            recargarbtn.TabIndex = 55;
            recargarbtn.UseVisualStyleBackColor = true;
            recargarbtn.Click += recargarbtn_Click;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.WindowFrame;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(label21);
            panel7.Controls.Add(filtrochk);
            panel7.Location = new Point(710, 83);
            panel7.Name = "panel7";
            panel7.Size = new Size(86, 32);
            panel7.TabIndex = 66;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label21.ForeColor = SystemColors.WindowFrame;
            label21.Image = Properties.Resources.filtroblanco;
            label21.Location = new Point(6, 5);
            label21.Name = "label21";
            label21.Size = new Size(18, 21);
            label21.TabIndex = 38;
            label21.Text = "  ";
            // 
            // filtrochk
            // 
            filtrochk.AutoSize = true;
            filtrochk.BackColor = SystemColors.WindowFrame;
            filtrochk.Checked = true;
            filtrochk.CheckState = CheckState.Checked;
            filtrochk.Cursor = Cursors.Hand;
            filtrochk.Font = new Font("Segoe UI", 13F);
            filtrochk.Image = Properties.Resources.sicheck;
            filtrochk.Location = new Point(35, 1);
            filtrochk.Name = "filtrochk";
            filtrochk.Size = new Size(41, 29);
            filtrochk.TabIndex = 65;
            filtrochk.Text = "  ";
            toolTip1.SetToolTip(filtrochk, "Estado Activo");
            filtrochk.UseVisualStyleBackColor = false;
            filtrochk.CheckedChanged += filtrochk_CheckedChanged;
            // 
            // detallepanelcompleto
            // 
            detallepanelcompleto.BackColor = Color.Gray;
            detallepanelcompleto.Controls.Add(bloqueopanel);
            detallepanelcompleto.Controls.Add(devueltapanel);
            detallepanelcompleto.Controls.Add(detallepagopanel);
            detallepanelcompleto.Location = new Point(842, 0);
            detallepanelcompleto.Name = "detallepanelcompleto";
            detallepanelcompleto.Size = new Size(810, 536);
            detallepanelcompleto.TabIndex = 10;
            // 
            // bloqueopanel
            // 
            bloqueopanel.BackColor = Color.FromArgb(64, 64, 64);
            bloqueopanel.Controls.Add(pictureBox3);
            bloqueopanel.Controls.Add(label13);
            bloqueopanel.Location = new Point(3, 265);
            bloqueopanel.Name = "bloqueopanel";
            bloqueopanel.Size = new Size(333, 322);
            bloqueopanel.TabIndex = 11;
            bloqueopanel.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.bloqueado;
            pictureBox3.Location = new Point(116, 146);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 118);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = SystemColors.Control;
            label13.Location = new Point(71, 59);
            label13.Name = "label13";
            label13.Size = new Size(190, 64);
            label13.TabIndex = 3;
            label13.Text = "Bloqueado por\r\ndetalle anterior";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // devueltapanel
            // 
            devueltapanel.BackColor = SystemColors.WindowFrame;
            devueltapanel.Controls.Add(devueltatxt);
            devueltapanel.Controls.Add(label32);
            devueltapanel.Controls.Add(label31);
            devueltapanel.Controls.Add(button13);
            devueltapanel.Controls.Add(panel12);
            devueltapanel.Location = new Point(1, 1);
            devueltapanel.Name = "devueltapanel";
            devueltapanel.Size = new Size(333, 258);
            devueltapanel.TabIndex = 10;
            devueltapanel.Visible = false;
            // 
            // devueltatxt
            // 
            devueltatxt.Enabled = false;
            devueltatxt.Font = new Font("Segoe UI", 14F);
            devueltatxt.Location = new Point(153, 153);
            devueltatxt.Name = "devueltatxt";
            devueltatxt.Size = new Size(159, 32);
            devueltatxt.TabIndex = 6;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label32.ForeColor = SystemColors.Control;
            label32.Location = new Point(21, 150);
            label32.Name = "label32";
            label32.Size = new Size(124, 32);
            label32.TabIndex = 3;
            label32.Text = "Devolver:";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label31.ForeColor = SystemColors.Control;
            label31.Location = new Point(51, 7);
            label31.Name = "label31";
            label31.Size = new Size(231, 32);
            label31.TabIndex = 3;
            label31.Text = "Devuelta (Efectivo)";
            // 
            // button13
            // 
            button13.Image = Properties.Resources.check;
            button13.ImageAlign = ContentAlignment.MiddleLeft;
            button13.Location = new Point(90, 202);
            button13.Name = "button13";
            button13.Size = new Size(152, 46);
            button13.TabIndex = 9;
            button13.Text = "Finalizar";
            button13.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(64, 64, 64);
            panel12.Controls.Add(pagadotxt);
            panel12.Controls.Add(label30);
            panel12.Controls.Add(totalpagar);
            panel12.Controls.Add(label29);
            panel12.Location = new Point(21, 52);
            panel12.Name = "panel12";
            panel12.Size = new Size(291, 78);
            panel12.TabIndex = 13;
            // 
            // pagadotxt
            // 
            pagadotxt.Enabled = false;
            pagadotxt.Location = new Point(114, 42);
            pagadotxt.Name = "pagadotxt";
            pagadotxt.Size = new Size(153, 23);
            pagadotxt.TabIndex = 6;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label30.ForeColor = SystemColors.Control;
            label30.Location = new Point(24, 45);
            label30.Name = "label30";
            label30.Size = new Size(72, 21);
            label30.TabIndex = 12;
            label30.Text = "Pagado:";
            // 
            // totalpagar
            // 
            totalpagar.Enabled = false;
            totalpagar.Location = new Point(114, 7);
            totalpagar.Name = "totalpagar";
            totalpagar.Size = new Size(153, 23);
            totalpagar.TabIndex = 6;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label29.ForeColor = SystemColors.Control;
            label29.Location = new Point(24, 10);
            label29.Name = "label29";
            label29.Size = new Size(52, 21);
            label29.TabIndex = 12;
            label29.Text = "Total:";
            // 
            // detallepagopanel
            // 
            detallepagopanel.BackColor = Color.FromArgb(64, 64, 64);
            detallepagopanel.Controls.Add(tabControl2);
            detallepagopanel.Controls.Add(label15);
            detallepagopanel.Location = new Point(476, 0);
            detallepagopanel.Name = "detallepagopanel";
            detallepagopanel.Size = new Size(333, 402);
            detallepagopanel.TabIndex = 2;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Add(tabPage5);
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Location = new Point(3, 51);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(327, 346);
            tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = SystemColors.WindowFrame;
            tabPage3.Controls.Add(efectivodt);
            tabPage3.Controls.Add(label18);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(pagarefectivo);
            tabPage3.Controls.Add(aplicarefectivo);
            tabPage3.Controls.Add(totalrealef);
            tabPage3.Controls.Add(efectivotxt);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.RightToLeft = RightToLeft.No;
            tabPage3.Size = new Size(319, 318);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Efectivo";
            // 
            // efectivodt
            // 
            efectivodt.AllowUserToAddRows = false;
            efectivodt.AllowUserToResizeRows = false;
            efectivodt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            efectivodt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            efectivodt.Location = new Point(6, 138);
            efectivodt.Name = "efectivodt";
            efectivodt.RowHeadersVisible = false;
            efectivodt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            efectivodt.Size = new Size(307, 116);
            efectivodt.TabIndex = 14;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label18.ForeColor = SystemColors.Control;
            label18.Location = new Point(9, 84);
            label18.Name = "label18";
            label18.Size = new Size(72, 21);
            label18.TabIndex = 4;
            label18.Text = "Efectivo";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label16.ForeColor = SystemColors.Control;
            label16.Location = new Point(140, 15);
            label16.Name = "label16";
            label16.Size = new Size(52, 21);
            label16.TabIndex = 4;
            label16.Text = "Total:";
            // 
            // button3
            // 
            button3.Image = Properties.Resources.atrás;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(6, 258);
            button3.Name = "button3";
            button3.Size = new Size(152, 46);
            button3.TabIndex = 1;
            button3.Text = "Volver";
            button3.UseVisualStyleBackColor = true;
            // 
            // pagarefectivo
            // 
            pagarefectivo.Image = Properties.Resources.pagar;
            pagarefectivo.ImageAlign = ContentAlignment.MiddleLeft;
            pagarefectivo.Location = new Point(161, 258);
            pagarefectivo.Name = "pagarefectivo";
            pagarefectivo.Size = new Size(152, 46);
            pagarefectivo.TabIndex = 1;
            pagarefectivo.Text = "Procesar";
            pagarefectivo.UseVisualStyleBackColor = true;
            // 
            // aplicarefectivo
            // 
            aplicarefectivo.Image = Properties.Resources.dinero2;
            aplicarefectivo.ImageAlign = ContentAlignment.MiddleLeft;
            aplicarefectivo.Location = new Point(190, 105);
            aplicarefectivo.Name = "aplicarefectivo";
            aplicarefectivo.Size = new Size(123, 29);
            aplicarefectivo.TabIndex = 1;
            aplicarefectivo.Text = "Aplicar";
            aplicarefectivo.UseVisualStyleBackColor = true;
            // 
            // totalrealef
            // 
            totalrealef.Enabled = false;
            totalrealef.Location = new Point(190, 8);
            totalrealef.Name = "totalrealef";
            totalrealef.Size = new Size(123, 23);
            totalrealef.TabIndex = 0;
            // 
            // efectivotxt
            // 
            efectivotxt.Location = new Point(6, 105);
            efectivotxt.Name = "efectivotxt";
            efectivotxt.PlaceholderText = "Total Efectivo";
            efectivotxt.Size = new Size(178, 23);
            efectivotxt.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.BackColor = SystemColors.WindowFrame;
            tabPage5.Controls.Add(tarjetacmbx);
            tabPage5.Controls.Add(tarjetadt);
            tabPage5.Controls.Add(label27);
            tabPage5.Controls.Add(label23);
            tabPage5.Controls.Add(label24);
            tabPage5.Controls.Add(button6);
            tabPage5.Controls.Add(pagartarjeta);
            tabPage5.Controls.Add(aplicartarjeta);
            tabPage5.Controls.Add(totalrealtar);
            tabPage5.Controls.Add(tarjetaref);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(319, 318);
            tabPage5.TabIndex = 2;
            tabPage5.Text = "Tarjeta";
            // 
            // tarjetacmbx
            // 
            tarjetacmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            tarjetacmbx.FormattingEnabled = true;
            tarjetacmbx.Items.AddRange(new object[] { "1. VISA", "2. MASTERCARD", "3. AMERICAN EXPRESS" });
            tarjetacmbx.Location = new Point(74, 44);
            tarjetacmbx.Name = "tarjetacmbx";
            tarjetacmbx.Size = new Size(239, 23);
            tarjetacmbx.TabIndex = 14;
            // 
            // tarjetadt
            // 
            tarjetadt.AllowUserToAddRows = false;
            tarjetadt.AllowUserToResizeRows = false;
            tarjetadt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tarjetadt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tarjetadt.Location = new Point(6, 138);
            tarjetadt.Name = "tarjetadt";
            tarjetadt.RowHeadersVisible = false;
            tarjetadt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tarjetadt.Size = new Size(307, 116);
            tarjetadt.TabIndex = 13;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label27.ForeColor = SystemColors.Control;
            label27.Location = new Point(6, 48);
            label27.Name = "label27";
            label27.Size = new Size(62, 21);
            label27.TabIndex = 11;
            label27.Text = "Tarjeta";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label23.ForeColor = SystemColors.Control;
            label23.Location = new Point(6, 81);
            label23.Name = "label23";
            label23.Size = new Size(91, 21);
            label23.TabIndex = 11;
            label23.Text = "Referencia";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label24.ForeColor = SystemColors.Control;
            label24.Location = new Point(137, 12);
            label24.Name = "label24";
            label24.Size = new Size(52, 21);
            label24.TabIndex = 12;
            label24.Text = "Total:";
            // 
            // button6
            // 
            button6.Image = Properties.Resources.atrás;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(6, 258);
            button6.Name = "button6";
            button6.Size = new Size(152, 46);
            button6.TabIndex = 8;
            button6.Text = "Volver";
            button6.UseVisualStyleBackColor = true;
            // 
            // pagartarjeta
            // 
            pagartarjeta.Image = Properties.Resources.pagar;
            pagartarjeta.ImageAlign = ContentAlignment.MiddleLeft;
            pagartarjeta.Location = new Point(161, 258);
            pagartarjeta.Name = "pagartarjeta";
            pagartarjeta.Size = new Size(152, 46);
            pagartarjeta.TabIndex = 9;
            pagartarjeta.Text = "Procesar";
            pagartarjeta.UseVisualStyleBackColor = true;
            // 
            // aplicartarjeta
            // 
            aplicartarjeta.Image = Properties.Resources.tarjeta_de_credito__1_;
            aplicartarjeta.ImageAlign = ContentAlignment.MiddleLeft;
            aplicartarjeta.Location = new Point(190, 105);
            aplicartarjeta.Name = "aplicartarjeta";
            aplicartarjeta.Size = new Size(123, 29);
            aplicartarjeta.TabIndex = 10;
            aplicartarjeta.Text = "Aplicar";
            aplicartarjeta.UseVisualStyleBackColor = true;
            // 
            // totalrealtar
            // 
            totalrealtar.Enabled = false;
            totalrealtar.Location = new Point(190, 8);
            totalrealtar.Name = "totalrealtar";
            totalrealtar.Size = new Size(123, 23);
            totalrealtar.TabIndex = 6;
            // 
            // tarjetaref
            // 
            tarjetaref.Location = new Point(6, 105);
            tarjetaref.Name = "tarjetaref";
            tarjetaref.PlaceholderText = "N° Referencia";
            tarjetaref.Size = new Size(178, 23);
            tarjetaref.TabIndex = 7;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = SystemColors.WindowFrame;
            tabPage4.Controls.Add(transferenciadt);
            tabPage4.Controls.Add(bancocmbx);
            tabPage4.Controls.Add(label28);
            tabPage4.Controls.Add(label25);
            tabPage4.Controls.Add(label26);
            tabPage4.Controls.Add(button10);
            tabPage4.Controls.Add(pagartransf);
            tabPage4.Controls.Add(aplicartransf);
            tabPage4.Controls.Add(totalrealtransf);
            tabPage4.Controls.Add(bancoref);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(319, 318);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "Transferencia";
            // 
            // transferenciadt
            // 
            transferenciadt.AllowUserToAddRows = false;
            transferenciadt.AllowUserToResizeRows = false;
            transferenciadt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            transferenciadt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            transferenciadt.Location = new Point(6, 138);
            transferenciadt.Name = "transferenciadt";
            transferenciadt.RowHeadersVisible = false;
            transferenciadt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            transferenciadt.Size = new Size(307, 116);
            transferenciadt.TabIndex = 17;
            // 
            // bancocmbx
            // 
            bancocmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            bancocmbx.FormattingEnabled = true;
            bancocmbx.Items.AddRange(new object[] { "1. BANCO POPULAR DOMINICANO", "2. BANCO DE RESERVAS (BANRESERVAS)", "3. BANCO BHD LEÓN", "4. SCOTIABANK REPÚBLICA DOMINICANA", "5. BANCO SANTA CRUZ", "6. BANCO CARIBE", "7. BANCO VIMENCA", "8. BANCO ADEMI" });
            bancocmbx.Location = new Point(74, 44);
            bancocmbx.Name = "bancocmbx";
            bancocmbx.Size = new Size(239, 23);
            bancocmbx.TabIndex = 16;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label28.ForeColor = SystemColors.Control;
            label28.Location = new Point(12, 51);
            label28.Name = "label28";
            label28.Size = new Size(57, 21);
            label28.TabIndex = 15;
            label28.Text = "Banco";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label25.ForeColor = SystemColors.Control;
            label25.Location = new Point(9, 84);
            label25.Name = "label25";
            label25.Size = new Size(91, 21);
            label25.TabIndex = 11;
            label25.Text = "Referencia";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label26.ForeColor = SystemColors.Control;
            label26.Location = new Point(140, 15);
            label26.Name = "label26";
            label26.Size = new Size(52, 21);
            label26.TabIndex = 12;
            label26.Text = "Total:";
            // 
            // button10
            // 
            button10.Image = Properties.Resources.atrás;
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Location = new Point(6, 258);
            button10.Name = "button10";
            button10.Size = new Size(152, 46);
            button10.TabIndex = 8;
            button10.Text = "Volver";
            button10.UseVisualStyleBackColor = true;
            // 
            // pagartransf
            // 
            pagartransf.Image = Properties.Resources.pagar;
            pagartransf.ImageAlign = ContentAlignment.MiddleLeft;
            pagartransf.Location = new Point(161, 258);
            pagartransf.Name = "pagartransf";
            pagartransf.Size = new Size(152, 46);
            pagartransf.TabIndex = 9;
            pagartransf.Text = "Procesar";
            pagartransf.UseVisualStyleBackColor = true;
            // 
            // aplicartransf
            // 
            aplicartransf.Image = Properties.Resources.banco__1_;
            aplicartransf.ImageAlign = ContentAlignment.MiddleLeft;
            aplicartransf.Location = new Point(190, 105);
            aplicartransf.Name = "aplicartransf";
            aplicartransf.Size = new Size(123, 29);
            aplicartransf.TabIndex = 10;
            aplicartransf.Text = "Aplicar";
            aplicartransf.UseVisualStyleBackColor = true;
            // 
            // totalrealtransf
            // 
            totalrealtransf.Enabled = false;
            totalrealtransf.Location = new Point(190, 8);
            totalrealtransf.Name = "totalrealtransf";
            totalrealtransf.Size = new Size(123, 23);
            totalrealtransf.TabIndex = 6;
            // 
            // bancoref
            // 
            bancoref.Location = new Point(6, 105);
            bancoref.Name = "bancoref";
            bancoref.PlaceholderText = "N° Referencia";
            bancoref.Size = new Size(178, 23);
            bancoref.TabIndex = 7;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.Control;
            label15.Location = new Point(69, 5);
            label15.Name = "label15";
            label15.Size = new Size(194, 32);
            label15.TabIndex = 3;
            label15.Text = "Detalle de pago";
            // 
            // flowmesa
            // 
            flowmesa.AutoScroll = true;
            flowmesa.BackColor = Color.FromArgb(64, 64, 64);
            flowmesa.Location = new Point(3, 199);
            flowmesa.Name = "flowmesa";
            flowmesa.Size = new Size(513, 270);
            flowmesa.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.WindowFrame;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(3, 158);
            panel2.Name = "panel2";
            panel2.Size = new Size(833, 37);
            panel2.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(551, 1);
            label4.Name = "label4";
            label4.Size = new Size(255, 32);
            label4.TabIndex = 3;
            label4.Text = "Datos de reservación";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(146, 1);
            label3.Name = "label3";
            label3.Size = new Size(226, 32);
            label3.TabIndex = 3;
            label3.Text = "Mesas Disponibles";
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(64, 64, 64);
            panel8.Controls.Add(notabtn);
            panel8.Controls.Add(CantidadPersonasNUD);
            panel8.Controls.Add(label7);
            panel8.Controls.Add(label6);
            panel8.Controls.Add(label5);
            panel8.Controls.Add(fecreservacion);
            panel8.Controls.Add(notapanel);
            panel8.Location = new Point(519, 199);
            panel8.Name = "panel8";
            panel8.Size = new Size(317, 270);
            panel8.TabIndex = 3;
            // 
            // notabtn
            // 
            notabtn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            notabtn.Image = Properties.Resources.nota;
            notabtn.ImageAlign = ContentAlignment.MiddleLeft;
            notabtn.Location = new Point(111, 114);
            notabtn.Name = "notabtn";
            notabtn.Size = new Size(98, 28);
            notabtn.TabIndex = 6;
            notabtn.Text = "Nota";
            notabtn.UseVisualStyleBackColor = true;
            notabtn.Click += notabtn_Click;
            // 
            // CantidadPersonasNUD
            // 
            CantidadPersonasNUD.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CantidadPersonasNUD.Location = new Point(186, 66);
            CantidadPersonasNUD.Name = "CantidadPersonasNUD";
            CantidadPersonasNUD.Size = new Size(122, 29);
            CantidadPersonasNUD.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(7, 114);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(2, 69);
            label6.Name = "label6";
            label6.Size = new Size(178, 21);
            label6.TabIndex = 3;
            label6.Text = "Cantidad de Personas:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(1, 21);
            label5.Name = "label5";
            label5.Size = new Size(141, 21);
            label5.TabIndex = 3;
            label5.Text = "Fecha de reserva:";
            // 
            // fecreservacion
            // 
            fecreservacion.Cursor = Cursors.Hand;
            fecreservacion.CustomFormat = "dd/MM/yyyy HH:mm";
            fecreservacion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fecreservacion.Format = DateTimePickerFormat.Custom;
            fecreservacion.Location = new Point(144, 18);
            fecreservacion.Name = "fecreservacion";
            fecreservacion.Size = new Size(164, 29);
            fecreservacion.TabIndex = 4;
            // 
            // notapanel
            // 
            notapanel.BackColor = Color.Gray;
            notapanel.Controls.Add(notatxt);
            notapanel.Location = new Point(17, 143);
            notapanel.Name = "notapanel";
            notapanel.Size = new Size(281, 126);
            notapanel.TabIndex = 159;
            notapanel.Visible = false;
            // 
            // notatxt
            // 
            notatxt.Font = new Font("Segoe UI", 12F);
            notatxt.Location = new Point(8, 9);
            notatxt.Multiline = true;
            notatxt.Name = "notatxt";
            notatxt.PlaceholderText = "Escribir nota aquí...";
            notatxt.Size = new Size(265, 108);
            notatxt.TabIndex = 158;
            notatxt.Enter += notatxt_Enter;
            notatxt.Leave += notatxt_Leave;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(txtnumero_cliente);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label20);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buscarclientebtn);
            panel1.Controls.Add(idclientetxt);
            panel1.Controls.Add(txtidreserva);
            panel1.Controls.Add(txtnombrecompleto);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(833, 149);
            panel1.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.WindowFrame;
            panel4.Controls.Add(fechacreacionreserva);
            panel4.Controls.Add(nuevobtn);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(guardareservabtn);
            panel4.Location = new Point(548, 8);
            panel4.Name = "panel4";
            panel4.Size = new Size(280, 133);
            panel4.TabIndex = 5;
            // 
            // fechacreacionreserva
            // 
            fechacreacionreserva.Enabled = false;
            fechacreacionreserva.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fechacreacionreserva.Format = DateTimePickerFormat.Short;
            fechacreacionreserva.Location = new Point(151, 8);
            fechacreacionreserva.Name = "fechacreacionreserva";
            fechacreacionreserva.Size = new Size(123, 29);
            fechacreacionreserva.TabIndex = 4;
            // 
            // nuevobtn
            // 
            nuevobtn.Cursor = Cursors.Hand;
            nuevobtn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nuevobtn.Image = Properties.Resources.nuevo;
            nuevobtn.ImageAlign = ContentAlignment.MiddleLeft;
            nuevobtn.Location = new Point(147, 72);
            nuevobtn.Name = "nuevobtn";
            nuevobtn.Size = new Size(128, 52);
            nuevobtn.TabIndex = 0;
            nuevobtn.Text = "Nuevo";
            nuevobtn.UseVisualStyleBackColor = true;
            nuevobtn.Click += nuevobtn_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label11.ForeColor = SystemColors.Control;
            label11.Location = new Point(1, 11);
            label11.Name = "label11";
            label11.Size = new Size(150, 21);
            label11.TabIndex = 3;
            label11.Text = "Fecha de creacion:";
            // 
            // guardareservabtn
            // 
            guardareservabtn.BackColor = Color.FromArgb(128, 255, 128);
            guardareservabtn.Cursor = Cursors.Hand;
            guardareservabtn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guardareservabtn.Image = Properties.Resources.next;
            guardareservabtn.ImageAlign = ContentAlignment.MiddleLeft;
            guardareservabtn.Location = new Point(6, 72);
            guardareservabtn.Name = "guardareservabtn";
            guardareservabtn.Size = new Size(128, 52);
            guardareservabtn.TabIndex = 0;
            guardareservabtn.Text = "Siguiente";
            guardareservabtn.UseVisualStyleBackColor = false;
            guardareservabtn.Click += guardareservabtn_Click;
            // 
            // txtnumero_cliente
            // 
            txtnumero_cliente.Font = new Font("Segoe UI", 12F);
            txtnumero_cliente.Location = new Point(42, 108);
            txtnumero_cliente.Name = "txtnumero_cliente";
            txtnumero_cliente.PlaceholderText = "Número de telefono";
            txtnumero_cliente.Size = new Size(169, 29);
            txtnumero_cliente.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.telefono;
            pictureBox1.Location = new Point(10, 110);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 26);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(326, 4);
            label2.Name = "label2";
            label2.Size = new Size(180, 32);
            label2.TabIndex = 3;
            label2.Text = "Reservar Mesa";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.ForeColor = SystemColors.Control;
            label20.Location = new Point(5, 10);
            label20.Name = "label20";
            label20.Size = new Size(29, 21);
            label20.TabIndex = 3;
            label20.Text = "N°";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(7, 48);
            label1.Name = "label1";
            label1.Size = new Size(110, 21);
            label1.TabIndex = 3;
            label1.Text = "Datos cliente";
            // 
            // buscarclientebtn
            // 
            buscarclientebtn.Cursor = Cursors.Hand;
            buscarclientebtn.Image = Properties.Resources.persona3;
            buscarclientebtn.Location = new Point(9, 75);
            buscarclientebtn.Name = "buscarclientebtn";
            buscarclientebtn.RightToLeft = RightToLeft.No;
            buscarclientebtn.Size = new Size(29, 29);
            buscarclientebtn.TabIndex = 2;
            toolTip1.SetToolTip(buscarclientebtn, "Buscar Cliente");
            buscarclientebtn.UseVisualStyleBackColor = true;
            buscarclientebtn.Click += buscarclientebtn_Click;
            // 
            // idclientetxt
            // 
            idclientetxt.Enabled = false;
            idclientetxt.Font = new Font("Segoe UI", 12F);
            idclientetxt.Location = new Point(42, 75);
            idclientetxt.Name = "idclientetxt";
            idclientetxt.PlaceholderText = "ID";
            idclientetxt.Size = new Size(48, 29);
            idclientetxt.TabIndex = 0;
            // 
            // txtidreserva
            // 
            txtidreserva.Enabled = false;
            txtidreserva.Font = new Font("Segoe UI", 12F);
            txtidreserva.Location = new Point(38, 6);
            txtidreserva.Name = "txtidreserva";
            txtidreserva.Size = new Size(87, 29);
            txtidreserva.TabIndex = 0;
            txtidreserva.Text = "ID";
            // 
            // txtnombrecompleto
            // 
            txtnombrecompleto.Enabled = false;
            txtnombrecompleto.Font = new Font("Segoe UI", 12F);
            txtnombrecompleto.Location = new Point(93, 75);
            txtnombrecompleto.Name = "txtnombrecompleto";
            txtnombrecompleto.PlaceholderText = "Nombre de Cliente";
            txtnombrecompleto.Size = new Size(413, 29);
            txtnombrecompleto.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(87, 128, 87);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(txtbusquedareserva);
            tabPage2.Controls.Add(panel3);
            tabPage2.Controls.Add(ReservacionMesasDGV);
            tabPage2.Controls.Add(panel10);
            tabPage2.Controls.Add(panel6);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(842, 476);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Reservaciones";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.White;
            label14.ForeColor = SystemColors.Control;
            label14.Image = Properties.Resources.busqueda;
            label14.Location = new Point(470, 138);
            label14.Name = "label14";
            label14.Size = new Size(18, 21);
            label14.TabIndex = 16;
            label14.Text = "  ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.Control;
            label10.Location = new Point(292, 10);
            label10.Name = "label10";
            label10.Size = new Size(265, 32);
            label10.TabIndex = 15;
            label10.Text = "Reservacion de Mesas";
            // 
            // txtbusquedareserva
            // 
            txtbusquedareserva.ForeColor = Color.Gray;
            txtbusquedareserva.Location = new Point(3, 134);
            txtbusquedareserva.Name = "txtbusquedareserva";
            txtbusquedareserva.PlaceholderText = "Buscar Reservaciones";
            txtbusquedareserva.Size = new Size(489, 29);
            txtbusquedareserva.TabIndex = 8;
            txtbusquedareserva.TextChanged += txtbusquedareserva_TextChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel3.Controls.Add(cancelarreservabtn);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(ordenbtn);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(fecini);
            panel3.Controls.Add(fecfin);
            panel3.Location = new Point(3, 54);
            panel3.Name = "panel3";
            panel3.Size = new Size(836, 74);
            panel3.TabIndex = 7;
            // 
            // cancelarreservabtn
            // 
            cancelarreservabtn.BackColor = Color.FromArgb(255, 128, 128);
            cancelarreservabtn.Image = Properties.Resources.cancelardoc;
            cancelarreservabtn.ImageAlign = ContentAlignment.MiddleLeft;
            cancelarreservabtn.Location = new Point(717, 9);
            cancelarreservabtn.Name = "cancelarreservabtn";
            cancelarreservabtn.Size = new Size(114, 56);
            cancelarreservabtn.TabIndex = 0;
            cancelarreservabtn.Text = "Cancelar";
            cancelarreservabtn.TextAlign = ContentAlignment.MiddleRight;
            cancelarreservabtn.UseVisualStyleBackColor = false;
            cancelarreservabtn.Click += cancelarreservabtn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(8, 10);
            label8.Name = "label8";
            label8.Size = new Size(101, 21);
            label8.TabIndex = 6;
            label8.Text = "Fecha inicio";
            // 
            // ordenbtn
            // 
            ordenbtn.BackColor = Color.FromArgb(255, 192, 128);
            ordenbtn.Image = Properties.Resources.nuevo;
            ordenbtn.ImageAlign = ContentAlignment.MiddleLeft;
            ordenbtn.Location = new Point(597, 10);
            ordenbtn.Name = "ordenbtn";
            ordenbtn.Size = new Size(114, 56);
            ordenbtn.TabIndex = 0;
            ordenbtn.Text = "Orden";
            ordenbtn.TextAlign = ContentAlignment.MiddleRight;
            ordenbtn.UseVisualStyleBackColor = false;
            ordenbtn.Click += ordenbtn_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(152, 10);
            label9.Name = "label9";
            label9.Size = new Size(79, 21);
            label9.TabIndex = 6;
            label9.Text = "Fecha fin";
            // 
            // fecini
            // 
            fecini.Format = DateTimePickerFormat.Short;
            fecini.Location = new Point(8, 34);
            fecini.Name = "fecini";
            fecini.Size = new Size(123, 29);
            fecini.TabIndex = 5;
            fecini.ValueChanged += fecini_ValueChanged;
            // 
            // fecfin
            // 
            fecfin.Format = DateTimePickerFormat.Short;
            fecfin.Location = new Point(152, 34);
            fecfin.Name = "fecfin";
            fecfin.Size = new Size(123, 29);
            fecfin.TabIndex = 5;
            fecfin.ValueChanged += fecfin_ValueChanged;
            // 
            // ReservacionMesasDGV
            // 
            ReservacionMesasDGV.AllowUserToAddRows = false;
            ReservacionMesasDGV.AllowUserToDeleteRows = false;
            ReservacionMesasDGV.AllowUserToResizeRows = false;
            ReservacionMesasDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ReservacionMesasDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReservacionMesasDGV.Location = new Point(7, 171);
            ReservacionMesasDGV.Name = "ReservacionMesasDGV";
            ReservacionMesasDGV.ReadOnly = true;
            ReservacionMesasDGV.RowHeadersVisible = false;
            ReservacionMesasDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ReservacionMesasDGV.Size = new Size(829, 296);
            ReservacionMesasDGV.TabIndex = 0;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(64, 64, 64);
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(label12);
            panel10.Controls.Add(pendientechk);
            panel10.Controls.Add(todoschk);
            panel10.Controls.Add(canceladochk);
            panel10.Location = new Point(498, 134);
            panel10.Name = "panel10";
            panel10.Size = new Size(341, 29);
            panel10.TabIndex = 18;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = SystemColors.Control;
            label12.Image = Properties.Resources.filtroblanco;
            label12.Location = new Point(3, 3);
            label12.Name = "label12";
            label12.Size = new Size(18, 21);
            label12.TabIndex = 19;
            label12.Text = "  ";
            // 
            // pendientechk
            // 
            pendientechk.AutoSize = true;
            pendientechk.BackColor = Color.FromArgb(64, 64, 64);
            pendientechk.Checked = true;
            pendientechk.CheckState = CheckState.Checked;
            pendientechk.ForeColor = Color.White;
            pendientechk.Location = new Point(35, 1);
            pendientechk.Name = "pendientechk";
            pendientechk.Size = new Size(97, 25);
            pendientechk.TabIndex = 11;
            pendientechk.Text = "Pendiente";
            pendientechk.UseVisualStyleBackColor = false;
            // 
            // todoschk
            // 
            todoschk.AutoSize = true;
            todoschk.BackColor = Color.FromArgb(64, 64, 64);
            todoschk.ForeColor = Color.White;
            todoschk.Location = new Point(255, 2);
            todoschk.Name = "todoschk";
            todoschk.Size = new Size(69, 25);
            todoschk.TabIndex = 9;
            todoschk.Text = "Todos";
            todoschk.UseVisualStyleBackColor = false;
            // 
            // canceladochk
            // 
            canceladochk.AutoSize = true;
            canceladochk.BackColor = Color.FromArgb(64, 64, 64);
            canceladochk.ForeColor = Color.White;
            canceladochk.Location = new Point(142, 2);
            canceladochk.Name = "canceladochk";
            canceladochk.Size = new Size(101, 25);
            canceladochk.TabIndex = 10;
            canceladochk.Text = "Cancelado";
            canceladochk.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(64, 64, 64);
            panel6.Location = new Point(3, 165);
            panel6.Name = "panel6";
            panel6.Size = new Size(836, 309);
            panel6.TabIndex = 19;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 4800;
            toolTip1.InitialDelay = 480;
            toolTip1.ReshowDelay = 96;
            toolTip1.ToolTipTitle = "Ayuda";
            // 
            // Reservacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(850, 510);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Reservacion";
            StartPosition = FormStartPosition.Manual;
            Text = "Reservacion";
            Load += Reservacion_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            PanelClientes.ResumeLayout(false);
            PanelClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tabladatoscliente).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            detallepanelcompleto.ResumeLayout(false);
            bloqueopanel.ResumeLayout(false);
            bloqueopanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            devueltapanel.ResumeLayout(false);
            devueltapanel.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            detallepagopanel.ResumeLayout(false);
            detallepagopanel.PerformLayout();
            tabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)efectivodt).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tarjetadt).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)transferenciadt).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CantidadPersonasNUD).EndInit();
            notapanel.ResumeLayout(false);
            notapanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ReservacionMesasDGV).EndInit();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private TextBox txtnumero_cliente;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label20;
        private Label label1;
        private Button buscarclientebtn;
        private TextBox txtidreserva;
        private TextBox txtnombrecompleto;
        private Panel panel4;
        private DateTimePicker fechacreacionreserva;
        private Button nuevobtn;
        private Label label11;
        private Button guardareservabtn;
        private Panel panel8;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private Label label5;
        private DateTimePicker fecreservacion;
        private NumericUpDown CantidadPersonasNUD;
        private Label label7;
        private Label label6;
        private DataGridView ReservacionMesasDGV;
        private Button cancelarreservabtn;
        private Button ordenbtn;
        private Label label9;
        private DateTimePicker fecfin;
        private Label label8;
        private DateTimePicker fecini;
        private Panel panel3;
        private CheckBox todoschk;
        private CheckBox canceladochk;
        private CheckBox pendientechk;
        private TextBox txtbusquedareserva;
        private Label label10;
        private Label label14;
        private TextBox idclientetxt;
        private FlowLayoutPanel flowmesa;
        private Panel detallepanelcompleto;
        private Panel bloqueopanel;
        private PictureBox pictureBox3;
        private Label label13;
        private Panel devueltapanel;
        private TextBox devueltatxt;
        private Label label32;
        private Label label31;
        private Button button13;
        private Panel panel12;
        private TextBox pagadotxt;
        private Label label30;
        private TextBox totalpagar;
        private Label label29;
        private Panel detallepagopanel;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private DataGridView efectivodt;
        private Label label18;
        private Label label16;
        private Button button3;
        private Button pagarefectivo;
        private Button aplicarefectivo;
        private TextBox totalrealef;
        private TextBox efectivotxt;
        private TabPage tabPage5;
        private ComboBox tarjetacmbx;
        private DataGridView tarjetadt;
        private Label label27;
        private Label label23;
        private Label label24;
        private Button button6;
        private Button pagartarjeta;
        private Button aplicartarjeta;
        private TextBox totalrealtar;
        private TextBox tarjetaref;
        private TabPage tabPage4;
        private DataGridView transferenciadt;
        private ComboBox bancocmbx;
        private Label label28;
        private Label label25;
        private Label label26;
        private Button button10;
        private Button pagartransf;
        private Button aplicartransf;
        private TextBox totalrealtransf;
        private TextBox bancoref;
        private Label label15;
        private Panel panel10;
        private Label label12;
        private Panel PanelClientes;
        private Label label17;
        private Label label19;
        private TextBox txtbuscador;
        private DataGridView tabladatoscliente;
        private Button recargarbtn;
        private Button eliminarbtn;
        private CheckBox filtrochk;
        private Panel panel7;
        private Label label21;
        private Panel panel6;
        private Button notabtn;
        private ToolTip toolTip1;
        private TextBox notatxt;
        private Panel notapanel;
        private Button RegresarBtn;
    }
}