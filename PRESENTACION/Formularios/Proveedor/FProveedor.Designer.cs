using VERTICAL.Controles;

namespace PRESENTACION.Formularios.Proveedor
{
    partial class FProveedor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblEstado = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.txtTelefono = new VERTICAL.Controles.TextBoxValidado();
            this.txtEmail = new VERTICAL.Controles.TextBoxValidado();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbProvincia = new System.Windows.Forms.ComboBox();
            this.cbDistrito = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRazSocial = new System.Windows.Forms.TextBox();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDocumento = new System.Windows.Forms.ComboBox();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbCompras = new System.Windows.Forms.GroupBox();
            this.btnProcesar = new FontAwesome.Sharp.IconButton();
            this.txtFecha2 = new System.Windows.Forms.DateTimePicker();
            this.txtFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dgvDespDetalles = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtNumero = new VERTICAL.Controles.TextBoxValidado();
            this.tbpSocio = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.txtEmailContacto = new VERTICAL.Controles.TextBoxValidado();
            this.txtNombresContacto = new VERTICAL.Controles.TextBoxValidado();
            this.txtTelfContacto = new VERTICAL.Controles.TextBoxValidado();
            this.txtArea = new VERTICAL.Controles.TextBoxValidado();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnGuardarContacto = new System.Windows.Forms.Button();
            this.btnCancelarContacto = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvContacto = new System.Windows.Forms.DataGridView();
            this.IdContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbcDatosAdicionales = new System.Windows.Forms.TabControl();
            this.pnlTitulo.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.Menu.SuspendLayout();
            this.gbCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDespDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tbpSocio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacto)).BeginInit();
            this.tbcDatosAdicionales.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMinimized
            // 
            this.btnMinimized.FlatAppearance.BorderSize = 0;
            this.btnMinimized.Size = new System.Drawing.Size(23, 30);
            // 
            // btnRestore
            // 
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.Size = new System.Drawing.Size(23, 30);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Location = new System.Drawing.Point(468, 7);
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(5, 587);
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Size = new System.Drawing.Size(989, 30);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(283, 68);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 74;
            this.lblEstado.Text = "Estado";
            // 
            // gbDatos
            // 
            this.gbDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatos.Controls.Add(this.btnCancelar);
            this.gbDatos.Controls.Add(this.btnEditar);
            this.gbDatos.Controls.Add(this.btnGuardar);
            this.gbDatos.Controls.Add(this.lblDireccion);
            this.gbDatos.Controls.Add(this.txtLine);
            this.gbDatos.Controls.Add(this.txtTelefono);
            this.gbDatos.Controls.Add(this.txtEmail);
            this.gbDatos.Controls.Add(this.label13);
            this.gbDatos.Controls.Add(this.label11);
            this.gbDatos.Controls.Add(this.cbProvincia);
            this.gbDatos.Controls.Add(this.cbDistrito);
            this.gbDatos.Controls.Add(this.label8);
            this.gbDatos.Controls.Add(this.cbDepartamento);
            this.gbDatos.Controls.Add(this.label9);
            this.gbDatos.Controls.Add(this.label7);
            this.gbDatos.Controls.Add(this.label5);
            this.gbDatos.Controls.Add(this.txtDireccion);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.txtRazSocial);
            this.gbDatos.Enabled = false;
            this.gbDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbDatos.Location = new System.Drawing.Point(12, 98);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(486, 269);
            this.gbDatos.TabIndex = 69;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Reply;
            this.btnCancelar.IconColor = System.Drawing.Color.Crimson;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 28;
            this.btnCancelar.Location = new System.Drawing.Point(450, 233);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(30, 30);
            this.btnCancelar.TabIndex = 79;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnEditar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.IconSize = 28;
            this.btnEditar.Location = new System.Drawing.Point(409, 233);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(30, 30);
            this.btnEditar.TabIndex = 78;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(83)))), ((int)(((byte)(145)))));
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 28;
            this.btnGuardar.Location = new System.Drawing.Point(368, 233);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(30, 30);
            this.btnGuardar.TabIndex = 77;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblDireccion
            // 
            this.lblDireccion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(14, 177);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 72;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtLine
            // 
            this.txtLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLine.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLine.Enabled = false;
            this.txtLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.txtLine.ForeColor = System.Drawing.Color.Transparent;
            this.txtLine.Location = new System.Drawing.Point(17, 193);
            this.txtLine.Multiline = true;
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(459, 1);
            this.txtLine.TabIndex = 71;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTelefono.Decimales = 0;
            this.txtTelefono.Location = new System.Drawing.Point(174, 233);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(158, 20);
            this.txtTelefono.TabIndex = 70;
            this.txtTelefono.TextBoxDecimales = false;
            this.txtTelefono.TextBoxEmail = false;
            this.txtTelefono.TextBoxMayus = false;
            this.txtTelefono.TextBoxNumero = false;
            this.txtTelefono.TextBoxUrl = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmail.Decimales = 0;
            this.txtEmail.Location = new System.Drawing.Point(17, 233);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(151, 20);
            this.txtEmail.TabIndex = 69;
            this.txtEmail.TextBoxDecimales = false;
            this.txtEmail.TextBoxEmail = true;
            this.txtEmail.TextBoxMayus = false;
            this.txtEmail.TextBoxNumero = false;
            this.txtEmail.TextBoxUrl = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(320, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Distrito";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(161, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Provincia";
            // 
            // cbProvincia
            // 
            this.cbProvincia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbProvincia.FormattingEnabled = true;
            this.cbProvincia.Location = new System.Drawing.Point(164, 105);
            this.cbProvincia.Name = "cbProvincia";
            this.cbProvincia.Size = new System.Drawing.Size(141, 21);
            this.cbProvincia.TabIndex = 33;
            this.cbProvincia.SelectedIndexChanged += new System.EventHandler(this.cbProvincia_SelectedIndexChanged);
            // 
            // cbDistrito
            // 
            this.cbDistrito.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbDistrito.FormattingEnabled = true;
            this.cbDistrito.Location = new System.Drawing.Point(317, 105);
            this.cbDistrito.Name = "cbDistrito";
            this.cbDistrito.Size = new System.Drawing.Size(141, 21);
            this.cbDistrito.TabIndex = 32;
            this.cbDistrito.SelectedIndexChanged += new System.EventHandler(this.cbDistrito_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Departamento";
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(17, 105);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(141, 21);
            this.cbDepartamento.TabIndex = 29;
            this.cbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cbDepartamento_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(171, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Telefono";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Email";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Dirección (Calle,Av,Lte,Urb,Mz,Nro)";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccion.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.txtDireccion.ForeColor = System.Drawing.Color.Transparent;
            this.txtDireccion.Location = new System.Drawing.Point(17, 149);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(459, 20);
            this.txtDireccion.TabIndex = 20;
            this.txtDireccion.TextChanged += new System.EventHandler(this.txtDireccion_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Razón Social";
            // 
            // txtRazSocial
            // 
            this.txtRazSocial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRazSocial.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtRazSocial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRazSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.txtRazSocial.ForeColor = System.Drawing.Color.Transparent;
            this.txtRazSocial.Location = new System.Drawing.Point(17, 48);
            this.txtRazSocial.Multiline = true;
            this.txtRazSocial.Name = "txtRazSocial";
            this.txtRazSocial.Size = new System.Drawing.Size(459, 20);
            this.txtRazSocial.TabIndex = 17;
            this.txtRazSocial.TextChanged += new System.EventHandler(this.txtRazSocial_TextChanged);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesactivar.BackColor = System.Drawing.Color.White;
            this.btnDesactivar.Location = new System.Drawing.Point(389, 45);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(109, 49);
            this.btnDesactivar.TabIndex = 73;
            this.btnDesactivar.UseVisualStyleBackColor = false;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Tipo de Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Número";
            // 
            // cbDocumento
            // 
            this.cbDocumento.ForeColor = System.Drawing.Color.Black;
            this.cbDocumento.FormattingEnabled = true;
            this.cbDocumento.Location = new System.Drawing.Point(16, 61);
            this.cbDocumento.Name = "cbDocumento";
            this.cbDocumento.Size = new System.Drawing.Size(98, 21);
            this.cbDocumento.TabIndex = 72;
            this.cbDocumento.SelectedIndexChanged += new System.EventHandler(this.cbDocumento_SelectedIndexChanged);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(118, 70);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // gbCompras
            // 
            this.gbCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCompras.Controls.Add(this.btnProcesar);
            this.gbCompras.Controls.Add(this.txtFecha2);
            this.gbCompras.Controls.Add(this.txtFecha1);
            this.gbCompras.Controls.Add(this.dataGridView4);
            this.gbCompras.Controls.Add(this.dgvDespDetalles);
            this.gbCompras.Location = new System.Drawing.Point(16, 373);
            this.gbCompras.Name = "gbCompras";
            this.gbCompras.Size = new System.Drawing.Size(966, 211);
            this.gbCompras.TabIndex = 77;
            this.gbCompras.TabStop = false;
            this.gbCompras.Text = "Compras";
            // 
            // btnProcesar
            // 
            this.btnProcesar.FlatAppearance.BorderSize = 0;
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesar.IconChar = FontAwesome.Sharp.IconChar.ThList;
            this.btnProcesar.IconColor = System.Drawing.Color.Green;
            this.btnProcesar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProcesar.IconSize = 20;
            this.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesar.Location = new System.Drawing.Point(204, 18);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(23, 23);
            this.btnProcesar.TabIndex = 71;
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcesar.UseVisualStyleBackColor = true;
            // 
            // txtFecha2
            // 
            this.txtFecha2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha2.Location = new System.Drawing.Point(109, 19);
            this.txtFecha2.Name = "txtFecha2";
            this.txtFecha2.Size = new System.Drawing.Size(89, 21);
            this.txtFecha2.TabIndex = 70;
            // 
            // txtFecha1
            // 
            this.txtFecha1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha1.Location = new System.Drawing.Point(6, 19);
            this.txtFecha1.Name = "txtFecha1";
            this.txtFecha1.Size = new System.Drawing.Size(89, 21);
            this.txtFecha1.TabIndex = 69;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(6, 44);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(451, 161);
            this.dataGridView4.TabIndex = 68;
            // 
            // dgvDespDetalles
            // 
            this.dgvDespDetalles.AllowUserToAddRows = false;
            this.dgvDespDetalles.AllowUserToDeleteRows = false;
            this.dgvDespDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDespDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDespDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDespDetalles.Location = new System.Drawing.Point(463, 14);
            this.dgvDespDetalles.Name = "dgvDespDetalles";
            this.dgvDespDetalles.ReadOnly = true;
            this.dgvDespDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDespDetalles.Size = new System.Drawing.Size(497, 191);
            this.dgvDespDetalles.TabIndex = 67;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtNumero
            // 
            this.txtNumero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNumero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNumero.Decimales = 0;
            this.txtNumero.ForeColor = System.Drawing.Color.Black;
            this.txtNumero.Location = new System.Drawing.Point(120, 61);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(151, 20);
            this.txtNumero.TabIndex = 75;
            this.txtNumero.TextBoxDecimales = false;
            this.txtNumero.TextBoxEmail = false;
            this.txtNumero.TextBoxMayus = false;
            this.txtNumero.TextBoxNumero = true;
            this.txtNumero.TextBoxUrl = false;
            this.txtNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyDown);
            // 
            // tbpSocio
            // 
            this.tbpSocio.Controls.Add(this.label3);
            this.tbpSocio.Controls.Add(this.Email);
            this.tbpSocio.Controls.Add(this.txtEmailContacto);
            this.tbpSocio.Controls.Add(this.txtNombresContacto);
            this.tbpSocio.Controls.Add(this.txtTelfContacto);
            this.tbpSocio.Controls.Add(this.txtArea);
            this.tbpSocio.Controls.Add(this.textBox4);
            this.tbpSocio.Controls.Add(this.btnGuardarContacto);
            this.tbpSocio.Controls.Add(this.btnCancelarContacto);
            this.tbpSocio.Controls.Add(this.label14);
            this.tbpSocio.Controls.Add(this.dgvContacto);
            this.tbpSocio.Controls.Add(this.label12);
            this.tbpSocio.Controls.Add(this.label10);
            this.tbpSocio.Location = new System.Drawing.Point(4, 22);
            this.tbpSocio.Name = "tbpSocio";
            this.tbpSocio.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSocio.Size = new System.Drawing.Size(471, 296);
            this.tbpSocio.TabIndex = 0;
            this.tbpSocio.Text = "Contactos";
            this.tbpSocio.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(298, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "Telefono";
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.ForeColor = System.Drawing.Color.Black;
            this.Email.Location = new System.Drawing.Point(15, 66);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(32, 13);
            this.Email.TabIndex = 75;
            this.Email.Text = "Email";
            // 
            // txtEmailContacto
            // 
            this.txtEmailContacto.Decimales = 0;
            this.txtEmailContacto.Enabled = false;
            this.txtEmailContacto.ForeColor = System.Drawing.Color.Black;
            this.txtEmailContacto.Location = new System.Drawing.Point(18, 82);
            this.txtEmailContacto.Name = "txtEmailContacto";
            this.txtEmailContacto.Size = new System.Drawing.Size(277, 20);
            this.txtEmailContacto.TabIndex = 74;
            this.txtEmailContacto.TextBoxDecimales = false;
            this.txtEmailContacto.TextBoxEmail = true;
            this.txtEmailContacto.TextBoxMayus = false;
            this.txtEmailContacto.TextBoxNumero = false;
            this.txtEmailContacto.TextBoxUrl = false;
            // 
            // txtNombresContacto
            // 
            this.txtNombresContacto.Decimales = 0;
            this.txtNombresContacto.Enabled = false;
            this.txtNombresContacto.ForeColor = System.Drawing.Color.Black;
            this.txtNombresContacto.Location = new System.Drawing.Point(18, 31);
            this.txtNombresContacto.Name = "txtNombresContacto";
            this.txtNombresContacto.Size = new System.Drawing.Size(277, 20);
            this.txtNombresContacto.TabIndex = 71;
            this.txtNombresContacto.TextBoxDecimales = false;
            this.txtNombresContacto.TextBoxEmail = false;
            this.txtNombresContacto.TextBoxMayus = false;
            this.txtNombresContacto.TextBoxNumero = false;
            this.txtNombresContacto.TextBoxUrl = false;
            // 
            // txtTelfContacto
            // 
            this.txtTelfContacto.Decimales = 0;
            this.txtTelfContacto.Enabled = false;
            this.txtTelfContacto.ForeColor = System.Drawing.Color.Black;
            this.txtTelfContacto.Location = new System.Drawing.Point(301, 82);
            this.txtTelfContacto.Name = "txtTelfContacto";
            this.txtTelfContacto.Size = new System.Drawing.Size(101, 20);
            this.txtTelfContacto.TabIndex = 70;
            this.txtTelfContacto.TextBoxDecimales = false;
            this.txtTelfContacto.TextBoxEmail = false;
            this.txtTelfContacto.TextBoxMayus = false;
            this.txtTelfContacto.TextBoxNumero = false;
            this.txtTelfContacto.TextBoxUrl = false;
            // 
            // txtArea
            // 
            this.txtArea.Decimales = 0;
            this.txtArea.Enabled = false;
            this.txtArea.ForeColor = System.Drawing.Color.Black;
            this.txtArea.Location = new System.Drawing.Point(301, 31);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(101, 20);
            this.txtArea.TabIndex = 70;
            this.txtArea.TextBoxDecimales = false;
            this.txtArea.TextBoxEmail = false;
            this.txtArea.TextBoxMayus = false;
            this.txtArea.TextBoxNumero = false;
            this.txtArea.TextBoxUrl = false;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.BackColor = System.Drawing.SystemColors.GrayText;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.textBox4.ForeColor = System.Drawing.Color.Black;
            this.textBox4.Location = new System.Drawing.Point(9, 116);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(456, 1);
            this.textBox4.TabIndex = 46;
            // 
            // btnGuardarContacto
            // 
            this.btnGuardarContacto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardarContacto.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardarContacto.Enabled = false;
            this.btnGuardarContacto.ForeColor = System.Drawing.Color.Black;
            this.btnGuardarContacto.Location = new System.Drawing.Point(414, 53);
            this.btnGuardarContacto.Name = "btnGuardarContacto";
            this.btnGuardarContacto.Size = new System.Drawing.Size(34, 23);
            this.btnGuardarContacto.TabIndex = 73;
            this.btnGuardarContacto.Text = "S";
            this.btnGuardarContacto.UseVisualStyleBackColor = false;
            this.btnGuardarContacto.Click += new System.EventHandler(this.btnSocioGuardar_Click);
            // 
            // btnCancelarContacto
            // 
            this.btnCancelarContacto.BackColor = System.Drawing.Color.Red;
            this.btnCancelarContacto.Enabled = false;
            this.btnCancelarContacto.ForeColor = System.Drawing.Color.Black;
            this.btnCancelarContacto.Location = new System.Drawing.Point(414, 79);
            this.btnCancelarContacto.Name = "btnCancelarContacto";
            this.btnCancelarContacto.Size = new System.Drawing.Size(34, 23);
            this.btnCancelarContacto.TabIndex = 48;
            this.btnCancelarContacto.Text = "C";
            this.btnCancelarContacto.UseVisualStyleBackColor = false;
            this.btnCancelarContacto.Click += new System.EventHandler(this.btnCancelarContacto_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(6, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "Contactos";
            // 
            // dgvContacto
            // 
            this.dgvContacto.AllowUserToAddRows = false;
            this.dgvContacto.AllowUserToDeleteRows = false;
            this.dgvContacto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContacto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContacto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdContacto,
            this.IdProveedor,
            this.Nombres,
            this.Area,
            this.EmailContacto,
            this.Telefono,
            this.Estado});
            this.dgvContacto.ContextMenuStrip = this.Menu;
            this.dgvContacto.Location = new System.Drawing.Point(9, 136);
            this.dgvContacto.Name = "dgvContacto";
            this.dgvContacto.ReadOnly = true;
            this.dgvContacto.RowHeadersVisible = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvContacto.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContacto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContacto.Size = new System.Drawing.Size(456, 154);
            this.dgvContacto.TabIndex = 44;
            // 
            // IdContacto
            // 
            this.IdContacto.HeaderText = "IdContacto";
            this.IdContacto.Name = "IdContacto";
            this.IdContacto.ReadOnly = true;
            this.IdContacto.Visible = false;
            // 
            // IdProveedor
            // 
            this.IdProveedor.HeaderText = "IdProveedor";
            this.IdProveedor.Name = "IdProveedor";
            this.IdProveedor.ReadOnly = true;
            this.IdProveedor.Visible = false;
            // 
            // Nombres
            // 
            this.Nombres.HeaderText = "Nombres";
            this.Nombres.Name = "Nombres";
            this.Nombres.ReadOnly = true;
            // 
            // Area
            // 
            this.Area.HeaderText = "Area";
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            // 
            // EmailContacto
            // 
            this.EmailContacto.HeaderText = "Email";
            this.EmailContacto.Name = "EmailContacto";
            this.EmailContacto.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Felefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(298, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 43;
            this.label12.Text = "Area";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(15, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Nombres";
            // 
            // tbcDatosAdicionales
            // 
            this.tbcDatosAdicionales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcDatosAdicionales.Controls.Add(this.tbpSocio);
            this.tbcDatosAdicionales.Enabled = false;
            this.tbcDatosAdicionales.Location = new System.Drawing.Point(503, 45);
            this.tbcDatosAdicionales.Name = "tbcDatosAdicionales";
            this.tbcDatosAdicionales.SelectedIndex = 0;
            this.tbcDatosAdicionales.Size = new System.Drawing.Size(479, 322);
            this.tbcDatosAdicionales.TabIndex = 76;
            // 
            // FProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 609);
            this.Controls.Add(this.gbCompras);
            this.Controls.Add(this.tbcDatosAdicionales);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDocumento);
            this.Name = "FProveedor";
            this.Text = "MProveedor";
            this.Controls.SetChildIndex(this.cbDocumento, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNumero, 0);
            this.Controls.SetChildIndex(this.btnDesactivar, 0);
            this.Controls.SetChildIndex(this.gbDatos, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.tbcDatosAdicionales, 0);
            this.Controls.SetChildIndex(this.gbCompras, 0);
            this.Controls.SetChildIndex(this.lblError, 0);
            this.Controls.SetChildIndex(this.pnlTitulo, 0);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.gbCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDespDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tbpSocio.ResumeLayout(false);
            this.tbpSocio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacto)).EndInit();
            this.tbcDatosAdicionales.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblDireccion;
        public System.Windows.Forms.TextBox txtLine;
        private TextBoxValidado txtTelefono;
        private TextBoxValidado txtEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbProvincia;
        private System.Windows.Forms.ComboBox cbDistrito;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtRazSocial;
        private System.Windows.Forms.Button btnDesactivar;
        private TextBoxValidado txtNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDocumento;
        private System.Windows.Forms.GroupBox gbCompras;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridView dgvDespDetalles;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker txtFecha2;
        private System.Windows.Forms.DateTimePicker txtFecha1;
        private FontAwesome.Sharp.IconButton btnProcesar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.TabControl tbcDatosAdicionales;
        private System.Windows.Forms.TabPage tbpSocio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Email;
        private TextBoxValidado txtEmailContacto;
        private TextBoxValidado txtNombresContacto;
        private TextBoxValidado txtTelfContacto;
        private TextBoxValidado txtArea;
        public System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnGuardarContacto;
        private System.Windows.Forms.Button btnCancelarContacto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvContacto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
    }
}