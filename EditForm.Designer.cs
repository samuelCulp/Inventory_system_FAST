namespace Inventory_system
{
    partial class EditForm
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
            this.ItemName = new System.Windows.Forms.Label();
            this.QTYLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.QTYBox = new System.Windows.Forms.TextBox();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ItemName
            // 
            this.ItemName.AutoSize = true;
            this.ItemName.Location = new System.Drawing.Point(89, 56);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(35, 13);
            this.ItemName.TabIndex = 0;
            this.ItemName.Text = "label1";
            this.ItemName.Click += new System.EventHandler(this.ItemName_Click);
            // 
            // QTYLabel
            // 
            this.QTYLabel.AutoSize = true;
            this.QTYLabel.Location = new System.Drawing.Point(89, 96);
            this.QTYLabel.Name = "QTYLabel";
            this.QTYLabel.Size = new System.Drawing.Size(35, 13);
            this.QTYLabel.TabIndex = 1;
            this.QTYLabel.Text = "label1";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(95, 128);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(13, 13);
            this.PriceLabel.TabIndex = 2;
            this.PriceLabel.Text = "$";
            this.PriceLabel.Click += new System.EventHandler(this.PriceLabel_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(124, 49);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 20);
            this.NameBox.TabIndex = 3;
            this.NameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // QTYBox
            // 
            this.QTYBox.Location = new System.Drawing.Point(124, 89);
            this.QTYBox.Name = "QTYBox";
            this.QTYBox.Size = new System.Drawing.Size(100, 20);
            this.QTYBox.TabIndex = 4;
            // 
            // PriceBox
            // 
            this.PriceBox.Location = new System.Drawing.Point(124, 121);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(100, 20);
            this.PriceBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(92, 165);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 8;
            this.DeleteBtn.Text = "Delete Item";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 229);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PriceBox);
            this.Controls.Add(this.QTYBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.QTYLabel);
            this.Controls.Add(this.ItemName);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ItemName;
        private System.Windows.Forms.Label QTYLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox QTYBox;
        private System.Windows.Forms.TextBox PriceBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button DeleteBtn;
    }
}