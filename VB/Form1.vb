Imports Microsoft.VisualBasic
#Region "Copyright Syncfusion Inc. 2001-2018."
' Copyright Syncfusion Inc. 2001-2018. All rights reserved.
' Use of this code is subject to the terms of our license.
' A copy of the current license can be obtained at any time by e-mailing
' licensing@syncfusion.com. Any infringement will be prosecuted under
' applicable laws. 
#End Region
Imports System.Windows.Forms
Imports System.Data
Imports Syncfusion.Data

Namespace GettingStarted
	Partial Public Class Form1
		Inherits Form
		Private table As DataTable
		Public Sub New()
			InitializeComponent()
			table = GetDataTable()
			sfDataGrid.DataSource = GetDataTableWithoutRecords(table)
			sfDataGrid.AutoExpandGroups = True
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
			If sfDataGrid.View.TopLevelGroup IsNot Nothing AndAlso Me.sfDataGrid.GroupColumnDescriptions.Count >= 0 Then
				sfDataGrid.View.AddNew()
				sfDataGrid.View.CommitNew()
				Dim record = sfDataGrid.View.TopLevelGroup.DisplayElements(1)
				If Not record.IsRecords Then
					Return
				End If

				Dim data = (TryCast(record, RecordEntry)).Data
				TryCast(data, DataRowView).Row.SetField(0, table.Rows(0)(0))
				TryCast(data, DataRowView).Row.SetField(1, table.Rows(0)(1))
				TryCast(data, DataRowView).Row.SetField(2, table.Rows(0)(2))
				TryCast(data, DataRowView).Row.SetField(3, table.Rows(0)(3))
				TryCast(data, DataRowView).Row.SetField(4, table.Rows(0)(4))
			Else
				sfDataGrid.View.AddNew()
				sfDataGrid.View.CommitNew()
				Dim record1 = sfDataGrid.View.Records.GetItemAt(0)
				TryCast(record1, DataRowView).Row.SetField(0, table.Rows(0)(0))
				TryCast(record1, DataRowView).Row.SetField(1, table.Rows(0)(1))
				TryCast(record1, DataRowView).Row.SetField(2, table.Rows(0)(2))
				TryCast(record1, DataRowView).Row.SetField(3, table.Rows(0)(3))
				TryCast(record1, DataRowView).Row.SetField(4, table.Rows(0)(4))
			End If
		End Sub

		Public Function GetDataTableWithoutRecords(ByVal table As DataTable) As DataTable
			Dim collection As New DataTable()
			For Each column As DataColumn In table.Columns
				collection.Columns.Add(column.ColumnName, column.DataType)
			Next column

			Return collection
		End Function

		Public Function GetDataTable() As DataTable
			Dim collection As New DataTable()
			collection.Columns.Add("ID", GetType(Integer))
			collection.Columns.Add("Name", GetType(String))
			collection.Columns.Add("Q1", GetType(Single))
			collection.Columns.Add("Q2", GetType(Single))
			collection.Columns.Add("Q3", GetType(Single))

			For i As Integer = 0 To 19
				collection.Rows.Add(1001, "Belgim", 872.81, 978.89, 685.90)
				collection.Rows.Add(1002, "Oliver", 978.76, 458.21, 675.99)
				collection.Rows.Add(1003, "Bernald", 548.31, 234.32, 423.44)
				collection.Rows.Add(1004, "James", 123.31, 6543.12, 978.31)
				collection.Rows.Add(1005, "Beverton", 654.33, 978.31, 654.11)
				collection.Rows.Add(1005, "Berlin", 647.33, 978.31, 423.44)
				collection.Rows.Add(1006, "Fransis", 908.55, 123.31, 675.99)
				collection.Rows.Add(1006, "Fred", 654.34, 423.44, 978.31)
				collection.Rows.Add(1009, "Dintin", 978.31, 455.64, 978.31)
				collection.Rows.Add(1009, "Diano", 458.31, 675.00, 978.31)
				collection.Rows.Add(1010, "Joysie", 978.31, 453.98, 455.64)
				collection.Rows.Add(1016, "Friedo", 458.31, 675.99, 455.64)
				collection.Rows.Add(1017, "George", 123.31, 978.31, 675.99)
				collection.Rows.Add(1011, "Dintin Amam", 978.31, 788.35, 978.76)
				collection.Rows.Add(1012, "John Amam", 123.31, 123.31, 458.31)
				collection.Rows.Add(1012, "Paul", 978.31, 544.44, 978.76)
			Next i

			Return collection
		End Function
	End Class
End Namespace
