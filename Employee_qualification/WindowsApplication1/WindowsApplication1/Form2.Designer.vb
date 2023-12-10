<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.lblnic = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbac = New System.Windows.Forms.ComboBox()
        Me.AcofficeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Employee_detailsDataSet = New WindowsApplication1.Employee_detailsDataSet()
        Me.txtnic = New System.Windows.Forms.TextBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.btninsert = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.dtview = New System.Windows.Forms.DataGridView()
        Me.Ac_officeTableAdapter = New WindowsApplication1.Employee_detailsDataSetTableAdapters.Ac_officeTableAdapter()
        CType(Me.AcofficeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Employee_detailsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblnic
        '
        Me.lblnic.AutoSize = True
        Me.lblnic.BackColor = System.Drawing.SystemColors.Window
        Me.lblnic.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnic.Location = New System.Drawing.Point(23, 65)
        Me.lblnic.Name = "lblnic"
        Me.lblnic.Size = New System.Drawing.Size(55, 22)
        Me.lblnic.TabIndex = 0
        Me.lblnic.Text = "NIC :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Office Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name :"
        '
        'cmbac
        '
        Me.cmbac.DataSource = Me.AcofficeBindingSource
        Me.cmbac.DisplayMember = "Ac_office_name"
        Me.cmbac.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbac.FormattingEnabled = True
        Me.cmbac.Location = New System.Drawing.Point(152, 17)
        Me.cmbac.Name = "cmbac"
        Me.cmbac.Size = New System.Drawing.Size(248, 29)
        Me.cmbac.TabIndex = 3
        '
        'AcofficeBindingSource
        '
        Me.AcofficeBindingSource.DataMember = "Ac_office"
        Me.AcofficeBindingSource.DataSource = Me.Employee_detailsDataSet
        '
        'Employee_detailsDataSet
        '
        Me.Employee_detailsDataSet.DataSetName = "Employee_detailsDataSet"
        Me.Employee_detailsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtnic
        '
        Me.txtnic.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnic.Location = New System.Drawing.Point(152, 58)
        Me.txtnic.Name = "txtnic"
        Me.txtnic.Size = New System.Drawing.Size(248, 29)
        Me.txtnic.TabIndex = 4
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(152, 101)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(248, 29)
        Me.txtname.TabIndex = 5
        '
        'btninsert
        '
        Me.btninsert.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btninsert.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btninsert.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btninsert.Location = New System.Drawing.Point(47, 159)
        Me.btninsert.Name = "btninsert"
        Me.btninsert.Size = New System.Drawing.Size(88, 34)
        Me.btninsert.TabIndex = 6
        Me.btninsert.Text = "Insert"
        Me.btninsert.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btndelete.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btndelete.Location = New System.Drawing.Point(170, 159)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(88, 34)
        Me.btndelete.TabIndex = 7
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnclose.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnclose.Location = New System.Drawing.Point(283, 159)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(88, 34)
        Me.btnclose.TabIndex = 8
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'dtview
        '
        Me.dtview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtview.Location = New System.Drawing.Point(27, 218)
        Me.dtview.Name = "dtview"
        Me.dtview.Size = New System.Drawing.Size(373, 210)
        Me.dtview.TabIndex = 9
        '
        'Ac_officeTableAdapter
        '
        Me.Ac_officeTableAdapter.ClearBeforeFill = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.vecteezy_abstract_blue_and_gray_wave_background_
        Me.ClientSize = New System.Drawing.Size(436, 455)
        Me.Controls.Add(Me.dtview)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btninsert)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.txtnic)
        Me.Controls.Add(Me.cmbac)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblnic)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        CType(Me.AcofficeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Employee_detailsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblnic As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbac As ComboBox
    Friend WithEvents txtnic As TextBox
    Friend WithEvents txtname As TextBox
    Friend WithEvents btninsert As Button
    Friend WithEvents btndelete As Button
    Friend WithEvents btnclose As Button
    Friend WithEvents dtview As DataGridView
    Friend WithEvents Employee_detailsDataSet As Employee_detailsDataSet
    Friend WithEvents AcofficeBindingSource As BindingSource
    Friend WithEvents Ac_officeTableAdapter As Employee_detailsDataSetTableAdapters.Ac_officeTableAdapter
End Class
