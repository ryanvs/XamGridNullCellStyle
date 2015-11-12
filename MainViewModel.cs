using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamGridNullCellStyle
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            var table = new DataTable("Data");
            table.Columns.AddRange(new[]
            {
                new DataColumn("A", typeof(string)),
                new DataColumn("B", typeof(string)),
                new DataColumn("C", typeof(string)),
                new DataColumn("D", typeof(double)),
            });
            table.Rows.Add(new object[] { "1", null, "3", 4.0 });
            table.Rows.Add(new object[] { "1", "2", null, 4.0 });
            table.Rows.Add(new object[] { null, "2", "3", 4.0 });
            table.Rows.Add(new object[] { "1", "2", "3", null });
            table.AcceptChanges();

            DataView = table.DefaultView;
            BuildTestData(table);
        }

        private DataView _dataView;
        public DataView DataView
        {
            get { return _dataView; }
            set { SetField(ref _dataView, value); }
        }

        private ObservableCollection<TestDataViewModel> _testData;
        public ObservableCollection<TestDataViewModel> TestData
        {
            get { return _testData; }
            set { SetField(ref _testData, value); }
        }

        private void BuildTestData(DataTable table)
        {
            var vm = new ObservableCollection<TestDataViewModel>();
            foreach (DataRow row in table.AsEnumerable())
            {
                var item = new TestDataViewModel();
                item.A = row.Field<string>("A");
                item.B = row.Field<string>("B");
                item.C = row.Field<string>("C");
                item.D = NullField<double>(row, "D");
                vm.Add(item);
            }
            TestData = vm;
        }

        private Nullable<T> NullField<T>(DataRow row, string fieldName) where T : struct
        {
            if (row.IsNull(fieldName)) { return (Nullable<T>)null; }
            return (Nullable<T>)row.Field<T>(fieldName);
        }
    }
}
