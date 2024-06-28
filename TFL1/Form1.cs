using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Globalization;
using static System.Windows.Forms.AxHost;

namespace TFL1
{
    public partial class Form1 : Form
    {
        public struct KA
        {
            // Фамилия
            public string fio;
            // Состояние автомата
            public string state;
        }
        // Путь открытого файла
        string fileNameIn = "";
        // Содержимое открытого файла
        string fileTextIn = "";
        // Список для хранения инициалов
        List<Regular> FIO = new List<Regular>();
        // Список номеров строк
        List<int> linesNumber = new List<int>();
        // Список начальных индексов слов
        List<int> startIndexes = new List<int>();
        // Список конечных индексов слов
        List<int> endIndexes = new List<int>();
        // Класс, описывающий состояния
        StateMachine stateMachine = new StateMachine();
        // Список результатов работы автомата 
        List<KA> kAs = new List<KA>();
        List<Leksem> leks = new List<Leksem>();
        // Открывание скобки
        bool open = false;
        // Закрытие скобки
        bool close = false;
        // Вернуться на символ назад
        bool turnBack = false;
        // Флаг вывода ошибки в случае отсутствия скобки в конце
        bool err = false;
        // Преобразованная константа
        string fix = "";
        // Количество ошибок
        int countErrs = 0;
        // Ожидаемые символы
        List<char> numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void OpenDocsSubMenu_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Helpter.chm");
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != fileTextIn)
            {
                CheckText();
            }
            // Событие нажатия на кнопку "Отмена"
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            // Получение имени файла
            fileNameIn = openFileDialog1.FileName;
            labelName.Text = "Текущий файл: " + openFileDialog1.FileName;
            // Чтение информации из файла
            fileTextIn = File.ReadAllText(fileNameIn);
            richTextBox1.Text = fileTextIn;
            MessageBox.Show("Файл успешно открыт", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            richTextBox1.Enabled = true;
        }
        // Сохранить как
        private void SaveHow()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            // Запись информации в файл
            File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл успешно сохранен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool CheckText()
        {
            DialogResult dR = MessageBox.Show("Сохранить файл?", "Оповещение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dR == DialogResult.Yes)
            {
                Save();
            }
            if (dR == DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }
        private void SaveItemHow_Click(object sender, EventArgs e)
        {
            SaveHow();
        }
        // Сохранить 
        private void Save()
        {
            try
            {
                File.WriteAllText(fileNameIn, richTextBox1.Text);
                MessageBox.Show("Файл успешно сохранен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                SaveHow();
            }
        }
        private void SaveItem_Click(object sender, EventArgs e)
        {
            Save();
        }
        // Создать файл
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            bool res = true;
            if ((richTextBox1.Text != "" || fileTextIn != "") && richTextBox1.Text != fileTextIn)
            {
                res = CheckText();
            }
            if (res)
            {
                labelName.Text = "";
                richTextBox1.Text = "";
                richTextBox1.Enabled = true;
                fileTextIn = "";
            }
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            bool res = true;
            if (richTextBox1.Text != fileTextIn)
            {
                res = CheckText();
            }
            if (res) System.Windows.Forms.Application.Exit();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Paste();
            }
        }

        private void BtnCut_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void ExitItem_Click(object sender, FormClosingEventArgs e)
        {
            bool res = true;
            if (richTextBox1.Text != fileTextIn)
            {
                res = CheckText();
            }
            if (res) System.Windows.Forms.Application.Exit();
        }

        private void PickAllFix_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
            }
        }

        private void DeleteFix_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectedText = "";
            }
        }

        private void BtnForward_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo == true)
            {
                richTextBox1.Redo();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
            }
        }

        private void AboutSubMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа написана студентами 3 курса НГТУ, АВТФ. Версия 1.0.0.1", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Регулярные выражения
        private void RegexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            startIndexes.Clear();
            endIndexes.Clear();
            linesNumber.Clear();
            //Инициалы после двойной фамилии
            string pattern = @"([А-ЯЁ][а-яё]{1,20}(ан|ана|ын|ына|ин|ина|ов|ова|ев|ева|ой|ая|их|ых)-[А-ЯЁ][а-яё]{1,20}(ан|ана|ын|ына|ин|ина|ов|ова|ев|ева|ой|ая|их|ых)\s[А-Я]\.[А-Я]\.)|" +
            //Инициалы до двойной фамилии
            @"([А-Я]\.[А-Я]\.\s[А-ЯЁ][а-яё]{1,20}(ан|ана|ын|ына|ин|ина|ов|ова|ев|ева|ой|ая|их|ых)-[А-ЯЁ][а-яё]{1,20}(ан|ана|ын|ына|ин|ина|ов|ова|ев|ева|ой|ая|их|ых))|" +
            ////Инициалы после фамилии
            @"([А-ЯЁ][а-яё]{1,20}(ан|ана|ын|ына|ин|ина|ов|ова|ев|ева|ой|ая|их|ых)\s[А-Я]\.[А-Я]\.)|" +
            //Инициалы до фамилии
            @"([А-Я]\.[А-Я]\.\s[А-ЯЁ][а-яё]{1,20}(ан|ана|ын|ына|ин|ина|ов|ова|ев|ева|ой|ая|их|ых))";
            Regex regex = new Regex(pattern);
            MatchCollection match = regex.Matches(richTextBox1.Text);
            int startSearching = 0;
            if (match.Count > 0)
            {
                foreach (Match m in match)
                {
                    int index = richTextBox1.Find(m.Value, startSearching, RichTextBoxFinds.NoHighlight);
                    richTextBox1.SelectionStart = index;
                    int lineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                    int startPositionInStr = richTextBox1.GetFirstCharIndexFromLine(lineIndex);
                    int startPositionOfWord = index - startPositionInStr;
                    int endPositionOfWord = startPositionOfWord + m.Value.Length;
                    startSearching = index + m.Length;
                    richTextBox2.Text += "Номер строки: " + (lineIndex + 1) + " Начало: " + (startPositionOfWord + 1) + " Конец: " + endPositionOfWord;
                    richTextBox2.Text += " Фамилия и инициалы: " + m.Value + "\n";
                    Regular a = new Regular(m.Value, startPositionOfWord + 1, endPositionOfWord, lineIndex + 1);
                    FIO.Add(a);
                }
            }
        }
        // Поиск по тексту
        private void MatchItems(MatchCollection match, string path)
        {
            int startSearching = 0;
            foreach (Match m in match)
            {

                int index = richTextBox1.Find(m.Value, startSearching, RichTextBoxFinds.NoHighlight);
                richTextBox1.SelectionStart = index;
                int lineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                int startPositionInStr = richTextBox1.GetFirstCharIndexFromLine(lineIndex);
                int startPositionOfWord = index - startPositionInStr;
                int endPositionOfWord = startPositionOfWord + m.Value.Length;
                startSearching = index + m.Length;
                if (linesNumber.Contains(lineIndex) && (startIndexes.Contains(startPositionOfWord) || endIndexes.Contains(endPositionOfWord))) continue;
                Regular a = new Regular(m.Value, startPositionOfWord + 1, endPositionOfWord, lineIndex + 1);
                richTextBox2.Text += "Номер строки: " + (lineIndex + 1) + " Начало: " + (startPositionOfWord + 1) + " Конец: " + endPositionOfWord;
                richTextBox2.Text += " Фамилия и инициалы: " + m.Value + " Путь: " + path + "\n";
                FIO.Add(a);
                startIndexes.Add(startPositionOfWord);
                endIndexes.Add(endPositionOfWord);
                linesNumber.Add(lineIndex);
            }
        }


        // Конечные автоматы
        private void TaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            // Собранное слово в данный момент
            string currentWord = "";
            // Текущее состояние автомата
            string currentState = "0";
            // Счетчик символов от текущей позиции
            int state = 0;
            endIndexes.Clear();
            startIndexes.Clear();
            for (int i = 0; i < richTextBox1.TextLength; i++)
            {
                // Счетчик количества букв в фамилии
                int sNameCount = 1;
                // Запись последней цепочки
                if (i + state >= richTextBox1.TextLength)
                {
                    int startIndex = 0;
                    if (endIndexes.Count > 0) startIndex = endIndexes.Last();
                    richTextBox2.Text += "Начало: " + (startIndex + 1) + ", Конец: " + (i + 1 + state) + "  Цепочка: " + currentWord + "\tПеречень состояний КА :" + currentState + "  FALSE\n";
                    break;
                }
                // Пропуск найденной цепочки
                if (endIndexes.Count > 0)
                {
                    if (i < endIndexes.Last()) continue;
                }
                if (stateMachine.State12(richTextBox1.Text[i + state]))
                {
                    currentState += "-12";
                    currentWord += richTextBox1.Text[i + state];
                    state++;
                    // Верхняя ветка
                    if (stateMachine.State1(richTextBox1.Text[i + state]))
                    {
                        currentState += "-1";
                        currentWord += richTextBox1.Text[i + state];
                        state++;
                        while (i + state < richTextBox1.TextLength && sNameCount < 19 && stateMachine.State1(richTextBox1.Text[i + state]))
                        {
                            sNameCount++;
                            currentWord += richTextBox1.Text[i + state];
                            currentState += "-1";
                            state++;
                            if (currentWord.Length >= 3 && (stateMachine.State2(currentWord.Substring(currentWord.Length - 3)) || stateMachine.State2(currentWord.Substring(currentWord.Length - 2))))
                            {
                                if (stateMachine.State2(currentWord.Substring(currentWord.Length - 3)))
                                {
                                    currentState = currentState.Substring(0, currentState.Length - 6);
                                    break;
                                }
                                else if (stateMachine.State2(currentWord.Substring(currentWord.Length - 2)))
                                {
                                    currentState = currentState.Substring(0, currentState.Length - 4);
                                    break;
                                }
                            }

                        }
                        if (currentWord.Length >= 3 && (stateMachine.State2(currentWord.Substring(currentWord.Length - 3)) || stateMachine.State2(currentWord.Substring(currentWord.Length - 2))))
                        {
                            currentState += "-2";
                            if (i + state < richTextBox1.TextLength && stateMachine.State8(richTextBox1.Text[i + state]))
                            {
                                currentState += "-8";
                                currentWord += richTextBox1.Text[i + state];
                                state++;
                                if (stateMachine.State22(richTextBox1.Text[i + state]))
                                {
                                    currentState += "-22";
                                    currentWord += richTextBox1.Text[i + state];
                                    state++;
                                    if (stateMachine.State9(richTextBox1.Text[i + state]))
                                    {
                                        currentState += "-9";
                                        currentWord += richTextBox1.Text[i + state];
                                        state++;
                                        sNameCount = 0;
                                        while (i + state < richTextBox1.TextLength && sNameCount < 19 && stateMachine.State9(richTextBox1.Text[i + state]))
                                        {
                                            sNameCount++;
                                            currentWord += richTextBox1.Text[i + state];
                                            currentState += "-9";
                                            state++;
                                            if (stateMachine.State10(currentWord.Substring(currentWord.Length - 3)))
                                            {
                                                currentState = currentState.Substring(0, currentState.Length - 6);
                                                break;
                                            }
                                            else if (stateMachine.State10(currentWord.Substring(currentWord.Length - 2)))
                                            {
                                                currentState = currentState.Substring(0, currentState.Length - 4);
                                                break;
                                            }
                                        }
                                        if (currentWord.Length >= 3 && (stateMachine.State10(currentWord.Substring(currentWord.Length - 3)) || stateMachine.State10(currentWord.Substring(currentWord.Length - 2))))
                                        {
                                            currentState += "-10";
                                            currentWord += richTextBox1.Text[i + state];
                                            if (i + state < richTextBox1.TextLength && stateMachine.State3(richTextBox1.Text[i + state]))
                                            {
                                                currentState += "-3";
                                                currentWord += richTextBox1.Text[i + state];
                                                state++;
                                                if (stateMachine.State4(richTextBox1.Text[i + state]))
                                                {
                                                    currentState += "-4";
                                                    currentWord += richTextBox1.Text[i + state];
                                                    state++;
                                                    if (stateMachine.State5(richTextBox1.Text[i + state]))
                                                    {
                                                        currentState += "-5";
                                                        currentWord += richTextBox1.Text[i + state];
                                                        state++;
                                                        if (stateMachine.State6(richTextBox1.Text[i + state]))
                                                        {
                                                            currentState += "-6";
                                                            currentWord += richTextBox1.Text[i + state];
                                                            state++;
                                                            if (stateMachine.State7(richTextBox1.Text[i + state]))
                                                            {
                                                                currentState += "-7";
                                                                currentWord += richTextBox1.Text[i + state];
                                                                int startIndex = 0;
                                                                if (endIndexes.Count > 0) startIndex = endIndexes.Last();
                                                                richTextBox2.Text += "Начало: " + (startIndex + 1) + ", Конец: " + (i + 1 + state) + "  Цепочка: " + currentWord + "\tПеречень состояний КА :" + currentState + "  TRUE\n";
                                                                startIndexes.Add(startIndex);
                                                                endIndexes.Add(i + state + 1);
                                                                KA a = new KA();
                                                                a.fio = currentWord;
                                                                a.state = currentState;
                                                                kAs.Add(a);
                                                                currentWord = "";
                                                                currentState = "0";
                                                                state = 0;
                                                            }
                                                            else
                                                            {
                                                                state--;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            state--;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        state--;
                                                    }
                                                }
                                                else
                                                {

                                                    state--;
                                                }
                                            }
                                            else
                                            {

                                                state--;
                                            }
                                        }
                                    }
                                    else
                                    {

                                        state--;
                                    }
                                }
                                else
                                {
                                    state--;
                                }

                            }
                            else if (i + state < richTextBox1.TextLength && stateMachine.State3(richTextBox1.Text[i + state]))
                            {

                                currentState += "-3";
                                currentWord += richTextBox1.Text[i + state];
                                state++;
                                if (stateMachine.State4(richTextBox1.Text[i + state]))
                                {
                                    currentState += "-4";
                                    currentWord += richTextBox1.Text[i + state];
                                    state++;
                                    if (stateMachine.State5(richTextBox1.Text[i + state]))
                                    {
                                        currentState += "-5";
                                        currentWord += richTextBox1.Text[i + state];
                                        state++;
                                        if (stateMachine.State6(richTextBox1.Text[i + state]))
                                        {
                                            currentState += "-6";
                                            currentWord += richTextBox1.Text[i + state];
                                            state++;
                                            if (stateMachine.State7(richTextBox1.Text[i + state]))
                                            {
                                                currentState += "-7";
                                                currentWord += richTextBox1.Text[i + state];
                                                int startIndex = 0;
                                                if (endIndexes.Count > 0) startIndex = endIndexes.Last();
                                                richTextBox2.Text += "Начало: " + (startIndex + 1) + ", Конец: " + (i + 1 + state) + "  Цепочка: " + currentWord + "\tПеречень состояний КА :" + currentState + "  TRUE\n";
                                                startIndexes.Add(startIndex);
                                                endIndexes.Add(i + state + 1);
                                                KA a = new KA();
                                                a.fio = currentWord;
                                                a.state = currentState;
                                                kAs.Add(a);
                                                currentWord = "";
                                                currentState = "0";
                                                state = 0;
                                            }
                                            else
                                            {
                                                state--;
                                            }
                                        }
                                        else
                                        {
                                            state--;
                                        }
                                    }
                                    else
                                    {
                                        state--;
                                    }
                                }
                                else
                                {
                                    state--;
                                }
                            }
                            else
                            {
                                state--;
                            }
                        }
                        else
                        {
                            state--;
                        }
                    }
                    // Нижняя ветка
                    else if (stateMachine.State13(richTextBox1.Text[i + state]))
                    {
                        currentState += "-13";
                        currentWord += richTextBox1.Text[i + state];
                        state++;
                        if (stateMachine.State14(richTextBox1.Text[i + state]))
                        {
                            currentState += "-14";
                            currentWord += richTextBox1.Text[i + state];
                            state++;
                            if (stateMachine.State15(richTextBox1.Text[i + state]))
                            {
                                currentState += "-15";
                                currentWord += richTextBox1.Text[i + state];
                                state++;
                                if (stateMachine.State16(richTextBox1.Text[i + state]))
                                {
                                    currentState += "-16";
                                    currentWord += richTextBox1.Text[i + state];
                                    state++;
                                    if (stateMachine.State23(richTextBox1.Text[i + state]))
                                    {
                                        currentState += "-23";
                                        currentWord += richTextBox1.Text[i + state];
                                        state++;
                                        if (stateMachine.State17(richTextBox1.Text[i + state]))
                                        {
                                            currentState += "-17";
                                            currentWord += richTextBox1.Text[i + state];
                                            state++;
                                            sNameCount = 0;
                                            while (i + state < richTextBox1.TextLength && sNameCount < 19 && stateMachine.State17(richTextBox1.Text[i + state]))
                                            {
                                                sNameCount++;
                                                currentWord += richTextBox1.Text[i + state];
                                                currentState += "-17";
                                                state++;
                                                if (stateMachine.State18(currentWord.Substring(currentWord.Length - 3)))
                                                {
                                                    currentState = currentState.Substring(0, currentState.Length - 9);
                                                    break;
                                                }
                                                else if (stateMachine.State18(currentWord.Substring(currentWord.Length - 2)))
                                                {
                                                    currentState = currentState.Substring(0, currentState.Length - 6);
                                                    break;
                                                }
                                            }
                                            if (currentWord.Length >= 3 && (stateMachine.State18(currentWord.Substring(currentWord.Length - 3)) || stateMachine.State18(currentWord.Substring(currentWord.Length - 2))))
                                            {
                                                currentState += "-18";
                                                if (i + state < richTextBox1.TextLength && stateMachine.State19(richTextBox1.Text[i + state]))
                                                {
                                                    currentState += "-19";
                                                    currentWord += richTextBox1.Text[i + state];
                                                    state++;
                                                    if (stateMachine.State24(richTextBox1.Text[i + state]))
                                                    {
                                                        currentState += "-24";
                                                        currentWord += richTextBox1.Text[i + state];
                                                        state++;
                                                        if (stateMachine.State20(richTextBox1.Text[i + state]))
                                                        {
                                                            currentState += "-20";
                                                            currentWord += richTextBox1.Text[i + state];
                                                            state++;
                                                            sNameCount = 0;
                                                            while (i + state < richTextBox1.TextLength && sNameCount < 19 && stateMachine.State20(richTextBox1.Text[i + state]))
                                                            {
                                                                sNameCount++;
                                                                currentWord += richTextBox1.Text[i + state];
                                                                currentState += "-20";
                                                                state++;
                                                                if (stateMachine.State21(currentWord.Substring(currentWord.Length - 3)))
                                                                {
                                                                    currentState = currentState.Substring(0, currentState.Length - 9);
                                                                    break;
                                                                }
                                                                else if (stateMachine.State21(currentWord.Substring(currentWord.Length - 2)))
                                                                {
                                                                    currentState = currentState.Substring(0, currentState.Length - 6);
                                                                    break;
                                                                }
                                                            }
                                                            if (stateMachine.State21(currentWord.Substring(currentWord.Length - 3)) || stateMachine.State21(currentWord.Substring(currentWord.Length - 2)))
                                                            {
                                                                currentState += "-21";
                                                                currentWord += richTextBox1.Text[i + state];
                                                                int startIndex = 0;
                                                                if (endIndexes.Count > 0) startIndex = endIndexes.Last();
                                                                richTextBox2.Text += "Начало: " + (startIndex + 1) + ", Конец: " + (i + 1 + state) + "  Цепочка: " + currentWord + "\tПеречень состояний КА :" + currentState + "  TRUE\n";
                                                                startIndexes.Add(startIndex);
                                                                endIndexes.Add(i + state + 1);
                                                                KA a = new KA();
                                                                a.fio = currentWord;
                                                                a.state = currentState;
                                                                kAs.Add(a);
                                                                currentWord = "";
                                                                currentState = "0";
                                                                state = 0;
                                                                continue;
                                                            }
                                                            else
                                                            {
                                                                state--;
                                                                continue;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            state--;
                                                            continue;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        state--;
                                                        continue;
                                                    }
                                                }
                                                else
                                                {
                                                    state--;
                                                    int startIndex = 0;
                                                    if (endIndexes.Count > 0) startIndex = endIndexes.Last();
                                                    richTextBox2.Text += "Начало: " + (startIndex + 1) + ", Конец: " + (i + 1 + state) + "  Цепочка: " + currentWord + "\tПеречень состояний КА :" + currentState + "  TRUE\n";
                                                    startIndexes.Add(startIndex);
                                                    endIndexes.Add(i + state + 1);
                                                    KA a = new KA();
                                                    a.fio = currentWord;
                                                    a.state = currentState;
                                                    kAs.Add(a);
                                                    currentWord = "";
                                                    currentState = "0";
                                                    state = 0;
                                                    continue;
                                                }

                                            }
                                            else
                                            {
                                                state--;
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            state--;
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        state--;
                                        continue;
                                    }

                                }
                                else
                                {
                                    state--;
                                    continue;
                                }
                            }
                            else
                            {
                                state--;
                                continue;
                            }
                        }
                        else
                        {
                            state--;
                            continue;
                        }
                    }
                    else
                    {
                        state--;
                    }
                }
                else
                {
                    currentState += "-0";
                    currentWord += richTextBox1.Text[i + state];
                }
            }

        }

        private void LexicAnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            string[] type = new string[4] { "Число", "Скобка", "Знак", "Идентификатор" };
            List<char> skobka = new List<char>() { ')', '(', '{', '}', '[', ']', '<', '>', '|' };
            List<char> znak = new List<char>() { '!', ':', ';', '?', '-', '_', '+', '=', '*', '%', '~', '/', '\\', '&' };
            bool flag = false; // для обозначения была ли уже точка или запятая в строке число.
            int lineIndex = 0;
            int startPositionInStr = 0;
            int startPositionOfWord = 0;
            int endPositionOfWord = 0;

            string identif = "";
            string chislo = "";
            for (int i = 0; i < richTextBox1.TextLength; i++)
            {
                //Продолжение записи числа
                if (chislo.Length > 0)
                {
                    if ((Char.IsDigit(richTextBox1.Text[i]) || richTextBox1.Text[i].ToString() == "," || richTextBox1.Text[i].ToString() == ".") && i != richTextBox1.TextLength - 1)
                    {
                        if (richTextBox1.Text[i].ToString() == "," || richTextBox1.Text[i].ToString() == ".")
                        {
                            if (flag == false)
                            {
                                chislo += richTextBox1.Text[i].ToString();
                                flag = true;
                            }
                            else
                            {
                                if (chislo[chislo.Length - 1] == '.' || chislo[chislo.Length - 1] == ',')
                                {
                                    chislo = chislo.Remove(chislo.Length - 1);
                                    i -= 2;
                                }
                                else i--;
                                endPositionOfWord = startPositionOfWord + chislo.Length;
                                richTextBox2.Text += "Номер строки: " + (lineIndex + 1) + " Начало: " + (startPositionOfWord + 1) + " Конец: " + endPositionOfWord;
                                richTextBox2.Text += " Тип: " + type[0] + ", Лексема: " + chislo + "\n";
                                Leksem a = new Leksem(type[0], chislo, startPositionOfWord + 1, endPositionOfWord, lineIndex + 1);
                                leks.Add(a);
                                chislo = "";
                                flag = false;
                            }
                        }
                        else
                            chislo += richTextBox1.Text[i].ToString();
                    }
                    else
                    {
                        if (i == richTextBox1.TextLength - 1 && Char.IsDigit(richTextBox1.Text[i]))
                        {
                            chislo += richTextBox1.Text[i].ToString();
                        }
                        else if (i == richTextBox1.TextLength - 1 && !Char.IsDigit(richTextBox1.Text[i]))
                        {
                            // Если целое число заканчивается на две точки, необходимо вернуться на 2 символа назад, а если дробное и заканчивается на точку, тогда на 1 символ
                            if (chislo[chislo.Length - 1] == '.' || chislo[chislo.Length - 1] == ',')
                            {
                                chislo = chislo.Remove(chislo.Length - 1);
                                i -= 2;
                            }
                            else i--;
                        }
                        else if (i < richTextBox1.TextLength - 1 && !Char.IsDigit(richTextBox1.Text[i])) i--;
                        endPositionOfWord = startPositionOfWord + chislo.Length;
                        richTextBox2.Text += "Номер строки: " + (lineIndex + 1) + " Начало: " + (startPositionOfWord + 1) + " Конец: " + endPositionOfWord;
                        richTextBox2.Text += " Тип: " + type[0] + ", Лексема: " + chislo + "\n";
                        Leksem a = new Leksem(type[0], chislo, startPositionOfWord + 1, endPositionOfWord, lineIndex + 1);
                        leks.Add(a);
                        chislo = "";
                        flag = false;
                    }
                }
                //Продолжение записи идентификатора
                else if (identif.Length > 0)
                {
                    if ((Char.IsDigit(richTextBox1.Text[i]) || Char.IsLetter(richTextBox1.Text[i])) && i != richTextBox1.TextLength - 1)
                    {
                        identif += richTextBox1.Text[i].ToString();
                    }
                    else
                    {
                        if (i == richTextBox1.TextLength - 1 && (Char.IsDigit(richTextBox1.Text[i]) || Char.IsLetter(richTextBox1.Text[i])))
                        {
                            identif += richTextBox1.Text[i].ToString();
                        }
                        else if (i < richTextBox1.TextLength - 1 && !Char.IsLetter(richTextBox1.Text[i])) i--;
                        endPositionOfWord = startPositionOfWord + identif.Length;
                        richTextBox2.Text += "Номер строки: " + (lineIndex + 1) + " Начало: " + (startPositionOfWord + 1) + " Конец: " + endPositionOfWord;
                        richTextBox2.Text += " Тип: " + type[3] + ", Лексема: " + identif + "\n";
                        Leksem a = new Leksem(type[3], identif, startPositionOfWord + 1, endPositionOfWord, lineIndex + 1);
                        leks.Add(a);
                        identif = "";
                    }
                }
                //Начало числа
                else if (Char.IsDigit(richTextBox1.Text[i]))
                {
                    lineIndex = richTextBox1.GetLineFromCharIndex(i);
                    startPositionInStr = richTextBox1.GetFirstCharIndexFromLine(lineIndex);
                    startPositionOfWord = i - startPositionInStr;
                    chislo += richTextBox1.Text[i].ToString();
                    if (i == richTextBox1.TextLength - 1)
                    {
                        endPositionOfWord = startPositionOfWord + chislo.Length;
                        richTextBox2.Text += "Номер строки: " + (lineIndex + 1) + " Начало: " + (startPositionOfWord + 1) + " Конец: " + endPositionOfWord;
                        richTextBox2.Text += " Тип: " + type[0] + ", Лексема: " + chislo + "\n";
                        Leksem a = new Leksem(type[0], identif, startPositionOfWord + 1, endPositionOfWord, lineIndex + 1);
                        leks.Add(a);
                        chislo = "";
                    }
                }
                //Начало индентификатора
                else if (Char.IsLetter(richTextBox1.Text[i]))
                {
                    lineIndex = richTextBox1.GetLineFromCharIndex(i);
                    startPositionInStr = richTextBox1.GetFirstCharIndexFromLine(lineIndex);
                    startPositionOfWord = i - startPositionInStr;
                    identif += richTextBox1.Text[i].ToString();
                    if (i == richTextBox1.TextLength - 1)
                    {
                        endPositionOfWord = startPositionOfWord + identif.Length;
                        richTextBox2.Text += "Номер строки: " + (lineIndex + 1) + " Начало: " + (startPositionOfWord + 1) + " Конец: " + endPositionOfWord;
                        richTextBox2.Text += " Тип: " + type[3] + ", Лексема: " + identif + "\n";
                        Leksem a = new Leksem(type[3], identif, startPositionOfWord + 1, endPositionOfWord, lineIndex + 1);
                        leks.Add(a);
                        identif = "";
                    }
                }
                else if (skobka.Contains(richTextBox1.Text[i]))
                {
                    lineIndex = richTextBox1.GetLineFromCharIndex(i);
                    startPositionInStr = richTextBox1.GetFirstCharIndexFromLine(lineIndex);
                    startPositionOfWord = i - startPositionInStr;
                    endPositionOfWord = startPositionOfWord;
                    richTextBox2.Text += "Номер строки: " + (lineIndex + 1) + " Начало: " + (startPositionOfWord + 1) + " Конец: " + (endPositionOfWord + 1);
                    richTextBox2.Text += " Тип: " + type[1] + ", Лексема: " + richTextBox1.Text[i] + "\n";
                    Leksem a = new Leksem(type[1], richTextBox1.Text[i].ToString(), startPositionOfWord + 1, endPositionOfWord + 1, lineIndex + 1);
                    leks.Add(a);
                }
                else if (znak.Contains(richTextBox1.Text[i]))
                {
                    lineIndex = richTextBox1.GetLineFromCharIndex(i);
                    startPositionInStr = richTextBox1.GetFirstCharIndexFromLine(lineIndex);
                    startPositionOfWord = i - startPositionInStr;
                    endPositionOfWord = startPositionOfWord;
                    richTextBox2.Text += "Номер строки: " + (lineIndex + 1) + " Начало: " + (startPositionOfWord + 1) + " Конец: " + (endPositionOfWord + 1);
                    richTextBox2.Text += " Тип: " + type[2] + ", Лексема: " + richTextBox1.Text[i] + "\n";
                    Leksem a = new Leksem(type[2], richTextBox1.Text[i].ToString(), startPositionOfWord + 1, endPositionOfWord + 1, lineIndex + 1);
                    leks.Add(a);
                }
            }

        }
        void E(ref int i)
        {
            if (i == 0) richTextBox2.Text += "E";
            else richTextBox2.Text += "-E";

            T(ref i);
            A(ref i);

        }
        void A(ref int i)
        {
            richTextBox2.Text += "-A";
            if (richTextBox1.Text[i].ToString() == "+")
            {
                richTextBox2.Text += "-+";
                i++;
                T(ref i);
                A(ref i);
            }
            else if (richTextBox1.Text[i].ToString() == "-")
            {
                richTextBox2.Text += "-'-'";
                i++;
                T(ref i);
                A(ref i);
            }
            else
            {
                richTextBox2.Text += "-ε";
                if (close)
                {
                    richTextBox2.Text += "-)";
                    open = false;
                    close = false;
                }
                if (err)
                {
                    richTextBox2.Text += "-ER";
                    open = false;
                    close = false;
                    err = false;
                }
                return;
            }
        }
        void T(ref int i)
        {
            richTextBox2.Text += "-T";
            O(ref i);
            B(ref i);
        }
        void O(ref int i)
        {
            richTextBox2.Text += "-O";
            string number = "";
            string id = "";
            for (; i < richTextBox1.TextLength; i++)
            {
                if (open && !close && !Char.IsDigit(richTextBox1.Text[i]) && !Char.IsLetter(richTextBox1.Text[i]) && richTextBox1.Text[i] != '+' && richTextBox1.Text[i] != '*'
                    && richTextBox1.Text[i] != '-' && richTextBox1.Text[i] != '/' && richTextBox1.Text[i] != ')' && richTextBox1.Text[i] != '.' && richTextBox1.Text[i] != ',')
                {
                    // Написать для дробного числа (обработать точку)
                    richTextBox2.Text += "-ER";
                    open = false;
                    close = false;
                    turnBack = true;
                    return;
                }
                if (open && !close && richTextBox1.Text[i] == ')' && (number.Length > 0 || id.Length > 0))
                {
                    close = true;
                    if (number.Length > 0) richTextBox2.Text += "-num";
                    else richTextBox2.Text += "-id";
                    return;
                }
                else if (open && !close && richTextBox1.Text[i] == ')' && number.Length == 0 && id.Length == 0)
                {
                    close = true;
                    return;
                }
                if (number.Length > 0)
                {
                    if ((Char.IsDigit(richTextBox1.Text[i]) || richTextBox1.Text[i].ToString() == "," || richTextBox1.Text[i].ToString() == ".") && i != richTextBox1.TextLength - 1)
                    {
                        if (richTextBox1.Text[i].ToString() == "," || richTextBox1.Text[i].ToString() == ".")
                        {
                            if (number.Contains(".") || number.Contains(","))
                            {
                                // Если целое число заканчивается на две точки, необходимо вернуться на 2 символа назад, а если дробное и заканчивается на точку, тогда на 1 символ
                                if (number[number.Length - 1] == '.' || number[number.Length - 1] == ',') i -= 2;
                                else i--;
                                number = "";
                                richTextBox2.Text += "-num";
                                return;
                            }
                            else
                            {
                                number += richTextBox1.Text[i].ToString();

                            }
                        }
                        else
                            number += richTextBox1.Text[i].ToString();
                    }
                    else
                    {
                        if (i == richTextBox1.TextLength - 1 && Char.IsDigit(richTextBox1.Text[i]))
                        {
                            number += richTextBox1.Text[i].ToString();
                            if (open && !close) err = true;
                        }
                        else if (i == richTextBox1.TextLength - 1 && !Char.IsDigit(richTextBox1.Text[i]))
                        {
                            err = true;
                            // Если целое число заканчивается на две точки, необходимо вернуться на 2 символа назад, а если дробное и заканчивается на точку, тогда на 1 символ
                            if (number[number.Length - 1] == '.' || number[number.Length - 1] == ',') i -= 2;
                            else if (number.Contains('.') || number.Contains(',')) i--;

                        }
                        else if (i < richTextBox1.TextLength - 1 && !Char.IsDigit(richTextBox1.Text[i]) && richTextBox1.Text[i] != '*' && richTextBox1.Text[i] != '+'
                            && richTextBox1.Text[i] != '/' && richTextBox1.Text[i] != '-') i--;
                        richTextBox2.Text += "-num";
                        return;
                    }
                }
                else if (id.Length > 0)
                {
                    if ((Char.IsDigit(richTextBox1.Text[i]) || Char.IsLetter(richTextBox1.Text[i])) && i != richTextBox1.TextLength - 1)
                    {
                        id += richTextBox1.Text[i].ToString();
                    }
                    else
                    {
                        if (i == richTextBox1.TextLength - 1 && (Char.IsDigit(richTextBox1.Text[i]) || Char.IsLetter(richTextBox1.Text[i])))
                        {
                            id += richTextBox1.Text[i].ToString();
                            err = true;
                        }
                        id = "";
                        richTextBox2.Text += "-id";
                        return;
                    }
                }
                //Начало числа
                else if (Char.IsDigit(richTextBox1.Text[i]))
                {
                    if (i < richTextBox1.TextLength - 1) number += richTextBox1.Text[i].ToString();
                    else
                    {
                        richTextBox2.Text += "-num";
                        return;
                    }
                }
                //Начало индентификатора
                else if (Char.IsLetter(richTextBox1.Text[i]))
                {
                    if (i < richTextBox1.TextLength - 1) id += richTextBox1.Text[i].ToString();
                    else
                    {
                        richTextBox2.Text += "-id";
                        return;
                    }
                }
                else if (richTextBox1.Text[i] == '(')
                {
                    open = true;
                    richTextBox2.Text += "-(";
                    i++;
                    E(ref i);
                    return;
                }
                else
                {
                    open = false;
                    richTextBox2.Text += "-ER";
                    return;
                }
            }
        }
        void B(ref int i)
        {
            richTextBox2.Text += "-B";
            if (richTextBox1.Text[i].ToString() == "*")
            {
                richTextBox2.Text += "-*";
                i++;
                O(ref i);
                B(ref i);
            }
            else if (richTextBox1.Text[i].ToString() == "/")
            {
                richTextBox2.Text += "-/";
                i++;
                O(ref i);
                B(ref i);
            }
            else
            {
                richTextBox2.Text += "-ε";
                return;
            }
        }
        private void RecurcsionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            turnBack = false;
            open = false;
            close = false;
            for (int i = 0; i < richTextBox1.TextLength; i++)
            {
                if (turnBack)
                {
                    i--;
                    turnBack = false;
                }
                E(ref i);

            }
        }
        void FixErrors(ref int i, char replace, List<char> arr)
        {
            string temp = "";
            while (!arr.Contains(richTextBox1.Text[i]))
            {
                temp += richTextBox1.Text[i];
                i++;
                if (i == richTextBox1.TextLength) break;
            }
            if (i == richTextBox1.TextLength)
            {
                richTextBox2.Text += "Найдена ошибка :" + temp + " , индекс ошибки: " + (i - temp.Length + 1) + $" Ожидалось число\n";
                replace = '1';
            }
            else
            {
                if (Char.IsDigit(richTextBox1.Text[i]))
                {
                    richTextBox2.Text += "Найдена ошибка :" + temp + " , индекс ошибки: " + (i - temp.Length + 1) + $" Ожидалось число\n";
                    replace = '1';
                }
                else if (richTextBox1.Text[i] == '+')
                {
                    richTextBox2.Text += "Найдена ошибка :" + temp + " , индекс ошибки: " + (i - temp.Length + 1) + $" Ожидался знак +\n";
                    replace = '+';
                    if (i < richTextBox1.TextLength) i++;
                }
                else if (richTextBox1.Text[i] == '-')
                {
                    richTextBox2.Text += "Найдена ошибка :" + temp + " , индекс ошибки: " + (i - temp.Length + 1) + $" Ожидался знак -\n";
                    replace = '-';
                    if (i < richTextBox1.TextLength) i++;
                }
                else if (richTextBox1.Text[i] == 'E')
                {
                    richTextBox2.Text += "Найдена ошибка :" + temp + " , индекс ошибки: " + (i - temp.Length + 1) + $" Ожидалось E\n";
                    replace = 'E';
                    if (i < richTextBox1.TextLength) i++;
                }
            }

            fix += replace;
            countErrs++;
        }
        void FuncCH(ref int i)
        {
            if (richTextBox1.Text[i] == '+' || richTextBox1.Text[i] == '-')
            {
                fix += richTextBox1.Text[i];
                i++;
            }
            FuncCHBZ(ref i);
        }
        void FuncCHBZ(ref int i)
        {
            if (richTextBox1.Text[i] == 'E')
            {
                fix += richTextBox1.Text[i];
                i++;
                FuncCEL(ref i);
            }
            else
            {
                FuncDCH(ref i);
                if (i < richTextBox1.TextLength && richTextBox1.Text[i] == 'E')
                {
                    fix += richTextBox1.Text[i];
                    i++;
                    FuncCEL(ref i);
                }
                else if (i < richTextBox1.TextLength && richTextBox1.Text[i] != 'E')
                {
                    numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    List<char> numbersE = numbers;
                    numbersE.Add('E');
                    FixErrors(ref i, 'E', numbersE);
                    if (i < richTextBox1.TextLength)
                        FuncCEL(ref i);
                }
            }

        }
        void FuncDCH(ref int i)
        {
            if (richTextBox1.Text[i] == '.')
            {
                fix += richTextBox1.Text[i];
                i++;
                FuncCELBZ(ref i);
            }

            else
            {
                FuncCELBZ(ref i);
            }
        }
        void FuncCEL(ref int i)
        {
            if (richTextBox1.Text[i] == '+' || richTextBox1.Text[i] == '-')
            {
                fix += richTextBox1.Text[i];
                i++;
            }
            FuncCELBZ(ref i);
        }
        void FuncCELBZ(ref int i)
        {

            if (Char.IsDigit(richTextBox1.Text[i]))
            {
                while (Char.IsDigit(richTextBox1.Text[i]))
                {
                    fix += richTextBox1.Text[i];
                    i++;
                    if (i == richTextBox1.TextLength) return;
                }
                if (richTextBox1.Text[i] == '.')
                {
                    fix += richTextBox1.Text[i];
                    i++;
                    if (Char.IsDigit(richTextBox1.Text[i]))
                        FuncCELBZ(ref i);
                    else if (richTextBox1.Text[i] != 'E')
                    {
                        FixErrors(ref i, '1', numbers);
                        FuncCELBZ(ref i);
                    }
                }
                else if (richTextBox1.Text[i] != 'E' && richTextBox1.Text[i] != '+' && richTextBox1.Text[i] != '-')
                {
                    numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    List<char> plusMinus = numbers;
                    plusMinus.AddRange(new char[] { '+', '-','E' });
                    FixErrors(ref i, '+', plusMinus);
                    if (i < richTextBox1.TextLength)
                        FuncCELBZ(ref i);
                }
            }
            else if (richTextBox1.Text[i] != 'E' && richTextBox1.Text[i] != '+' && richTextBox1.Text[i] != '-')
            {
                numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                List<char> plusMinus = numbers;
                plusMinus.AddRange(new char[] { '+', '-', 'E' });
                FixErrors(ref i, '+', plusMinus);
                if (i < richTextBox1.TextLength)
                    FuncCELBZ(ref i);
            }
        }
        private void DiagnosticToolStrip_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            fix = "";
            countErrs = 0;
            for (int i = 0; i < richTextBox1.TextLength; i++)
            {
                FuncCH(ref i);
            }
            richTextBox2.Text += $"Общее количество ошибок: {countErrs} \n Ожидаемая константа: {fix}";
        }
    }
}
