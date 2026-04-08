namespace Proyecto_restaurante
{
    partial class ConsClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsClientes));
            txtbuscador = new TextBox();
            tabladatos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            eliminarbtn = new Button();
            label3 = new Label();
            Editar = new Button();
            agregar = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            nombrelabel = new Label();
            telefonolabel = new Label();
            idenlabel = new Label();
            clienteimg = new PictureBox();
            recargarbtn = new Button();
            filtrochk = new CheckBox();
            tabPage2 = new TabPage();
            tipodoccmbx = new ComboBox();
            label10 = new Label();
            label14 = new Label();
            panel4 = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            label19 = new Label();
            direcciontxt = new TextBox();
            numerotxt = new TextBox();
            label13 = new Label();
            principalDireccion = new CheckBox();
            numPrincipalcmbx = new CheckBox();
            direccioncliente = new DataGridView();
            telefonocliente = new DataGridView();
            eliminarDireccion = new Button();
            bajardireccion = new Button();
            eliminarNumero = new Button();
            bajarTelefono = new Button();
            nombredirecciontxt = new TextBox();
            nombrenumerotxt = new TextBox();
            panel3 = new Panel();
            guardarbtn = new Button();
            limpiarbtn = new Button();
            panel1 = new Panel();
            seleccionimagenbtn = new Button();
            imagencliente = new PictureBox();
            button2 = new Button();
            estadochk = new CheckBox();
            emailtxt = new TextBox();
            txtapellido = new TextBox();
            idclientetxt = new TextBox();
            identtxt = new TextBox();
            txtnombre = new TextBox();
            label4 = new Label();
            label6 = new Label();
            label8 = new Label();
            label7 = new Label();
            label12 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)tabladatos).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clienteimg).BeginInit();
            tabPage2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)direccioncliente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)telefonocliente).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imagencliente).BeginInit();
            SuspendLayout();
            // 
            // txtbuscador
            // 
            txtbuscador.CharacterCasing = CharacterCasing.Upper;
            txtbuscador.Font = new Font("Segoe UI", 12F);
            txtbuscador.ForeColor = SystemColors.ScrollBar;
            txtbuscador.Location = new Point(10, 63);
            txtbuscador.Name = "txtbuscador";
            txtbuscador.PlaceholderText = "Buscar Cliente";
            txtbuscador.Size = new Size(452, 29);
            txtbuscador.TabIndex = 1;
            txtbuscador.TextChanged += txtbuscador_TextChanged;
            // 
            // tabladatos
            // 
            tabladatos.AllowUserToAddRows = false;
            tabladatos.AllowUserToDeleteRows = false;
            tabladatos.AllowUserToResizeRows = false;
            tabladatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabladatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabladatos.Location = new Point(10, 98);
            tabladatos.MultiSelect = false;
            tabladatos.Name = "tabladatos";
            tabladatos.ReadOnly = true;
            tabladatos.RowHeadersVisible = false;
            tabladatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabladatos.Size = new Size(543, 541);
            tabladatos.TabIndex = 1;
            tabladatos.CellClick += tabladatos_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(216, 3);
            label1.Name = "label1";
            label1.Size = new Size(295, 40);
            label1.TabIndex = 3;
            label1.Text = "Consulta de Clientes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Image = Properties.Resources.busqueda;
            label2.Location = new Point(439, 67);
            label2.Name = "label2";
            label2.Size = new Size(18, 21);
            label2.TabIndex = 0;
            label2.Text = "  ";
            // 
            // eliminarbtn
            // 
            eliminarbtn.Cursor = Cursors.Hand;
            eliminarbtn.Image = Properties.Resources.limpio;
            eliminarbtn.Location = new Point(522, 63);
            eliminarbtn.Name = "eliminarbtn";
            eliminarbtn.Size = new Size(31, 29);
            eliminarbtn.TabIndex = 2;
            eliminarbtn.UseVisualStyleBackColor = true;
            eliminarbtn.Click += eliminarbtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(581, 56);
            label3.Name = "label3";
            label3.Size = new Size(116, 32);
            label3.TabIndex = 48;
            label3.Text = "Acciones";
            // 
            // Editar
            // 
            Editar.Cursor = Cursors.Hand;
            Editar.Image = Properties.Resources.editarcliente1;
            Editar.Location = new Point(558, 175);
            Editar.Name = "Editar";
            Editar.Size = new Size(159, 72);
            Editar.TabIndex = 46;
            Editar.Text = "Editar";
            Editar.TextAlign = ContentAlignment.BottomCenter;
            Editar.UseVisualStyleBackColor = true;
            Editar.Click += Editar_Click;
            // 
            // agregar
            // 
            agregar.Cursor = Cursors.Hand;
            agregar.Image = Properties.Resources.cliente1;
            agregar.Location = new Point(558, 98);
            agregar.Name = "agregar";
            agregar.Size = new Size(159, 72);
            agregar.TabIndex = 47;
            agregar.Text = "Nuevo";
            agregar.TextAlign = ContentAlignment.BottomCenter;
            agregar.UseVisualStyleBackColor = true;
            agregar.Click += agregar_Click;
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
            tabControl1.Size = new Size(734, 679);
            tabControl1.TabIndex = 49;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.WindowFrame;
            tabPage1.Controls.Add(nombrelabel);
            tabPage1.Controls.Add(telefonolabel);
            tabPage1.Controls.Add(idenlabel);
            tabPage1.Controls.Add(clienteimg);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtbuscador);
            tabPage1.Controls.Add(Editar);
            tabPage1.Controls.Add(tabladatos);
            tabPage1.Controls.Add(agregar);
            tabPage1.Controls.Add(recargarbtn);
            tabPage1.Controls.Add(eliminarbtn);
            tabPage1.Controls.Add(filtrochk);
            tabPage1.Font = new Font("Segoe UI", 12F);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(726, 645);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Consulta";
            // 
            // nombrelabel
            // 
            nombrelabel.AutoSize = true;
            nombrelabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nombrelabel.ForeColor = Color.White;
            nombrelabel.Location = new Point(558, 431);
            nombrelabel.Name = "nombrelabel";
            nombrelabel.Size = new Size(154, 21);
            nombrelabel.TabIndex = 50;
            nombrelabel.Text = "Nombre completo:";
            // 
            // telefonolabel
            // 
            telefonolabel.AutoSize = true;
            telefonolabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            telefonolabel.ForeColor = Color.White;
            telefonolabel.Location = new Point(558, 564);
            telefonolabel.Name = "telefonolabel";
            telefonolabel.Size = new Size(149, 21);
            telefonolabel.TabIndex = 50;
            telefonolabel.Text = "Teléfono principal";
            // 
            // idenlabel
            // 
            idenlabel.AutoSize = true;
            idenlabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            idenlabel.ForeColor = Color.White;
            idenlabel.Location = new Point(558, 496);
            idenlabel.Name = "idenlabel";
            idenlabel.Size = new Size(107, 21);
            idenlabel.TabIndex = 50;
            idenlabel.Text = "Cédula/RNC:";
            // 
            // clienteimg
            // 
            clienteimg.ErrorImage = Properties.Resources.perfilcliente;
            clienteimg.Image = Properties.Resources.perfilcliente;
            clienteimg.InitialImage = Properties.Resources.perfilcliente;
            clienteimg.Location = new Point(559, 252);
            clienteimg.Name = "clienteimg";
            clienteimg.Size = new Size(158, 158);
            clienteimg.SizeMode = PictureBoxSizeMode.StretchImage;
            clienteimg.TabIndex = 49;
            clienteimg.TabStop = false;
            // 
            // recargarbtn
            // 
            recargarbtn.Cursor = Cursors.Hand;
            recargarbtn.Image = Properties.Resources.actualizar;
            recargarbtn.Location = new Point(10, 12);
            recargarbtn.Name = "recargarbtn";
            recargarbtn.Size = new Size(29, 29);
            recargarbtn.TabIndex = 2;
            recargarbtn.UseVisualStyleBackColor = true;
            recargarbtn.Click += button1_Click;
            // 
            // filtrochk
            // 
            filtrochk.AutoSize = true;
            filtrochk.Checked = true;
            filtrochk.CheckState = CheckState.Checked;
            filtrochk.Cursor = Cursors.Hand;
            filtrochk.Font = new Font("Segoe UI", 13F);
            filtrochk.Image = Properties.Resources.sicheck;
            filtrochk.Location = new Point(474, 64);
            filtrochk.Name = "filtrochk";
            filtrochk.Size = new Size(41, 29);
            filtrochk.TabIndex = 51;
            filtrochk.Text = "  ";
            filtrochk.UseVisualStyleBackColor = true;
            filtrochk.CheckedChanged += filtro_CheckedChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.WindowFrame;
            tabPage2.Controls.Add(tipodoccmbx);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(panel4);
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(panel5);
            tabPage2.Controls.Add(panel3);
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(estadochk);
            tabPage2.Controls.Add(emailtxt);
            tabPage2.Controls.Add(txtapellido);
            tabPage2.Controls.Add(idclientetxt);
            tabPage2.Controls.Add(identtxt);
            tabPage2.Controls.Add(txtnombre);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label9);
            tabPage2.Font = new Font("Segoe UI", 12F);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(726, 645);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Creación";
            // 
            // tipodoccmbx
            // 
            tipodoccmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            tipodoccmbx.FormattingEnabled = true;
            tipodoccmbx.Items.AddRange(new object[] { "RNC", "Cedula" });
            tipodoccmbx.Location = new Point(11, 93);
            tipodoccmbx.Name = "tipodoccmbx";
            tipodoccmbx.Size = new Size(91, 29);
            tipodoccmbx.TabIndex = 100;
            tipodoccmbx.SelectedIndexChanged += tipodoccmbx_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.ForeColor = Color.Red;
            label10.Location = new Point(457, 169);
            label10.Name = "label10";
            label10.Size = new Size(17, 21);
            label10.TabIndex = 99;
            label10.Text = "*";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label14.ForeColor = SystemColors.Control;
            label14.Location = new Point(11, 68);
            label14.Name = "label14";
            label14.Size = new Size(211, 21);
            label14.TabIndex = 99;
            label14.Text = "Documento de indentidad";
            // 
            // panel4
            // 
            panel4.Location = new Point(455, 365);
            panel4.Name = "panel4";
            panel4.Size = new Size(261, 26);
            panel4.TabIndex = 98;
            // 
            // panel2
            // 
            panel2.Location = new Point(211, 365);
            panel2.Name = "panel2";
            panel2.Size = new Size(129, 26);
            panel2.TabIndex = 97;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(64, 64, 64);
            panel5.Controls.Add(label19);
            panel5.Controls.Add(direcciontxt);
            panel5.Controls.Add(numerotxt);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(principalDireccion);
            panel5.Controls.Add(numPrincipalcmbx);
            panel5.Controls.Add(direccioncliente);
            panel5.Controls.Add(telefonocliente);
            panel5.Controls.Add(eliminarDireccion);
            panel5.Controls.Add(bajardireccion);
            panel5.Controls.Add(eliminarNumero);
            panel5.Controls.Add(bajarTelefono);
            panel5.Controls.Add(nombredirecciontxt);
            panel5.Controls.Add(nombrenumerotxt);
            panel5.Location = new Point(9, 365);
            panel5.Name = "panel5";
            panel5.Size = new Size(708, 206);
            panel5.TabIndex = 96;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label19.ForeColor = Color.White;
            label19.Image = Properties.Resources.ubicacion;
            label19.ImageAlign = ContentAlignment.MiddleRight;
            label19.Location = new Point(339, 5);
            label19.Name = "label19";
            label19.Size = new Size(103, 21);
            label19.TabIndex = 55;
            label19.Text = "Direccion     ";
            // 
            // direcciontxt
            // 
            direcciontxt.CharacterCasing = CharacterCasing.Upper;
            direcciontxt.Location = new Point(408, 36);
            direcciontxt.Name = "direcciontxt";
            direcciontxt.PlaceholderText = "Dirección";
            direcciontxt.Size = new Size(166, 29);
            direcciontxt.TabIndex = 79;
            // 
            // numerotxt
            // 
            numerotxt.Location = new Point(78, 36);
            numerotxt.Name = "numerotxt";
            numerotxt.PlaceholderText = "Número";
            numerotxt.Size = new Size(113, 29);
            numerotxt.TabIndex = 79;
            numerotxt.TextChanged += txtnumero_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Image = Properties.Resources.telefonoblanco;
            label13.ImageAlign = ContentAlignment.MiddleRight;
            label13.Location = new Point(9, 5);
            label13.Name = "label13";
            label13.Size = new Size(185, 21);
            label13.TabIndex = 55;
            label13.Text = "Número de telefono     ";
            // 
            // principalDireccion
            // 
            principalDireccion.AutoSize = true;
            principalDireccion.ForeColor = Color.White;
            principalDireccion.Location = new Point(580, 38);
            principalDireccion.Name = "principalDireccion";
            principalDireccion.Size = new Size(89, 25);
            principalDireccion.TabIndex = 90;
            principalDireccion.Text = "Principal";
            principalDireccion.UseVisualStyleBackColor = true;
            principalDireccion.CheckedChanged += principalDireccion_CheckedChanged;
            // 
            // numPrincipalcmbx
            // 
            numPrincipalcmbx.AutoSize = true;
            numPrincipalcmbx.ForeColor = Color.White;
            numPrincipalcmbx.Location = new Point(199, 38);
            numPrincipalcmbx.Name = "numPrincipalcmbx";
            numPrincipalcmbx.Size = new Size(89, 25);
            numPrincipalcmbx.TabIndex = 90;
            numPrincipalcmbx.Text = "Principal";
            numPrincipalcmbx.UseVisualStyleBackColor = true;
            numPrincipalcmbx.CheckedChanged += numPrincipalcmbx_CheckedChanged;
            // 
            // direccioncliente
            // 
            direccioncliente.AllowUserToAddRows = false;
            direccioncliente.AllowUserToResizeRows = false;
            direccioncliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            direccioncliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            direccioncliente.Location = new Point(339, 71);
            direccioncliente.MultiSelect = false;
            direccioncliente.Name = "direccioncliente";
            direccioncliente.ReadOnly = true;
            direccioncliente.RowHeadersVisible = false;
            direccioncliente.RowHeadersWidth = 51;
            direccioncliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            direccioncliente.Size = new Size(329, 129);
            direccioncliente.TabIndex = 74;
            direccioncliente.CellClick += direccioncliente_CellClick;
            // 
            // telefonocliente
            // 
            telefonocliente.AllowUserToAddRows = false;
            telefonocliente.AllowUserToResizeRows = false;
            telefonocliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            telefonocliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            telefonocliente.Location = new Point(9, 69);
            telefonocliente.MultiSelect = false;
            telefonocliente.Name = "telefonocliente";
            telefonocliente.ReadOnly = true;
            telefonocliente.RowHeadersVisible = false;
            telefonocliente.RowHeadersWidth = 51;
            telefonocliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            telefonocliente.Size = new Size(281, 129);
            telefonocliente.TabIndex = 74;
            telefonocliente.CellClick += telefonocliente_CellClick;
            // 
            // eliminarDireccion
            // 
            eliminarDireccion.BackColor = Color.Red;
            eliminarDireccion.Cursor = Cursors.Hand;
            eliminarDireccion.Image = Properties.Resources.basurablanco;
            eliminarDireccion.Location = new Point(673, 171);
            eliminarDireccion.Name = "eliminarDireccion";
            eliminarDireccion.Size = new Size(28, 29);
            eliminarDireccion.TabIndex = 77;
            eliminarDireccion.UseVisualStyleBackColor = false;
            eliminarDireccion.Click += eliminarDireccion_Click;
            // 
            // bajardireccion
            // 
            bajardireccion.Cursor = Cursors.Hand;
            bajardireccion.Image = Properties.Resources.angulo_hacia_abajo;
            bajardireccion.Location = new Point(673, 36);
            bajardireccion.Name = "bajardireccion";
            bajardireccion.Size = new Size(28, 29);
            bajardireccion.TabIndex = 77;
            bajardireccion.UseVisualStyleBackColor = true;
            bajardireccion.Click += bajardireccion_Click;
            // 
            // eliminarNumero
            // 
            eliminarNumero.BackColor = Color.Red;
            eliminarNumero.Cursor = Cursors.Hand;
            eliminarNumero.Image = Properties.Resources.basurablanco;
            eliminarNumero.Location = new Point(293, 169);
            eliminarNumero.Name = "eliminarNumero";
            eliminarNumero.Size = new Size(28, 29);
            eliminarNumero.TabIndex = 77;
            eliminarNumero.UseVisualStyleBackColor = false;
            eliminarNumero.Click += eliminarNumero_Click;
            // 
            // bajarTelefono
            // 
            bajarTelefono.Cursor = Cursors.Hand;
            bajarTelefono.Image = Properties.Resources.angulo_hacia_abajo;
            bajarTelefono.Location = new Point(293, 36);
            bajarTelefono.Name = "bajarTelefono";
            bajarTelefono.Size = new Size(28, 29);
            bajarTelefono.TabIndex = 77;
            bajarTelefono.UseVisualStyleBackColor = true;
            bajarTelefono.Click += bajarTelefono_Click;
            // 
            // nombredirecciontxt
            // 
            nombredirecciontxt.CharacterCasing = CharacterCasing.Upper;
            nombredirecciontxt.Location = new Point(339, 36);
            nombredirecciontxt.Name = "nombredirecciontxt";
            nombredirecciontxt.PlaceholderText = "Etiqueta";
            nombredirecciontxt.Size = new Size(66, 29);
            nombredirecciontxt.TabIndex = 79;
            // 
            // nombrenumerotxt
            // 
            nombrenumerotxt.CharacterCasing = CharacterCasing.Upper;
            nombrenumerotxt.Location = new Point(9, 36);
            nombrenumerotxt.Name = "nombrenumerotxt";
            nombrenumerotxt.PlaceholderText = "Etiqueta";
            nombrenumerotxt.Size = new Size(66, 29);
            nombrenumerotxt.TabIndex = 79;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel3.Controls.Add(guardarbtn);
            panel3.Controls.Add(limpiarbtn);
            panel3.Location = new Point(159, 568);
            panel3.Name = "panel3";
            panel3.Size = new Size(409, 74);
            panel3.TabIndex = 75;
            // 
            // guardarbtn
            // 
            guardarbtn.Cursor = Cursors.Hand;
            guardarbtn.Image = Properties.Resources.guardar;
            guardarbtn.ImageAlign = ContentAlignment.MiddleLeft;
            guardarbtn.Location = new Point(12, 8);
            guardarbtn.Name = "guardarbtn";
            guardarbtn.Size = new Size(181, 58);
            guardarbtn.TabIndex = 20;
            guardarbtn.Text = "Guardar";
            guardarbtn.UseVisualStyleBackColor = true;
            guardarbtn.Click += guardarbtn_Click;
            // 
            // limpiarbtn
            // 
            limpiarbtn.Cursor = Cursors.Hand;
            limpiarbtn.Image = Properties.Resources.nuevo;
            limpiarbtn.ImageAlign = ContentAlignment.MiddleLeft;
            limpiarbtn.Location = new Point(216, 8);
            limpiarbtn.Name = "limpiarbtn";
            limpiarbtn.Size = new Size(181, 58);
            limpiarbtn.TabIndex = 19;
            limpiarbtn.Text = "Nuevo";
            limpiarbtn.UseVisualStyleBackColor = true;
            limpiarbtn.Click += limpiarbtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(seleccionimagenbtn);
            panel1.Controls.Add(imagencliente);
            panel1.Location = new Point(517, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(199, 255);
            panel1.TabIndex = 28;
            // 
            // seleccionimagenbtn
            // 
            seleccionimagenbtn.BackColor = Color.Lime;
            seleccionimagenbtn.Cursor = Cursors.Hand;
            seleccionimagenbtn.ForeColor = Color.Black;
            seleccionimagenbtn.Image = Properties.Resources.subir1;
            seleccionimagenbtn.Location = new Point(9, 191);
            seleccionimagenbtn.Name = "seleccionimagenbtn";
            seleccionimagenbtn.Size = new Size(181, 58);
            seleccionimagenbtn.TabIndex = 0;
            seleccionimagenbtn.Text = "Buscar Imagen";
            seleccionimagenbtn.TextAlign = ContentAlignment.BottomCenter;
            seleccionimagenbtn.UseVisualStyleBackColor = false;
            seleccionimagenbtn.Click += seleccionimagenbtn_Click;
            // 
            // imagencliente
            // 
            imagencliente.ErrorImage = Properties.Resources.perfilcliente;
            imagencliente.Image = Properties.Resources.perfilcliente;
            imagencliente.InitialImage = Properties.Resources.perfilcliente;
            imagencliente.Location = new Point(9, 6);
            imagencliente.Name = "imagencliente";
            imagencliente.Size = new Size(181, 181);
            imagencliente.SizeMode = PictureBoxSizeMode.StretchImage;
            imagencliente.TabIndex = 27;
            imagencliente.TabStop = false;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Image = Properties.Resources.atrás;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(611, 9);
            button2.Name = "button2";
            button2.Size = new Size(97, 29);
            button2.TabIndex = 26;
            button2.Text = " Volver";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // estadochk
            // 
            estadochk.AutoSize = true;
            estadochk.Checked = true;
            estadochk.CheckState = CheckState.Checked;
            estadochk.ForeColor = Color.Lime;
            estadochk.Location = new Point(617, 328);
            estadochk.Name = "estadochk";
            estadochk.Size = new Size(72, 25);
            estadochk.TabIndex = 25;
            estadochk.Text = "Activo";
            estadochk.UseVisualStyleBackColor = true;
            estadochk.CheckedChanged += estadochk_CheckedChanged;
            // 
            // emailtxt
            // 
            emailtxt.CharacterCasing = CharacterCasing.Upper;
            emailtxt.Location = new Point(11, 309);
            emailtxt.Name = "emailtxt";
            emailtxt.Size = new Size(440, 29);
            emailtxt.TabIndex = 2;
            emailtxt.KeyPress += txtapellido_KeyPress;
            // 
            // txtapellido
            // 
            txtapellido.CharacterCasing = CharacterCasing.Upper;
            txtapellido.Location = new Point(11, 237);
            txtapellido.Name = "txtapellido";
            txtapellido.Size = new Size(440, 29);
            txtapellido.TabIndex = 2;
            txtapellido.KeyPress += txtapellido_KeyPress;
            // 
            // idclientetxt
            // 
            idclientetxt.Enabled = false;
            idclientetxt.Location = new Point(43, 9);
            idclientetxt.Name = "idclientetxt";
            idclientetxt.Size = new Size(76, 29);
            idclientetxt.TabIndex = 12;
            idclientetxt.KeyPress += txtnombre_KeyPress;
            // 
            // identtxt
            // 
            identtxt.CharacterCasing = CharacterCasing.Upper;
            identtxt.Location = new Point(105, 93);
            identtxt.Name = "identtxt";
            identtxt.Size = new Size(153, 29);
            identtxt.TabIndex = 1;
            identtxt.TextChanged += identtxt_TextChanged;
            identtxt.KeyPress += identtxt_KeyPress;
            // 
            // txtnombre
            // 
            txtnombre.CharacterCasing = CharacterCasing.Upper;
            txtnombre.Location = new Point(11, 165);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(440, 29);
            txtnombre.TabIndex = 1;
            txtnombre.KeyPress += txtnombre_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(11, 284);
            label4.Name = "label4";
            label4.Size = new Size(53, 21);
            label4.TabIndex = 15;
            label4.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(11, 212);
            label6.Name = "label6";
            label6.Size = new Size(94, 21);
            label6.TabIndex = 15;
            label6.Text = "Apellido(s)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(546, 330);
            label8.Name = "label8";
            label8.Size = new Size(65, 21);
            label8.TabIndex = 16;
            label8.Text = "Estado:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(219, 3);
            label7.Name = "label7";
            label7.Size = new Size(289, 40);
            label7.TabIndex = 17;
            label7.Text = "Registro de Clientes";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label12.ForeColor = SystemColors.Control;
            label12.Location = new Point(11, 13);
            label12.Name = "label12";
            label12.Size = new Size(27, 21);
            label12.TabIndex = 18;
            label12.Text = "ID";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(11, 140);
            label9.Name = "label9";
            label9.Size = new Size(92, 21);
            label9.TabIndex = 18;
            label9.Text = "Nombre(s)";
            // 
            // ConsClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(734, 679);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConsClientes";
            StartPosition = FormStartPosition.Manual;
            Text = "Clientes";
            Load += ConsultaClientes_Load;
            KeyDown += ConsClientes_KeyDown;
            ((System.ComponentModel.ISupportInitialize)tabladatos).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)clienteimg).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)direccioncliente).EndInit();
            ((System.ComponentModel.ISupportInitialize)telefonocliente).EndInit();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imagencliente).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtbuscador;
        private DataGridView tabladatos;
        private Label label1;
        private Label label2;
        private Button eliminarbtn;
        private Label label3;
        private Button Editar;
        private Button agregar;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CheckBox estadochk;
        private TextBox txtapellido;
        private TextBox txtnombre;
        private Button limpiarbtn;
        private Button guardarbtn;
        private Label label6;
        private Label label8;
        private Label label7;
        private Label label9;
        private Button recargarbtn;
        private Button button2;
        private PictureBox imagencliente;
        private Panel panel1;
        private Button seleccionimagenbtn;
        private Panel panel3;
        private Label idenlabel;
        private PictureBox clienteimg;
        private TextBox idclientetxt;
        private Label label12;
        private CheckBox filtrochk;
        private Panel panel4;
        private Panel panel2;
        private Panel panel5;
        private Label label19;
        private TextBox direcciontxt;
        private TextBox numerotxt;
        private Label label13;
        private CheckBox principalDireccion;
        private CheckBox numPrincipalcmbx;
        private DataGridView direccioncliente;
        private DataGridView telefonocliente;
        private Button eliminarDireccion;
        private Button bajardireccion;
        private Button eliminarNumero;
        private Button bajarTelefono;
        private TextBox nombredirecciontxt;
        private TextBox nombrenumerotxt;
        private Label nombrelabel;
        private Label telefonolabel;
        private ComboBox tipodoccmbx;
        private Label label14;
        private TextBox identtxt;
        private TextBox emailtxt;
        private Label label4;
        private Label label10;
    }
}