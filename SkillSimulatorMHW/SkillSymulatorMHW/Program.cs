using System;
using System.Windows.Forms;
using SkillSimulatorMHW.Forms;
using SkillSimulatorMHW.Extensions;

namespace SkillSimulatorMHW
{
    /// <summary>
    /// メインクラス
    /// </summary>
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Log.Write("▼▼▼MHW スキルシミュレータ▼▼▼");

            // 初期化.
            var code = SkillSimulatorMhw.Instance.Init();
            if (0 == code)
            {
                // 起動フォーム.
                Log.Write("MHW スキルシミュレータ起動");
                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("初期化に失敗した為、終了します。\ncode:{0}".Fmt(code), Ssm.Title);
            }
        }
    }
}
