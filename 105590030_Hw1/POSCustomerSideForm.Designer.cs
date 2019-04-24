using DataGridViewNumericUpDownElements;

namespace POS
{
    partial class POSCustomerSideForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._firstMeal = new System.Windows.Forms.GroupBox();
            this._categoryControl = new System.Windows.Forms.TabControl();
            this._orderMealView = new System.Windows.Forms.DataGridView();
            this._nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._categoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._unitPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._quantityColumn = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this._subtotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._orderListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._total = new System.Windows.Forms.Label();
            this._pageNumber = new System.Windows.Forms.Label();
            this._previousPage = new System.Windows.Forms.Button();
            this._nextPage = new System.Windows.Forms.Button();
            this._add = new System.Windows.Forms.Button();
            this._displayMealDescribe = new System.Windows.Forms.RichTextBox();
            this._firstMeal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._orderMealView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._orderListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._modelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _firstMeal
            // 
            this._firstMeal.Controls.Add(this._categoryControl);
            this._firstMeal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._firstMeal.Location = new System.Drawing.Point(7, -2);
            this._firstMeal.Name = "_firstMeal";
            this._firstMeal.Size = new System.Drawing.Size(558, 573);
            this._firstMeal.TabIndex = 0;
            this._firstMeal.TabStop = false;
            this._firstMeal.Text = "Meals";
            // 
            // _categoryControl
            // 
            this._categoryControl.Location = new System.Drawing.Point(4, 21);
            this._categoryControl.Name = "_categoryControl";
            this._categoryControl.SelectedIndex = 0;
            this._categoryControl.Size = new System.Drawing.Size(550, 560);
            this._categoryControl.TabIndex = 0;
            this._categoryControl.SelectedIndexChanged += new System.EventHandler(this.ChangeCategoryControlSelectIndex);
            // 
            // _orderMealView
            // 
            this._orderMealView.AllowUserToAddRows = false;
            this._orderMealView.AutoGenerateColumns = false;
            this._orderMealView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._orderMealView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._nameColumn,
            this._categoryColumn,
            this._unitPriceColumn,
            this._quantityColumn,
            this._subtotalColumn});
            this._orderMealView.DataSource = this._orderListBindingSource;
            this._orderMealView.Location = new System.Drawing.Point(571, 12);
            this._orderMealView.Name = "_orderMealView";
            this._orderMealView.RowHeadersVisible = false;
            this._orderMealView.RowTemplate.Height = 27;
            this._orderMealView.Size = new System.Drawing.Size(451, 559);
            this._orderMealView.TabIndex = 1;
            this._orderMealView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickCellContentDataGridView1);
            // 
            // _nameColumn
            // 
            this._nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._nameColumn.DataPropertyName = "Name";
            this._nameColumn.HeaderText = "Name";
            this._nameColumn.Name = "_nameColumn";
            this._nameColumn.Width = 69;
            // 
            // _categoryColumn
            // 
            this._categoryColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._categoryColumn.DataPropertyName = "Category";
            this._categoryColumn.HeaderText = "Category";
            this._categoryColumn.Name = "_categoryColumn";
            // 
            // _unitPriceColumn
            // 
            this._unitPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._unitPriceColumn.DataPropertyName = "UnitPrice";
            this._unitPriceColumn.HeaderText = "UnitPrice";
            this._unitPriceColumn.Name = "_unitPriceColumn";
            // 
            // _quantityColumn
            // 
            this._quantityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._quantityColumn.DataPropertyName = "Quantity";
            this._quantityColumn.HeaderText = "Quantity";
            this._quantityColumn.Name = "_quantityColumn";
            this._quantityColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._quantityColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _subtotalColumn
            // 
            this._subtotalColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._subtotalColumn.DataPropertyName = "SubTotal";
            this._subtotalColumn.HeaderText = "SubTotal";
            this._subtotalColumn.Name = "_subtotalColumn";
            // 
            // _orderListBindingSource
            // 
            this._orderListBindingSource.DataMember = "OrderList";
            this._orderListBindingSource.DataSource = this._modelBindingSource;
            // 
            // _modelBindingSource
            // 
            this._modelBindingSource.DataSource = typeof(POS.Model);
            // 
            // _total
            // 
            this._total.AutoSize = true;
            this._total.Font = new System.Drawing.Font("新細明體", 25F);
            this._total.ForeColor = System.Drawing.Color.Red;
            this._total.Location = new System.Drawing.Point(775, 695);
            this._total.Name = "_total";
            this._total.Size = new System.Drawing.Size(175, 42);
            this._total.TabIndex = 13;
            this._total.Text = "Total:0元";
            // 
            // _pageNumber
            // 
            this._pageNumber.AutoSize = true;
            this._pageNumber.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._pageNumber.ForeColor = System.Drawing.Color.Blue;
            this._pageNumber.Location = new System.Drawing.Point(12, 719);
            this._pageNumber.Name = "_pageNumber";
            this._pageNumber.Size = new System.Drawing.Size(117, 31);
            this._pageNumber.TabIndex = 12;
            this._pageNumber.Text = "Page:1/2";
            // 
            // _previousPage
            // 
            this._previousPage.Enabled = false;
            this._previousPage.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this._previousPage.Location = new System.Drawing.Point(232, 719);
            this._previousPage.Name = "_previousPage";
            this._previousPage.Size = new System.Drawing.Size(160, 34);
            this._previousPage.TabIndex = 11;
            this._previousPage.Text = "Previous page";
            this._previousPage.UseVisualStyleBackColor = true;
            this._previousPage.Click += new System.EventHandler(this.ClickPreviousPage);
            // 
            // _nextPage
            // 
            this._nextPage.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this._nextPage.Location = new System.Drawing.Point(398, 719);
            this._nextPage.Name = "_nextPage";
            this._nextPage.Size = new System.Drawing.Size(160, 34);
            this._nextPage.TabIndex = 10;
            this._nextPage.Text = "Next page";
            this._nextPage.UseVisualStyleBackColor = true;
            this._nextPage.Click += new System.EventHandler(this.ClickNextPage);
            // 
            // _add
            // 
            this._add.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this._add.Location = new System.Drawing.Point(424, 679);
            this._add.Name = "_add";
            this._add.Size = new System.Drawing.Size(134, 34);
            this._add.TabIndex = 9;
            this._add.Text = "Add";
            this._add.UseVisualStyleBackColor = true;
            this._add.Click += new System.EventHandler(this.AddClick);
            // 
            // _displayMealDescribe
            // 
            this._displayMealDescribe.Enabled = false;
            this._displayMealDescribe.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._displayMealDescribe.Location = new System.Drawing.Point(14, 577);
            this._displayMealDescribe.Name = "_displayMealDescribe";
            this._displayMealDescribe.Size = new System.Drawing.Size(546, 96);
            this._displayMealDescribe.TabIndex = 13;
            this._displayMealDescribe.Text = "";
            // 
            // POSCustomerSideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 759);
            this.Controls.Add(this._pageNumber);
            this.Controls.Add(this._total);
            this.Controls.Add(this._displayMealDescribe);
            this.Controls.Add(this._previousPage);
            this.Controls.Add(this._orderMealView);
            this.Controls.Add(this._nextPage);
            this.Controls.Add(this._firstMeal);
            this.Controls.Add(this._add);
            this.Name = "POSCustomerSideForm";
            this.Text = "POS-CustomerSide";
            this._firstMeal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._orderMealView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._orderListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._modelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _firstMeal;
        private System.Windows.Forms.DataGridView _orderMealView;
        private System.Windows.Forms.Label _total;
        private System.Windows.Forms.Label _pageNumber;
        private System.Windows.Forms.Button _previousPage;
        private System.Windows.Forms.Button _nextPage;
        private System.Windows.Forms.Button _add;
        private System.Windows.Forms.RichTextBox _displayMealDescribe;
        private System.Windows.Forms.BindingSource _modelBindingSource;
        private System.Windows.Forms.BindingSource _orderListBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _categoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _unitPriceColumn;
        private DataGridViewNumericUpDownColumn _quantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _subtotalColumn;
        private System.Windows.Forms.TabControl _categoryControl;
    }
}

