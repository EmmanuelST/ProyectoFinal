﻿namespace ProyectoFinal.UI.Consultas.ReportViewers
{
    partial class ComprasReportViewer
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
            this.MycrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // MycrystalReportViewer
            // 
            this.MycrystalReportViewer.ActiveViewIndex = -1;
            this.MycrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MycrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.MycrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MycrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.MycrystalReportViewer.Name = "MycrystalReportViewer";
            this.MycrystalReportViewer.Size = new System.Drawing.Size(887, 577);
            this.MycrystalReportViewer.TabIndex = 0;
            // 
            // ComprasReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 577);
            this.Controls.Add(this.MycrystalReportViewer);
            this.Name = "ComprasReportViewer";
            this.Text = "ComprasReportViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer MycrystalReportViewer;
    }
}