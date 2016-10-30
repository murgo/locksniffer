using System.Windows.Forms;

namespace LockSniffer
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_lunch = new NumericTextBox();
            this.textBox_worktime = new NumericTextBox();
            this.label_lunch = new System.Windows.Forms.Label();
            this.label_worktime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowWeekNumbers = true;
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(18, 192);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(588, 229);
            this.textBox1.TabIndex = 1;
            // 
            // textBox_lunch
            // 
            this.textBox_lunch.Location = new System.Drawing.Point(505, 18);
            this.textBox_lunch.MaxLength = 5;
            this.textBox_lunch.Name = "textBox_lunch";
            this.textBox_lunch.Size = new System.Drawing.Size(100, 20);
            this.textBox_lunch.TabIndex = 2;
            this.textBox_lunch.KeyUp += new KeyEventHandler(UpdateList);
            // 
            // textBox_worktime
            // 
            this.textBox_worktime.Location = new System.Drawing.Point(506, 44);
            this.textBox_worktime.MaxLength = 5;
            this.textBox_worktime.Name = "textBox_worktime";
            this.textBox_worktime.Size = new System.Drawing.Size(100, 20);
            this.textBox_worktime.TabIndex = 3;
            this.textBox_worktime.KeyUp += new KeyEventHandler(UpdateList);
            // 
            // label_lunch
            // 
            this.label_lunch.AutoSize = true;
            this.label_lunch.Location = new System.Drawing.Point(431, 21);
            this.label_lunch.Name = "label_lunch";
            this.label_lunch.Size = new System.Drawing.Size(37, 13);
            this.label_lunch.TabIndex = 4;
            this.label_lunch.Text = "Lunch";
            // 
            // label_worktime
            // 
            this.label_worktime.AutoSize = true;
            this.label_worktime.Location = new System.Drawing.Point(431, 47);
            this.label_worktime.Name = "label_worktime";
            this.label_worktime.Size = new System.Drawing.Size(69, 13);
            this.label_worktime.TabIndex = 5;
            this.label_worktime.Text = "Working time";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 433);
            this.Controls.Add(this.label_worktime);
            this.Controls.Add(this.label_lunch);
            this.Controls.Add(this.textBox_worktime);
            this.Controls.Add(this.textBox_lunch);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "ReportForm";
            this.Text = "LockSniffer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox_lunch;
        private System.Windows.Forms.TextBox textBox_worktime;
        private System.Windows.Forms.Label label_lunch;
        private System.Windows.Forms.Label label_worktime;
    }
}