namespace Proyecto_restaurante
{
    partial class ConsEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsEmpleados));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label11 = new Label();
            empleadoimg = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtbuscador = new TextBox();
            Editar = new Button();
            tabladatos = new DataGridView();
            agregar = new Button();
            recargarbtn = new Button();
            eliminarbtn = new Button();
            filtro = new CheckBox();
            tabPage2 = new TabPage();
            puestopanel = new Panel();
            idconsultatxt = new TextBox();
            puestoconsultatxt = new TextBox();
            button5 = new Button();
            label5 = new Label();
            puestoconsulta = new DataGridView();
            estadochk = new CheckBox();
            label8 = new Label();
            panel4 = new Panel();
            rolcmbx = new ComboBox();
            tiposueldocmbx = new ComboBox();
            fechaingreso = new DateTimePicker();
            idpuestotxt = new TextBox();
            puestotxt = new TextBox();
            label10 = new Label();
            buscarpuesto = new Button();
            panel2 = new Panel();
            panel5 = new Panel();
            label19 = new Label();
            direcciontxt = new TextBox();
            numerotxt = new TextBox();
            label13 = new Label();
            principalDireccion = new CheckBox();
            numPrincipalcmbx = new CheckBox();
            direccionEmpleado = new DataGridView();
            numeroEmpleado = new DataGridView();
            button7 = new Button();
            bajarDireccion = new Button();
            button6 = new Button();
            bajarTelefono = new Button();
            nombredirecciontxt = new TextBox();
            nombrenumerotxt = new TextBox();
            panel3 = new Panel();
            guardarbtn = new Button();
            limpiarbtn = new Button();
            panel1 = new Panel();
            seleccionimagenbtn = new Button();
            imagenempleado = new PictureBox();
            button2 = new Button();
            emailtxt = new TextBox();
            txtcedula = new TextBox();
            txtapellido = new TextBox();
            idUltimoEmpleado = new TextBox();
            txtsueldo = new TextBox();
            txtnombre = new TextBox();
            label14 = new Label();
            label17 = new Label();
            label16 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label12 = new Label();
            label15 = new Label();
            label9 = new Label();
            toolTip1 = new ToolTip(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)empleadoimg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabladatos).BeginInit();
            tabPage2.SuspendLayout();
            puestopanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)puestoconsulta).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)direccionEmpleado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numeroEmpleado).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imagenempleado).BeginInit();
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
            tabControl1.Size = new Size(772, 652);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.WindowFrame;
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(empleadoimg);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtbuscador);
            tabPage1.Controls.Add(Editar);
            tabPage1.Controls.Add(tabladatos);
            tabPage1.Controls.Add(agregar);
            tabPage1.Controls.Add(recargarbtn);
            tabPage1.Controls.Add(eliminarbtn);
            tabPage1.Controls.Add(filtro);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(764, 618);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Consulta";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(592, 420);
            label11.Name = "label11";
            label11.Size = new Size(67, 21);
            label11.TabIndex = 62;
            label11.Text = "Cedula:";
            // 
            // empleadoimg
            // 
            empleadoimg.ErrorImage = Properties.Resources.perfilcliente;
            empleadoimg.Image = Properties.Resources.perfilcliente;
            empleadoimg.InitialImage = Properties.Resources.perfilcliente;
            empleadoimg.Location = new Point(593, 254);
            empleadoimg.Name = "empleadoimg";
            empleadoimg.Size = new Size(158, 158);
            empleadoimg.SizeMode = PictureBoxSizeMode.StretchImage;
            empleadoimg.TabIndex = 61;
            empleadoimg.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(214, 5);
            label1.Name = "label1";
            label1.Size = new Size(336, 40);
            label1.TabIndex = 57;
            label1.Text = "Consulta de Empleados";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Image = Properties.Resources.busqueda;
            label2.Location = new Point(468, 69);
            label2.Name = "label2";
            label2.Size = new Size(18, 21);
            label2.TabIndex = 52;
            label2.Text = "  ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(615, 58);
            label3.Name = "label3";
            label3.Size = new Size(116, 32);
            label3.TabIndex = 60;
            label3.Text = "Acciones";
            // 
            // txtbuscador
            // 
            txtbuscador.CharacterCasing = CharacterCasing.Upper;
            txtbuscador.Font = new Font("Segoe UI", 12F);
            txtbuscador.ForeColor = SystemColors.ScrollBar;
            txtbuscador.Location = new Point(11, 65);
            txtbuscador.Name = "txtbuscador";
            txtbuscador.PlaceholderText = "Buscar Empleado";
            txtbuscador.Size = new Size(479, 29);
            txtbuscador.TabIndex = 53;
            // 
            // Editar
            // 
            Editar.Image = Properties.Resources.editarcliente1;
            Editar.Location = new Point(592, 177);
            Editar.Name = "Editar";
            Editar.Size = new Size(159, 72);
            Editar.TabIndex = 58;
            Editar.Text = "Editar";
            Editar.TextAlign = ContentAlignment.BottomCenter;
            Editar.UseVisualStyleBackColor = true;
            Editar.Click += Editar_Click;
            // 
            // tabladatos
            // 
            tabladatos.AllowUserToAddRows = false;
            tabladatos.AllowUserToDeleteRows = false;
            tabladatos.AllowUserToResizeRows = false;
            tabladatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabladatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabladatos.Location = new Point(11, 100);
            tabladatos.MultiSelect = false;
            tabladatos.Name = "tabladatos";
            tabladatos.ReadOnly = true;
            tabladatos.RowHeadersVisible = false;
            tabladatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabladatos.Size = new Size(575, 510);
            tabladatos.TabIndex = 54;
            tabladatos.CellClick += tabladatos_CellClick;
            // 
            // agregar
            // 
            agregar.Image = Properties.Resources.cliente1;
            agregar.Location = new Point(592, 100);
            agregar.Name = "agregar";
            agregar.Size = new Size(159, 72);
            agregar.TabIndex = 59;
            agregar.Text = "Nuevo";
            agregar.TextAlign = ContentAlignment.BottomCenter;
            agregar.UseVisualStyleBackColor = true;
            agregar.Click += agregar_Click;
            // 
            // recargarbtn
            // 
            recargarbtn.Image = Properties.Resources.actualizar;
            recargarbtn.Location = new Point(11, 11);
            recargarbtn.Name = "recargarbtn";
            recargarbtn.Size = new Size(29, 29);
            recargarbtn.TabIndex = 55;
            recargarbtn.UseVisualStyleBackColor = true;
            recargarbtn.Click += recargarbtn_Click;
            // 
            // eliminarbtn
            // 
            eliminarbtn.Image = Properties.Resources.limpio;
            eliminarbtn.Location = new Point(555, 65);
            eliminarbtn.Name = "eliminarbtn";
            eliminarbtn.Size = new Size(31, 29);
            eliminarbtn.TabIndex = 56;
            eliminarbtn.UseVisualStyleBackColor = true;
            eliminarbtn.Click += eliminarbtn_Click;
            // 
            // filtro
            // 
            filtro.AutoSize = true;
            filtro.Checked = true;
            filtro.CheckState = CheckState.Checked;
            filtro.Cursor = Cursors.Hand;
            filtro.Font = new Font("Segoe UI", 13F);
            filtro.Image = Properties.Resources.sicheck;
            filtro.Location = new Point(505, 66);
            filtro.Name = "filtro";
            filtro.Size = new Size(41, 29);
            filtro.TabIndex = 63;
            filtro.Text = "  ";
            filtro.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.WindowFrame;
            tabPage2.Controls.Add(puestopanel);
            tabPage2.Controls.Add(estadochk);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(panel4);
            tabPage2.Controls.Add(rolcmbx);
            tabPage2.Controls.Add(tiposueldocmbx);
            tabPage2.Controls.Add(fechaingreso);
            tabPage2.Controls.Add(idpuestotxt);
            tabPage2.Controls.Add(puestotxt);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(buscarpuesto);
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(panel5);
            tabPage2.Controls.Add(panel3);
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(emailtxt);
            tabPage2.Controls.Add(txtcedula);
            tabPage2.Controls.Add(txtapellido);
            tabPage2.Controls.Add(idUltimoEmpleado);
            tabPage2.Controls.Add(txtsueldo);
            tabPage2.Controls.Add(txtnombre);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(label17);
            tabPage2.Controls.Add(label16);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label15);
            tabPage2.Controls.Add(label9);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(764, 618);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Creación";
            // 
            // puestopanel
            // 
            puestopanel.BackColor = Color.FromArgb(64, 64, 64);
            puestopanel.Controls.Add(idconsultatxt);
            puestopanel.Controls.Add(puestoconsultatxt);
            puestopanel.Controls.Add(button5);
            puestopanel.Controls.Add(label5);
            puestopanel.Controls.Add(puestoconsulta);
            puestopanel.Location = new Point(264, 163);
            puestopanel.Name = "puestopanel";
            puestopanel.Size = new Size(227, 159);
            puestopanel.TabIndex = 100;
            puestopanel.Visible = false;
            // 
            // idconsultatxt
            // 
            idconsultatxt.Enabled = false;
            idconsultatxt.Location = new Point(4, 28);
            idconsultatxt.Name = "idconsultatxt";
            idconsultatxt.Size = new Size(31, 29);
            idconsultatxt.TabIndex = 58;
            // 
            // puestoconsultatxt
            // 
            puestoconsultatxt.Enabled = false;
            puestoconsultatxt.Location = new Point(37, 28);
            puestoconsultatxt.Name = "puestoconsultatxt";
            puestoconsultatxt.Size = new Size(154, 29);
            puestoconsultatxt.TabIndex = 58;
            // 
            // button5
            // 
            button5.ForeColor = Color.Black;
            button5.Image = Properties.Resources.angulo_hacia_arriba;
            button5.Location = new Point(194, 28);
            button5.Name = "button5";
            button5.Size = new Size(28, 29);
            button5.TabIndex = 60;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(5, 2);
            label5.Name = "label5";
            label5.Size = new Size(154, 21);
            label5.TabIndex = 50;
            label5.Text = "Seleccionar puesto";
            // 
            // puestoconsulta
            // 
            puestoconsulta.AllowUserToAddRows = false;
            puestoconsulta.AllowUserToDeleteRows = false;
            puestoconsulta.AllowUserToResizeRows = false;
            puestoconsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            puestoconsulta.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            puestoconsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            puestoconsulta.Location = new Point(4, 63);
            puestoconsulta.MultiSelect = false;
            puestoconsulta.Name = "puestoconsulta";
            puestoconsulta.ReadOnly = true;
            puestoconsulta.RowHeadersVisible = false;
            puestoconsulta.RowHeadersWidth = 51;
            puestoconsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            puestoconsulta.Size = new Size(219, 90);
            puestoconsulta.TabIndex = 74;
            puestoconsulta.CellClick += puestoconsulta_CellClick;
            puestoconsulta.CellContentDoubleClick += puestoconsulta_CellContentDoubleClick;
            // 
            // estadochk
            // 
            estadochk.AutoSize = true;
            estadochk.Checked = true;
            estadochk.CheckState = CheckState.Checked;
            estadochk.ForeColor = Color.Lime;
            estadochk.Location = new Point(641, 300);
            estadochk.Name = "estadochk";
            estadochk.Size = new Size(72, 25);
            estadochk.TabIndex = 90;
            estadochk.Text = "Activo";
            estadochk.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(570, 302);
            label8.Name = "label8";
            label8.Size = new Size(65, 21);
            label8.TabIndex = 86;
            label8.Text = "Estado:";
            // 
            // panel4
            // 
            panel4.Location = new Point(467, 338);
            panel4.Name = "panel4";
            panel4.Size = new Size(279, 26);
            panel4.TabIndex = 95;
            // 
            // rolcmbx
            // 
            rolcmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            rolcmbx.FormattingEnabled = true;
            rolcmbx.Items.AddRange(new object[] { "Gerente", "Administrator", "Supervisor", "Cajero", "Mesero", "Repartidor", "Cocinero" });
            rolcmbx.Location = new Point(19, 294);
            rolcmbx.Name = "rolcmbx";
            rolcmbx.Size = new Size(172, 29);
            rolcmbx.TabIndex = 102;
            // 
            // tiposueldocmbx
            // 
            tiposueldocmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            tiposueldocmbx.FormattingEnabled = true;
            tiposueldocmbx.Items.AddRange(new object[] { "Semanal", "Quincenal", "Mensual" });
            tiposueldocmbx.Location = new Point(367, 74);
            tiposueldocmbx.Name = "tiposueldocmbx";
            tiposueldocmbx.Size = new Size(87, 29);
            tiposueldocmbx.TabIndex = 102;
            // 
            // fechaingreso
            // 
            fechaingreso.Format = DateTimePickerFormat.Short;
            fechaingreso.Location = new Point(266, 184);
            fechaingreso.Name = "fechaingreso";
            fechaingreso.Size = new Size(172, 29);
            fechaingreso.TabIndex = 101;
            // 
            // idpuestotxt
            // 
            idpuestotxt.Enabled = false;
            idpuestotxt.Location = new Point(266, 129);
            idpuestotxt.Name = "idpuestotxt";
            idpuestotxt.Size = new Size(31, 29);
            idpuestotxt.TabIndex = 97;
            // 
            // puestotxt
            // 
            puestotxt.Enabled = false;
            puestotxt.Location = new Point(299, 129);
            puestotxt.Name = "puestotxt";
            puestotxt.Size = new Size(155, 29);
            puestotxt.TabIndex = 98;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(266, 107);
            label10.Name = "label10";
            label10.Size = new Size(144, 21);
            label10.TabIndex = 96;
            label10.Text = "Puesto de trabajo";
            // 
            // buscarpuesto
            // 
            buscarpuesto.ForeColor = Color.Black;
            buscarpuesto.Image = Properties.Resources.busqueda;
            buscarpuesto.Location = new Point(458, 129);
            buscarpuesto.Name = "buscarpuesto";
            buscarpuesto.Size = new Size(28, 29);
            buscarpuesto.TabIndex = 99;
            toolTip1.SetToolTip(buscarpuesto, "Buscar Puesto");
            buscarpuesto.UseVisualStyleBackColor = true;
            buscarpuesto.Click += buscarpuesto_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(221, 338);
            panel2.Name = "panel2";
            panel2.Size = new Size(130, 26);
            panel2.TabIndex = 95;
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
            panel5.Controls.Add(direccionEmpleado);
            panel5.Controls.Add(numeroEmpleado);
            panel5.Controls.Add(button7);
            panel5.Controls.Add(bajarDireccion);
            panel5.Controls.Add(button6);
            panel5.Controls.Add(bajarTelefono);
            panel5.Controls.Add(nombredirecciontxt);
            panel5.Controls.Add(nombrenumerotxt);
            panel5.Location = new Point(19, 338);
            panel5.Name = "panel5";
            panel5.Size = new Size(727, 206);
            panel5.TabIndex = 94;
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
            label19.Text = "Dirección     ";
            // 
            // direcciontxt
            // 
            direcciontxt.Location = new Point(411, 36);
            direcciontxt.Name = "direcciontxt";
            direcciontxt.PlaceholderText = "Dirección";
            direcciontxt.Size = new Size(179, 29);
            direcciontxt.TabIndex = 79;
            // 
            // numerotxt
            // 
            numerotxt.Location = new Point(81, 36);
            numerotxt.Name = "numerotxt";
            numerotxt.PlaceholderText = "Número";
            numerotxt.Size = new Size(113, 29);
            numerotxt.TabIndex = 79;
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
            label13.Text = "Número de teléfono     ";
            // 
            // principalDireccion
            // 
            principalDireccion.AutoSize = true;
            principalDireccion.ForeColor = Color.White;
            principalDireccion.Location = new Point(596, 38);
            principalDireccion.Name = "principalDireccion";
            principalDireccion.Size = new Size(89, 25);
            principalDireccion.TabIndex = 90;
            principalDireccion.Text = "Principal";
            principalDireccion.UseVisualStyleBackColor = true;
            // 
            // numPrincipalcmbx
            // 
            numPrincipalcmbx.AutoSize = true;
            numPrincipalcmbx.ForeColor = Color.White;
            numPrincipalcmbx.Location = new Point(200, 38);
            numPrincipalcmbx.Name = "numPrincipalcmbx";
            numPrincipalcmbx.Size = new Size(89, 25);
            numPrincipalcmbx.TabIndex = 90;
            numPrincipalcmbx.Text = "Principal";
            numPrincipalcmbx.UseVisualStyleBackColor = true;
            // 
            // direccionEmpleado
            // 
            direccionEmpleado.AllowUserToAddRows = false;
            direccionEmpleado.AllowUserToDeleteRows = false;
            direccionEmpleado.AllowUserToResizeRows = false;
            direccionEmpleado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            direccionEmpleado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            direccionEmpleado.Location = new Point(339, 71);
            direccionEmpleado.MultiSelect = false;
            direccionEmpleado.Name = "direccionEmpleado";
            direccionEmpleado.ReadOnly = true;
            direccionEmpleado.RowHeadersVisible = false;
            direccionEmpleado.RowHeadersWidth = 51;
            direccionEmpleado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            direccionEmpleado.Size = new Size(346, 129);
            direccionEmpleado.TabIndex = 74;
            direccionEmpleado.CellClick += direccionEmpleado_CellClick;
            // 
            // numeroEmpleado
            // 
            numeroEmpleado.AllowUserToAddRows = false;
            numeroEmpleado.AllowUserToDeleteRows = false;
            numeroEmpleado.AllowUserToResizeRows = false;
            numeroEmpleado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            numeroEmpleado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            numeroEmpleado.Location = new Point(9, 69);
            numeroEmpleado.MultiSelect = false;
            numeroEmpleado.Name = "numeroEmpleado";
            numeroEmpleado.ReadOnly = true;
            numeroEmpleado.RowHeadersVisible = false;
            numeroEmpleado.RowHeadersWidth = 51;
            numeroEmpleado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            numeroEmpleado.Size = new Size(281, 129);
            numeroEmpleado.TabIndex = 74;
            numeroEmpleado.CellClick += numeroEmpleado_CellClick;
            // 
            // button7
            // 
            button7.BackColor = Color.Red;
            button7.Image = Properties.Resources.basurablanco;
            button7.Location = new Point(691, 171);
            button7.Name = "button7";
            button7.Size = new Size(28, 29);
            button7.TabIndex = 77;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // bajarDireccion
            // 
            bajarDireccion.Image = Properties.Resources.angulo_hacia_abajo;
            bajarDireccion.Location = new Point(691, 36);
            bajarDireccion.Name = "bajarDireccion";
            bajarDireccion.Size = new Size(28, 29);
            bajarDireccion.TabIndex = 77;
            bajarDireccion.UseVisualStyleBackColor = true;
            bajarDireccion.Click += bajarDireccion_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Red;
            button6.Image = Properties.Resources.basurablanco;
            button6.Location = new Point(295, 169);
            button6.Name = "button6";
            button6.Size = new Size(28, 29);
            button6.TabIndex = 77;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // bajarTelefono
            // 
            bajarTelefono.Image = Properties.Resources.angulo_hacia_abajo;
            bajarTelefono.Location = new Point(295, 36);
            bajarTelefono.Name = "bajarTelefono";
            bajarTelefono.Size = new Size(28, 29);
            bajarTelefono.TabIndex = 77;
            bajarTelefono.UseVisualStyleBackColor = true;
            bajarTelefono.Click += bajarTelefono_Click;
            // 
            // nombredirecciontxt
            // 
            nombredirecciontxt.Location = new Point(339, 36);
            nombredirecciontxt.Name = "nombredirecciontxt";
            nombredirecciontxt.PlaceholderText = "Etiqueta";
            nombredirecciontxt.Size = new Size(66, 29);
            nombredirecciontxt.TabIndex = 79;
            // 
            // nombrenumerotxt
            // 
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
            panel3.Location = new Point(178, 541);
            panel3.Name = "panel3";
            panel3.Size = new Size(409, 74);
            panel3.TabIndex = 93;
            // 
            // guardarbtn
            // 
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
            panel1.Controls.Add(imagenempleado);
            panel1.Location = new Point(555, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(170, 229);
            panel1.TabIndex = 92;
            // 
            // seleccionimagenbtn
            // 
            seleccionimagenbtn.BackColor = Color.Lime;
            seleccionimagenbtn.ForeColor = Color.Black;
            seleccionimagenbtn.Image = Properties.Resources.subir1;
            seleccionimagenbtn.Location = new Point(9, 169);
            seleccionimagenbtn.Name = "seleccionimagenbtn";
            seleccionimagenbtn.Size = new Size(152, 56);
            seleccionimagenbtn.TabIndex = 0;
            seleccionimagenbtn.Text = "Buscar Imagen";
            seleccionimagenbtn.TextAlign = ContentAlignment.BottomCenter;
            seleccionimagenbtn.UseVisualStyleBackColor = false;
            seleccionimagenbtn.Click += seleccionimagenbtn_Click;
            // 
            // imagenempleado
            // 
            imagenempleado.ErrorImage = Properties.Resources.perfilcliente;
            imagenempleado.Image = Properties.Resources.perfilcliente;
            imagenempleado.InitialImage = Properties.Resources.perfilcliente;
            imagenempleado.Location = new Point(9, 11);
            imagenempleado.Name = "imagenempleado";
            imagenempleado.Size = new Size(152, 155);
            imagenempleado.SizeMode = PictureBoxSizeMode.StretchImage;
            imagenempleado.TabIndex = 27;
            imagenempleado.TabStop = false;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.atrás;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(645, 11);
            button2.Name = "button2";
            button2.Size = new Size(97, 29);
            button2.TabIndex = 91;
            button2.Text = " Volver";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // emailtxt
            // 
            emailtxt.CharacterCasing = CharacterCasing.Upper;
            emailtxt.Location = new Point(19, 239);
            emailtxt.Name = "emailtxt";
            emailtxt.Size = new Size(172, 29);
            emailtxt.TabIndex = 78;
            // 
            // txtcedula
            // 
            txtcedula.CharacterCasing = CharacterCasing.Upper;
            txtcedula.Location = new Point(19, 74);
            txtcedula.Name = "txtcedula";
            txtcedula.Size = new Size(172, 29);
            txtcedula.TabIndex = 78;
            txtcedula.TextChanged += txtcedula_TextChanged;
            // 
            // txtapellido
            // 
            txtapellido.CharacterCasing = CharacterCasing.Upper;
            txtapellido.Location = new Point(19, 184);
            txtapellido.Name = "txtapellido";
            txtapellido.Size = new Size(172, 29);
            txtapellido.TabIndex = 77;
            // 
            // idUltimoEmpleado
            // 
            idUltimoEmpleado.Enabled = false;
            idUltimoEmpleado.Location = new Point(51, 11);
            idUltimoEmpleado.Name = "idUltimoEmpleado";
            idUltimoEmpleado.Size = new Size(76, 29);
            idUltimoEmpleado.TabIndex = 81;
            // 
            // txtsueldo
            // 
            txtsueldo.Location = new Point(266, 74);
            txtsueldo.Name = "txtsueldo";
            txtsueldo.Size = new Size(98, 29);
            txtsueldo.TabIndex = 76;
            // 
            // txtnombre
            // 
            txtnombre.CharacterCasing = CharacterCasing.Upper;
            txtnombre.Location = new Point(19, 129);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(172, 29);
            txtnombre.TabIndex = 76;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label14.ForeColor = SystemColors.Control;
            label14.Location = new Point(266, 162);
            label14.Name = "label14";
            label14.Size = new Size(138, 21);
            label14.TabIndex = 82;
            label14.Text = "Fecha de ingreso";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label17.ForeColor = SystemColors.Control;
            label17.Location = new Point(19, 270);
            label17.Name = "label17";
            label17.Size = new Size(35, 21);
            label17.TabIndex = 82;
            label17.Text = "Rol";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label16.ForeColor = SystemColors.Control;
            label16.Location = new Point(19, 217);
            label16.Name = "label16";
            label16.Size = new Size(53, 21);
            label16.TabIndex = 82;
            label16.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(19, 52);
            label4.Name = "label4";
            label4.Size = new Size(63, 21);
            label4.TabIndex = 82;
            label4.Text = "Cédula";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(19, 162);
            label6.Name = "label6";
            label6.Size = new Size(94, 21);
            label6.TabIndex = 84;
            label6.Text = "Apellido(s)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(217, 5);
            label7.Name = "label7";
            label7.Size = new Size(330, 40);
            label7.TabIndex = 87;
            label7.Text = "Registro de Empleados";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label12.ForeColor = SystemColors.Control;
            label12.Location = new Point(15, 15);
            label12.Name = "label12";
            label12.Size = new Size(27, 21);
            label12.TabIndex = 89;
            label12.Text = "ID";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label15.ForeColor = SystemColors.Control;
            label15.Location = new Point(266, 52);
            label15.Name = "label15";
            label15.Size = new Size(63, 21);
            label15.TabIndex = 88;
            label15.Text = "Sueldo";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(19, 107);
            label9.Name = "label9";
            label9.Size = new Size(92, 21);
            label9.TabIndex = 88;
            label9.Text = "Nombre(s)";
            // 
            // ConsEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(772, 652);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConsEmpleados";
            StartPosition = FormStartPosition.Manual;
            Text = "Empleados";
            Load += ConsEmpleados_Load;
            KeyDown += ConsEmpleados_KeyDown;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)empleadoimg).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabladatos).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            puestopanel.ResumeLayout(false);
            puestopanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)puestoconsulta).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)direccionEmpleado).EndInit();
            ((System.ComponentModel.ISupportInitialize)numeroEmpleado).EndInit();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imagenempleado).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label11;
        private PictureBox empleadoimg;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtbuscador;
        private Button Editar;
        private DataGridView tabladatos;
        private Button agregar;
        private Button recargarbtn;
        private Button eliminarbtn;
        private CheckBox filtro;
        private Panel panel3;
        private Button guardarbtn;
        private Button limpiarbtn;
        private Panel panel1;
        private Button seleccionimagenbtn;
        private PictureBox imagenempleado;
        private Button button2;
        private CheckBox estadochk;
        private TextBox txtcedula;
        private TextBox txtapellido;
        private TextBox idUltimoEmpleado;
        private TextBox txtnombre;
        private Label label4;
        private Label label6;
        private Label label8;
        private Label label7;
        private Label label12;
        private Label label9;
        private Panel panel5;
        private Label label19;
        private TextBox direcciontxt;
        private TextBox numerotxt;
        private Label label13;
        private DataGridView direccionEmpleado;
        private DataGridView numeroEmpleado;
        private Button bajarTelefono;
        private TextBox nombredirecciontxt;
        private TextBox nombrenumerotxt;
        private CheckBox numPrincipalcmbx;
        private Button bajarDireccion;
        private Panel panel4;
        private Panel panel2;
        private TextBox idpuestotxt;
        private TextBox puestotxt;
        private Label label10;
        private Button buscarpuesto;
        private Panel puestopanel;
        private TextBox idconsultatxt;
        private TextBox puestoconsultatxt;
        private Button button5;
        private Label label5;
        private DataGridView puestoconsulta;
        private DateTimePicker fechaingreso;
        private CheckBox principalDireccion;
        private Label label14;
        private ComboBox tiposueldocmbx;
        private TextBox txtsueldo;
        private Label label15;
        private Button button7;
        private Button button6;
        private TextBox emailtxt;
        private Label label16;
        private ToolTip toolTip1;
        private ComboBox rolcmbx;
        private Label label17;
    }
}