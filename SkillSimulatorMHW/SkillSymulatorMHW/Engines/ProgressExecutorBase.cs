using System.ComponentModel;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Engines
{
    /// <summary>
    /// 進捗管理実行クラス基底.
    /// </summary>
    public abstract class ProgressExecutorBase
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ProgressExecutorBase()
        {
            this.Worker = null;
            this.Event = null;
        }

        /// <summary>
        /// Woker
        /// </summary>
        protected BackgroundWorker Worker { get; set; }

        /// <summary>
        /// WorkerEvent
        /// </summary>
        protected DoWorkEventArgs Event { get; set; }

        /// <summary>
        /// 公開実行メソッド.
        /// </summary>
        public void Execute(object sender, DoWorkEventArgs e)
        {
            // パラメータをセット.
            this.Worker = sender as BackgroundWorker;
            this.Event = e;
            if (null == this.Worker)
            {
                this.Event.Cancel = true;
                return;
            }

            // 内部実行処理(実装はオーバーライド)呼び出し.
            this.Execute();
        }

        /// <summary>
        /// 公開終了メソッド(処理終了時に呼ばれる).
        /// </summary>
        public virtual void Closing()
        {
            // 必要であればオーバーライドする.
        }

        /// <summary>
        /// キャンセルチェック.
        /// </summary>
        protected bool IsCancel()
        {
            if (null != this.Worker && this.Worker.CancellationPending)
            {
                this.Event.Cancel = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 進捗更新.
        /// </summary>
        /// <param name="percent">%</param>
        /// <param name="message"></param>
        protected void SetProgress(int percent, string message = "")
        {
            if (message.IsEmpty())
            {
                message = "{0}% 完了".Fmt(percent);
            }

            if (null != this.Worker)
            {
                this.Worker.ReportProgress(percent, message);
            }
        }

        /// <summary>
        /// 内部実行メソッド.
        /// </summary>
        protected abstract void Execute();
    }
}
