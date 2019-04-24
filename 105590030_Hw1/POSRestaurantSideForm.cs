using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class POSRestaurantSideForm : Form
    {
        Model _model;
        RestaurantPresentationModel _restaurantPresentationModel;
        private OpenFileDialog _openImageDialog;
        const string TEXT = "Text";
        const string ENABLED = "Enabled";
        const string CATEGORY_NAME = "CategoryName";
        const string SAVE = "Save";
        const string ADD = "Add";
        const string EDIT_MEAL = "Edit Meal";
        const string ADD_MEAL = "Add Meal";
        const string EDIT_CATEGORY = "Edit Category";
        const string ADD_CATEGORY = "Add Category";
            
        public POSRestaurantSideForm(Model model)
        {
            InitializeComponent();
            _model = model;
            _restaurantPresentationModel = new RestaurantPresentationModel(model);
            _mealNameTextBox.DataBindings.Add(TEXT, _restaurantPresentationModel, "MealName");
            _mealPriceTextBox.DataBindings.Add(TEXT, _restaurantPresentationModel, "MealPrice");
            _mealImageTextBox.DataBindings.Add(TEXT, _restaurantPresentationModel, "MealImagePath");
            _mealDescribeTextBox.DataBindings.Add(TEXT, _restaurantPresentationModel, "MealDescribe");
            _categoryComboBox.DataBindings.Add(TEXT, _restaurantPresentationModel, "MealCategory");
            _addMeal.DataBindings.Add(ENABLED, _restaurantPresentationModel, "AddMealButtonEnable");
            _deleteMeal.DataBindings.Add(ENABLED, _restaurantPresentationModel, "DeleteMealButtonEnable");
            _categoryTextBox.DataBindings.Add(TEXT, _restaurantPresentationModel, CATEGORY_NAME);
            _save.DataBindings.Add(ENABLED, _restaurantPresentationModel, "SaveButtonEnable");
            _deleteCategory.DataBindings.Add(ENABLED, _restaurantPresentationModel, "DeleteCategoryEnable");
            _categoryComboBox.DataSource = _model.CategoryList;
            _categoryComboBox.DisplayMember = CATEGORY_NAME;
            _mealListBox.DataSource = _model.GetMealList;
            _mealListBox.DisplayMember = "Name";
            _categoryListBox.DataSource = _model.CategoryList;
            _categoryListBox.DisplayMember = CATEGORY_NAME;
            _categoryMeal.DataSource = _restaurantPresentationModel.CategoryMeal;
            FormClosed += new FormClosedEventHandler(CloseRestaurant);
        }

        //關閉餐廳視窗
        private void CloseRestaurant(object sender, FormClosedEventArgs e)
        {
            _model.CloseRestaurant();
        }

        //管理MealList的Binding
        private BindingManagerBase BindingManager
        {
            get
            {
                return BindingContext[_model.GetMealList];
            }
        }

        //管理CategoryList的Binding
        private BindingManagerBase BindingManagerSecond
        {
            get
            {
                return BindingContext[_model.CategoryList];
            }
        }

        //點選餐點ListBox中的餐點
        private void ClickMealListBox(object sender, MouseEventArgs e)
        {
            _restaurantPresentationModel.SelectMeal(_mealListBox.SelectedIndex);
            _mealGroupBox.Text = EDIT_MEAL;
            _save.Text = SAVE;
        }

        //點選類別ListBox中的餐點
        private void ClickCategoryListBox(object sender, MouseEventArgs e)
        {
            _restaurantPresentationModel.SelectCategory(_categoryListBox.SelectedIndex);
            _categoryGroupBox.Text = EDIT_CATEGORY;
            _saveCategory.Text = SAVE;
        }

        //點選CombBox
        private void ClickCategoryComboBox(object sender, MouseEventArgs e)
        {
            _restaurantPresentationModel.ChangeComboBox(_categoryComboBox.SelectedIndex);
        }

        //點選載入圖片
        private void ClickBrowse(object sender, EventArgs e)
        {
            _openImageDialog = new OpenFileDialog();
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            _openImageDialog.InitialDirectory = projectPath;
            _openImageDialog.Multiselect = false;
            _openImageDialog.Filter = "Image|*.png;*.jpg;*.jpeg";
            DialogResult result = _openImageDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string relativePath = GetRelativePath(projectPath, _openImageDialog.FileName);
                _restaurantPresentationModel.MealImagePath = relativePath.Replace("105590030_Hw1","");
            }
        }

        //得到相對位址
        public string GetRelativePath(string basePath, string targetPath)
        {
            Uri baseUri = new Uri(basePath);
            Uri targetUri = new Uri(targetPath);
            return baseUri.MakeRelativeUri(targetUri).ToString().Replace(@"\", @"/");
        }

        //按下刪除餐點時
        private void ClickDeleteMeal(object sender, EventArgs e)
        {
            _model.GetMealList.RemoveAt(_mealListBox.SelectedIndex);
            _model.Refresh();
        }

        //按下add Meal時，改變groupBox文字
        private void ClickAddMeal(object sender, EventArgs e)
        {
            _mealGroupBox.Text = ADD_MEAL;
            _save.Text = ADD;
            _restaurantPresentationModel.AddMealView();
        }

        //按下儲存時，判斷目前是edit還是add
        private void ClickSave(object sender, EventArgs e)
        {
            _restaurantPresentationModel.SaveMealData(_mealGroupBox.Text, _mealListBox.SelectedIndex);
            _model.Refresh();
        }

        //按下類別中的儲存時，會判斷目前是edit還是add
        private void ClickSaveCategory(object sender, EventArgs e)
        {
            _restaurantPresentationModel.SaveCategoryData(_categoryGroupBox.Text, _categoryListBox.SelectedIndex);
            _model.Refresh();
        }

        //新增類別
        private void ClickAddCategory(object sender, EventArgs e)
        {
            _restaurantPresentationModel.AddCategoryView();
            _categoryGroupBox.Text = ADD_CATEGORY;
            _saveCategory.Text = ADD;
        }

        //刪除類別
        private void ClickDeleteCategory(object sender, EventArgs e)
        {
            _model.DeleteCategoryMeal(_categoryListBox.SelectedIndex);
            _model.CategoryList.RemoveAt(_categoryListBox.SelectedIndex);
            _model.Refresh();
        }
    }
}
