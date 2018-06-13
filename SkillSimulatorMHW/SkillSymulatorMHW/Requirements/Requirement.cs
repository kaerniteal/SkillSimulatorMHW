using System;
using System.IO;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Requirements
{
    /// <summary>
    /// 検索条件.
    /// </summary>
    public class Requirement
    {
        /// <summary>
        /// 設定ファイルパス.
        /// </summary>
        private const string FilePath = @".\SsmRequirement.xml";
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Requirement()
        {
            // 検索条件スキル
            this.RequirementSkillList = new RequirementSkillList();

            // レア度指定.
            this.RequirementRareData = new RequirementRareData();

            // 検索条件防具
            this.RequirementDataList = new RequirementDataList();
        }

        /// <summary>
        /// 必要スキルリスト
        /// </summary>
        public RequirementSkillList RequirementSkillList { get; set; }

        /// <summary>
        /// レア度指定.
        /// </summary>
        public RequirementRareData RequirementRareData { get; set; }

        /// <summary>
        /// 検索条件リスト.
        /// </summary>
        public RequirementDataList RequirementDataList { get; set; }

        /// <summary>
        /// 読み込み
        /// </summary>
        public static Requirement Load()
        {
            var requirement = new Requirement();

            // ファイルの存在チェック.
            if (File.Exists(FilePath))
            {
                try
                {
                    requirement = FilePath.XmlLoad<Requirement>();
                }
                catch (Exception e)
                {
                    Log.Write("検索条件ファイル[{0}]の読み込みに失敗しました\n[{1}]".Fmt(FilePath, e.Message));
                }
            }

            // ファイルを出力する.
            requirement.Save();

            return requirement;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            try
            {
                this.XmlSave(FilePath);
            }
            catch (Exception e)
            {
                Log.Write("検索条件ファイル[{0}]の保存に失敗しました\n[{1}]".Fmt(FilePath, e.Message));
            }
        }
    }
}
