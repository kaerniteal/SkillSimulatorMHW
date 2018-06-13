using System.Windows.Forms;

namespace SkillSimulatorMHW
{
    /// <summary>
    /// SSMHWメインクラス.
    /// </summary>
    class SkillSimulatorMhw
    {
        /// <summary>
        /// アプリケーションバージョン.
        /// </summary>
        public const string Version = "0.4.1";

        /// <summary>
        /// アプリケーションタイトル.
        /// </summary>
        public const string Title = "Skill Simulator MHW β版 [" + Version + "]";

        /// <summary>
        /// 実装者.
        /// </summary>
        public const string Implementator = "Implementator [Kaerniteal]";

        /// <summary>
        /// シングルトンインスタンス.
        /// </summary>
        public static readonly SkillSimulatorMhw Instance = new SkillSimulatorMhw();

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        private SkillSimulatorMhw()
        {
            this.Config = Config.Load();
            this.Master = new MasterManager();
        }

        /// <summary>
        /// 動作設定.
        /// </summary>
        public Config Config { get; set; }

        /// <summary>
        /// マスタアクセサ.
        /// </summary>
        public MasterManager Master { get; private set; }

        /// <summary>
        /// 初期化処理.
        /// </summary>
        /// <returns>初期化成否</returns>
        public int Init()
        {
            Log.Write("初期化開始");

            var masterResult = this.Master.Init();
            if (0 != masterResult)
            {
                return masterResult;
            }

            Log.Write("マスタの初期化完了");

            return 0;
        }

        /// <summary>
        /// アプリケーション終了.
        /// </summary>
        public void Exit()
        {
            Application.Exit();
        }
    }
}
