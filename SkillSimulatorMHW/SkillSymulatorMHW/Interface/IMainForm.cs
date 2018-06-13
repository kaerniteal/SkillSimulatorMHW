using System.Collections.Generic;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Result;

namespace SkillSimulatorMHW.Interface
{
    /// <summary>
    /// メインフォームインタフェース.
    /// </summary>
    public interface IMainForm
    {
        /// <summary>
        /// スキルリストからスキルを削除.
        /// </summary>
        /// <param name="skillData">スキルデータ.</param>
        void DeleteSkill(SkillData skillData);

        /// <summary>
        /// 結果セットリストを登録.
        /// </summary>
        /// <param name="resultData">結果データ</param>
        void SetResult(ResultData resultData);
    }
}
