using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using System.Text;
namespace Ncsln.Classes
{
    /// <summary>
    /// Represent the set of code values to be output into barcode form
    /// 
    /// </summary>
    public class Code128Content
    {
        private int[] mCodeList;

        /// <summary>
        /// Provides the Code128 code values representing the object's string
        /// 
        /// </summary>
        public int[] Codes
        {
            get
            {
                return this.mCodeList;
            }
        }

        /// <summary>
        /// Create content based on a string of ASCII data
        /// 
        /// </summary>
        /// <param name="AsciiData">the string that should be represented</param>
        public Code128Content(string AsciiData)
        {
            this.mCodeList = this.StringToCode128(AsciiData);
        }

        /// <summary>
        /// Transform the string into integers representing the Code128 codes
        ///  necessary to represent it
        /// 
        /// </summary>
        /// <param name="AsciiData">String to be encoded</param>
        /// <returns>
        /// Code128 representation
        /// </returns>
        private int[] StringToCode128(string AsciiData)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(AsciiData);
            Code128Code.CodeSetAllowed csa1 = bytes.Length <= 0 ? Code128Code.CodeSetAllowed.CodeAorB : Code128Code.CodesetAllowedForChar((int)bytes[0]);
            Code128Code.CodeSetAllowed csa2 = new Code128Code.CodeSetAllowed();
            if (bytes.Length > 0)
            {
                Code128Code.CodesetAllowedForChar((int)bytes[1]);
                csa2 = Code128Code.CodeSetAllowed.CodeAorB;
            }
            CodeSet bestStartSet = this.GetBestStartSet(csa1, csa2);
            ArrayList arrayList = new ArrayList(checked(bytes.Length + 3));
            arrayList.Add((object)Code128Code.StartCodeForCodeSet(bestStartSet));
            int index1 = 0;
            while (index1 < bytes.Length)
            {
                int CharAscii = (int)bytes[index1];
                int LookAheadAscii = bytes.Length <= checked(index1 + 1) ? -1 : (int)bytes[checked(index1 + 1)];
                arrayList.AddRange((ICollection)Code128Code.CodesForChar(CharAscii, LookAheadAscii, ref bestStartSet));
                checked { ++index1; }
            }
            int num = Conversions.ToInteger(arrayList[0]);
            int index2 = 1;
            while (index2 < arrayList.Count)
            {
                checked { num += index2 * Conversions.ToInteger(arrayList[index2]); }
                checked { ++index2; }
            }
            arrayList.Add((object)(num % 103));
            arrayList.Add((object)Code128Code.StopCode());
            return (int[])arrayList.ToArray(typeof(int));
        }

        /// <summary>
        /// Determines the best starting code set based on the the first two
        ///  characters of the string to be encoded
        /// 
        /// </summary>
        /// <param name="csa1">First character of input string</param><param name="csa2">Second character of input string</param>
        /// <returns>
        /// The codeset determined to be best to start with
        /// </returns>
        private CodeSet GetBestStartSet(Code128Code.CodeSetAllowed csa1, Code128Code.CodeSetAllowed csa2)
        {
            int num1 = 0;
            int num2 = csa1 != Code128Code.CodeSetAllowed.CodeA ? checked(num1 + 0) : checked(num1 + 1);
            int num3 = csa1 != Code128Code.CodeSetAllowed.CodeB ? checked(num2 + 0) : checked(num2 - 1);
            int num4 = csa2 != Code128Code.CodeSetAllowed.CodeA ? checked(num3 + 0) : checked(num3 + 1);
            return (csa2 != Code128Code.CodeSetAllowed.CodeB ? checked(num4 + 0) : checked(num4 - 1)) > 0 ? CodeSet.CodeA : CodeSet.CodeB;
        }
    }
}

