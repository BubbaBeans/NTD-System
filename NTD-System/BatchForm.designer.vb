<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BatchForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
		Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
		Me.StartDatePicker = New System.Windows.Forms.DateTimePicker()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.EndDatePicker = New System.Windows.Forms.DateTimePicker()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.NumbOfDays = New System.Windows.Forms.NumericUpDown()
		Me.EndingDateRadioButton = New System.Windows.Forms.RadioButton()
		Me.NoOfDaysRadioButton = New System.Windows.Forms.RadioButton()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.RunBatchButton = New System.Windows.Forms.Button()
		Me.BatchCancel = New System.Windows.Forms.Button()
		Me.BatchStatus = New System.Windows.Forms.RichTextBox()
		CType(Me.NumbOfDays, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'MonthCalendar1
		'
		Me.MonthCalendar1.Location = New System.Drawing.Point(18, 219)
		Me.MonthCalendar1.Name = "MonthCalendar1"
		Me.MonthCalendar1.TabIndex = 0
		Me.MonthCalendar1.TitleBackColor = System.Drawing.SystemColors.Highlight
		Me.MonthCalendar1.TitleForeColor = System.Drawing.Color.Red
		'
		'StartDatePicker
		'
		Me.StartDatePicker.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.StartDatePicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.StartDatePicker.Location = New System.Drawing.Point(145, 4)
		Me.StartDatePicker.Name = "StartDatePicker"
		Me.StartDatePicker.Size = New System.Drawing.Size(124, 26)
		Me.StartDatePicker.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(32, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(108, 20)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Starting Date:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(38, 83)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(102, 20)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "Ending Date:"
		'
		'EndDatePicker
		'
		Me.EndDatePicker.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.EndDatePicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.EndDatePicker.Location = New System.Drawing.Point(145, 78)
		Me.EndDatePicker.Name = "EndDatePicker"
		Me.EndDatePicker.Size = New System.Drawing.Size(124, 26)
		Me.EndDatePicker.TabIndex = 3
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.ForeColor = System.Drawing.SystemColors.MenuHighlight
		Me.Label3.Location = New System.Drawing.Point(113, 116)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(57, 20)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "- OR -"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.Location = New System.Drawing.Point(42, 151)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(98, 20)
		Me.Label4.TabIndex = 7
		Me.Label4.Text = "No. Of Days:"
		'
		'NumbOfDays
		'
		Me.NumbOfDays.Enabled = False
		Me.NumbOfDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NumbOfDays.Location = New System.Drawing.Point(146, 149)
		Me.NumbOfDays.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
		Me.NumbOfDays.Name = "NumbOfDays"
		Me.NumbOfDays.Size = New System.Drawing.Size(53, 26)
		Me.NumbOfDays.TabIndex = 8
		Me.NumbOfDays.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'EndingDateRadioButton
		'
		Me.EndingDateRadioButton.AutoSize = True
		Me.EndingDateRadioButton.Checked = True
		Me.EndingDateRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.EndingDateRadioButton.Location = New System.Drawing.Point(18, 87)
		Me.EndingDateRadioButton.Name = "EndingDateRadioButton"
		Me.EndingDateRadioButton.Size = New System.Drawing.Size(14, 13)
		Me.EndingDateRadioButton.TabIndex = 9
		Me.EndingDateRadioButton.TabStop = True
		Me.EndingDateRadioButton.UseVisualStyleBackColor = True
		'
		'NoOfDaysRadioButton
		'
		Me.NoOfDaysRadioButton.AutoSize = True
		Me.NoOfDaysRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.NoOfDaysRadioButton.Location = New System.Drawing.Point(18, 155)
		Me.NoOfDaysRadioButton.Name = "NoOfDaysRadioButton"
		Me.NoOfDaysRadioButton.Size = New System.Drawing.Size(14, 13)
		Me.NoOfDaysRadioButton.TabIndex = 10
		Me.NoOfDaysRadioButton.UseVisualStyleBackColor = True
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.ForeColor = System.Drawing.SystemColors.MenuHighlight
		Me.Label5.Location = New System.Drawing.Point(113, 49)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(68, 20)
		Me.Label5.TabIndex = 11
		Me.Label5.Text = "- AND -"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.Location = New System.Drawing.Point(15, 197)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(742, 20)
		Me.Label6.TabIndex = 12
		Me.Label6.Text = "Note: Dates in bold will not have surveys printed. Click any days the service is " &
	"not operating."
		'
		'RunBatchButton
		'
		Me.RunBatchButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RunBatchButton.Location = New System.Drawing.Point(145, 407)
		Me.RunBatchButton.Name = "RunBatchButton"
		Me.RunBatchButton.Size = New System.Drawing.Size(100, 31)
		Me.RunBatchButton.TabIndex = 13
		Me.RunBatchButton.Text = "Run Batch"
		Me.RunBatchButton.UseVisualStyleBackColor = True
		'
		'BatchCancel
		'
		Me.BatchCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BatchCancel.Location = New System.Drawing.Point(284, 407)
		Me.BatchCancel.Name = "BatchCancel"
		Me.BatchCancel.Size = New System.Drawing.Size(85, 31)
		Me.BatchCancel.TabIndex = 14
		Me.BatchCancel.Text = "Cancel"
		Me.BatchCancel.UseVisualStyleBackColor = True
		'
		'BatchStatus
		'
		Me.BatchStatus.BackColor = System.Drawing.SystemColors.AppWorkspace
		Me.BatchStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.BatchStatus.CausesValidation = False
		Me.BatchStatus.Cursor = System.Windows.Forms.Cursors.Default
		Me.BatchStatus.Location = New System.Drawing.Point(407, 12)
		Me.BatchStatus.Name = "BatchStatus"
		Me.BatchStatus.Size = New System.Drawing.Size(381, 159)
		Me.BatchStatus.TabIndex = 15
		Me.BatchStatus.TabStop = False
		Me.BatchStatus.Text = ""
		'
		'BatchForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.AppWorkspace
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Controls.Add(Me.BatchStatus)
		Me.Controls.Add(Me.BatchCancel)
		Me.Controls.Add(Me.RunBatchButton)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.NoOfDaysRadioButton)
		Me.Controls.Add(Me.EndingDateRadioButton)
		Me.Controls.Add(Me.NumbOfDays)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.EndDatePicker)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.StartDatePicker)
		Me.Controls.Add(Me.MonthCalendar1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.Name = "BatchForm"
		Me.Text = "Batch of Surveys"
		CType(Me.NumbOfDays, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents StartDatePicker As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents EndDatePicker As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents NumbOfDays As NumericUpDown
    Friend WithEvents EndingDateRadioButton As RadioButton
    Friend WithEvents NoOfDaysRadioButton As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents RunBatchButton As Button
    Friend WithEvents BatchCancel As Button
    Friend WithEvents BatchStatus As RichTextBox
End Class
