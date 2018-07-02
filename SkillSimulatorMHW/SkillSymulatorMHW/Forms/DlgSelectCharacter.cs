using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SkillSimulatorMHW.Extensions;
using SkillSimulatorMHW.Requirements;

namespace SkillSimulatorMHW.Forms
{
    /// <summary>
    /// キャラクタ選択ダイアログクラス.
    /// </summary>
    public partial class DlgSelectCharacter : Form
    {
        /// <summary>
        /// デフォルト選択文字列.
        /// </summary>
        private const string Nothing = @"なし";

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DlgSelectCharacter(Requirement currentRequirement)
        {
            this.CurrentRequirement = currentRequirement;
            this.Charactors = new List<string>();

            InitializeComponent();

            // キャラクタリストを生成.
            this.UpdateCharactorList();

            // デフォルトを選択する.
            this.cmbSelectedCharactor.SelectValue(Ssm.Config.DefaultCharactor);
        }

        /// <summary>
        /// 現在の設定.
        /// </summary>
        private Requirement CurrentRequirement { get; set; }

        /// <summary>
        /// キャラクタ名リスト.
        /// </summary>
        private List<string> Charactors { get; set; }

        /// <summary>
        /// 編集チェックボックス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackChkCharactorEditCheckedChanged(object sender, System.EventArgs e)
        {
            this.grpCharactorEdit.Enabled = this.chkCharactorEdit.Checked;
        }

        /// <summary>
        /// 更新.
        /// </summary>
        private void UpdateCharactorList()
        {
            // キャラクタ名リストを取得.
            this.Charactors = Directory.EnumerateFiles(".", Requirement.CharactorFileFilter)
                .Select(Requirement.ExtractNameFromPath)
                .OrderBy(name => name)
                .ToList();

            // 先頭に"なし"を挿入.
            this.Charactors.Insert(0, Nothing);

            // コンボボックスを再生成..
            this.cmbSelectedCharactor.Init(this.Charactors);
        }

        /// <summary>
        /// 選択されたキャラクタ名を返却する.
        /// </summary>
        /// <returns></returns>
        public string GetSelectedCharactor()
        {
            // デフォルトが選択されている場合.
            if (0 == this.cmbSelectedCharactor.SelectedIndex)
            {
                return string.Empty;
            }

            return this.cmbSelectedCharactor.SelectedObj<string>();
        }

        /// <summary>
        /// 追加ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnAddCharactorClick(object sender, System.EventArgs e)
        {
            var name = this.txtbCharactorName.Text;

            // 空欄は無視.
            if (name.IsEmpty())
            {
                return;
            }

            // 無効な名前の場合は無視.
            if (Nothing.Equals(name))
            {
                MessageBox.Show("[{0}]は無効な名前です".Fmt(name), Ssm.Title);
                return;
            }

            // ファイルパスを生成.
            var path = Requirement.CreatePathFromeName(name);
            if (File.Exists(path))
            {
                MessageBox.Show("[{0}]は既に存在しています".Fmt(name), Ssm.Title);
                return;
            }

            // 選択を取得
            var srcName = this.cmbSelectedCharactor.SelectedObj<string>();

            // メッセージの生成.
            var header = "新たに";
            if (this.chkTakeOver.Checked)
            {
                header = "[{0}]の設定を引き継いで、".Fmt(srcName);
            }

            var message = header + "[{0}]を作成します。\nよろしいですか？\n\n※ この操作はキャンセルできません。".Fmt(name);

            // メッセージを表示.
            if (DialogResult.Yes != MessageBox.Show(message, Ssm.Title, MessageBoxButtons.YesNo))
            {
                return;
            }

            // 新たな設定を生成.
            var requirement = new Requirement();

            // 引き継ぐ場合.
            if (this.chkTakeOver.Checked)
            {
                requirement = Requirement.LoadCharactor(srcName);
            }

            // 保存する.
            requirement.Save(path);

            // 更新する.
            this.UpdateCharactorList();
        }

        /// <summary>
        /// 削除ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnDeleteCharactorClick(object sender, System.EventArgs e)
        {
            // デフォルトが選択されている場合.
            if (0 == this.cmbSelectedCharactor.SelectedIndex)
            {
                return;
            }

            // 選択を取得
            var name = this.cmbSelectedCharactor.SelectedObj<string>();

            // ファイルパスを生成.
            var path = Requirement.CreatePathFromeName(name);
            if (File.Exists(path))
            {
                // メッセージを表示.
                if (DialogResult.Yes != MessageBox.Show("[{0}]を削除します。\nよろしいですか？\n\n※ この操作はキャンセルできません。".Fmt(name), Ssm.Title, MessageBoxButtons.YesNo))
                {
                    return;
                }

                try
                {
                    File.Delete(path);

                    // 現在選択されているキャラクターが削除された場合.
                    if (this.CurrentRequirement.FilePath == path)
                    {
                        this.btnCancel.Enabled = false;
                        MessageBox.Show("現在選択中のキャラクタ[{0}]が削除されました。\n別のキャラクタを選択してください".Fmt(name), Ssm.Title);
                    }
                }
                catch (Exception ex)
                {
                    Log.Write("ファイル[{0}]の削除に失敗しました\n[{1}]".Fmt(path, ex.Message));
                    return;
                }
            }
            else
            {
                MessageBox.Show("[{0}]は既に存在していません".Fmt(name), Ssm.Title);
            }

            // 更新する.
            this.UpdateCharactorList();
        }
    }
}
