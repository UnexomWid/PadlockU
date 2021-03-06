﻿/**
 * PadlockU (https://github.com/UnexomWid/PadlockU)
 *
 * This project is licensed under the MIT license.
 * Copyright (c) 2018-2019 UnexomWid (https://uw.exom.dev)
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the
 * following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace PadlockU
{
    internal static class Helper
    {
        internal static string SafeFileName(string file)
        {
            string safeFileName = "";
            foreach (char p in ReverseString(file))
            {
                if (p == '\\')
                    break;
                else safeFileName += p;
            }

            return ReverseString(safeFileName);
        }

        internal static string ReverseString(string s)
        {
            if (s == null)
                return null;

            char[] c = s.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }

        public enum Action { Encrypt, Decrypt }
        internal static void RunAESAlgorithm(Action action, string file, string dumpFile, ICryptoTransform cipher)
        {
            #region IO Test

            using (FileStream testreadf = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None))
            {

            }
            using (FileStream testwritef = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {

            }
            File.Delete(dumpFile);

            #endregion

            #region Work

            using (FileStream writef = new FileStream(dumpFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                using (CryptoStream dumpData = new CryptoStream(writef, cipher, CryptoStreamMode.Write))
                {
                    using (FileStream readf = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        readf.CopyTo(dumpData);
                        dumpData.FlushFinalBlock();
                    }
                }
            }

            #endregion
        }

        internal static SymmetricAlgorithm GetCipher(string key)
        {
            int keySize = 256;
            int blockSize = 128;

            SymmetricAlgorithm cipher = new AesCryptoServiceProvider();

            byte[] saltBytes = new byte[32];
            byte[] IV = new byte[32];
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            saltBytes = Encoding.Unicode.GetBytes(ToHex(RunKeyedHashAlgorihm(KeyedHashAlgorithm.HMACMD5, Encoding.UTF8.GetBytes(key), ToHex(RunHashAlgorithm(HashAlgorithm.RIPEMD160, Encoding.UTF8.GetBytes(key)), true)), true));
            IV = Encoding.Unicode.GetBytes(ToHex(RunKeyedHashAlgorihm(KeyedHashAlgorithm.HMACMD5, Encoding.UTF8.GetBytes(key), ToHex(RunHashAlgorithm(HashAlgorithm.SHA1, Encoding.UTF8.GetBytes(key)), true)), true));

            keyBytes = new Rfc2898DeriveBytes(key, saltBytes).GetBytes(keySize / 8);
            byte[] IVBytes = new Rfc2898DeriveBytes(key, IV).GetBytes(blockSize / 8);

            cipher.KeySize = keySize;
            cipher.BlockSize = blockSize;
            cipher.Key = keyBytes;
            cipher.IV = IVBytes;
            cipher.Mode = CipherMode.CBC;
            cipher.Padding = PaddingMode.PKCS7;

            return cipher;
        }

        public enum HashAlgorithm { MD5, SHA1, SHA256, SHA384, SHA512, RIPEMD160 }
        internal static byte[] RunHashAlgorithm(HashAlgorithm algorithm, byte[] data)
        {
            switch (algorithm)
                {
                    case HashAlgorithm.MD5:
                        #region MD5

                        MD5 MD5_cipher = new MD5CryptoServiceProvider();
                        return MD5_cipher.ComputeHash(data);

                    #endregion

                    case HashAlgorithm.SHA1:
                        #region SHA1

                        SHA1 SHA1_cipher = new SHA1Managed();
                        return SHA1_cipher.ComputeHash(data);

                    #endregion

                    case HashAlgorithm.SHA256:
                        #region SHA256

                        SHA256 SHA256_cipher = new SHA256Managed();
                        return SHA256_cipher.ComputeHash(data);

                    #endregion

                    case HashAlgorithm.SHA384:
                        #region SHA384

                        SHA384 SHA384_cipher = new SHA384Managed();
                        return SHA384_cipher.ComputeHash(data);

                    #endregion

                    case HashAlgorithm.SHA512:
                        #region SHA512

                        SHA512 SHA512_cipher = new SHA512Managed();
                        return SHA512_cipher.ComputeHash(data);

                    #endregion

                    case HashAlgorithm.RIPEMD160:
                        #region RIPEMD160

                        RIPEMD160 RIPEMD160_cipher = new RIPEMD160Managed();
                        return RIPEMD160_cipher.ComputeHash(data);

                    #endregion

                    default:
                        return null;
                }
}

        public enum KeyedHashAlgorithm { HMACMD5, HMACSHA1, HMACSHA256, HMACSHA384, HMACSHA512, HMACRIPEMD160 }
        internal static byte[] RunKeyedHashAlgorihm(KeyedHashAlgorithm algorithm, byte[] data, string key)
        {
            switch (algorithm)
            {
                case KeyedHashAlgorithm.HMACMD5:
                    #region HMACMD5

                    HMACMD5 HMACMD5_cipher = new HMACMD5(Encoding.UTF8.GetBytes(key));
                    return HMACMD5_cipher.ComputeHash(data);

                #endregion

                case KeyedHashAlgorithm.HMACSHA1:
                    #region HMACSHA1

                    HMACSHA1 HMACSHA1_cipher = new HMACSHA1(Encoding.UTF8.GetBytes(key));
                    return HMACSHA1_cipher.ComputeHash(data);

                #endregion

                case KeyedHashAlgorithm.HMACSHA256:
                    #region HMACSHA256

                    HMACSHA256 HMACSHA256_cipher = new HMACSHA256(Encoding.UTF8.GetBytes(key));
                    return HMACSHA256_cipher.ComputeHash(data);

                #endregion

                case KeyedHashAlgorithm.HMACSHA384:
                    #region HMACSHA384

                    HMACSHA384 HMACSHA384_cipher = new HMACSHA384(Encoding.UTF8.GetBytes(key));
                    return HMACSHA384_cipher.ComputeHash(data);

                #endregion

                case KeyedHashAlgorithm.HMACSHA512:
                    #region HMACSHA512

                    HMACSHA512 HMACSHA512_cipher = new HMACSHA512(Encoding.UTF8.GetBytes(key));
                    return HMACSHA512_cipher.ComputeHash(data);

                #endregion

                case KeyedHashAlgorithm.HMACRIPEMD160:
                    #region HMACRIPEMD160

                    HMACRIPEMD160 HMACRIPEMD160_cipher = new HMACRIPEMD160(Encoding.UTF8.GetBytes(key));
                    return HMACRIPEMD160_cipher.ComputeHash(data);

                #endregion

                default:
                    return null;
            }
        }

        internal static string ToHex(byte[] data, bool uppercase)
        {
            StringBuilder hexData = new StringBuilder(data.Length * 2);

            foreach (byte u in data)
            {
                hexData.Append(u.ToString(uppercase ? "X2" : "x2"));
            }

            return hexData.ToString();
        }

        internal static string GetSHA1(byte[] data)
        {
            return ToHex(RunHashAlgorithm(HashAlgorithm.SHA1, data), true);
        }

        internal static string GetSHA256(byte[] data)
        {
            return ToHex(RunHashAlgorithm(HashAlgorithm.SHA256, data), true);
        }

        internal static string GetSHA384(byte[] data)
        {
            return ToHex(RunHashAlgorithm(HashAlgorithm.SHA384, data), true);
        }

        internal static string GetSHA512(byte[] data)
        {
            return ToHex(RunHashAlgorithm(HashAlgorithm.SHA512, data), true);
        }
    }
}
