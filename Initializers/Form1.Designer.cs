namespace Initializers
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
            this.components = new System.ComponentModel.Container();
            this.cityLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.citiesComboBox = new System.Windows.Forms.ComboBox();
            this.citiesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.citiesAndNumbersSet = new Initializers.CitiesAndNumbersSet();
            this.citiesAndNumbersSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addingButton = new System.Windows.Forms.Button();
            this.citiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.citiesTableAdapter = new Initializers.CitiesAndNumbersSetTableAdapters.CitiesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.citiesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.citiesAndNumbersSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.citiesAndNumbersSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.citiesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cityLabel.Location = new System.Drawing.Point(145, 41);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(78, 25);
            this.cityLabel.TabIndex = 0;
            this.cityLabel.Text = "Город:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(164, 95);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(59, 25);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Имя:";
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneNumberLabel.Location = new System.Drawing.Point(34, 150);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(189, 25);
            this.phoneNumberLabel.TabIndex = 2;
            this.phoneNumberLabel.Text = "Номер телефона:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(229, 100);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(124, 20);
            this.nameTextBox.TabIndex = 3;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(229, 155);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(124, 20);
            this.phoneTextBox.TabIndex = 4;
            // 
            // citiesComboBox
            // 
            this.citiesComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.citiesBindingSource1, "Name", true));
            this.citiesComboBox.DataSource = this.citiesAndNumbersSetBindingSource;
            this.citiesComboBox.FormattingEnabled = true;
            this.citiesComboBox.Location = new System.Drawing.Point(229, 47);
            this.citiesComboBox.Name = "citiesComboBox";
            this.citiesComboBox.Size = new System.Drawing.Size(124, 21);
            this.citiesComboBox.TabIndex = 5;
            this.citiesComboBox.SelectedIndexChanged += new System.EventHandler(this.citiesComboBox_SelectedIndexChanged);
            // 
            // citiesBindingSource1
            // 
            this.citiesBindingSource1.DataMember = "Cities";
            this.citiesBindingSource1.DataSource = this.citiesAndNumbersSet;
            // 
            // citiesAndNumbersSet
            // 
            this.citiesAndNumbersSet.DataSetName = "CitiesAndNumbersSet";
            this.citiesAndNumbersSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // citiesAndNumbersSetBindingSource
            // 
            this.citiesAndNumbersSetBindingSource.DataSource = this.citiesAndNumbersSet;
            this.citiesAndNumbersSetBindingSource.Position = 0;
            // 
            // addingButton
            // 
            this.addingButton.Location = new System.Drawing.Point(208, 204);
            this.addingButton.Name = "addingButton";
            this.addingButton.Size = new System.Drawing.Size(75, 23);
            this.addingButton.TabIndex = 6;
            this.addingButton.Text = "Добавить";
            this.addingButton.UseVisualStyleBackColor = true;
            this.addingButton.Click += new System.EventHandler(this.addingButton_Click);
            // 
            // citiesBindingSource
            // 
            this.citiesBindingSource.DataMember = "Cities";
            this.citiesBindingSource.DataSource = this.citiesAndNumbersSet;
            // 
            // citiesTableAdapter
            // 
            this.citiesTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 264);
            this.Controls.Add(this.addingButton);
            this.Controls.Add(this.citiesComboBox);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.phoneNumberLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.cityLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.citiesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.citiesAndNumbersSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.citiesAndNumbersSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.citiesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.ComboBox citiesComboBox;
        private System.Windows.Forms.Button addingButton;
        private System.Windows.Forms.BindingSource citiesAndNumbersSetBindingSource;
        private CitiesAndNumbersSet citiesAndNumbersSet;
        private System.Windows.Forms.BindingSource citiesBindingSource;
        private CitiesAndNumbersSetTableAdapters.CitiesTableAdapter citiesTableAdapter;
        private System.Windows.Forms.BindingSource citiesBindingSource1;
    }
}

