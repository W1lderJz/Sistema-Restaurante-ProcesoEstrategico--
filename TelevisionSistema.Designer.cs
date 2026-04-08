namespace Proyecto_restaurante
{
    partial class TelevisionSistema
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
            panelOrdenes = new FlowLayoutPanel();
            label5 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // panelOrdenes
            // 
            panelOrdenes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelOrdenes.AutoScroll = true;
            panelOrdenes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelOrdenes.BackColor = Color.FromArgb(64, 64, 64);
            panelOrdenes.Location = new Point(12, 69);
            panelOrdenes.Name = "panelOrdenes";
            panelOrdenes.Size = new Size(1226, 637);
            panelOrdenes.TabIndex = 27;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(480, 15);
            label5.Name = "label5";
            label5.Size = new Size(291, 40);
            label5.TabIndex = 28;
            label5.Text = "Ordenes Pendientes";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = Properties.Resources.cruz__1_;
            button2.ImageAlign = ContentAlignment.TopCenter;
            button2.Location = new Point(1209, 23);
            button2.Name = "button2";
            button2.Size = new Size(29, 27);
            button2.TabIndex = 97;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // TelevisionSistema
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(1250, 718);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(panelOrdenes);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelevisionSistema";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de TV";
            WindowState = FormWindowState.Maximized;
            Load += TelevisionSistema_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel panelOrdenes;
        private Label label5;
        private Button button2;
    }
}