using SkillSimulatorMHW.Masters;

namespace SkillSimulatorMHW
{
    /// <summary>
    /// マスタ管理.
    /// </summary>
    public class MasterManager
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterManager()
        {
            this.MasterSeries = new MasterSeries();
            this.MasterSkill = new MasterSkill();
            this.MasterWepon = new MasterWepon();
            this.MasterArmor = new MasterArmor();
            this.MasterAmulet = new MasterAmulet();
            this.MasterAccessory = new MasterAccessory();
        }

        /// <summary>
        /// シリーズマスタ.
        /// </summary>
        public MasterSeries MasterSeries { get; set; }

        /// <summary>
        /// スキルマスタ.
        /// </summary>
        public MasterSkill MasterSkill { get; set; }

        /// <summary>
        /// 武器マスタ.
        /// </summary>
        public MasterWepon MasterWepon { get; set; }

        /// <summary>
        /// 防具マスタ.
        /// </summary>
        public MasterArmor MasterArmor { get; set; }

        /// <summary>
        /// 護石マスタ.
        /// </summary>
        public MasterAmulet MasterAmulet { get; set; }

        /// <summary>
        /// 装飾品マスタ.
        /// </summary>
        public MasterAccessory MasterAccessory { get; set; }

        /// <summary>
        /// 初期化処理.
        /// </summary>
        /// <returns>初期化成否</returns>
        public int Init()
        {
            if (!this.MasterSeries.Init())
            {
                Log.Write("シリーズマスタの読み込みに失敗しました。");
                return 21;
            }

            if (!this.MasterSkill.Init())
            {
                Log.Write("スキルマスタの読み込みに失敗しました。");
                return 22;
            }

            if (!this.MasterWepon.Init())
            {
                Log.Write("武器マスタの読み込みに失敗しました。");
                return 23;
            }

            if (!this.MasterArmor.Init())
            {
                Log.Write("防具マスタの読み込みに失敗しました。");
                return 24;
            }

            if (!this.MasterAmulet.Init())
            {
                Log.Write("護石マスタの読み込みに失敗しました。");
                return 25;
            }

            if (!this.MasterAccessory.Init())
            {
                Log.Write("装飾品マスタの読み込みに失敗しました。");
                return 26;
            }

            return 0;
        }
    }
}
