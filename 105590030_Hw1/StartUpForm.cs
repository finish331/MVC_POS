using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class StartUpForm : Form
    {
        Model _model;
        public StartUpForm(Model model)
        {
            this._model = model;
            InitializeComponent();
            _model._customerClosed += CloseCustomer;
            _model._restaurantClosed += CloseRestaurant;
        }

        //點選Customer Button時，產生Form
        private void ClickButtonToCustomer(object sender, EventArgs e)
        {
            POSCustomerSideForm customerSideForm = new POSCustomerSideForm(this._model);
            customerSideForm.Show();
            DetectEnable(_buttonToCustomer,false);
        }

        //當Customer Form被關閉時，改變按鈕狀態為true
        private void CloseCustomer()
        {
            DetectEnable(_buttonToCustomer, true);
        }

        //點選Restaurant按鈕時，開啟Form
        private void ClickButtonToRestaurant(object sender, EventArgs e)
        {
            POSRestaurantSideForm restaurant = new POSRestaurantSideForm(this._model);
            restaurant.Show();
            DetectEnable(_buttonToRestaurant, false);
        }

        //Restaurant Form被關閉時，將其按鈕狀態改為true
        private void CloseRestaurant()
        {
            DetectEnable(_buttonToRestaurant, true);
        }

        //當Exit鍵被按下時結束程式
        private void ClickExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //改變傳進來的按鈕狀態為_judgment
        private void DetectEnable(Button button, Boolean state)
        {
            button.Enabled = state;
        }
    }
}
