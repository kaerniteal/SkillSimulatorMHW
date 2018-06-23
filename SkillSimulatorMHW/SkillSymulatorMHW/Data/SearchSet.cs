using System;
using System.Collections.Generic;
using SkillSimulatorMHW.Defines;

namespace SkillSimulatorMHW.Data
{
    /// <summary>
    /// 検索セット.
    /// </summary>
    public class SearchSet : PartSet
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SearchSet()
        {
        }

        /// <summary>
        /// コンストラクタ(シャローコピー)
        /// </summary>
        public SearchSet(SearchSet searchSet)
        {
            this.Wepon = searchSet.Wepon;
            this.Head = searchSet.Head;
            this.Body = searchSet.Body;
            this.Arm = searchSet.Arm;
            this.Waist = searchSet.Waist;
            this.Leg = searchSet.Leg;
            this.Amulet = searchSet.Amulet;
            this.Accessory = searchSet.Accessory;
        }

        /// <summary>
        /// 部位データを取得.
        /// </summary>
        /// <param name="part">部位</param>
        public PartDataBase GetPart(Part part)
        {
            switch (part)
            {   
                case Part.Wepon:     return this.Wepon;
                case Part.Head:      return this.Head;
                case Part.Body:      return this.Body;
                case Part.Arm:       return this.Arm;
                case Part.Waist:     return this.Waist;
                case Part.Leg:       return this.Leg;
                case Part.Amulet:    return this.Amulet;
                case Part.Accessory: return this.Accessory;
            }

            throw new ArgumentOutOfRangeException("part", part, null);
        }

        /// <summary>
        /// 部位データをセット.
        /// </summary>
        /// <param name="part">部位</param>
        /// <param name="candidate">データ</param>
        public void SetPart(Part part, PartDataBase candidate)
        {
            switch (part)
            {
                case Part.Wepon:
                    this.Wepon = candidate as PartDataWepon;
                    if (null == this.Wepon)
                    {
                        throw new InvalidCastException();
                    }
                    break;

                case Part.Head:
                    this.Head = candidate as PartDataArmor;
                    if (null == this.Head)
                    {
                        throw new InvalidCastException();
                    }
                    break;

                case Part.Body:
                    this.Body = candidate as PartDataArmor;
                    if (null == this.Body)
                    {
                        throw new InvalidCastException();
                    }
                    break;

                case Part.Arm:
                    this.Arm = candidate as PartDataArmor;
                    if (null == this.Arm)
                    {
                        throw new InvalidCastException();
                    }
                    break;

                case Part.Waist:
                    this.Waist = candidate as PartDataArmor;
                    if (null == this.Waist)
                    {
                        throw new InvalidCastException();
                    }
                    break;

                case Part.Leg:
                    this.Leg = candidate as PartDataArmor;
                    if (null == this.Leg)
                    {
                        throw new InvalidCastException();
                    }
                    break;

                case Part.Amulet:
                    this.Amulet = candidate as PartDataAmulet;
                    if (null == this.Amulet)
                    {
                        throw new InvalidCastException();
                    }
                    break;

                case Part.Accessory:
                    this.Accessory = candidate as PartDataAccessory;
                    if (null == this.Accessory)
                    {
                        throw new InvalidCastException();
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException("part", part, null);
            }
        }

        /// <summary>
        /// 部位を未確定に戻す.
        /// </summary>
        /// <param name="part"></param>
        public void RemovePart(Part part)
        {
            switch (part)
            {
                case Part.Wepon:
                    this.Wepon = new PartDataWepon();
                    break;

                case Part.Head:
                    this.Head = new PartDataArmor(part);
                    break;

                case Part.Body:
                    this.Body = new PartDataArmor(part);
                    break;

                case Part.Arm:
                    this.Arm = new PartDataArmor(part);
                    break;

                case Part.Waist:
                    this.Waist = new PartDataArmor(part);
                    break;

                case Part.Leg:
                    this.Leg = new PartDataArmor(part);
                    break;

                case Part.Amulet:
                    this.Amulet = new PartDataAmulet();
                    break;

                case Part.Accessory:
                    this.Accessory = new PartDataAccessory();
                    break;

                default:
                    throw new ArgumentOutOfRangeException("part", part, null);
            }
        }

        /// <summary>
        /// 対象シリーズスキルを持つ防具数を返す.
        /// </summary>
        /// <returns></returns>
        public int GetSeriesCount(int index)
        {
            // 検索処理速度向上の為、平文化.

            var result = 0;

            if (this.Head.HaveSeries(index))
            {
                result++;
            }

            if (this.Body.HaveSeries(index))
            {
                result++;
            }

            if (this.Arm.HaveSeries(index))
            {
                result++;
            }

            if (this.Waist.HaveSeries(index))
            {
                result++;
            }

            if (this.Leg.HaveSeries(index))
            {
                result++;
            }

            return result;
        }

        /// <summary>
        /// 対象スキルのスキルLvの合計を返す.
        /// </summary>
        /// <returns></returns>
        public int GetSkillLvSum(int index)
        {
            // 検索処理速度向上の為、平文化.
            return this.Head.GetSkillLv(index)
                   + this.Body.GetSkillLv(index)
                   + this.Arm.GetSkillLv(index)
                   + this.Waist.GetSkillLv(index)
                   + this.Leg.GetSkillLv(index)
                   + this.Amulet.GetSkillLv(index)
                   + this.Accessory.GetSkillLv(index);
        }

        /// <summary>
        /// 未確定防具リストを取得.
        /// </summary>
        /// <returns></returns>
        public List<PartDataBase> GetUnsettledArmorList()
        {
            // 武器と装飾品は未確定がありえないので除外.
            var result = new List<PartDataBase>();

            // 速度改善の為平文で記載.

            if (PartState.Unsettled == this.Head.State)
            {
                result.Add(this.Head);
            }

            if (PartState.Unsettled == this.Body.State)
            {
                result.Add(this.Body);
            }

            if (PartState.Unsettled == this.Arm.State)
            {
                result.Add(this.Arm);
            }

            if (PartState.Unsettled == this.Waist.State)
            {
                result.Add(this.Waist);
            }

            if (PartState.Unsettled == this.Leg.State)
            {
                result.Add(this.Leg);
            }

            return result;
        }
    }
}
