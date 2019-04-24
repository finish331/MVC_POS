using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewNumericUpDownElements;

namespace POS
{
    public partial class POSCustomerSideForm : Form
    {
        const char WRAP = '\n';
        const char MONEY_SYMBOL = '$';
        const char MONEY_UNIT = '元';
        const char SLASH = '/';
        const string MONEY_TOTAL = "Total:";
        const string PAGE = "Page:";
        const string DELETE_COLUMN = "_deleteColumn";
        const string ENABLED = "Enabled";
        const string TEXT = "Text";
        const int BUTTON_WIDTH = 130;
        const int BUTTON_HEIGHT = 130;
        const int TWO = 2;
        const int BUTTON_SIZE = 9;
        int _chooseFoodIndex = -1;
        string _projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        Model _model;
        Button[] _buttons = new Button[BUTTON_SIZE];
        CustomerPresentationModel _presentationModel;
        DataGridViewButtonColumn _deleteColumn = new DataGridViewButtonColumn();
        List<TabPage> _allTabPage = new List<TabPage>();

        public POSCustomerSideForm(Model model)
        {
            _model = model;
            InitializeComponent();
            InitializeTabPage();//要先初始化Page下面有使用到Page的部分才不會有誤
            _presentationModel = new CustomerPresentationModel(model);
            _model.StoreMeal(_categoryControl.SelectedTab.Text);
            _presentationModel.ChangeTotalPage();
            InitializeButton();
            _add.DataBindings.Add(ENABLED, _presentationModel, "IsAddEnable");
            _pageNumber.DataBindings.Add(TEXT, _presentationModel, "GetPageText");
            _nextPage.DataBindings.Add(ENABLED, _presentationModel, "IsNextPageEnable");
            _previousPage.DataBindings.Add(ENABLED, _presentationModel, "IsPreviousPageEnable");
            _total.DataBindings.Add(TEXT, _presentationModel, "TotalPrice");
            _orderMealView.DataSource = _model.OrderList;
            _deleteColumn.HeaderText = "Delete";
            _deleteColumn.Name = DELETE_COLUMN;
            _deleteColumn.Text = "X";
            _deleteColumn.UseColumnTextForButtonValue = true;
            _deleteColumn.DisplayIndex = 0;
            _deleteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _orderMealView.Columns.Add(_deleteColumn);
            _orderMealView.CellValueChanged += new DataGridViewCellEventHandler(ChangeValue);
            _model._modelChanged += UpdateData;
            FormClosed += new FormClosedEventHandler(CloseForm);
        }

        //初始化Button
        public void InitializeButton()
        {
            int[] point = new int[TWO];//point座標為X及Y座標
            Meal meal = new Meal();
            for (int i = 0; i < _buttons.Length; ++i)
            {
                try
                {
                    _buttons[i] = new Button();
                    _buttons[i].Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
                    meal = _model.GetTabPageMealList[i];
                    _buttons[i].Text = meal.Name + WRAP + MONEY_SYMBOL + (meal.Price).ToString() + MONEY_UNIT;
                    _buttons[i].ForeColor = Color.White;
                    _buttons[i].TextAlign = ContentAlignment.BottomLeft;
                    _buttons[i].TabIndex = i;
                    _buttons[i].Click += new EventHandler(ButtonClick);
                    _buttons[i].BackgroundImage = Image.FromFile(_projectPath + meal.ImagePath);
                    _buttons[i].BackgroundImageLayout = ImageLayout.Stretch;
                    point = _model.CalculatePoint(i);
                    _buttons[i].Location = new Point(point[0], point[1]);
                    this.Controls.Add(_buttons[i]);
                    _categoryControl.SelectedTab.Controls.Add(_buttons[i]);
                }
                catch
                {
                }
            }
        }

        //初始化TabPage
        public void InitializeTabPage()
        {
            _categoryControl.TabPages.Clear();
            for (int i = 0; i < _model.CategoryList.Count; i++)
            {
                TabPage tabPage = new TabPage();
                tabPage.Text = _model.CategoryList[i].CategoryName;
                tabPage.TabIndex = i;
                _categoryControl.Controls.Add(tabPage);
            }
        }

