using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitExample2
{
        public delegate void ChangeTextDelegate(String msg);
        class DelegateTest
        {
            public ChangeTextDelegate changeTextDelegate;

            public DelegateTest(ChangeTextDelegate changeTextDelegate)
            {
                this.changeTextDelegate = changeTextDelegate;
            }

            public void ChangeText(String msg)
            {
                changeTextDelegate.Invoke(msg);
            }
        }
}
