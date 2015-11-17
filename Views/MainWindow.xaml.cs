using Infragistics.Controls.Grids;
using Infragistics.Controls.Grids.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamGridNullCellStyle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GridWithDataView.DataObjectRequested += Grid_DataObjectRequested;
        }

        /// <summary>
        /// Updates the ActiveCell when the right mouse button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cell_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var grid = (XamGrid)sender;
            var pos = e.GetPosition((IInputElement)sender);
            var cell = (CellControl)sender;
            var parent = (CellsPanel)cell.Parent;
            var data = parent.Row.Data;
            if (grid.ActiveCell != cell.Cell)
                grid.ActiveCell = cell.Cell;
        }

        private void Grid_DataObjectRequested(object sender, DataObjectCreationEventArgs e)
        {
            var grid = (XamGrid)sender;
            var dataView = grid.ItemsSource as System.Data.DataView;
            if (dataView != null && e.ObjectType.Equals(typeof(System.Data.DataRowView)))
            {
                e.NewObject = new System.Data.DataView(dataView.Table).AddNew();
            }
        }
    }
}
