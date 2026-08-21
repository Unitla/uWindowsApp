<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PatientForm
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
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.SurnameTextBox = New System.Windows.Forms.TextBox()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.PESELTextBox = New System.Windows.Forms.TextBox()
        Me.AddressTextBox = New System.Windows.Forms.TextBox()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SavePatientButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.AreaCodeTextBox = New System.Windows.Forms.TextBox()
        Me.PhoneNumberTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'NameTextBox
        '
        Me.NameTextBox.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.NameTextBox.Location = New System.Drawing.Point(12, 30)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(413, 26)
        Me.NameTextBox.TabIndex = 10
        '
        'SurnameTextBox
        '
        Me.SurnameTextBox.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.SurnameTextBox.Location = New System.Drawing.Point(12, 83)
        Me.SurnameTextBox.Name = "SurnameTextBox"
        Me.SurnameTextBox.Size = New System.Drawing.Size(413, 26)
        Me.SurnameTextBox.TabIndex = 11
        '
        'EmailTextBox
        '
        Me.EmailTextBox.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.EmailTextBox.Location = New System.Drawing.Point(12, 138)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(413, 26)
        Me.EmailTextBox.TabIndex = 12
        '
        'PESELTextBox
        '
        Me.PESELTextBox.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.PESELTextBox.Location = New System.Drawing.Point(12, 188)
        Me.PESELTextBox.Name = "PESELTextBox"
        Me.PESELTextBox.Size = New System.Drawing.Size(413, 26)
        Me.PESELTextBox.TabIndex = 13
        '
        'AddressTextBox
        '
        Me.AddressTextBox.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.AddressTextBox.Location = New System.Drawing.Point(12, 242)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(413, 26)
        Me.AddressTextBox.TabIndex = 14
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.NameLabel.Location = New System.Drawing.Point(8, 8)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(43, 19)
        Me.NameLabel.TabIndex = 15
        Me.NameLabel.Text = "Imię:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 19)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Nazwisko:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(8, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 19)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Email:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(8, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 19)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "PESEL:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(8, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 19)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Adres:"
        '
        'SavePatientButton
        '
        Me.SavePatientButton.BackColor = System.Drawing.Color.RoyalBlue
        Me.SavePatientButton.FlatAppearance.BorderSize = 0
        Me.SavePatientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SavePatientButton.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.SavePatientButton.ForeColor = System.Drawing.Color.White
        Me.SavePatientButton.Location = New System.Drawing.Point(12, 425)
        Me.SavePatientButton.Name = "SavePatientButton"
        Me.SavePatientButton.Size = New System.Drawing.Size(413, 29)
        Me.SavePatientButton.TabIndex = 20
        Me.SavePatientButton.Text = "Zapisz Pacjenta"
        Me.SavePatientButton.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(8, 325)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 19)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Numer kierunkowy"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.Label6.Location = New System.Drawing.Point(8, 275)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 19)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Numer telefonu:"
        '
        'AreaCodeTextBox
        '
        Me.AreaCodeTextBox.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.AreaCodeTextBox.Location = New System.Drawing.Point(12, 350)
        Me.AreaCodeTextBox.Name = "AreaCodeTextBox"
        Me.AreaCodeTextBox.Size = New System.Drawing.Size(413, 26)
        Me.AreaCodeTextBox.TabIndex = 22
        '
        'PhoneNumberTextBox
        '
        Me.PhoneNumberTextBox.Font = New System.Drawing.Font("Segoe UI Black", 10.0!)
        Me.PhoneNumberTextBox.Location = New System.Drawing.Point(12, 296)
        Me.PhoneNumberTextBox.Name = "PhoneNumberTextBox"
        Me.PhoneNumberTextBox.Size = New System.Drawing.Size(413, 26)
        Me.PhoneNumberTextBox.TabIndex = 21
        '
        'PatientForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 466)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.AreaCodeTextBox)
        Me.Controls.Add(Me.PhoneNumberTextBox)
        Me.Controls.Add(Me.SavePatientButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.AddressTextBox)
        Me.Controls.Add(Me.PESELTextBox)
        Me.Controls.Add(Me.EmailTextBox)
        Me.Controls.Add(Me.SurnameTextBox)
        Me.Controls.Add(Me.NameTextBox)
        Me.Name = "PatientForm"
        Me.RightToLeftLayout = True
        Me.Text = "PatientForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents SurnameTextBox As TextBox
    Friend WithEvents EmailTextBox As TextBox
    Friend WithEvents PESELTextBox As TextBox
    Friend WithEvents AddressTextBox As TextBox
    Friend WithEvents NameLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents SavePatientButton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents AreaCodeTextBox As TextBox
    Friend WithEvents PhoneNumberTextBox As TextBox
End Class
