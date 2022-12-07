namespace pry04.View.Idiomas_v2.Matricula
{
    partial class frmAdministracionExamen
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvExamen = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFiltroCodigoUniversitario = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlDatosExamen = new System.Windows.Forms.Panel();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudNota = new System.Windows.Forms.NumericUpDown();
            this.btnBuscarSemestre = new System.Windows.Forms.Button();
            this.btnBuscarDocente = new System.Windows.Forms.Button();
            this.btnBuscarCurso = new System.Windows.Forms.Button();
            this.btnBuscarEstudiante = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtIdIdi_Semestre = new System.Windows.Forms.TextBox();
            this.txtIdIdi_Curso = new System.Windows.Forms.TextBox();
            this.txtIdIdi_Docente = new System.Windows.Forms.TextBox();
            this.txtCodigoUniversitario = new System.Windows.Forms.TextBox();
            this.txtEstudiante = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlSexo = new System.Windows.Forms.Panel();
            this.rbtAcreditacion = new System.Windows.Forms.RadioButton();
            this.rbtUbicacion = new System.Windows.Forms.RadioButton();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDocente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSemestre = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamen)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlDatosExamen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNota)).BeginInit();
            this.pnlSexo.SuspendLayout();
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
            this.label2.Size = new System.Drawing.Size(296, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "Administración de Exámenes";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1049, 70);
            this.label1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvExamen);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pnlDatosExamen);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(12, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 492);
            this.panel1.TabIndex = 12;
            // 
            // dgvExamen
            // 
            this.dgvExamen.AllowUserToAddRows = false;
            this.dgvExamen.AllowUserToDeleteRows = false;
            this.dgvExamen.AllowUserToResizeColumns = false;
            this.dgvExamen.AllowUserToResizeRows = false;
            this.dgvExamen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExamen.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExamen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExamen.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExamen.EnableHeadersVisualStyles = false;
            this.dgvExamen.Location = new System.Drawing.Point(-1, 38);
            this.dgvExamen.MultiSelect = false;
            this.dgvExamen.Name = "dgvExamen";
            this.dgvExamen.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExamen.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExamen.RowHeadersVisible = false;
            this.dgvExamen.RowTemplate.Height = 25;
            this.dgvExamen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExamen.Size = new System.Drawing.Size(1025, 250);
            this.dgvExamen.TabIndex = 69;
            this.dgvExamen.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamenes_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtFiltroCodigoUniversitario);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 40);
            this.panel2.TabIndex = 68;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "Listado de Exámenes";
            // 
            // txtFiltroCodigoUniversitario
            // 
            this.txtFiltroCodigoUniversitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroCodigoUniversitario.Location = new System.Drawing.Point(277, 8);
            this.txtFiltroCodigoUniversitario.MaxLength = 40;
            this.txtFiltroCodigoUniversitario.Name = "txtFiltroCodigoUniversitario";
            this.txtFiltroCodigoUniversitario.Size = new System.Drawing.Size(310, 23);
            this.txtFiltroCodigoUniversitario.TabIndex = 63;
            this.txtFiltroCodigoUniversitario.TextChanged += new System.EventHandler(this.txtFiltroCodigoUniversitario_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(156, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 15);
            this.label12.TabIndex = 62;
            this.label12.Text = "Código Universitario";
            // 
            // pnlDatosExamen
            // 
            this.pnlDatosExamen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatosExamen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatosExamen.Controls.Add(this.cmbEstado);
            this.pnlDatosExamen.Controls.Add(this.label3);
            this.pnlDatosExamen.Controls.Add(this.nudNota);
            this.pnlDatosExamen.Controls.Add(this.btnBuscarSemestre);
            this.pnlDatosExamen.Controls.Add(this.btnBuscarDocente);
            this.pnlDatosExamen.Controls.Add(this.btnBuscarCurso);
            this.pnlDatosExamen.Controls.Add(this.btnBuscarEstudiante);
            this.pnlDatosExamen.Controls.Add(this.dtpFecha);
            this.pnlDatosExamen.Controls.Add(this.txtIdIdi_Semestre);
            this.pnlDatosExamen.Controls.Add(this.txtIdIdi_Curso);
            this.pnlDatosExamen.Controls.Add(this.txtIdIdi_Docente);
            this.pnlDatosExamen.Controls.Add(this.txtCodigoUniversitario);
            this.pnlDatosExamen.Controls.Add(this.txtEstudiante);
            this.pnlDatosExamen.Controls.Add(this.label10);
            this.pnlDatosExamen.Controls.Add(this.pnlSexo);
            this.pnlDatosExamen.Controls.Add(this.txtCurso);
            this.pnlDatosExamen.Controls.Add(this.label18);
            this.pnlDatosExamen.Controls.Add(this.label17);
            this.pnlDatosExamen.Controls.Add(this.label16);
            this.pnlDatosExamen.Controls.Add(this.txtTema);
            this.pnlDatosExamen.Controls.Add(this.label9);
            this.pnlDatosExamen.Controls.Add(this.txtDocente);
            this.pnlDatosExamen.Controls.Add(this.label5);
            this.pnlDatosExamen.Controls.Add(this.label8);
            this.pnlDatosExamen.Controls.Add(this.txtSemestre);
            this.pnlDatosExamen.Controls.Add(this.label13);
            this.pnlDatosExamen.Controls.Add(this.label6);
            this.pnlDatosExamen.Location = new System.Drawing.Point(-1, 287);
            this.pnlDatosExamen.Name = "pnlDatosExamen";
            this.pnlDatosExamen.Size = new System.Drawing.Size(1025, 165);
            this.pnlDatosExamen.TabIndex = 12;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(586, 41);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(138, 23);
            this.cmbEstado.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(538, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 70;
            this.label3.Text = "Estado";
            // 
            // nudNota
            // 
            this.nudNota.Location = new System.Drawing.Point(786, 128);
            this.nudNota.Name = "nudNota";
            this.nudNota.Size = new System.Drawing.Size(57, 23);
            this.nudNota.TabIndex = 87;
            this.nudNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBuscarSemestre
            // 
            this.btnBuscarSemestre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscarSemestre.Location = new System.Drawing.Point(849, 97);
            this.btnBuscarSemestre.Name = "btnBuscarSemestre";
            this.btnBuscarSemestre.Size = new System.Drawing.Size(26, 26);
            this.btnBuscarSemestre.TabIndex = 86;
            this.btnBuscarSemestre.Text = "B";
            this.btnBuscarSemestre.UseVisualStyleBackColor = true;
            this.btnBuscarSemestre.Click += new System.EventHandler(this.btnBuscarSemestre_Click);
            // 
            // btnBuscarDocente
            // 
            this.btnBuscarDocente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscarDocente.Location = new System.Drawing.Point(982, 68);
            this.btnBuscarDocente.Name = "btnBuscarDocente";
            this.btnBuscarDocente.Size = new System.Drawing.Size(26, 26);
            this.btnBuscarDocente.TabIndex = 85;
            this.btnBuscarDocente.Text = "B";
            this.btnBuscarDocente.UseVisualStyleBackColor = true;
            this.btnBuscarDocente.Click += new System.EventHandler(this.btnBuscarDocente_Click);
            // 
            // btnBuscarCurso
            // 
            this.btnBuscarCurso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscarCurso.Location = new System.Drawing.Point(479, 97);
            this.btnBuscarCurso.Name = "btnBuscarCurso";
            this.btnBuscarCurso.Size = new System.Drawing.Size(26, 26);
            this.btnBuscarCurso.TabIndex = 84;
            this.btnBuscarCurso.Text = "B";
            this.btnBuscarCurso.UseVisualStyleBackColor = true;
            this.btnBuscarCurso.Click += new System.EventHandler(this.btnBuscarCurso_Click);
            // 
            // btnBuscarEstudiante
            // 
            this.btnBuscarEstudiante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscarEstudiante.Location = new System.Drawing.Point(479, 68);
            this.btnBuscarEstudiante.Name = "btnBuscarEstudiante";
            this.btnBuscarEstudiante.Size = new System.Drawing.Size(26, 26);
            this.btnBuscarEstudiante.TabIndex = 83;
            this.btnBuscarEstudiante.Text = "B";
            this.btnBuscarEstudiante.UseVisualStyleBackColor = true;
            this.btnBuscarEstudiante.Click += new System.EventHandler(this.btnBuscarEstudiante_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(587, 128);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(81, 23);
            this.dtpFecha.TabIndex = 81;
            // 
            // txtIdIdi_Semestre
            // 
            this.txtIdIdi_Semestre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdIdi_Semestre.Location = new System.Drawing.Point(587, 99);
            this.txtIdIdi_Semestre.MaxLength = 10;
            this.txtIdIdi_Semestre.Name = "txtIdIdi_Semestre";
            this.txtIdIdi_Semestre.ReadOnly = true;
            this.txtIdIdi_Semestre.Size = new System.Drawing.Size(81, 23);
            this.txtIdIdi_Semestre.TabIndex = 80;
            this.txtIdIdi_Semestre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIdIdi_Curso
            // 
            this.txtIdIdi_Curso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdIdi_Curso.Location = new System.Drawing.Point(88, 99);
            this.txtIdIdi_Curso.MaxLength = 10;
            this.txtIdIdi_Curso.Name = "txtIdIdi_Curso";
            this.txtIdIdi_Curso.ReadOnly = true;
            this.txtIdIdi_Curso.Size = new System.Drawing.Size(77, 23);
            this.txtIdIdi_Curso.TabIndex = 79;
            this.txtIdIdi_Curso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIdIdi_Docente
            // 
            this.txtIdIdi_Docente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdIdi_Docente.Location = new System.Drawing.Point(586, 70);
            this.txtIdIdi_Docente.MaxLength = 10;
            this.txtIdIdi_Docente.Name = "txtIdIdi_Docente";
            this.txtIdIdi_Docente.ReadOnly = true;
            this.txtIdIdi_Docente.Size = new System.Drawing.Size(82, 23);
            this.txtIdIdi_Docente.TabIndex = 78;
            this.txtIdIdi_Docente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCodigoUniversitario
            // 
            this.txtCodigoUniversitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoUniversitario.Location = new System.Drawing.Point(88, 70);
            this.txtCodigoUniversitario.MaxLength = 10;
            this.txtCodigoUniversitario.Name = "txtCodigoUniversitario";
            this.txtCodigoUniversitario.ReadOnly = true;
            this.txtCodigoUniversitario.Size = new System.Drawing.Size(77, 23);
            this.txtCodigoUniversitario.TabIndex = 77;
            this.txtCodigoUniversitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEstudiante
            // 
            this.txtEstudiante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstudiante.Location = new System.Drawing.Point(171, 70);
            this.txtEstudiante.MaxLength = 40;
            this.txtEstudiante.Name = "txtEstudiante";
            this.txtEstudiante.ReadOnly = true;
            this.txtEstudiante.Size = new System.Drawing.Size(302, 23);
            this.txtEstudiante.TabIndex = 76;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(52, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 15);
            this.label10.TabIndex = 75;
            this.label10.Text = "Tipo";
            // 
            // pnlSexo
            // 
            this.pnlSexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSexo.Controls.Add(this.rbtAcreditacion);
            this.pnlSexo.Controls.Add(this.rbtUbicacion);
            this.pnlSexo.Location = new System.Drawing.Point(86, 41);
            this.pnlSexo.Name = "pnlSexo";
            this.pnlSexo.Size = new System.Drawing.Size(222, 23);
            this.pnlSexo.TabIndex = 74;
            // 
            // rbtAcreditacion
            // 
            this.rbtAcreditacion.AutoSize = true;
            this.rbtAcreditacion.Location = new System.Drawing.Point(106, 1);
            this.rbtAcreditacion.Name = "rbtAcreditacion";
            this.rbtAcreditacion.Size = new System.Drawing.Size(92, 19);
            this.rbtAcreditacion.TabIndex = 50;
            this.rbtAcreditacion.TabStop = true;
            this.rbtAcreditacion.Text = "Acreditación";
            this.rbtAcreditacion.UseVisualStyleBackColor = true;
            // 
            // rbtUbicacion
            // 
            this.rbtUbicacion.AutoSize = true;
            this.rbtUbicacion.Location = new System.Drawing.Point(22, 1);
            this.rbtUbicacion.Name = "rbtUbicacion";
            this.rbtUbicacion.Size = new System.Drawing.Size(78, 19);
            this.rbtUbicacion.TabIndex = 49;
            this.rbtUbicacion.TabStop = true;
            this.rbtUbicacion.Text = "Ubicación";
            this.rbtUbicacion.UseVisualStyleBackColor = true;
            // 
            // txtCurso
            // 
            this.txtCurso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurso.Location = new System.Drawing.Point(171, 99);
            this.txtCurso.MaxLength = 50;
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.ReadOnly = true;
            this.txtCurso.Size = new System.Drawing.Size(302, 23);
            this.txtCurso.TabIndex = 71;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(44, 102);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 15);
            this.label18.TabIndex = 70;
            this.label18.Text = "Curso";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(747, 132);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 15);
            this.label17.TabIndex = 68;
            this.label17.Text = "Nota";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(543, 132);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 15);
            this.label16.TabIndex = 66;
            this.label16.Text = "Fecha";
            // 
            // txtTema
            // 
            this.txtTema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTema.Location = new System.Drawing.Point(88, 128);
            this.txtTema.MaxLength = 12;
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(383, 23);
            this.txtTema.TabIndex = 63;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(47, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 15);
            this.label9.TabIndex = 62;
            this.label9.Text = "Tema";
            // 
            // txtDocente
            // 
            this.txtDocente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocente.Location = new System.Drawing.Point(674, 70);
            this.txtDocente.MaxLength = 40;
            this.txtDocente.Name = "txtDocente";
            this.txtDocente.ReadOnly = true;
            this.txtDocente.Size = new System.Drawing.Size(302, 23);
            this.txtDocente.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(529, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 60;
            this.label5.Text = "Docente";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(20, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 58;
            this.label8.Text = "Estudiante";
            // 
            // txtSemestre
            // 
            this.txtSemestre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSemestre.Location = new System.Drawing.Point(674, 99);
            this.txtSemestre.MaxLength = 40;
            this.txtSemestre.Name = "txtSemestre";
            this.txtSemestre.ReadOnly = true;
            this.txtSemestre.Size = new System.Drawing.Size(169, 23);
            this.txtSemestre.TabIndex = 57;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(526, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 15);
            this.label13.TabIndex = 56;
            this.label13.Text = "Semestre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Información General";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnGuardar);
            this.panel4.Controls.Add(this.btnNuevo);
            this.panel4.Controls.Add(this.btnCancelar);
            this.panel4.Location = new System.Drawing.Point(-1, 451);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1025, 40);
            this.panel4.TabIndex = 11;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(799, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(107, 26);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "   Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Location = new System.Drawing.Point(686, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(107, 26);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "   Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(912, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 26);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "   Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAdministracionExamen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1049, 586);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(1065, 625);
            this.Name = "frmAdministracionExamen";
            this.Text = "Administración de Examenes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdministracionExamen_FormClosed);
            this.Load += new System.EventHandler(this.frmAdministracionExamen_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamen)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlDatosExamen.ResumeLayout(false);
            this.pnlDatosExamen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNota)).EndInit();
            this.pnlSexo.ResumeLayout(false);
            this.pnlSexo.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDatosExamen;
        private System.Windows.Forms.TextBox txtCurso;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDocente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSemestre;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlSexo;
        private System.Windows.Forms.RadioButton rbtAcreditacion;
        private System.Windows.Forms.RadioButton rbtUbicacion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFiltroCodigoUniversitario;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvExamen;
        private System.Windows.Forms.TextBox txtEstudiante;
        private System.Windows.Forms.TextBox txtIdIdi_Semestre;
        private System.Windows.Forms.TextBox txtIdIdi_Curso;
        private System.Windows.Forms.TextBox txtIdIdi_Docente;
        private System.Windows.Forms.TextBox txtCodigoUniversitario;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnBuscarSemestre;
        private System.Windows.Forms.Button btnBuscarDocente;
        private System.Windows.Forms.Button btnBuscarCurso;
        private System.Windows.Forms.Button btnBuscarEstudiante;
        private System.Windows.Forms.NumericUpDown nudNota;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
    }
}