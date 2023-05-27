namespace ld137_323_Assignment_2
{
    partial class Form1
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
            this.idTextbox = new System.Windows.Forms.TextBox();
            this.idSubmitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idTextbox
            // 
            this.idTextbox.Location = new System.Drawing.Point(131, 168);
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.Size = new System.Drawing.Size(100, 20);
            this.idTextbox.TabIndex = 0;
            // 
            // idSubmitButton
            // 
            this.idSubmitButton.Location = new System.Drawing.Point(237, 166);
            this.idSubmitButton.Name = "idSubmitButton";
            this.idSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.idSubmitButton.TabIndex = 1;
            this.idSubmitButton.Text = "Submit";
            this.idSubmitButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.idSubmitButton);
            this.Controls.Add(this.idTextbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idTextbox;
        private System.Windows.Forms.Button idSubmitButton;
    }
}

