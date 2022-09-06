using Model;
using System.Collections;
using System.Collections.Specialized;

namespace BL
{
    public class PlotCardFileManager
    {
        public static byte[] GenerateBinaryFile(PlotCard plotCard)
        {
            // Get byte array size
            var arraySize = PltFileConstants.Header.Length;

            var sizeBlock = GenerateSizeBlock(plotCard);
            arraySize += sizeBlock.Length;


            // Create byte array
            var byteArray = new byte[arraySize];

            // Header
            PltFileConstants.Header.CopyTo(byteArray, 0);

            // Size Block
            sizeBlock.CopyTo(byteArray, 4);


            return byteArray;
        }
         
        public static byte[] GenerateSizeBlock(PlotCard plotCard)
        {
            var sizeBlockData = new byte[16];

            var sizeBlock = UIntArrayToBigEndianByteArray(new uint[] { plotCard.Width, plotCard.Height });
            var sizeBlockSize = UIntToBigEndianByteArray((uint)sizeBlock.Length);

            sizeBlockSize.CopyTo(sizeBlockData, 0);
            PltFileConstants.SizeBlock.CopyTo(sizeBlockData, 4);
            sizeBlock.CopyTo(sizeBlockData, 8);

            return sizeBlockData;
        }

        public static byte[] UIntToBigEndianByteArray(uint UInt)
        {
            byte[] uIntBytes = BitConverter.GetBytes(UInt);

            return new byte[] { uIntBytes[3], uIntBytes[2], uIntBytes[1], uIntBytes[0] };
        }

        public static byte[] UIntArrayToBigEndianByteArray(uint[] uIntArray)
        {
            byte[] byteArray = new byte[uIntArray.Length * sizeof(uint)];

            for (var i = 0; i < uIntArray.Length; i++)
            {
                UIntToBigEndianByteArray(uIntArray[i]).CopyTo(byteArray, i * 4);
            }

            return byteArray;
        }
    }
}
