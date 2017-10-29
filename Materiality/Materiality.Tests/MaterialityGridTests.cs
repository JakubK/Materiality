using Materiality.WPF.Layouts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Materiality.Tests
{
    [TestClass]
    public class MaterialityGridTests
    {
        [TestMethod]
        [Description("No matter what kind of layout is being arranged, the result is True")]
        public void FitsControlsProperly()
        {
            //arrange
            MaterialityGrid grid = new MaterialityGrid();
            //act

            //assert
        }
    }
}
