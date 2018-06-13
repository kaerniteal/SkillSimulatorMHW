using System;
using System.IO;
using System.Xml.Serialization;

namespace SkillSimulatorMHW.Extensions
{
    /// <summary>
    /// XML ドキュメントをデシリアライズするための拡張メソッドを定義します。
    /// </summary>
    public static class XmlExtensions
    {
        /// <summary>
        /// XMLドキュメントをデシリアライズします。
        /// </summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="self">自分自身</param>
        /// <returns>デシリアライズしたオブジェクト</returns>
        /// <exception cref="System.ArgumentNullException">ファイル名が空文字の場合に発生します。</exception>
        /// <exception cref="System.IO.FileNotFoundException">指定したファイルが見つからない場合に発生します。</exception>
        /// <exception cref="System.InvalidOperationException">シリアライズに失敗した場合に発生します。</exception>
        public static T XmlLoad<T>(this string self) where T : class
        {
            if (string.IsNullOrEmpty(self))
            {
                throw new ArgumentNullException();
            }

            if (!File.Exists(self))
            {
                throw new FileNotFoundException("指定したファイルが見つかりません", self);
            }

            T result;

            using (var fs = File.OpenRead(self))
            {
                var serializer = new XmlSerializer(typeof(T));
                result = serializer.Deserialize(fs) as T;
            }

            return result;
        }

        /// <summary>
        /// XMLシリアライズして出力する.
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <param name="filePath">出力先パス</param>
        public static void XmlSave(this object self, string filePath)
        {
            if ((null == self) || string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException();
            }

            // ディレクトリがない場合は作っておく。
            var dir = Path.GetDirectoryName(filePath);
            if (null != dir)
            {
                Directory.CreateDirectory(dir);
            }

            // ファイルに出力する.
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(self.GetType());
                serializer.Serialize(fs, self);
            }
        }
    }
}