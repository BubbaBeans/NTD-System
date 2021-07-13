<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SurveyEntry
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SurveyView = New System.Windows.Forms.DataGridView()
        Me.StopNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StopName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Odometer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PassBoard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PassDeboard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PassOnBoard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DistBetStop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PassMiles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerialLabel = New System.Windows.Forms.Label()
        Me.SerialTextBox = New System.Windows.Forms.TextBox()
        Me.DateLabel = New System.Windows.Forms.Label()
        Me.VehLabel = New System.Windows.Forms.Label()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.DayOfWeekLabel = New System.Windows.Forms.Label()
        Me.SeatedLabel = New System.Windows.Forms.Label()
        Me.TotalLabel = New System.Windows.Forms.Label()
        Me.TimeOfDayLabel = New System.Windows.Forms.TextBox()
        Me.ClearButt = New System.Windows.Forms.Button()
        Me.ImportButt = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.CapTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DOWTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TODTimer = New System.Windows.Forms.Timer(Me.components)
        Me.VehComboBox = New System.Windows.Forms.ComboBox()
        Me.SavedLabel = New System.Windows.Forms.TextBox()
        Me.SavedLabelTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.SurveyView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SurveyView
        '
        Me.SurveyView.AllowUserToAddRows = False
        Me.SurveyView.AllowUserToDeleteRows = False
        Me.SurveyView.AllowUserToResizeColumns = False
        Me.SurveyView.AllowUserToResizeRows = False
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SurveyView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle25
        Me.SurveyView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SurveyView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.SurveyView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SurveyView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.SurveyView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SurveyView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StopNo, Me.StopName, Me.Odometer, Me.PassBoard, Me.PassDeboard, Me.PassOnBoard, Me.DistBetStop, Me.PassMiles})
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SurveyView.DefaultCellStyle = DataGridViewCellStyle35
        Me.SurveyView.Location = New System.Drawing.Point(16, 97)
        Me.SurveyView.MultiSelect = False
        Me.SurveyView.Name = "SurveyView"
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SurveyView.RowHeadersDefaultCellStyle = DataGridViewCellStyle36
        Me.SurveyView.RowHeadersWidth = 12
        Me.SurveyView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.SurveyView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SurveyView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.SurveyView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.SurveyView.Size = New System.Drawing.Size(806, 784)
        Me.SurveyView.TabIndex = 5
        '
        'StopNo
        '
        Me.StopNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StopNo.DefaultCellStyle = DataGridViewCellStyle27
        Me.StopNo.FillWeight = 1.0!
        Me.StopNo.HeaderText = "Stop Number"
        Me.StopNo.MaxInputLength = 4
        Me.StopNo.Name = "StopNo"
        Me.StopNo.ReadOnly = True
        Me.StopNo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.StopNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.StopNo.Width = 60
        '
        'StopName
        '
        Me.StopName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.StopName.DefaultCellStyle = DataGridViewCellStyle28
        Me.StopName.HeaderText = "Stop Name"
        Me.StopName.Name = "StopName"
        Me.StopName.ReadOnly = True
        Me.StopName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.StopName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.StopName.Width = 82
        '
        'Odometer
        '
        Me.Odometer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Odometer.DefaultCellStyle = DataGridViewCellStyle29
        Me.Odometer.HeaderText = "Mileage"
        Me.Odometer.Name = "Odometer"
        Me.Odometer.ReadOnly = True
        Me.Odometer.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Odometer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Odometer.Visible = False
        '
        'PassBoard
        '
        Me.PassBoard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PassBoard.DefaultCellStyle = DataGridViewCellStyle30
        Me.PassBoard.HeaderText = "Passengers Boarded"
        Me.PassBoard.MaxInputLength = 3
        Me.PassBoard.Name = "PassBoard"
        Me.PassBoard.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PassBoard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PassBoard.Width = 90
        '
        'PassDeboard
        '
        Me.PassDeboard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PassDeboard.DefaultCellStyle = DataGridViewCellStyle31
        Me.PassDeboard.HeaderText = "Passengers Deboarded"
        Me.PassDeboard.MaxInputLength = 3
        Me.PassDeboard.Name = "PassDeboard"
        Me.PassDeboard.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PassDeboard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PassDeboard.Width = 90
        '
        'PassOnBoard
        '
        Me.PassOnBoard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PassOnBoard.DefaultCellStyle = DataGridViewCellStyle32
        Me.PassOnBoard.HeaderText = "Passengers On Board"
        Me.PassOnBoard.MaxInputLength = 5
        Me.PassOnBoard.Name = "PassOnBoard"
        Me.PassOnBoard.ReadOnly = True
        Me.PassOnBoard.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PassOnBoard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PassOnBoard.Width = 90
        '
        'DistBetStop
        '
        Me.DistBetStop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DistBetStop.DefaultCellStyle = DataGridViewCellStyle33
        Me.DistBetStop.HeaderText = "Dist Between Stops"
        Me.DistBetStop.MaxInputLength = 5
        Me.DistBetStop.Name = "DistBetStop"
        Me.DistBetStop.ReadOnly = True
        Me.DistBetStop.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DistBetStop.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DistBetStop.Width = 110
        '
        'PassMiles
        '
        Me.PassMiles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle34.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PassMiles.DefaultCellStyle = DataGridViewCellStyle34
        Me.PassMiles.HeaderText = "Passenger Miles"
        Me.PassMiles.MaxInputLength = 8
        Me.PassMiles.Name = "PassMiles"
        Me.PassMiles.ReadOnly = True
        Me.PassMiles.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PassMiles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PassMiles.Width = 136
        '
        'SerialLabel
        '
        Me.SerialLabel.AutoSize = True
        Me.SerialLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SerialLabel.Location = New System.Drawing.Point(13, 8)
        Me.SerialLabel.Name = "SerialLabel"
        Me.SerialLabel.Size = New System.Drawing.Size(46, 16)
        Me.SerialLabel.TabIndex = 6
        Me.SerialLabel.Text = "Serial:"
        '
        'SerialTextBox
        '
        Me.SerialTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SerialTextBox.Location = New System.Drawing.Point(64, 8)
        Me.SerialTextBox.Name = "SerialTextBox"
        Me.SerialTextBox.Size = New System.Drawing.Size(100, 20)
        Me.SerialTextBox.TabIndex = 1
        '
        'DateLabel
        '
        Me.DateLabel.AutoSize = True
        Me.DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateLabel.Location = New System.Drawing.Point(221, 8)
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Size = New System.Drawing.Size(40, 16)
        Me.DateLabel.TabIndex = 8
        Me.DateLabel.Text = "Date:"
        '
        'VehLabel
        '
        Me.VehLabel.AutoSize = True
        Me.VehLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VehLabel.Location = New System.Drawing.Point(505, 8)
        Me.VehLabel.Name = "VehLabel"
        Me.VehLabel.Size = New System.Drawing.Size(56, 16)
        Me.VehLabel.TabIndex = 10
        Me.VehLabel.Text = "Vehicle:"
        '
        'SaveButton
        '
        Me.SaveButton.Enabled = False
        Me.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SaveButton.Location = New System.Drawing.Point(845, 139)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveButton.TabIndex = 6
        Me.SaveButton.Text = "&Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'DayOfWeekLabel
        '
        Me.DayOfWeekLabel.AutoSize = True
        Me.DayOfWeekLabel.BackColor = System.Drawing.Color.Transparent
        Me.DayOfWeekLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DayOfWeekLabel.Location = New System.Drawing.Point(221, 28)
        Me.DayOfWeekLabel.Name = "DayOfWeekLabel"
        Me.DayOfWeekLabel.Size = New System.Drawing.Size(91, 16)
        Me.DayOfWeekLabel.TabIndex = 18
        Me.DayOfWeekLabel.Text = "Day Of Week:"
        '
        'SeatedLabel
        '
        Me.SeatedLabel.AutoSize = True
        Me.SeatedLabel.BackColor = System.Drawing.Color.Transparent
        Me.SeatedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SeatedLabel.Location = New System.Drawing.Point(505, 36)
        Me.SeatedLabel.Name = "SeatedLabel"
        Me.SeatedLabel.Size = New System.Drawing.Size(83, 16)
        Me.SeatedLabel.TabIndex = 19
        Me.SeatedLabel.Text = "Seated Cap:"
        '
        'TotalLabel
        '
        Me.TotalLabel.AutoSize = True
        Me.TotalLabel.BackColor = System.Drawing.Color.Transparent
        Me.TotalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalLabel.Location = New System.Drawing.Point(505, 67)
        Me.TotalLabel.Name = "TotalLabel"
        Me.TotalLabel.Size = New System.Drawing.Size(70, 16)
        Me.TotalLabel.TabIndex = 20
        Me.TotalLabel.Text = "Total Cap:"
        '
        'TimeOfDayLabel
        '
        Me.TimeOfDayLabel.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.TimeOfDayLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TimeOfDayLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeOfDayLabel.Location = New System.Drawing.Point(16, 34)
        Me.TimeOfDayLabel.Multiline = True
        Me.TimeOfDayLabel.Name = "TimeOfDayLabel"
        Me.TimeOfDayLabel.ReadOnly = True
        Me.TimeOfDayLabel.Size = New System.Drawing.Size(199, 57)
        Me.TimeOfDayLabel.TabIndex = 22
        Me.TimeOfDayLabel.TabStop = False
        Me.TimeOfDayLabel.Text = "Time Of Day:"
        '
        'ClearButt
        '
        Me.ClearButt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ClearButt.Location = New System.Drawing.Point(845, 189)
        Me.ClearButt.Name = "ClearButt"
        Me.ClearButt.Size = New System.Drawing.Size(75, 23)
        Me.ClearButt.TabIndex = 7
        Me.ClearButt.Text = "&Clear"
        Me.ClearButt.UseVisualStyleBackColor = True
        '
        'ImportButt
        '
        Me.ImportButt.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ImportButt.Enabled = False
        Me.ImportButt.Location = New System.Drawing.Point(267, 47)
        Me.ImportButt.Name = "ImportButt"
        Me.ImportButt.Size = New System.Drawing.Size(95, 44)
        Me.ImportButt.TabIndex = 4
        Me.ImportButt.Text = "Import"
        Me.ImportButt.UseMnemonic = False
        Me.ImportButt.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CausesValidation = False
        Me.DateTimePicker1.CustomFormat = "M/dd/yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(267, 8)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(127, 20)
        Me.DateTimePicker1.TabIndex = 2
        '
        'CapTimer
        '
        Me.CapTimer.Interval = 1
        '
        'DOWTimer
        '
        Me.DOWTimer.Interval = 1
        '
        'TODTimer
        '
        Me.TODTimer.Interval = 1
        '
        'VehComboBox
        '
        Me.VehComboBox.BackColor = System.Drawing.SystemColors.Window
        Me.VehComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.VehComboBox.FormattingEnabled = True
        Me.VehComboBox.Location = New System.Drawing.Point(567, 5)
        Me.VehComboBox.Name = "VehComboBox"
        Me.VehComboBox.Size = New System.Drawing.Size(89, 21)
        Me.VehComboBox.TabIndex = 3
        '
        'SavedLabel
        '
        Me.SavedLabel.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.SavedLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SavedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavedLabel.Location = New System.Drawing.Point(845, 97)
        Me.SavedLabel.Name = "SavedLabel"
        Me.SavedLabel.Size = New System.Drawing.Size(75, 24)
        Me.SavedLabel.TabIndex = 23
        Me.SavedLabel.TabStop = False
        Me.SavedLabel.Text = "SAVED"
        Me.SavedLabel.Visible = False
        '
        'SavedLabelTimer
        '
        Me.SavedLabelTimer.Interval = 1
        '
        'SurveyEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(972, 893)
        Me.Controls.Add(Me.SavedLabel)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.VehComboBox)
        Me.Controls.Add(Me.ClearButt)
        Me.Controls.Add(Me.TimeOfDayLabel)
        Me.Controls.Add(Me.ImportButt)
        Me.Controls.Add(Me.TotalLabel)
        Me.Controls.Add(Me.SeatedLabel)
        Me.Controls.Add(Me.DayOfWeekLabel)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.VehLabel)
        Me.Controls.Add(Me.DateLabel)
        Me.Controls.Add(Me.SerialTextBox)
        Me.Controls.Add(Me.SerialLabel)
        Me.Controls.Add(Me.SurveyView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "SurveyEntry"
        Me.Text = "Entering Surveys"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SurveyView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SurveyView As DataGridView
    Friend WithEvents StopNo As DataGridViewTextBoxColumn
    Friend WithEvents StopName As DataGridViewTextBoxColumn
    Friend WithEvents Odometer As DataGridViewTextBoxColumn
    Friend WithEvents PassBoard As DataGridViewTextBoxColumn
    Friend WithEvents PassDeboard As DataGridViewTextBoxColumn
    Friend WithEvents PassOnBoard As DataGridViewTextBoxColumn
    Friend WithEvents DistBetStop As DataGridViewTextBoxColumn
    Friend WithEvents PassMiles As DataGridViewTextBoxColumn
    Friend WithEvents SerialLabel As Label
    Friend WithEvents SerialTextBox As TextBox
    Friend WithEvents DateLabel As Label
    Friend WithEvents VehLabel As Label
    Friend WithEvents SaveButton As Button
    Friend WithEvents DayOfWeekLabel As Label
    Friend WithEvents SeatedLabel As Label
    Friend WithEvents TotalLabel As Label
    Friend WithEvents ImportButt As Button
    Friend WithEvents TimeOfDayLabel As TextBox
    Friend WithEvents ClearButt As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents CapTimer As Timer
    Friend WithEvents DOWTimer As Timer
    Friend WithEvents TODTimer As Timer
    Friend WithEvents VehComboBox As ComboBox
    Friend WithEvents SavedLabel As TextBox
    Friend WithEvents SavedLabelTimer As Timer
End Class
