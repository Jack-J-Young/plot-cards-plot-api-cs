using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PltFileConstants
    {
        // 0x89 + plt: Unique header for .plt files
        public static byte[] Header = new byte[] { 137, 112, 108, 116 };

        // sIZe: Stores the width and height values
        public static byte[] SizeBlock = new byte[] { 115, 73, 90, 101 };

        // hDAt or height data: stores the height maps data as Float32[width * height], in bytes
        public static byte[] HdatBlock = new byte[] { 115, 73, 90, 101 };
    }
}
