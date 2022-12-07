namespace pry04.View.Idiomas_v2.Individuo
{
    partial class frmAdministracionDocente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdDocente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdEscalafon = new System.Windows.Forms.TextBox();
            this.dgvDocente = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSincronizarDocentes = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtApellidoMaterno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtApellidoPaterno = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocente)).BeginInit();
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
            this.label2.Location = new System.Drawing.Point(52, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "Administración de Docentes";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(684, 70);
            this.label1.TabIndex = 8;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.panel1);
            this.pnlPrincipal.Controls.Add(this.label6);
            this.pnlPrincipal.Controls.Add(this.txtIdDocente);
            this.pnlPrincipal.Controls.Add(this.label5);
            this.pnlPrincipal.Controls.Add(this.txtIdEscalafon);
            this.pnlPrincipal.Controls.Add(this.dgvDocente);
            this.pnlPrincipal.Controls.Add(this.label4);
            this.pnlPrincipal.Controls.Add(this.panel4);
            this.pnlPrincipal.Controls.Add(this.txtNombres);
            this.pnlPrincipal.Controls.Add(this.label13);
            this.pnlPrincipal.Controls.Add(this.txtApellidoMaterno);
            this.pnlPrincipal.Controls.Add(this.label9);
            this.pnlPrincipal.Controls.Add(this.label12);
            this.pnlPrincipal.Controls.Add(this.txtDocumento);
            this.pnlPrincipal.Controls.Add(this.txtApellidoPaterno);
            this.pnlPrincipal.Controls.Add(this.label11);
            this.pnlPrincipal.Location = new System.Drawing.Point(12, 82);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(660, 492);
            this.pnlPrincipal.TabIndex = 67;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFiltroNombre);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 40);
            this.panel1.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Listado de Docentes";
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroNombre.Location = new System.Drawing.Point(218, 8);
            this.txtFiltroNombre.MaxLength = 40;
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(310, 23);
            this.txtFiltroNombre.TabIndex = 63;
            this.txtFiltroNombre.TextChanged += new System.EventHandler(this.txtFiltroNombre_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(156, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 62;
            this.label7.Text = "Nombres";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(310, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 60;
            this.label6.Text = "ID Idiomas";
            // 
            // txtIdDocente
            // 
            this.txtIdDocente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdDocente.Location = new System.Drawing.Point(379, 358);
            this.txtIdDocente.MaxLength = 2;
            this.txtIdDocente.Name = "txtIdDocente";
            this.txtIdDocente.ReadOnly = true;
            this.txtIdDocente.Size = new System.Drawing.Size(46, 23);
            this.txtIdDocente.TabIndex = 61;
            this.txtIdDocente.Text = "0";
            this.txtIdDocente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(302, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 58;
            this.label5.Text = "ID Escalafón";
            // 
            // txtIdEscalafon
            // 
            this.txtIdEscalafon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdEscalafon.Location = new System.Drawing.Point(379, 329);
            this.txtIdEscalafon.MaxLength = 2;
            this.txtIdEscalafon.Name = "txtIdEscalafon";
            this.txtIdEscalafon.ReadOnly = true;
            this.txtIdEscalafon.Size = new System.Drawing.Size(46, 23);
            this.txtIdEscalafon.TabIndex = 59;
            this.txtIdEscalafon.Text = "0";
            this.txtIdEscalafon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvDocente
            // 
            this.dgvDocente.AllowUserToAddRows = false;
            this.dgvDocente.AllowUserToDeleteRows = false;
            this.dgvDocente.AllowUserToResizeColumns = false;
            this.dgvDocente.AllowUserToResizeRows = false;
            this.dgvDocente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocente.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocente.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDocente.EnableHeadersVisualStyles = false;
            this.dgvDocente.Location = new System.Drawing.Point(-1, 38);
            this.dgvDocente.MultiSelect = false;
            this.dgvDocente.Name = "dgvDocente";
            this.dgvDocente.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocente.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDocente.RowHeadersVisible = false;
            this.dgvDocente.RowTemplate.Height = 25;
            this.dgvDocente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocente.Size = new System.Drawing.Size(660, 250);
            this.dgvDocente.TabIndex = 57;
            this.dgvDocente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocente_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 56;
            this.label4.Text = "Datos Personales";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnSincronizarDocentes);
            this.panel4.Controls.Add(this.btnCancelar);
            this.panel4.Controls.Add(this.btnNuevo);
            this.panel4.Controls.Add(this.btnGuardar);
            this.panel4.Location = new System.Drawing.Point(-1, 451);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(660, 40);
            this.panel4.TabIndex = 47;
            // 
            // btnSincronizarDocentes
            // 
            this.btnSincronizarDocentes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSincronizarDocentes.Location = new System.Drawing.Point(6, 6);
            this.btnSincronizarDocentes.Name = "btnSincronizarDocentes";
            this.btnSincronizarDocentes.Size = new System.Drawing.Size(107, 26);
            this.btnSincronizarDocentes.TabIndex = 74;
            this.btnSincronizarDocentes.Text = "   Sincronizar";
            this.btnSincronizarDocentes.UseVisualStyleBackColor = true;
            this.btnSincronizarDocentes.Click += new System.EventHandler(this.btnSincronizarDocentes_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(548, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 26);
            this.btnCancelar.TabIndex = 73;
            this.btnCancelar.Text = "   Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Location = new System.Drawing.Point(322, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(107, 26);
            this.btnNuevo.TabIndex = 71;
            this.btnNuevo.Text = "   Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(435, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(107, 26);
            this.btnGuardar.TabIndex = 72;
            this.btnGuardar.Text = "   Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNombres
            // 
            this.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombres.Location = new System.Drawing.Point(115, 416);
            this.txtNombres.MaxLength = 40;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(310, 23);
            this.txtNombres.TabIndex = 55;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(53, 420);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 15);
            this.label13.TabIndex = 54;
            this.label13.Text = "Nombres";
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoMaterno.Location = new System.Drawing.Point(115, 387);
            this.txtApellidoMaterno.MaxLength = 30;
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(145, 23);
            this.txtApellidoMaterno.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(23, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 15);
            this.label9.TabIndex = 46;
            this.label9.Text = "N° documento";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(10, 391);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 15);
            this.label12.TabIndex = 52;
            this.label12.Text = "Apellido Materno";
            // 
            // txtDocumento
            // 
            this.txtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumento.Location = new System.Drawing.Point(115, 329);
            this.txtDocumento.MaxLength = 15;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(106, 23);
            this.txtDocumento.TabIndex = 47;
            this.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoPaterno.Location = new System.Drawing.Point(115, 358);
            this.txtApellidoPaterno.MaxLength = 30;
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(145, 23);
            this.txtApellidoPaterno.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(14, 362);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 15);
            this.label11.TabIndex = 50;
            this.label11.Text = "Apellido Paterno";
            // 
            // frmAdministracionDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 586);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(700, 625);
            this.MinimumSize = new System.Drawing.Size(700, 625);
            this.Name = "frmAdministracionDocente";
            this.Text = "Administración de Docentes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdministracionDocente_FormClosed);
            this.Load += new System.EventHandler(this.frmAdministracionDocente_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocente)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtApellidoMaterno;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtApellidoPaterno;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDocente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdDocente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdEscalafon;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSincronizarDocentes;
        private System.Windows.Forms.Panel panel1;
    }
}