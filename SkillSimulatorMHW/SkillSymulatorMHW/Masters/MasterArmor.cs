using System.Collections.Generic;
using System.Linq;
using SkillSimulatorMHW.Defines;

namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// 防具マスタ.
    /// </summary>
    public class MasterArmor : MasterBase<MasterArmorData>
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MasterArmor()
            : base(@"Csv/Armor.csv")
        {
        }

        /// <summary>
        /// 部位別リストの取得.
        /// </summary>
        /// <param name="part">部位</param>
        public List<MasterArmorData> GetPartList(Part part)
        {
            return this.GetRecordList()
                .Where(rec => rec.Part == part)
                .ToList();
        }

        /// <summary>
        /// 部位別リストの取得.
        /// </summary>
        /// <param name="part">部位</param>
        public List<MasterDataBase> GetMasterDataList(Part part)
        {
            // IMasterData型に変換.
            return GetPartList(part)
                .Select(rec => rec as MasterDataBase)
                .Where(rec => null != rec)
                .ToList();
        }
    }
}
