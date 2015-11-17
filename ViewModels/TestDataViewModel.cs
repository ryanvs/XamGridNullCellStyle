using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamGridNullCellStyle
{
    public class TestDataViewModel : ObservableObject
    {
        private string a;
        public string A
        {
            get { return a; }
            set { SetField(ref a, value); }
        }

        private string b;
        public string B
        {
            get { return b; }
            set { SetField(ref b, value); }
        }

        private string c;
        public string C
        {
            get { return c; }
            set { SetField(ref c, value); }
        }

        private double? d;
        public double? D
        {
            get { return d; }
            set { SetField(ref d, value); }
        }

    }
}
