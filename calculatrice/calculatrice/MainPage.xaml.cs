using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculatrice
{
    public partial class MainPage : ContentPage
    {
        #region Declaration

        Button Plus, Minus, Divide, Multiply, Equal, Enter;

        Button[] keypad;

        #endregion

        #region Init

        private void InitComponent()
        {
            Plus = new Button() { Text = "Plus" };
            Minus = new Button() { Text = "Minus" };
            Divide = new Button() { Text = "Divide" };
            Multiply = new Button() { Text = "Multiply" };
            Enter = new Button() { Text = "Enter" };
        }
        public MainPage()
        {
            InitializeComponent();
        }
        #endregion

        #region

        #endregion
    }
}
