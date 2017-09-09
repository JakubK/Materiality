using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Materiality.WPF.Layouts
{
    /// <summary>
    /// Fills the row.
    /// </summary>
    public class RowFiller : Control
    {
        public RowFiller()
        {
            MaterialityGrid.SetSColumn(this, 12);
            MaterialityGrid.SetMColumn(this, 12);
            MaterialityGrid.SetLColumn(this, 12);
            MaterialityGrid.SetXLColumn(this, 12);
        }
    }
}