        //關閉視窗
        public void CloseForm(object sender, FormClosedEventArgs e)
        {
            _model.CloseCustomer();
        }

        //更新畫面資料
        public void UpdateData()
        {
            InitializeTabPage();
            _model.StoreMeal(_categoryControl.SelectedTab.Text);
            _presentationModel.ChangeTotalPage();
            SetButtonText();
            _presentationModel.TotalPrice = _model.GetPrice().ToString();
        }

        //當DataGridView裡面的值有改變時，會再次去計算總價錢
        private void ChangeValue(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.TotalPrice = (_model.GetPrice()).ToString();
        }

        private BindingManagerBase BindingManager
        {
            get
            {
                return BindingContext[_model.OrderList];
            }
        }

        //下一頁的按鈕
        private void ClickNextPage(object sender, EventArgs e)
        {
            _presentationModel.ClickNextPage();
            ChangePage();
        }

        //上一頁的按鈕
        private void ClickPreviousPage(object sender, EventArgs e)
        {
            _presentationModel.ClickPreviousPage();
            ChangePage();
        }

        //換頁時，重新設定Button及按鈕的狀態
        private void ChangePage()
        {
            SetButtonText();
            _chooseFoodIndex = -1;
            _displayMealDescribe.Text = "";
        }

        //換頁時觸發
        private void ChangeTabPage()
        {
            if (_categoryControl.TabPages.Count > 0)
            {
                _model.StoreMeal(_categoryControl.SelectedTab.Text);
            }
            _presentationModel.ChangeTotalPage();
            _presentationModel.ChangeTabPage();
            SetButtonText();
            _displayMealDescribe.Text = "";
        }

        //設置每次換頁button的Text
        private void SetButtonText()
        {
            Meal meal = new Meal();
            for (int i = 0; i < _buttons.Length; i++)
            {
                try
                {
                    int temp = _presentationModel.DetectWhichButton(i, _buttons.Length);
                    meal = _model.GetTabPageMealList[temp];
                    _buttons[i].Text = meal.Name + WRAP + MONEY_SYMBOL + (meal.Price).ToString() + MONEY_UNIT;
                    _buttons[i].BackgroundImage = Image.FromFile(_projectPath + meal.ImagePath);
                    _buttons[i].BackgroundImageLayout = ImageLayout.Stretch;
                    _buttons[i].Visible = true;
                    this._categoryControl.SelectedTab.Controls.Add(_buttons[i]);
                }
                catch
                {
                    _buttons[i].Visible = false;
                }
            }
        }

        //所有餐點的button被點到時所觸發的事件
        private void ButtonClick(object sender, EventArgs e)
        {
            _chooseFoodIndex = _presentationModel.DetectWhichButton(((Button)(sender)).TabIndex, _buttons.Length);
            _displayMealDescribe.Text = _model.GetTabPageMealList[_chooseFoodIndex].Describe;
            _presentationModel.ClickButton();
            _add.Enabled = _presentationModel.IsAddEnable;
        }

        //當按下add button時的事件
        private void AddClick(object sender, EventArgs e)
        {
            Meal meal = new Meal();
            try
            {
                meal = _model.GetTabPageMealList[_chooseFoodIndex];
                _model.AddMealToOrder(meal.Name,meal.Category,meal.Price,1, meal.Price);
                _presentationModel.TotalPrice = (_model.GetPrice()).ToString();
            }
            catch
            {
                
            }
        }

        //當dataGridView中的Delete Button被點到則刪除餐點
        private void ClickCellContentDataGridView1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && _orderMealView.Columns[e.ColumnIndex].Name == DELETE_COLUMN)
            {
                _orderMealView.Rows.RemoveAt(e.RowIndex);
     
                _presentationModel.TotalPrice = (_model.GetPrice()).ToString();
            }
        }

        //TabControl的換頁事件，當切換到不同的TabPage要重新設定餐點及按鈕狀態
        private void ChangeCategoryControlSelectIndex(object sender, EventArgs e)
        {
            ChangeTabPage();
        }
    }
}
