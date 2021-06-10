﻿Imports Spire.Presentation
Imports System.ComponentModel
Imports System.Text

Namespace MergeTableCell
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnRun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRun.Click
			'Create a PPT document and load file
			Dim presentation As New Presentation()
			presentation.LoadFromFile("..\..\..\..\..\..\Data\MergeTableCell.pptx")

			Dim table As ITable = Nothing
			For Each shape As IShape In presentation.Slides(0).Shapes
				If TypeOf shape Is ITable Then
					table = CType(shape, ITable)

					'Merge the second row and third row of the first column
					table.MergeCells(table(0, 1), table(0, 2), False)

					table.MergeCells(table(3, 4), table(4, 4), True)

				End If
			Next shape

			'Save and launch the file
			presentation.SaveToFile("MergeTableCell_result.pptx", FileFormat.Pptx2010)
			Process.Start("MergeTableCell_result.pptx")
		End Sub
	End Class
End Namespace
