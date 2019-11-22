using System;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;

using GLsizei = System.Int32; //TODO ADD UINT!!!!!
using GLenum = System.Int32;
using GLboolean = System.Boolean;
using GLchar = System.Char;
using GLbyte = System.Byte;
using GLubyte = System.Byte;
using GLshort = System.Int16;
using GLushort = System.Int16;
using GLint = System.Int32;
using GLuint = System.Int32;
using GLfloat = System.Single;
using GLclampf = System.Single;
using GLdouble = System.Double;
using GLclampd = System.Double;
using GLintptr = System.Int32;
using GLsizeiptr = System.Int32;
using GLbitfield = System.Int32;

namespace OJE.GL
{
    internal static unsafe class Imports
    {
        private const string DllName = "opengl32.dll";
        private static IntPtr DllHandle;

        [DllImport("kernel32.dll")]
        internal static extern IntPtr LoadLibrary(string name);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetProcAddress(IntPtr handle, string name);

        static Imports()
        {
            DllHandle = LoadLibrary(DllName);
            if (DllHandle == IntPtr.Zero)
                throw new Exception("Failed to load opengl library");
            IntPtr address = GetProcAddress(DllHandle, "wglGetProcAddress");

            if (address == IntPtr.Zero)
                throw new Exception("Failed to call wglGetProcAddress function");
            wglGetProcAddress = (wglGetProcAddressDelegate)Marshal.GetDelegateForFunctionPointer(address, typeof(wglGetProcAddressDelegate));
            ReloadFunctions();
        }

        public static void ReloadFunctions()
        {
            foreach (FieldInfo field in typeof(Imports).GetFields(BindingFlags.NonPublic | BindingFlags.Static).Where(field => field.FieldType.BaseType == typeof(MulticastDelegate) && field.IsAssembly))
            {
                string name = field.Name;
                IntPtr address;
                if ((address = GetProcAddress(DllHandle, name)) == IntPtr.Zero && (address = wglGetProcAddress(name)) == IntPtr.Zero)
                    Console.WriteLine("Failed to load opengl function: " + name);
                else
                    field.SetValue(null, Marshal.GetDelegateForFunctionPointer(address, field.FieldType));
            }
        }

