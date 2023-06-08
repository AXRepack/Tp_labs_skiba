using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlaUI;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using SkibaLab3;
using Windows.UI.ViewManagement;

namespace SkibaLab3Test
{
    internal class UiTest
    {

        string testAppPath = @"C:\Users\AXRep\OneDrive\Документы\TP\Скиба, ТП\lab3\SkibaLab3\bin\Debug\net6.0-windows\SkibaLab3.exe";
        int maxDelayTimeInMs = 5000;

        const string label_name = "label_name";
        const string label_surname = "label_surname";
        const string label_father = "label_father";
        const string label_father_text = "Отчество";
        const string label_surname_text = "Фамилия";
        const string label_name_text = "Имя";
        const string text_father_id = "text_father";
        const string text_surname_id = "text_surname";
        const string text_name_id = "text_name";
        const string appTitle = "FioTransformer";

        [Test]
        public void T_001_AllElementsAreUp()
        {
            FlaUI.Core.Application app =  FlaUI.Core.Application.Launch(testAppPath);

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                string title = window.Title;
                Assert.AreEqual(appTitle, title);


                var surnameLabel = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(label_surname)).AsLabel());
                var nameLabel = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(label_name)).AsLabel());
                var fatherLabel = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(label_father)).AsLabel());
                var fatherText = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(text_father_id)).AsTextBox());
                var surnameText = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(text_surname_id)).AsTextBox());
                var nameText = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(text_name_id)).AsTextBox());
                var buttonFio = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId("button_fio")).AsTextBox());
                var textOut = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId("text_out")).AsTextBox());




                Assert.AreEqual(label_surname_text, surnameLabel.Text);
                Assert.AreEqual(label_name_text, nameLabel.Text);
                Assert.AreEqual(label_father_text, fatherLabel.Text);

                app.Close();
            }



        }

        [Test]
        public void T_002_BaseFlow()
        {
            FlaUI.Core.Application app = FlaUI.Core.Application.Launch(testAppPath);

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                string title = window.Title;
                Assert.AreEqual(appTitle, title);


                var surnameLabel = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(label_surname)).AsLabel());
                var nameLabel = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(label_name)).AsLabel());
                var fatherLabel = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(label_father)).AsLabel());
                var fatherText = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(text_father_id)).AsTextBox());
                var surnameText = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(text_surname_id)).AsTextBox());
                var nameText = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(text_name_id)).AsTextBox());
                var buttonFio = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId("button_fio")).AsTextBox());
                var textOut = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId("text_out")).AsTextBox());


                fatherText.Enter("Эдикович");
                nameText.Enter("Александр");
                surnameText.Enter("Скиба");
                buttonFio.Click();

                Assert.AreEqual("Скиба А. Э.", textOut.Text);

                app.Close();
            }
        }

        [Test]
        public void T_003_WrongFlow()
        {
            FlaUI.Core.Application app = FlaUI.Core.Application.Launch(testAppPath);

            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                string title = window.Title;
                Assert.AreEqual(appTitle, title);


                var surnameLabel = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(label_surname)).AsLabel());
                var nameLabel = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(label_name)).AsLabel());
                var fatherLabel = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(label_father)).AsLabel());
                var fatherText = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(text_father_id)).AsTextBox());
                var surnameText = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(text_surname_id)).AsTextBox());
                var nameText = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId(text_name_id)).AsTextBox());
                var buttonFio = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId("button_fio")).AsTextBox());
                var textOut = WaitForElement(() => window.FindFirstDescendant
                    (cf => cf.ByAutomationId("text_out")).AsTextBox());


                fatherText.Enter("Эдикович!");
                nameText.Enter("Александр");
                surnameText.Enter("Скиба");
                buttonFio.Click();

                Assert.AreEqual("ForbiddenSymbolsException", textOut.Text);

                fatherText.Enter("");
                nameText.Enter("Александр");
                surnameText.Enter("Скиба");
                buttonFio.Click();

                Assert.AreEqual("Скиба А.", textOut.Text);

                app.Close();
            }
        }

        public T WaitForElement<T>(Func<T> getter)
        {
            var retry = Retry.WhileNull<T>(
            getter,
            TimeSpan.FromMilliseconds(maxDelayTimeInMs));
            if (!retry.Success)
            {
                Assert.Fail($"Невозможно найти элемент {maxDelayTimeInMs} ms");
            }
            return retry.Result;
        }


    }



}
