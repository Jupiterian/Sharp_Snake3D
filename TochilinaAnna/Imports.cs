using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices; //dll

namespace TochilinaAnna
{
    public class Imports
    {
        [DllImport("MathVectorDll.dll")]
        public static extern IntPtr MathVector();

        //[DllImport("MathVectorDll.dll")]
        //public static extern int LLr();

        //[DllImport("GameModeSnake.dll")]
        //public static extern int Level(IntPtr pClassNameObject, int value = 0);
    }
}
