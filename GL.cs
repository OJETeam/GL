using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OJE.GL
{
    public static unsafe class GL
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Accum(int oper, float val)
        {
            Imports.glAccum(oper, val);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ActiveTexture(int texture)
        {
            Imports.glActiveTexture(texture);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AlphaFunc(int func, float reference)
        {
            Imports.glAlphaFunc(func, reference);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool[] AreTexturesResident(int lenght, int[] textures)
        {
            bool[] residences;
            Imports.glAreTexturesResident(lenght, textures, out residences);
            return residences;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArrayElement(int index)
        {
            Imports.glArrayElement(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AttachShader(int program, int shader)
        {
            Imports.glAttachShader(program, shader);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Begin(int mode)
        {
            Imports.glBegin(mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BeginQuery(int target, int id)
        {
            Imports.glBeginQuery(target, id);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BindAttribLocation(int program, int index, string name)
        {
            Imports.glBindAttribLocation(program, index, name);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BindBuffer(int target, int buffer)
        {
            Imports.glBindBuffer(target, buffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BindTexture(int target, int texture)
        {
            Imports.glBindTexture(target, texture);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BindVertexArray(int array) //TODO USE UINT EVERYWHERE
        {
            Imports.glBindVertexArray(array);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Bitmap(int width, int height, float xorig, float yorig, float xmove, float ymove, byte[] bitmap)
        {
            Imports.glBitmap(width, height, xorig, yorig, xmove, ymove, bitmap);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendColor(float red, float green, float blue, float alpha)
        {
            Imports.glBlendColor(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendEquation(int mode)
        {
            Imports.glBlendEquation(mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendEquationSeparate(int modeRGB, int modeAlpha)
        {
            Imports.glBlendEquationSeparate(modeRGB, modeAlpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendFunc(int sfactor, int dfactor)
        {
            Imports.glBlendFunc(sfactor, dfactor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha)
        {
            Imports.glBlendFuncSeparate(srcRGB, dstRGB, srcAlpha, dstAlpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BufferData(int target, int size, void* data, int usage)
        {
            Imports.glBufferData(target, size, data, usage);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BufferData(int target, int size, object data, int usage)
        {
            GCHandle pointer = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                Imports.glBufferData(target, size, pointer.AddrOfPinnedObject().ToPointer(), usage);
            }
            finally
            {
                pointer.Free();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BufferSubData(int target, int offset, int size, object data)
        {
            GCHandle pointer = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                Imports.glBufferSubData(target, offset, size, pointer.AddrOfPinnedObject().ToPointer());
            }
            finally
            {
                pointer.Free();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallList(int list)
        {
            Imports.glCallList(list);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallLists(sbyte[] lists)
        {
            fixed (void* pointer = lists)
            {
                Imports.glCallLists(lists.Length, BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallLists(byte[] lists)
        {
            fixed (void* pointer = lists)
            {
                Imports.glCallLists(lists.Length, UNSIGNED_BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallLists(short[] lists)
        {
            fixed (void* pointer = lists)
            {
                Imports.glCallLists(lists.Length, SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallLists(ushort[] lists)
        {
            fixed (void* pointer = lists)
            {
                Imports.glCallLists(lists.Length, UNSIGNED_SHORT, pointer);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallLists(UInt24[] lists)
        {
            fixed (void* pointer = lists)
            {
                Imports.glCallLists(lists.Length, GL_3_BYTES, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallLists(int[] lists)
        {
            fixed (void* pointer = lists)
            {
                Imports.glCallLists(lists.Length, INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallLists(uint[] lists)
        {
            fixed (void* pointer = lists)
            {
                Imports.glCallLists(lists.Length, UNSIGNED_INT_2_10_10_10_REV, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CallLists(float[] lists)
        {
            fixed (void* pointer = lists)
            {
                Imports.glCallLists(lists.Length, FLOAT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Clear(int mask)
        {
            Imports.glClear(mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClearAccum(float red, float green, float blue, float alpha)
        {
            Imports.glClearAccum(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClearColor(float red, float green, float blue, float alpha)
        {
            Imports.glClearColor(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClearDepth(double depth)
        {
            Imports.glClearDepth(depth);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClearIndex(float c)
        {
            Imports.glClearIndex(c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClearStencil(int s)
        {
            Imports.glClearStencil(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClientActiveTexture(int texture)
        {
            Imports.glClientActiveTexture(texture);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ClipPlane(int plane, double[] equation)
        {
            Imports.glClipPlane(plane, equation);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color3(sbyte red, sbyte green, sbyte blue)
        {
            Imports.glColor3b(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color3(short red, short green, short blue)
        {
            Imports.glColor3s(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color3(int red, int green, int blue)
        {
            Imports.glColor3i(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color3(float red, float green, float blue)
        {
            Imports.glColor3f(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color3(double red, double green, double blue)
        {
            Imports.glColor3d(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color3(byte red, byte green, byte blue)
        {
            Imports.glColor3ub(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color3us(short red, short green, short blue)
        {
            Imports.glColor3us(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color3ui(int red, int green, int blue)
        {
            Imports.glColor3ui(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color4b(byte red, byte green, byte blue, byte alpha)
        {
            Imports.glColor4b(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color4s(short red, short green, short blue, short alpha)
        {
            Imports.glColor4s(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color4i(int red, int green, int blue, int alpha)
        {
            Imports.glColor4i(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color4f(float red, float green, float blue, float alpha)
        {
            Imports.glColor4f(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color4d(double red, double green, double blue, double alpha)
        {
            Imports.glColor4d(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color4ub(byte red, byte green, byte blue, byte alpha)
        {
            Imports.glColor4ub(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color4us(short red, short green, short blue, short alpha)
        {
            Imports.glColor4us(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Color4ui(int red, int green, int blue, int alpha)
        {
            Imports.glColor4ui(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorMask(bool red, bool green, bool blue, bool alpha)
        {
            Imports.glColorMask(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorMaterial(int face, int mode)
        {
            Imports.glColorMaterial(face, mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorPointer(int size, sbyte[] array)
        {
            fixed (void* pointer = array)
            {
                Imports.glColorPointer(size, BYTE, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorPointer(int size, byte[] array)
        {
            fixed (void* pointer = array)
            {
                Imports.glColorPointer(size, UNSIGNED_BYTE, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorPointer(int size, short[] array)
        {
            fixed (void* pointer = array)
            {
                Imports.glColorPointer(size, SHORT, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorPointer(int size, ushort[] array)
        {
            fixed (void* pointer = array)
            {
                Imports.glColorPointer(size, UNSIGNED_SHORT, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorPointer(int size, int[] array)
        {
            fixed (void* pointer = array)
            {
                Imports.glColorPointer(size, INT, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorPointer(int size, uint[] array)
        {
            fixed (void* pointer = array)
            {
                Imports.glColorPointer(size, UNSIGNED_INT_2_10_10_10_REV, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorPointer(int size, float[] array)
        {
            fixed (void* pointer = array)
            {
                Imports.glColorPointer(size, FLOAT, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorPointer(int size, double[] array)
        {
            fixed (void* pointer = array)
            {
                Imports.glColorPointer(size, DOUBLE, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorSubTable(int target, int start, int format, sbyte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorSubTable(target, start, data.Length, format, BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorSubTable(int target, int start, int format, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorSubTable(target, start, data.Length, format, UNSIGNED_BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorSubTable(int target, int start, int format, short[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorSubTable(target, start, data.Length, format, SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorSubTable(int target, int start, int format, ushort[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorSubTable(target, start, data.Length, format, UNSIGNED_SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorSubTable(int target, int start, int format, int[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorSubTable(target, start, data.Length, format, INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorSubTable(int target, int start, int format, uint[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorSubTable(target, start, data.Length, format, UNSIGNED_INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorSubTable(int target, int start, int format, float[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorSubTable(target, start, data.Length, format, FLOAT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorTable(int target, int publicformat, int width, int format, sbyte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorTable(target, publicformat, width, format, BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorTable(int target, int publicformat, int width, int format, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorTable(target, publicformat, width, format, UNSIGNED_BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorTable(int target, int publicformat, int width, int format, short[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorTable(target, publicformat, width, format, SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorTable(int target, int publicformat, int width, int format, ushort[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorTable(target, publicformat, width, format, UNSIGNED_SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorTable(int target, int publicformat, int width, int format, int[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorTable(target, publicformat, width, format, INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorTable(int target, int publicformat, int width, int format, uint[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorTable(target, publicformat, width, format, UNSIGNED_INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorTable(int target, int publicformat, int width, int format, float[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glColorTable(target, publicformat, width, format, FLOAT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorTableParameterfv(int target, int pname, float[] param)
        {
            Imports.glColorTableParameterfv(target, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ColorTableParameteriv(int target, int pname, int[] param)
        {
            Imports.glColorTableParameteriv(target, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompileShader(int shader)
        {
            Imports.glCompileShader(shader);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompressedTexImage1D(int target, int level, int publicformat, int width, int border, int imageSize, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glCompressedTexImage1D(target, level, publicformat, width, border, imageSize, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompressedTexImage2D(int target, int level, int publicformat, int width, int height, int border, int imageSize, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glCompressedTexImage2D(target, level, publicformat, width, height, border, imageSize, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompressedTexImage3D(int target, int level, int publicformat, int width, int height, int depth, int border, int imageSize, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glCompressedTexImage3D(target, level, publicformat, width, height, depth, border, imageSize, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompressedTexSubImage1D(int target, int level, int xoffset, int width, int format, int imageSize, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glCompressedTexSubImage1D(target, level, xoffset, width, format, imageSize, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int imageSize, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CompressedTexSubImage3D(int target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int format, int imageSize, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glCompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter1D(int target, int publicformat, int width, int format, sbyte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter1D(target, publicformat, width, format, BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter1D(int target, int publicformat, int width, int format, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter1D(target, publicformat, width, format, UNSIGNED_BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilterBitmap1D(int target, int publicformat, int width, int format, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter1D(target, publicformat, width, format, BITMAP, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter1D(int target, int publicformat, int width, int format, short[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter1D(target, publicformat, width, format, SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter1D(int target, int publicformat, int width, int format, ushort[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter1D(target, publicformat, width, format, UNSIGNED_SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter1D(int target, int publicformat, int width, int format, int[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter1D(target, publicformat, width, format, INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter1D(int target, int publicformat, int width, int format, uint[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter1D(target, publicformat, width, format, UNSIGNED_INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter1D(int target, int publicformat, int width, int format, float[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter1D(target, publicformat, width, format, FLOAT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter2D(int target, int publicformat, int width, int height, int format, sbyte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter2D(target, publicformat, width, height, format, BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter2D(int target, int publicformat, int width, int height, int format, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter2D(target, publicformat, width, height, format, UNSIGNED_BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilterBitmap2D(int target, int publicformat, int width, int height, int format, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter2D(target, publicformat, width, height, format, BITMAP, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter2D(int target, int publicformat, int width, int height, int format, short[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter2D(target, publicformat, width, height, format, SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter2D(int target, int publicformat, int width, int height, int format, ushort[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter2D(target, publicformat, width, height, format, UNSIGNED_SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter2D(int target, int publicformat, int width, int height, int format, int[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter2D(target, publicformat, width, height, format, INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter2D(int target, int publicformat, int width, int height, int format, uint[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter2D(target, publicformat, width, height, format, UNSIGNED_INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionFilter2D(int target, int publicformat, int width, int height, int format, float[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glConvolutionFilter2D(target, publicformat, width, height, format, FLOAT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionParameterf(int target, int pname, float param)
        {
            Imports.glConvolutionParameterf(target, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ConvolutionParameteri(int target, int pname, int param)
        {
            Imports.glConvolutionParameteri(target, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyColorSubTable(int target, int start, int x, int y, int width)
        {
            Imports.glCopyColorSubTable(target, start, x, y, width);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyColorTable(int target, int publicformat, int x, int y, int width)
        {
            Imports.glCopyColorTable(target, publicformat, x, y, width);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyConvolutionFilter1D(int target, int publicformat, int x, int y, int width)
        {
            Imports.glCopyConvolutionFilter1D(target, publicformat, x, y, width);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyConvolutionFilter2D(int target, int publicformat, int x, int y, int width,
    int height)
        {
            Imports.glCopyConvolutionFilter2D(target, publicformat, x, y, width, height);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyPixels(int x, int y, int width, int height, int type)
        {
            Imports.glCopyPixels(x, y, width, height, type);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyTexImage1D(int target, int level, int publicformat, int x, int y,
    int width, int border)
        {
            Imports.glCopyTexImage1D(target, level, publicformat, x, y, width, border);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyTexImage2D(int target, int level, int publicformat, int x, int y,
    int width, int height, int border)
        {
            Imports.glCopyTexImage2D(target, level, publicformat, x, y, width, height, border);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyTexSubImage1D(int target, int level, int xoffset, int x, int y,
    int width)
        {
            Imports.glCopyTexSubImage1D(target, level, xoffset, x, y, width);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x,
    int y, int width, int height)
        {
            Imports.glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyTexSubImage3D(int target, int level, int xoffset, int yoffset, int zoffset,
    int x, int y, int width, int height)
        {
            Imports.glCopyTexSubImage3D(target, level, xoffset, yoffset, zoffset, x, y, width, height);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CreateProgram()
        {
            return Imports.glCreateProgram();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CreateShader(int shaderType)
        {
            return Imports.glCreateShader(shaderType);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CullFace(int mode)
        {
            Imports.glCullFace(mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DeleteBuffers(int n, int[] buffers) //NOTE deal with n
        {
            Imports.glDeleteBuffers(n, buffers);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DeleteLists(int list, int range)
        {
            Imports.glDeleteLists(list, range);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DeleteProgram(int program)
        {
            Imports.glDeleteProgram(program);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DeleteQueries(int n, int[] ids) //note deal with n
        {
            Imports.glDeleteQueries(n, ids);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DeleteShader(int shader)
        {
            Imports.glDeleteShader(shader);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DeleteTextures(int n, int[] textures) //note deal with n
        {
            Imports.glDeleteTextures(n, textures);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DepthFunc(int func)
        {
            Imports.glDepthFunc(func);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DepthMask(bool flag)
        {
            Imports.glDepthMask(flag);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DepthRange(double nearVal, double farVal)
        {
            Imports.glDepthRange(nearVal, farVal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DetachShader(int program, int shader)
        {
            Imports.glDetachShader(program, shader);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Disable(int cap)
        {
            Imports.glDisable(cap);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DisableClientState(int cap)
        {
            Imports.glDisableClientState(cap);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EnableVertexAttribArray(int index)
        {
            Imports.glEnableVertexAttribArray(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DisableVertexAttribArray(int index)
        {
            Imports.glDisableVertexAttribArray(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawArrays(int mode, int first, int count)
        {
            Imports.glDrawArrays(mode, first, count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawBuffer(int mode)
        {
            Imports.glDrawBuffer(mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawBuffers(int[] bufs)
        {
            Imports.glDrawBuffers(bufs.Length, bufs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawElements(int mode, int count, int type, object indices)
        {
            GCHandle pointer = GCHandle.Alloc(indices, GCHandleType.Pinned);
            Imports.glDrawElements(mode, count, type, pointer.AddrOfPinnedObject().ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawElements(int mode, int count, int type, void* indices)
        {
            Imports.glDrawElements(mode, count, type, indices);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawPixels(int width, int height, int format, sbyte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glDrawPixels(width, height, format, BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawPixels(int width, int height, int format, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glDrawPixels(width, height, format, UNSIGNED_BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawPixelsBitmap(int width, int height, int format, byte[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glDrawPixels(width, height, format, BITMAP, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawPixels(int width, int height, int format, short[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glDrawPixels(width, height, format, SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawPixels(int width, int height, int format, ushort[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glDrawPixels(width, height, format, UNSIGNED_SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawPixels(int width, int height, int format, int[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glDrawPixels(width, height, format, INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawPixels(int width, int height, int format, uint[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glDrawPixels(width, height, format, UNSIGNED_INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawPixels(int width, int height, int format, float[] data)
        {
            fixed (void* pointer = data)
            {
                Imports.glDrawPixels(width, height, format, FLOAT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawRangeElements(int mode, int start, int end, int count, byte[] indices)
        {
            fixed (void* pointer = indices)
            {
                Imports.glDrawRangeElements(mode, start, end, count, UNSIGNED_BYTE, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawRangeElements(int mode, int start, int end, int count, ushort[] indices)
        {
            fixed (void* pointer = indices)
            {
                Imports.glDrawRangeElements(mode, start, end, count, UNSIGNED_SHORT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DrawRangeElements(int mode, int start, int end, int count, uint[] indices)
        {
            fixed (void* pointer = indices)
            {
                Imports.glDrawRangeElements(mode, start, end, count, UNSIGNED_INT, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EdgeFlag(bool flag)
        {
            //Imports.glEdgeFlag(flag ? 1 : 0);
            Imports.glEdgeFlag(flag);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EdgeFlag(bool[] flag)
        {
            /*int[] result = new int[flag.Length];
            for (int i = 0; i < flag.Length; i++)
                result[i] = flag[i] ? 1 : 0;*/
            Imports.glEdgeFlagv(flag);
        }

        /*        [MethodImpl(MethodImplOptions.AggressiveInlining)]
public static void EdgeFlagPointer(bool[] flag)//useless piece of shit
        {
            Imports.glEdgeFlagPointer(0, flag);
        }*/

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Enable(int cap)
        {
            Imports.glEnable(cap);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EnableClientState(int cap)
        {
            Imports.glEnableClientState(cap);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void End()
        {
            Imports.glEnd();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EndList(int list, int mode)
        {
            Imports.glEndList(list, mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EndQuery(int target)
        {
            Imports.glEndQuery(target);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EvalCoord1(float u)
        {
            Imports.glEvalCoord1f(u);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EvalCoord1(double u)
        {
            Imports.glEvalCoord1d(u);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EvalCoord2(float u, float v)
        {
            Imports.glEvalCoord2f(u, v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EvalCoord2(double u, double v)
        {
            Imports.glEvalCoord2d(u, v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EvalMesh1(int mode, int i1, int i2)
        {
            Imports.glEvalMesh1(mode, i1, i2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EvalMesh2(int mode, int i1, int i2, int j1, int j2)
        {
            Imports.glEvalMesh2(mode, i1, i2, j1, j2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EvalPoint1(int i)
        {
            Imports.glEvalPoint1(i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EvalPoint2(int i, int j)
        {
            Imports.glEvalPoint2(i, j);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FeedbackBuffer(int size, int type, out float[] buffer)
        {
            Imports.glFeedbackBuffer(size, type, out buffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Finish()
        {
            Imports.glFinish();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Flush()
        {
            Imports.glFlush();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fog(int pname, float param)
        {
            Imports.glFogf(pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fog(int pname, int param)
        {
            Imports.glFogi(pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FogCoord(double coord)
        {
            Imports.glFogCoordd(coord);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FogCoord(float coord)
        {
            Imports.glFogCoordf(coord);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FogCoord(double[] coords)
        {
            fixed (void* pointer = coords)
            {
                Imports.glFogCoordPointer(DOUBLE, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FogCoord(float[] coords)
        {
            fixed (void* pointer = coords)
            {
                Imports.glFogCoordPointer(FLOAT, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FrontFace(int mode)
        {
            Imports.glFrontFace(mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Frustum(double left, double right, double bottom, double top, double nearVal,
    double farVal)
        {
            Imports.glFrustum(left, right, bottom, top, nearVal, farVal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GenerateMipmap(int target)
        {
            Imports.glGenerateMipmap(target);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GenerateTextureMipmap(int texture)
        {
            Imports.glGenerateTextureMipmap(texture);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GenBuffers(int n, ref int[] buffers)
        {
            fixed (int* pointer = buffers)
            {
                Imports.glGenBuffers(n, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GenBuffer()
        {
            int buffer;
            Imports.glGenBuffers(1, &buffer);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GenLists(int range)
        {
            Imports.glGenLists(range);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GenQueries(int n, ref int[] ids)
        {
            fixed (int* pointer = ids)
            {
                Imports.glGenQueries(n, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GenQuery()
        {
            int query;
            Imports.glGenQueries(1, &query);
            return query;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GenTexture()
        {
            int result;
            Imports.glGenTextures(1, &result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GenTextures(int count)
        {
            int[] result = new int[count];
            fixed (int* pointer = result)
            {
                Imports.glGenTextures(count, pointer);
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GenVertexArray()
        {
            int result;
            Imports.glGenVertexArrays(1, &result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GenVertexArrays(int count)
        {
            int[] result = new int[count];
            fixed (int* pointer = result)
            {
                Imports.glGenVertexArrays(count, pointer);
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool[] GetBoolean(int pname)
        {
            bool[] result;
            Imports.glGetBooleanv(pname, out result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] GetDouble(int pname)
        {
            double[] param;
            Imports.glGetDoublev(pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetFloat(int pname)
        {
            float[] param;
            Imports.glGetFloatv(pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetInteger(int pname)
        {
            int[] param;
            Imports.glGetIntegerv(pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetActiveAttrib(int program, int index, int bufSize, out int length, out int size, out int type, out string name)
        {
            Imports.glGetActiveAttrib(program, index, bufSize, out length, out size, out type, out name);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetActiveUniform(int program, int index, int bufSize, out int length, out int size, out int type, out string name)
        {
            Imports.glGetActiveUniform(program, index, bufSize, out length, out size, out type, out name);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetAttachedShaders(int program, int maxCount)
        {
            int count;
            int[] shaders;
            Imports.glGetAttachedShaders(program, maxCount, out count, out shaders);
            return shaders;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetAttribLocation(int program, string name)
        {
            return Imports.glGetAttribLocation(program, name);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetBufferParameter(int target, int value)
        {
            int[] data;
            Imports.glGetBufferParameteriv(target, value, out data);
            return data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBufferPointer(int target, int pname)
        {
            byte[] result;
            Imports.glGetBufferPointerv(target, pname, out result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBufferSubData(int target, int offset, int size)
        {
            byte[] data;
            Imports.glGetBufferSubData(target, offset, size, out data);
            return data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] GetClipPlane(int plane)
        {
            double[] equation;
            Imports.glGetClipPlane(plane, out equation);
            return equation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetColorTable(int target, int type, int format) //TODO~!!!!!!@!@!@!@
        {
            void* pointer;
            Imports.glGetColorTable(target, format, type, out pointer);
            return new IntPtr(pointer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetColorTableParameterfv(int target, int pname)
        {
            float[] param;
            Imports.glGetColorTableParameterfv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetColorTableParameteriv(int target, int pname)
        {
            int[] param;
            Imports.glGetColorTableParameteriv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetCompressedTexImage(int target, int lod)//TODO!@!@!@!@!@
        {
            IntPtr image;
            Imports.glGetCompressedTexImage(target, lod, out image);
            return image;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetConvolutionFilter(int target, int format, int type)//TODO!!@!@!@!@!@
        {
            IntPtr image;
            Imports.glGetConvolutionFilter(target, format, type, out image);
            return image;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetConvolutionParameterfv(int target, int pname)
        {
            float[] param;
            Imports.glGetConvolutionParameterfv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetConvolutionParameteriv(int target, int pname)
        {
            int[] param;
            Imports.glGetConvolutionParameteriv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetError()
        {
            return Imports.glGetError();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetHistogram(int target, bool reset, int format, int type) //TODO !@!@!@!@!@!
        {
            IntPtr values;
            Imports.glGetHistogram(target, reset, format, type, out values);
            return values;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetHistogramParameterfv(int target, int pname)
        {
            float[] param;
            Imports.glGetHistogramParameterfv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetHistogramParameteriv(int target, int pname)
        {
            int[] param;
            Imports.glGetHistogramParameteriv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetLightfv(int light, int pname)
        {
            float[] param;
            Imports.glGetLightfv(light, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetLightiv(int light, int pname)
        {
            int[] param;
            Imports.glGetLightiv(light, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] GetMapdv(int target, int query)
        {
            double[] v;
            Imports.glGetMapdv(target, query, out v);
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetMapfv(int target, int query)
        {
            float[] v;
            Imports.glGetMapfv(target, query, out v);
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetMapiv(int target, int query)
        {
            int[] v;
            Imports.glGetMapiv(target, query, out v);
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetMaterialfv(int face, int pname)
        {
            float[] param;
            Imports.glGetMaterialfv(face, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetMaterialiv(int face, int pname)
        {
            int[] param;
            Imports.glGetMaterialiv(face, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetMinmax(int target, bool reset, int format, int types)
        {
            IntPtr values;
            Imports.glGetMinmax(target, reset, format, types, out values);
            return values;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetMinmaxParameterfv(int target, int pname)
        {
            float[] param;
            Imports.glGetMinmaxParameterfv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetMinmaxParameteriv(int target, int pname)
        {
            int[] param;
            Imports.glGetMinmaxParameteriv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetPixelMapfv(int map)
        {
            float[] data;
            Imports.glGetPixelMapfv(map, out data);
            return data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetPixelMapuiv(int map)
        {
            int[] data;
            Imports.glGetPixelMapuiv(map, out data);
            return data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short[] GetPixelMapuv(int map)
        {
            short[] data;
            Imports.glGetPixelMapusv(map, out data);
            return data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetPointer(int pname)
        {
            IntPtr param;
            Imports.glGetPointerv(pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetPolygonStipple()
        {
            byte[] pattern;
            Imports.glGetPolygonStipple(out pattern);
            return pattern;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetProgram(int program, int pname)
        {
            int param;
            Imports.glGetProgramiv(program, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetProgramInfoLog(int program, int maxLength)
        {
            IntPtr s = Marshal.AllocHGlobal(maxLength);
            Imports.glGetProgramInfoLog(program, maxLength, null, s);
            return Marshal.PtrToStringAnsi(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetQueryObjectiv(int id, int pname)
        {
            int[] param;
            Imports.glGetQueryObjectiv(id, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetQueryObjectuiv(int id, int pname)
        {
            int[] param;
            Imports.glGetQueryObjectuiv(id, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetQueryiv(int target, int pname)
        {
            int[] param;
            Imports.glGetQueryiv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetSeparableFilter(int target, int format, int type, out IntPtr row, out IntPtr column, out IntPtr span) //TODO!@W!@!@!@!@!@!
        {
            Imports.glGetSeparableFilter(target, format, type, out row, out column, out span);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetShader(int shader, int pname)
        {
            int param;
            Imports.glGetShaderiv(shader, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetShaderInfoLog(int shader, int maxLength)
        {
            IntPtr s = Marshal.AllocHGlobal(maxLength);
            Imports.glGetShaderInfoLog(shader, maxLength, null, s);
            return Marshal.PtrToStringAnsi(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetShaderSource(int shader, int bufSize)
        {
            IntPtr s = Marshal.AllocHGlobal(bufSize);
            Imports.glGetShaderSource(shader, bufSize, null, s);
            return Marshal.PtrToStringAnsi(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetString(int name)
        {
            return Marshal.PtrToStringAnsi((IntPtr)Imports.glGetString(name));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetTexEnvfv(int target, int pname)
        {
            float[] param;
            Imports.glGetTexEnvfv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetTexEnviv(int target, int pname)
        {
            int[] param;
            Imports.glGetTexEnviv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] GetTexGendv(int coord, int pname)
        {
            double[] param;
            Imports.glGetTexGendv(coord, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetTexGenfv(int coord, int pname)
        {
            float[] param;
            Imports.glGetTexGenfv(coord, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetTexGeniv(int coord, int pname)
        {
            int[] param;
            Imports.glGetTexGeniv(coord, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetTexImage(int target, int level, int format, int type, void* img)
        {
            Imports.glGetTexImage(target, level, format, type, img);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetTexLevelParameterfv(int target, int level, int pname)
        {
            float[] param;
            Imports.glGetTexLevelParameterfv(target, level, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetTexLevelParameteriv(int target, int level, int pname)
        {
            int[] param;
            Imports.glGetTexLevelParameteriv(target, level, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetTexParameterfv(int target, int pname)
        {
            float[] param;
            Imports.glGetTexParameterfv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetTexParameteriv(int target, int pname)
        {
            int[] param;
            Imports.glGetTexParameteriv(target, pname, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] GetUniformfv(int program, int location)
        {
            float[] param;
            Imports.glGetUniformfv(program, location, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetUniformiv(int program, int location)
        {
            int[] param;
            Imports.glGetUniformiv(program, location, out param);
            return param;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetUniformLocation(int program, string name)
        {
            return Imports.glGetUniformLocation(program, name);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetVertexAttrib(int index, int pname, out double[] param)
        {
            Imports.glGetVertexAttribdv(index, pname, out param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetVertexAttrib(int index, int pname, out float[] param)
        {
            Imports.glGetVertexAttribfv(index, pname, out param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetVertexAttrib(int index, int pname, out int[] param)
        {
            Imports.glGetVertexAttribiv(index, pname, out param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetVertexAttribPointer(int index, int pname)
        {
            void* pointer;
            Imports.glGetVertexAttribPointerv(index, pname, out pointer);
            return new IntPtr(pointer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hint(int target, int mode)
        {
            Imports.glHint(target, mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Histogram(int target, int width, int publicformat, bool sink)
        {
            Imports.glHistogram(target, width, publicformat, sink);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Indexs(short c)
        {
            Imports.glIndexs(c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Indexi(int c)
        {
            Imports.glIndexi(c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Indexf(float c)
        {
            Imports.glIndexf(c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Indexd(double c)
        {
            Imports.glIndexd(c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Indexub(byte c)
        {
            Imports.glIndexub(c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IndexMask(int mask)
        {
            Imports.glIndexMask(mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IndexPointer(int type, int stride, IntPtr pointer)
        {
            Imports.glIndexPointer(type, stride, pointer.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InitNames()
        {
            Imports.glInitNames();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InterleavedArrays(int format, int stride, IntPtr pointer)
        {
            Imports.glInterleavedArrays(format, stride, pointer.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBuffer(int buffer)
        {
            return Imports.glIsBuffer(buffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEnabled(int cap)
        {
            return Imports.glIsEnabled(cap);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsList(int list)
        {
            return Imports.glIsList(list);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsProgram(int program)
        {
            return Imports.glIsProgram(program);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsQuery(int id)
        {
            return Imports.glIsQuery(id);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsShader(int shader)
        {
            return Imports.glIsShader(shader);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTexture(int texture)
        {
            return Imports.glIsTexture(texture);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Lightf(int light, int pname, float param)
        {
            Imports.glLightf(light, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Lighti(int light, int pname, int param)
        {
            Imports.glLighti(light, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LightModelf(int pname, float param)
        {
            Imports.glLightModelf(pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LightModeli(int pname, int param)
        {
            Imports.glLightModeli(pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LineStipple(int factor, short pattern)
        {
            Imports.glLineStipple(factor, pattern);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LineWidth(float width)
        {
            Imports.glLineWidth(width);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinkProgram(int program)
        {
            Imports.glLinkProgram(program);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ListBase(int b)
        {
            Imports.glListBase(b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LoadIdentity()
        {
            Imports.glLoadIdentity();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LoadMatrixd(double[] m)
        {
            Imports.glLoadMatrixd(m);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LoadMatrixf(float[] m)
        {
            Imports.glLoadMatrixf(m);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LoadName(int name)
        {
            Imports.glLoadName(name);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LoadTransposeMatrixd(double[] m)
        {
            Imports.glLoadTransposeMatrixd(m);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LoadTransposeMatrixf(float[] m)
        {
            Imports.glLoadTransposeMatrixf(m);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogicOp(int opcode)
        {
            Imports.glLogicOp(opcode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Map1(int target, float u1, float u2, int stride, int order, float[] points)
        {
            Imports.glMap1f(target, u1, u2, stride, order, points);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Map1(int target, double u1, double u2, int stride, int order, double[] points)
        {
            Imports.glMap1d(target, u1, u2, stride, order, points);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Map2(int target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, float[] points)
        {
            Imports.glMap2f(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Map2(int target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, double[] points)
        {
            Imports.glMap2d(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MapBuffer(int target, int access)
        {
            Imports.glMapBuffer(target, access);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MapGrid1d(int un, double u1, double u2)
        {
            Imports.glMapGrid1d(un, u1, u2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MapGrid1(int un, float u1, float u2)
        {
            Imports.glMapGrid1f(un, u1, u2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MapGrid2(int un, double u1, double u2, int vn, double v1, double v2)
        {
            Imports.glMapGrid2d(un, u1, u2, vn, v1, v2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MapGrid2(int un, float u1, float u2, int vn, float v1, float v2)
        {
            Imports.glMapGrid2f(un, u1, u2, vn, v1, v2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Material(int face, int pname, float param)
        {
            Imports.glMaterialf(face, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Material(int face, int pname, int param)
        {
            Imports.glMateriali(face, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MatrixMode(int mode)
        {
            Imports.glMatrixMode(mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Minmax(int target, int publicformat, bool sink)
        {
            Imports.glMinmax(target, publicformat, sink);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultMatrixd(double[] m)
        {
            Imports.glMultMatrixd(m);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultMatrixf(float[] m)
        {
            Imports.glMultMatrixf(m);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultTransposeMatrixd(double[] m)
        {
            Imports.glMultTransposeMatrixd(m);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultTransposeMatrixf(float[] m)
        {
            Imports.glMultTransposeMatrixf(m);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiDrawArrays(int mode, int[] first, int[] count, int primcount)
        {
            Imports.glMultiDrawArrays(mode, first, count, primcount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiDrawElements(int mode, int[] count, int type, IntPtr indices)
        {
            Imports.glMultiDrawElements(mode, count, type, indices.ToPointer(), count.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord1(int target, short s)
        {
            Imports.glMultiTexCoord1s(target, s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord1(int target, int s)
        {
            Imports.glMultiTexCoord1i(target, s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord1(int target, float s)
        {
            Imports.glMultiTexCoord1f(target, s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord1(int target, double s)
        {
            Imports.glMultiTexCoord1d(target, s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord2(int target, short s, short t)
        {
            Imports.glMultiTexCoord2s(target, s, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord2(int target, int s, int t)
        {
            Imports.glMultiTexCoord2i(target, s, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord2(int target, float s, float t)
        {
            Imports.glMultiTexCoord2f(target, s, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord2(int target, double s, double t)
        {
            Imports.glMultiTexCoord2d(target, s, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord3(int target, short s, short t, short r)
        {
            Imports.glMultiTexCoord3s(target, s, t, r);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord3(int target, int s, int t, int r)
        {
            Imports.glMultiTexCoord3i(target, s, t, r);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord3(int target, float s, float t, float r)
        {
            Imports.glMultiTexCoord3f(target, s, t, r);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord3(int target, double s, double t, double r)
        {
            Imports.glMultiTexCoord3d(target, s, t, r);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord4(int target, short s, short t, short r, short q)
        {
            Imports.glMultiTexCoord4s(target, s, t, r, q);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord4(int target, int s, int t, int r, int q)
        {
            Imports.glMultiTexCoord4i(target, s, t, r, q);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord4(int target, float s, float t, float r, float q)
        {
            Imports.glMultiTexCoord4f(target, s, t, r, q);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MultiTexCoord4(int target, double s, double t, double r, double q)
        {
            Imports.glMultiTexCoord4d(target, s, t, r, q);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NewListDelegate(int list, int mode)
        {
            Imports.glNewList(list, mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normal3b(byte nx, byte ny, byte nz)
        {
            Imports.glNormal3b(nx, ny, nz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normal3d(double nx, double ny, double nz)
        {
            Imports.glNormal3d(nx, ny, nz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normal3f(float nx, float ny, float nz)
        {
            Imports.glNormal3f(nx, ny, nz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normal3i(int nx, int ny, int nz)
        {
            Imports.glNormal3i(nx, ny, nz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normal3s(short nx, short ny, short nz)
        {
            Imports.glNormal3s(nx, ny, nz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NormalPointer(int type, int stride, IntPtr pointer)
        {
            Imports.glNormalPointer(type, stride, pointer.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ortho(double left, double right, double bottom, double top, double nearVal, double farVal)
        {
            Imports.glOrtho(left, right, bottom, top, nearVal, farVal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PassThrough(float token)
        {
            Imports.glPassThrough(token);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PixelMapfv(int map, int mapsize, float[] values)
        {
            Imports.glPixelMapfv(map, mapsize, values);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PixelMapuiv(int map, int mapsize, int[] values)
        {
            Imports.glPixelMapuiv(map, mapsize, values);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PixelMapusv(int map, int mapsize, short[] values)
        {
            Imports.glPixelMapusv(map, mapsize, values);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PixelStoref(int pname, float param)
        {
            Imports.glPixelStoref(pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PixelStorei(int pname, int param)
        {
            Imports.glPixelStorei(pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PixelTransferf(int pname, float param)
        {
            Imports.glPixelTransferf(pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PixelTransferi(int pname, int param)
        {
            Imports.glPixelTransferi(pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PixelZoom(float xfactor, float yfactor)
        {
            Imports.glPixelZoom(xfactor, yfactor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PointParameterf(int pname, float param)
        {
            Imports.glPointParameterf(pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PointParameteri(int pname, int param)
        {
            Imports.glPointParameteri(pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PointSize(float size)
        {
            Imports.glPointSize(size);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PolygonMode(int face, int mode)
        {
            Imports.glPolygonMode(face, mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PolygonOffset(float factor, float units)
        {
            Imports.glPolygonOffset(factor, units);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PolygonStipple(byte[] pattern)
        {
            Imports.glPolygonStipple(pattern);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PopAttrib(int mask)
        {
            Imports.glPopAttrib(mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PopClientAttrib()
        {
            Imports.glPopClientAttrib();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PopMatrix()
        {
            Imports.glPopMatrix();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PopName()
        {
            Imports.glPopName();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PrioritizeTextures(int[] textures, float[] priorities)
        {
            Imports.glPrioritizeTextures(textures.Length, textures, priorities);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PushAttrib(int mask)
        {
            Imports.glPushAttrib(mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PushClientAttrib(int mask)
        {
            Imports.glPushClientAttrib(mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PushMatrix()
        {
            Imports.glPushMatrix();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PushName(int name)
        {
            Imports.glPushName(name);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos2s(short x, short y)
        {
            Imports.glRasterPos2s(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos2i(int x, int y)
        {
            Imports.glRasterPos2i(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos2f(float x, float y)
        {
            Imports.glRasterPos2f(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos2d(double x, double y)
        {
            Imports.glRasterPos2d(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos3s(short x, short y, short z)
        {
            Imports.glRasterPos3s(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos3i(int x, int y, int z)
        {
            Imports.glRasterPos3i(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos3f(float x, float y, float z)
        {
            Imports.glRasterPos3f(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos3d(double x, double y, double z)
        {
            Imports.glRasterPos3d(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos4s(short x, short y, short z, short w)
        {
            Imports.glRasterPos4s(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos4i(int x, int y, int z, int w)
        {
            Imports.glRasterPos4i(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos4f(float x, float y, float z, float w)
        {
            Imports.glRasterPos4f(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RasterPos4d(double x, double y, double z, double w)
        {
            Imports.glRasterPos4d(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ReadBuffer(int mode)
        {
            Imports.glReadBuffer(mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr ReadPixels(int x, int y, int width, int height, int format, int type)
        {
            void* data;
            Imports.glReadPixels(x, y, width, height, format, type, out data);
            return new IntPtr(data);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rectd(double x1, double y1, double x2, double y2)
        {
            Imports.glRectd(x1, y1, x2, y2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rectf(float x1, float y1, float x2, float y2)
        {
            Imports.glRectf(x1, y1, x2, y2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Recti(int x1, int y1, int x2, int y2)
        {
            Imports.glRecti(x1, y1, x2, y2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rects(short x1, short y1, short x2, short y2)
        {
            Imports.glRects(x1, y1, x2, y2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RenderMode(int mode)
        {
            return Imports.glRenderMode(mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ResetHistogram(int target)
        {
            Imports.glResetHistogram(target);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ResetMinmax(int target)
        {
            Imports.glResetMinmax(target);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rotated(double angle, double x, double y, double z)
        {
            Imports.glRotated(angle, x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rotatef(float angle, float x, float y, float z)
        {
            Imports.glRotatef(angle, x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SampleCoverage(float value, bool invert)
        {
            Imports.glSampleCoverage(value, invert);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Scaled(double x, double y, double z)
        {
            Imports.glScaled(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Scalef(float x, float y, float z)
        {
            Imports.glScalef(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Scissor(int x, int y, int width, int height)
        {
            Imports.glScissor(x, y, width, height);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SecondaryColor3b(byte red, byte green, byte blue)
        {
            Imports.glSecondaryColor3b(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SecondaryColor3s(short red, short green, short blue)
        {
            Imports.glSecondaryColor3s(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SecondaryColor3i(int red, int green, int blue)
        {
            Imports.glSecondaryColor3i(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SecondaryColor3f(float red, float green, float blue)
        {
            Imports.glSecondaryColor3f(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SecondaryColor3d(double red, double green, double blue)
        {
            Imports.glSecondaryColor3d(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SecondaryColor3ub(byte red, byte green, byte blue)
        {
            Imports.glSecondaryColor3ub(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SecondaryColor3us(short red, short green, short blue)
        {
            Imports.glSecondaryColor3us(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SecondaryColor3ui(int red, int green, int blue)
        {
            Imports.glSecondaryColor3ui(red, green, blue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SecondaryColorPointer(int size, int type, int stride, IntPtr pointer)
        {
            Imports.glSecondaryColorPointer(size, type, stride, pointer.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SelectBuffer(ref int[] buffer)
        {
            Imports.glSelectBuffer(buffer.Length, ref buffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SeparableFilter2D(int target, int publicformat, int width, int height, int format, int type, IntPtr row, IntPtr column)
        {
            Imports.glSeparableFilter2D(target, publicformat, width, height, format, type, row.ToPointer(), column.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShadeModel(int mode)
        {
            Imports.glShadeModel(mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShaderSource(int shader, int count, string[] str, int[] length) //NOTE: deal with count
        {
            Imports.glShaderSource(shader, count, str, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilFunc(int func, int reference, int mask)
        {
            Imports.glStencilFunc(func, reference, mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilFuncSeparate(int face, int func, int reference, int mask)
        {
            Imports.glStencilFuncSeparate(face, func, reference, mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilMask(int mask)
        {
            Imports.glStencilMask(mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilMaskSeparate(int face, int mask)
        {
            Imports.glStencilMaskSeparate(face, mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilOp(int sfail, int dpfail, int dppass)
        {
            Imports.glStencilOp(sfail, dpfail, dppass);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StencilOpSeparate(int face, int sfail, int dpfail, int dppass)
        {
            Imports.glStencilOpSeparate(face, sfail, dpfail, dppass);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord1(short s)
        {
            Imports.glTexCoord1s(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord1(int s)
        {
            Imports.glTexCoord1i(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord1(float s)
        {
            Imports.glTexCoord1f(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord1(double s)
        {
            Imports.glTexCoord1d(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord2(short s, short t)
        {
            Imports.glTexCoord2s(s, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord2(int s, int t)
        {
            Imports.glTexCoord2i(s, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord2(float s, float t)
        {
            Imports.glTexCoord2f(s, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord2(double s, double t)
        {
            Imports.glTexCoord2d(s, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord3(short s, short t, short r)
        {
            Imports.glTexCoord3s(s, t, r);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord3(int s, int t, int r)
        {
            Imports.glTexCoord3i(s, t, r);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord3(float s, float t, float r)
        {
            Imports.glTexCoord3f(s, t, r);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord3(double s, double t, double r)
        {
            Imports.glTexCoord3d(s, t, r);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord4(short s, short t, short r, short q)
        {
            Imports.glTexCoord4s(s, t, r, q);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord4(int s, int t, int r, int q)
        {
            Imports.glTexCoord4i(s, t, r, q);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord4(float s, float t, float r, float q)
        {
            Imports.glTexCoord4f(s, t, r, q);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoord4(double s, double t, double r, double q)
        {
            Imports.glTexCoord4d(s, t, r, q);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoordPointer(void* pointer, int type, int size)
        {
            Imports.glTexCoordPointer(size, type, 0, pointer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoordPointer(short[] data, int size)
        {
            fixed (void* pointer = data)
            {
                Imports.glTexCoordPointer(size, SHORT, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoordPointer(int[] data, int size)
        {
            fixed (void* pointer = data)
            {
                Imports.glTexCoordPointer(size, INT, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoordPointer(float[] data, int size)
        {
            fixed (void* pointer = data)
            {
                Imports.glTexCoordPointer(size, FLOAT, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexCoordPointer(double[] data, int size)
        {
            fixed (void* pointer = data)
            {
                Imports.glTexCoordPointer(size, DOUBLE, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexEnv(int target, int pname, float param)
        {
            Imports.glTexEnvf(target, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexEnv(int target, int pname, int param)
        {
            Imports.glTexEnvi(target, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexGen(int coord, int pname, int param)
        {
            Imports.glTexGeni(coord, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexGen(int coord, int pname, float param)
        {
            Imports.glTexGenf(coord, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexGen(int coord, int pname, double param)
        {
            Imports.glTexGend(coord, pname, param);
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexImage1D(int target, int level, int publicFormat, int width, int border, int format, int type, IntPtr data)
        {
            Imports.glTexImage1D(target, level, publicFormat, width, border, format, type, data.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexImage2D(int target, int level, int publicFormat, int width, int height, int border, int format, int type, IntPtr data)
        {
            Imports.glTexImage2D(target, level, publicFormat, width, height, border, format, type, data.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexImage3D(int target, int level, int publicFormat, int width, int height, int depth, int border, int format, int type, IntPtr data)
        {
            Imports.glTexImage3D(target, level, publicFormat, width, height, depth, border, format, type, data.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexParameter(int target, int pname, float param)
        {
            Imports.glTexParameterf(target, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexParameter(int target, int pname, int param)
        {
            Imports.glTexParameteri(target, pname, param);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexStorage1D(int target, int levels, int internalformat, int width)
        {
            Imports.glTexStorage1D(target, levels, internalformat, width);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexStorage2D(int target, int levels, int internalformat, int width, int height)
        {
            Imports.glTexStorage2D(target, levels, internalformat, width, height);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexStorage3D(int target, int levels, int internalformat, int width, int height, int depth)
        {
            Imports.glTexStorage3D(target, levels, internalformat, width, height, depth);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexSubImage1D(int target, int level, int xoffset, int width, int format, int type, IntPtr data)
        {
            Imports.glTexSubImage1D(target, level, xoffset, width, format, type, data.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, IntPtr data)
        {
            Imports.glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, data.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TexSubImage3D(int target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int format, int type, IntPtr data)
        {
            Imports.glTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, data.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Translate(double x, double y, double z)
        {
            Imports.glTranslated(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Translate(float x, float y, float z)
        {
            Imports.glTranslatef(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform1(int location, float v0)
        {
            Imports.glUniform1f(location, v0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform2(int location, float v0, float v1)
        {
            Imports.glUniform2f(location, v0, v1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform3(int location, float v0, float v1, float v2)
        {
            Imports.glUniform3f(location, v0, v1, v2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform4(int location, float v0, float v1, float v2, float v3)
        {
            Imports.glUniform4f(location, v0, v1, v2, v3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform1(int location, int v0)
        {
            Imports.glUniform1i(location, v0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform2(int location, int v0, int v1)
        {
            Imports.glUniform2i(location, v0, v1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform3(int location, int v0, int v1, int v2)
        {
            Imports.glUniform3i(location, v0, v1, v2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform4(int location, int v0, int v1, int v2, int v3)
        {
            Imports.glUniform4i(location, v0, v1, v2, v3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform1(int location, double v0)
        {
            Imports.glUniform1d(location, v0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform2(int location, double v0, double v1)
        {
            Imports.glUniform2d(location, v0, v1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform3(int location, double v0, double v1, double v2)
        {
            Imports.glUniform3d(location, v0, v1, v2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Uniform4(int location, double v0, double v1, double v2, double v3)
        {
            Imports.glUniform4d(location, v0, v1, v2, v3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool UnmapBuffer(int target)
        {
            return Imports.glUnmapBuffer(target);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UseProgram(int program)
        {
            Imports.glUseProgram(program);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ValidateProgram(int program)
        {
            Imports.glValidateProgram(program);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex2(short x, short y)
        {
            Imports.glVertex2s(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex2(int x, int y)
        {
            Imports.glVertex2i(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex2(float x, float y)
        {
            Imports.glVertex2f(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex2(double x, double y)
        {
            Imports.glVertex2d(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex3(short x, short y, short z)
        {
            Imports.glVertex3s(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex3(int x, int y, int z)
        {
            Imports.glVertex3i(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex3(float x, float y, float z)
        {
            Imports.glVertex3f(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex3(double x, double y, double z)
        {
            Imports.glVertex3d(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex4(short x, short y, short z, short w)
        {
            Imports.glVertex4s(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex4(int x, int y, int z, int w)
        {
            Imports.glVertex4i(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex4(float x, float y, float z, float w)
        {
            Imports.glVertex4f(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Vertex4(double x, double y, double z, double w)
        {
            Imports.glVertex4d(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib1(int index, float v0)
        {
            Imports.glVertexAttrib1f(index, v0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib1(int index, short v0)
        {
            Imports.glVertexAttrib1s(index, v0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib1(int index, double v0)
        {
            Imports.glVertexAttrib1d(index, v0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib2(int index, float v0, float v1)
        {
            Imports.glVertexAttrib2f(index, v0, v1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib2(int index, short v0, short v1)
        {
            Imports.glVertexAttrib2s(index, v0, v1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib2(int index, double v0, double v1)
        {
            Imports.glVertexAttrib2d(index, v0, v1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib3(int index, float v0, float v1, float v2)
        {
            Imports.glVertexAttrib3f(index, v0, v1, v2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib3(int index, short v0, short v1, short v2)
        {
            Imports.glVertexAttrib3s(index, v0, v1, v2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib3(int index, double v0, double v1, double v2)
        {
            Imports.glVertexAttrib3d(index, v0, v1, v2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib4(int index, float v0, float v1, float v2, float v3)
        {
            Imports.glVertexAttrib4f(index, v0, v1, v2, v3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib4(int index, short v0, short v1, short v2, short v3)
        {
            Imports.glVertexAttrib4s(index, v0, v1, v2, v3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib4(int index, double v0, double v1, double v2, double v3)
        {
            Imports.glVertexAttrib4d(index, v0, v1, v2, v3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttrib4(int index, byte v0, byte v1, byte v2, byte v3)
        {
            Imports.glVertexAttrib4Nub(index, v0, v1, v2, v3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttribPointer(int index, int size, int type, bool normalized, int stride, IntPtr pointer)
        {
            Imports.glVertexAttribPointer(index, size, type, normalized, stride, pointer.ToPointer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexAttribPointer(int index, int size, int type, bool normalized, int stride, void* pointer)
        {
            Imports.glVertexAttribPointer(index, size, type, normalized, stride, pointer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexPointer(void* pointer, int type, int size)
        {
            Imports.glVertexPointer(size, type, 0, pointer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexPointer(int[] array, int size)
        {
            fixed (void* pointer = array)
            {
                Imports.glVertexPointer(size, INT, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexPointer(float[] array, int size)
        {
            fixed (void* pointer = array)
            {
                Imports.glVertexPointer(size, FLOAT, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexPointer(short[] array, int size)
        {
            fixed (void* pointer = array)
            {
                Imports.glVertexPointer(size, SHORT, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void VertexPointer(double[] array, int size)
        {
            fixed (void* pointer = array)
            {
                Imports.glVertexPointer(size, DOUBLE, 0, pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Viewport(int x, int y, int width, int height)
        {
            Imports.glViewport(x, y, width, height);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WindowPos2s(short x, short y)
        {
            Imports.glWindowPos2s(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WindowPos2i(int x, int y)
        {
            Imports.glWindowPos2i(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WindowPos2f(float x, float y)
        {
            Imports.glWindowPos2f(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WindowPos2d(double x, double y)
        {
            Imports.glWindowPos2d(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WindowPos3s(short x, short y, short z)
        {
            Imports.glWindowPos3s(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WindowPos3i(int x, int y, int z)
        {
            Imports.glWindowPos3i(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WindowPos3f(float x, float y, float z)
        {
            Imports.glWindowPos3f(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WindowPos3d(double x, double y, double z)
        {
            Imports.glWindowPos3d(x, y, z);
        }

        public struct UInt24
        {
            public byte First;
            public byte Second;
            public byte Third;
        }

        public struct Int24
        {
            public sbyte First;
            public sbyte Second;
            public sbyte Third;
        }

        public const int DEPTH_BUFFER_BIT = 0x00000100;
        public const int STENCIL_BUFFER_BIT = 0x00000400;
        public const int COLOR_BUFFER_BIT = 0x00004000;
        public const int FALSE = 0;
        public const int TRUE = 1;
        public const int POINTS = 0x0000;
        public const int LINES = 0x0001;
        public const int LINE_LOOP = 0x0002;
        public const int LINE_STRIP = 0x0003;
        public const int TRIANGLES = 0x0004;
        public const int TRIANGLE_STRIP = 0x0005;
        public const int TRIANGLE_FAN = 0x0006;
        public const int QUADS = 0x0007;
        public const int NEVER = 0x0200;
        public const int LESS = 0x0201;
        public const int EQUAL = 0x0202;
        public const int LEQUAL = 0x0203;
        public const int GREATER = 0x0204;
        public const int NOTEQUAL = 0x0205;
        public const int GEQUAL = 0x0206;
        public const int ALWAYS = 0x0207;
        public const int ZERO = 0;
        public const int ONE = 1;
        public const int SRC_COLOR = 0x0300;
        public const int ONE_MINUS_SRC_COLOR = 0x0301;
        public const int SRC_ALPHA = 0x0302;
        public const int ONE_MINUS_SRC_ALPHA = 0x0303;
        public const int DST_ALPHA = 0x0304;
        public const int ONE_MINUS_DST_ALPHA = 0x0305;
        public const int DST_COLOR = 0x0306;
        public const int ONE_MINUS_DST_COLOR = 0x0307;
        public const int SRC_ALPHA_SATURATE = 0x0308;
        public const int NONE = 0;
        public const int FRONT_LEFT = 0x0400;
        public const int FRONT_RIGHT = 0x0401;
        public const int BACK_LEFT = 0x0402;
        public const int BACK_RIGHT = 0x0403;
        public const int FRONT = 0x0404;
        public const int BACK = 0x0405;
        public const int LEFT = 0x0406;
        public const int RIGHT = 0x0407;
        public const int FRONT_AND_BACK = 0x0408;
        public const int NO_ERROR = 0;
        public const int INVALID_ENUM = 0x0500;
        public const int INVALID_VALUE = 0x0501;
        public const int INVALID_OPERATION = 0x0502;
        public const int OUT_OF_MEMORY = 0x0505;
        public const int CW = 0x0900;
        public const int CCW = 0x0901;
        public const int POINT_SIZE = 0x0B11;
        public const int POINT_SIZE_RANGE = 0x0B12;
        public const int POINT_SIZE_GRANULARITY = 0x0B13;
        public const int LINE_SMOOTH = 0x0B20;
        public const int LINE_WIDTH = 0x0B21;
        public const int LINE_WIDTH_RANGE = 0x0B22;
        public const int LINE_WIDTH_GRANULARITY = 0x0B23;
        public const int POLYGON_MODE = 0x0B40;
        public const int POLYGON_SMOOTH = 0x0B41;
        public const int CULL_FACE = 0x0B44;
        public const int CULL_FACE_MODE = 0x0B45;
        public const int FRONT_FACE = 0x0B46;
        public const int DEPTH_RANGE = 0x0B70;
        public const int DEPTH_TEST = 0x0B71;
        public const int DEPTH_WRITEMASK = 0x0B72;
        public const int DEPTH_CLEAR_VALUE = 0x0B73;
        public const int DEPTH_FUNC = 0x0B74;
        public const int STENCIL_TEST = 0x0B90;
        public const int STENCIL_CLEAR_VALUE = 0x0B91;
        public const int STENCIL_FUNC = 0x0B92;
        public const int STENCIL_VALUE_MASK = 0x0B93;
        public const int STENCIL_FAIL = 0x0B94;
        public const int STENCIL_PASS_DEPTH_FAIL = 0x0B95;
        public const int STENCIL_PASS_DEPTH_PASS = 0x0B96;
        public const int STENCIL_REF = 0x0B97;
        public const int STENCIL_WRITEMASK = 0x0B98;
        public const int VIEWPORT = 0x0BA2;
        public const int DITHER = 0x0BD0;
        public const int BLEND_DST = 0x0BE0;
        public const int BLEND_SRC = 0x0BE1;
        public const int BLEND = 0x0BE2;
        public const int LOGIC_OP_MODE = 0x0BF0;
        public const int COLOR_LOGIC_OP = 0x0BF2;
        public const int DRAW_BUFFER = 0x0C01;
        public const int READ_BUFFER = 0x0C02;
        public const int SCISSOR_BOX = 0x0C10;
        public const int SCISSOR_TEST = 0x0C11;
        public const int COLOR_CLEAR_VALUE = 0x0C22;
        public const int COLOR_WRITEMASK = 0x0C23;
        public const int DOUBLEBUFFER = 0x0C32;
        public const int STEREO = 0x0C33;
        public const int LINE_SMOOTH_Hint = 0x0C52;
        public const int POLYGON_SMOOTH_Hint = 0x0C53;
        public const int UNPACK_SWAP_BYTES = 0x0CF0;
        public const int UNPACK_LSB_FIRST = 0x0CF1;
        public const int UNPACK_ROW_LENGTH = 0x0CF2;
        public const int UNPACK_SKIP_ROWS = 0x0CF3;
        public const int UNPACK_SKIP_PIXELS = 0x0CF4;
        public const int UNPACK_ALIGNMENT = 0x0CF5;
        public const int PACK_SWAP_BYTES = 0x0D00;
        public const int PACK_LSB_FIRST = 0x0D01;
        public const int PACK_ROW_LENGTH = 0x0D02;
        public const int PACK_SKIP_ROWS = 0x0D03;
        public const int PACK_SKIP_PIXELS = 0x0D04;
        public const int PACK_ALIGNMENT = 0x0D05;
        public const int MAX_TEXTURE_SIZE = 0x0D33;
        public const int MAX_VIEWPORT_DIMS = 0x0D3A;
        public const int SUBPIXEL_BITS = 0x0D50;
        public const int TEXTURE_1D = 0x0DE0;
        public const int TEXTURE_2D = 0x0DE1;
        public const int TEXTURE_2D_ARRAY = 0x8C1A;
        public const int POLYGON_OFFSET_UNITS = 0x2A00;
        public const int POLYGON_OFFSET_POINT = 0x2A01;
        public const int POLYGON_OFFSET_LINE = 0x2A02;
        public const int POLYGON_OFFSET_FILL = 0x8037;
        public const int POLYGON_OFFSET_FACTOR = 0x8038;
        public const int TEXTURE_BINDING_1D = 0x8068;
        public const int TEXTURE_BINDING_2D = 0x8069;
        public const int TEXTURE_WIDTH = 0x1000;
        public const int TEXTURE_HEIGHT = 0x1001;
        public const int TEXTURE_INTERNAL_FORMAT = 0x1003;
        public const int TEXTURE_BORDER_COLOR = 0x1004;
        public const int TEXTURE_RED_SIZE = 0x805C;
        public const int TEXTURE_GREEN_SIZE = 0x805D;
        public const int TEXTURE_BLUE_SIZE = 0x805E;
        public const int TEXTURE_ALPHA_SIZE = 0x805F;
        public const int DONT_CARE = 0x1100;
        public const int FASTEST = 0x1101;
        public const int NICEST = 0x1102;
        public const int BYTE = 0x1400;
        public const int UNSIGNED_BYTE = 0x1401;
        public const int SHORT = 0x1402;
        public const int UNSIGNED_SHORT = 0x1403;
        public const int INT = 0x1404;
        public const int UNSIGNED_INT = 0x1405;
        public const int FLOAT = 0x1406;
        public const int DOUBLE = 0x140A;
        public const int STACK_OVERFLOW = 0x0503;
        public const int STACK_UNDERFLOW = 0x0504;
        public const int CLEAR = 0x1500;
        public const int AND = 0x1501;
        public const int AND_REVERSE = 0x1502;
        public const int COPY = 0x1503;
        public const int AND_INVERTED = 0x1504;
        public const int NOOP = 0x1505;
        public const int XOR = 0x1506;
        public const int OR = 0x1507;
        public const int NOR = 0x1508;
        public const int EQUIV = 0x1509;
        public const int INVERT = 0x150A;
        public const int OR_REVERSE = 0x150B;
        public const int COPY_INVERTED = 0x150C;
        public const int OR_INVERTED = 0x150D;
        public const int NAND = 0x150E;
        public const int SET = 0x150F;
        public const int TEXTURE = 0x1702;
        public const int COLOR = 0x1800;
        public const int DEPTH = 0x1801;
        public const int STENCIL = 0x1802;
        public const int STENCIL_INDEX = 0x1901;
        public const int DEPTH_COMPONENT = 0x1902;
        public const int RED = 0x1903;
        public const int GREEN = 0x1904;
        public const int BLUE = 0x1905;
        public const int ALPHA = 0x1906;
        public const int RGB = 0x1907;
        public const int RGBA = 0x1908;
        public const int POint = 0x1B00;
        public const int LINE = 0x1B01;
        public const int FILL = 0x1B02;
        public const int KEEP = 0x1E00;
        public const int REPLACE = 0x1E01;
        public const int INCR = 0x1E02;
        public const int DECR = 0x1E03;
        public const int VENDOR = 0x1F00;
        public const int RENDERER = 0x1F01;
        public const int VERSION = 0x1F02;
        public const int EXTENSIONS = 0x1F03;
        public const int NEAREST = 0x2600;
        public const int LINEAR = 0x2601;
        public const int NEAREST_MIPMAP_NEAREST = 0x2700;
        public const int LINEAR_MIPMAP_NEAREST = 0x2701;
        public const int NEAREST_MIPMAP_LINEAR = 0x2702;
        public const int LINEAR_MIPMAP_LINEAR = 0x2703;
        public const int TEXTURE_MAG_FILTER = 0x2800;
        public const int TEXTURE_MIN_FILTER = 0x2801;
        public const int TEXTURE_WRAP_S = 0x2802;
        public const int TEXTURE_WRAP_T = 0x2803;
        public const int PROXY_TEXTURE_1D = 0x8063;
        public const int PROXY_TEXTURE_2D = 0x8064;
        public const int REPEAT = 0x2901;
        public const int R3_G3_B2 = 0x2A10;
        public const int RGB4 = 0x804F;
        public const int RGB5 = 0x8050;
        public const int RGB8 = 0x8051;
        public const int RGB10 = 0x8052;
        public const int RGB12 = 0x8053;
        public const int RGB16 = 0x8054;
        public const int RGBA2 = 0x8055;
        public const int RGBA4 = 0x8056;
        public const int RGB5_A1 = 0x8057;
        public const int RGBA8 = 0x8058;
        public const int RGB10_A2 = 0x8059;
        public const int RGBA12 = 0x805A;
        public const int RGBA16 = 0x805B;
        public const int CURRENT_BIT = 0x00000001;
        public const int POINT_BIT = 0x00000002;
        public const int LINE_BIT = 0x00000004;
        public const int POLYGON_BIT = 0x00000008;
        public const int POLYGON_STIPPLE_BIT = 0x00000010;
        public const int PIXEL_MODE_BIT = 0x00000020;
        public const int LIGHTING_BIT = 0x00000040;
        public const int FOG_BIT = 0x00000080;
        public const int ACCUM_BUFFER_BIT = 0x00000200;
        public const int VIEWPORT_BIT = 0x00000800;
        public const int TRANSFORM_BIT = 0x00001000;
        public const int ENABLE_BIT = 0x00002000;
        public const int HINT_BIT = 0x00008000;
        public const int EVAL_BIT = 0x00010000;
        public const int LIST_BIT = 0x00020000;
        public const int TEXTURE_BIT = 0x00040000;
        public const int SCISSOR_BIT = 0x00080000;
        public const uint ALL_ATTRIB_BITS = 0xFFFFFFFF;
        public const uint CLIENT_PIXEL_STORE_BIT = 0x00000001;
        public const int CLIENT_VERTEX_ARRAY_BIT = 0x00000002;
        public const uint CLIENT_ALL_ATTRIB_BITS = 0xFFFFFFFF;
        public const int QUAD_STRIP = 0x0008;
        public const int POLYGON = 0x0009;
        public const int ACCUM = 0x0100;
        public const int LOAD = 0x0101;
        public const int RETURN = 0x0102;
        public const int MULT = 0x0103;
        public const int ADD = 0x0104;
        public const int AUX0 = 0x0409;
        public const int AUX1 = 0x040A;
        public const int AUX2 = 0x040B;
        public const int AUX3 = 0x040C;
        public const int GL_2D = 0x0600;
        public const int GL_3D = 0x0601;
        public const int GL_3D_COLOR = 0x0602;
        public const int GL_3D_COLOR_TEXTURE = 0x0603;
        public const int GL_4D_COLOR_TEXTURE = 0x0604;
        public const int PASS_THROUGH_TOKEN = 0x0700;
        public const int POINT_TOKEN = 0x0701;
        public const int LINE_TOKEN = 0x0702;
        public const int POLYGON_TOKEN = 0x0703;
        public const int BITMAP_TOKEN = 0x0704;
        public const int DRAW_PIXEL_TOKEN = 0x0705;
        public const int COPY_PIXEL_TOKEN = 0x0706;
        public const int LINE_RESET_TOKEN = 0x0707;
        public const int EXP = 0x0800;
        public const int EXP2 = 0x0801;
        public const int COEFF = 0x0A00;
        public const int ORDER = 0x0A01;
        public const int DOMAIN = 0x0A02;
        public const int PIXEL_MAP_I_TO_I = 0x0C70;
        public const int PIXEL_MAP_S_TO_S = 0x0C71;
        public const int PIXEL_MAP_I_TO_R = 0x0C72;
        public const int PIXEL_MAP_I_TO_G = 0x0C73;
        public const int PIXEL_MAP_I_TO_B = 0x0C74;
        public const int PIXEL_MAP_I_TO_A = 0x0C75;
        public const int PIXEL_MAP_R_TO_R = 0x0C76;
        public const int PIXEL_MAP_G_TO_G = 0x0C77;
        public const int PIXEL_MAP_B_TO_B = 0x0C78;
        public const int PIXEL_MAP_A_TO_A = 0x0C79;
        public const int VERTEX_ARRAY_POINTER = 0x808E;
        public const int NORMAL_ARRAY_POINTER = 0x808F;
        public const int COLOR_ARRAY_POINTER = 0x8090;
        public const int INDEX_ARRAY_POINTER = 0x8091;
        public const int TEXTURE_COORD_ARRAY_POINTER = 0x8092;
        public const int EDGE_FLAG_ARRAY_POINTER = 0x8093;
        public const int FEEDBACK_BUFFER_POINTER = 0x0DF0;
        public const int SELECTION_BUFFER_POINTER = 0x0DF3;
        public const int CURRENT_COLOR = 0x0B00;
        public const int CURRENT_INDEX = 0x0B01;
        public const int CURRENT_NORMAL = 0x0B02;
        public const int CURRENT_TEXTURE_COORDS = 0x0B03;
        public const int CURRENT_RASTER_COLOR = 0x0B04;
        public const int CURRENT_RASTER_INDEX = 0x0B05;
        public const int CURRENT_RASTER_TEXTURE_COORDS = 0x0B06;
        public const int CURRENT_RASTER_POSITION = 0x0B07;
        public const int CURRENT_RASTER_POSITION_VALID = 0x0B08;
        public const int CURRENT_RASTER_DISTANCE = 0x0B09;
        public const int POINT_SMOOTH = 0x0B10;
        public const int LINE_STIPPLE = 0x0B24;
        public const int LINE_STIPPLE_PATTERN = 0x0B25;
        public const int LINE_STIPPLE_REPEAT = 0x0B26;
        public const int LIST_MODE = 0x0B30;
        public const int MAX_LIST_NESTING = 0x0B31;
        public const int LIST_BASE = 0x0B32;
        public const int LIST_INDEX = 0x0B33;
        public const int POLYGON_STIPPLE = 0x0B42;
        public const int EDGE_FLAG = 0x0B43;
        public const int LIGHTING = 0x0B50;
        public const int LIGHT_MODEL_LOCAL_VIEWER = 0x0B51;
        public const int LIGHT_MODEL_TWO_SIDE = 0x0B52;
        public const int LIGHT_MODEL_AMBIENT = 0x0B53;
        public const int SHADE_MODEL = 0x0B54;
        public const int COLOR_MATERIAL_FACE = 0x0B55;
        public const int COLOR_MATERIAL_PARAMETER = 0x0B56;
        public const int COLOR_MATERIAL = 0x0B57;
        public const int FOG = 0x0B60;
        public const int FOG_INDEX = 0x0B61;
        public const int FOG_DENSITY = 0x0B62;
        public const int FOG_START = 0x0B63;
        public const int FOG_END = 0x0B64;
        public const int FOG_MODE = 0x0B65;
        public const int FOG_COLOR = 0x0B66;
        public const int ACCUM_CLEAR_VALUE = 0x0B80;
        public const int MATRIX_MODE = 0x0BA0;
        public const int NORMALIZE = 0x0BA1;
        public const int MODELVIEW_STACK_DEPTH = 0x0BA3;
        public const int PROJECTION_STACK_DEPTH = 0x0BA4;
        public const int TEXTURE_STACK_DEPTH = 0x0BA5;
        public const int MODELVIEW_MATRIX = 0x0BA6;
        public const int PROJECTION_MATRIX = 0x0BA7;
        public const int TEXTURE_MATRIX = 0x0BA8;
        public const int ATTRIB_STACK_DEPTH = 0x0BB0;
        public const int CLIENT_ATTRIB_STACK_DEPTH = 0x0BB1;
        public const int ALPHA_TEST = 0x0BC0;
        public const int ALPHA_TEST_FUNC = 0x0BC1;
        public const int ALPHA_TEST_REF = 0x0BC2;
        public const int INDEX_LOGIC_OP = 0x0BF1;
        public const int LOGIC_OP = 0x0BF1;
        public const int AUX_BUFFERS = 0x0C00;
        public const int INDEX_CLEAR_VALUE = 0x0C20;
        public const int INDEX_WRITEMASK = 0x0C21;
        public const int INDEX_MODE = 0x0C30;
        public const int RGBA_MODE = 0x0C31;
        public const int RENDER_MODE = 0x0C40;
        public const int PERSPECTIVE_CORRECTION_Hint = 0x0C50;
        public const int POINT_SMOOTH_Hint = 0x0C51;
        public const int FOG_Hint = 0x0C54;
        public const int TEXTURE_GEN_S = 0x0C60;
        public const int TEXTURE_GEN_T = 0x0C61;
        public const int TEXTURE_GEN_R = 0x0C62;
        public const int TEXTURE_GEN_Q = 0x0C63;
        public const int PIXEL_MAP_I_TO_I_SIZE = 0x0CB0;
        public const int PIXEL_MAP_S_TO_S_SIZE = 0x0CB1;
        public const int PIXEL_MAP_I_TO_R_SIZE = 0x0CB2;
        public const int PIXEL_MAP_I_TO_G_SIZE = 0x0CB3;
        public const int PIXEL_MAP_I_TO_B_SIZE = 0x0CB4;
        public const int PIXEL_MAP_I_TO_A_SIZE = 0x0CB5;
        public const int PIXEL_MAP_R_TO_R_SIZE = 0x0CB6;
        public const int PIXEL_MAP_G_TO_G_SIZE = 0x0CB7;
        public const int PIXEL_MAP_B_TO_B_SIZE = 0x0CB8;
        public const int PIXEL_MAP_A_TO_A_SIZE = 0x0CB9;
        public const int MAP_COLOR = 0x0D10;
        public const int MAP_STENCIL = 0x0D11;
        public const int INDEX_SHIFT = 0x0D12;
        public const int INDEX_OFFSET = 0x0D13;
        public const int RED_SCALE = 0x0D14;
        public const int RED_BIAS = 0x0D15;
        public const int ZOOM_X = 0x0D16;
        public const int ZOOM_Y = 0x0D17;
        public const int GREEN_SCALE = 0x0D18;
        public const int GREEN_BIAS = 0x0D19;
        public const int BLUE_SCALE = 0x0D1A;
        public const int BLUE_BIAS = 0x0D1B;
        public const int ALPHA_SCALE = 0x0D1C;
        public const int ALPHA_BIAS = 0x0D1D;
        public const int DEPTH_SCALE = 0x0D1E;
        public const int DEPTH_BIAS = 0x0D1F;
        public const int MAX_EVAL_ORDER = 0x0D30;
        public const int MAX_LIGHTS = 0x0D31;
        public const int MAX_CLIP_PLANES = 0x0D32;
        public const int MAX_PIXEL_MAP_TABLE = 0x0D34;
        public const int MAX_ATTRIB_STACK_DEPTH = 0x0D35;
        public const int MAX_MODELVIEW_STACK_DEPTH = 0x0D36;
        public const int MAX_NAME_STACK_DEPTH = 0x0D37;
        public const int MAX_PROJECTION_STACK_DEPTH = 0x0D38;
        public const int MAX_TEXTURE_STACK_DEPTH = 0x0D39;
        public const int MAX_CLIENT_ATTRIB_STACK_DEPTH = 0x0D3B;
        public const int INDEX_BITS = 0x0D51;
        public const int RED_BITS = 0x0D52;
        public const int GREEN_BITS = 0x0D53;
        public const int BLUE_BITS = 0x0D54;
        public const int ALPHA_BITS = 0x0D55;
        public const int DEPTH_BITS = 0x0D56;
        public const int STENCIL_BITS = 0x0D57;
        public const int ACCUM_RED_BITS = 0x0D58;
        public const int ACCUM_GREEN_BITS = 0x0D59;
        public const int ACCUM_BLUE_BITS = 0x0D5A;
        public const int ACCUM_ALPHA_BITS = 0x0D5B;
        public const int NAME_STACK_DEPTH = 0x0D70;
        public const int AUTO_NORMAL = 0x0D80;
        public const int MAP1_COLOR_4 = 0x0D90;
        public const int MAP1_INDEX = 0x0D91;
        public const int MAP1_NORMAL = 0x0D92;
        public const int MAP1_TEXTURE_COORD_1 = 0x0D93;
        public const int MAP1_TEXTURE_COORD_2 = 0x0D94;
        public const int MAP1_TEXTURE_COORD_3 = 0x0D95;
        public const int MAP1_TEXTURE_COORD_4 = 0x0D96;
        public const int MAP1_VERTEX_3 = 0x0D97;
        public const int MAP1_VERTEX_4 = 0x0D98;
        public const int MAP2_COLOR_4 = 0x0DB0;
        public const int MAP2_INDEX = 0x0DB1;
        public const int MAP2_NORMAL = 0x0DB2;
        public const int MAP2_TEXTURE_COORD_1 = 0x0DB3;
        public const int MAP2_TEXTURE_COORD_2 = 0x0DB4;
        public const int MAP2_TEXTURE_COORD_3 = 0x0DB5;
        public const int MAP2_TEXTURE_COORD_4 = 0x0DB6;
        public const int MAP2_VERTEX_3 = 0x0DB7;
        public const int MAP2_VERTEX_4 = 0x0DB8;
        public const int MAP1_GRID_DOMAIN = 0x0DD0;
        public const int MAP1_GRID_SEGMENTS = 0x0DD1;
        public const int MAP2_GRID_DOMAIN = 0x0DD2;
        public const int MAP2_GRID_SEGMENTS = 0x0DD3;
        public const int FEEDBACK_BUFFER_SIZE = 0x0DF1;
        public const int FEEDBACK_BUFFER_TYPE = 0x0DF2;
        public const int SELECTION_BUFFER_SIZE = 0x0DF4;
        public const int VERTEX_ARRAY = 0x8074;
        public const int NORMAL_ARRAY = 0x8075;
        public const int COLOR_ARRAY = 0x8076;
        public const int INDEX_ARRAY = 0x8077;
        public const int TEXTURE_COORD_ARRAY = 0x8078;
        public const int EDGE_FLAG_ARRAY = 0x8079;
        public const int VERTEX_ARRAY_SIZE = 0x807A;
        public const int VERTEX_ARRAY_TYPE = 0x807B;
        public const int VERTEX_ARRAY_STRIDE = 0x807C;
        public const int NORMAL_ARRAY_TYPE = 0x807E;
        public const int NORMAL_ARRAY_STRIDE = 0x807F;
        public const int COLOR_ARRAY_SIZE = 0x8081;
        public const int COLOR_ARRAY_TYPE = 0x8082;
        public const int COLOR_ARRAY_STRIDE = 0x8083;
        public const int INDEX_ARRAY_TYPE = 0x8085;
        public const int INDEX_ARRAY_STRIDE = 0x8086;
        public const int TEXTURE_COORD_ARRAY_SIZE = 0x8088;
        public const int TEXTURE_COORD_ARRAY_TYPE = 0x8089;
        public const int TEXTURE_COORD_ARRAY_STRIDE = 0x808A;
        public const int EDGE_FLAG_ARRAY_STRIDE = 0x808C;
        public const int TEXTURE_COMPONENTS = 0x1003;
        public const int TEXTURE_BORDER = 0x1005;
        public const int TEXTURE_LUMINANCE_SIZE = 0x8060;
        public const int TEXTURE_INTENSITY_SIZE = 0x8061;
        public const int TEXTURE_PRIORITY = 0x8066;
        public const int TEXTURE_RESIDENT = 0x8067;
        public const int AMBIENT = 0x1200;
        public const int DIFFUSE = 0x1201;
        public const int SPECULAR = 0x1202;
        public const int POSITION = 0x1203;
        public const int SPOT_DIRECTION = 0x1204;
        public const int SPOT_EXPONENT = 0x1205;
        public const int SPOT_CUTOFF = 0x1206;
        public const int CONSTANT_ATTENUATION = 0x1207;
        public const int LINEAR_ATTENUATION = 0x1208;
        public const int QUADRATIC_ATTENUATION = 0x1209;
        public const int COMPILE = 0x1300;
        public const int COMPILE_AND_EXECUTE = 0x1301;
        public const int GL_2_BYTES = 0x1407;
        public const int GL_3_BYTES = 0x1408;
        public const int GL_4_BYTES = 0x1409;
        public const int EMISSION = 0x1600;
        public const int SHININESS = 0x1601;
        public const int AMBIENT_AND_DIFFUSE = 0x1602;
        public const int COLOR_INDEXES = 0x1603;
        public const int MODELVIEW = 0x1700;
        public const int PROJECTION = 0x1701;
        public const int COLOR_INDEX = 0x1900;
        public const int LUMINANCE = 0x1909;
        public const int LUMINANCE_ALPHA = 0x190A;
        public const int BITMAP = 0x1A00;
        public const int RENDER = 0x1C00;
        public const int FEEDBACK = 0x1C01;
        public const int SELECT = 0x1C02;
        public const int FLAT = 0x1D00;
        public const int SMOOTH = 0x1D01;
        public const int S = 0x2000;
        public const int T = 0x2001;
        public const int R = 0x2002;
        public const int Q = 0x2003;
        public const int MODULATE = 0x2100;
        public const int DECAL = 0x2101;
        public const int TEXTURE_ENV_MODE = 0x2200;
        public const int TEXTURE_ENV_COLOR = 0x2201;
        public const int TEXTURE_ENV = 0x2300;
        public const int EYE_LINEAR = 0x2400;
        public const int OBJECT_LINEAR = 0x2401;
        public const int SPHERE_MAP = 0x2402;
        public const int TEXTURE_GEN_MODE = 0x2500;
        public const int OBJECT_PLANE = 0x2501;
        public const int EYE_PLANE = 0x2502;
        public const int CLAMP = 0x2900;
        public const int ALPHA4 = 0x803B;
        public const int ALPHA8 = 0x803C;
        public const int ALPHA12 = 0x803D;
        public const int ALPHA16 = 0x803E;
        public const int LUMINANCE4 = 0x803F;
        public const int LUMINANCE8 = 0x8040;
        public const int LUMINANCE12 = 0x8041;
        public const int LUMINANCE16 = 0x8042;
        public const int LUMINANCE4_ALPHA4 = 0x8043;
        public const int LUMINANCE6_ALPHA2 = 0x8044;
        public const int LUMINANCE8_ALPHA8 = 0x8045;
        public const int LUMINANCE12_ALPHA4 = 0x8046;
        public const int LUMINANCE12_ALPHA12 = 0x8047;
        public const int LUMINANCE16_ALPHA16 = 0x8048;
        public const int INTENSITY = 0x8049;
        public const int INTENSITY4 = 0x804A;
        public const int INTENSITY8 = 0x804B;
        public const int INTENSITY12 = 0x804C;
        public const int INTENSITY16 = 0x804D;
        public const int V2F = 0x2A20;
        public const int V3F = 0x2A21;
        public const int C4UB_V2F = 0x2A22;
        public const int C4UB_V3F = 0x2A23;
        public const int C3F_V3F = 0x2A24;
        public const int N3F_V3F = 0x2A25;
        public const int C4F_N3F_V3F = 0x2A26;
        public const int T2F_V3F = 0x2A27;
        public const int T4F_V4F = 0x2A28;
        public const int T2F_C4UB_V3F = 0x2A29;
        public const int T2F_C3F_V3F = 0x2A2A;
        public const int T2F_N3F_V3F = 0x2A2B;
        public const int T2F_C4F_N3F_V3F = 0x2A2C;
        public const int T4F_C4F_N3F_V4F = 0x2A2D;
        public const int CLIP_PLANE0 = 0x3000;
        public const int CLIP_PLANE1 = 0x3001;
        public const int CLIP_PLANE2 = 0x3002;
        public const int CLIP_PLANE3 = 0x3003;
        public const int CLIP_PLANE4 = 0x3004;
        public const int CLIP_PLANE5 = 0x3005;
        public const int LIGHT0 = 0x4000;
        public const int LIGHT1 = 0x4001;
        public const int LIGHT2 = 0x4002;
        public const int LIGHT3 = 0x4003;
        public const int LIGHT4 = 0x4004;
        public const int LIGHT5 = 0x4005;
        public const int LIGHT6 = 0x4006;
        public const int LIGHT7 = 0x4007;
        public const int UNSIGNED_BYTE_3_3_2 = 0x8032;
        public const int UNSIGNED_SHORT_4_4_4_4 = 0x8033;
        public const int UNSIGNED_SHORT_5_5_5_1 = 0x8034;
        public const int UNSIGNED_INT_8_8_8_8 = 0x8035;
        public const int UNSIGNED_INT_10_10_10_2 = 0x8036;
        public const int TEXTURE_BINDING_3D = 0x806A;
        public const int PACK_SKIP_IMAGES = 0x806B;
        public const int PACK_IMAGE_HEIGHT = 0x806C;
        public const int UNPACK_SKIP_IMAGES = 0x806D;
        public const int UNPACK_IMAGE_HEIGHT = 0x806E;
        public const int TEXTURE_3D = 0x806F;
        public const int PROXY_TEXTURE_3D = 0x8070;
        public const int TEXTURE_DEPTH = 0x8071;
        public const int TEXTURE_WRAP_R = 0x8072;
        public const int MAX_3D_TEXTURE_SIZE = 0x8073;
        public const int UNSIGNED_BYTE_2_3_3_REV = 0x8362;
        public const int UNSIGNED_SHORT_5_6_5 = 0x8363;
        public const int UNSIGNED_SHORT_5_6_5_REV = 0x8364;
        public const int UNSIGNED_SHORT_4_4_4_4_REV = 0x8365;
        public const int UNSIGNED_SHORT_1_5_5_5_REV = 0x8366;
        public const int UNSIGNED_INT_8_8_8_8_REV = 0x8367;
        public const int UNSIGNED_INT_2_10_10_10_REV = 0x8368;
        public const int BGR = 0x80E0;
        public const int BGRA = 0x80E1;
        public const int MAX_ELEMENTS_VERTICES = 0x80E8;
        public const int MAX_ELEMENTS_INDICES = 0x80E9;
        public const int CLAMP_TO_EDGE = 0x812F;
        public const int TEXTURE_MIN_LOD = 0x813A;
        public const int TEXTURE_MAX_LOD = 0x813B;
        public const int TEXTURE_BASE_LEVEL = 0x813C;
        public const int TEXTURE_MAX_LEVEL = 0x813D;
        public const int SMOOTH_POINT_SIZE_RANGE = 0x0B12;
        public const int SMOOTH_POINT_SIZE_GRANULARITY = 0x0B13;
        public const int SMOOTH_LINE_WIDTH_RANGE = 0x0B22;
        public const int SMOOTH_LINE_WIDTH_GRANULARITY = 0x0B23;
        public const int ALIASED_LINE_WIDTH_RANGE = 0x846E;
        public const int RESCALE_NORMAL = 0x803A;
        public const int LIGHT_MODEL_COLOR_CONTROL = 0x81F8;
        public const int SINGLE_COLOR = 0x81F9;
        public const int SEPARATE_SPECULAR_COLOR = 0x81FA;
        public const int ALIASED_POINT_SIZE_RANGE = 0x846D;
        public const int CONSTANT_COLOR = 0x8001;
        public const int ONE_MINUS_CONSTANT_COLOR = 0x8002;
        public const int CONSTANT_ALPHA = 0x8003;
        public const int ONE_MINUS_CONSTANT_ALPHA = 0x8004;
        public const int BLEND_COLOR = 0x8005;
        public const int FUNC_ADD = 0x8006;
        public const int MIN = 0x8007;
        public const int MAX = 0x8008;
        public const int BLEND_EQUATION = 0x8009;
        public const int FUNC_SUBTRACT = 0x800A;
        public const int FUNC_REVERSE_SUBTRACT = 0x800B;
        public const int CONVOLUTION_1D = 0x8010;
        public const int CONVOLUTION_2D = 0x8011;
        public const int SEPARABLE_2D = 0x8012;
        public const int CONVOLUTION_BORDER_MODE = 0x8013;
        public const int CONVOLUTION_FILTER_SCALE = 0x8014;
        public const int CONVOLUTION_FILTER_BIAS = 0x8015;
        public const int REDUCE = 0x8016;
        public const int CONVOLUTION_FORMAT = 0x8017;
        public const int CONVOLUTION_WIDTH = 0x8018;
        public const int CONVOLUTION_HEIGHT = 0x8019;
        public const int MAX_CONVOLUTION_WIDTH = 0x801A;
        public const int MAX_CONVOLUTION_HEIGHT = 0x801B;
        public const int POST_CONVOLUTION_RED_SCALE = 0x801C;
        public const int POST_CONVOLUTION_GREEN_SCALE = 0x801D;
        public const int POST_CONVOLUTION_BLUE_SCALE = 0x801E;
        public const int POST_CONVOLUTION_ALPHA_SCALE = 0x801F;
        public const int POST_CONVOLUTION_RED_BIAS = 0x8020;
        public const int POST_CONVOLUTION_GREEN_BIAS = 0x8021;
        public const int POST_CONVOLUTION_BLUE_BIAS = 0x8022;
        public const int POST_CONVOLUTION_ALPHA_BIAS = 0x8023;
        public const int HISTOGRAM = 0x8024;
        public const int PROXY_HISTOGRAM = 0x8025;
        public const int HISTOGRAM_WIDTH = 0x8026;
        public const int HISTOGRAM_FORMAT = 0x8027;
        public const int HISTOGRAM_RED_SIZE = 0x8028;
        public const int HISTOGRAM_GREEN_SIZE = 0x8029;
        public const int HISTOGRAM_BLUE_SIZE = 0x802A;
        public const int HISTOGRAM_ALPHA_SIZE = 0x802B;
        public const int HISTOGRAM_LUMINANCE_SIZE = 0x802C;
        public const int HISTOGRAM_SINK = 0x802D;
        public const int MINMAX = 0x802E;
        public const int MINMAX_FORMAT = 0x802F;
        public const int MINMAX_SINK = 0x8030;
        public const int TABLE_TOO_LARGE = 0x8031;
        public const int COLOR_MATRIX = 0x80B1;
        public const int COLOR_MATRIX_STACK_DEPTH = 0x80B2;
        public const int MAX_COLOR_MATRIX_STACK_DEPTH = 0x80B3;
        public const int POST_COLOR_MATRIX_RED_SCALE = 0x80B4;
        public const int POST_COLOR_MATRIX_GREEN_SCALE = 0x80B5;
        public const int POST_COLOR_MATRIX_BLUE_SCALE = 0x80B6;
        public const int POST_COLOR_MATRIX_ALPHA_SCALE = 0x80B7;
        public const int POST_COLOR_MATRIX_RED_BIAS = 0x80B8;
        public const int POST_COLOR_MATRIX_GREEN_BIAS = 0x80B9;
        public const int POST_COLOR_MATRIX_BLUE_BIAS = 0x80BA;
        public const int POST_COLOR_MATRIX_ALPHA_BIAS = 0x80BB;
        public const int COLOR_TABLE = 0x80D0;
        public const int POST_CONVOLUTION_COLOR_TABLE = 0x80D1;
        public const int POST_COLOR_MATRIX_COLOR_TABLE = 0x80D2;
        public const int PROXY_COLOR_TABLE = 0x80D3;
        public const int PROXY_POST_CONVOLUTION_COLOR_TABLE = 0x80D4;
        public const int PROXY_POST_COLOR_MATRIX_COLOR_TABLE = 0x80D5;
        public const int COLOR_TABLE_SCALE = 0x80D6;
        public const int COLOR_TABLE_BIAS = 0x80D7;
        public const int COLOR_TABLE_FORMAT = 0x80D8;
        public const int COLOR_TABLE_WIDTH = 0x80D9;
        public const int COLOR_TABLE_RED_SIZE = 0x80DA;
        public const int COLOR_TABLE_GREEN_SIZE = 0x80DB;
        public const int COLOR_TABLE_BLUE_SIZE = 0x80DC;
        public const int COLOR_TABLE_ALPHA_SIZE = 0x80DD;
        public const int COLOR_TABLE_LUMINANCE_SIZE = 0x80DE;
        public const int COLOR_TABLE_INTENSITY_SIZE = 0x80DF;
        public const int CONSTANT_BORDER = 0x8151;
        public const int REPLICATE_BORDER = 0x8153;
        public const int CONVOLUTION_BORDER_COLOR = 0x8154;
        public const int TEXTURE0 = 0x84C0;
        public const int TEXTURE1 = 0x84C1;
        public const int TEXTURE2 = 0x84C2;
        public const int TEXTURE3 = 0x84C3;
        public const int TEXTURE4 = 0x84C4;
        public const int TEXTURE5 = 0x84C5;
        public const int TEXTURE6 = 0x84C6;
        public const int TEXTURE7 = 0x84C7;
        public const int TEXTURE8 = 0x84C8;
        public const int TEXTURE9 = 0x84C9;
        public const int TEXTURE10 = 0x84CA;
        public const int TEXTURE11 = 0x84CB;
        public const int TEXTURE12 = 0x84CC;
        public const int TEXTURE13 = 0x84CD;
        public const int TEXTURE14 = 0x84CE;
        public const int TEXTURE15 = 0x84CF;
        public const int TEXTURE16 = 0x84D0;
        public const int TEXTURE17 = 0x84D1;
        public const int TEXTURE18 = 0x84D2;
        public const int TEXTURE19 = 0x84D3;
        public const int TEXTURE20 = 0x84D4;
        public const int TEXTURE21 = 0x84D5;
        public const int TEXTURE22 = 0x84D6;
        public const int TEXTURE23 = 0x84D7;
        public const int TEXTURE24 = 0x84D8;
        public const int TEXTURE25 = 0x84D9;
        public const int TEXTURE26 = 0x84DA;
        public const int TEXTURE27 = 0x84DB;
        public const int TEXTURE28 = 0x84DC;
        public const int TEXTURE29 = 0x84DD;
        public const int TEXTURE30 = 0x84DE;
        public const int TEXTURE31 = 0x84DF;
        public const int ACTIVE_TEXTURE = 0x84E0;
        public const int MULTISAMPLE = 0x809D;
        public const int SAMPLE_ALPHA_TO_COVERAGE = 0x809E;
        public const int SAMPLE_ALPHA_TO_ONE = 0x809F;
        public const int SAMPLE_COVERAGE = 0x80A0;
        public const int SAMPLE_BUFFERS = 0x80A8;
        public const int SAMPLES = 0x80A9;
        public const int SAMPLE_COVERAGE_VALUE = 0x80AA;
        public const int SAMPLE_COVERAGE_INVERT = 0x80AB;
        public const int TEXTURE_CUBE_MAP = 0x8513;
        public const int TEXTURE_BINDING_CUBE_MAP = 0x8514;
        public const int TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;
        public const int TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;
        public const int TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;
        public const int TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;
        public const int TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;
        public const int TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;
        public const int PROXY_TEXTURE_CUBE_MAP = 0x851B;
        public const int MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;
        public const int COMPRESSED_RGB = 0x84ED;
        public const int COMPRESSED_RGBA = 0x84EE;
        public const int TEXTURE_COMPRESSION_Hint = 0x84EF;
        public const int TEXTURE_COMPRESSED_IMAGE_SIZE = 0x86A0;
        public const int TEXTURE_COMPRESSED = 0x86A1;
        public const int NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2;
        public const int COMPRESSED_TEXTURE_FORMATS = 0x86A3;
        public const int CLAMP_TO_BORDER = 0x812D;
        public const int CLIENT_ACTIVE_TEXTURE = 0x84E1;
        public const int MAX_TEXTURE_UNITS = 0x84E2;
        public const int TRANSPOSE_MODELVIEW_MATRIX = 0x84E3;
        public const int TRANSPOSE_PROJECTION_MATRIX = 0x84E4;
        public const int TRANSPOSE_TEXTURE_MATRIX = 0x84E5;
        public const int TRANSPOSE_COLOR_MATRIX = 0x84E6;
        public const int MULTISAMPLE_BIT = 0x20000000;
        public const int NORMAL_MAP = 0x8511;
        public const int REFLECTION_MAP = 0x8512;
        public const int COMPRESSED_ALPHA = 0x84E9;
        public const int COMPRESSED_LUMINANCE = 0x84EA;
        public const int COMPRESSED_LUMINANCE_ALPHA = 0x84EB;
        public const int COMPRESSED_INTENSITY = 0x84EC;
        public const int COMBINE = 0x8570;
        public const int COMBINE_RGB = 0x8571;
        public const int COMBINE_ALPHA = 0x8572;
        public const int SOURCE0_RGB = 0x8580;
        public const int SOURCE1_RGB = 0x8581;
        public const int SOURCE2_RGB = 0x8582;
        public const int SOURCE0_ALPHA = 0x8588;
        public const int SOURCE1_ALPHA = 0x8589;
        public const int SOURCE2_ALPHA = 0x858A;
        public const int OPERAND0_RGB = 0x8590;
        public const int OPERAND1_RGB = 0x8591;
        public const int OPERAND2_RGB = 0x8592;
        public const int OPERAND0_ALPHA = 0x8598;
        public const int OPERAND1_ALPHA = 0x8599;
        public const int OPERAND2_ALPHA = 0x859A;
        public const int RGB_SCALE = 0x8573;
        public const int ADD_SIGNED = 0x8574;
        public const int INTERPOLATE = 0x8575;
        public const int SUBTRACT = 0x84E7;
        public const int CONSTANT = 0x8576;
        public const int PRIMARY_COLOR = 0x8577;
        public const int PREVIOUS = 0x8578;
        public const int DOT3_RGB = 0x86AE;
        public const int DOT3_RGBA = 0x86AF;
        public const int BLEND_DST_RGB = 0x80C8;
        public const int BLEND_SRC_RGB = 0x80C9;
        public const int BLEND_DST_ALPHA = 0x80CA;
        public const int BLEND_SRC_ALPHA = 0x80CB;
        public const int POINT_FADE_THRESHOLD_SIZE = 0x8128;
        public const int DEPTH_COMPONENT16 = 0x81A5;
        public const int DEPTH_COMPONENT24 = 0x81A6;
        public const int DEPTH_COMPONENT32 = 0x81A7;
        public const int MIRRORED_REPEAT = 0x8370;
        public const int MAX_TEXTURE_LOD_BIAS = 0x84FD;
        public const int TEXTURE_LOD_BIAS = 0x8501;
        public const int INCR_WRAP = 0x8507;
        public const int DECR_WRAP = 0x8508;
        public const int TEXTURE_DEPTH_SIZE = 0x884A;
        public const int TEXTURE_COMPARE_MODE = 0x884C;
        public const int TEXTURE_COMPARE_FUNC = 0x884D;
        public const int POINT_SIZE_MIN = 0x8126;
        public const int POINT_SIZE_MAX = 0x8127;
        public const int POINT_DISTANCE_ATTENUATION = 0x8129;
        public const int GENERATE_MIPMAP = 0x8191;
        public const int GENERATE_MIPMAP_Hint = 0x8192;
        public const int FOG_COORDINATE_SOURCE = 0x8450;
        public const int FOG_COORDINATE = 0x8451;
        public const int FRAGMENT_DEPTH = 0x8452;
        public const int CURRENT_FOG_COORDINATE = 0x8453;
        public const int FOG_COORDINATE_ARRAY_TYPE = 0x8454;
        public const int FOG_COORDINATE_ARRAY_STRIDE = 0x8455;
        public const int FOG_COORDINATE_ARRAY_POINTER = 0x8456;
        public const int FOG_COORDINATE_ARRAY = 0x8457;
        public const int COLOR_SUM = 0x8458;
        public const int CURRENT_SECONDARY_COLOR = 0x8459;
        public const int SECONDARY_COLOR_ARRAY_SIZE = 0x845A;
        public const int SECONDARY_COLOR_ARRAY_TYPE = 0x845B;
        public const int SECONDARY_COLOR_ARRAY_STRIDE = 0x845C;
        public const int SECONDARY_COLOR_ARRAY_POINTER = 0x845D;
        public const int SECONDARY_COLOR_ARRAY = 0x845E;
        public const int TEXTURE_FILTER_CONTROL = 0x8500;
        public const int DEPTH_TEXTURE_MODE = 0x884B;
        public const int COMPARE_R_TO_TEXTURE = 0x884E;
        public const int BUFFER_SIZE = 0x8764;
        public const int BUFFER_USAGE = 0x8765;
        public const int QUERY_COUNTER_BITS = 0x8864;
        public const int CURRENT_QUERY = 0x8865;
        public const int QUERY_RESULT = 0x8866;
        public const int QUERY_RESULT_AVAILABLE = 0x8867;
        public const int ARRAY_BUFFER = 0x8892;
        public const int ELEMENT_ARRAY_BUFFER = 0x8893;
        public const int ARRAY_BUFFER_BINDING = 0x8894;
        public const int ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;
        public const int VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;
        public const int READ_ONLY = 0x88B8;
        public const int WRITE_ONLY = 0x88B9;
        public const int READ_WRITE = 0x88BA;
        public const int BUFFER_ACCESS = 0x88BB;
        public const int BUFFER_MAPPED = 0x88BC;
        public const int BUFFER_MAP_POINTER = 0x88BD;
        public const int STREAM_DRAW = 0x88E0;
        public const int STREAM_READ = 0x88E1;
        public const int STREAM_COPY = 0x88E2;
        public const int STATIC_DRAW = 0x88E4;
        public const int STATIC_READ = 0x88E5;
        public const int STATIC_COPY = 0x88E6;
        public const int DYNAMIC_DRAW = 0x88E8;
        public const int DYNAMIC_READ = 0x88E9;
        public const int DYNAMIC_COPY = 0x88EA;
        public const int SAMPLES_PASSED = 0x8914;
        public const int SRC1_ALPHA = 0x8589;
        public const int VERTEX_ARRAY_BUFFER_BINDING = 0x8896;
        public const int NORMAL_ARRAY_BUFFER_BINDING = 0x8897;
        public const int COLOR_ARRAY_BUFFER_BINDING = 0x8898;
        public const int INDEX_ARRAY_BUFFER_BINDING = 0x8899;
        public const int TEXTURE_COORD_ARRAY_BUFFER_BINDING = 0x889A;
        public const int EDGE_FLAG_ARRAY_BUFFER_BINDING = 0x889B;
        public const int SECONDARY_COLOR_ARRAY_BUFFER_BINDING = 0x889C;
        public const int FOG_COORDINATE_ARRAY_BUFFER_BINDING = 0x889D;
        public const int WEIGHT_ARRAY_BUFFER_BINDING = 0x889E;
        public const int FOG_COORD_SRC = 0x8450;
        public const int FOG_COORD = 0x8451;
        public const int CURRENT_FOG_COORD = 0x8453;
        public const int FOG_COORD_ARRAY_TYPE = 0x8454;
        public const int FOG_COORD_ARRAY_STRIDE = 0x8455;
        public const int FOG_COORD_ARRAY_POINTER = 0x8456;
        public const int FOG_COORD_ARRAY = 0x8457;
        public const int FOG_COORD_ARRAY_BUFFER_BINDING = 0x889D;
        public const int SRC0_RGB = 0x8580;
        public const int SRC1_RGB = 0x8581;
        public const int SRC2_RGB = 0x8582;
        public const int SRC0_ALPHA = 0x8588;
        public const int SRC2_ALPHA = 0x858A;
        public const int BLEND_EQUATION_RGB = 0x8009;
        public const int VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;
        public const int VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;
        public const int VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;
        public const int VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;
        public const int CURRENT_VERTEX_ATTRIB = 0x8626;
        public const int VERTEX_PROGRAM_POINT_SIZE = 0x8642;
        public const int VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;
        public const int STENCIL_BACK_FUNC = 0x8800;
        public const int STENCIL_BACK_FAIL = 0x8801;
        public const int STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;
        public const int STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;
        public const int MAX_DRAW_BUFFERS = 0x8824;
        public const int DRAW_BUFFER0 = 0x8825;
        public const int DRAW_BUFFER1 = 0x8826;
        public const int DRAW_BUFFER2 = 0x8827;
        public const int DRAW_BUFFER3 = 0x8828;
        public const int DRAW_BUFFER4 = 0x8829;
        public const int DRAW_BUFFER5 = 0x882A;
        public const int DRAW_BUFFER6 = 0x882B;
        public const int DRAW_BUFFER7 = 0x882C;
        public const int DRAW_BUFFER8 = 0x882D;
        public const int DRAW_BUFFER9 = 0x882E;
        public const int DRAW_BUFFER10 = 0x882F;
        public const int DRAW_BUFFER11 = 0x8830;
        public const int DRAW_BUFFER12 = 0x8831;
        public const int DRAW_BUFFER13 = 0x8832;
        public const int DRAW_BUFFER14 = 0x8833;
        public const int DRAW_BUFFER15 = 0x8834;
        public const int BLEND_EQUATION_ALPHA = 0x883D;
        public const int MAX_VERTEX_ATTRIBS = 0x8869;
        public const int VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;
        public const int MAX_TEXTURE_IMAGE_UNITS = 0x8872;
        public const int FRAGMENT_SHADER = 0x8B30;
        public const int VERTEX_SHADER = 0x8B31;
        public const int GEOMETRY_SHADER = 0x8DD9;
        public const int MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49;
        public const int MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A;
        public const int MAX_VARYING_FLOATS = 0x8B4B;
        public const int MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;
        public const int MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
        public const int SHADER_TYPE = 0x8B4F;
        public const int FLOAT_VEC2 = 0x8B50;
        public const int FLOAT_VEC3 = 0x8B51;
        public const int FLOAT_VEC4 = 0x8B52;
        public const int INT_VEC2 = 0x8B53;
        public const int INT_VEC3 = 0x8B54;
        public const int INT_VEC4 = 0x8B55;
        public const int BOOL = 0x8B56;
        public const int BOOL_VEC2 = 0x8B57;
        public const int BOOL_VEC3 = 0x8B58;
        public const int BOOL_VEC4 = 0x8B59;
        public const int FLOAT_MAT2 = 0x8B5A;
        public const int FLOAT_MAT3 = 0x8B5B;
        public const int FLOAT_MAT4 = 0x8B5C;
        public const int SAMPLER_1D = 0x8B5D;
        public const int SAMPLER_2D = 0x8B5E;
        public const int SAMPLER_3D = 0x8B5F;
        public const int SAMPLER_CUBE = 0x8B60;
        public const int SAMPLER_1D_SHADOW = 0x8B61;
        public const int SAMPLER_2D_SHADOW = 0x8B62;
        public const int DELETE_STATUS = 0x8B80;
        public const int COMPILE_STATUS = 0x8B81;
        public const int LINK_STATUS = 0x8B82;
        public const int VALIDATE_STATUS = 0x8B83;
        public const int INFO_LOG_LENGTH = 0x8B84;
        public const int ATTACHED_SHADERS = 0x8B85;
        public const int ACTIVE_UNIFORMS = 0x8B86;
        public const int ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87;
        public const int SHADER_SOURCE_LENGTH = 0x8B88;
        public const int ACTIVE_ATTRIBUTES = 0x8B89;
        public const int ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A;
        public const int FRAGMENT_SHADER_DERIVATIVE_Hint = 0x8B8B;
        public const int SHADING_LANGUAGE_VERSION = 0x8B8C;
        public const int CURRENT_PROGRAM = 0x8B8D;
        public const int POINT_SPRITE_COORD_ORIGIN = 0x8CA0;
        public const int LOWER_LEFT = 0x8CA1;
        public const int UPPER_LEFT = 0x8CA2;
        public const int STENCIL_BACK_REF = 0x8CA3;
        public const int STENCIL_BACK_VALUE_MASK = 0x8CA4;
        public const int STENCIL_BACK_WRITEMASK = 0x8CA5;
        public const int VERTEX_PROGRAM_TWO_SIDE = 0x8643;
        public const int POINT_SPRITE = 0x8861;
        public const int COORD_REPLACE = 0x8862;
        public const int MAX_TEXTURE_COORDS = 0x8871;
        public const int PIXEL_PACK_BUFFER = 0x88EB;
        public const int PIXEL_UNPACK_BUFFER = 0x88EC;
        public const int PIXEL_PACK_BUFFER_BINDING = 0x88ED;
        public const int PIXEL_UNPACK_BUFFER_BINDING = 0x88EF;
        public const int FLOAT_MAT2x3 = 0x8B65;
        public const int FLOAT_MAT2x4 = 0x8B66;
        public const int FLOAT_MAT3x2 = 0x8B67;
        public const int FLOAT_MAT3x4 = 0x8B68;
        public const int FLOAT_MAT4x2 = 0x8B69;
        public const int FLOAT_MAT4x3 = 0x8B6A;
        public const int SRGB = 0x8C40;
        public const int SRGB8 = 0x8C41;
        public const int SRGB_ALPHA = 0x8C42;
        public const int SRGB8_ALPHA8 = 0x8C43;
        public const int COMPRESSED_SRGB = 0x8C48;
        public const int COMPRESSED_SRGB_ALPHA = 0x8C49;
        public const int CURRENT_RASTER_SECONDARY_COLOR = 0x845F;
        public const int SLUMINANCE_ALPHA = 0x8C44;
        public const int SLUMINANCE8_ALPHA8 = 0x8C45;
        public const int SLUMINANCE = 0x8C46;
        public const int SLUMINANCE8 = 0x8C47;
        public const int COMPRESSED_SLUMINANCE = 0x8C4A;
        public const int COMPRESSED_SLUMINANCE_ALPHA = 0x8C4B;
    }
}
