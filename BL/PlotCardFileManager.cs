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

            // Get size block
            var sizeBlock = UIntArrayToBigEndianByteArray(new uint[] { plotCard.Width, plotCard.Height });

            var sizeBlockSize = UIntToBigEndianByteArray((uint)sizeBlock.Length);

            arraySize += sizeBlock.Length;
            arraySize += sizeBlockSize.Length;

            arraySize += PltFileConstants.SizeBlock.Length;

            var byteArray = new byte[arraySize];

            // Header
            PltFileConstants.Header.CopyTo(byteArray, 0);

            // Size Block
            sizeBlockSize.CopyTo(byteArray, 4);
            PltFileConstants.SizeBlock.CopyTo(byteArray, 8);
            sizeBlock.CopyTo(byteArray, 12);

            return byteArray;
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
