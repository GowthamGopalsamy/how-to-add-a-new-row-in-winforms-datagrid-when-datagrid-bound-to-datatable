
#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Forms;
using System.Data;
using Syncfusion.Data;

namespace GettingStarted
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
            table = GetDataTable();
            sfDataGrid.DataSource = GetDataTableWithoutRecords(table);
            sfDataGrid.AutoExpandGroups = true;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {           
            if (sfDataGrid.View.TopLevelGroup != null && this.sfDataGrid.GroupColumnDescriptions.Count >= 0)
            {
                sfDataGrid.View.AddNew();
                sfDataGrid.View.CommitNew();
                var record = sfDataGrid.View.TopLevelGroup.DisplayElements[1];
                if (!record.IsRecords)
                    return;

                var data = (record as RecordEntry).Data;
                (data as DataRowView).Row.SetField(0, table.Rows[0][0]);
                (data as DataRowView).Row.SetField(1, table.Rows[0][1]);
                (data as DataRowView).Row.SetField(2, table.Rows[0][2]);
                (data as DataRowView).Row.SetField(3, table.Rows[0][3]);
                (data as DataRowView).Row.SetField(4, table.Rows[0][4]);
            }
            else
            {
                sfDataGrid.View.AddNew();
                sfDataGrid.View.CommitNew();
                var record1 = sfDataGrid.View.Records.GetItemAt(0);
                (record1 as DataRowView).Row.SetField(0, table.Rows[0][0]);
                (record1 as DataRowView).Row.SetField(1, table.Rows[0][1]);
                (record1 as DataRowView).Row.SetField(2, table.Rows[0][2]);
                (record1 as DataRowView).Row.SetField(3, table.Rows[0][3]);
                (record1 as DataRowView).Row.SetField(4, table.Rows[0][4]);
            }
        }

        public DataTable GetDataTableWithoutRecords(DataTable table)
        {
            DataTable collection = new DataTable();
            foreach (DataColumn column in table.Columns)
            {
                collection.Columns.Add(column.ColumnName, column.DataType);
            }

            return collection;
        }

        public DataTable GetDataTable()
        {
            DataTable collection = new DataTable();
            collection.Columns.Add("ID", typeof(int));
            collection.Columns.Add("Name", typeof(string));
            collection.Columns.Add("Q1", typeof(float));
            collection.Columns.Add("Q2", typeof(float));
            collection.Columns.Add("Q3", typeof(float));

            for (int i = 0; i <= 19; i++)
            {
                collection.Rows.Add(1001, "Belgim", 872.81, 978.89, 685.90);
                collection.Rows.Add(1002, "Oliver", 978.76, 458.21, 675.99);
                collection.Rows.Add(1003, "Bernald", 548.31, 234.32, 423.44);
                collection.Rows.Add(1004, "James", 123.31, 6543.12, 978.31);
                collection.Rows.Add(1005, "Beverton", 654.33, 978.31, 654.11);
                collection.Rows.Add(1005, "Berlin", 647.33, 978.31, 423.44);
                collection.Rows.Add(1006, "Fransis", 908.55, 123.31, 675.99);
                collection.Rows.Add(1006, "Fred", 654.34, 423.44, 978.31);
                collection.Rows.Add(1009, "Dintin", 978.31, 455.64, 978.31);
                collection.Rows.Add(1009, "Diano", 458.31, 675.00, 978.31);
                collection.Rows.Add(1010, "Joysie", 978.31, 453.98, 455.64);
                collection.Rows.Add(1016, "Friedo", 458.31, 675.99, 455.64);
                collection.Rows.Add(1017, "George", 123.31, 978.31, 675.99);
                collection.Rows.Add(1011, "Dintin Amam", 978.31, 788.35, 978.76);
                collection.Rows.Add(1012, "John Amam", 123.31, 123.31, 458.31);
                collection.Rows.Add(1012, "Paul", 978.31, 544.44, 978.76);
            }

            return collection;
        }
    }
}
