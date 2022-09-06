using Xunit;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BL.Tests
{
    public class PlotCardFileManagerTests
    {
        [Theory]
        [InlineData(1, 1,
            new byte[] { 137, 112, 108, 116, 0, 0, 0, 8, 115, 73, 90, 101, 0, 0, 0, 1, 0, 0, 0, 1 }
        )]
        [InlineData(2, 2,
            new byte[] { 137, 112, 108, 116, 0, 0, 0, 8, 115, 73, 90, 101, 0, 0, 0, 2, 0, 0, 0, 2 }
        )]
        [InlineData(3, 3,
            new byte[] { 137, 112, 108, 116, 0, 0, 0, 8, 115, 73, 90, 101, 0, 0, 0, 3, 0, 0, 0, 3 }
        )]
        [InlineData(4, 4,
            new byte[] { 137, 112, 108, 116, 0, 0, 0, 8, 115, 73, 90, 101, 0, 0, 0, 4, 0, 0, 0, 4 }
        )]
        public void GenerateBinaryFileTest(uint width, uint height, byte[] fileData)
        {
            var file = PlotCardFileManager.GenerateBinaryFile(new PlotCard(width, height));

            Assert.Equal(fileData, file);
        }
    }
}