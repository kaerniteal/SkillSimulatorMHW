using System.Windows.Forms;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Web;

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
        public const int VerMajor = 0;
        public const int VerMinor = 9;
        public const int VerBuild = 0;

        public string Version = "{0}.{1}.{2}".Fmt(VerMajor, VerMinor, VerBuild);

        /// <summary>
        /// アプリケーションタイトル.
        /// </summary>
        public string Title = "Skill Simulator MHW β版 [{0}.{1}.{2}]".Fmt(VerMajor, VerMinor, VerBuild);

        /// <summary>
        /// 実装者.
        /// </summary>
        public const string Implementator = "Implementator [Kaerniteal]";

        /// <summary>
        /// ホームページURL
        /// </summary>
        public const string UrlHome = "https://kaerniteal.web.fc2.com/SkillSimulatorMHW/";

        /// <summary>
        /// ホームページURL
        /// </summary>
        public const string MailAddress = "mailto:SkillSimulatorMHW@gmail.com";

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
            this.WebInfo = new WebInfo();
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
        /// WebInfo
        /// </summary>
        public WebInfo WebInfo { get; set; }

        /// <summary>
        /// 初期化処理.
        /// </summary>
        /// <returns>初期化成否</returns>
        public int Init()
        {
            Log.Write("初期化開始");

            // マスタの初期化.
            var masterResult = this.Master.Init();
            if (0 != masterResult)
            {
                return masterResult;
            }

            Log.Write("マスタの初期化完了");

            // WebInfoの初期化.
            this.WebInfo.Init();

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
