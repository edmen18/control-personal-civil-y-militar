<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblidentidad = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblmaterno = New System.Windows.Forms.Label()
        Me.lblpaterno = New System.Windows.Forms.Label()
        Me.lblnombre = New System.Windows.Forms.Label()
        Me.lblcodigo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstpaciente = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TXTDATO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rbna = New System.Windows.Forms.RadioButton()
        Me.RbDoc = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        'Me.EnrollmentControl = New DPFP.Gui.Enrollment.EnrollmentControl()
        Me.btnver = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(13, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(595, 378)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnver)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.lstpaciente)
        Me.TabPage1.Controls.Add(Me.TXTDATO)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(587, 352)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Busqueda"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btncancelar)
        Me.GroupBox2.Controls.Add(Me.lblidentidad)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblmaterno)
        Me.GroupBox2.Controls.Add(Me.lblpaterno)
        Me.GroupBox2.Controls.Add(Me.lblnombre)
        Me.GroupBox2.Controls.Add(Me.lblcodigo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 208)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(555, 138)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Paciente"
        '
        'lblidentidad
        '
        Me.lblidentidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblidentidad.Location = New System.Drawing.Point(73, 112)
        Me.lblidentidad.Name = "lblidentidad"
        Me.lblidentidad.Size = New System.Drawing.Size(476, 20)
        Me.lblidentidad.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Identidad"
        '
        'lblmaterno
        '
        Me.lblmaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblmaterno.Location = New System.Drawing.Point(73, 89)
        Me.lblmaterno.Name = "lblmaterno"
        Me.lblmaterno.Size = New System.Drawing.Size(476, 20)
        Me.lblmaterno.TabIndex = 7
        '
        'lblpaterno
        '
        Me.lblpaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblpaterno.Location = New System.Drawing.Point(73, 66)
        Me.lblpaterno.Name = "lblpaterno"
        Me.lblpaterno.Size = New System.Drawing.Size(476, 20)
        Me.lblpaterno.TabIndex = 6
        '
        'lblnombre
        '
        Me.lblnombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblnombre.Location = New System.Drawing.Point(73, 44)
        Me.lblnombre.Name = "lblnombre"
        Me.lblnombre.Size = New System.Drawing.Size(476, 20)
        Me.lblnombre.TabIndex = 5
        '
        'lblcodigo
        '
        Me.lblcodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblcodigo.Location = New System.Drawing.Point(73, 19)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(396, 20)
        Me.lblcodigo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Ap. Materno"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Ap. Paterno"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Código"
        '
        'lstpaciente
        '
        Me.lstpaciente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstpaciente.FullRowSelect = True
        Me.lstpaciente.GridLines = True
        Me.lstpaciente.HideSelection = False
        Me.lstpaciente.Location = New System.Drawing.Point(10, 100)
        Me.lstpaciente.Name = "lstpaciente"
        Me.lstpaciente.Size = New System.Drawing.Size(556, 102)
        Me.lstpaciente.TabIndex = 3
        Me.lstpaciente.UseCompatibleStateImageBehavior = False
        Me.lstpaciente.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width = 67
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width = 124
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Apellido Pat."
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Apellido Mat."
        Me.ColumnHeader4.Width = 144
        '
        'TXTDATO
        '
        Me.TXTDATO.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TXTDATO.Location = New System.Drawing.Point(112, 70)
        Me.TXTDATO.Name = "TXTDATO"
        Me.TXTDATO.Size = New System.Drawing.Size(406, 20)
        Me.TXTDATO.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ingrese el Dato"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rbna)
        Me.GroupBox1.Controls.Add(Me.RbDoc)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(557, 45)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'Rbna
        '
        Me.Rbna.AutoSize = True
        Me.Rbna.Location = New System.Drawing.Point(199, 21)
        Me.Rbna.Name = "Rbna"
        Me.Rbna.Size = New System.Drawing.Size(102, 17)
        Me.Rbna.TabIndex = 1
        Me.Rbna.TabStop = True
        Me.Rbna.Text = "Nombre Apellido"
        Me.Rbna.UseVisualStyleBackColor = True
        '
        'RbDoc
        '
        Me.RbDoc.AutoSize = True
        Me.RbDoc.Location = New System.Drawing.Point(21, 21)
        Me.RbDoc.Name = "RbDoc"
        Me.RbDoc.Size = New System.Drawing.Size(92, 17)
        Me.RbDoc.TabIndex = 0
        Me.RbDoc.TabStop = True
        Me.RbDoc.Text = "Doc Identidad"
        Me.RbDoc.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        'Me.TabPage2.Controls.Add(Me.EnrollmentControl)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(587, 352)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Registro"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'EnrollmentControl
        '
        'Me.EnrollmentControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        'Me.EnrollmentControl.EnrolledFingerMask = 0
        'Me.EnrollmentControl.Location = New System.Drawing.Point(34, 17)
        'Me.EnrollmentControl.MaxEnrollFingerCount = 10
        'Me.EnrollmentControl.Name = "EnrollmentControl"
        'Me.EnrollmentControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000"
        'Me.EnrollmentControl.Size = New System.Drawing.Size(492, 314)
        'Me.EnrollmentControl.TabIndex = 5
        '
        'btnver
        '
        Me.btnver.Image = Global.ejemploHuella.My.Resources.Resources._94
        Me.btnver.Location = New System.Drawing.Point(525, 57)
        Me.btnver.Name = "btnver"
        Me.btnver.Size = New System.Drawing.Size(42, 39)
        Me.btnver.TabIndex = 5
        Me.btnver.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.Image = Global.ejemploHuella.My.Resources.Resources._19s
        Me.btncancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancelar.Location = New System.Drawing.Point(474, 16)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(75, 23)
        Me.btncancelar.TabIndex = 10
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 408)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "Registro de Huella digital"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TXTDATO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rbna As System.Windows.Forms.RadioButton
    Friend WithEvents RbDoc As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lstpaciente As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnver As System.Windows.Forms.Button
    Friend WithEvents lblmaterno As System.Windows.Forms.Label
    Friend WithEvents lblpaterno As System.Windows.Forms.Label
    Friend WithEvents lblnombre As System.Windows.Forms.Label
    Friend WithEvents lblcodigo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblidentidad As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    'Friend WithEvents EnrollmentControl As DPFP.Gui.Enrollment.EnrollmentControl
    Friend WithEvents btncancelar As System.Windows.Forms.Button

End Class
