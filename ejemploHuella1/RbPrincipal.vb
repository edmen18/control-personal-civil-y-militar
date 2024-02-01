Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports System.Diagnostics
Imports DevExpress.XtraEditors
Imports DevExpress.Skins
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Ribbon.Gallery
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils
Imports DevExpress.Utils.Controls
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraTab
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraBars
Imports Reglas
Imports Reportes
Public Class RbPrincipal
    Dim imp As New C_imprime
    Dim asi As New Cl_ASISTENCIA
    Dim ar As New Cl_area
    Dim P As New Cl_personal
    Dim per As New Cl_permisos
    Dim vac As New Cl_vacaciones
    Public Sub New()
        InitializeComponent()
        InitSkinGallery()
        UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue")
    End Sub

    Private Sub InitSkinGallery()
        Dim imageButton As SimpleButton = New SimpleButton()
        For Each cnt As SkinContainer In SkinManager.Default.Skins
            imageButton.LookAndFeel.SetSkinStyle(cnt.SkinName)
            Dim gItem As GalleryItem = New GalleryItem()
            Dim groupIndex As Integer = 0
            If cnt.SkinName.Contains("office") Then
                groupIndex = 1
            End If
            rgbiSkins.Gallery.Groups(groupIndex).Items.Add(gItem)
            gItem.Caption = cnt.SkinName

            gItem.Image = GetSkinImage(imageButton, 32, 17, 2)
            gItem.HoverImage = GetSkinImage(imageButton, 70, 36, 5)
            gItem.Caption = cnt.SkinName
            gItem.Hint = cnt.SkinName
        Next cnt
        rgbiSkins.Gallery.Groups(1).Visible = False
        rgbiSkins.Gallery.Groups(2).Visible = False
    End Sub
    Private Function GetSkinImage(ByVal button As SimpleButton, ByVal width As Integer, ByVal height As Integer, ByVal indent As Integer) As Bitmap
        Dim image As Bitmap = New Bitmap(width, height)
        Using g As Graphics = Graphics.FromImage(image)
            Dim info As StyleObjectInfoArgs = New StyleObjectInfoArgs(New GraphicsCache(g))
            info.Bounds = New Rectangle(0, 0, width, height)
            button.LookAndFeel.Painter.GroupPanel.DrawObject(info)
            button.LookAndFeel.Painter.Border.DrawObject(info)
            info.Bounds = New Rectangle(indent, indent, width - indent * 2, height - indent * 2)
            button.LookAndFeel.Painter.Button.DrawObject(info)
        End Using
        Return image
    End Function
    Private Sub rgbiSkins_Gallery_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles rgbiSkins.Gallery.ItemClick
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(e.Item.Caption)
    End Sub
    Private Sub rgbiSkins_Gallery_InitDropDownGallery(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Ribbon.InplaceGalleryEventArgs) Handles rgbiSkins.Gallery.InitDropDownGallery
        e.PopupGallery.CreateFrom(rgbiSkins.Gallery)
        e.PopupGallery.AllowFilter = False
        e.PopupGallery.ShowItemText = True
        e.PopupGallery.ShowGroupCaption = True
        e.PopupGallery.AllowHoverImages = False
        For Each galleryGroup As GalleryItemGroup In e.PopupGallery.Groups
            For Each item As GalleryItem In galleryGroup.Items
                item.Image = item.HoverImage
            Next item
        Next galleryGroup
        e.PopupGallery.ColumnCount = 2
        e.PopupGallery.ImageSize = New Size(70, 36)
    End Sub
    Private Sub RbPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.RepositoryItemSpinEdit1.MinValue = "2014"
        'Me.RepositoryItemSpinEdit1.MaxValue = "3000"
        ar.cargarareacmb(Me.BarEditItem5)
        P.cargarpersonalcmb(BarEditItem7)
        P.cargarpersonalcmb(BarEditItem11)
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim frm As New FrmPersonal
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim frm As New FrmTipoPersonal
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim frm As New FrmReporteAsistencia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem5_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim frm As New Form1
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem4_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim frm As New FrmTodos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem6_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim frm As New FrmEspecialidad
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem7_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Dim frm As New FrmAsistencia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem8_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Dim frm As New FrmVacaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem10_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Dim frm As New Frmvpersona
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem11_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Dim frm As New FrmAnio
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem13_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        Dim frm As New FrmHorarios
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem14_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        Dim cr As New Xr_tya
        imp.reporte(asi.REPORTEtardanzaanioymes(Microsoft.VisualBasic.Left(Me.BarEditItem3.EditValue.ToString, 2), Me.BarEditItem1.EditValue.ToString), cr, "Reporte", Me)
    End Sub

    Private Sub BarButtonItem12_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim frm As New FrmAreas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RibbonControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonControl.Click

    End Sub

    Private Sub BarButtonItem15_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Dim cr As New XRPERSONALXAREA
        imp.reporte(P.REPORTEPERSONALXAREA(Me.BarEditItem5.EditValue.ToString), cr, "Reporte", Me)
    End Sub

    Private Sub BarButtonItem16_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        Dim cr As New XRPERSONALXAREA
        imp.reporte(P.REPORTEPERSONALXAREA(""), cr, "Reporte", Me)
    End Sub

    Private Sub BarButtonItem18_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        Try
            Dim cr As New Xrtardanzasxpersona
            imp.reporte(asi.REPORTEtardanzaaniomesPERSONA(Microsoft.VisualBasic.Left(Me.BarEditItem9.EditValue.ToString, 2), BarEditItem8.EditValue.ToString, BarEditItem7.EditValue.ToString), cr, "Reporte", Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
           End Sub

    Private Sub BarButtonItem19_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        Dim frm As New FrmPermisos
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem21_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        Try
            Dim cr As New XR_permisosTodos
            imp.reporte(per.REPORTEpermisostodos(Microsoft.VisualBasic.Left(Me.BarEditItem10.EditValue.ToString, 2), BarEditItem6.EditValue.ToString, ""), cr, "Reporte de Permisos", Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BarButtonItem23_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        Try
            Dim cr As New Xr_PermisosPersonal
            imp.reporte(per.REPORTEpermisostodos(Microsoft.VisualBasic.Left(Me.BarEditItem12.EditValue.ToString, 2), BarEditItem13.EditValue.ToString, Me.BarEditItem11.EditValue.ToString), cr, "Reporte de Permisos", Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BarButtonItem17_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        Dim frm As New FrmTurnos
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub BarButtonItem9_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Dim frm As New FrmControlVacaciones
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem20_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        Dim frm As New Form2
        frm.MdiParent = Me
        frm.lblannio.Text = Me.BarEditItem1.EditValue.ToString
        frm.lblmes.Text = Microsoft.VisualBasic.Left(Me.BarEditItem3.EditValue.ToString, 2)
        frm.Show()
    End Sub

    Private Sub BarButtonItem22_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        Dim frm As New FrmEstadisticoPermisos
        frm.MdiParent = Me
        frm.lblanio.Text = Me.BarEditItem6.EditValue.ToString
        frm.lblmes.Text = Microsoft.VisualBasic.Left(Me.BarEditItem10.EditValue.ToString, 2)
        frm.Show()

    End Sub

    Private Sub BarButtonItem24_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem24.ItemClick
        Dim cr As New Xr_adicionalmesaniio
        imp.reporte(asi.REPORTEadicionalesanioymes(Microsoft.VisualBasic.Left(Me.BarEditItem15.EditValue.ToString, 2), Me.BarEditItem14.EditValue.ToString), cr, "Reporte Minutos Adicionales mes y año", Me)
    End Sub

    Private Sub BarButtonItem26_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem26.ItemClick
        Dim cr As New Xr_adicionalmesaniio
        imp.reporte(asi.REPORTEadicionalesanioymes(Microsoft.VisualBasic.Left(Me.BarEditItem3.EditValue.ToString, 2), Me.BarEditItem1.EditValue.ToString), cr, "Reporte", Me)

    End Sub

    Private Sub BarButtonItem27_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem27.ItemClick
        Try
            Dim cr As New Xr_adicionalesxpersona
            imp.reporte(asi.REPORTEadicionalaniomesPERSONA(Microsoft.VisualBasic.Left(Me.BarEditItem9.EditValue.ToString, 2), BarEditItem8.EditValue.ToString, BarEditItem7.EditValue.ToString), cr, "Reporte", Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BarEditItem19_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarEditItem19.ItemClick
      
    End Sub

    Private Sub BarButtonItem28_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem28.ItemClick
        Dim cr As New XrSaldosVacaciones
        If BarEditItem19.EditValue = True Then
            imp.reporte(vac.REPORTESaldos(""), cr, "Saldos de Vacaciones", Me)
        Else
            imp.reporte(vac.REPORTESaldos(Me.BarEditItem18.EditValue.ToString), cr, "Saldos de Vacaciones", Me)
        End If
    End Sub
End Class