using System.Collections.Generic;

namespace SkillSimulatorMHW.Web
{
    /// <summary>
    /// バージョン情報.
    /// </summary>
    class VersionInfo
    {
        /// <summary>
        /// コンストラクタ(最新版).
        /// </summary>
        public VersionInfo()
        {
            this.IsLatest = true;
            this.Version = string.Empty;
            this.Remark = string.Empty;
        }

        /// <summary>
        /// コンストラクタ(非最新版).
        /// </summary>
        public VersionInfo(string version, List<string> topic)
        {
            this.IsLatest = false;
            this.Version = version;
            this.Remark = string.Join("\n", topic);
        }

        /// <summary>
        /// 最新かどうか.
        /// </summary>
        public bool IsLatest { get; set; }

        /// <summary>
        /// バージョン文字列(x.x.x)
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 詳細.
        /// </summary>
        public string Remark { get; set; }
    }
}
