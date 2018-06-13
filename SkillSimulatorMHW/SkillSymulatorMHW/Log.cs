using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillSimulatorMHW
{
    /// <summary>
    /// ログ出力.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// ログバッファの最大件数.
        /// </summary>
        private const int LogMax = 1000;

        /// <summary>
        /// シングルトンインスタンス.
        /// </summary>
        private static readonly Log Instance = new Log();

        /// <summary>
        /// ロックオブジェクト
        /// </summary>
        private readonly object lockObject = new object();

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        private Log()
        {
            this.Writer = null;
            this.Buffer = new List<string>();
        }

        /// <summary>
        /// ログ出力インタフェース.
        /// </summary>
        private ILogWriter Writer { get; set; }

        /// <summary>
        /// ログ出力バッファ.
        /// </summary>
        private List<string> Buffer { get; set; }

        /// <summary>
        /// ログ出力インタフェースのセット.
        /// </summary>
        /// <param name="writer">ログ出力インタフェース</param>
        public static void SetWriter(ILogWriter writer)
        {
            Instance.Writer = writer;
        }

        /// <summary>
        /// ログの書き込み.
        /// </summary>
        /// <param name="log">ログ</param>
        public static void Write(string log)
        {
            // ログを出力.
            Instance.PutLog(log);
        }

        /// <summary>
        /// ログの出力.
        /// </summary>
        /// <param name="log">ログ</param>
        private void PutLog(string log)
        {
            lock (this.lockObject)
            {
                this.Buffer.Add("[" + DateTime.Now + "] " + log + "\r\n");
                if (LogMax < this.Buffer.Count)
                {
                    this.Buffer.RemoveAt(0);
                }

                // 出力対象が存在する場合は出力.
                if ((null != this.Writer) && this.Buffer.Any())
                {
                    // バッファしているログを全て出力.
                    foreach (var line in this.Buffer)
                    {
                        this.Writer.LogWrite(line);
                    }

                    // バッファをクリア
                    this.Buffer.Clear();
                }
            }
        }

        /// <summary>
        /// ログ出力インタフェース.
        /// </summary>
        public interface ILogWriter
        {
            /// <summary>
            /// ログを出力する.
            /// </summary>
            /// <param name="log">ログ</param>
            void LogWrite(string log);
        }
    }
}
