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

        Button Plus, Minus, Divide, Multiply, Equal, Dot, Clear;
        Label resultLbl, bufferLbl;

        Button[] keypad;

        double buffer = 0.0;
        double result = 0.0;

        #region Methodes Public

        public double Buffer
        {
            get
            {
                return buffer;
            }
            set
            {
                buffer = value;
                bufferLbl.Text = buffer.ToString();
            }
        }
        public double Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                resultLbl.Text = result.ToString();
            }
        }

        #endregion

        #endregion

        #region Init


        private void InitComponent()
        {
            resultLbl = new Label();
            bufferLbl = new Label();
            Plus = new Button() { Text = "+" };
            Minus = new Button() { Text = "-" };
            Divide = new Button() { Text = "/" };
            Multiply = new Button() { Text = "*" };
            Clear = new Button() { Text = "C" };
            Equal = new Button() { Text = "=" };
            Dot = new Button() { Text = "." };

            resultLbl.VerticalTextAlignment = TextAlignment.End;
            resultLbl.HorizontalTextAlignment = TextAlignment.End;
            resultLbl.HorizontalOptions = new LayoutOptions(LayoutAlignment.Fill, true);
            resultLbl.VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true);
            resultLbl.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));

            bufferLbl.VerticalTextAlignment = TextAlignment.End;
            bufferLbl.HorizontalTextAlignment = TextAlignment.End;
            bufferLbl.HorizontalOptions = new LayoutOptions(LayoutAlignment.Fill, true);
            bufferLbl.VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true);

            Plus.Pressed += Plus_Pressed;
            Minus.Pressed += Minus_Pressed;
            Divide.Pressed += Divide_Pressed;
            Multiply.Pressed += Multiply_Pressed;
            Clear.Pressed += Clear_Pressed;

            //KeyPad Buttons
            keypad = new Button[10];

            for( var index = 0; index < keypad.Count(); ++ index)
            {
                ref var button = ref keypad[index];
                button = new Button() { Text = index.ToString() };
                int i = index;
                button.Pressed += (o, e) => { KeypadButton_Pressed(i); };
            }

            #region Creation et insertion des composante dans le Grid
            // grid
            int[] index_remap = new int[] { 0, 3, 2, 1, 6, 5, 4, 9, 8, 7 };
            var grid = new rMultiplatform.AutoGrid();
            //var Headergrid = new rMultiplatform.AutoGrid();
            //Headergrid.DefineGrid(4, 6);
            grid.DefineGrid(4, 6);

            grid.AutoAdd(bufferLbl);
            grid.AutoAdd(resultLbl,2);
            grid.AutoAdd(Clear);
            grid.AutoAdd(keypad[1]);
            grid.AutoAdd(keypad[2]);
            grid.AutoAdd(keypad[3]);
            grid.AutoAdd(Plus);
            grid.AutoAdd(keypad[4]);
            grid.AutoAdd(keypad[5]);
            grid.AutoAdd(keypad[6]);
            grid.AutoAdd(Minus);
            grid.AutoAdd(keypad[7]);
            grid.AutoAdd(keypad[8]);
            grid.AutoAdd(keypad[9]);
            grid.AutoAdd(Multiply);
            grid.AutoAdd(Dot);
            grid.AutoAdd(keypad[0]);
            grid.AutoAdd(Equal);
            grid.AutoAdd(Divide);

            //for (var index = keypad.Count()-1; index >=0; --index)
            //{                
            //    ref var button = ref keypad[index_remap[index]];
            //    if (index != 0)
            //        grid.AutoAdd(button);
            //    else
            //        grid.AutoAdd(button, 2);
            //}

            //afficher la grid

            Content = grid;
            #endregion
        }



        public MainPage()
        {
            InitializeComponent();

            InitComponent();
        }
        #endregion

        #region Operation Button

        private void Clear_Pressed(object sender, EventArgs e)
        {
            Buffer = 0.0;
            Result = 0.0;
        }
        private void KeypadButton_Pressed(int index)
        {
            Buffer *= 10.0;
            Buffer += (double)index;

           // double value = index;
        }

        private void Multiply_Pressed(object sender, EventArgs e)
        {
            Result *= buffer;
            Buffer = 0.0;
        }

        private void Divide_Pressed(object sender, EventArgs e)
        {
            Result /= buffer;
            Buffer = 0.0;
        }

        private void Minus_Pressed(object sender, EventArgs e)
        {
            Result -= buffer;
            Buffer = 0.0;
        }

        private void Plus_Pressed(object sender, EventArgs e)
        {
            Result += buffer;
            Buffer = 0.0;
        }
        #endregion
    }
}
