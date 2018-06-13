using System.Collections.Generic;

namespace SkillSimulatorMHW.Interface
{
    /// <summary>
    /// スロットを持つ装備インタフェース.
    /// </summary>
    public interface IHaveSlot
    {
        /// <summary>
        /// 所持するスロットの羅列を取得する
        /// </summary>
        /// <remarks>Lv1スロットを３つの場合1,1,1、Lv3スロット２つの場合3,3と入る</remarks>
        /// <returns></returns>
        List<int> GetSlotList();
    }
}
