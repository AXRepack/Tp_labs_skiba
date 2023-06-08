
using SkibaLab3Test;
using System.Runtime.CompilerServices;

namespace SkibaLab3
{
    partial class FioTransformer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Очистка ресурсов.
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

        /// <summary>
        /// Создание из трёх отдельных строк (ФИО) инициалов
        /// </summary>
        /// <example>
        /// Пример Применения:
        /// <code>
        /// 
        /// string initials = CreateFioInitials(surname, name, patronymic);
        /// </code>
        /// </example>
        /// <param name="surname">Фамилия пользователя, не может быть пустым, должен состоять из букв латинского или русского алфавита</param>
        /// <param name="name">Имя пользователя, не может быть пустым, должен состоять из букв латинского или русского алфавита</param>
        /// <param name="otchestvo">Отчество пользователя, может быть пустым, должен состоять из букв латинского или русского алфавита</param>
        /// <returns>Инициалы пользователя пр. "Скиба А. Э."</returns>
        public static string CreateFioInitials(string surname, string name, string otchestvo)
        {
            //добавить проверку на пустые строки, также отчества может и не быть
            string fio = "";

            if (surname == "" && name == "" && otchestvo == "")
            {
                return "EmptyException";
            }


            if (surname.Contains('!') | name.Contains('!') | otchestvo.Contains('!'))
            {
                return "ForbiddenSymbolsException";
            }
            if (surname != "" && name != "" && otchestvo != "")
            {
                fio = surname + " " + name.Substring(0, 1) + ". " + otchestvo.Substring(0, 1) + ".";
            }
            if (surname == "" && name != "" && otchestvo != "")
            {
                fio = name.Substring(0, 1) + ". " + otchestvo.Substring(0, 1) + ".";
            }
            if (name == "" && surname != "")
            {
                fio = surname;
            }
            if (surname != "" && name != "" && otchestvo == "")
            {
                fio = surname + " " + name.Substring(0, 1) + ".";
            }
            return fio;
        }

        public static MockBuffer buffer = new MockBuffer();

        /// <summary>
        /// Получает строку из буфера, делит её и возвращает инициалы.
        /// </summary>
        /// <returns>string initials</returns>
        public static string splitAndTest()
        {

            if (buffer.paste == "")
            {
                return "EmptyException";
            }
            string[] FIO_array = buffer.paste.Split(' ');
            string surname = FIO_array[0];
            string name = FIO_array[1];
            string otchestvo = FIO_array[2];
            string fio = CreateFioInitials(surname, name, otchestvo);


            return fio;
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            text_surname = new TextBox();
            text_name = new TextBox();
            text_father = new TextBox();
            label_surname = new Label();
            label_name = new Label();
            label_father = new Label();
            button_fio = new Button();
            text_out = new TextBox();
            SuspendLayout();
            // 
            // text_surname
            // 
            text_surname.Location = new Point(77, 22);
            text_surname.Name = "text_surname";
            text_surname.Size = new Size(125, 23);
            text_surname.TabIndex = 0;
            // 
            // text_name
            // 
            text_name.Location = new Point(77, 75);
            text_name.Name = "text_name";
            text_name.Size = new Size(125, 23);
            text_name.TabIndex = 1;
            // 
            // text_father
            // 
            text_father.Location = new Point(77, 126);
            text_father.Name = "text_father";
            text_father.Size = new Size(125, 23);
            text_father.TabIndex = 2;
            // 
            // label_surname
            // 
            label_surname.AutoSize = true;
            label_surname.Location = new Point(15, 25);
            label_surname.Name = "label_surname";
            label_surname.Size = new Size(58, 15);
            label_surname.TabIndex = 3;
            label_surname.Text = "Фамилия";
            label_surname.TextAlign = ContentAlignment.MiddleCenter;
            label_surname.Click += label1_Click;
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Location = new Point(15, 78);
            label_name.Name = "label_name";
            label_name.Size = new Size(31, 15);
            label_name.TabIndex = 4;
            label_name.Text = "Имя";
            label_name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_father
            // 
            label_father.AutoSize = true;
            label_father.Location = new Point(15, 129);
            label_father.Name = "label_father";
            label_father.Size = new Size(58, 15);
            label_father.TabIndex = 5;
            label_father.Text = "Отчество";
            label_father.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_fio
            // 
            button_fio.Location = new Point(245, 75);
            button_fio.Name = "button_fio";
            button_fio.Size = new Size(75, 23);
            button_fio.TabIndex = 6;
            button_fio.Text = "=";
            button_fio.UseVisualStyleBackColor = true;
            button_fio.Click += button_fio_Click;
            // 
            // text_out
            // 
            text_out.Location = new Point(357, 75);
            text_out.Name = "text_out";
            text_out.Size = new Size(100, 23);
            text_out.TabIndex = 7;
            // 
            // FioTransformer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 161);
            Controls.Add(text_out);
            Controls.Add(button_fio);
            Controls.Add(label_father);
            Controls.Add(label_name);
            Controls.Add(label_surname);
            Controls.Add(text_father);
            Controls.Add(text_name);
            Controls.Add(text_surname);
            Name = "FioTransformer";
            Text = "FioTransformer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox text_surname;
        private TextBox text_name;
        private TextBox text_father;
        private Label label_surname;
        private Label label_name;
        private Label label_father;
        private Button button_fio;
        private TextBox text_out;
    }
}