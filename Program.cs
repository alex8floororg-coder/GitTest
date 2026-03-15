using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Form form = new ColorForm(Color.Azure, "Цветная");
            Application.Run(form);
        }

        public class ColorForm : Form
        {
            private bool _mouseOnForm = false;
            private Color _backColor;
            private TextBox _textBox;
            private CheckBox _checkBox;

            public ColorForm(Color backColor, string title)
            {
                _backColor = BackColor;
                BackColor = backColor;
                Text = title;
                Height = 600;
                Width = 800;
                Color _frontColor = Color.AliceBlue;

              
                Button exitButton = CreateButton(new Size(60, 30), new Point(700, 500), "Выход");
                exitButton.Click += (object sender, EventArgs e) => Application.Exit();

                Label label = CreateLabel(new Size(200, 30), new Point(305, 260), "Вы дважды щёлкнули по форме");
                label.Visible = false;
                DoubleClick += (sender, e) => ShowLabel(label);

                // Создаем TextBox
                _textBox = CreateTextBox(new Size(150, 25), new Point(50, 50), "Введите текст");
                _textBox.TextChanged += (sender, e) => UpdateFormTitle();

                // Создаем CheckBox
                _checkBox = CreateCheckBox(new Size(150, 30), new Point(50, 100), "Изменить цвет фона");
                _checkBox.CheckedChanged += (sender, e) => ToggleBackgroundColor();
            }

            private void ShowLabel(Label label)
            {
                if (_mouseOnForm)
                {
                    label.Visible = true;
                }
            }

            private void ChangeFormColor(Color color) => BackColor = color;

            private void UpdateFormTitle()
            {
                if (!string.IsNullOrWhiteSpace(_textBox.Text))
                {
                    Text = $"Введено: {_textBox.Text}";
                }
                else
                {
                    Text = "Цветная";
                }
            }

            private void ToggleBackgroundColor()
            {
                if (_checkBox.Checked)
                {
                    BackColor = Color.LightGreen;
                }
                else
                {
                    BackColor = _mouseOnForm ? Color.Coral : _backColor;
                }
            }

            private void SetCommonParameters(Control element, Size size, Point position, string title)
            {
                element.Size = size;
                element.Location = position;
                element.Text = title;
                Controls.Add(element);
            }

            private Button CreateButton(Size size, Point position, string title)
            {
                Button button = new Button();
                SetCommonParameters(button, size, position, title);
                return button;
            }

            private Label CreateLabel(Size size, Point position, string title)
            {
                Label label = new Label();
                SetCommonParameters(label, size, position, title);
                return label;
            }

            private TextBox CreateTextBox(Size size, Point position, string title)
            {
                TextBox textBox = new TextBox();
                SetCommonParameters(textBox, size, position, title);
                return textBox;
            }

            private CheckBox CreateCheckBox(Size size, Point position, string title)
            {
                CheckBox checkBox = new CheckBox();
                SetCommonParameters(checkBox, size, position, title);
                return checkBox;
            }
        }
    }
}