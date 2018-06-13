using System.Collections.Generic;

namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// 武器マスタ.
    /// </summary>
    public class MasterWepon : MasterBase<MasterWeponData>
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterWepon()
            : base(string.Empty)
        {
        }

        /// <summary>
        /// マスタ初期化.
        /// </summary>
        public override bool Init()
        {
            // 抽象化武器リストを登録.
            var wepontList = new List<MasterWeponData>
            {
                new MasterWeponAbstract(1, 0, 0, 0),
                new MasterWeponAbstract(2, 0, 0, 0),
                new MasterWeponAbstract(3, 0, 0, 0),
                new MasterWeponAbstract(1, 1, 0, 0),
                new MasterWeponAbstract(2, 1, 0, 0),
                new MasterWeponAbstract(2, 2, 0, 0),
                new MasterWeponAbstract(3, 1, 0, 0),
                new MasterWeponAbstract(3, 2, 0, 0),
                new MasterWeponAbstract(3, 3, 0, 0),
                new MasterWeponAbstract(1, 1, 1, 0),
                new MasterWeponAbstract(2, 1, 1, 0),
                new MasterWeponAbstract(2, 2, 1, 0),
                new MasterWeponAbstract(3, 1, 1, 0),
                new MasterWeponAbstract(3, 2, 1, 0),
                new MasterWeponAbstract(3, 3, 1, 0),
            };

            // 全て登録.
            foreach (var wepon in wepontList)
            {
                var key = wepon.GetIndex();
                this.Records.Add(key, wepon);
            }

            return true;
        }
    }
}
