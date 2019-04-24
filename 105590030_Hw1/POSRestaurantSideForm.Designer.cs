namespace POS
{
    partial class POSRestaurantSideForm
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
            this._restaurantTabControl = new System.Windows.Forms.TabControl();
            this._tabPage1 = new System.Windows.Forms.TabPage();
            this._save = new System.Windows.Forms.Button();
            this._mealGroupBox = new System.Windows.Forms.GroupBox();
            this._mealDescribeTextBox = new System.Windows.Forms.TextBox();
            this._label6 = new System.Windows.Forms.Label();
            this._browse = new System.Windows.Forms.Button();
            this._mealImageTextBox = new System.Windows.Forms.TextBox();
            this._label5 = new System.Windows.Forms.Label();
            this._categoryComboBox = new System.Windows.Forms.ComboBox();
            this._label4 = new System.Windows.Forms.Label();
            this._label3 = new System.Windows.Forms.Label();
            this._mealPriceTextBox = new System.Windows.Forms.TextBox();
            this._label2 = new System.Windows.Forms.Label();
            this._mealNameTextBox = new System.Windows.Forms.TextBox();
            this._label1 = new System.Windows.Forms.Label();
            this._deleteMeal = new System.Windows.Forms.Button();
            this._addMeal = new System.Windows.Forms.Button();
            this._mealListBox = new System.Windows.Forms.ListBox();
            this._tabPage2 = new System.Windows.Forms.TabPage();
            this._saveCategory = new System.Windows.Forms.Button();
            this._deleteCategory = new System.Windows.Forms.Button();
            this._addCategory = new System.Windows.Forms.Button();
            this._categoryGroupBox = new System.Windows.Forms.GroupBox();
            this._categoryMeal = new System.Windows.Forms.ListBox();
            this._label11 = new System.Windows.Forms.Label();
            this._categoryTextBox = new System.Windows.Forms.TextBox();
            this._categoryText = new System.Windows.Forms.Label();
            this._categoryListBox = new System.Windows.Forms.ListBox();
            this._restaurantTabControl.SuspendLayout();
            this._tabPage1.SuspendLayout();
            this._mealGroupBox.SuspendLayout();
            this._tabPage2.SuspendLayout();
            this._categoryGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _restaurantTabControl
            // 
            this._restaurantTabControl.Controls.Add(this._tabPage1);
            this._restaurantTabControl.Controls.Add(this._tabPage2);
            this._restaurantTabControl.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._restaurantTabControl.Location = new System.Drawing.Point(6, 12);
            this._restaurantTabControl.Name = "_restaurantTabControl";
            this._restaurantTabControl.SelectedIndex = 0;
            this._restaurantTabControl.Size = new System.Drawing.Size(1022, 578);
            this._restaurantTabControl.TabIndex = 0;
            // 
            // _tabPage1
            // 
            this._tabPage1.Controls.Add(this._save);
            this._tabPage1.Controls.Add(this._mealGroupBox);
            this._tabPage1.Controls.Add(this._deleteMeal);
            this._tabPage1.Controls.Add(this._addMeal);
            this._tabPage1.Controls.Add(this._mealListBox);
            this._tabPage1.Location = new System.Drawing.Point(4, 30);
            this._tabPage1.Name = "_tabPage1";
            this._tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage1.Size = new System.Drawing.Size(1014, 544);
            this._tabPage1.TabIndex = 0;
            this._tabPage1.Text = "Meal Manager";
            this._tabPage1.UseVisualStyleBackColor = true;
            // 
            // _save
            // 
            this._save.Location = new System.Drawing.Point(858, 478);
            this._save.Name = "_save";
            this._save.Size = new System.Drawing.Size(135, 31);
            this._save.TabIndex = 4;
            this._save.Text = "Save";
            this._save.UseVisualStyleBackColor = true;
            this._save.Click += new System.EventHandler(this.ClickSave);
            // 
            // _mealGroupBox
            // 
            this._mealGroupBox.Controls.Add(this._mealDescribeTextBox);
            this._mealGroupBox.Controls.Add(this._label6);
            this._mealGroupBox.Controls.Add(this._browse);
            this._mealGroupBox.Controls.Add(this._mealImageTextBox);
            this._mealGroupBox.Controls.Add(this._label5);
            this._mealGroupBox.Controls.Add(this._categoryComboBox);
            this._mealGroupBox.Controls.Add(this._label4);
            this._mealGroupBox.Controls.Add(this._label3);
            this._mealGroupBox.Controls.Add(this._mealPriceTextBox);
            this._mealGroupBox.Controls.Add(this._label2);
            this._mealGroupBox.Controls.Add(this._mealNameTextBox);
            this._mealGroupBox.Controls.Add(this._label1);
            this._mealGroupBox.Location = new System.Drawing.Point(340, 6);
            this._mealGroupBox.Name = "_mealGroupBox";
            this._mealGroupBox.Size = new System.Drawing.Size(668, 444);
            this._mealGroupBox.TabIndex = 3;
            this._mealGroupBox.TabStop = false;
            this._mealGroupBox.Text = "Edit Meal";
            // 
            // _mealDescribeTextBox
            // 
            this._mealDescribeTextBox.Location = new System.Drawing.Point(10, 281);
            this._mealDescribeTextBox.Multiline = true;
            this._mealDescribeTextBox.Name = "_mealDescribeTextBox";
            this._mealDescribeTextBox.Size = new System.Drawing.Size(643, 157);
            this._mealDescribeTextBox.TabIndex = 11;
            // 
            // _label6
            // 
            this._label6.AutoSize = true;
            this._label6.Location = new System.Drawing.Point(6, 248);
            this._label6.Name = "_label6";
            this._label6.Size = new System.Drawing.Size(142, 20);
            this._label6.TabIndex = 10;
            this._label6.Text = "Meal Descripition";
            // 
            // _browse
            // 
            this._browse.Location = new System.Drawing.Point(565, 171);
            this._browse.Name = "_browse";
            this._browse.Size = new System.Drawing.Size(88, 32);
            this._browse.TabIndex = 9;
            this._browse.Text = "Browse...";
            this._browse.UseVisualStyleBackColor = true;
            this._browse.Click += new System.EventHandler(this.ClickBrowse);
            // 
            // _mealImageTextBox
            // 
            this._mealImageTextBox.Location = new System.Drawing.Point(272, 172);
            this._mealImageTextBox.Name = "_mealImageTextBox";
            this._mealImageTextBox.Size = new System.Drawing.Size(287, 31);
            this._mealImageTextBox.TabIndex = 8;
            // 
            // _label5
            // 
            this._label5.AutoSize = true;
            this._label5.Location = new System.Drawing.Point(6, 177);
            this._label5.Name = "_label5";
            this._label5.Size = new System.Drawing.Size(227, 20);
            this._label5.TabIndex = 7;
            this._label5.Text = "Meal Image Relative Path (*)";
            // 
            // _categoryComboBox
            // 
            this._categoryComboBox.FormattingEnabled = true;
            this._categoryComboBox.Location = new System.Drawing.Point(532, 105);
            this._categoryComboBox.Name = "_categoryComboBox";
            this._categoryComboBox.Size = new System.Drawing.Size(121, 28);
            this._categoryComboBox.TabIndex = 6;
            this._categoryComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickCategoryComboBox);
            // 
            // _label4
            // 
            this._label4.AutoSize = true;
            this._label4.Location = new System.Drawing.Point(368, 108);
            this._label4.Name = "_label4";
            this._label4.Size = new System.Drawing.Size(145, 20);
            this._label4.TabIndex = 5;
            this._label4.Text = "Meal Category (*)";
            // 
            // _label3
            // 
            this._label3.AutoSize = true;
            this._label3.Location = new System.Drawing.Point(280, 108);
            this._label3.Name = "_label3";
            this._label3.Size = new System.Drawing.Size(48, 20);
            this._label3.TabIndex = 4;
            this._label3.Text = "NTD";
            // 
            // _mealPriceTextBox
            // 
            this._mealPriceTextBox.Location = new System.Drawing.Point(135, 105);
            this._mealPriceTextBox.Name = "_mealPriceTextBox";
            this._mealPriceTextBox.Size = new System.Drawing.Size(139, 31);
            this._mealPriceTextBox.TabIndex = 3;
            // 
            // _label2
            // 
            this._label2.AutoSize = true;
            this._label2.Location = new System.Drawing.Point(6, 108);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(115, 20);
            this._label2.TabIndex = 2;
            this._label2.Text = "Meal Price (*)";
            // 
            // _mealNameTextBox
            // 
            this._mealNameTextBox.Location = new System.Drawing.Point(135, 30);
            this._mealNameTextBox.Name = "_mealNameTextBox";
            this._mealNameTextBox.Size = new System.Drawing.Size(518, 31);
            this._mealNameTextBox.TabIndex = 1;
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Location = new System.Drawing.Point(6, 38);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(123, 20);
            this._label1.TabIndex = 0;
            this._label1.Text = "Meal Name (*)";
            // 
            // _deleteMeal
            // 
            this._deleteMeal.Location = new System.Drawing.Point(185, 478);
            this._deleteMeal.Name = "_deleteMeal";
            this._deleteMeal.Size = new System.Drawing.Size(205, 31);
            this._deleteMeal.TabIndex = 2;
            this._deleteMeal.Text = "Delete Selected Meal";
            this._deleteMeal.UseVisualStyleBackColor = true;
            this._deleteMeal.Click += new System.EventHandler(this.ClickDeleteMeal);
            // 
            // _addMeal
            // 
            this._addMeal.Location = new System.Drawing.Point(7, 478);
            this._addMeal.Name = "_addMeal";
            this._addMeal.Size = new System.Drawing.Size(153, 31);
            this._addMeal.TabIndex = 1;
            this._addMeal.Text = "Add New Meal";
            this._addMeal.UseVisualStyleBackColor = true;
            this._addMeal.Click += new System.EventHandler(this.ClickAddMeal);
            // 
            // _mealListBox
            // 
            this._mealListBox.FormattingEnabled = true;
            this._mealListBox.ItemHeight = 20;
            this._mealListBox.Location = new System.Drawing.Point(6, 6);
            this._mealListBox.Name = "_mealListBox";
            this._mealListBox.Size = new System.Drawing.Size(328, 444);
            this._mealListBox.TabIndex = 0;
            this._mealListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickMealListBox);
            // 
            // _tabPage2
            // 
            this._tabPage2.Controls.Add(this._saveCategory);
            this._tabPage2.Controls.Add(this._deleteCategory);
            this._tabPage2.Controls.Add(this._addCategory);
            this._tabPage2.Controls.Add(this._categoryGroupBox);
            this._tabPage2.Controls.Add(this._categoryListBox);
            this._tabPage2.Location = new System.Drawing.Point(4, 30);
            this._tabPage2.Name = "_tabPage2";
            this._tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage2.Size = new System.Drawing.Size(1014, 544);
            this._tabPage2.TabIndex = 1;
            this._tabPage2.Text = "Category Manager";
            this._tabPage2.UseVisualStyleBackColor = true;
            // 
            // _saveCategory
            // 
            this._saveCategory.Location = new System.Drawing.Point(858, 478);
            this._saveCategory.Name = "_saveCategory";
            this._saveCategory.Size = new System.Drawing.Size(135, 31);
            this._saveCategory.TabIndex = 7;
            this._saveCategory.Text = "Save";
            this._saveCategory.UseVisualStyleBackColor = true;
            this._saveCategory.Click += new System.EventHandler(this.ClickSaveCategory);
            // 
            // _deleteCategory
            // 
            this._deleteCategory.Location = new System.Drawing.Point(185, 478);
            this._deleteCategory.Name = "_deleteCategory";
            this._deleteCategory.Size = new System.Drawing.Size(204, 31);
            this._deleteCategory.TabIndex = 6;
            this._deleteCategory.Text = "Delete Selected Category";
            this._deleteCategory.UseVisualStyleBackColor = true;
            this._deleteCategory.Click += new System.EventHandler(this.ClickDeleteCategory);
            // 
            // _addCategory
            // 
            this._addCategory.Location = new System.Drawing.Point(7, 478);
            this._addCategory.Name = "_addCategory";
            this._addCategory.Size = new System.Drawing.Size(153, 31);
            this._addCategory.TabIndex = 5;
            this._addCategory.Text = "Add Category";
            this._addCategory.UseVisualStyleBackColor = true;
            this._addCategory.Click += new System.EventHandler(this.ClickAddCategory);
            // 
            // _categoryGroupBox
            // 
            this._categoryGroupBox.Controls.Add(this._categoryMeal);
            this._categoryGroupBox.Controls.Add(this._label11);
            this._categoryGroupBox.Controls.Add(this._categoryTextBox);
            this._categoryGroupBox.Controls.Add(this._categoryText);
            this._categoryGroupBox.Location = new System.Drawing.Point(341, 6);
            this._categoryGroupBox.Name = "_categoryGroupBox";
            this._categoryGroupBox.Size = new System.Drawing.Size(667, 444);
            this._categoryGroupBox.TabIndex = 4;
            this._categoryGroupBox.TabStop = false;
            this._categoryGroupBox.Text = "Edit Category";
            // 
            // _categoryMeal
            // 
            this._categoryMeal.FormattingEnabled = true;
            this._categoryMeal.ItemHeight = 20;
            this._categoryMeal.Location = new System.Drawing.Point(10, 154);
            this._categoryMeal.Name = "_categoryMeal";
            this._categoryMeal.Size = new System.Drawing.Size(651, 284);
            this._categoryMeal.TabIndex = 8;
            // 
            // _label11
            // 
            this._label11.AutoSize = true;
            this._label11.Location = new System.Drawing.Point(6, 108);
            this._label11.Name = "_label11";
            this._label11.Size = new System.Drawing.Size(223, 20);
            this._label11.TabIndex = 2;
            this._label11.Text = "Meal(s) Using this Category:";
            // 
            // _categoryTextBox
            // 
            this._categoryTextBox.Location = new System.Drawing.Point(176, 30);
            this._categoryTextBox.Name = "_categoryTextBox";
            this._categoryTextBox.Size = new System.Drawing.Size(456, 31);
            this._categoryTextBox.TabIndex = 1;
            // 
            // _categoryText
            // 
            this._categoryText.AutoSize = true;
            this._categoryText.Location = new System.Drawing.Point(6, 38);
            this._categoryText.Name = "_categoryText";
            this._categoryText.Size = new System.Drawing.Size(152, 20);
            this._categoryText.TabIndex = 0;
            this._categoryText.Text = "Category Name (*)";
            // 
            // _categoryListBox
            // 
            this._categoryListBox.FormattingEnabled = true;
            this._categoryListBox.ItemHeight = 20;
            this._categoryListBox.Location = new System.Drawing.Point(6, 6);
            this._categoryListBox.Name = "_categoryListBox";
            this._categoryListBox.Size = new System.Drawing.Size(329, 444);
            this._categoryListBox.TabIndex = 1;
            this._categoryListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickCategoryListBox);
            // 
            // POSRestaurantSideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 595);
            this.Controls.Add(this._restaurantTabControl);
            this.Name = "POSRestaurantSideForm";
            this.Text = "POS-Restaurant Side";
            this._restaurantTabControl.ResumeLayout(false);
            this._tabPage1.ResumeLayout(false);
            this._mealGroupBox.ResumeLayout(false);
            this._mealGroupBox.PerformLayout();
            this._tabPage2.ResumeLayout(false);
            this._categoryGroupBox.ResumeLayout(false);
            this._categoryGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _restaurantTabControl;
        private System.Windows.Forms.TabPage _tabPage1;
        private System.Windows.Forms.Button _save;
        private System.Windows.Forms.GroupBox _mealGroupBox;
        private System.Windows.Forms.Label _label3;
        private System.Windows.Forms.TextBox _mealPriceTextBox;
        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.TextBox _mealNameTextBox;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.Button _deleteMeal;
        private System.Windows.Forms.Button _addMeal;
        private System.Windows.Forms.ListBox _mealListBox;
        private System.Windows.Forms.TabPage _tabPage2;
        private System.Windows.Forms.TextBox _mealDescribeTextBox;
        private System.Windows.Forms.Label _label6;
        private System.Windows.Forms.Button _browse;
        private System.Windows.Forms.TextBox _mealImageTextBox;
        private System.Windows.Forms.Label _label5;
        private System.Windows.Forms.ComboBox _categoryComboBox;
        private System.Windows.Forms.Label _label4;
        private System.Windows.Forms.Button _saveCategory;
        private System.Windows.Forms.Button _deleteCategory;
        private System.Windows.Forms.Button _addCategory;
        private System.Windows.Forms.GroupBox _categoryGroupBox;
        private System.Windows.Forms.Label _label11;
        private System.Windows.Forms.TextBox _categoryTextBox;
        private System.Windows.Forms.Label _categoryText;
        private System.Windows.Forms.ListBox _categoryListBox;
        private System.Windows.Forms.ListBox _categoryMeal;
    }
}