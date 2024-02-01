<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Verificacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        'Me.VerificationControl = New DPFP.Gui.Verification.VerificationControl()
        Me.lblnhc = New System.Windows.Forms.Label()
        Me.lblcodigo = New System.Windows.Forms.Label()
        Me.lsthuella = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LBLDATO = New System.Windows.Forms.Label()
        Me.LBLHORA = New System.Windows.Forms.Label()
        Me.LBLTURNO = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'VerificationControl
        '
        'Me.VerificationControl.Active = True
        'Me.VerificationControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        'Me.VerificationControl.Location = New System.Drawing.Point(38, 22)
        'Me.VerificationControl.Name = "VerificationControl"
        'Me.VerificationControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000"
        'Me.VerificationControl.Size = New System.Drawing.Size(48, 47)
        'Me.VerificationControl.TabIndex = 7
        '
        'lblnhc
        '
        Me.lblnhc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblnhc.Location = New System.Drawing.Point(406, 47)
        Me.lblnhc.Name = "lblnhc"
        Me.lblnhc.Size = New System.Drawing.Size(179, 23)
        Me.lblnhc.TabIndex = 20
        '
        'lblcodigo
        '
        Me.lblcodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblcodigo.Location = New System.Drawing.Point(111, 47)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(289, 23)
        Me.lblcodigo.TabIndex = 19
        '
        'lsthuella
        '
        Me.lsthuella.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lsthuella.Location = New System.Drawing.Point(547, 56)
        Me.lsthuella.Name = "lsthuella"
        Me.lsthuella.Size = New System.Drawing.Size(17, 14)
        Me.lsthuella.TabIndex = 17
        Me.lsthuella.UseCompatibleStateImageBehavior = False
        Me.lsthuella.View = System.Windows.Forms.View.Details
        Me.lsthuella.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Codcli"
        Me.ColumnHeader1.Width = 120
        '
        'LBLDATO
        '
        Me.LBLDATO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBLDATO.Location = New System.Drawing.Point(111, 22)
        Me.LBLDATO.Name = "LBLDATO"
        Me.LBLDATO.Size = New System.Drawing.Size(474, 23)
        Me.LBLDATO.TabIndex = 16
        '
        'LBLHORA
        '
        Me.LBLHORA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBLHORA.Location = New System.Drawing.Point(546, 73)
        Me.LBLHORA.Name = "LBLHORA"
        Me.LBLHORA.Size = New System.Drawing.Size(18, 10)
        Me.LBLHORA.TabIndex = 21
        Me.LBLHORA.Visible = False
        '
        'LBLTURNO
        '
        Me.LBLTURNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBLTURNO.Location = New System.Drawing.Point(455, 107)
        Me.LBLTURNO.Name = "LBLTURNO"
        Me.LBLTURNO.Size = New System.Drawing.Size(39, 27)
        Me.LBLTURNO.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(111, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(474, 23)
        Me.Label1.TabIndex = 23
        '
        'Verificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 142)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LBLTURNO)
        Me.Controls.Add(Me.LBLHORA)
        Me.Controls.Add(Me.lblnhc)
        Me.Controls.Add(Me.lblcodigo)
        Me.Controls.Add(Me.lsthuella)
        Me.Controls.Add(Me.LBLDATO)
        'Me.Controls.Add(Me.VerificationControl)
        Me.Name = "Verificacion"
        Me.Text = "Asistencia"
        Me.ResumeLayout(False)

    End Sub
    'Friend WithEvents VerificationControl As DPFP.Gui.Verification.VerificationControl
    Friend WithEvents lblnhc As System.Windows.Forms.Label
    Friend WithEvents lblcodigo As System.Windows.Forms.Label
    Friend WithEvents lsthuella As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LBLDATO As System.Windows.Forms.Label
    Friend WithEvents LBLHORA As System.Windows.Forms.Label
    Friend WithEvents LBLTURNO As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
