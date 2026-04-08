namespace Proyecto_restaurante
{
    partial class ConsProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsProductos));
            label11 = new Label();
            eliminarbtn = new Button();
            label12 = new Label();
            tabladatos = new DataGridView();
            txtbuscador = new TextBox();
            agregar = new Button();
            Editar = new Button();
            panel1 = new Panel();
            label2 = new Label();
            imagenproducto = new PictureBox();
            label1 = new Label();
            recargarbtn = new Button();
            tabControl1 = new TabControl();
            consulta = new TabPage();
            panel2 = new Panel();
            filtroingredientes = new CheckBox();
            filtroplatos = new CheckBox();
            filtrotodos = new CheckBox();
            filtro = new CheckBox();
            label15 = new Label();
            creacion = new TabPage();
            panel6 = new Panel();
            panel3 = new Panel();
            seleccionpanel = new Panel();
            button7 = new Button();
            label20 = new Label();
            label19 = new Label();
            textBox1 = new TextBox();
            numCantidad = new NumericUpDown();
            label6 = new Label();
            nombreprodreceta = new TextBox();
            recetaingredientes = new DataGridView();
            ingredientesconsulta = new DataGridView();
            costoIng = new TextBox();
            idprodreceta = new TextBox();
            unimedidareceta = new TextBox();
            agregarbtn = new Button();
            panel9 = new Panel();
            panel8 = new Panel();
            autoCalcular = new CheckBox();
            panel7 = new Panel();
            panel5 = new Panel();
            ultimoID = new TextBox();
            label18 = new Label();
            idcategoriatxt = new TextBox();
            imagenpanel = new Panel();
            imagenprod = new PictureBox();
            seleccionimagenbtn = new Button();
            panel4 = new Panel();
            guardarbtn = new Button();
            limpiarbtn = new Button();
            button1 = new Button();
            tipoproductocmbx = new ComboBox();
            label13 = new Label();
            txtprecio_compra = new TextBox();
            categoriatxt = new TextBox();
            txtnombre_prod = new TextBox();
            txtcodigo_barras = new TextBox();
            txtprecio_venta = new TextBox();
            label16 = new Label();
            label21 = new Label();
            label8 = new Label();
            label4 = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label17 = new Label();
            label10 = new Label();
            label14 = new Label();
            estadochk = new CheckBox();
            codigobarrarandombtn = new Button();
            buscarcateg = new Button();
            unidadmedida = new ComboBox();
            ITBIS = new ComboBox();
            categoriapanel = new Panel();
            idconsultatxt = new TextBox();
            categoriaconsultatxt = new TextBox();
            button4 = new Button();
            label9 = new Label();
            categoriaconsulta = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabladatos).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imagenproducto).BeginInit();
            tabControl1.SuspendLayout();
            consulta.SuspendLayout();
            panel2.SuspendLayout();
            creacion.SuspendLayout();
            seleccionpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)recetaingredientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ingredientesconsulta).BeginInit();
            imagenpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imagenprod).BeginInit();
            panel4.SuspendLayout();
            categoriapanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaconsulta).BeginInit();
            SuspendLayout();
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label11.ForeColor = SystemColors.Control;
            label11.Location = new Point(256, 4);
            label11.Name = "label11";
            label11.Size = new Size(327, 40);
            label11.TabIndex = 42;
            label11.Text = "Consulta de Productos";
            // 
            // eliminarbtn
            // 
            eliminarbtn.Image = Properties.Resources.limpio;
            eliminarbtn.Location = new Point(635, 55);
            eliminarbtn.Name = "eliminarbtn";
            eliminarbtn.Size = new Size(29, 29);
            eliminarbtn.TabIndex = 41;
            eliminarbtn.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.White;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label12.ForeColor = SystemColors.Control;
            label12.Image = Properties.Resources.busqueda1;
            label12.Location = new Point(359, 59);
            label12.Name = "label12";
            label12.Size = new Size(18, 21);
            label12.TabIndex = 38;
            label12.Text = "  ";
            // 
            // tabladatos
            // 
            tabladatos.AllowUserToAddRows = false;
            tabladatos.AllowUserToDeleteRows = false;
            tabladatos.AllowUserToResizeRows = false;
            tabladatos.Anchor = AnchorStyles.None;
            tabladatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabladatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tabladatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabladatos.Location = new Point(8, 92);
            tabladatos.MultiSelect = false;
            tabladatos.Name = "tabladatos";
            tabladatos.ReadOnly = true;
            tabladatos.RowHeadersVisible = false;
            tabladatos.RowHeadersWidth = 51;
            tabladatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabladatos.Size = new Size(656, 558);
            tabladatos.TabIndex = 39;
            tabladatos.CellClick += tabladatos_CellClick;
            // 
            // txtbuscador
            // 
            txtbuscador.CharacterCasing = CharacterCasing.Upper;
            txtbuscador.ForeColor = SystemColors.ScrollBar;
            txtbuscador.Location = new Point(8, 55);
            txtbuscador.Name = "txtbuscador";
            txtbuscador.PlaceholderText = "Buscar Producto";
            txtbuscador.Size = new Size(374, 29);
            txtbuscador.TabIndex = 1;
            // 
            // agregar
            // 
            agregar.Image = Properties.Resources.producto;
            agregar.Location = new Point(672, 92);
            agregar.Name = "agregar";
            agregar.Size = new Size(159, 72);
            agregar.TabIndex = 43;
            agregar.Text = "Nuevo";
            agregar.TextAlign = ContentAlignment.BottomCenter;
            agregar.UseVisualStyleBackColor = true;
            agregar.Click += agregar_Click;
            // 
            // Editar
            // 
            Editar.Image = Properties.Resources.editar;
            Editar.Location = new Point(672, 170);
            Editar.Name = "Editar";
            Editar.Size = new Size(159, 72);
            Editar.TabIndex = 43;
            Editar.Text = "Editar";
            Editar.TextAlign = ContentAlignment.BottomCenter;
            Editar.UseVisualStyleBackColor = true;
            Editar.Click += Editar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(imagenproducto);
            panel1.Location = new Point(667, 246);
            panel1.Name = "panel1";
            panel1.Size = new Size(169, 404);
            panel1.TabIndex = 44;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(7, 4);
            label2.Name = "label2";
            label2.Size = new Size(155, 64);
            label2.TabIndex = 46;
            label2.Text = "Informacion\r\n    General";
            // 
            // imagenproducto
            // 
            imagenproducto.ErrorImage = Properties.Resources.paisaje;
            imagenproducto.Image = Properties.Resources.paisaje;
            imagenproducto.InitialImage = Properties.Resources.paisaje;
            imagenproducto.Location = new Point(5, 71);
            imagenproducto.Name = "imagenproducto";
            imagenproducto.Size = new Size(159, 159);
            imagenproducto.SizeMode = PictureBoxSizeMode.StretchImage;
            imagenproducto.TabIndex = 0;
            imagenproducto.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(693, 50);
            label1.Name = "label1";
            label1.Size = new Size(116, 32);
            label1.TabIndex = 45;
            label1.Text = "Acciones";
            // 
            // recargarbtn
            // 
            recargarbtn.Image = Properties.Resources.actualizar;
            recargarbtn.Location = new Point(8, 10);
            recargarbtn.Name = "recargarbtn";
            recargarbtn.Size = new Size(29, 29);
            recargarbtn.TabIndex = 46;
            recargarbtn.TabStop = false;
            recargarbtn.UseVisualStyleBackColor = true;
            recargarbtn.Click += recargarbtn_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(consulta);
            tabControl1.Controls.Add(creacion);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(847, 690);
            tabControl1.TabIndex = 47;
            // 
            // consulta
            // 
            consulta.BackColor = SystemColors.WindowFrame;
            consulta.Controls.Add(panel2);
            consulta.Controls.Add(label12);
            consulta.Controls.Add(recargarbtn);
            consulta.Controls.Add(panel1);
            consulta.Controls.Add(Editar);
            consulta.Controls.Add(label1);
            consulta.Controls.Add(agregar);
            consulta.Controls.Add(tabladatos);
            consulta.Controls.Add(eliminarbtn);
            consulta.Controls.Add(label11);
            consulta.Controls.Add(txtbuscador);
            consulta.Location = new Point(4, 30);
            consulta.Name = "consulta";
            consulta.Padding = new Padding(3);
            consulta.Size = new Size(839, 656);
            consulta.TabIndex = 0;
            consulta.Text = "Consulta";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(64, 64, 64);
            panel2.Controls.Add(filtroingredientes);
            panel2.Controls.Add(filtroplatos);
            panel2.Controls.Add(filtrotodos);
            panel2.Controls.Add(filtro);
            panel2.Controls.Add(label15);
            panel2.Location = new Point(385, 53);
            panel2.Name = "panel2";
            panel2.Size = new Size(244, 32);
            panel2.TabIndex = 47;
            // 
            // filtroingredientes
            // 
            filtroingredientes.AutoSize = true;
            filtroingredientes.Cursor = Cursors.Hand;
            filtroingredientes.Font = new Font("Segoe UI", 13F);
            filtroingredientes.Image = Properties.Resources.saleroblanco;
            filtroingredientes.Location = new Point(145, 2);
            filtroingredientes.Name = "filtroingredientes";
            filtroingredientes.Size = new Size(41, 29);
            filtroingredientes.TabIndex = 0;
            filtroingredientes.Text = "  ";
            filtroingredientes.UseVisualStyleBackColor = true;
            filtroingredientes.CheckedChanged += filtroingredientes_CheckedChanged;
            // 
            // filtroplatos
            // 
            filtroplatos.AutoSize = true;
            filtroplatos.Cursor = Cursors.Hand;
            filtroplatos.Font = new Font("Segoe UI", 13F);
            filtroplatos.Image = Properties.Resources.cuchilloblanco;
            filtroplatos.Location = new Point(90, 2);
            filtroplatos.Name = "filtroplatos";
            filtroplatos.Size = new Size(41, 29);
            filtroplatos.TabIndex = 0;
            filtroplatos.Text = "  ";
            filtroplatos.UseVisualStyleBackColor = true;
            filtroplatos.CheckedChanged += filtroplatos_CheckedChanged;
            // 
            // filtrotodos
            // 
            filtrotodos.AutoSize = true;
            filtrotodos.Checked = true;
            filtrotodos.CheckState = CheckState.Checked;
            filtrotodos.Cursor = Cursors.Hand;
            filtrotodos.Font = new Font("Segoe UI", 13F);
            filtrotodos.Image = Properties.Resources.mundoblanco;
            filtrotodos.Location = new Point(35, 2);
            filtrotodos.Name = "filtrotodos";
            filtrotodos.Size = new Size(41, 29);
            filtrotodos.TabIndex = 0;
            filtrotodos.Text = "  ";
            filtrotodos.UseVisualStyleBackColor = true;
            filtrotodos.CheckedChanged += filtrotodos_CheckedChanged;
            // 
            // filtro
            // 
            filtro.AutoSize = true;
            filtro.Checked = true;
            filtro.CheckState = CheckState.Checked;
            filtro.Cursor = Cursors.Hand;
            filtro.Font = new Font("Segoe UI", 13F);
            filtro.Image = Properties.Resources.sicheck;
            filtro.Location = new Point(200, 2);
            filtro.Name = "filtro";
            filtro.Size = new Size(41, 29);
            filtro.TabIndex = 0;
            filtro.Text = "  ";
            filtro.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label15.ForeColor = SystemColors.WindowFrame;
            label15.Image = Properties.Resources.filtroblanco;
            label15.Location = new Point(3, 6);
            label15.Name = "label15";
            label15.Size = new Size(18, 21);
            label15.TabIndex = 38;
            label15.Text = "  ";
            // 
            // creacion
            // 
            creacion.BackColor = SystemColors.WindowFrame;
            creacion.Controls.Add(panel6);
            creacion.Controls.Add(panel3);
            creacion.Controls.Add(seleccionpanel);
            creacion.Controls.Add(panel9);
            creacion.Controls.Add(panel8);
            creacion.Controls.Add(autoCalcular);
            creacion.Controls.Add(panel7);
            creacion.Controls.Add(panel5);
            creacion.Controls.Add(ultimoID);
            creacion.Controls.Add(label18);
            creacion.Controls.Add(idcategoriatxt);
            creacion.Controls.Add(imagenpanel);
            creacion.Controls.Add(panel4);
            creacion.Controls.Add(button1);
            creacion.Controls.Add(tipoproductocmbx);
            creacion.Controls.Add(label13);
            creacion.Controls.Add(txtprecio_compra);
            creacion.Controls.Add(categoriatxt);
            creacion.Controls.Add(txtnombre_prod);
            creacion.Controls.Add(txtcodigo_barras);
            creacion.Controls.Add(txtprecio_venta);
            creacion.Controls.Add(label16);
            creacion.Controls.Add(label21);
            creacion.Controls.Add(label8);
            creacion.Controls.Add(label4);
            creacion.Controls.Add(label7);
            creacion.Controls.Add(label5);
            creacion.Controls.Add(label3);
            creacion.Controls.Add(label17);
            creacion.Controls.Add(label10);
            creacion.Controls.Add(label14);
            creacion.Controls.Add(estadochk);
            creacion.Controls.Add(codigobarrarandombtn);
            creacion.Controls.Add(buscarcateg);
            creacion.Controls.Add(unidadmedida);
            creacion.Controls.Add(ITBIS);
            creacion.Controls.Add(categoriapanel);
            creacion.Location = new Point(4, 30);
            creacion.Name = "creacion";
            creacion.Padding = new Padding(3);
            creacion.Size = new Size(839, 656);
            creacion.TabIndex = 1;
            creacion.Text = "Creación";
            creacion.ToolTipText = "Cálculo automatico";
            // 
            // panel6
            // 
            panel6.Location = new Point(455, 380);
            panel6.Name = "panel6";
            panel6.Size = new Size(386, 25);
            panel6.TabIndex = 85;
            // 
            // panel3
            // 
            panel3.Location = new Point(159, 380);
            panel3.Name = "panel3";
            panel3.Size = new Size(189, 25);
            panel3.TabIndex = 85;
            // 
            // seleccionpanel
            // 
            seleccionpanel.BackColor = Color.FromArgb(64, 64, 64);
            seleccionpanel.Controls.Add(button7);
            seleccionpanel.Controls.Add(label20);
            seleccionpanel.Controls.Add(label19);
            seleccionpanel.Controls.Add(textBox1);
            seleccionpanel.Controls.Add(numCantidad);
            seleccionpanel.Controls.Add(label6);
            seleccionpanel.Controls.Add(nombreprodreceta);
            seleccionpanel.Controls.Add(recetaingredientes);
            seleccionpanel.Controls.Add(ingredientesconsulta);
            seleccionpanel.Controls.Add(costoIng);
            seleccionpanel.Controls.Add(idprodreceta);
            seleccionpanel.Controls.Add(unimedidareceta);
            seleccionpanel.Controls.Add(agregarbtn);
            seleccionpanel.Enabled = false;
            seleccionpanel.Location = new Point(3, 380);
            seleccionpanel.Name = "seleccionpanel";
            seleccionpanel.Size = new Size(834, 206);
            seleccionpanel.TabIndex = 82;
            // 
            // button7
            // 
            button7.BackColor = Color.Red;
            button7.Image = Properties.Resources.basurablanco;
            button7.Location = new Point(799, 169);
            button7.Name = "button7";
            button7.Size = new Size(29, 29);
            button7.TabIndex = 82;
            button7.UseVisualStyleBackColor = false;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.White;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label20.ForeColor = SystemColors.Control;
            label20.Image = Properties.Resources.busqueda;
            label20.Location = new Point(321, 41);
            label20.Name = "label20";
            label20.Size = new Size(18, 21);
            label20.TabIndex = 81;
            label20.Text = "  ";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label19.ForeColor = Color.White;
            label19.Image = Properties.Resources.recetablanco;
            label19.ImageAlign = ContentAlignment.MiddleRight;
            label19.Location = new Point(348, 5);
            label19.Name = "label19";
            label19.Size = new Size(98, 21);
            label19.TabIndex = 55;
            label19.Text = "2. Receta     ";
            // 
            // textBox1
            // 
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Enabled = false;
            textBox1.Location = new Point(5, 37);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Buscar ingrediente";
            textBox1.Size = new Size(338, 29);
            textBox1.TabIndex = 79;
            // 
            // numCantidad
            // 
            numCantidad.DecimalPlaces = 2;
            numCantidad.Location = new Point(739, 37);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(57, 29);
            numCantidad.TabIndex = 80;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.KeyPress += numCantidad_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Image = Properties.Resources.saleroblanco;
            label6.ImageAlign = ContentAlignment.MiddleRight;
            label6.Location = new Point(5, 5);
            label6.Name = "label6";
            label6.Size = new Size(147, 21);
            label6.TabIndex = 55;
            label6.Text = "1. Ingredientes      ";
            // 
            // nombreprodreceta
            // 
            nombreprodreceta.CharacterCasing = CharacterCasing.Upper;
            nombreprodreceta.Enabled = false;
            nombreprodreceta.Location = new Point(400, 37);
            nombreprodreceta.Name = "nombreprodreceta";
            nombreprodreceta.PlaceholderText = "Ingrediente";
            nombreprodreceta.Size = new Size(187, 29);
            nombreprodreceta.TabIndex = 75;
            // 
            // recetaingredientes
            // 
            recetaingredientes.AllowUserToAddRows = false;
            recetaingredientes.AllowUserToResizeRows = false;
            recetaingredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            recetaingredientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            recetaingredientes.Location = new Point(351, 69);
            recetaingredientes.MultiSelect = false;
            recetaingredientes.Name = "recetaingredientes";
            recetaingredientes.ReadOnly = true;
            recetaingredientes.RowHeadersVisible = false;
            recetaingredientes.RowHeadersWidth = 51;
            recetaingredientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            recetaingredientes.Size = new Size(445, 129);
            recetaingredientes.TabIndex = 74;
            // 
            // ingredientesconsulta
            // 
            ingredientesconsulta.AllowUserToAddRows = false;
            ingredientesconsulta.AllowUserToDeleteRows = false;
            ingredientesconsulta.AllowUserToResizeRows = false;
            ingredientesconsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ingredientesconsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ingredientesconsulta.Location = new Point(5, 69);
            ingredientesconsulta.MultiSelect = false;
            ingredientesconsulta.Name = "ingredientesconsulta";
            ingredientesconsulta.ReadOnly = true;
            ingredientesconsulta.RowHeadersVisible = false;
            ingredientesconsulta.RowHeadersWidth = 51;
            ingredientesconsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ingredientesconsulta.Size = new Size(338, 129);
            ingredientesconsulta.TabIndex = 74;
            ingredientesconsulta.CellClick += ingredientesconsulta_CellClick;
            // 
            // costoIng
            // 
            costoIng.CharacterCasing = CharacterCasing.Upper;
            costoIng.Enabled = false;
            costoIng.Location = new Point(674, 37);
            costoIng.Name = "costoIng";
            costoIng.PlaceholderText = "Costo";
            costoIng.Size = new Size(61, 29);
            costoIng.TabIndex = 79;
            // 
            // idprodreceta
            // 
            idprodreceta.CharacterCasing = CharacterCasing.Upper;
            idprodreceta.Enabled = false;
            idprodreceta.Location = new Point(351, 37);
            idprodreceta.Name = "idprodreceta";
            idprodreceta.PlaceholderText = "ID";
            idprodreceta.Size = new Size(45, 29);
            idprodreceta.TabIndex = 79;
            // 
            // unimedidareceta
            // 
            unimedidareceta.CharacterCasing = CharacterCasing.Upper;
            unimedidareceta.Enabled = false;
            unimedidareceta.Location = new Point(591, 37);
            unimedidareceta.Name = "unimedidareceta";
            unimedidareceta.PlaceholderText = "Medida";
            unimedidareceta.Size = new Size(79, 29);
            unimedidareceta.TabIndex = 79;
            // 
            // agregarbtn
            // 
            agregarbtn.Image = Properties.Resources.mas;
            agregarbtn.Location = new Point(799, 37);
            agregarbtn.Name = "agregarbtn";
            agregarbtn.Size = new Size(29, 29);
            agregarbtn.TabIndex = 77;
            agregarbtn.UseVisualStyleBackColor = true;
            agregarbtn.Click += agregarbtn_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(64, 64, 64);
            panel9.Location = new Point(192, 313);
            panel9.Name = "panel9";
            panel9.Size = new Size(15, 9);
            panel9.TabIndex = 87;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(64, 64, 64);
            panel8.Location = new Point(190, 280);
            panel8.Name = "panel8";
            panel8.Size = new Size(10, 74);
            panel8.TabIndex = 87;
            // 
            // autoCalcular
            // 
            autoCalcular.AutoSize = true;
            autoCalcular.Checked = true;
            autoCalcular.CheckState = CheckState.Checked;
            autoCalcular.Font = new Font("Segoe UI", 14F);
            autoCalcular.Image = Properties.Resources.calculadora;
            autoCalcular.ImageAlign = ContentAlignment.MiddleRight;
            autoCalcular.Location = new Point(210, 303);
            autoCalcular.Name = "autoCalcular";
            autoCalcular.Size = new Size(36, 29);
            autoCalcular.TabIndex = 86;
            autoCalcular.Text = " ";
            autoCalcular.UseVisualStyleBackColor = true;
            autoCalcular.CheckedChanged += autoCalcular_CheckedChanged;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(64, 64, 64);
            panel7.Location = new Point(181, 345);
            panel7.Name = "panel7";
            panel7.Size = new Size(11, 9);
            panel7.TabIndex = 87;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(64, 64, 64);
            panel5.Location = new Point(181, 280);
            panel5.Name = "panel5";
            panel5.Size = new Size(11, 9);
            panel5.TabIndex = 87;
            // 
            // ultimoID
            // 
            ultimoID.Enabled = false;
            ultimoID.Location = new Point(773, 10);
            ultimoID.Name = "ultimoID";
            ultimoID.Size = new Size(56, 29);
            ultimoID.TabIndex = 84;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label18.ForeColor = Color.White;
            label18.Location = new Point(740, 14);
            label18.Name = "label18";
            label18.Size = new Size(27, 21);
            label18.TabIndex = 83;
            label18.Text = "ID";
            // 
            // idcategoriatxt
            // 
            idcategoriatxt.CharacterCasing = CharacterCasing.Upper;
            idcategoriatxt.Enabled = false;
            idcategoriatxt.Location = new Point(234, 140);
            idcategoriatxt.Name = "idcategoriatxt";
            idcategoriatxt.Size = new Size(45, 29);
            idcategoriatxt.TabIndex = 58;
            // 
            // imagenpanel
            // 
            imagenpanel.BackColor = Color.Gray;
            imagenpanel.Controls.Add(imagenprod);
            imagenpanel.Controls.Add(seleccionimagenbtn);
            imagenpanel.Location = new Point(545, 65);
            imagenpanel.Name = "imagenpanel";
            imagenpanel.Size = new Size(199, 265);
            imagenpanel.TabIndex = 72;
            // 
            // imagenprod
            // 
            imagenprod.ErrorImage = Properties.Resources.paisaje;
            imagenprod.Image = Properties.Resources.paisaje;
            imagenprod.InitialImage = Properties.Resources.paisaje;
            imagenprod.Location = new Point(9, 9);
            imagenprod.Name = "imagenprod";
            imagenprod.Size = new Size(181, 181);
            imagenprod.SizeMode = PictureBoxSizeMode.StretchImage;
            imagenprod.TabIndex = 13;
            imagenprod.TabStop = false;
            // 
            // seleccionimagenbtn
            // 
            seleccionimagenbtn.BackColor = Color.Lime;
            seleccionimagenbtn.ForeColor = Color.Black;
            seleccionimagenbtn.Image = Properties.Resources.subir1;
            seleccionimagenbtn.Location = new Point(9, 198);
            seleccionimagenbtn.Name = "seleccionimagenbtn";
            seleccionimagenbtn.Size = new Size(181, 60);
            seleccionimagenbtn.TabIndex = 12;
            seleccionimagenbtn.Text = "Buscar Imagen";
            seleccionimagenbtn.TextAlign = ContentAlignment.BottomCenter;
            seleccionimagenbtn.UseVisualStyleBackColor = false;
            seleccionimagenbtn.Click += seleccionimagenbtn_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(64, 64, 64);
            panel4.Controls.Add(guardarbtn);
            panel4.Controls.Add(limpiarbtn);
            panel4.Location = new Point(206, 580);
            panel4.Name = "panel4";
            panel4.Size = new Size(426, 74);
            panel4.TabIndex = 71;
            // 
            // guardarbtn
            // 
            guardarbtn.Enabled = false;
            guardarbtn.ForeColor = Color.Black;
            guardarbtn.Image = Properties.Resources.disco;
            guardarbtn.ImageAlign = ContentAlignment.MiddleLeft;
            guardarbtn.Location = new Point(12, 9);
            guardarbtn.Name = "guardarbtn";
            guardarbtn.Size = new Size(181, 58);
            guardarbtn.TabIndex = 13;
            guardarbtn.Text = "Guardar";
            guardarbtn.UseVisualStyleBackColor = true;
            guardarbtn.Click += guardarbtn_Click;
            // 
            // limpiarbtn
            // 
            limpiarbtn.Enabled = false;
            limpiarbtn.ForeColor = Color.Black;
            limpiarbtn.Image = Properties.Resources.limpio;
            limpiarbtn.ImageAlign = ContentAlignment.MiddleLeft;
            limpiarbtn.Location = new Point(233, 9);
            limpiarbtn.Name = "limpiarbtn";
            limpiarbtn.Size = new Size(181, 58);
            limpiarbtn.TabIndex = 14;
            limpiarbtn.Text = "Limpiar";
            limpiarbtn.UseVisualStyleBackColor = true;
            limpiarbtn.Click += limpiarbtn_Click;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.actualizar;
            button1.Location = new Point(8, 10);
            button1.Name = "button1";
            button1.Size = new Size(29, 29);
            button1.TabIndex = 70;
            button1.TabStop = false;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tipoproductocmbx
            // 
            tipoproductocmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            tipoproductocmbx.FormattingEnabled = true;
            tipoproductocmbx.Location = new Point(16, 75);
            tipoproductocmbx.Name = "tipoproductocmbx";
            tipoproductocmbx.Size = new Size(163, 29);
            tipoproductocmbx.TabIndex = 64;
            tipoproductocmbx.SelectedIndexChanged += tipoproductocmbx_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            label13.ForeColor = SystemColors.Control;
            label13.Location = new Point(259, 4);
            label13.Name = "label13";
            label13.Size = new Size(321, 40);
            label13.TabIndex = 68;
            label13.Text = "Registro de Productos";
            // 
            // txtprecio_compra
            // 
            txtprecio_compra.CharacterCasing = CharacterCasing.Upper;
            txtprecio_compra.Enabled = false;
            txtprecio_compra.Location = new Point(16, 270);
            txtprecio_compra.Name = "txtprecio_compra";
            txtprecio_compra.Size = new Size(163, 29);
            txtprecio_compra.TabIndex = 61;
            // 
            // categoriatxt
            // 
            categoriatxt.CharacterCasing = CharacterCasing.Upper;
            categoriatxt.Enabled = false;
            categoriatxt.Location = new Point(281, 140);
            categoriatxt.Name = "categoriatxt";
            categoriatxt.Size = new Size(117, 29);
            categoriatxt.TabIndex = 58;
            // 
            // txtnombre_prod
            // 
            txtnombre_prod.CharacterCasing = CharacterCasing.Upper;
            txtnombre_prod.Enabled = false;
            txtnombre_prod.Location = new Point(16, 205);
            txtnombre_prod.Name = "txtnombre_prod";
            txtnombre_prod.Size = new Size(163, 29);
            txtnombre_prod.TabIndex = 58;
            // 
            // txtcodigo_barras
            // 
            txtcodigo_barras.CharacterCasing = CharacterCasing.Upper;
            txtcodigo_barras.Enabled = false;
            txtcodigo_barras.Location = new Point(16, 140);
            txtcodigo_barras.Name = "txtcodigo_barras";
            txtcodigo_barras.Size = new Size(163, 29);
            txtcodigo_barras.TabIndex = 65;
            // 
            // txtprecio_venta
            // 
            txtprecio_venta.CharacterCasing = CharacterCasing.Upper;
            txtprecio_venta.Enabled = false;
            txtprecio_venta.Location = new Point(16, 335);
            txtprecio_venta.Name = "txtprecio_venta";
            txtprecio_venta.Size = new Size(163, 29);
            txtprecio_venta.TabIndex = 62;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label16.ForeColor = Color.White;
            label16.Location = new Point(16, 51);
            label16.Name = "label16";
            label16.Size = new Size(141, 21);
            label16.TabIndex = 55;
            label16.Text = "Tipo de producto";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label21.ForeColor = Color.White;
            label21.Location = new Point(234, 179);
            label21.Name = "label21";
            label21.Size = new Size(151, 21);
            label21.TabIndex = 55;
            label21.Text = "Unidad de medida";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(234, 51);
            label8.Name = "label8";
            label8.Size = new Size(52, 21);
            label8.TabIndex = 55;
            label8.Text = "ITBIS:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(13, 243);
            label4.Name = "label4";
            label4.Size = new Size(149, 21);
            label4.TabIndex = 54;
            label4.Text = "Precio de Compra:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(16, 115);
            label7.Name = "label7";
            label7.Size = new Size(143, 21);
            label7.TabIndex = 53;
            label7.Text = "Codigo de Barras:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(13, 307);
            label5.Name = "label5";
            label5.Size = new Size(133, 21);
            label5.TabIndex = 52;
            label5.Text = "Precio de Venta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(13, 179);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 51;
            label3.Text = "Nombre:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label17.ForeColor = Color.White;
            label17.Location = new Point(310, 77);
            label17.Name = "label17";
            label17.Size = new Size(28, 25);
            label17.TabIndex = 50;
            label17.Text = "%";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(234, 112);
            label10.Name = "label10";
            label10.Size = new Size(88, 21);
            label10.TabIndex = 50;
            label10.Text = "Categoria:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label14.ForeColor = Color.White;
            label14.Location = new Point(571, 338);
            label14.Name = "label14";
            label14.Size = new Size(65, 21);
            label14.TabIndex = 49;
            label14.Text = "Estado:";
            // 
            // estadochk
            // 
            estadochk.AutoSize = true;
            estadochk.Checked = true;
            estadochk.CheckState = CheckState.Checked;
            estadochk.ForeColor = Color.Lime;
            estadochk.Location = new Point(647, 336);
            estadochk.Name = "estadochk";
            estadochk.Size = new Size(72, 25);
            estadochk.TabIndex = 46;
            estadochk.Text = "Activo";
            estadochk.UseVisualStyleBackColor = true;
            // 
            // codigobarrarandombtn
            // 
            codigobarrarandombtn.Enabled = false;
            codigobarrarandombtn.ForeColor = Color.Black;
            codigobarrarandombtn.Image = Properties.Resources.barajar;
            codigobarrarandombtn.Location = new Point(181, 140);
            codigobarrarandombtn.Name = "codigobarrarandombtn";
            codigobarrarandombtn.Size = new Size(28, 29);
            codigobarrarandombtn.TabIndex = 66;
            codigobarrarandombtn.UseVisualStyleBackColor = true;
            codigobarrarandombtn.Click += codigobarrarandombtn_Click;
            // 
            // buscarcateg
            // 
            buscarcateg.Enabled = false;
            buscarcateg.ForeColor = Color.Black;
            buscarcateg.Image = Properties.Resources.busqueda;
            buscarcateg.Location = new Point(400, 140);
            buscarcateg.Name = "buscarcateg";
            buscarcateg.Size = new Size(28, 29);
            buscarcateg.TabIndex = 60;
            buscarcateg.UseVisualStyleBackColor = true;
            buscarcateg.Click += buscarcateg_Click;
            // 
            // unidadmedida
            // 
            unidadmedida.DropDownStyle = ComboBoxStyle.DropDownList;
            unidadmedida.Enabled = false;
            unidadmedida.FormattingEnabled = true;
            unidadmedida.Location = new Point(234, 205);
            unidadmedida.Name = "unidadmedida";
            unidadmedida.Size = new Size(163, 29);
            unidadmedida.TabIndex = 64;
            // 
            // ITBIS
            // 
            ITBIS.DropDownStyle = ComboBoxStyle.DropDownList;
            ITBIS.Enabled = false;
            ITBIS.FormattingEnabled = true;
            ITBIS.Items.AddRange(new object[] { "18", "16", "Excento" });
            ITBIS.Location = new Point(234, 75);
            ITBIS.Name = "ITBIS";
            ITBIS.Size = new Size(70, 29);
            ITBIS.TabIndex = 64;
            // 
            // categoriapanel
            // 
            categoriapanel.BackColor = Color.FromArgb(64, 64, 64);
            categoriapanel.Controls.Add(idconsultatxt);
            categoriapanel.Controls.Add(categoriaconsultatxt);
            categoriapanel.Controls.Add(button4);
            categoriapanel.Controls.Add(label9);
            categoriapanel.Controls.Add(categoriaconsulta);
            categoriapanel.Location = new Point(310, 243);
            categoriapanel.Name = "categoriapanel";
            categoriapanel.Size = new Size(204, 242);
            categoriapanel.TabIndex = 81;
            categoriapanel.Visible = false;
            // 
            // idconsultatxt
            // 
            idconsultatxt.Enabled = false;
            idconsultatxt.Location = new Point(4, 28);
            idconsultatxt.Name = "idconsultatxt";
            idconsultatxt.Size = new Size(36, 29);
            idconsultatxt.TabIndex = 58;
            // 
            // categoriaconsultatxt
            // 
            categoriaconsultatxt.Enabled = false;
            categoriaconsultatxt.Location = new Point(43, 28);
            categoriaconsultatxt.Name = "categoriaconsultatxt";
            categoriaconsultatxt.Size = new Size(125, 29);
            categoriaconsultatxt.TabIndex = 58;
            // 
            // button4
            // 
            button4.ForeColor = Color.Black;
            button4.Image = Properties.Resources.angulo_hacia_izquierda;
            button4.Location = new Point(171, 28);
            button4.Name = "button4";
            button4.Size = new Size(28, 29);
            button4.TabIndex = 60;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(5, 2);
            label9.Name = "label9";
            label9.Size = new Size(174, 21);
            label9.TabIndex = 50;
            label9.Text = "Seleccionar categoria";
            // 
            // categoriaconsulta
            // 
            categoriaconsulta.AllowUserToAddRows = false;
            categoriaconsulta.AllowUserToDeleteRows = false;
            categoriaconsulta.AllowUserToResizeRows = false;
            categoriaconsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            categoriaconsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            categoriaconsulta.Location = new Point(4, 63);
            categoriaconsulta.MultiSelect = false;
            categoriaconsulta.Name = "categoriaconsulta";
            categoriaconsulta.ReadOnly = true;
            categoriaconsulta.RowHeadersVisible = false;
            categoriaconsulta.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            categoriaconsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            categoriaconsulta.Size = new Size(195, 171);
            categoriaconsulta.TabIndex = 74;
            categoriaconsulta.CellClick += categoriaconsulta_CellClick;
            categoriaconsulta.CellDoubleClick += categoriaconsulta_CellDoubleClick;
            // 
            // ConsProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(847, 690);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConsProductos";
            StartPosition = FormStartPosition.Manual;
            Text = "Productos";
            Load += ConsProductos_Load;
            ((System.ComponentModel.ISupportInitialize)tabladatos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imagenproducto).EndInit();
            tabControl1.ResumeLayout(false);
            consulta.ResumeLayout(false);
            consulta.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            creacion.ResumeLayout(false);
            creacion.PerformLayout();
            seleccionpanel.ResumeLayout(false);
            seleccionpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)recetaingredientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)ingredientesconsulta).EndInit();
            imagenpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imagenprod).EndInit();
            panel4.ResumeLayout(false);
            categoriapanel.ResumeLayout(false);
            categoriapanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaconsulta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label11;
        private Button eliminarbtn;
        private Label label12;
        private DataGridView tabladatos;
        private TextBox txtbuscador;
        private Button agregar;
        private Button Editar;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private PictureBox imagenproducto;
        public Button recargarbtn;
        private TabControl tabControl1;
        private TabPage consulta;
        private TabPage creacion;
        private Panel imagenpanel;
        private Button seleccionimagenbtn;
        private Panel panel4;
        private Button guardarbtn;
        private Button limpiarbtn;
        public Button button1;
        private ComboBox ITBIS;
        private Label label13;
        private TextBox txtprecio_compra;
        private TextBox txtnombre_prod;
        private TextBox txtcodigo_barras;
        private TextBox txtprecio_venta;
        private Label label8;
        private Label label4;
        private Label label7;
        private Label label5;
        private Label label3;
        private Label label10;
        private Label label14;
        private CheckBox estadochk;
        private Button codigobarrarandombtn;
        private Button buscarcateg;
        private PictureBox imagenprod;
        private DataGridView recetaingredientes;
        private ComboBox tipoproductocmbx;
        private Label label6;
        private Label label16;
        private NumericUpDown numCantidad;
        private TextBox nombreprodreceta;
        private Button agregarbtn;
        private TextBox textBox1;
        private DataGridView ingredientesconsulta;
        private Panel categoriapanel;
        private TextBox categoriaconsultatxt;
        private TextBox categoriatxt;
        private Panel seleccionpanel;
        private Button button4;
        private Label label9;
        private DataGridView categoriaconsulta;
        private CheckBox filtroingredientes;
        private CheckBox filtroplatos;
        private CheckBox filtrotodos;
        private CheckBox filtro;
        private Label label15;
        private TextBox idcategoriatxt;
        private TextBox idconsultatxt;
        private Label label17;
        private TextBox ultimoID;
        private Label label18;
        private Panel panel3;
        private Panel panel6;
        private Label label19;
        private Label label21;
        private TextBox unimedidareceta;
        private ComboBox unidadmedida;
        private Label label20;
        private Panel panel2;
        private TextBox idprodreceta;
        private Button button7;
        private TextBox costoIng;
        private CheckBox autoCalcular;
        private Panel panel9;
        private Panel panel8;
        private Panel panel7;
        private Panel panel5;
    }
}