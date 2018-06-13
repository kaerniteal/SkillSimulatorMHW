using System;
using System.ComponentModel;
using System.Windows.Forms;
using SkillSimulatorMHW.Executors;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Forms
{
    /// <summary>
    /// プログレスダイアログクラス.
    /// </summary>
    public partial class DlgProgress : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="title">タイトル</param>
        /// <param name="doWork">バックグラウンドで実行するメソッド</param>
        /// <param name="argument">doWorkに渡すパラメータ</param>
        public DlgProgress(
            string title,
            DoWorkEventHandler doWork,
            object argument = null)
        {
            this.InitializeComponent();

            // 初期化
            this.Error = null;

            this.Title = title;
            this.backgroundWorker.DoWork += doWork;
            this.WorkerArgument = argument;
        }

        /// <summary>
        /// バックグラウンド処理中に発生したエラー
        /// </summary>
        public Exception Error { get; private set; }

        /// <summary>
        /// フォームタイトル.
        /// </summary>
        private string Title { get; set; }

        /// <summary>
        /// バックグラウンド処理に渡すパラメータ.
        /// </summary>
        private object WorkerArgument { get; set; }

        /// <summary>
        /// 進捗表示処理
        /// </summary>
        /// <param name="processName">処理名</param>
        /// <param name="executor">処理実体</param>
        public static void ProgressProcess(string processName, ProgressExecutorBase executor)
        {
            // Workerを持つプログレスダイアログを生成
            using (var dlg = new DlgProgress(processName, executor.Execute))
            {
                // 表示と共に処理開始.
                var result = dlg.ShowDialog();

                // 終了処理呼び出し.
                executor.Closing();

                // 結果を取得する
                if (DialogResult.Cancel == result)
                {
                    // キャンセル.
                    Log.Write("キャンセルされました。");
                }
                else if (DialogResult.Abort == result)
                {
                    // エラー情報を表示.
                    Log.Write("エラー: {0}".Fmt(dlg.Error.Message));
                }
                else if (DialogResult.OK == result)
                {
                    // 正常終了.
                }
            }
        }

        /// <summary>
        /// ロード完了
        /// </summary>
        /// <param name="sender">イベント呼び出し元</param>
        /// <param name="e">イベント引数</param>
        private void CallBackProgressDialogLoad(object sender, EventArgs e)
        {
            this.Text = this.Title;
        }

        /// <summary>
        /// フォームが表示されたときにバックグラウンド処理を開始
        /// </summary>
        /// <param name="sender">イベント呼び出し元</param>
        /// <param name="e">イベント引数</param>
        private void CallBackProgressDialogShown(object sender, EventArgs e)
        {
            this.backgroundWorker.RunWorkerAsync(this.WorkerArgument);
        }

        /// <summary>
        /// キャンセルボタンが押されたとき
        /// </summary>
        /// <param name="sender">イベント呼び出し元</param>
        /// <param name="e">イベント引数</param>
        private void CallBackCancelAsyncButtonClick(object sender, EventArgs e)
        {
            this.cancelAsyncButton.Enabled = false;
            this.backgroundWorker.CancelAsync();
        }

        /// <summary>
        /// ReportProgressメソッドが呼び出されたとき
        /// </summary>
        /// <param name="sender">イベント呼び出し元</param>
        /// <param name="e">イベント引数</param>
        private void CallBackBackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // プログレスバーの値を変更する
            if (e.ProgressPercentage < this.progressBar.Minimum)
            {
                this.progressBar.Value = this.progressBar.Minimum;
            }
            else if (this.progressBar.Maximum < e.ProgressPercentage)
            {
                this.progressBar.Value = this.progressBar.Maximum;
            }
            else
            {
                this.progressBar.Value = e.ProgressPercentage;
            }

            // メッセージのテキストを変更する
            this.messageLabel.Text = (string)e.UserState;
        }

        /// <summary>
        /// バックグラウンド処理が終了したとき
        /// </summary>
        /// <param name="sender">イベント呼び出し元</param>
        /// <param name="e">イベント引数</param>
        private void CallBackBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.Error = e.Error;
                this.DialogResult = DialogResult.Abort;
            }
            else if (e.Cancelled)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }
    }
}
