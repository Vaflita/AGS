namespace AZS
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            entryButton = new Button();
            entryLabel = new Label();
            numLabel = new Label();
            passLabel = new Label();
            numField = new TextBox();
            passwordField = new TextBox();
            SuspendLayout();
            // 
            // entryButton
            // 
            entryButton.Location = new Point(327, 286);
            entryButton.Name = "entryButton";
            entryButton.Size = new Size(124, 41);
            entryButton.TabIndex = 0;
            entryButton.Text = "Войти";
            entryButton.Click += entryButton_Click_1;
            // 
            // entryLabel
            // 
            entryLabel.AutoSize = true;
            entryLabel.Location = new Point(372, 104);
            entryLabel.Name = "entryLabel";
            entryLabel.Size = new Size(33, 15);
            entryLabel.TabIndex = 1;
            entryLabel.Text = "Вход";
            // 
            // numLabel
            // 
            numLabel.AutoSize = true;
            numLabel.Location = new Point(224, 163);
            numLabel.Name = "numLabel";
            numLabel.Size = new Size(101, 15);
            numLabel.TabIndex = 2;
            numLabel.Text = "Номер Автобазы";
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Location = new Point(224, 214);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(49, 15);
            passLabel.TabIndex = 3;
            passLabel.Text = "Пароль";
            // 
            // numField
            // 
            numField.Location = new Point(458, 163);
            numField.Name = "numField";
            numField.Size = new Size(103, 23);
            numField.TabIndex = 4;
            // 
            // passwordField
            // 
            passwordField.Location = new Point(458, 211);
            passwordField.Name = "passwordField";
            passwordField.Size = new Size(100, 23);
            passwordField.TabIndex = 5;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(passwordField);
            Controls.Add(numField);
            Controls.Add(passLabel);
            Controls.Add(numLabel);
            Controls.Add(entryLabel);
            Controls.Add(entryButton);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button entryButton;
        private Label entryLabel;
        private Label numLabel;
        private Label passLabel;
        private TextBox numField;
        private TextBox passwordField;
    }
}