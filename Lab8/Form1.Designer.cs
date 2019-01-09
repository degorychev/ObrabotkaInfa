namespace lab8
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
            this.ShowBMP = new System.Windows.Forms.PictureBox();
            this.FileList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NeuronList = new System.Windows.Forms.ListView();
            this.checkBoxLearn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ShowBMP)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowBMP
            // 
            this.ShowBMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShowBMP.Location = new System.Drawing.Point(12, 12);
            this.ShowBMP.Name = "ShowBMP";
            this.ShowBMP.Size = new System.Drawing.Size(450, 450);
            this.ShowBMP.TabIndex = 0;
            this.ShowBMP.TabStop = false;
            // 
            // FileList
            // 
            this.FileList.FormattingEnabled = true;
            this.FileList.Location = new System.Drawing.Point(471, 28);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(171, 485);
            this.FileList.TabIndex = 1;
            this.FileList.SelectedIndexChanged += new System.EventHandler(this.FileList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Список файлов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(645, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Веса нейронов:";
            // 
            // NeuronList
            // 
            this.NeuronList.Location = new System.Drawing.Point(648, 28);
            this.NeuronList.Name = "NeuronList";
            this.NeuronList.Size = new System.Drawing.Size(174, 486);
            this.NeuronList.TabIndex = 5;
            this.NeuronList.UseCompatibleStateImageBehavior = false;
            this.NeuronList.View = System.Windows.Forms.View.List;
            // 
            // checkBoxLearn
            // 
            this.checkBoxLearn.AutoSize = true;
            this.checkBoxLearn.Checked = true;
            this.checkBoxLearn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLearn.Location = new System.Drawing.Point(391, 468);
            this.checkBoxLearn.Name = "checkBoxLearn";
            this.checkBoxLearn.Size = new System.Drawing.Size(74, 17);
            this.checkBoxLearn.TabIndex = 6;
            this.checkBoxLearn.Text = "Обучение";
            this.checkBoxLearn.UseVisualStyleBackColor = true;
            this.checkBoxLearn.CheckedChanged += new System.EventHandler(this.checkBoxLearn_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 528);
            this.Controls.Add(this.checkBoxLearn);
            this.Controls.Add(this.NeuronList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.ShowBMP);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 567);
            this.MinimumSize = new System.Drawing.Size(850, 567);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Распознователь букв";
            ((System.ComponentModel.ISupportInitialize)(this.ShowBMP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ShowBMP;
        private System.Windows.Forms.ListBox FileList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView NeuronList;
        private System.Windows.Forms.CheckBox checkBoxLearn;
    }
}

