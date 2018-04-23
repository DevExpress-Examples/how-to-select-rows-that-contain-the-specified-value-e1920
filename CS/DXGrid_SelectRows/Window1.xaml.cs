﻿using System.Windows;

namespace DXGrid_SelectRows {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            grid.DataSource = ProductList.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            SelectProducts(20);
        }

        private void SelectProducts(double minPrice) {
            tableView.BeginSelection();
            tableView.ClearSelection();
            for (int i = 0; i < grid.VisibleRowCount; i++) {
                int rowHandle = grid.GetRowHandleByVisibleIndex(i);
                if (!grid.IsGroupRowHandle(rowHandle)) {
                    double price = (double)grid.GetCellValue(rowHandle,
                        grid.Columns["UnitPrice"]);
                    if (price >= minPrice)
                        tableView.SelectRow(rowHandle);
                }
            }
            tableView.EndSelection();
        }
    }
}
