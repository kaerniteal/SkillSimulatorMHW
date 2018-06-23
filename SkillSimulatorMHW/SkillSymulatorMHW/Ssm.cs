namespace SkillSimulatorMHW
{
    /// <summary>
    /// スキルシミュレータアクセサ.
    /// </summary>
    static class Ssm
    {
        /// <summary>
        /// 静的コンストラクタ
        /// </summary>
        static Ssm()
        {
            SkillSimulatorMhw = SkillSimulatorMhw.Instance;
        }

        /// <summary>
        /// スキルシミュレータ.
        /// </summary>
        private static SkillSimulatorMhw SkillSimulatorMhw { get; set; }

        /// <summary>
        /// タイトル.
        /// </summary>
        public static string Title
        {
            get
            {
                return SkillSimulatorMhw.Title;
            }
        }

        /// <summary>
        ///  設定.
        /// </summary>
        public static Config Config
        {
            get
            {
                return SkillSimulatorMhw.Config;
            }
        }

        /// <summary>
        ///  マスタ管理.
        /// </summary>
        public static MasterManager Master
        {
            get
            {
                return SkillSimulatorMhw.Master;
            }
        }

        /// <summary>
        /// WebInfo
        /// </summary>
        public static WebInfo WebInfo
        {
            get
            {
                return SkillSimulatorMhw.WebInfo;
            }
        }
    }
}
