using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW.Web
{
    /// <summary>
    /// WebInfo取得.
    /// </summary>
    class WebInfo
    {
        /// <summary>
        /// 起動時情報取得URL
        /// </summary>
        private const string Infomation = "Infomation";

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public WebInfo()
        {
            this.Info = null;
            this.IsLoaded = false;
        }

        /// <summary>
        /// WebInfoオブジェクト.
        /// </summary>
        private JObject Info { get; set; }

        /// <summary>
        /// ロードが完了しているかどうか.
        /// </summary>
        private bool IsLoaded { get; set; }

        /// <summary>
        /// 初期化.
        /// </summary>
        /// <remarks>ネットワークに繋がらないケースは普通に考えられるので、エラーは返さない</remarks>
        public void Init()
        {
            if (!Ssm.Config.EnableWeb)
            {
                return;
            }

            try
            {
                var client = new HttpClient();
                var info = client.GetStringAsync(SkillSimulatorMhw.UrlHome + Infomation).Result;
                this.Info = JObject.Parse(info);
                this.IsLoaded = true;
            }
            catch (Exception ex)
            {
                if (Ssm.Config.ShowDebugLog)
                {
                    Log.Write("【DEBUG】ネットワークへ接続中に例外発生。[" + ex.Message + "]");
                }
            }
        }

        /// <summary>
        /// バージョンチェック.
        /// </summary>
        public VersionInfo IsLatestVersion()
        {
            var verInfo = new VersionInfo();

            if (!this.IsLoaded)
            {
                // 情報の取得失敗は放置.
                return verInfo;
            }

            try
            {
                var ver = this.Info["Version"];
                var major = Int32.Parse(ver["VerMajor"].ToString());
                var minor = Int32.Parse(ver["VerMinor"].ToString());
                var build = Int32.Parse(ver["VerBuild"].ToString());
                var topic = ver["Topic"].ToObject<List<string>>();

                if (major <= SkillSimulatorMhw.VerMajor)
                {
                    if (minor <= SkillSimulatorMhw.VerMinor)
                    {
                        if (build <= SkillSimulatorMhw.VerBuild)
                        {
                            // 最新バージョン.
                            return verInfo;
                        }
                    }
                }

                // 最新版ではなかった場合.
                verInfo = new VersionInfo("{0}.{1}.{2}".Fmt(major, minor, build), topic);
            }
            catch (Exception ex)
            {
                if (Ssm.Config.ShowDebugLog)
                {
                    Log.Write("【DEBUG】バージョンチェックに失敗。[" + ex.Message + "]");
                }

                return verInfo;
            }

            // 最新版ではなかった場合.
            return verInfo;
        }

        /// <summary>
        /// ホームページを開く.
        /// </summary>
        public static void OpenHomePage()
        {
            Process.Start(SkillSimulatorMhw.UrlHome);
        }
    }
}
