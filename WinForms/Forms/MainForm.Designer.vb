<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PatientDataGridView = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Admin = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AddPatientButton = New System.Windows.Forms.Button()
        Me.SearchTextBox = New System.Windows.Forms.TextBox()
        Me.PESELRadioButton = New System.Windows.Forms.RadioButton()
        Me.SurnameRadioButton = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PreviousButton = New System.Windows.Forms.Button()
        Me.NextButton = New System.Windows.Forms.Button()
        Me.PageNumberLabel = New System.Windows.Forms.Label()
        Me.AreaCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PhoneNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SurnameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PESELDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PatientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.PatientDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PatientDataGridView
        '
        Me.PatientDataGridView.AutoGenerateColumns = False
        Me.PatientDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.PatientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PatientDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.SurnameDataGridViewTextBoxColumn, Me.EmailDataGridViewTextBoxColumn, Me.PESELDataGridViewTextBoxColumn, Me.AddressDataGridViewTextBoxColumn, Me.AreaCode, Me.PhoneNumber})
        Me.PatientDataGridView.DataSource = Me.PatientBindingSource
        Me.PatientDataGridView.Location = New System.Drawing.Point(12, 157)
        Me.PatientDataGridView.Name = "PatientDataGridView"
        Me.PatientDataGridView.Size = New System.Drawing.Size(927, 384)
        Me.PatientDataGridView.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.uWindowsApp.My.Resources.Resources.mini_logo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(188, 80)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Black", 20.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(345, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(309, 37)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Dashboard Pacjentów"
        '
        'Admin
        '
        Me.Admin.AutoSize = True
        Me.Admin.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.Admin.Location = New System.Drawing.Point(848, 31)
        Me.Admin.Name = "Admin"
        Me.Admin.Size = New System.Drawing.Size(55, 19)
        Me.Admin.TabIndex = 3
        Me.Admin.Text = "Admin"
        Me.Admin.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(807, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Zalogowano jako:"
        '
        'AddPatientButton
        '
        Me.AddPatientButton.BackColor = System.Drawing.Color.RoyalBlue
        Me.AddPatientButton.FlatAppearance.BorderSize = 0
        Me.AddPatientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddPatientButton.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.AddPatientButton.ForeColor = System.Drawing.Color.White
        Me.AddPatientButton.Location = New System.Drawing.Point(12, 577)
        Me.AddPatientButton.Name = "AddPatientButton"
        Me.AddPatientButton.Size = New System.Drawing.Size(927, 39)
        Me.AddPatientButton.TabIndex = 8
        Me.AddPatientButton.Text = "Dodaj Pacjenta"
        Me.AddPatientButton.UseVisualStyleBackColor = False
        '
        'SearchTextBox
        '
        Me.SearchTextBox.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.SearchTextBox.Location = New System.Drawing.Point(270, 114)
        Me.SearchTextBox.Name = "SearchTextBox"
        Me.SearchTextBox.Size = New System.Drawing.Size(541, 26)
        Me.SearchTextBox.TabIndex = 9
        '
        'PESELRadioButton
        '
        Me.PESELRadioButton.AutoSize = True
        Me.PESELRadioButton.Checked = True
        Me.PESELRadioButton.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.PESELRadioButton.Location = New System.Drawing.Point(171, 105)
        Me.PESELRadioButton.Name = "PESELRadioButton"
        Me.PESELRadioButton.Size = New System.Drawing.Size(68, 23)
        Me.PESELRadioButton.TabIndex = 10
        Me.PESELRadioButton.TabStop = True
        Me.PESELRadioButton.Text = "PESEL"
        Me.PESELRadioButton.UseVisualStyleBackColor = True
        '
        'SurnameRadioButton
        '
        Me.SurnameRadioButton.AutoSize = True
        Me.SurnameRadioButton.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.SurnameRadioButton.Location = New System.Drawing.Point(171, 128)
        Me.SurnameRadioButton.Name = "SurnameRadioButton"
        Me.SurnameRadioButton.Size = New System.Drawing.Size(93, 23)
        Me.SurnameRadioButton.TabIndex = 11
        Me.SurnameRadioButton.Text = "Nazwisko"
        Me.SurnameRadioButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 19)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Wyszukaj pacjenta:"
        '
        'SearchButton
        '
        Me.SearchButton.BackColor = System.Drawing.Color.RoyalBlue
        Me.SearchButton.FlatAppearance.BorderSize = 0
        Me.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SearchButton.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SearchButton.ForeColor = System.Drawing.Color.White
        Me.SearchButton.Location = New System.Drawing.Point(817, 114)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(122, 26)
        Me.SearchButton.TabIndex = 13
        Me.SearchButton.Text = "Szukaj"
        Me.SearchButton.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(397, 544)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 19)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Strona Numer:"
        '
        'PreviousButton
        '
        Me.PreviousButton.BackColor = System.Drawing.Color.RoyalBlue
        Me.PreviousButton.FlatAppearance.BorderSize = 0
        Me.PreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PreviousButton.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PreviousButton.ForeColor = System.Drawing.Color.White
        Me.PreviousButton.Location = New System.Drawing.Point(12, 544)
        Me.PreviousButton.Name = "PreviousButton"
        Me.PreviousButton.Size = New System.Drawing.Size(188, 26)
        Me.PreviousButton.TabIndex = 15
        Me.PreviousButton.Text = "← Poprzednia Strona"
        Me.PreviousButton.UseVisualStyleBackColor = False
        '
        'NextButton
        '
        Me.NextButton.BackColor = System.Drawing.Color.RoyalBlue
        Me.NextButton.FlatAppearance.BorderSize = 0
        Me.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NextButton.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.NextButton.ForeColor = System.Drawing.Color.White
        Me.NextButton.Location = New System.Drawing.Point(709, 544)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(230, 26)
        Me.NextButton.TabIndex = 16
        Me.NextButton.Text = "Następna Strona → "
        Me.NextButton.UseVisualStyleBackColor = False
        '
        'PageNumberLabel
        '
        Me.PageNumberLabel.AutoSize = True
        Me.PageNumberLabel.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.PageNumberLabel.Location = New System.Drawing.Point(513, 544)
        Me.PageNumberLabel.Name = "PageNumberLabel"
        Me.PageNumberLabel.Size = New System.Drawing.Size(17, 19)
        Me.PageNumberLabel.TabIndex = 17
        Me.PageNumberLabel.Text = "0"
        '
        'AreaCode
        '
        Me.AreaCode.DataPropertyName = "AreaCode"
        Me.AreaCode.HeaderText = "AreaCode"
        Me.AreaCode.Name = "AreaCode"
        '
        'PhoneNumber
        '
        Me.PhoneNumber.DataPropertyName = "PhoneNumber"
        Me.PhoneNumber.HeaderText = "PhoneNumber"
        Me.PhoneNumber.Name = "PhoneNumber"
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        '
        'SurnameDataGridViewTextBoxColumn
        '
        Me.SurnameDataGridViewTextBoxColumn.DataPropertyName = "Surname"
        Me.SurnameDataGridViewTextBoxColumn.HeaderText = "Surname"
        Me.SurnameDataGridViewTextBoxColumn.Name = "SurnameDataGridViewTextBoxColumn"
        '
        'EmailDataGridViewTextBoxColumn
        '
        Me.EmailDataGridViewTextBoxColumn.DataPropertyName = "Email"
        Me.EmailDataGridViewTextBoxColumn.HeaderText = "Email"
        Me.EmailDataGridViewTextBoxColumn.Name = "EmailDataGridViewTextBoxColumn"
        '
        'PESELDataGridViewTextBoxColumn
        '
        Me.PESELDataGridViewTextBoxColumn.DataPropertyName = "PESEL"
        Me.PESELDataGridViewTextBoxColumn.HeaderText = "PESEL"
        Me.PESELDataGridViewTextBoxColumn.Name = "PESELDataGridViewTextBoxColumn"
        '
        'AddressDataGridViewTextBoxColumn
        '
        Me.AddressDataGridViewTextBoxColumn.DataPropertyName = "Address"
        Me.AddressDataGridViewTextBoxColumn.HeaderText = "Address"
        Me.AddressDataGridViewTextBoxColumn.Name = "AddressDataGridViewTextBoxColumn"
        '
        'PatientBindingSource
        '
        Me.PatientBindingSource.DataSource = GetType(uWindowsApp.Entities.Patient)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(951, 628)
        Me.Controls.Add(Me.PageNumberLabel)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.PreviousButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SurnameRadioButton)
        Me.Controls.Add(Me.PESELRadioButton)
        Me.Controls.Add(Me.SearchTextBox)
        Me.Controls.Add(Me.AddPatientButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Admin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PatientDataGridView)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        CType(Me.PatientDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PatientDataGridView As DataGridView
    Friend WithEvents PatientBindingSource As BindingSource
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Admin As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents AddPatientButton As Button
    Friend WithEvents SearchTextBox As TextBox
    Friend WithEvents PESELRadioButton As RadioButton
    Friend WithEvents SurnameRadioButton As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents SearchButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents PreviousButton As Button
    Friend WithEvents NextButton As Button
    Friend WithEvents PageNumberLabel As Label
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SurnameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PESELDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AddressDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AreaCode As DataGridViewTextBoxColumn
    Friend WithEvents PhoneNumber As DataGridViewTextBoxColumn
End Class
