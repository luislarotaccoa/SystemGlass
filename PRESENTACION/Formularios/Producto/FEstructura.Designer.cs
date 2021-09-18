namespace PRESENTACION.Formularios.Producto
{
    partial class FEstructura
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
            this.dgvCategoria = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.dgvFamilia = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvDescripcion2 = new System.Windows.Forms.DataGridView();
            this.dgvDescripcion1 = new System.Windows.Forms.DataGridView();
            this.dgvColor = new System.Windows.Forms.DataGridView();
            this.MenuMouse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescripcion2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescripcion1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColor)).BeginInit();
            this.MenuMouse.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMinimized
            // 
            this.btnMinimized.FlatAppearance.BorderSize = 0;
            // 
            // btnRestore
            // 
            this.btnRestore.FlatAppearance.BorderSize = 0;
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(2, 593);
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Size = new System.Drawing.Size(587, 25);
            // 
            // dgvCategoria
            // 
            this.dgvCategoria.AllowUserToAddRows = false;
            this.dgvCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCategoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoria.Location = new System.Drawing.Point(8, 33);
            this.dgvCategoria.Name = "dgvCategoria";
            this.dgvCategoria.ReadOnly = true;
            this.dgvCategoria.RowHeadersVisible = false;
            this.dgvCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategoria.Size = new System.Drawing.Size(285, 145);
            this.dgvCategoria.TabIndex = 8;
            this.dgvCategoria.SelectionChanged += new System.EventHandler(this.DgvCategoria_SelectionChanged);
            this.dgvCategoria.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Dgv_MouseClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.lblDescripcion);
            this.panel5.Controls.Add(this.txtCodigo);
            this.panel5.Controls.Add(this.lblCodigo);
            this.panel5.Controls.Add(this.btnCrear);
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(299, 33);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(285, 145);
            this.panel5.TabIndex = 39;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(6, 88);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(15, 16);
            this.lblDescripcion.TabIndex = 18;
            this.lblDescripcion.Text = "?";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(64, 18);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(208, 22);
            this.txtCodigo.TabIndex = 17;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 21);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 16);
            this.lblCodigo.TabIndex = 16;
            this.lblCodigo.Text = "Código";
            // 
            // btnCrear
            // 
            this.btnCrear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCrear.BackColor = System.Drawing.Color.Green;
            this.btnCrear.Location = new System.Drawing.Point(197, 55);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 24);
            this.btnCrear.TabIndex = 15;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // dgvFamilia
            // 
            this.dgvFamilia.AllowUserToAddRows = false;
            this.dgvFamilia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvFamilia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFamilia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFamilia.Location = new System.Drawing.Point(8, 191);
            this.dgvFamilia.Name = "dgvFamilia";
            this.dgvFamilia.ReadOnly = true;
            this.dgvFamilia.RowHeadersVisible = false;
            this.dgvFamilia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFamilia.Size = new System.Drawing.Size(285, 145);
            this.dgvFamilia.TabIndex = 40;
            this.dgvFamilia.SelectionChanged += new System.EventHandler(this.DgvFamilia_SelectionChanged);
            this.dgvFamilia.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Dgv_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.textBox1.Location = new System.Drawing.Point(5, 184);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(582, 1);
            this.textBox1.TabIndex = 43;
            // 
            // dgvDescripcion2
            // 
            this.dgvDescripcion2.AllowUserToAddRows = false;
            this.dgvDescripcion2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDescripcion2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDescripcion2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescripcion2.Location = new System.Drawing.Point(299, 191);
            this.dgvDescripcion2.Name = "dgvDescripcion2";
            this.dgvDescripcion2.ReadOnly = true;
            this.dgvDescripcion2.RowHeadersVisible = false;
            this.dgvDescripcion2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDescripcion2.Size = new System.Drawing.Size(285, 248);
            this.dgvDescripcion2.TabIndex = 44;
            this.dgvDescripcion2.SelectionChanged += new System.EventHandler(this.dgvDescrip2_SelectionChanged);
            this.dgvDescripcion2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Dgv_MouseClick);
            // 
            // dgvDescripcion1
            // 
            this.dgvDescripcion1.AllowUserToAddRows = false;
            this.dgvDescripcion1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDescripcion1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDescripcion1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescripcion1.Location = new System.Drawing.Point(8, 342);
            this.dgvDescripcion1.Name = "dgvDescripcion1";
            this.dgvDescripcion1.ReadOnly = true;
            this.dgvDescripcion1.RowHeadersVisible = false;
            this.dgvDescripcion1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDescripcion1.Size = new System.Drawing.Size(285, 248);
            this.dgvDescripcion1.TabIndex = 45;
            this.dgvDescripcion1.SelectionChanged += new System.EventHandler(this.dgvDescrip1_SelectionChanged);
            this.dgvDescripcion1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Dgv_MouseClick);
            // 
            // dgvColor
            // 
            this.dgvColor.AllowUserToAddRows = false;
            this.dgvColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvColor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColor.Location = new System.Drawing.Point(299, 445);
            this.dgvColor.Name = "dgvColor";
            this.dgvColor.ReadOnly = true;
            this.dgvColor.RowHeadersVisible = false;
            this.dgvColor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColor.Size = new System.Drawing.Size(285, 145);
            this.dgvColor.TabIndex = 46;
            this.dgvColor.SelectionChanged += new System.EventHandler(this.dgvColor_SelectionChanged);
            this.dgvColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Dgv_MouseClick);
            // 
            // MenuMouse
            // 
            this.MenuMouse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.actualizarToolStripMenuItem});
            this.MenuMouse.Name = "MenuMouse";
            this.MenuMouse.Size = new System.Drawing.Size(127, 70);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.NuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.EditarToolStripMenuItem_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.ActualizarToolStripMenuItem_Click);
            // 
            // FEstructura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 608);
            this.Controls.Add(this.dgvColor);
            this.Controls.Add(this.dgvDescripcion1);
            this.Controls.Add(this.dgvDescripcion2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvFamilia);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.dgvCategoria);
            this.Name = "FEstructura";
            this.Text = "FEstructura";
            this.Controls.SetChildIndex(this.pnlTitulo, 0);
            this.Controls.SetChildIndex(this.lblError, 0);
            this.Controls.SetChildIndex(this.dgvCategoria, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.dgvFamilia, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.dgvDescripcion2, 0);
            this.Controls.SetChildIndex(this.dgvDescripcion1, 0);
            this.Controls.SetChildIndex(this.dgvColor, 0);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescripcion2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescripcion1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColor)).EndInit();
            this.MenuMouse.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategoria;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.DataGridView dgvFamilia;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvDescripcion2;
        private System.Windows.Forms.DataGridView dgvDescripcion1;
        private System.Windows.Forms.DataGridView dgvColor;
        private System.Windows.Forms.ContextMenuStrip MenuMouse;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
    }
}