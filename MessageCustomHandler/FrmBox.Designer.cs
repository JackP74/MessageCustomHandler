namespace MessageCustomHandler
{
    partial class FrmBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBox));
            this.LabelMessage = new System.Windows.Forms.Label();
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.txtMoreDetails = new System.Windows.Forms.TextBox();
            this.PicBadge = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicBadge)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelMessage
            // 
            this.LabelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelMessage.Location = new System.Drawing.Point(50, 12);
            this.LabelMessage.Name = "LabelMessage";
            this.LabelMessage.Size = new System.Drawing.Size(504, 32);
            this.LabelMessage.TabIndex = 1;
            this.LabelMessage.Text = "Message";
            this.LabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelButtons
            // 
            this.PanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelButtons.Location = new System.Drawing.Point(12, 50);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Size = new System.Drawing.Size(542, 23);
            this.PanelButtons.TabIndex = 2;
            // 
            // txtMoreDetails
            // 
            this.txtMoreDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoreDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMoreDetails.Location = new System.Drawing.Point(12, 83);
            this.txtMoreDetails.Multiline = true;
            this.txtMoreDetails.Name = "txtMoreDetails";
            this.txtMoreDetails.ReadOnly = true;
            this.txtMoreDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoreDetails.Size = new System.Drawing.Size(542, 118);
            this.txtMoreDetails.TabIndex = 3;
            // 
            // PicBadge
            // 
            this.PicBadge.Location = new System.Drawing.Point(12, 12);
            this.PicBadge.Name = "PicBadge";
            this.PicBadge.Size = new System.Drawing.Size(32, 32);
            this.PicBadge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBadge.TabIndex = 0;
            this.PicBadge.TabStop = false;
            // 
            // FrmBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 83);
            this.Controls.Add(this.txtMoreDetails);
            this.Controls.Add(this.PanelButtons);
            this.Controls.Add(this.LabelMessage);
            this.Controls.Add(this.PicBadge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message";
            ((System.ComponentModel.ISupportInitialize)(this.PicBadge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBadge;
        private System.Windows.Forms.Label LabelMessage;
        private System.Windows.Forms.Panel PanelButtons;
        private System.Windows.Forms.TextBox txtMoreDetails;
    }
}

