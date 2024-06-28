namespace TFL1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveItemHow = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FixMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelFix = new System.Windows.Forms.ToolStripMenuItem();
            this.RepeatFix = new System.Windows.Forms.ToolStripMenuItem();
            this.CutFIx = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyFix = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteFix = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFix = new System.Windows.Forms.ToolStripMenuItem();
            this.PickAllFix = new System.Windows.Forms.ToolStripMenuItem();
            this.TextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.грамматикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.классификацияГрамматикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методАнализаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiagnosticToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.тестовыйПримерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЛитературыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исходныйКодПрограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LexicAnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecurcsionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DocsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDocsSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnForward = new System.Windows.Forms.Button();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.BtnCut = new System.Windows.Forms.Button();
            this.BtnPaste = new System.Windows.Forms.Button();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.ButSave = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.labelName = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.FixMenu,
            this.TextMenu,
            this.StartMenu,
            this.DocsMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1037, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateItem,
            this.OpenItem,
            this.SaveItem,
            this.SaveItemHow,
            this.ExitItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(59, 26);
            this.FileMenu.Text = "Файл";
            // 
            // CreateItem
            // 
            this.CreateItem.Name = "CreateItem";
            this.CreateItem.Size = new System.Drawing.Size(192, 26);
            this.CreateItem.Text = "Создать";
            this.CreateItem.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // OpenItem
            // 
            this.OpenItem.Name = "OpenItem";
            this.OpenItem.Size = new System.Drawing.Size(192, 26);
            this.OpenItem.Text = "Открыть";
            this.OpenItem.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // SaveItem
            // 
            this.SaveItem.Name = "SaveItem";
            this.SaveItem.Size = new System.Drawing.Size(192, 26);
            this.SaveItem.Text = "Сохранить";
            this.SaveItem.Click += new System.EventHandler(this.SaveItem_Click);
            // 
            // SaveItemHow
            // 
            this.SaveItemHow.Name = "SaveItemHow";
            this.SaveItemHow.Size = new System.Drawing.Size(192, 26);
            this.SaveItemHow.Text = "Сохранить как";
            this.SaveItemHow.Click += new System.EventHandler(this.SaveItemHow_Click);
            // 
            // ExitItem
            // 
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(192, 26);
            this.ExitItem.Text = "Выход";
            this.ExitItem.Click += new System.EventHandler(this.ExitItem_Click);
            // 
            // FixMenu
            // 
            this.FixMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelFix,
            this.RepeatFix,
            this.CutFIx,
            this.CopyFix,
            this.PasteFix,
            this.DeleteFix,
            this.PickAllFix});
            this.FixMenu.Name = "FixMenu";
            this.FixMenu.Size = new System.Drawing.Size(74, 26);
            this.FixMenu.Text = "Правка";
            // 
            // CancelFix
            // 
            this.CancelFix.Name = "CancelFix";
            this.CancelFix.Size = new System.Drawing.Size(186, 26);
            this.CancelFix.Text = "Отменить";
            this.CancelFix.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // RepeatFix
            // 
            this.RepeatFix.Name = "RepeatFix";
            this.RepeatFix.Size = new System.Drawing.Size(186, 26);
            this.RepeatFix.Text = "Повторить";
            this.RepeatFix.Click += new System.EventHandler(this.BtnForward_Click);
            // 
            // CutFIx
            // 
            this.CutFIx.Name = "CutFIx";
            this.CutFIx.Size = new System.Drawing.Size(186, 26);
            this.CutFIx.Text = "Вырезать";
            this.CutFIx.Click += new System.EventHandler(this.BtnCut_Click);
            // 
            // CopyFix
            // 
            this.CopyFix.Name = "CopyFix";
            this.CopyFix.Size = new System.Drawing.Size(186, 26);
            this.CopyFix.Text = "Копировать";
            this.CopyFix.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // PasteFix
            // 
            this.PasteFix.Name = "PasteFix";
            this.PasteFix.Size = new System.Drawing.Size(186, 26);
            this.PasteFix.Text = "Вставить";
            this.PasteFix.Click += new System.EventHandler(this.BtnPaste_Click);
            // 
            // DeleteFix
            // 
            this.DeleteFix.Name = "DeleteFix";
            this.DeleteFix.Size = new System.Drawing.Size(186, 26);
            this.DeleteFix.Text = "Удалить";
            this.DeleteFix.Click += new System.EventHandler(this.DeleteFix_Click);
            // 
            // PickAllFix
            // 
            this.PickAllFix.Name = "PickAllFix";
            this.PickAllFix.Size = new System.Drawing.Size(186, 26);
            this.PickAllFix.Text = "Выделить все";
            this.PickAllFix.Click += new System.EventHandler(this.PickAllFix_Click);
            // 
            // TextMenu
            // 
            this.TextMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TaskToolStripMenuItem,
            this.грамматикаToolStripMenuItem,
            this.классификацияГрамматикаToolStripMenuItem,
            this.методАнализаToolStripMenuItem,
            this.DiagnosticToolStrip,
            this.тестовыйПримерToolStripMenuItem,
            this.списокЛитературыToolStripMenuItem,
            this.исходныйКодПрограммыToolStripMenuItem,
            this.RegexToolStripMenuItem,
            this.LexicAnToolStripMenuItem,
            this.RecurcsionToolStripMenuItem});
            this.TextMenu.Name = "TextMenu";
            this.TextMenu.Size = new System.Drawing.Size(59, 26);
            this.TextMenu.Text = "Текст";
            // 
            // TaskToolStripMenuItem
            // 
            this.TaskToolStripMenuItem.Name = "TaskToolStripMenuItem";
            this.TaskToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.TaskToolStripMenuItem.Text = "Задача";
            this.TaskToolStripMenuItem.Click += new System.EventHandler(this.TaskToolStripMenuItem_Click);
            // 
            // грамматикаToolStripMenuItem
            // 
            this.грамматикаToolStripMenuItem.Name = "грамматикаToolStripMenuItem";
            this.грамматикаToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.грамматикаToolStripMenuItem.Text = "Грамматика";
            // 
            // классификацияГрамматикаToolStripMenuItem
            // 
            this.классификацияГрамматикаToolStripMenuItem.Name = "классификацияГрамматикаToolStripMenuItem";
            this.классификацияГрамматикаToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.классификацияГрамматикаToolStripMenuItem.Text = "Классификация грамматика";
            // 
            // методАнализаToolStripMenuItem
            // 
            this.методАнализаToolStripMenuItem.Name = "методАнализаToolStripMenuItem";
            this.методАнализаToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.методАнализаToolStripMenuItem.Text = "Метод анализа";
            // 
            // DiagnosticToolStrip
            // 
            this.DiagnosticToolStrip.Name = "DiagnosticToolStrip";
            this.DiagnosticToolStrip.Size = new System.Drawing.Size(363, 26);
            this.DiagnosticToolStrip.Text = "Диагностика и нейтрализация ошибок";
            this.DiagnosticToolStrip.Click += new System.EventHandler(this.DiagnosticToolStrip_Click);
            // 
            // тестовыйПримерToolStripMenuItem
            // 
            this.тестовыйПримерToolStripMenuItem.Name = "тестовыйПримерToolStripMenuItem";
            this.тестовыйПримерToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.тестовыйПримерToolStripMenuItem.Text = "Тестовый пример";
            // 
            // списокЛитературыToolStripMenuItem
            // 
            this.списокЛитературыToolStripMenuItem.Name = "списокЛитературыToolStripMenuItem";
            this.списокЛитературыToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.списокЛитературыToolStripMenuItem.Text = "Список литературы";
            // 
            // исходныйКодПрограммыToolStripMenuItem
            // 
            this.исходныйКодПрограммыToolStripMenuItem.Name = "исходныйКодПрограммыToolStripMenuItem";
            this.исходныйКодПрограммыToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.исходныйКодПрограммыToolStripMenuItem.Text = "Исходный код программы";
            // 
            // RegexToolStripMenuItem
            // 
            this.RegexToolStripMenuItem.Name = "RegexToolStripMenuItem";
            this.RegexToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.RegexToolStripMenuItem.Text = "Регулярные выражения ";
            this.RegexToolStripMenuItem.Click += new System.EventHandler(this.RegexToolStripMenuItem_Click);
            // 
            // LexicAnToolStripMenuItem
            // 
            this.LexicAnToolStripMenuItem.Name = "LexicAnToolStripMenuItem";
            this.LexicAnToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.LexicAnToolStripMenuItem.Text = "Лексический анализатор";
            this.LexicAnToolStripMenuItem.Click += new System.EventHandler(this.LexicAnToolStripMenuItem_Click);
            // 
            // RecurcsionToolStripMenuItem
            // 
            this.RecurcsionToolStripMenuItem.Name = "RecurcsionToolStripMenuItem";
            this.RecurcsionToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.RecurcsionToolStripMenuItem.Text = "Рекурcивный спуск";
            this.RecurcsionToolStripMenuItem.Click += new System.EventHandler(this.RecurcsionToolStripMenuItem_Click);
            // 
            // StartMenu
            // 
            this.StartMenu.Name = "StartMenu";
            this.StartMenu.Size = new System.Drawing.Size(55, 26);
            this.StartMenu.Text = "Пуск";
            // 
            // DocsMenu
            // 
            this.DocsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenDocsSubMenu,
            this.AboutSubMenu});
            this.DocsMenu.Name = "DocsMenu";
            this.DocsMenu.Size = new System.Drawing.Size(81, 26);
            this.DocsMenu.Text = "Справка";
            // 
            // OpenDocsSubMenu
            // 
            this.OpenDocsSubMenu.Name = "OpenDocsSubMenu";
            this.OpenDocsSubMenu.Size = new System.Drawing.Size(197, 26);
            this.OpenDocsSubMenu.Text = "Вызов справки";
            this.OpenDocsSubMenu.Click += new System.EventHandler(this.OpenDocsSubMenu_Click);
            // 
            // AboutSubMenu
            // 
            this.AboutSubMenu.Name = "AboutSubMenu";
            this.AboutSubMenu.Size = new System.Drawing.Size(197, 26);
            this.AboutSubMenu.Text = "О программе";
            this.AboutSubMenu.Click += new System.EventHandler(this.AboutSubMenu_Click);
            // 
            // BtnForward
            // 
            this.BtnForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnForward.BackgroundImage")));
            this.BtnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnForward.Location = new System.Drawing.Point(280, 43);
            this.BtnForward.Name = "BtnForward";
            this.BtnForward.Size = new System.Drawing.Size(34, 34);
            this.BtnForward.TabIndex = 5;
            this.BtnForward.UseVisualStyleBackColor = true;
            this.BtnForward.Click += new System.EventHandler(this.BtnForward_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnCopy.BackgroundImage")));
            this.BtnCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCopy.Location = new System.Drawing.Point(330, 43);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(34, 34);
            this.BtnCopy.TabIndex = 6;
            this.BtnCopy.UseVisualStyleBackColor = true;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // BtnCut
            // 
            this.BtnCut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnCut.BackgroundImage")));
            this.BtnCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCut.Location = new System.Drawing.Point(380, 43);
            this.BtnCut.Name = "BtnCut";
            this.BtnCut.Size = new System.Drawing.Size(34, 34);
            this.BtnCut.TabIndex = 7;
            this.BtnCut.UseVisualStyleBackColor = true;
            this.BtnCut.Click += new System.EventHandler(this.BtnCut_Click);
            // 
            // BtnPaste
            // 
            this.BtnPaste.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnPaste.BackgroundImage")));
            this.BtnPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnPaste.Location = new System.Drawing.Point(430, 43);
            this.BtnPaste.Name = "BtnPaste";
            this.BtnPaste.Size = new System.Drawing.Size(33, 33);
            this.BtnPaste.TabIndex = 8;
            this.BtnPaste.UseVisualStyleBackColor = true;
            this.BtnPaste.Click += new System.EventHandler(this.BtnPaste_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnOpen.BackgroundImage")));
            this.BtnOpen.Location = new System.Drawing.Point(80, 43);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(34, 34);
            this.BtnOpen.TabIndex = 3;
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnCreate
            // 
            this.BtnCreate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnCreate.BackgroundImage")));
            this.BtnCreate.Location = new System.Drawing.Point(30, 43);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(34, 34);
            this.BtnCreate.TabIndex = 2;
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // ButSave
            // 
            this.ButSave.BackColor = System.Drawing.Color.Transparent;
            this.ButSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButSave.BackgroundImage")));
            this.ButSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButSave.Location = new System.Drawing.Point(130, 43);
            this.ButSave.Name = "ButSave";
            this.ButSave.Size = new System.Drawing.Size(33, 33);
            this.ButSave.TabIndex = 1;
            this.ButSave.UseVisualStyleBackColor = false;
            this.ButSave.Click += new System.EventHandler(this.SaveItem_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnBack.BackgroundImage")));
            this.BtnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnBack.Location = new System.Drawing.Point(230, 43);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(34, 34);
            this.BtnBack.TabIndex = 9;
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(30, 77);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 16);
            this.labelName.TabIndex = 11;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(30, 111);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(960, 290);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Location = new System.Drawing.Point(30, 418);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox2.Size = new System.Drawing.Size(960, 223);
            this.richTextBox2.TabIndex = 14;
            this.richTextBox2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 703);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnPaste);
            this.Controls.Add(this.BtnCut);
            this.Controls.Add(this.BtnCopy);
            this.Controls.Add(this.BtnForward);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.BtnCreate);
            this.Controls.Add(this.ButSave);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Текстовый редактор";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExitItem_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem CreateItem;
        private System.Windows.Forms.ToolStripMenuItem OpenItem;
        private System.Windows.Forms.ToolStripMenuItem SaveItem;
        private System.Windows.Forms.ToolStripMenuItem SaveItemHow;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.ToolStripMenuItem FixMenu;
        private System.Windows.Forms.ToolStripMenuItem CancelFix;
        private System.Windows.Forms.ToolStripMenuItem RepeatFix;
        private System.Windows.Forms.ToolStripMenuItem CutFIx;
        private System.Windows.Forms.ToolStripMenuItem TextMenu;
        private System.Windows.Forms.ToolStripMenuItem StartMenu;
        private System.Windows.Forms.ToolStripMenuItem DocsMenu;
        private System.Windows.Forms.ToolStripMenuItem CopyFix;
        private System.Windows.Forms.ToolStripMenuItem PasteFix;
        private System.Windows.Forms.ToolStripMenuItem DeleteFix;
        private System.Windows.Forms.ToolStripMenuItem PickAllFix;
        private System.Windows.Forms.ToolStripMenuItem TaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem грамматикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem классификацияГрамматикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методАнализаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DiagnosticToolStrip;
        private System.Windows.Forms.ToolStripMenuItem тестовыйПримерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЛитературыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исходныйКодПрограммыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenDocsSubMenu;
        private System.Windows.Forms.ToolStripMenuItem AboutSubMenu;
        private System.Windows.Forms.Button ButSave;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnForward;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.Button BtnCut;
        private System.Windows.Forms.Button BtnPaste;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem RegexToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ToolStripMenuItem LexicAnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RecurcsionToolStripMenuItem;
    }
}

