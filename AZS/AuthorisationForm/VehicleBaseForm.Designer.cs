namespace UI
{
    partial class VehicleBaseForm
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            lowFuelButton = new Button();
            allButton = new Button();
            sendButton = new Button();
            allAzsButton = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(216, 216, 216);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(73, 87);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(675, 287);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // lowFuelButton
            // 
            lowFuelButton.Location = new Point(73, 412);
            lowFuelButton.Name = "lowFuelButton";
            lowFuelButton.Size = new Size(163, 41);
            lowFuelButton.TabIndex = 1;
            lowFuelButton.Text = "Низкий уровень топлива";
            lowFuelButton.UseVisualStyleBackColor = true;
            lowFuelButton.Click += lowFuelButton_Click;
            // 
            // allButton
            // 
            allButton.Location = new Point(73, 474);
            allButton.Name = "allButton";
            allButton.Size = new Size(163, 41);
            allButton.TabIndex = 2;
            allButton.Text = "Показать все";
            allButton.UseVisualStyleBackColor = true;
            allButton.Click += allButton_Click;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(549, 412);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(199, 103);
            sendButton.TabIndex = 3;
            sendButton.Text = "Отправить на заправку с низким уровнем топлива";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // allAzsButton
            // 
            allAzsButton.Location = new Point(274, 412);
            allAzsButton.Name = "allAzsButton";
            allAzsButton.Size = new Size(163, 41);
            allAzsButton.TabIndex = 4;
            allAzsButton.Text = "Все АЗС";
            allAzsButton.UseVisualStyleBackColor = true;
            allAzsButton.Click += allAzsButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 39);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // VehicleBaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1145, 608);
            Controls.Add(label2);
            Controls.Add(allAzsButton);
            Controls.Add(sendButton);
            Controls.Add(allButton);
            Controls.Add(lowFuelButton);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "VehicleBaseForm";
            Text = "VehicleBaseForm";
            Load += VehicleBaseForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button lowFuelButton;
        private Button allButton;
        private Button sendButton;
        private Button allAzsButton;
        private Label label2;
    }
}