        [SuppressUnmanagedCodeSecurity]
        internal delegate IntPtr wglGetProcAddressDelegate(string procedure);
        internal static wglGetProcAddressDelegate wglGetProcAddress;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glAccumDelegate(GLenum oper, GLfloat val);
        internal static glAccumDelegate glAccum;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glActiveTextureDelegate(GLenum texture);
        internal static glActiveTextureDelegate glActiveTexture;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glAlphaFuncDelegate(GLenum func, GLclampf reference);
        internal static glAlphaFuncDelegate glAlphaFunc;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLboolean glAreTexturesResidentDelegate(GLsizei n, GLuint[] textures, out GLboolean[] residences);
        internal static glAreTexturesResidentDelegate glAreTexturesResident;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glArrayElementDelegate(GLint index);
        internal static glArrayElementDelegate glArrayElement;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glAttachShaderDelegate(GLuint program, GLuint shader);
        internal static glAttachShaderDelegate glAttachShader;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBeginDelegate(GLenum mode);
        internal static glBeginDelegate glBegin;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBeginQueryDelegate(GLenum target, GLuint id);
        internal static glBeginQueryDelegate glBeginQuery;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBindAttribLocationDelegate(GLuint program, GLuint index, string name);
        internal static glBindAttribLocationDelegate glBindAttribLocation;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBindBufferDelegate(GLenum target, GLuint buffer);
        internal static glBindBufferDelegate glBindBuffer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBindTextureDelegate(GLenum target, GLuint texture);
        internal static glBindTextureDelegate glBindTexture;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBindVertexArrayDelegate(GLuint array);
        internal static glBindVertexArrayDelegate glBindVertexArray;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBitmapDelegate(GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, GLubyte[] bitmap);
        internal static glBitmapDelegate glBitmap;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBlendColorDelegate(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
        internal static glBlendColorDelegate glBlendColor;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBlendEquationDelegate(GLenum mode);
        internal static glBlendEquationDelegate glBlendEquation;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBlendEquationSeparateDelegate(GLenum modeRGB, GLenum modeAlpha);
        internal static glBlendEquationSeparateDelegate glBlendEquationSeparate;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBlendFuncDelegate(GLenum sfactor, GLenum dfactor);
        internal static glBlendFuncDelegate glBlendFunc;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBlendFuncSeparateDelegate(GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha);
        internal static glBlendFuncSeparateDelegate glBlendFuncSeparate;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBufferDataDelegate(GLenum target, GLsizeiptr size, void* data, GLenum usage);
        internal static glBufferDataDelegate glBufferData;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glBufferSubDataDelegate(GLenum target, GLintptr offset, GLsizeiptr size, void* data);
        internal static glBufferSubDataDelegate glBufferSubData;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCallListDelegate(GLuint list);// TODO
        internal static glCallListDelegate glCallList;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCallListsDelegate(GLsizei n, GLenum type, void* lists);
        internal static glCallListsDelegate glCallLists;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glClearDelegate(GLbitfield mask);
        internal static glClearDelegate glClear;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glClearAccumDelegate(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
        internal static glClearAccumDelegate glClearAccum;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glClearColorDelegate(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
        internal static glClearColorDelegate glClearColor;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glClearDepthDelegate(GLclampd depth);
        internal static glClearDepthDelegate glClearDepth;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glClearIndexDelegate(GLfloat c);
        internal static glClearIndexDelegate glClearIndex;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glClearStencilDelegate(GLint s);
        internal static glClearStencilDelegate glClearStencil;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glClientActiveTextureDelegate(GLenum texture);// TODO
        internal static glClientActiveTextureDelegate glClientActiveTexture;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glClipPlaneDelegate(GLenum plane, GLdouble[] equation);
        internal static glClipPlaneDelegate glClipPlane;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor3bDelegate(sbyte red, sbyte green, sbyte blue);
        internal static glColor3bDelegate glColor3b;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor3sDelegate(GLshort red, GLshort green, GLshort blue);
        internal static glColor3sDelegate glColor3s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor3iDelegate(GLint red, GLint green, GLint blue);
        internal static glColor3iDelegate glColor3i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor3fDelegate(GLfloat red, GLfloat green, GLfloat blue);
        internal static glColor3fDelegate glColor3f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor3dDelegate(GLdouble red, GLdouble green, GLdouble blue);
        internal static glColor3dDelegate glColor3d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor3ubDelegate(GLubyte red, GLubyte green, GLubyte blue);
        internal static glColor3ubDelegate glColor3ub;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor3usDelegate(GLushort red, GLushort green, GLushort blue);
        internal static glColor3usDelegate glColor3us;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor3uiDelegate(GLuint red, GLuint green, GLuint blue);
        internal static glColor3uiDelegate glColor3ui;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor4bDelegate(GLbyte red, GLbyte green, GLbyte blue, GLbyte alpha);
        internal static glColor4bDelegate glColor4b;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor4sDelegate(GLshort red, GLshort green, GLshort blue, GLshort alpha);
        internal static glColor4sDelegate glColor4s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor4iDelegate(GLint red, GLint green, GLint blue, GLint alpha);
        internal static glColor4iDelegate glColor4i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor4fDelegate(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
        internal static glColor4fDelegate glColor4f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor4dDelegate(GLdouble red, GLdouble green, GLdouble blue, GLdouble alpha);
        internal static glColor4dDelegate glColor4d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor4ubDelegate(GLubyte red, GLubyte green, GLubyte blue, GLubyte alpha);
        internal static glColor4ubDelegate glColor4ub;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor4usDelegate(GLushort red, GLushort green, GLushort blue, GLushort alpha);
        internal static glColor4usDelegate glColor4us;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColor4uiDelegate(GLuint red, GLuint green, GLuint blue, GLuint alpha);
        internal static glColor4uiDelegate glColor4ui;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColorMaskDelegate(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);
        internal static glColorMaskDelegate glColorMask;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColorMaterialDelegate(GLenum face, GLenum mode);
        internal static glColorMaterialDelegate glColorMaterial;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColorPointerDelegate(GLint size, GLenum type, GLsizei stride, void* pointer);
        internal static glColorPointerDelegate glColorPointer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColorSubTableDelegate(GLenum target, GLsizei start, GLsizei count, GLenum format, GLenum type, void* data);
        internal static glColorSubTableDelegate glColorSubTable;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColorTableDelegate(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, void* data);
        internal static glColorTableDelegate glColorTable;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColorTableParameterfvDelegate(GLenum target, GLenum pname, GLfloat[] param);
        internal static glColorTableParameterfvDelegate glColorTableParameterfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glColorTableParameterivDelegate(GLenum target, GLenum pname, GLint[] param);
        internal static glColorTableParameterivDelegate glColorTableParameteriv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCompileShaderDelegate(GLuint shader);
        internal static glCompileShaderDelegate glCompileShader;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCompressedTexImage1DDelegate(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, void* data);
        internal static glCompressedTexImage1DDelegate glCompressedTexImage1D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCompressedTexImage2DDelegate(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, void* data);
        internal static glCompressedTexImage2DDelegate glCompressedTexImage2D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCompressedTexImage3DDelegate(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, void* data);
        internal static glCompressedTexImage3DDelegate glCompressedTexImage3D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCompressedTexSubImage1DDelegate(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, void* data);
        internal static glCompressedTexSubImage1DDelegate glCompressedTexSubImage1D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCompressedTexSubImage2DDelegate(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, void* data);
        internal static glCompressedTexSubImage2DDelegate glCompressedTexSubImage2D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCompressedTexSubImage3DDelegate(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, void* data);// TODO
        internal static glCompressedTexSubImage3DDelegate glCompressedTexSubImage3D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glConvolutionFilter1DDelegate(GLenum target, GLenum internalformat, GLsizei width, GLenum format, GLenum type, void* data);
        internal static glConvolutionFilter1DDelegate glConvolutionFilter1D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glConvolutionFilter2DDelegate(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, void* data);
        internal static glConvolutionFilter2DDelegate glConvolutionFilter2D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glConvolutionParameterfDelegate(GLenum target, GLenum pname, GLfloat param);
        internal static glConvolutionParameterfDelegate glConvolutionParameterf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glConvolutionParameteriDelegate(GLenum target, GLenum pname, GLint param);
        internal static glConvolutionParameteriDelegate glConvolutionParameteri;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCopyColorSubTableDelegate(GLenum target, GLsizei start, GLint x, GLint y, GLsizei width);
        internal static glCopyColorSubTableDelegate glCopyColorSubTable;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCopyColorTableDelegate(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);
        internal static glCopyColorTableDelegate glCopyColorTable;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCopyConvolutionFilter1DDelegate(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width);
        internal static glCopyConvolutionFilter1DDelegate glCopyConvolutionFilter1D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCopyConvolutionFilter2DDelegate(GLenum target, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height);
        internal static glCopyConvolutionFilter2DDelegate glCopyConvolutionFilter2D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCopyPixelsDelegate(GLint x, GLint y, GLsizei width, GLsizei height, GLenum type);
        internal static glCopyPixelsDelegate glCopyPixels;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCopyTexImage1DDelegate(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);
        internal static glCopyTexImage1DDelegate glCopyTexImage1D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCopyTexImage2DDelegate(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);
        internal static glCopyTexImage2DDelegate glCopyTexImage2D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCopyTexSubImage1DDelegate(GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);
        internal static glCopyTexSubImage1DDelegate glCopyTexSubImage1D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCopyTexSubImage2DDelegate(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);
        internal static glCopyTexSubImage2DDelegate glCopyTexSubImage2D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCopyTexSubImage3DDelegate(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);
        internal static glCopyTexSubImage3DDelegate glCopyTexSubImage3D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate int glCreateProgramDelegate();
        internal static glCreateProgramDelegate glCreateProgram;

        [SuppressUnmanagedCodeSecurity]
        internal delegate int glCreateShaderDelegate(GLenum shaderType);
        internal static glCreateShaderDelegate glCreateShader;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glCullFaceDelegate(GLenum mode);// TODO
        internal static glCullFaceDelegate glCullFace;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDeleteBuffersDelegate(GLsizei n, GLuint[] buffers);
        internal static glDeleteBuffersDelegate glDeleteBuffers;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDeleteListsDelegate(GLuint list, GLsizei range);
        internal static glDeleteListsDelegate glDeleteLists;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDeleteProgramDelegate(GLuint program);// TODO
        internal static glDeleteProgramDelegate glDeleteProgram;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDeleteQueriesDelegate(GLsizei n, GLuint[] ids);
        internal static glDeleteQueriesDelegate glDeleteQueries;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDeleteShaderDelegate(GLuint shader);// TODO
        internal static glDeleteShaderDelegate glDeleteShader;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDeleteTexturesDelegate(GLsizei n, GLuint[] textures);
        internal static glDeleteTexturesDelegate glDeleteTextures;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDepthFuncDelegate(GLenum func);
        internal static glDepthFuncDelegate glDepthFunc;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDepthMaskDelegate(GLboolean flag);
        internal static glDepthMaskDelegate glDepthMask;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDepthRangeDelegate(GLclampd nearVal, GLclampd farVal);
        internal static glDepthRangeDelegate glDepthRange;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDetachShaderDelegate(GLuint program, GLuint shader);
        internal static glDetachShaderDelegate glDetachShader;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDisableDelegate(GLenum cap);
        internal static glDisableDelegate glDisable;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDisableClientStateDelegate(GLenum cap);
        internal static glDisableClientStateDelegate glDisableClientState;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEnableVertexAttribArrayDelegate(GLuint index);
        internal static glEnableVertexAttribArrayDelegate glEnableVertexAttribArray;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDisableVertexAttribArrayDelegate(GLuint index);
        internal static glDisableVertexAttribArrayDelegate glDisableVertexAttribArray;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDrawArraysDelegate(GLenum mode, GLint first, GLsizei count);
        internal static glDrawArraysDelegate glDrawArrays;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDrawBufferDelegate(GLenum mode);
        internal static glDrawBufferDelegate glDrawBuffer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDrawBuffersDelegate(GLsizei n, GLenum[] bufs);
        internal static glDrawBuffersDelegate glDrawBuffers;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDrawElementsDelegate(GLenum mode, GLsizei count, GLenum type, void* indices);
        internal static glDrawElementsDelegate glDrawElements;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDrawPixelsDelegate(GLsizei width, GLsizei height, GLenum format, GLenum type, void* data);
        internal static glDrawPixelsDelegate glDrawPixels;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glDrawRangeElementsDelegate(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, void* indices);
        internal static glDrawRangeElementsDelegate glDrawRangeElements;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEdgeFlagDelegate(GLboolean flag);
        internal static glEdgeFlagDelegate glEdgeFlag;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEdgeFlagvDelegate(GLboolean[] flag);
        internal static glEdgeFlagvDelegate glEdgeFlagv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEdgeFlagPointerDelegate(GLsizei stride, void* pointer);
        internal static glEdgeFlagPointerDelegate glEdgeFlagPointer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEnableDelegate(GLenum cap);
        internal static glEnableDelegate glEnable;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEnableClientStateDelegate(GLenum cap);
        internal static glEnableClientStateDelegate glEnableClientState;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEndDelegate();
        internal static glEndDelegate glEnd;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEndListDelegate(GLuint list, GLenum mode);
        internal static glEndListDelegate glEndList;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEndQueryDelegate(GLenum target);
        internal static glEndQueryDelegate glEndQuery;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEvalCoord1fDelegate(GLfloat u);
        internal static glEvalCoord1fDelegate glEvalCoord1f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEvalCoord1dDelegate(GLdouble u);
        internal static glEvalCoord1dDelegate glEvalCoord1d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEvalCoord2fDelegate(GLfloat u, GLfloat v);
        internal static glEvalCoord2fDelegate glEvalCoord2f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEvalCoord2dDelegate(GLdouble u, GLdouble v);
        internal static glEvalCoord2dDelegate glEvalCoord2d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEvalMesh1Delegate(GLenum mode, GLint i1, GLint i2);
        internal static glEvalMesh1Delegate glEvalMesh1;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEvalMesh2Delegate(GLenum mode, GLint i1, GLint i2, GLint j1, GLint j2);
        internal static glEvalMesh2Delegate glEvalMesh2;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEvalPoint1Delegate(GLint i);
        internal static glEvalPoint1Delegate glEvalPoint1;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glEvalPoint2Delegate(GLint i, GLint j);
        internal static glEvalPoint2Delegate glEvalPoint2;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glFeedbackBufferDelegate(GLsizei size, GLenum type, out GLfloat[] buffer);
        internal static glFeedbackBufferDelegate glFeedbackBuffer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glFinishDelegate();
        internal static glFinishDelegate glFinish;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glFlushDelegate();
        internal static glFlushDelegate glFlush;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glFogfDelegate(GLenum pname, GLfloat param);
        internal static glFogfDelegate glFogf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glFogiDelegate(GLenum pname, GLint param);
        internal static glFogiDelegate glFogi;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glFogCoorddDelegate(GLdouble coord);
        internal static glFogCoorddDelegate glFogCoordd;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glFogCoordfDelegate(GLfloat coord);
        internal static glFogCoordfDelegate glFogCoordf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glFogCoordPointerDelegate(GLenum type, GLsizei stride, void* pointer);
        internal static glFogCoordPointerDelegate glFogCoordPointer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glFrontFaceDelegate(GLenum mode);
        internal static glFrontFaceDelegate glFrontFace;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glFrustumDelegate(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble nearVal, GLdouble farVal);
        internal static glFrustumDelegate glFrustum;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGenerateMipmapDelegate(GLenum target);
        internal static glGenerateMipmapDelegate glGenerateMipmap;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGenerateTextureMipmapDelegate(GLuint texture);
        internal static glGenerateTextureMipmapDelegate glGenerateTextureMipmap;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGenBuffersDelegate(GLsizei n, GLuint* buffers);
        internal static glGenBuffersDelegate glGenBuffers;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGenListsDelegate(GLsizei range);
        internal static glGenListsDelegate glGenLists;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGenQueriesDelegate(GLsizei n, GLuint* ids);
        internal static glGenQueriesDelegate glGenQueries;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGenTexturesDelegate(GLsizei n, GLuint* textures);
        internal static glGenTexturesDelegate glGenTextures;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGenVertexArraysDelegate(GLsizei n, GLuint* arrays);
        internal static glGenVertexArraysDelegate glGenVertexArrays;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetBooleanvDelegate(GLenum pname, out GLboolean[] param);
        internal static glGetBooleanvDelegate glGetBooleanv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetDoublevDelegate(GLenum pname, out GLdouble[] param);
        internal static glGetDoublevDelegate glGetDoublev;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetFloatvDelegate(GLenum pname, out GLfloat[] param);
        internal static glGetFloatvDelegate glGetFloatv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetIntegervDelegate(GLenum pname, out GLint[] param);
        internal static glGetIntegervDelegate glGetIntegerv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetActiveAttribDelegate(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, out GLint size, out GLenum type, out string name); //NOTE: not sure about pointers
        internal static glGetActiveAttribDelegate glGetActiveAttrib;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetActiveUniformDelegate(GLuint program, GLuint index, GLsizei bufSize, out GLsizei length, out GLint size, out GLenum type, out string name);
        internal static glGetActiveUniformDelegate glGetActiveUniform;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetAttachedShadersDelegate(GLuint program, GLsizei maxCount, out GLsizei count, out GLuint[] shaders);
        internal static glGetAttachedShadersDelegate glGetAttachedShaders;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLint glGetAttribLocationDelegate(GLuint program, string name);
        internal static glGetAttribLocationDelegate glGetAttribLocation;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetBufferParameterivDelegate(GLenum target, GLenum value, out GLint[] data);
        internal static glGetBufferParameterivDelegate glGetBufferParameteriv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetBufferPointervDelegate(GLenum target, GLenum pname, out byte[] parameters);
        internal static glGetBufferPointervDelegate glGetBufferPointerv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetBufferSubDataDelegate(GLenum target, GLintptr offset, GLsizeiptr size, out byte[] data);
        internal static glGetBufferSubDataDelegate glGetBufferSubData;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetClipPlaneDelegate(GLenum plane, out GLdouble[] equation);
        internal static glGetClipPlaneDelegate glGetClipPlane;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetColorTableDelegate(GLenum target, GLenum format, GLenum type, out void* table);
        internal static glGetColorTableDelegate glGetColorTable;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetColorTableParameterfvDelegate(GLenum target, GLenum pname, out GLfloat[] param);
        internal static glGetColorTableParameterfvDelegate glGetColorTableParameterfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetColorTableParameterivDelegate(GLenum target, GLenum pname, out GLint[] param);
        internal static glGetColorTableParameterivDelegate glGetColorTableParameteriv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetCompressedTexImageDelegate(GLenum target, GLint lod, out IntPtr img);
        internal static glGetCompressedTexImageDelegate glGetCompressedTexImage;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetConvolutionFilterDelegate(GLenum target, GLenum format, GLenum type, out IntPtr image);
        internal static glGetConvolutionFilterDelegate glGetConvolutionFilter;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetConvolutionParameterfvDelegate(GLenum target, GLenum pname, out GLfloat[] param);
        internal static glGetConvolutionParameterfvDelegate glGetConvolutionParameterfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetConvolutionParameterivDelegate(GLenum target, GLenum pname, out GLint[] param);
        internal static glGetConvolutionParameterivDelegate glGetConvolutionParameteriv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLenum glGetErrorDelegate();
        internal static glGetErrorDelegate glGetError;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetHistogramDelegate(GLenum target, GLboolean reset, GLenum format, GLenum type, out IntPtr values);
        internal static glGetHistogramDelegate glGetHistogram;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetHistogramParameterfvDelegate(GLenum target, GLenum pname, out GLfloat[] param);
        internal static glGetHistogramParameterfvDelegate glGetHistogramParameterfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetHistogramParameterivDelegate(GLenum target, GLenum pname, out GLint[] param);
        internal static glGetHistogramParameterivDelegate glGetHistogramParameteriv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetLightfvDelegate(GLenum light, GLenum pname, out GLfloat[] param);
        internal static glGetLightfvDelegate glGetLightfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetLightivDelegate(GLenum light, GLenum pname, out GLint[] param);
        internal static glGetLightivDelegate glGetLightiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetMapdvDelegate(GLenum target, GLenum query, out GLdouble[] v);
        internal static glGetMapdvDelegate glGetMapdv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetMapfvDelegate(GLenum target, GLenum query, out GLfloat[] v);
        internal static glGetMapfvDelegate glGetMapfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetMapivDelegate(GLenum target, GLenum query, out GLint[] v);
        internal static glGetMapivDelegate glGetMapiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetMaterialfvDelegate(GLenum face, GLenum pname, out GLfloat[] param);
        internal static glGetMaterialfvDelegate glGetMaterialfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetMaterialivDelegate(GLenum face, GLenum pname, out GLint[] param);
        internal static glGetMaterialivDelegate glGetMaterialiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetMinmaxDelegate(GLenum target, GLboolean reset, GLenum format, GLenum types, out IntPtr values);
        internal static glGetMinmaxDelegate glGetMinmax;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetMinmaxParameterfvDelegate(GLenum target, GLenum pname, out GLfloat[] param);
        internal static glGetMinmaxParameterfvDelegate glGetMinmaxParameterfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetMinmaxParameterivDelegate(GLenum target, GLenum pname, out GLint[] param);
        internal static glGetMinmaxParameterivDelegate glGetMinmaxParameteriv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetPixelMapfvDelegate(GLenum map, out GLfloat[] data);
        internal static glGetPixelMapfvDelegate glGetPixelMapfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetPixelMapuivDelegate(GLenum map, out GLuint[] data);
        internal static glGetPixelMapuivDelegate glGetPixelMapuiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetPixelMapusvDelegate(GLenum map, out GLushort[] data);
        internal static glGetPixelMapusvDelegate glGetPixelMapusv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetPointervDelegate(GLenum pname, out IntPtr param);
        internal static glGetPointervDelegate glGetPointerv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetPolygonStippleDelegate(out GLubyte[] pattern);
        internal static glGetPolygonStippleDelegate glGetPolygonStipple;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetProgramivDelegate(GLuint program, GLenum pname, out GLint param);
        internal static glGetProgramivDelegate glGetProgramiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetProgramInfoLogDelegate(GLuint program, GLsizei maxLength, GLsizei* length, IntPtr infoLog);
        internal static glGetProgramInfoLogDelegate glGetProgramInfoLog;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetQueryObjectivDelegate(GLuint id, GLenum pname, out GLint[] param);
        internal static glGetQueryObjectivDelegate glGetQueryObjectiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetQueryObjectuivDelegate(GLuint id, GLenum pname, out GLuint[] param);
        internal static glGetQueryObjectuivDelegate glGetQueryObjectuiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetQueryivDelegate(GLenum target, GLenum pname, out GLint[] param);
        internal static glGetQueryivDelegate glGetQueryiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetSeparableFilterDelegate(GLenum target, GLenum format, GLenum type, out IntPtr row, out IntPtr column, out IntPtr span);
        internal static glGetSeparableFilterDelegate glGetSeparableFilter;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetShaderivDelegate(GLuint shader, GLenum pname, out GLint param);
        internal static glGetShaderivDelegate glGetShaderiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetShaderInfoLogDelegate(GLuint shader, GLsizei maxLength, GLsizei* length, IntPtr infoLog);
        internal static glGetShaderInfoLogDelegate glGetShaderInfoLog;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetShaderSourceDelegate(GLuint shader, GLsizei bufSize, GLsizei* length, IntPtr source);
        internal static glGetShaderSourceDelegate glGetShaderSource;

        [SuppressUnmanagedCodeSecurity]
        internal delegate byte* glGetStringDelegate(GLenum name);
        internal static glGetStringDelegate glGetString;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetTexEnvfvDelegate(GLenum target, GLenum pname, out GLfloat[] param);
        internal static glGetTexEnvfvDelegate glGetTexEnvfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetTexEnvivDelegate(GLenum target, GLenum pname, out GLint[] param);
        internal static glGetTexEnvivDelegate glGetTexEnviv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetTexGendvDelegate(GLenum coord, GLenum pname, out GLdouble[] param);
        internal static glGetTexGendvDelegate glGetTexGendv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetTexGenfvDelegate(GLenum coord, GLenum pname, out GLfloat[] param);
        internal static glGetTexGenfvDelegate glGetTexGenfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetTexGenivDelegate(GLenum coord, GLenum pname, out GLint[] param);
        internal static glGetTexGenivDelegate glGetTexGeniv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetTexImageDelegate(GLenum target, GLint level, GLenum format, GLenum type, void* img);
        internal static glGetTexImageDelegate glGetTexImage;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetTexLevelParameterfvDelegate(GLenum target, GLint level, GLenum pname, out GLfloat[] param);
        internal static glGetTexLevelParameterfvDelegate glGetTexLevelParameterfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetTexLevelParameterivDelegate(GLenum target, GLint level, GLenum pname, out GLint[] param);
        internal static glGetTexLevelParameterivDelegate glGetTexLevelParameteriv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetTexParameterfvDelegate(GLenum target, GLenum pname, out GLfloat[] param);
        internal static glGetTexParameterfvDelegate glGetTexParameterfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetTexParameterivDelegate(GLenum target, GLenum pname, out GLint[] param);
        internal static glGetTexParameterivDelegate glGetTexParameteriv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetUniformfvDelegate(GLuint program, GLint location, out GLfloat[] param);
        internal static glGetUniformfvDelegate glGetUniformfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetUniformivDelegate(GLuint program, GLint location, out GLint[] param);
        internal static glGetUniformivDelegate glGetUniformiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate int glGetUniformLocationDelegate(GLuint program, string name);
        internal static glGetUniformLocationDelegate glGetUniformLocation;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetVertexAttribdvDelegate(GLuint index, GLenum pname, out GLdouble[] param);
        internal static glGetVertexAttribdvDelegate glGetVertexAttribdv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetVertexAttribfvDelegate(GLuint index, GLenum pname, out GLfloat[] param);
        internal static glGetVertexAttribfvDelegate glGetVertexAttribfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetVertexAttribivDelegate(GLuint index, GLenum pname, out GLint[] param);
        internal static glGetVertexAttribivDelegate glGetVertexAttribiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glGetVertexAttribPointervDelegate(GLuint index, GLenum pname, out void* pointer);
        internal static glGetVertexAttribPointervDelegate glGetVertexAttribPointerv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glHintDelegate(GLenum target, GLenum mode);
        internal static glHintDelegate glHint;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glHistogramDelegate(GLenum target, GLsizei width, GLenum internalformat, GLboolean sink);
        internal static glHistogramDelegate glHistogram;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glIndexsDelegate(GLshort c);
        internal static glIndexsDelegate glIndexs;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glIndexiDelegate(GLint c);
        internal static glIndexiDelegate glIndexi;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glIndexfDelegate(GLfloat c);
        internal static glIndexfDelegate glIndexf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glIndexdDelegate(GLdouble c);
        internal static glIndexdDelegate glIndexd;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glIndexubDelegate(GLubyte c);
        internal static glIndexubDelegate glIndexub;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glIndexMaskDelegate(GLuint mask);
        internal static glIndexMaskDelegate glIndexMask;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glIndexPointerDelegate(GLenum type, GLsizei stride, void* pointer);
        internal static glIndexPointerDelegate glIndexPointer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glInitNamesDelegate();
        internal static glInitNamesDelegate glInitNames;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glInterleavedArraysDelegate(GLenum format, GLsizei stride, void* pointer);
        internal static glInterleavedArraysDelegate glInterleavedArrays;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLboolean glIsBufferDelegate(GLuint buffer);
        internal static glIsBufferDelegate glIsBuffer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLboolean glIsEnabledDelegate(GLenum cap);
        internal static glIsEnabledDelegate glIsEnabled;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLboolean glIsListDelegate(GLuint list);
        internal static glIsListDelegate glIsList;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLboolean glIsProgramDelegate(GLuint program);
        internal static glIsProgramDelegate glIsProgram;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLboolean glIsQueryDelegate(GLuint id);
        internal static glIsQueryDelegate glIsQuery;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLboolean glIsShaderDelegate(GLuint shader);
        internal static glIsShaderDelegate glIsShader;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLboolean glIsTextureDelegate(GLuint texture);
        internal static glIsTextureDelegate glIsTexture;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLightfDelegate(GLenum light, GLenum pname, GLfloat param);
        internal static glLightfDelegate glLightf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLightiDelegate(GLenum light, GLenum pname, GLint param);
        internal static glLightiDelegate glLighti;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLightModelfDelegate(GLenum pname, GLfloat param);
        internal static glLightModelfDelegate glLightModelf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLightModeliDelegate(GLenum pname, GLint param);
        internal static glLightModeliDelegate glLightModeli;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLineStippleDelegate(GLint factor, GLushort pattern);
        internal static glLineStippleDelegate glLineStipple;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLineWidthDelegate(GLfloat width);
        internal static glLineWidthDelegate glLineWidth;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLinkProgramDelegate(GLuint program);
        internal static glLinkProgramDelegate glLinkProgram;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glListBaseDelegate(GLuint b);
        internal static glListBaseDelegate glListBase;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLoadIdentityDelegate();
        internal static glLoadIdentityDelegate glLoadIdentity;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLoadMatrixdDelegate(GLdouble[] m);
        internal static glLoadMatrixdDelegate glLoadMatrixd;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLoadMatrixfDelegate(GLfloat[] m);
        internal static glLoadMatrixfDelegate glLoadMatrixf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLoadNameDelegate(GLuint name);
        internal static glLoadNameDelegate glLoadName;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLoadTransposeMatrixdDelegate(GLdouble[] m);
        internal static glLoadTransposeMatrixdDelegate glLoadTransposeMatrixd;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLoadTransposeMatrixfDelegate(GLfloat[] m);
        internal static glLoadTransposeMatrixfDelegate glLoadTransposeMatrixf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glLogicOpDelegate(GLenum opcode);
        internal static glLogicOpDelegate glLogicOp;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMap1fDelegate(GLenum target, GLfloat u1, GLfloat u2, GLint stride, GLint order, GLfloat[] points);
        internal static glMap1fDelegate glMap1f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMap1dDelegate(GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, GLdouble[] points);
        internal static glMap1dDelegate glMap1d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMap2fDelegate(GLenum target, GLfloat u1, GLfloat u2, GLint ustride, GLint uorder, GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, GLfloat[] points);
        internal static glMap2fDelegate glMap2f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMap2dDelegate(GLenum target, GLdouble u1, GLdouble u2, GLint ustride, GLint uorder, GLdouble v1, GLdouble v2, GLint vstride, GLint vorder, GLdouble[] points);
        internal static glMap2dDelegate glMap2d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMapBufferDelegate(GLenum target, GLenum access); //NOTE: maybe need IntPtr, not object
        internal static glMapBufferDelegate glMapBuffer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMapGrid1dDelegate(GLint un, GLdouble u1, GLdouble u2);
        internal static glMapGrid1dDelegate glMapGrid1d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMapGrid1fDelegate(GLint un, GLfloat u1, GLfloat u2);
        internal static glMapGrid1fDelegate glMapGrid1f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMapGrid2dDelegate(GLint un, GLdouble u1, GLdouble u2, GLint vn, GLdouble v1, GLdouble v2);
        internal static glMapGrid2dDelegate glMapGrid2d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMapGrid2fDelegate(GLint un, GLfloat u1, GLfloat u2, GLint vn, GLfloat v1, GLfloat v2);
        internal static glMapGrid2fDelegate glMapGrid2f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMaterialfDelegate(GLenum face, GLenum pname, GLfloat param);
        internal static glMaterialfDelegate glMaterialf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMaterialiDelegate(GLenum face, GLenum pname, GLint param);
        internal static glMaterialiDelegate glMateriali;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMatrixModeDelegate(GLenum mode);
        internal static glMatrixModeDelegate glMatrixMode;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMinmaxDelegate(GLenum target, GLenum internalformat, GLboolean sink);
        internal static glMinmaxDelegate glMinmax;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultMatrixdDelegate(GLdouble[] m);
        internal static glMultMatrixdDelegate glMultMatrixd;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultMatrixfDelegate(GLfloat[] m);
        internal static glMultMatrixfDelegate glMultMatrixf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultTransposeMatrixdDelegate(GLdouble[] m);
        internal static glMultTransposeMatrixdDelegate glMultTransposeMatrixd;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultTransposeMatrixfDelegate(GLfloat[] m);
        internal static glMultTransposeMatrixfDelegate glMultTransposeMatrixf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiDrawArraysDelegate(GLenum mode, GLint[] first, GLsizei[] count, GLsizei primcount);
        internal static glMultiDrawArraysDelegate glMultiDrawArrays;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiDrawElementsDelegate(GLenum mode, GLsizei[] count, GLenum type, void* indices, GLsizei primcount);
        internal static glMultiDrawElementsDelegate glMultiDrawElements;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord1sDelegate(GLenum target, GLshort s);
        internal static glMultiTexCoord1sDelegate glMultiTexCoord1s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord1iDelegate(GLenum target, GLint s);
        internal static glMultiTexCoord1iDelegate glMultiTexCoord1i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord1fDelegate(GLenum target, GLfloat s);
        internal static glMultiTexCoord1fDelegate glMultiTexCoord1f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord1dDelegate(GLenum target, GLdouble s);
        internal static glMultiTexCoord1dDelegate glMultiTexCoord1d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord2sDelegate(GLenum target, GLshort s, GLshort t);
        internal static glMultiTexCoord2sDelegate glMultiTexCoord2s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord2iDelegate(GLenum target, GLint s, GLint t);
        internal static glMultiTexCoord2iDelegate glMultiTexCoord2i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord2fDelegate(GLenum target, GLfloat s, GLfloat t);
        internal static glMultiTexCoord2fDelegate glMultiTexCoord2f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord2dDelegate(GLenum target, GLdouble s, GLdouble t);
        internal static glMultiTexCoord2dDelegate glMultiTexCoord2d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord3sDelegate(GLenum target, GLshort s, GLshort t, GLshort r);
        internal static glMultiTexCoord3sDelegate glMultiTexCoord3s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord3iDelegate(GLenum target, GLint s, GLint t, GLint r);
        internal static glMultiTexCoord3iDelegate glMultiTexCoord3i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord3fDelegate(GLenum target, GLfloat s, GLfloat t, GLfloat r);
        internal static glMultiTexCoord3fDelegate glMultiTexCoord3f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord3dDelegate(GLenum target, GLdouble s, GLdouble t, GLdouble r);
        internal static glMultiTexCoord3dDelegate glMultiTexCoord3d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord4sDelegate(GLenum target, GLshort s, GLshort t, GLshort r, GLshort q);
        internal static glMultiTexCoord4sDelegate glMultiTexCoord4s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord4iDelegate(GLenum target, GLint s, GLint t, GLint r, GLint q);
        internal static glMultiTexCoord4iDelegate glMultiTexCoord4i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord4fDelegate(GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);
        internal static glMultiTexCoord4fDelegate glMultiTexCoord4f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glMultiTexCoord4dDelegate(GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q);
        internal static glMultiTexCoord4dDelegate glMultiTexCoord4d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glNewListDelegate(GLuint list, GLenum mode);
        internal static glNewListDelegate glNewList;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glNormal3bDelegate(GLbyte nx, GLbyte ny, GLbyte nz);
        internal static glNormal3bDelegate glNormal3b;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glNormal3dDelegate(GLdouble nx, GLdouble ny, GLdouble nz);
        internal static glNormal3dDelegate glNormal3d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glNormal3fDelegate(GLfloat nx, GLfloat ny, GLfloat nz);
        internal static glNormal3fDelegate glNormal3f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glNormal3iDelegate(GLint nx, GLint ny, GLint nz);
        internal static glNormal3iDelegate glNormal3i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glNormal3sDelegate(GLshort nx, GLshort ny, GLshort nz);
        internal static glNormal3sDelegate glNormal3s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glNormalPointerDelegate(GLenum type, GLsizei stride, void* pointer);
        internal static glNormalPointerDelegate glNormalPointer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glOrthoDelegate(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble nearVal, GLdouble farVal);
        internal static glOrthoDelegate glOrtho;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPassThroughDelegate(GLfloat token);
        internal static glPassThroughDelegate glPassThrough;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPixelMapfvDelegate(GLenum map, GLsizei mapsize, GLfloat[] values);
        internal static glPixelMapfvDelegate glPixelMapfv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPixelMapuivDelegate(GLenum map, GLsizei mapsize, GLuint[] values);
        internal static glPixelMapuivDelegate glPixelMapuiv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPixelMapusvDelegate(GLenum map, GLsizei mapsize, GLushort[] values);
        internal static glPixelMapusvDelegate glPixelMapusv;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPixelStorefDelegate(GLenum pname, GLfloat param);
        internal static glPixelStorefDelegate glPixelStoref;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPixelStoreiDelegate(GLenum pname, GLint param);
        internal static glPixelStoreiDelegate glPixelStorei;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPixelTransferfDelegate(GLenum pname, GLfloat param);
        internal static glPixelTransferfDelegate glPixelTransferf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPixelTransferiDelegate(GLenum pname, GLint param);
        internal static glPixelTransferiDelegate glPixelTransferi;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPixelZoomDelegate(GLfloat xfactor, GLfloat yfactor);
        internal static glPixelZoomDelegate glPixelZoom;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPointParameterfDelegate(GLenum pname, GLfloat param);
        internal static glPointParameterfDelegate glPointParameterf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPointParameteriDelegate(GLenum pname, GLint param);
        internal static glPointParameteriDelegate glPointParameteri;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPointSizeDelegate(GLfloat size);
        internal static glPointSizeDelegate glPointSize;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPolygonModeDelegate(GLenum face, GLenum mode);
        internal static glPolygonModeDelegate glPolygonMode;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPolygonOffsetDelegate(GLfloat factor, GLfloat units);
        internal static glPolygonOffsetDelegate glPolygonOffset;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPolygonStippleDelegate(GLubyte[] pattern);
        internal static glPolygonStippleDelegate glPolygonStipple;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPopAttribDelegate(GLbitfield mask);
        internal static glPopAttribDelegate glPopAttrib;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPopClientAttribDelegate();
        internal static glPopClientAttribDelegate glPopClientAttrib;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPopMatrixDelegate();
        internal static glPopMatrixDelegate glPopMatrix;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPopNameDelegate();
        internal static glPopNameDelegate glPopName;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPrioritizeTexturesDelegate(GLsizei n, GLuint[] textures, GLclampf[] priorities);
        internal static glPrioritizeTexturesDelegate glPrioritizeTextures;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPushAttribDelegate(GLbitfield mask);
        internal static glPushAttribDelegate glPushAttrib;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPushClientAttribDelegate(GLbitfield mask);
        internal static glPushClientAttribDelegate glPushClientAttrib;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPushMatrixDelegate();
        internal static glPushMatrixDelegate glPushMatrix;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glPushNameDelegate(GLuint name);
        internal static glPushNameDelegate glPushName;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos2sDelegate(GLshort x, GLshort y);
        internal static glRasterPos2sDelegate glRasterPos2s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos2iDelegate(GLint x, GLint y);
        internal static glRasterPos2iDelegate glRasterPos2i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos2fDelegate(GLfloat x, GLfloat y);
        internal static glRasterPos2fDelegate glRasterPos2f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos2dDelegate(GLdouble x, GLdouble y);
        internal static glRasterPos2dDelegate glRasterPos2d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos3sDelegate(GLshort x, GLshort y, GLshort z);
        internal static glRasterPos3sDelegate glRasterPos3s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos3iDelegate(GLint x, GLint y, GLint z);
        internal static glRasterPos3iDelegate glRasterPos3i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos3fDelegate(GLfloat x, GLfloat y, GLfloat z);
        internal static glRasterPos3fDelegate glRasterPos3f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos3dDelegate(GLdouble x, GLdouble y, GLdouble z);
        internal static glRasterPos3dDelegate glRasterPos3d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos4sDelegate(GLshort x, GLshort y, GLshort z, GLshort w);
        internal static glRasterPos4sDelegate glRasterPos4s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos4iDelegate(GLint x, GLint y, GLint z, GLint w);
        internal static glRasterPos4iDelegate glRasterPos4i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos4fDelegate(GLfloat x, GLfloat y, GLfloat z, GLfloat w);
        internal static glRasterPos4fDelegate glRasterPos4f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRasterPos4dDelegate(GLdouble x, GLdouble y, GLdouble z, GLdouble w);
        internal static glRasterPos4dDelegate glRasterPos4d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glReadBufferDelegate(GLenum mode);
        internal static glReadBufferDelegate glReadBuffer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glReadPixelsDelegate(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, out void* data);
        internal static glReadPixelsDelegate glReadPixels;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRectdDelegate(GLdouble x1, GLdouble y1, GLdouble x2, GLdouble y2);
        internal static glRectdDelegate glRectd;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRectfDelegate(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2);
        internal static glRectfDelegate glRectf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRectiDelegate(GLint x1, GLint y1, GLint x2, GLint y2);
        internal static glRectiDelegate glRecti;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRectsDelegate(GLshort x1, GLshort y1, GLshort x2, GLshort y2);
        internal static glRectsDelegate glRects;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLint glRenderModeDelegate(GLenum mode);
        internal static glRenderModeDelegate glRenderMode;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glResetHistogramDelegate(GLenum target);
        internal static glResetHistogramDelegate glResetHistogram;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glResetMinmaxDelegate(GLenum target);
        internal static glResetMinmaxDelegate glResetMinmax;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRotatedDelegate(GLdouble angle, GLdouble x, GLdouble y, GLdouble z);
        internal static glRotatedDelegate glRotated;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glRotatefDelegate(GLfloat angle, GLfloat x, GLfloat y, GLfloat z);
        internal static glRotatefDelegate glRotatef;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSampleCoverageDelegate(GLclampf value, GLboolean invert);
        internal static glSampleCoverageDelegate glSampleCoverage;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glScaledDelegate(GLdouble x, GLdouble y, GLdouble z);
        internal static glScaledDelegate glScaled;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glScalefDelegate(GLfloat x, GLfloat y, GLfloat z);
        internal static glScalefDelegate glScalef;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glScissorDelegate(GLint x, GLint y, GLsizei width, GLsizei height);
        internal static glScissorDelegate glScissor;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSecondaryColor3bDelegate(GLbyte red, GLbyte green, GLbyte blue);
        internal static glSecondaryColor3bDelegate glSecondaryColor3b;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSecondaryColor3sDelegate(GLshort red, GLshort green, GLshort blue);
        internal static glSecondaryColor3sDelegate glSecondaryColor3s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSecondaryColor3iDelegate(GLint red, GLint green, GLint blue);
        internal static glSecondaryColor3iDelegate glSecondaryColor3i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSecondaryColor3fDelegate(GLfloat red, GLfloat green, GLfloat blue);
        internal static glSecondaryColor3fDelegate glSecondaryColor3f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSecondaryColor3dDelegate(GLdouble red, GLdouble green, GLdouble blue);
        internal static glSecondaryColor3dDelegate glSecondaryColor3d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSecondaryColor3ubDelegate(GLubyte red, GLubyte green, GLubyte blue);
        internal static glSecondaryColor3ubDelegate glSecondaryColor3ub;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSecondaryColor3usDelegate(GLushort red, GLushort green, GLushort blue);
        internal static glSecondaryColor3usDelegate glSecondaryColor3us;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSecondaryColor3uiDelegate(GLuint red, GLuint green, GLuint blue);
        internal static glSecondaryColor3uiDelegate glSecondaryColor3ui;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSecondaryColorPointerDelegate(GLint size, GLenum type, GLsizei stride, void* pointer);
        internal static glSecondaryColorPointerDelegate glSecondaryColorPointer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSelectBufferDelegate(GLsizei size, ref GLuint[] buffer);
        internal static glSelectBufferDelegate glSelectBuffer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glSeparableFilter2DDelegate(GLenum target, GLenum internalformat, GLsizei width, GLsizei height, GLenum format, GLenum type, void* row, void* column);
        internal static glSeparableFilter2DDelegate glSeparableFilter2D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glShadeModelDelegate(GLenum mode);
        internal static glShadeModelDelegate glShadeModel;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glShaderSourceDelegate(GLuint shader, GLsizei count, string[] str, GLint[] length);
        internal static glShaderSourceDelegate glShaderSource;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glStencilFuncDelegate(GLenum func, GLint reference, GLuint mask);
        internal static glStencilFuncDelegate glStencilFunc;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glStencilFuncSeparateDelegate(GLenum face, GLenum func, GLint reference, GLuint mask);
        internal static glStencilFuncSeparateDelegate glStencilFuncSeparate;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glStencilMaskDelegate(GLuint mask);
        internal static glStencilMaskDelegate glStencilMask;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glStencilMaskSeparateDelegate(GLenum face, GLuint mask);
        internal static glStencilMaskSeparateDelegate glStencilMaskSeparate;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glStencilOpDelegate(GLenum sfail, GLenum dpfail, GLenum dppass);
        internal static glStencilOpDelegate glStencilOp;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glStencilOpSeparateDelegate(GLenum face, GLenum sfail, GLenum dpfail, GLenum dppass);
        internal static glStencilOpSeparateDelegate glStencilOpSeparate;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord1sDelegate(GLshort s);
        internal static glTexCoord1sDelegate glTexCoord1s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord1iDelegate(GLint s);
        internal static glTexCoord1iDelegate glTexCoord1i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord1fDelegate(GLfloat s);
        internal static glTexCoord1fDelegate glTexCoord1f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord1dDelegate(GLdouble s);
        internal static glTexCoord1dDelegate glTexCoord1d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord2sDelegate(GLshort s, GLshort t);
        internal static glTexCoord2sDelegate glTexCoord2s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord2iDelegate(GLint s, GLint t);
        internal static glTexCoord2iDelegate glTexCoord2i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord2fDelegate(GLfloat s, GLfloat t);
        internal static glTexCoord2fDelegate glTexCoord2f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord2dDelegate(GLdouble s, GLdouble t);
        internal static glTexCoord2dDelegate glTexCoord2d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord3sDelegate(GLshort s, GLshort t, GLshort r);
        internal static glTexCoord3sDelegate glTexCoord3s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord3iDelegate(GLint s, GLint t, GLint r);
        internal static glTexCoord3iDelegate glTexCoord3i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord3fDelegate(GLfloat s, GLfloat t, GLfloat r);
        internal static glTexCoord3fDelegate glTexCoord3f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord3dDelegate(GLdouble s, GLdouble t, GLdouble r);
        internal static glTexCoord3dDelegate glTexCoord3d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord4sDelegate(GLshort s, GLshort t, GLshort r, GLshort q);
        internal static glTexCoord4sDelegate glTexCoord4s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord4iDelegate(GLint s, GLint t, GLint r, GLint q);
        internal static glTexCoord4iDelegate glTexCoord4i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord4fDelegate(GLfloat s, GLfloat t, GLfloat r, GLfloat q);
        internal static glTexCoord4fDelegate glTexCoord4f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoord4dDelegate(GLdouble s, GLdouble t, GLdouble r, GLdouble q);
        internal static glTexCoord4dDelegate glTexCoord4d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexCoordPointerDelegate(GLint size, GLenum type, GLsizei stride, void* pointer);
        internal static glTexCoordPointerDelegate glTexCoordPointer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexEnvfDelegate(GLenum target, GLenum pname, GLfloat param);
        internal static glTexEnvfDelegate glTexEnvf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexEnviDelegate(GLenum target, GLenum pname, GLint param);
        internal static glTexEnviDelegate glTexEnvi;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexGeniDelegate(GLenum coord, GLenum pname, GLint param);
        internal static glTexGeniDelegate glTexGeni;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexGenfDelegate(GLenum coord, GLenum pname, GLfloat param);
        internal static glTexGenfDelegate glTexGenf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexGendDelegate(GLenum coord, GLenum pname, GLdouble param);
        internal static glTexGendDelegate glTexGend;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexImage1DDelegate(GLenum target, GLint level, GLint internalFormat, GLsizei width, GLint border, GLenum format, GLenum type, void* data);
        internal static glTexImage1DDelegate glTexImage1D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexImage2DDelegate(GLenum target, GLint level, GLint internalFormat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, void* data);
        internal static glTexImage2DDelegate glTexImage2D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexImage3DDelegate(GLenum target, GLint level, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, void* data);
        internal static glTexImage3DDelegate glTexImage3D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexParameterfDelegate(GLenum target, GLenum pname, GLfloat param);
        internal static glTexParameterfDelegate glTexParameterf;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexParameteriDelegate(GLenum target, GLenum pname, GLint param);
        internal static glTexParameteriDelegate glTexParameteri;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexStorage1DDelegate(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width);
        internal static glTexStorage1DDelegate glTexStorage1D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexStorage2DDelegate(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height);
        internal static glTexStorage2DDelegate glTexStorage2D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexStorage3DDelegate(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth);
        internal static glTexStorage3DDelegate glTexStorage3D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexSubImage1DDelegate(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, void* data);
        internal static glTexSubImage1DDelegate glTexSubImage1D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexSubImage2DDelegate(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, void* data);
        internal static glTexSubImage2DDelegate glTexSubImage2D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTexSubImage3DDelegate(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, void* data);
        internal static glTexSubImage3DDelegate glTexSubImage3D;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTranslatedDelegate(GLdouble x, GLdouble y, GLdouble z);
        internal static glTranslatedDelegate glTranslated;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glTranslatefDelegate(GLfloat x, GLfloat y, GLfloat z);
        internal static glTranslatefDelegate glTranslatef;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform1fDelegate(GLint location, GLfloat v0);
        internal static glUniform1fDelegate glUniform1f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform2fDelegate(GLint location, GLfloat v0, GLfloat v1);
        internal static glUniform2fDelegate glUniform2f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform3fDelegate(GLint location, GLfloat v0, GLfloat v1, GLfloat v2);
        internal static glUniform3fDelegate glUniform3f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform4fDelegate(GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);
        internal static glUniform4fDelegate glUniform4f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform1iDelegate(GLint location, GLint v0);
        internal static glUniform1iDelegate glUniform1i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform2iDelegate(GLint location, GLint v0, GLint v1);
        internal static glUniform2iDelegate glUniform2i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform3iDelegate(GLint location, GLint v0, GLint v1, GLint v2);
        internal static glUniform3iDelegate glUniform3i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform4iDelegate(GLint location, GLint v0, GLint v1, GLint v2, GLint v3);
        internal static glUniform4iDelegate glUniform4i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform1dDelegate(GLint location, GLdouble v0);
        internal static glUniform1dDelegate glUniform1d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform2dDelegate(GLint location, GLdouble v0, GLdouble v1);
        internal static glUniform2dDelegate glUniform2d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform3dDelegate(GLint location, GLdouble v0, GLdouble v1, GLdouble v2);
        internal static glUniform3dDelegate glUniform3d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUniform4dDelegate(GLint location, GLdouble v0, GLdouble v1, GLdouble v2, GLdouble v3);
        internal static glUniform4dDelegate glUniform4d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate GLboolean glUnmapBufferDelegate(GLenum target);
        internal static glUnmapBufferDelegate glUnmapBuffer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glUseProgramDelegate(GLuint program);
        internal static glUseProgramDelegate glUseProgram;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glValidateProgramDelegate(GLuint program);
        internal static glValidateProgramDelegate glValidateProgram;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex2sDelegate(GLshort x, GLshort y);
        internal static glVertex2sDelegate glVertex2s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex2iDelegate(GLint x, GLint y);
        internal static glVertex2iDelegate glVertex2i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex2fDelegate(GLfloat x, GLfloat y);
        internal static glVertex2fDelegate glVertex2f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex2dDelegate(GLdouble x, GLdouble y);
        internal static glVertex2dDelegate glVertex2d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex3sDelegate(GLshort x, GLshort y, GLshort z);
        internal static glVertex3sDelegate glVertex3s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex3iDelegate(GLint x, GLint y, GLint z);
        internal static glVertex3iDelegate glVertex3i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex3fDelegate(GLfloat x, GLfloat y, GLfloat z);
        internal static glVertex3fDelegate glVertex3f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex3dDelegate(GLdouble x, GLdouble y, GLdouble z);
        internal static glVertex3dDelegate glVertex3d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex4sDelegate(GLshort x, GLshort y, GLshort z, GLshort w);
        internal static glVertex4sDelegate glVertex4s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex4iDelegate(GLint x, GLint y, GLint z, GLint w);
        internal static glVertex4iDelegate glVertex4i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex4fDelegate(GLfloat x, GLfloat y, GLfloat z, GLfloat w);
        internal static glVertex4fDelegate glVertex4f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertex4dDelegate(GLdouble x, GLdouble y, GLdouble z, GLdouble w);
        internal static glVertex4dDelegate glVertex4d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib1fDelegate(GLuint index, GLfloat v0);
        internal static glVertexAttrib1fDelegate glVertexAttrib1f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib1sDelegate(GLuint index, GLshort v0);
        internal static glVertexAttrib1sDelegate glVertexAttrib1s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib1dDelegate(GLuint index, GLdouble v0);
        internal static glVertexAttrib1dDelegate glVertexAttrib1d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib2fDelegate(GLuint index, GLfloat v0, GLfloat v1);
        internal static glVertexAttrib2fDelegate glVertexAttrib2f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib2sDelegate(GLuint index, GLshort v0, GLshort v1);
        internal static glVertexAttrib2sDelegate glVertexAttrib2s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib2dDelegate(GLuint index, GLdouble v0, GLdouble v1);
        internal static glVertexAttrib2dDelegate glVertexAttrib2d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib3fDelegate(GLuint index, GLfloat v0, GLfloat v1, GLfloat v2);
        internal static glVertexAttrib3fDelegate glVertexAttrib3f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib3sDelegate(GLuint index, GLshort v0, GLshort v1, GLshort v2);
        internal static glVertexAttrib3sDelegate glVertexAttrib3s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib3dDelegate(GLuint index, GLdouble v0, GLdouble v1, GLdouble v2);
        internal static glVertexAttrib3dDelegate glVertexAttrib3d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib4fDelegate(GLuint index, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);
        internal static glVertexAttrib4fDelegate glVertexAttrib4f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib4sDelegate(GLuint index, GLshort v0, GLshort v1, GLshort v2, GLshort v3);
        internal static glVertexAttrib4sDelegate glVertexAttrib4s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib4dDelegate(GLuint index, GLdouble v0, GLdouble v1, GLdouble v2, GLdouble v3);
        internal static glVertexAttrib4dDelegate glVertexAttrib4d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttrib4NubDelegate(GLuint index, GLubyte v0, GLubyte v1, GLubyte v2, GLubyte v3);
        internal static glVertexAttrib4NubDelegate glVertexAttrib4Nub;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexAttribPointerDelegate(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, void* pointer);
        internal static glVertexAttribPointerDelegate glVertexAttribPointer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glVertexPointerDelegate(GLint size, GLenum type, GLsizei stride, void* pointer);
        internal static glVertexPointerDelegate glVertexPointer;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glViewportDelegate(GLint x, GLint y, GLsizei width, GLsizei height);
        internal static glViewportDelegate glViewport;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glWindowPos2sDelegate(GLshort x, GLshort y);
        internal static glWindowPos2sDelegate glWindowPos2s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glWindowPos2iDelegate(GLint x, GLint y);
        internal static glWindowPos2iDelegate glWindowPos2i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glWindowPos2fDelegate(GLfloat x, GLfloat y);
        internal static glWindowPos2fDelegate glWindowPos2f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glWindowPos2dDelegate(GLdouble x, GLdouble y);
        internal static glWindowPos2dDelegate glWindowPos2d;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glWindowPos3sDelegate(GLshort x, GLshort y, GLshort z);
        internal static glWindowPos3sDelegate glWindowPos3s;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glWindowPos3iDelegate(GLint x, GLint y, GLint z);
        internal static glWindowPos3iDelegate glWindowPos3i;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glWindowPos3fDelegate(GLfloat x, GLfloat y, GLfloat z);
        internal static glWindowPos3fDelegate glWindowPos3f;

        [SuppressUnmanagedCodeSecurity]
        internal delegate void glWindowPos3dDelegate(GLdouble x, GLdouble y, GLdouble z);
        internal static glWindowPos3dDelegate glWindowPos3d;




        /* //GLU
         internal const string GluDll = "glu32.dll";
         [SuppressUnmanagedCodeSecurity]
internal delegate void gluBeginCurveDelegate(Structs.GLUnurbs* nurb);
         internal static gluBeginCurveDelegate gluBeginCurve;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluBeginPolygonDelegate(Structs.GLUtesselator* tess);
         internal static gluBeginPolygonDelegate gluBeginPolygon;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluBeginSurfaceDelegate(Structs.GLUnurbs* nurb);
         internal static gluBeginSurfaceDelegate gluBeginSurface;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluBeginTrimDelegate(Structs.GLUnurbs* nurb);
         internal static gluBeginTrimDelegate gluBeginTrim;

         [SuppressUnmanagedCodeSecurity]
internal delegate GLint gluBuild1DMipmapLevelsDelegate(GLenum target, GLint internalFormat, GLsizei width, GLenum format, GLenum type, GLint level, GLint bas, GLint max, void* data);
         internal static gluBuild1DMipmapLevelsDelegate gluBuild1DMipmapLevels;

         [SuppressUnmanagedCodeSecurity]
internal delegate GLint gluBuild1DMipmapsDelegate(GLenum target, GLint internalFormat, GLsizei width, GLenum format, GLenum type, void* data);
         internal static gluBuild1DMipmapsDelegate gluBuild1DMipmaps;

         [SuppressUnmanagedCodeSecurity]
internal delegate GLint gluBuild2DMipmapLevelsDelegate(GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLenum format, GLenum type, GLint level, GLint bas, GLint max, void* data);
         internal static gluBuild2DMipmapLevelsDelegate gluBuild2DMipmapLevels;

         [SuppressUnmanagedCodeSecurity]
internal delegate GLint gluBuild2DMipmapsDelegate(GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLenum format, GLenum type, void* data);
         internal static gluBuild2DMipmapsDelegate gluBuild2DMipmaps;

         [SuppressUnmanagedCodeSecurity]
internal delegate GLint gluBuild3DMipmapLevelsDelegate(GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, GLint level, GLint bas, GLint max, void* data);
         internal static gluBuild3DMipmapLevelsDelegate gluBuild3DMipmapLevels;

         [SuppressUnmanagedCodeSecurity]
internal delegate GLint gluBuild3DMipmapsDelegate(GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, void* data);
         internal static gluBuild3DMipmapsDelegate gluBuild3DMipmaps;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluCheckExtensionDelegate(GLubyte* extName, GLubyte* extString);
         internal static gluCheckExtensionDelegate gluCheckExtension;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluCylinderDelegate(Structs.GLUquadric* quad, GLdouble bas, GLdouble top, GLdouble height, GLint slices, GLint stacks);
         internal static gluCylinderDelegate gluCylinder;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluDeleteNurbsRendererDelegate(Structs.GLUnurbs* nurb);
         internal static gluDeleteNurbsRendererDelegate gluDeleteNurbsRenderer;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluDeleteQuadricDelegate(Structs.GLUquadric* quad);
         internal static gluDeleteQuadricDelegate gluDeleteQuadric;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluDeleteTessDelegate(Structs.GLUtesselator* tess);
         internal static gluDeleteTessDelegate gluDeleteTess;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluDiskDelegate(Structs.GLUquadric* quad, GLdouble inner, GLdouble outer, GLint slices, GLint loops);
         internal static gluDiskDelegate gluDisk;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluEndCurveDelegate(Structs.GLUnurbs* nurb);
         internal static gluEndCurveDelegate gluEndCurve;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluEndPolygonDelegate(Structs.GLUtesselator* tess);
         internal static gluEndPolygonDelegate gluEndPolygon;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluEndSurfaceDelegate(Structs.GLUnurbs* nurb);
         internal static gluEndSurfaceDelegate gluEndSurface;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluEndTrimDelegate(Structs.GLUnurbs* nurb);
         internal static gluEndTrimDelegate gluEndTrim;

         [SuppressUnmanagedCodeSecurity]
internal delegate GLubyte* gluErrorStringDelegate(GLenum error);
         internal static gluErrorStringDelegate gluErrorString;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluGetNurbsPropertyDelegate(Structs.GLUnurbs* nurb, GLenum property, out GLfloat* data);
         internal static gluGetNurbsPropertyDelegate gluGetNurbsProperty;

         [SuppressUnmanagedCodeSecurity]
internal delegate GLubyte* gluGetStringDelegate(GLenum name);
         internal static gluGetStringDelegate gluGetString;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluGetTessPropertyDelegate(Structs.GLUtesselator* tess, GLenum which, out GLdouble* data);
         internal static gluGetTessPropertyDelegate gluGetTessProperty;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluLoadSamplingMatricesDelegate(Structs.GLUnurbs* nurb, GLfloat* model, GLfloat* perspective, GLint* view);
         internal static gluLoadSamplingMatricesDelegate gluLoadSamplingMatrices;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluLookAtDelegate(GLdouble eyeX, GLdouble eyeY, GLdouble eyeZ, GLdouble centerX, GLdouble centerY, GLdouble centerZ, GLdouble upX, GLdouble upY, GLdouble upZ);
         internal static gluLookAtDelegate gluLookAt;

         [SuppressUnmanagedCodeSecurity]
internal delegate Structs.GLUnurbs* gluNewNurbsRendererDelegate();
         internal static gluNewNurbsRendererDelegate gluNewNurbsRenderer;

         [SuppressUnmanagedCodeSecurity]
internal delegate Structs.GLUquadric* gluNewQuadricDelegate();
         internal static gluNewQuadricDelegate gluNewQuadric;

         [SuppressUnmanagedCodeSecurity]
internal delegate Structs.GLUtesselator* gluNewTessDelegate();
         internal static gluNewTessDelegate gluNewTess;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluNextContourDelegate(Structs.GLUtesselator* tess, GLenum type);
         internal static gluNextContourDelegate gluNextContour;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluNurbsCallbackDelegate(Structs.GLUnurbs* nurb, GLenum which, Action CallBackFunc);
         internal static gluNurbsCallbackDelegate gluNurbsCallback;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluNurbsCallbackDataDelegate(Structs.GLUnurbs* nurb, void* userData);
         internal static gluNurbsCallbackDataDelegate gluNurbsCallbackData;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluNurbsCallbackDataEXTDelegate(Structs.GLUnurbs* nurb, void* userData);
         internal static gluNurbsCallbackDataEXTDelegate gluNurbsCallbackDataEXT;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluNurbsCurveDelegate(Structs.GLUnurbs* nurb, GLint knotCount, GLfloat* knots, GLint stride, GLfloat* control, GLint order, GLenum type);
         internal static gluNurbsCurveDelegate gluNurbsCurve;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluNurbsPropertyDelegate(Structs.GLUnurbs* nurb, GLenum property, GLfloat value);
         internal static gluNurbsPropertyDelegate gluNurbsProperty;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluNurbsSurfaceDelegate(Structs.GLUnurbs* nurb, GLint sKnotCount, GLfloat* sKnots, GLint tKnotCount, GLfloat* tKnots, GLint sStride, GLint tStride, GLfloat* control, GLint sOrder, GLint tOrder, GLenum type);
         internal static gluNurbsSurfaceDelegate gluNurbsSurface;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluOrtho2DDelegate(GLdouble left, GLdouble right, GLdouble bottom, GLdouble top);
         internal static gluOrtho2DDelegate gluOrtho2D;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluPartialDiskDelegate(Structs.GLUquadric* quad, GLdouble inner, GLdouble outer, GLint slices, GLint loops, GLdouble start, GLdouble sweep);
         internal static gluPartialDiskDelegate gluPartialDisk;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluPerspectiveDelegate(GLdouble fovy, GLdouble aspect, GLdouble zNear, GLdouble zFar);
         internal static gluPerspectiveDelegate gluPerspective;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluPickMatrixDelegate(GLdouble x, GLdouble y, GLdouble delX, GLdouble delY, GLint* viewport);
         internal static gluPickMatrixDelegate gluPickMatrix;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluProjectDelegate(GLdouble objX, GLdouble objY, GLdouble objZ, GLdouble* model, GLdouble* proj, GLint* view, out GLdouble* winX, out GLdouble* winY, out GLdouble* winZ);
         internal static gluProjectDelegate gluProject;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluPwlCurveDelegate(Structs.GLUnurbs* nurb, GLint count, GLfloat* data, GLint stride, GLenum type);
         internal static gluPwlCurveDelegate gluPwlCurve;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluQuadricCallbackDelegate(Structs.GLUquadric* quad, GLenum which, Action CallBackFunc);
         internal static gluQuadricCallbackDelegate gluQuadricCallback;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluQuadricDrawStyleDelegate(Structs.GLUquadric* quad, GLenum draw);
         internal static gluQuadricDrawStyleDelegate gluQuadricDrawStyle;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluQuadricNormalsDelegate(Structs.GLUquadric* quad, GLenum norma);
         internal static gluQuadricNormalsDelegate gluQuadricNormals;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluQuadricOrientationDelegate(Structs.GLUquadric* quad, GLenum orientation);
         internal static gluQuadricOrientationDelegate gluQuadricOrientation;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluQuadricTextureDelegate(Structs.GLUquadric* quad, GLboolean texture);
         internal static gluQuadricTextureDelegate gluQuadricTexture;

         [SuppressUnmanagedCodeSecurity]
internal delegate GLint gluScaleImageDelegate(GLenum format, GLsizei wIn, GLsizei hIn, GLenum typeIn, void* dataIn, GLsizei wOut, GLsizei hOut, GLenum typeOut, void* dataOut);
         internal static gluScaleImageDelegate gluScaleImage;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluSphereDelegate(Structs.GLUquadric* quad, GLdouble radius, GLint slices, GLint stacks);
         internal static gluSphereDelegate gluSphere;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluTessBeginContourDelegate(Structs.GLUtesselator* tess);
         internal static gluTessBeginContourDelegate gluTessBeginContour;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluTessBeginPolygonDelegate(Structs.GLUtesselator* tess, void* data);
         internal static gluTessBeginPolygonDelegate gluTessBeginPolygon;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluTessCallbackDelegate(Structs.GLUtesselator* tess, GLenum which, Action CallBackFunc);
         internal static gluTessCallbackDelegate gluTessCallback;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluTessEndContourDelegate(Structs.GLUtesselator* tess);
         internal static gluTessEndContourDelegate gluTessEndContour;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluTessEndPolygonDelegate(Structs.GLUtesselator* tess);
         internal static gluTessEndPolygonDelegate gluTessEndPolygon;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluTessNormalDelegate(Structs.GLUtesselator* tess, GLdouble valueX, GLdouble valueY, GLdouble valueZ);
         internal static gluTessNormalDelegate gluTessNormal;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluTessPropertyDelegate(Structs.GLUtesselator* tess, GLenum which, GLdouble data);
         internal static gluTessPropertyDelegate gluTessProperty;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluTessVertexDelegate(Structs.GLUtesselator* tess, GLdouble* location, void* data);
         internal static gluTessVertexDelegate gluTessVertex;

         [SuppressUnmanagedCodeSecurity]
internal delegate void gluUnProjectDelegate(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble* model, GLdouble* proj, GLint* view, out GLdouble* objX, out GLdouble* objY, out GLdouble* objZ);
         internal static gluUnProjectDelegate gluUnProject;

         [SuppressUnmanagedCodeSecurity]
internal delegate int gluUnProject4Delegate(GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, GLdouble* model, GLdouble* proj, GLint* view, GLdouble nearVal, GLdouble farVal, out GLdouble* objX, out GLdouble* objY, out GLdouble* objZ, out GLdouble* objW);
         internal static gluUnProject4Delegate gluUnProject4;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXChooseFBConfigDelegate();
         internal static glXChooseFBConfigDelegate glXChooseFBConfig;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXChooseVisualDelegate();
         internal static glXChooseVisualDelegate glXChooseVisual;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXCopyContextDelegate();
         internal static glXCopyContextDelegate glXCopyContext;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXCreateContextDelegate();
         internal static glXCreateContextDelegate glXCreateContext;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXCreateGLXPixmapDelegate();
         internal static glXCreateGLXPixmapDelegate glXCreateGLXPixmap;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXCreateNewContextDelegate();
         internal static glXCreateNewContextDelegate glXCreateNewContext;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXCreatePbufferDelegate();
         internal static glXCreatePbufferDelegate glXCreatePbuffer;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXCreatePixmapDelegate();
         internal static glXCreatePixmapDelegate glXCreatePixmap;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXCreateWindowDelegate();
         internal static glXCreateWindowDelegate glXCreateWindow;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXDestroyContextDelegate();
         internal static glXDestroyContextDelegate glXDestroyContext;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXDestroyGLXPixmapDelegate();
         internal static glXDestroyGLXPixmapDelegate glXDestroyGLXPixmap;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXDestroyPbufferDelegate();
         internal static glXDestroyPbufferDelegate glXDestroyPbuffer;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXDestroyPixmapDelegate();
         internal static glXDestroyPixmapDelegate glXDestroyPixmap;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXDestroyWindowDelegate();
         internal static glXDestroyWindowDelegate glXDestroyWindow;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXFreeContextEXTDelegate();
         internal static glXFreeContextEXTDelegate glXFreeContextEXT;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetClientStringDelegate();
         internal static glXGetClientStringDelegate glXGetClientString;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetConfigDelegate();
         internal static glXGetConfigDelegate glXGetConfig;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetContextIDEXTDelegate();
         internal static glXGetContextIDEXTDelegate glXGetContextIDEXT;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetCurrentContextDelegate();
         internal static glXGetCurrentContextDelegate glXGetCurrentContext;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetCurrentDisplayDelegate();
         internal static glXGetCurrentDisplayDelegate glXGetCurrentDisplay;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetCurrentDrawableDelegate();
         internal static glXGetCurrentDrawableDelegate glXGetCurrentDrawable;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetCurrentReadDrawableDelegate();
         internal static glXGetCurrentReadDrawableDelegate glXGetCurrentReadDrawable;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetFBConfigAttribDelegate();
         internal static glXGetFBConfigAttribDelegate glXGetFBConfigAttrib;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetFBConfigsDelegate();
         internal static glXGetFBConfigsDelegate glXGetFBConfigs;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetProcAddressDelegate();
         internal static glXGetProcAddressDelegate glXGetProcAddress;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetSelectedEventDelegate();
         internal static glXGetSelectedEventDelegate glXGetSelectedEvent;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXGetVisualFromFBConfigDelegate();
         internal static glXGetVisualFromFBConfigDelegate glXGetVisualFromFBConfig;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXImportContextEXTDelegate();
         internal static glXImportContextEXTDelegate glXImportContextEXT;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXIntroDelegate();
         internal static glXIntroDelegate glXIntro;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXIsDirectDelegate();
         internal static glXIsDirectDelegate glXIsDirect;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXMakeContextCurrentDelegate();
         internal static glXMakeContextCurrentDelegate glXMakeContextCurrent;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXMakeCurrentDelegate();
         internal static glXMakeCurrentDelegate glXMakeCurrent;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXQueryContextDelegate();
         internal static glXQueryContextDelegate glXQueryContext;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXQueryContextInfoEXTDelegate();
         internal static glXQueryContextInfoEXTDelegate glXQueryContextInfoEXT;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXQueryDrawableDelegate();
         internal static glXQueryDrawableDelegate glXQueryDrawable;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXQueryExtensionDelegate();
         internal static glXQueryExtensionDelegate glXQueryExtension;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXQueryExtensionsStringDelegate();
         internal static glXQueryExtensionsStringDelegate glXQueryExtensionsString;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXQueryServerStringDelegate();
         internal static glXQueryServerStringDelegate glXQueryServerString;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXQueryVersionDelegate();
         internal static glXQueryVersionDelegate glXQueryVersion;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXSelectEventDelegate();
         internal static glXSelectEventDelegate glXSelectEvent;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXSwapBuffersDelegate();
         internal static glXSwapBuffersDelegate glXSwapBuffers;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXUseXFontDelegate();
         internal static glXUseXFontDelegate glXUseXFont;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXWaitGLDelegate();
         internal static glXWaitGLDelegate glXWaitGL;

         [SuppressUnmanagedCodeSecurity]
internal delegate void glXWaitXDelegate();
         internal static glXWaitXDelegate glXWaitX;*/

    }
}
