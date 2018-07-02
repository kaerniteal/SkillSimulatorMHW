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
        /// デフォルトファイルパス.
        /// </summary>
        public const string DefaultPath = @".\SsmRequirement.xml";

        /// <summary>
        /// キャラクタ毎ファイルパス.
        /// </summary>
        public const string CharactorFileFormat = @".\SsmRequirement.{0}.xml";

        /// <summary>
        /// キャラクタ毎ファイルフィルタ.
        /// </summary>
        public const string CharactorFileFilter = @"SsmRequirement.*.xml";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Requirement()
        {
            // ファイルパス.
            this.FilePath = DefaultPath;

            // 検索条件スキル
            this.RequirementSkillList = new RequirementSkillList();

            // レア度指定.
            this.RequirementRareData = new RequirementRareData();

            // 検索条件防具
            this.RequirementDataList = new RequirementDataList();
        }

        /// <summary>
        /// ファイルパス.
        /// </summary>
        public string FilePath { get; set; }

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
        /// キャラクタ名称.
        /// </summary>
        public string Name
        {
            get
            {
                return ExtractNameFromPath(this.FilePath);
            }
        }

        /// <summary>
        /// キャラクタ名から対象ファイルパスを生成する.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CreatePathFromeName(string name)
        {
            return CharactorFileFormat.Fmt(name);
        }

        /// <summary>
        /// 対象ファイルパスからキャラクタ名を抽出する.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ExtractNameFromPath(string path)
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            if (null != fileName)
            {
                var fileEles = fileName.Split('.');
                if (2 == fileEles.Length)
                {
                    return fileEles[1];
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 読み込み
        /// </summary>
        public static Requirement LoadCharactor(string name)
        {
            var path = CreatePathFromeName(name);
            return Load(path);
        }

        /// <summary>
        /// 読み込み
        /// </summary>
        /// <param name="filePath"></param>
        public static Requirement Load(string filePath = DefaultPath)
        {
            // デフォルトで作成.
            var requirement = new Requirement();

            // ファイルパス.
            var path = string.Empty;

            // 指定ファイルの存在チェック.
            if (File.Exists(filePath))
            {
                path = filePath;
            }
            // デフォルトファイルの存在チェック.
            else if (File.Exists(DefaultPath))
            {
                path = DefaultPath;
            }

            // ファイルが存在するならば.
            if (!path.IsEmpty())
            {
                try
                {
                    requirement = path.XmlLoad<Requirement>();
                    requirement.FilePath = path;
                }
                catch (Exception e)
                {
                    Log.Write("検索条件ファイル[{0}]の読み込みに失敗しました\n[{1}]".Fmt(path, e.Message));
                }
            }

            // ファイルを出力する.
            requirement.Save();

            return requirement;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save(string path)
        {
            try
            {
                this.XmlSave(path);
            }
            catch (Exception e)
            {
                Log.Write("検索条件ファイル[{0}]の保存に失敗しました\n[{1}]".Fmt(DefaultPath, e.Message));
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            this.Save(this.FilePath);
        }
    }
}
