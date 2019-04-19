namespace FisrtDemo
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
            this.my_button = new System.Windows.Forms.Button();
            this.my_label = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // my_button
            // 
            this.my_button.Location = new System.Drawing.Point(217, 355);
            this.my_button.Name = "my_button";
            this.my_button.Size = new System.Drawing.Size(240, 83);
            this.my_button.TabIndex = 0;
            this.my_button.Text = "button1";
            this.my_button.UseVisualStyleBackColor = true;
            this.my_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // my_label
            // 
            this.my_label.AutoSize = true;
            this.my_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.my_label.Location = new System.Drawing.Point(223, 183);
            this.my_label.Name = "my_label";
            this.my_label.Size = new System.Drawing.Size(122, 44);
            this.my_label.TabIndex = 1;
            this.my_label.Text = "label1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(500, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 83);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(217, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(432, 50);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 813);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.my_label);
            this.Controls.Add(this.my_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button my_button;
        private System.Windows.Forms.Label my_label;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

