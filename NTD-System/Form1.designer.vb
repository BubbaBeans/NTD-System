<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.sNum = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StartDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ctrlnWeeks = New System.Windows.Forms.NumericUpDown()
        Me.DoneButt = New System.Windows.Forms.Button()
        Me.ThruDate = New System.Windows.Forms.Label()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.Note = New System.Windows.Forms.Label()
        Me.SelectionNote = New System.Windows.Forms.Label()
        Me.StatusText = New System.Windows.Forms.RichTextBox()
        Me.batchBut = New System.Windows.Forms.Button()
        Me.Settings = New System.Windows.Forms.Button()
        Me.Oops = New System.Windows.Forms.Button()
        Me.AboutButt = New System.Windows.Forms.Button()
        CType(Me.sNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ctrlnWeeks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sNum
        '
        Me.sNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sNum.Location = New System.Drawing.Point(221, 102)
        Me.sNum.Maximum = New Decimal(New Integer() {35, 0, 0, 0})
        Me.sNum.Name = "sNum"
        Me.sNum.Size = New System.Drawing.Size(42, 26)
        Me.sNum.TabIndex = 3
        Me.sNum.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Number of surveys per week"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date to start surveys"
        '
        'StartDatePicker
        '
        Me.StartDatePicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.StartDatePicker.Location = New System.Drawing.Point(221, 13)
        Me.StartDatePicker.Name = "StartDatePicker"
        Me.StartDatePicker.Size = New System.Drawing.Size(127, 26)
        Me.StartDatePicker.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(83, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Number of weeks"
        '
        'ctrlnWeeks
        '
        Me.ctrlnWeeks.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctrlnWeeks.Location = New System.Drawing.Point(221, 59)
        Me.ctrlnWeeks.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.ctrlnWeeks.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ctrlnWeeks.Name = "ctrlnWeeks"
        Me.ctrlnWeeks.Size = New System.Drawing.Size(42, 26)
        Me.ctrlnWeeks.TabIndex = 2
        Me.ctrlnWeeks.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'DoneButt
        '
        Me.DoneButt.Location = New System.Drawing.Point(11, 357)
        Me.DoneButt.Name = "DoneButt"
        Me.DoneButt.Size = New System.Drawing.Size(75, 23)
        Me.DoneButt.TabIndex = 5
        Me.DoneButt.Text = "Print"
        Me.DoneButt.UseVisualStyleBackColor = True
        '
        'ThruDate
        '
        Me.ThruDate.AutoSize = True
        Me.ThruDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThruDate.Location = New System.Drawing.Point(269, 61)
        Me.ThruDate.Name = "ThruDate"
        Me.ThruDate.Size = New System.Drawing.Size(0, 20)
        Me.ThruDate.TabIndex = 10
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.MonthCalendar1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MonthCalendar1.Location = New System.Drawing.Point(11, 158)
        Me.MonthCalendar1.MaxSelectionCount = 120
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.ShowToday = False
        Me.MonthCalendar1.ShowTodayCircle = False
        Me.MonthCalendar1.TabIndex = 4
        Me.MonthCalendar1.TitleBackColor = System.Drawing.SystemColors.Highlight
        Me.MonthCalendar1.TitleForeColor = System.Drawing.Color.Red
        Me.MonthCalendar1.TrailingForeColor = System.Drawing.SystemColors.GradientActiveCaption
        '
        'Note
        '
        Me.Note.AutoSize = True
        Me.Note.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Note.Location = New System.Drawing.Point(354, 18)
        Me.Note.Name = "Note"
        Me.Note.Size = New System.Drawing.Size(220, 20)
        Me.Note.TabIndex = 12
        Me.Note.Text = "Note: Date must be a Monday"
        '
        'SelectionNote
        '
        Me.SelectionNote.AutoSize = True
        Me.SelectionNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectionNote.Location = New System.Drawing.Point(12, 329)
        Me.SelectionNote.Name = "SelectionNote"
        Me.SelectionNote.Size = New System.Drawing.Size(642, 20)
        Me.SelectionNote.TabIndex = 13
        Me.SelectionNote.Text = "Click on any days that the service isn't running.  No surveys will be printed for" &
    " bolded dates."
        '
        'StatusText
        '
        Me.StatusText.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.StatusText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StatusText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusText.Location = New System.Drawing.Point(93, 352)
        Me.StatusText.Name = "StatusText"
        Me.StatusText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.StatusText.Size = New System.Drawing.Size(508, 83)
        Me.StatusText.TabIndex = 14
        Me.StatusText.TabStop = False
        Me.StatusText.Text = ""
        '
        'batchBut
        '
        Me.batchBut.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.batchBut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.batchBut.Location = New System.Drawing.Point(11, 386)
        Me.batchBut.Name = "batchBut"
        Me.batchBut.Size = New System.Drawing.Size(75, 23)
        Me.batchBut.TabIndex = 15
        Me.batchBut.Text = "Batch"
        Me.batchBut.UseVisualStyleBackColor = False
        '
        'Settings
        '
        Me.Settings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Settings.BackgroundImage = Global.NTD_System.My.Resources.Resources.Gears
        Me.Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Settings.FlatAppearance.BorderSize = 0
        Me.Settings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.Settings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime
        Me.Settings.Location = New System.Drawing.Point(604, 380)
        Me.Settings.Margin = New System.Windows.Forms.Padding(0)
        Me.Settings.Name = "Settings"
        Me.Settings.Size = New System.Drawing.Size(34, 34)
        Me.Settings.TabIndex = 6
        Me.Settings.UseVisualStyleBackColor = True
        '
        'Oops
        '
        Me.Oops.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Oops.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Oops.Location = New System.Drawing.Point(12, 420)
        Me.Oops.Name = "Oops"
        Me.Oops.Size = New System.Drawing.Size(75, 23)
        Me.Oops.TabIndex = 16
        Me.Oops.Text = "Close"
        Me.Oops.UseVisualStyleBackColor = False
        '
        'AboutButt
        '
        Me.AboutButt.Location = New System.Drawing.Point(596, 420)
        Me.AboutButt.Name = "AboutButt"
        Me.AboutButt.Size = New System.Drawing.Size(49, 23)
        Me.AboutButt.TabIndex = 17
        Me.AboutButt.Text = "About"
        Me.AboutButt.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(657, 455)
        Me.Controls.Add(Me.AboutButt)
        Me.Controls.Add(Me.Oops)
        Me.Controls.Add(Me.batchBut)
        Me.Controls.Add(Me.StatusText)
        Me.Controls.Add(Me.SelectionNote)
        Me.Controls.Add(Me.Note)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.ThruDate)
        Me.Controls.Add(Me.DoneButt)
        Me.Controls.Add(Me.Settings)
        Me.Controls.Add(Me.ctrlnWeeks)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StartDatePicker)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.sNum)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "National Transit Database"
        CType(Me.sNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ctrlnWeeks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents sNum As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents StartDatePicker As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents ctrlnWeeks As NumericUpDown
    Friend WithEvents Settings As Button
    Friend WithEvents DoneButt As Button
    Friend WithEvents ThruDate As Label
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents Note As Label
    Friend WithEvents SelectionNote As Label
    Friend WithEvents StatusText As RichTextBox
    Friend WithEvents batchBut As Button
    Friend WithEvents Oops As Button
    Friend WithEvents AboutButt As Button
End Class
