namespace POS
{
    partial class StartUpForm
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
            this._buttonToCustomer = new System.Windows.Forms.Button();
            this._buttonToRestaurant = new System.Windows.Forms.Button();
            this._exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _buttonToCustomer
            // 
            this._buttonToCustomer.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._buttonToCustomer.Location = new System.Drawing.Point(31, 13);
            this._buttonToCustomer.Name = "_buttonToCustomer";
            this._buttonToCustomer.Size = new System.Drawing.Size(732, 109);
            this._buttonToCustomer.TabIndex = 0;
            this._buttonToCustomer.Text = "Start the Customer Program(Frontend)";
            this._buttonToCustomer.UseVisualStyleBackColor = true;
            this._buttonToCustomer.Click += new System.EventHandler(this.ClickButtonToCustomer);
            // 
            // _buttonToRestaurant
            // 
            this._buttonToRestaurant.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._buttonToRestaurant.Location = new System.Drawing.Point(31, 146);
            this._buttonToRestaurant.Name = "_buttonToRestaurant";
            this._buttonToRestaurant.Size = new System.Drawing.Size(732, 109);
            this._buttonToRestaurant.TabIndex = 1;
            this._buttonToRestaurant.Text = "Start the Restuarant Program(Backend)";
            this._buttonToRestaurant.UseVisualStyleBackColor = true;
            this._buttonToRestaurant.Click += new System.EventHandler(this.ClickButtonToRestaurant);
            // 
            // _exit
            // 
            this._exit.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._exit.Location = new System.Drawing.Point(554, 281);
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(209, 81);
            this._exit.TabIndex = 2;
            this._exit.Text = "Exit";
            this._exit.UseVisualStyleBackColor = true;
            this._exit.Click += new System.EventHandler(this.ClickExit);
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 385);
            this.Controls.Add(this._exit);
            this.Controls.Add(this._buttonToRestaurant);
            this.Controls.Add(this._buttonToCustomer);
            this.Name = "StartUpForm";
            this.Text = "StartUpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonToCustomer;
        private System.Windows.Forms.Button _buttonToRestaurant;
        private System.Windows.Forms.Button _exit;
    }
}