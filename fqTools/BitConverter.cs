using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fqTools
{
    public static class BitConverter
    {
        /// <inheritdoc cref="System.BitConverter.GetBytes(short)"/>
        /// <param name="bigEndian">BigEndianの並びにする</param>
        public static byte[] GetBytes(short value, bool bigEndian = true)
        {
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                return System.BitConverter.GetBytes(value).Reverse().ToArray();
            }
            else
            {
                return System.BitConverter.GetBytes(value);
            }
        }


        /// <inheritdoc cref="System.BitConverter.GetBytes(ushort)"/>
        /// <param name="bigEndian">BigEndianの並びにする</param>
        public static byte[] GetBytes(ushort value, bool bigEndian = true)
        {
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                return System.BitConverter.GetBytes(value).Reverse().ToArray();
            }
            else
            {
                return System.BitConverter.GetBytes(value);
            }
        }


        /// <inheritdoc cref="System.BitConverter.GetBytes(Int32)"/>
        /// <param name="bigEndian">BigEndianの並びにする</param>
        public static byte[] GetBytes(Int32 value, bool bigEndian = true)
        {
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                return System.BitConverter.GetBytes(value).Reverse().ToArray();
            }
            else
            {
                return System.BitConverter.GetBytes(value);
            }
        }


        /// <inheritdoc cref="System.BitConverter.GetBytes(UInt32)"/>
        /// <param name="bigEndian">BigEndianの並びにする</param>
        public static byte[] GetBytes(UInt32 value, bool bigEndian = true)
        {
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                return System.BitConverter.GetBytes(value).Reverse().ToArray();
            }
            else
            {
                return System.BitConverter.GetBytes(value);
            }
        }


        /// <inheritdoc cref="System.BitConverter.GetBytes(Int64)"/>
        /// <param name="bigEndian">BigEndianの並びにする</param>
        public static byte[] GetBytes(Int64 value, bool bigEndian = true)
        {
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                return System.BitConverter.GetBytes(value).Reverse().ToArray();
            }
            else
            {
                return System.BitConverter.GetBytes(value);
            }
        }


        /// <inheritdoc cref="System.BitConverter.GetBytes(UInt64)"/>
        /// <param name="bigEndian">BigEndianの並びにする</param>
        public static byte[] GetBytes(UInt64 value, bool bigEndian = true)
        {
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                return System.BitConverter.GetBytes(value).Reverse().ToArray();
            }
            else
            {
                return System.BitConverter.GetBytes(value);
            }
        }


        /// <inheritdoc cref="System.BitConverter.GetBytes(float)"/>
        /// <param name="bigEndian">BigEndianの並びにする</param>
        public static byte[] GetBytes(float value, bool bigEndian = true)
        {
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                return System.BitConverter.GetBytes(value).Reverse().ToArray();
            }
            else
            {
                return System.BitConverter.GetBytes(value);
            }
        }


        /// <inheritdoc cref="System.BitConverter.GetBytes(double)"/>
        /// <param name="bigEndian">BigEndianの並びにする</param>
        public static byte[] GetBytes(double value, bool bigEndian = true)
        {
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                return System.BitConverter.GetBytes(value).Reverse().ToArray();
            }
            else
            {
                return System.BitConverter.GetBytes(value);
            }
        }



        /// <inheritdoc cref="System.BitConverter.ToInt16"/>
        /// <param name="bigEndian">valueがBigEndianの並び</param>
        public static short ToInt16(byte[] value, int startIndex, bool bigEndian = true)
        {
            if (value.Length - startIndex < 2)
            {
                throw new ArgumentOutOfRangeException("value.Length - startIndex < 2");
            }
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                byte[] rev = new byte[] { value[startIndex + 1], value[startIndex] };
                return System.BitConverter.ToInt16(rev, 0);
            }
            else
            {
                return System.BitConverter.ToInt16(value, startIndex);
            }
        }


        /// <inheritdoc cref="System.BitConverter.ToUInt16"/>
        /// <param name="bigEndian">valueがBigEndianの並び</param>
        public static ushort ToUInt16(byte[] value, int startIndex, bool bigEndian = true)
        {
            if (value.Length - startIndex < 2)
            {
                throw new ArgumentOutOfRangeException("value.Length - startIndex < 2");
            }
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                byte[] rev = new byte[] { value[startIndex + 1], value[startIndex] };
                return System.BitConverter.ToUInt16(rev, 0);
            }
            else
            {
                return System.BitConverter.ToUInt16(value, startIndex);
            }
        }


        /// <inheritdoc cref="System.BitConverter.ToInt32"/>
        /// <param name="bigEndian">valueがBigEndianの並び</param>
        public static Int32 ToInt32(byte[] value, int startIndex, bool bigEndian = true)
        {
            if (value.Length - startIndex < 4)
            {
                throw new ArgumentOutOfRangeException("value.Length - startIndex < 4");
            }
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                byte[] rev = new byte[] { value[startIndex + 3], value[startIndex + 2], value[startIndex + 1], value[startIndex] };
                return System.BitConverter.ToInt32(rev, 0);
            }
            else
            {
                return System.BitConverter.ToInt32(value, startIndex);
            }
        }


        /// <inheritdoc cref="System.BitConverter.ToUInt32"/>
        /// <param name="bigEndian">valueがBigEndianの並び</param>
        public static UInt32 ToUInt32(byte[] value, int startIndex, bool bigEndian = true)
        {
            if (value.Length - startIndex < 4)
            {
                throw new ArgumentOutOfRangeException("value.Length - startIndex < 4");
            }
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                byte[] rev = new byte[] { value[startIndex + 3], value[startIndex + 2], value[startIndex + 1], value[startIndex] };
                return System.BitConverter.ToUInt32(rev, 0);
            }
            else
            {
                return System.BitConverter.ToUInt32(value, startIndex);
            }
        }


        /// <inheritdoc cref="System.BitConverter.ToSingle"/>
        /// <param name="bigEndian">valueがBigEndianの並び</param>
        public static float ToSingle(byte[] value, int startIndex, bool bigEndian = true)
        {
            if (value.Length - startIndex < 4)
            {
                throw new ArgumentOutOfRangeException("value.Length - startIndex < 4");
            }
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                byte[] rev = new byte[] { value[startIndex + 3], value[startIndex + 2], value[startIndex + 1], value[startIndex] };
                return System.BitConverter.ToSingle(rev, 0);
            }
            else
            {
                return System.BitConverter.ToSingle(value, startIndex);
            }
        }


        /// <inheritdoc cref="System.BitConverter.ToInt64"/>
        /// <param name="bigEndian">valueがBigEndianの並び</param>
        public static Int64 ToInt64(byte[] value, int startIndex, bool bigEndian = true)
        {
            if (value.Length - startIndex < 8)
            {
                throw new ArgumentOutOfRangeException("value.Length - startIndex < 8");
            }
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                byte[] rev = new byte[] { value[startIndex + 7], value[startIndex + 6], value[startIndex + 5], value[startIndex + 4], value[startIndex + 3], value[startIndex + 2], value[startIndex + 1], value[startIndex] };
                return System.BitConverter.ToInt64(rev, 0);
            }
            else
            {
                return System.BitConverter.ToInt64(value, startIndex);
            }
        }


        /// <inheritdoc cref="System.BitConverter.ToUInt64"/>
        /// <param name="bigEndian">valueがBigEndianの並び</param>
        public static UInt64 ToUInt64(byte[] value, int startIndex, bool bigEndian = true)
        {
            if (value.Length - startIndex < 8)
            {
                throw new ArgumentOutOfRangeException("value.Length - startIndex < 8");
            }
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                byte[] rev = new byte[] { value[startIndex + 7], value[startIndex + 6], value[startIndex + 5], value[startIndex + 4], value[startIndex + 3], value[startIndex + 2], value[startIndex + 1], value[startIndex] };
                return System.BitConverter.ToUInt64(rev, 0);
            }
            else
            {
                return System.BitConverter.ToUInt64(value, startIndex);
            }
        }


        /// <inheritdoc cref="System.BitConverter.ToDouble"/>
        /// <param name="bigEndian">valueがBigEndianの並び</param>
        public static double ToDouble(byte[] value, int startIndex, bool bigEndian = true)
        {
            if (value.Length - startIndex < 8)
            {
                throw new ArgumentOutOfRangeException("value.Length - startIndex < 8");
            }
            if ((bigEndian && System.BitConverter.IsLittleEndian)
                || (!bigEndian && !System.BitConverter.IsLittleEndian))
            {
                byte[] rev = new byte[] { value[startIndex + 7], value[startIndex + 6], value[startIndex + 5], value[startIndex + 4], value[startIndex + 3], value[startIndex + 2], value[startIndex + 1], value[startIndex] };
                return System.BitConverter.ToDouble(rev, 0);
            }
            else
            {
                return System.BitConverter.ToDouble(value, startIndex);
            }
        }
    }
}
