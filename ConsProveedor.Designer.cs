namespace Proyecto_restaurante
{
    partial class ConsProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsProveedor));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            provdt = new DataGridView();
            label2 = new Label();
            informalfiltro = new CheckBox();
            filtro = new CheckBox();
            label11 = new Label();
            clienteimg = new PictureBox();
            label3 = new Label();
            Editar = new Button();
            agregar = new Button();
            recargarbtn = new Button();
            label12 = new Label();
            eliminarbtn = new Button();
            txtbuscador = new TextBox();
            tabPage2 = new TabPage();
            informalchk = new CheckBox();
            tipodoccmbx = new ComboBox();
            estadochk = new CheckBox();
            label14 = new Label();
            identtxt = new TextBox();
            label8 = new Label();
            panel1 = new Panel();
            seleccionimagenbtn = new Button();
            imagenprov = new PictureBox();
            button2 = new Button();
            label1 = new Label();
            panel3 = new Panel();
            guardarbtn = new Button();
            limpiarbtn = new Button();
            panel4 = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            label19 = new Label();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            label15 = new Label();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            dataGridView2 = new DataGridView();
            ingredientesconsulta = new DataGridView();
            button7 = new Button();
            button4 = new Button();
            button6 = new Button();
            button3 = new Button();
            textBox2 = new TextBox();
            txtcodigo = new TextBox();
            label9 = new Label();
            label4 = new Label();
            label7 = new Label();
            idprovtxt = new TextBox();
            correotxt = new TextBox();
            nombreprovtxt = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)provdt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteimg).BeginInit();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imagenprov).BeginInit();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ingredientesconsulta).BeginInit();
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
            tabControl1.ShowToolTips = true;
            tabControl1.Size = new Size(914, 653);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.WindowFrame;
            tabPage1.Controls.Add(provdt);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(informalfiltro);
            tabPage1.Controls.Add(filtro);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(clienteimg);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(Editar);
            tabPage1.Controls.Add(agregar);
            tabPage1.Controls.Add(recargarbtn);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(eliminarbtn);
            tabPage1.Controls.Add(txtbuscador);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(906, 619);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Consulta";
            // 
            // provdt
            // 
            provdt.AllowUserToAddRows = false;
            provdt.AllowUserToDeleteRows = false;
            provdt.AllowUserToResizeRows = false;
            provdt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            provdt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            provdt.Location = new Point(8, 101);
            provdt.MultiSelect = false;
            provdt.Name = "provdt";
            provdt.ReadOnly = true;
            provdt.RowHeadersVisible = false;
            provdt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            provdt.Size = new Size(727, 511);
            provdt.TabIndex = 64;
            provdt.CellClick += provdt_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Image = Properties.Resources.busqueda;
            label2.Location = new Point(572, 66);
            label2.Name = "label2";
            label2.Size = new Size(18, 21);
            label2.TabIndex = 63;
            label2.Text = "  ";
            // 
            // informalfiltro
            // 
            informalfiltro.AutoSize = true;
            informalfiltro.Cursor = Cursors.Hand;
            informalfiltro.Font = new Font("Segoe UI", 13F);
            informalfiltro.Image = Properties.Resources.informal;
            informalfiltro.Location = new Point(604, 62);
            informalfiltro.Name = "informalfiltro";
            informalfiltro.Size = new Size(41, 29);
            informalfiltro.TabIndex = 62;
            informalfiltro.Text = "  ";
            informalfiltro.UseVisualStyleBackColor = true;
            // 
            // filtro
            // 
            filtro.AutoSize = true;
            filtro.Checked = true;
            filtro.CheckState = CheckState.Checked;
            filtro.Cursor = Cursors.Hand;
            filtro.Font = new Font("Segoe UI", 13F);
            filtro.Image = Properties.Resources.sicheck;
            filtro.Location = new Point(656, 62);
            filtro.Name = "filtro";
            filtro.Size = new Size(41, 29);
            filtro.TabIndex = 62;
            filtro.Text = "  ";
            filtro.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(741, 421);
            label11.Name = "label11";
            label11.Size = new Size(107, 21);
            label11.TabIndex = 61;
            label11.Text = "RNC/Cedula:";
            // 
            // clienteimg
            // 
            clienteimg.ErrorImage = Properties.Resources.perfilcliente;
            clienteimg.Image = Properties.Resources.perfilcliente;
            clienteimg.InitialImage = Properties.Resources.perfilcliente;
            clienteimg.Location = new Point(742, 255);
            clienteimg.Name = "clienteimg";
            clienteimg.Size = new Size(158, 158);
            clienteimg.SizeMode = PictureBoxSizeMode.StretchImage;
            clienteimg.TabIndex = 60;
            clienteimg.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(764, 59);
            label3.Name = "label3";
            label3.Size = new Size(116, 32);
            label3.TabIndex = 59;
            label3.Text = "Acciones";
            // 
            // Editar
            // 
            Editar.Image = Properties.Resources.editarcliente1;
            Editar.Location = new Point(741, 178);
            Editar.Name = "Editar";
            Editar.Size = new Size(159, 72);
            Editar.TabIndex = 57;
            Editar.Text = "Editar";
            Editar.TextAlign = ContentAlignment.BottomCenter;
            Editar.UseVisualStyleBackColor = true;
            // 
            // agregar
            // 
            agregar.Image = Properties.Resources.cliente1;
            agregar.Location = new Point(741, 101);
            agregar.Name = "agregar";
            agregar.Size = new Size(159, 72);
            agregar.TabIndex = 58;
            agregar.Text = "Nuevo";
            agregar.TextAlign = ContentAlignment.BottomCenter;
            agregar.UseVisualStyleBackColor = true;
            agregar.Click += agregar_Click;
            // 
            // recargarbtn
            // 
            recargarbtn.Image = Properties.Resources.actualizar;
            recargarbtn.Location = new Point(8, 12);
            recargarbtn.Name = "recargarbtn";
            recargarbtn.Size = new Size(29, 29);
            recargarbtn.TabIndex = 56;
            recargarbtn.TabStop = false;
            recargarbtn.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label12.ForeColor = SystemColors.Control;
            label12.Location = new Point(273, 6);
            label12.Name = "label12";
            label12.Size = new Size(360, 40);
            label12.TabIndex = 55;
            label12.Text = "Consulta de Proveedores";
            // 
            // eliminarbtn
            // 
            eliminarbtn.Image = Properties.Resources.limpio;
            eliminarbtn.Location = new Point(706, 62);
            eliminarbtn.Name = "eliminarbtn";
            eliminarbtn.Size = new Size(29, 29);
            eliminarbtn.TabIndex = 54;
            eliminarbtn.UseVisualStyleBackColor = true;
            // 
            // txtbuscador
            // 
            txtbuscador.CharacterCasing = CharacterCasing.Upper;
            txtbuscador.ForeColor = SystemColors.ScrollBar;
            txtbuscador.Location = new Point(8, 62);
            txtbuscador.Name = "txtbuscador";
            txtbuscador.PlaceholderText = "Buscar Proveedor";
            txtbuscador.Size = new Size(586, 29);
            txtbuscador.TabIndex = 53;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.WindowFrame;
            tabPage2.Controls.Add(informalchk);
            tabPage2.Controls.Add(tipodoccmbx);
            tabPage2.Controls.Add(estadochk);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(identtxt);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(panel3);
            tabPage2.Controls.Add(panel4);
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(panel5);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(idprovtxt);
            tabPage2.Controls.Add(correotxt);
            tabPage2.Controls.Add(nombreprovtxt);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(906, 619);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Creación";
            // 
            // informalchk
            // 
            informalchk.AutoSize = true;
            informalchk.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            informalchk.ForeColor = Color.White;
            informalchk.Image = Properties.Resources.informal;
            informalchk.ImageAlign = ContentAlignment.MiddleRight;
            informalchk.Location = new Point(297, 111);
            informalchk.Name = "informalchk";
            informalchk.Size = new Size(111, 25);
            informalchk.TabIndex = 104;
            informalchk.Text = "Informal    ";
            informalchk.UseVisualStyleBackColor = true;
            // 
            // tipodoccmbx
            // 
            tipodoccmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            tipodoccmbx.FormattingEnabled = true;
            tipodoccmbx.Items.AddRange(new object[] { "RNC", "Cedula" });
            tipodoccmbx.Location = new Point(33, 109);
            tipodoccmbx.Name = "tipodoccmbx";
            tipodoccmbx.Size = new Size(94, 29);
            tipodoccmbx.TabIndex = 103;
            // 
            // estadochk
            // 
            estadochk.AutoSize = true;
            estadochk.Checked = true;
            estadochk.CheckState = CheckState.Checked;
            estadochk.ForeColor = Color.Lime;
            estadochk.Location = new Point(771, 311);
            estadochk.Name = "estadochk";
            estadochk.Size = new Size(72, 25);
            estadochk.TabIndex = 103;
            estadochk.Text = "Activo";
            estadochk.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label14.ForeColor = SystemColors.Control;
            label14.Location = new Point(33, 85);
            label14.Name = "label14";
            label14.Size = new Size(211, 21);
            label14.TabIndex = 102;
            label14.Text = "Documento de indentidad";
            // 
            // identtxt
            // 
            identtxt.CharacterCasing = CharacterCasing.Upper;
            identtxt.Location = new Point(131, 109);
            identtxt.Name = "identtxt";
            identtxt.Size = new Size(159, 29);
            identtxt.TabIndex = 101;
            identtxt.TextChanged += identtxt_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(700, 313);
            label8.Name = "label8";
            label8.Size = new Size(65, 21);
            label8.TabIndex = 102;
            label8.Text = "Estado:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(seleccionimagenbtn);
            panel1.Controls.Add(imagenprov);
            panel1.Location = new Point(675, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(199, 255);
            panel1.TabIndex = 101;
            // 
            // seleccionimagenbtn
            // 
            seleccionimagenbtn.BackColor = Color.Lime;
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
            // imagenprov
            // 
            imagenprov.ErrorImage = Properties.Resources.perfilcliente;
            imagenprov.Image = Properties.Resources.perfilcliente;
            imagenprov.InitialImage = Properties.Resources.perfilcliente;
            imagenprov.Location = new Point(9, 6);
            imagenprov.Name = "imagenprov";
            imagenprov.Size = new Size(181, 181);
            imagenprov.SizeMode = PictureBoxSizeMode.StretchImage;
            imagenprov.TabIndex = 27;
            imagenprov.TabStop = false;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.atrás;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(777, 9);
            button2.Name = "button2";
            button2.Size = new Size(97, 29);
            button2.TabIndex = 100;
            button2.Text = " Volver";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(276, 3);
            label1.Name = "label1";
            label1.Size = new Size(354, 40);
            label1.TabIndex = 99;
            label1.Text = "Registro de Proveedores";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(64, 64, 64);
            panel3.Controls.Add(guardarbtn);
            panel3.Controls.Add(limpiarbtn);
            panel3.Location = new Point(249, 543);
            panel3.Name = "panel3";
            panel3.Size = new Size(409, 74);
            panel3.TabIndex = 94;
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
            // 
            // panel4
            // 
            panel4.Location = new Point(480, 339);
            panel4.Name = "panel4";
            panel4.Size = new Size(394, 26);
            panel4.TabIndex = 98;
            // 
            // panel2
            // 
            panel2.Location = new Point(236, 339);
            panel2.Name = "panel2";
            panel2.Size = new Size(130, 26);
            panel2.TabIndex = 97;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(64, 64, 64);
            panel5.Controls.Add(label19);
            panel5.Controls.Add(textBox3);
            panel5.Controls.Add(textBox1);
            panel5.Controls.Add(label15);
            panel5.Controls.Add(checkBox2);
            panel5.Controls.Add(checkBox1);
            panel5.Controls.Add(dataGridView2);
            panel5.Controls.Add(ingredientesconsulta);
            panel5.Controls.Add(button7);
            panel5.Controls.Add(button4);
            panel5.Controls.Add(button6);
            panel5.Controls.Add(button3);
            panel5.Controls.Add(textBox2);
            panel5.Controls.Add(txtcodigo);
            panel5.Location = new Point(33, 339);
            panel5.Name = "panel5";
            panel5.Size = new Size(841, 206);
            panel5.TabIndex = 96;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label19.ForeColor = Color.White;
            label19.Image = Properties.Resources.ubicacion;
            label19.ImageAlign = ContentAlignment.MiddleRight;
            label19.Location = new Point(339, 4);
            label19.Name = "label19";
            label19.Size = new Size(103, 21);
            label19.TabIndex = 55;
            label19.Text = "Dirección     ";
            // 
            // textBox3
            // 
            textBox3.CharacterCasing = CharacterCasing.Upper;
            textBox3.Location = new Point(407, 36);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Dirección completa";
            textBox3.Size = new Size(291, 29);
            textBox3.TabIndex = 79;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(77, 36);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Teléfono";
            textBox1.Size = new Size(115, 29);
            textBox1.TabIndex = 79;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label15.ForeColor = Color.White;
            label15.Image = Properties.Resources.telefonoblanco;
            label15.ImageAlign = ContentAlignment.MiddleRight;
            label15.Location = new Point(9, 4);
            label15.Name = "label15";
            label15.Size = new Size(185, 21);
            label15.TabIndex = 55;
            label15.Text = "Número de teléfono     ";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.ForeColor = Color.White;
            checkBox2.Location = new Point(708, 38);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(89, 25);
            checkBox2.TabIndex = 90;
            checkBox2.Text = "Principal";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(201, 38);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(89, 25);
            checkBox1.TabIndex = 90;
            checkBox1.Text = "Principal";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(339, 71);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(458, 129);
            dataGridView2.TabIndex = 74;
            // 
            // ingredientesconsulta
            // 
            ingredientesconsulta.AllowUserToAddRows = false;
            ingredientesconsulta.AllowUserToDeleteRows = false;
            ingredientesconsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ingredientesconsulta.Location = new Point(9, 69);
            ingredientesconsulta.MultiSelect = false;
            ingredientesconsulta.Name = "ingredientesconsulta";
            ingredientesconsulta.ReadOnly = true;
            ingredientesconsulta.RowHeadersWidth = 51;
            ingredientesconsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ingredientesconsulta.Size = new Size(281, 129);
            ingredientesconsulta.TabIndex = 74;
            // 
            // button7
            // 
            button7.BackColor = Color.Red;
            button7.Enabled = false;
            button7.Image = Properties.Resources.basurablanco;
            button7.Location = new Point(803, 171);
            button7.Name = "button7";
            button7.Size = new Size(29, 29);
            button7.TabIndex = 77;
            button7.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.Image = Properties.Resources.angulo_hacia_abajo;
            button4.Location = new Point(803, 36);
            button4.Name = "button4";
            button4.Size = new Size(29, 29);
            button4.TabIndex = 77;
            button4.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.BackColor = Color.Red;
            button6.Enabled = false;
            button6.Image = Properties.Resources.basurablanco;
            button6.Location = new Point(295, 169);
            button6.Name = "button6";
            button6.Size = new Size(29, 29);
            button6.TabIndex = 77;
            button6.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.angulo_hacia_abajo;
            button3.Location = new Point(295, 36);
            button3.Name = "button3";
            button3.Size = new Size(29, 29);
            button3.TabIndex = 77;
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox2.Location = new Point(339, 36);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Etiqueta";
            textBox2.Size = new Size(66, 29);
            textBox2.TabIndex = 79;
            // 
            // txtcodigo
            // 
            txtcodigo.CharacterCasing = CharacterCasing.Upper;
            txtcodigo.Location = new Point(9, 36);
            txtcodigo.Name = "txtcodigo";
            txtcodigo.PlaceholderText = "Etiqueta";
            txtcodigo.Size = new Size(66, 29);
            txtcodigo.TabIndex = 79;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(33, 237);
            label9.Name = "label9";
            label9.Size = new Size(53, 21);
            label9.TabIndex = 64;
            label9.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(18, 13);
            label4.Name = "label4";
            label4.Size = new Size(27, 21);
            label4.TabIndex = 60;
            label4.Text = "ID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(33, 161);
            label7.Name = "label7";
            label7.Size = new Size(150, 21);
            label7.TabIndex = 60;
            label7.Text = "Nombre completo";
            // 
            // idprovtxt
            // 
            idprovtxt.Enabled = false;
            idprovtxt.Location = new Point(54, 9);
            idprovtxt.Name = "idprovtxt";
            idprovtxt.Size = new Size(73, 29);
            idprovtxt.TabIndex = 57;
            // 
            // correotxt
            // 
            correotxt.CharacterCasing = CharacterCasing.Upper;
            correotxt.Location = new Point(33, 261);
            correotxt.Name = "correotxt";
            correotxt.Size = new Size(355, 29);
            correotxt.TabIndex = 54;
            // 
            // nombreprovtxt
            // 
            nombreprovtxt.CharacterCasing = CharacterCasing.Upper;
            nombreprovtxt.Location = new Point(33, 185);
            nombreprovtxt.Name = "nombreprovtxt";
            nombreprovtxt.Size = new Size(355, 29);
            nombreprovtxt.TabIndex = 57;
            // 
            // ConsProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(914, 653);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConsProveedor";
            StartPosition = FormStartPosition.Manual;
            Text = "Proveedores";
            Load += ConsProveedor_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)provdt).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteimg).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imagenprov).EndInit();
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ingredientesconsulta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        public Button recargarbtn;
        private Label label12;
        private Button eliminarbtn;
        private TextBox txtbuscador;
        private Label label11;
        private PictureBox clienteimg;
        private Label label3;
        private Button Editar;
        private Button agregar;
        private CheckBox filtro;
        private Label label2;
        private Label label9;
        private Label label7;
        private TextBox correotxt;
        private TextBox nombreprovtxt;
        private Panel panel4;
        private Panel panel2;
        private Panel panel5;
        private Label label19;
        private TextBox textBox3;
        private TextBox textBox1;
        private Label label15;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private DataGridView dataGridView2;
        private DataGridView ingredientesconsulta;
        private Button button7;
        private Button button4;
        private Button button6;
        private Button button3;
        private TextBox textBox2;
        private TextBox txtcodigo;
        private Label label1;
        private Panel panel3;
        private Button guardarbtn;
        private Button limpiarbtn;
        private Label label4;
        private TextBox idprovtxt;
        private Panel panel1;
        private Button seleccionimagenbtn;
        private PictureBox imagenprov;
        private Button button2;
        private CheckBox estadochk;
        private Label label8;
        private ComboBox tipodoccmbx;
        private Label label14;
        private TextBox identtxt;
        private CheckBox informalchk;
        private CheckBox informalfiltro;
        private DataGridView provdt;
    }
}