﻿
namespace TP2021_Mendiburu_GeonasStunf
{
    partial class FormInicio
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
            this.txtCantTabaGenerar = new System.Windows.Forms.TextBox();
            this.txtPedirCantTableros = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCantTabaGenerar
            // 
            this.txtCantTabaGenerar.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtCantTabaGenerar.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCantTabaGenerar.Font = new System.Drawing.Font("Mongolian Baiti", 18F);
            this.txtCantTabaGenerar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCantTabaGenerar.Location = new System.Drawing.Point(137, 152);
            this.txtCantTabaGenerar.Name = "txtCantTabaGenerar";
            this.txtCantTabaGenerar.ReadOnly = true;
            this.txtCantTabaGenerar.Size = new System.Drawing.Size(280, 35);
            this.txtCantTabaGenerar.TabIndex = 0;
            this.txtCantTabaGenerar.Text = "Cantidad tableros a generar";
            this.txtCantTabaGenerar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtPedirCantTableros
            // 
            this.txtPedirCantTableros.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtPedirCantTableros.Font = new System.Drawing.Font("Mongolian Baiti", 18F);
            this.txtPedirCantTableros.Location = new System.Drawing.Point(423, 152);
            this.txtPedirCantTableros.Name = "txtPedirCantTableros";
            this.txtPedirCantTableros.Size = new System.Drawing.Size(100, 35);
            this.txtPedirCantTableros.TabIndex = 1;
            this.txtPedirCantTableros.TextChanged += new System.EventHandler(this.txtPedirCantTableros_TextChanged);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(603, 275);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(103, 49);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(618, 330);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 46);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtPedirCantTableros);
            this.Controls.Add(this.txtCantTabaGenerar);
            this.Name = "FormInicio";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormInicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCantTabaGenerar;
        private System.Windows.Forms.TextBox txtPedirCantTableros;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnSalir;
    }
}

