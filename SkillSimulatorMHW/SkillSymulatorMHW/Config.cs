using System;
using System.IO;
using System.Windows.Forms;
using SkillSimulatorMHW.Defines;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW
{
    /// <summary>
    /// 設定
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 設定ファイルパス.
        /// </summary>
        private const string ConfigFilePath = @".\SsmConfig.xml";

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public Config()
        {
            this.SetDefault();
        }

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        private void SetDefault()
        {
            // デフォルトはここで与える.
            this.ShowResultLimitCount = 100;

            this.SerchLimitCount = 0;
            this.UseArmorAbstract = true;
            this.EnableAsyncExec = true;
            this.EnableWebInfo = false;
            this.AnalyzeType = AnalyzeType.Always;

            this.IsDebug = false;

            this.ShowDebugLog = false;
            this.SearchEngineId = "stable";

            this.EnableDuplicateCheck = false;
            this.EnableResultOutput = false;
            this.FileNameResultOutput = @"./SsmResult.list";
        }

        /// <summary>
        /// 結果表示件数上限数.
        /// </summary>
        public int ShowResultLimitCount { get; set; }

        /// <summary>
        /// 検索上限数.
        /// </summary>
        public int SerchLimitCount { get; set; }

        /// <summary>
        /// 抽象化防具使用有無.
        /// </summary>
        public bool UseArmorAbstract { get; set; }

        /// <summary>
        /// 非同期実行の有効/無効.
        /// </summary>
        public bool EnableAsyncExec { get; set; }

        /// <summary>
        /// WebInfoを利用する.
        /// </summary>
        public bool EnableWebInfo { get; set; }

        /// <summary>
        /// 解析実行タイプ.
        /// </summary>
        public AnalyzeType AnalyzeType { get; set; }

        /// <summary>
        /// デバッグモードかどうか.
        /// </summary>
        public bool IsDebug { get; set; }

        /// <summary>
        /// デバッグログの表示ON/OFF.
        /// </summary>
        public bool ShowDebugLog { get; set; }

        /// <summary>
        /// 検索エンジンIndex
        /// </summary>
        public string SearchEngineId { get; set; }

        /// <summary>
        /// 重複チェックの有効/無効.
        /// </summary>
        public bool EnableDuplicateCheck { get; set; }

        /// <summary>
        /// 検索結果をファイル出力するかどうか.
        /// </summary>
        public bool EnableResultOutput { get; set; }

        /// <summary>
        /// 検索結果出力ファイル名.
        /// </summary>
        public string FileNameResultOutput { get; set; }

        /// <summary>
        /// 読み込み
        /// </summary>
        public static Config Load()
        {
            var config = new Config();

            // ファイルの存在をチェックし、存在する場合のみ読み込む。
            if (File.Exists(ConfigFilePath))
            {
                try
                {
                    config = ConfigFilePath.XmlLoad<Config>();
                }
                catch (Exception e)
                {
                    MessageBox.Show(@"ファイル[{0}]の読み込みに失敗しました\n\n{1}\n{2}".Fmt(ConfigFilePath, e, e.StackTrace), Ssm.Title);
                }
            }

            // 下記の２ケースを想定して毎回出力する
            // ・読み込んだ設定ファイルに項目が不足している場合.
            // ・設定ファイルが存在しない場合.
            config.Save();

            return config;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public bool Save()
        {
            var result = true;

            try
            {
                this.XmlSave(ConfigFilePath);
            }
            catch (Exception e)
            {
                MessageBox.Show(@"ファイル[{0}]の保存に失敗しました\n\n{1}\n{2}".Fmt(ConfigFilePath, e, e.StackTrace), Ssm.Title);
                result = false;
            }

            return result;
        }
    }
}
