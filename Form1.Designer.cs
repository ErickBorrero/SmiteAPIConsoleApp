namespace WindowsFormsApplication1
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
            this.buttonCreateSession = new System.Windows.Forms.Button();
            this.buttonGetGods = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCreateSession
            // 
            this.buttonCreateSession.Location = new System.Drawing.Point(280, 168);
            this.buttonCreateSession.Name = "buttonCreateSession";
            this.buttonCreateSession.Size = new System.Drawing.Size(205, 23);
            this.buttonCreateSession.TabIndex = 1;
            this.buttonCreateSession.Text = "Create Session\r\n";
            this.buttonCreateSession.UseVisualStyleBackColor = true;
            this.buttonCreateSession.Click += new System.EventHandler(this.buttonCreateSession_Click);
            // 
            // buttonGetGods
            // 
            this.buttonGetGods.Location = new System.Drawing.Point(280, 211);
            this.buttonGetGods.Name = "buttonGetGods";
            this.buttonGetGods.Size = new System.Drawing.Size(205, 23);
            this.buttonGetGods.TabIndex = 2;
            this.buttonGetGods.Text = "Call GetGods() API Method\r\n";
            this.buttonGetGods.UseVisualStyleBackColor = true;
            this.buttonGetGods.Click += new System.EventHandler(this.buttonGetGods_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Step 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Step 2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 414);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGetGods);
            this.Controls.Add(this.buttonCreateSession);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateSession;
        private System.Windows.Forms.Button buttonGetGods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
