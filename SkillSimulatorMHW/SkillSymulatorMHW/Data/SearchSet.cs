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

        /// <summary>
        /// 指定部位よりもPart順で後位の未確定部位リストを取得.
        /// </summary>
        /// <returns></returns>
        public List<PartDataBase> GetUnsettledPartList(Part lastPart)
        {
            // 検索順序リスト.
            // この順序で再帰処理がまわる為、順序は意識する必要がある
            // ・装飾品は再帰処理に入る前のループで扱うため、処理不要
            // ・武器は未使用か固定の２択なので処理不要
            // ・護石は同じシリーズ護石で下位、上位がある為、再帰処理の中では最初に確定する.
            var searchList = new List<PartDataBase>
            {
                this.Head,
                this.Body,
                this.Arm,
                this.Waist,
                this.Leg,
                this.Amulet,
            };

            // 検索順序リストの順で、最終セットされた部位よりも後ろでかつ、未確定の部位のリストを生成する.
            // 組み合わせは総当りで検索するが、
            // 未確定部位リストの前方には戻らない(順序違いの同じ組み合わせが出てくるから)
            // lastPartには一つ上位のレイヤで確定した部位が入っている為、
            // 以降に検索すべきはlastPartより後方の未確定部位のみとなる。
            var hitLast = Part.Non == lastPart;
            var unsettledPartList = new List<PartDataBase>();
            foreach (var part in searchList)
            {
                // フラグがONでかつ、未確定部位ならばリストに追加.
                if (hitLast && PartState.Unsettled == part.State)
                {
                    unsettledPartList.Add(part);
                }
                // 最終格納部位を見つけたらフラグON
                else if (part.Part == lastPart)
                {
                    hitLast = true;
                }
            }

            // 全部位のリストを返す.
            return unsettledPartList;
        }
    }
}
