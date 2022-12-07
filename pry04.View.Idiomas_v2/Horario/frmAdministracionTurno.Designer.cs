namespace pry04.View.Idiomas_v2.Horario
{
    partial class frmAdministracionTurno
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlInformacion = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTurnoBase = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnRestaurarSeleccion = new System.Windows.Forms.Button();
            this.txtRegistroNombre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlDias = new System.Windows.Forms.Panel();
            this.chkMartes = new System.Windows.Forms.CheckBox();
            this.chkLunes = new System.Windows.Forms.CheckBox();
            this.chkMiercoles = new System.Windows.Forms.CheckBox();
            this.chkJueves = new System.Windows.Forms.CheckBox();
            this.chkViernes = new System.Windows.Forms.CheckBox();
            this.chkSabado = new System.Windows.Forms.CheckBox();
            this.chkDomingo = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btnRestaurarTodo = new System.Windows.Forms.Button();
            this.btnReemplazar = new System.Windows.Forms.Button();
            this.dgvTurnoDetalle = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblCantidadRegistros = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnoBase)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlDias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnoDetalle)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(80, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Administración de Turnos";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(766, 70);
            this.label1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlInformacion);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 180);
            this.panel1.TabIndex = 6;
            // 
            // pnlInformacion
            // 
            this.pnlInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInformacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInformacion.Controls.Add(this.label5);
            this.pnlInformacion.Controls.Add(this.dgvTurnoBase);
            this.pnlInformacion.Location = new System.Drawing.Point(-1, 39);
            this.pnlInformacion.Name = "pnlInformacion";
            this.pnlInformacion.Size = new System.Drawing.Size(742, 140);
            this.pnlInformacion.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Lista de Turnos actuales";
            // 
            // dgvTurnoBase
            // 
            this.dgvTurnoBase.AllowUserToAddRows = false;
            this.dgvTurnoBase.AllowUserToDeleteRows = false;
            this.dgvTurnoBase.AllowUserToResizeColumns = false;
            this.dgvTurnoBase.AllowUserToResizeRows = false;
            this.dgvTurnoBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTurnoBase.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnoBase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTurnoBase.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTurnoBase.EnableHeadersVisualStyles = false;
            this.dgvTurnoBase.Location = new System.Drawing.Point(-1, 39);
            this.dgvTurnoBase.MultiSelect = false;
            this.dgvTurnoBase.Name = "dgvTurnoBase";
            this.dgvTurnoBase.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnoBase.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTurnoBase.RowHeadersVisible = false;
            this.dgvTurnoBase.RowTemplate.Height = 25;
            this.dgvTurnoBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnoBase.Size = new System.Drawing.Size(742, 100);
            this.dgvTurnoBase.TabIndex = 5;
            this.dgvTurnoBase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnoBase_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtFiltroNombre);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(742, 41);
            this.panel2.TabIndex = 3;
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroNombre.Location = new System.Drawing.Point(199, 8);
            this.txtFiltroNombre.MaxLength = 50;
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(281, 23);
            this.txtFiltroNombre.TabIndex = 23;
            this.txtFiltroNombre.TextChanged += new System.EventHandler(this.txtFiltroNombre_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Filtros de búsqueda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(142, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nombre";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(12, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 398);
            this.panel3.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnRestaurarSeleccion);
            this.panel5.Controls.Add(this.txtRegistroNombre);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.pnlDias);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.dtpHasta);
            this.panel5.Controls.Add(this.dtpDesde);
            this.panel5.Controls.Add(this.btnRestaurarTodo);
            this.panel5.Controls.Add(this.btnReemplazar);
            this.panel5.Controls.Add(this.dgvTurnoDetalle);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(-1, 178);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(742, 180);
            this.panel5.TabIndex = 11;
            // 
            // btnRestaurarSeleccion
            // 
            this.btnRestaurarSeleccion.Location = new System.Drawing.Point(674, 64);
            this.btnRestaurarSeleccion.Name = "btnRestaurarSeleccion";
            this.btnRestaurarSeleccion.Size = new System.Drawing.Size(26, 26);
            this.btnRestaurarSeleccion.TabIndex = 30;
            this.btnRestaurarSeleccion.Text = "-";
            this.btnRestaurarSeleccion.UseVisualStyleBackColor = true;
            this.btnRestaurarSeleccion.Click += new System.EventHandler(this.btnRestaurarSeleccion_Click);
            // 
            // txtRegistroNombre
            // 
            this.txtRegistroNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistroNombre.Location = new System.Drawing.Point(67, 36);
            this.txtRegistroNombre.MaxLength = 40;
            this.txtRegistroNombre.Name = "txtRegistroNombre";
            this.txtRegistroNombre.Size = new System.Drawing.Size(555, 23);
            this.txtRegistroNombre.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(10, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "Nombre";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(519, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 15);
            this.label10.TabIndex = 27;
            this.label10.Text = "Hasta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(37, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "Día";
            // 
            // pnlDias
            // 
            this.pnlDias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDias.Controls.Add(this.chkMartes);
            this.pnlDias.Controls.Add(this.chkLunes);
            this.pnlDias.Controls.Add(this.chkMiercoles);
            this.pnlDias.Controls.Add(this.chkJueves);
            this.pnlDias.Controls.Add(this.chkViernes);
            this.pnlDias.Controls.Add(this.chkSabado);
            this.pnlDias.Controls.Add(this.chkDomingo);
            this.pnlDias.Location = new System.Drawing.Point(67, 65);
            this.pnlDias.Name = "pnlDias";
            this.pnlDias.Size = new System.Drawing.Size(317, 24);
            this.pnlDias.TabIndex = 25;
            // 
            // chkMartes
            // 
            this.chkMartes.AutoSize = true;
            this.chkMartes.Location = new System.Drawing.Point(47, 3);
            this.chkMartes.Name = "chkMartes";
            this.chkMartes.Size = new System.Drawing.Size(43, 19);
            this.chkMartes.TabIndex = 12;
            this.chkMartes.Text = "Ma";
            this.chkMartes.UseVisualStyleBackColor = true;
            // 
            // chkLunes
            // 
            this.chkLunes.AutoSize = true;
            this.chkLunes.Location = new System.Drawing.Point(3, 3);
            this.chkLunes.Name = "chkLunes";
            this.chkLunes.Size = new System.Drawing.Size(39, 19);
            this.chkLunes.TabIndex = 11;
            this.chkLunes.Text = "Lu";
            this.chkLunes.UseVisualStyleBackColor = true;
            // 
            // chkMiercoles
            // 
            this.chkMiercoles.AutoSize = true;
            this.chkMiercoles.Location = new System.Drawing.Point(97, 3);
            this.chkMiercoles.Name = "chkMiercoles";
            this.chkMiercoles.Size = new System.Drawing.Size(40, 19);
            this.chkMiercoles.TabIndex = 13;
            this.chkMiercoles.Text = "Mi";
            this.chkMiercoles.UseVisualStyleBackColor = true;
            // 
            // chkJueves
            // 
            this.chkJueves.AutoSize = true;
            this.chkJueves.Location = new System.Drawing.Point(143, 3);
            this.chkJueves.Name = "chkJueves";
            this.chkJueves.Size = new System.Drawing.Size(37, 19);
            this.chkJueves.TabIndex = 14;
            this.chkJueves.Text = "Ju";
            this.chkJueves.UseVisualStyleBackColor = true;
            // 
            // chkViernes
            // 
            this.chkViernes.AutoSize = true;
            this.chkViernes.Location = new System.Drawing.Point(186, 3);
            this.chkViernes.Name = "chkViernes";
            this.chkViernes.Size = new System.Drawing.Size(36, 19);
            this.chkViernes.TabIndex = 15;
            this.chkViernes.Text = "Vi";
            this.chkViernes.UseVisualStyleBackColor = true;
            // 
            // chkSabado
            // 
            this.chkSabado.AutoSize = true;
            this.chkSabado.Location = new System.Drawing.Point(228, 3);
            this.chkSabado.Name = "chkSabado";
            this.chkSabado.Size = new System.Drawing.Size(38, 19);
            this.chkSabado.TabIndex = 16;
            this.chkSabado.Text = "Sa";
            this.chkSabado.UseVisualStyleBackColor = true;
            // 
            // chkDomingo
            // 
            this.chkDomingo.AutoSize = true;
            this.chkDomingo.Location = new System.Drawing.Point(272, 3);
            this.chkDomingo.Name = "chkDomingo";
            this.chkDomingo.Size = new System.Drawing.Size(41, 19);
            this.chkDomingo.TabIndex = 17;
            this.chkDomingo.Text = "Do";
            this.chkDomingo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(399, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Desde";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "HH:mm";
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(562, 65);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowUpDown = true;
            this.dtpHasta.Size = new System.Drawing.Size(60, 23);
            this.dtpHasta.TabIndex = 22;
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "HH:mm";
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(441, 65);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.ShowUpDown = true;
            this.dtpDesde.Size = new System.Drawing.Size(60, 23);
            this.dtpDesde.TabIndex = 21;
            // 
            // btnRestaurarTodo
            // 
            this.btnRestaurarTodo.Location = new System.Drawing.Point(706, 64);
            this.btnRestaurarTodo.Name = "btnRestaurarTodo";
            this.btnRestaurarTodo.Size = new System.Drawing.Size(26, 26);
            this.btnRestaurarTodo.TabIndex = 20;
            this.btnRestaurarTodo.Text = "R";
            this.btnRestaurarTodo.UseVisualStyleBackColor = true;
            this.btnRestaurarTodo.Click += new System.EventHandler(this.btnRestaurarTodo_Click);
            // 
            // btnReemplazar
            // 
            this.btnReemplazar.Location = new System.Drawing.Point(642, 64);
            this.btnReemplazar.Name = "btnReemplazar";
            this.btnReemplazar.Size = new System.Drawing.Size(26, 26);
            this.btnReemplazar.TabIndex = 18;
            this.btnReemplazar.Text = "+";
            this.btnReemplazar.UseVisualStyleBackColor = true;
            this.btnReemplazar.Click += new System.EventHandler(this.btnReemplazar_Click);
            // 
            // dgvTurnoDetalle
            // 
            this.dgvTurnoDetalle.AllowUserToAddRows = false;
            this.dgvTurnoDetalle.AllowUserToDeleteRows = false;
            this.dgvTurnoDetalle.AllowUserToResizeColumns = false;
            this.dgvTurnoDetalle.AllowUserToResizeRows = false;
            this.dgvTurnoDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTurnoDetalle.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnoDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTurnoDetalle.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTurnoDetalle.EnableHeadersVisualStyles = false;
            this.dgvTurnoDetalle.Location = new System.Drawing.Point(-1, 104);
            this.dgvTurnoDetalle.MultiSelect = false;
            this.dgvTurnoDetalle.Name = "dgvTurnoDetalle";
            this.dgvTurnoDetalle.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnoDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTurnoDetalle.RowHeadersVisible = false;
            this.dgvTurnoDetalle.RowTemplate.Height = 25;
            this.dgvTurnoDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnoDetalle.Size = new System.Drawing.Size(742, 75);
            this.dgvTurnoDetalle.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(6, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Personalizar Turno";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnCancelar);
            this.panel4.Controls.Add(this.btnGuardar);
            this.panel4.Controls.Add(this.btnNuevo);
            this.panel4.Controls.Add(this.lblCantidadRegistros);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(-1, 357);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(742, 40);
            this.panel4.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(630, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 26);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "   Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(517, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(107, 26);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "   Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Location = new System.Drawing.Point(404, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(107, 26);
            this.btnNuevo.TabIndex = 19;
            this.btnNuevo.Text = "   Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblCantidadRegistros
            // 
            this.lblCantidadRegistros.AutoSize = true;
            this.lblCantidadRegistros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCantidadRegistros.Location = new System.Drawing.Point(84, 12);
            this.lblCantidadRegistros.Name = "lblCantidadRegistros";
            this.lblCantidadRegistros.Size = new System.Drawing.Size(13, 15);
            this.lblCantidadRegistros.TabIndex = 18;
            this.lblCantidadRegistros.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "N° Registros";
            // 
            // frmAdministracionTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(766, 492);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(782, 531);
            this.Name = "frmAdministracionTurno";
            this.Text = "Administración de Turnos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdministracionTurno_FormClosed);
            this.Load += new System.EventHandler(this.frmAdministracionTurno_Load);
            this.panel1.ResumeLayout(false);
            this.pnlInformacion.ResumeLayout(false);
            this.pnlInformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnoBase)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlDias.ResumeLayout(false);
            this.pnlDias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnoDetalle)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlInformacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvTurnoBase;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblCantidadRegistros;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkDomingo;
        private System.Windows.Forms.CheckBox chkSabado;
        private System.Windows.Forms.CheckBox chkViernes;
        private System.Windows.Forms.CheckBox chkJueves;
        private System.Windows.Forms.CheckBox chkMiercoles;
        private System.Windows.Forms.CheckBox chkMartes;
        private System.Windows.Forms.CheckBox chkLunes;
        private System.Windows.Forms.DataGridView dgvTurnoDetalle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlDias;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnRestaurarTodo;
        private System.Windows.Forms.Button btnReemplazar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtRegistroNombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRestaurarSeleccion;
    }
}