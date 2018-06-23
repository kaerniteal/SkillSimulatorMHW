using System;
using System.Diagnostics;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW
{
    /// <summary>
    /// WebInfo取得.
    /// </summary>
    class WebInfo
    {
        /// <summary>
        /// ホームページURL
        /// </summary>
        private const string HomePage = "http://www.kaerniteal.somee.com/SkillSimulatorMHW/";

        /// <summary>
        /// 起動時情報取得URL
        /// </summary>
        private const string InfoAsp = "Info.asp";

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public WebInfo()
        {
//            this.Info = null;
            this.IsLoaded = false;
        }

        /// <summary>
        /// WebInfoオブジェクト.
        /// </summary>
//        private JObject Info { get; set; }

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
            if (!Ssm.Config.EnableWebInfo)
            {
                return;
            }

            try
            {
                //var client = new HttpClient();
                //var info = client.GetStringAsync(HomePage + InfoAsp).Result;
                //this.Info = JObject.Parse(info);
                //this.IsLoaded = true;
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
        public Tuple<bool, string> IsLatestVersion()
        {
            var latestVer = string.Empty;

            if (!this.IsLoaded)
            {
                // 情報の取得失敗は放置.
                return Tuple.Create(true, latestVer);
            }

            //try
            //{
            //    var ver = this.Info["Version"];
            //    var major = Int32.Parse(ver["VerMajor"].ToString());
            //    var minor = Int32.Parse(ver["VerMinor"].ToString());
            //    var build = Int32.Parse(ver["VerBuild"].ToString());

            //    if (major <= SkillSimulatorMhw.VerMajor)
            //    {
            //        if (minor <= SkillSimulatorMhw.VerMinor)
            //        {
            //            if (build <= SkillSimulatorMhw.VerBuild)
            //            {
            //                // 最新バージョン.
            //                return Tuple.Create(true, latestVer);
            //            }
            //        }
            //    }

            //    latestVer = "{0}.{1}.{2}".Fmt(major, minor, build);
            //}
            //catch (Exception ex)
            //{
            //    if (Ssm.Config.ShowDebugLog)
            //    {
            //        Log.Write("【DEBUG】バージョンチェックに失敗。[" + ex.Message + "]");
            //    }

            //    return Tuple.Create(true, latestVer);
            //}

            return Tuple.Create(false, latestVer);
        }

        /// <summary>
        /// ホームページを開く.
        /// </summary>
        public static void OpenHomePage()
        {
            Process.Start(HomePage);
        }
    }
}
