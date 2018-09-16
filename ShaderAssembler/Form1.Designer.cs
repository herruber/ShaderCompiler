namespace ShaderAssembler
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
            this.pickShader = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.txt_Visual = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // pickShader
            // 
            this.pickShader.Location = new System.Drawing.Point(12, 12);
            this.pickShader.Name = "pickShader";
            this.pickShader.Size = new System.Drawing.Size(153, 59);
            this.pickShader.TabIndex = 0;
            this.pickShader.Text = "Pick Shader..";
            this.pickShader.UseVisualStyleBackColor = true;
            this.pickShader.Click += new System.EventHandler(this.pickShader_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(12, 93);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(156, 59);
            this.save.TabIndex = 1;
            this.save.Text = "Save..";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // txt_Visual
            // 
            this.txt_Visual.Location = new System.Drawing.Point(257, 12);
            this.txt_Visual.Name = "txt_Visual";
            this.txt_Visual.Size = new System.Drawing.Size(744, 492);
            this.txt_Visual.TabIndex = 2;
            this.txt_Visual.Text = "";
            this.txt_Visual.TextChanged += new System.EventHandler(this.txt_Visual_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 516);
            this.Controls.Add(this.txt_Visual);
            this.Controls.Add(this.save);
            this.Controls.Add(this.pickShader);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pickShader;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.RichTextBox txt_Visual;
    }
}

