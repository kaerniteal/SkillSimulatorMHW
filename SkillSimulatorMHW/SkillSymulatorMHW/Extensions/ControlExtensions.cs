using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SkillSimulatorMHW.Data;
using SkillSimulatorMHW.Defines;

namespace SkillSimulatorMHW.Extensions
{
    /// <summary>
    /// コントロール拡張メソッドを定義します。
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Invokeのデリゲート省略.
        /// </summary>
        /// <param name="control">自分自身</param>
        /// <param name="act">アクション</param>
        public static void BeginInvoke(this Control control, Action act)
        {
            if (control.IsHandleCreated)
            {
                control.BeginInvoke((MethodInvoker)(() => act()));
            }
        }

        /// <summary>
        /// 描画更新ネイティブメソッドの定義.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0x000B;

        /// <summary>
        /// コントロールの再描画を停止させる
        /// </summary>
        /// <param name="self">自分自身</param>
        public static void BeginControlUpdate(this Control self)
        {
            SendMessage(new HandleRef(self, self.Handle), WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// コントロールの再描画を再開させる
        /// </summary>
        /// <param name="self">自分自身</param>
        public static void EndControlUpdate(this Control self)
        {
            SendMessage(new HandleRef(self, self.Handle), WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
            self.Refresh();
        }

        /// <summary>
        /// コンボボックス初期化
        /// </summary>
        /// <param name="self">自分自身</param>
        public static void Clear(this ComboBox self)
        {
            self.Items.Clear();
            self.Items.Add(Define.StrItemNon);
            self.SelectedIndex = 0;
        }

        /// <summary>
        /// コンボボックス再生成
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <param name="items">コンボボックスアイテム</param>
        public static void Recreate<T>(this ComboBox self, List<T> items)
        {
            self.Items.Clear();

            if (null != items)
            {
                foreach (var item in items)
                {
                    self.Items.Add(item);
                }
            }

            if (0 == self.Items.Count)
            {
                self.Clear();
            }
        }

        /// <summary>
        /// コンボボックス初期化
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <param name="items">コンボボックスアイテム</param>
        public static void Init<T>(this ComboBox self, List<T> items)
        {
            // 現在選択されているオブジェクトを退避.
            var selected = self.SelectedItem;

            // 再生成する.
            self.Recreate(items);

            self.SelectedIndex = 0;
            if (null != selected)
            {
                self.SelectedItem = selected;
            }
        }

        /// <summary>
        /// コンボボックスの同じ値を持つ要素を選択する
        /// </summary>
        /// <typeparam name="T">コンボボックスアイテムの値</typeparam>
        /// <param name="self">自分自身</param>
        /// <param name="value">比較対象値</param>
        /// <returns>選択結果</returns>
        public static bool SelectValue<T>(this ComboBox self, T value)
        {
            if (self.Items.Count <= 0)
            {
                return false;
            }

            for (var i = 0; i < self.Items.Count; i++)
            {
                var item = self.Items[i];
                if ((null != item) && item.Equals(value))
                {
                    self.SelectedIndex = i;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// コンボボックスの同じ値を持つ要素を選択する
        /// </summary>
        /// <typeparam name="T">コンボボックスアイテムの値</typeparam>
        /// <param name="self">自分自身</param>
        /// <param name="value">比較対象値</param>
        /// <returns>選択結果</returns>
        public static bool SelectCmbItem<T>(this ComboBox self, T value)
        {
            if (self.Items.Count <= 0)
            {
                return false;
            }

            for (var i = 0; i < self.Items.Count; i++)
            {
                var cmbItem = self.Items[i] as CmbItem<T>;
                if (null != cmbItem && cmbItem.Equals(value))
                {
                    self.SelectedIndex = i;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// コンボボックスで選択されている値(オブジェクト)を返す.
        /// </summary>
        /// <typeparam name="T">コンボボックスアイテムの値</typeparam>
        /// <param name="self">自分自身</param>
        /// <returns>選択された値</returns>
        public static T SelectedObj<T>(this ComboBox self) where T : class
        {
            return self.SelectedItem as T;
        }

        /// <summary>
        /// コンボボックスで選択されている値(オブジェクト)を返す.
        /// </summary>
        /// <typeparam name="T">コンボボックスアイテムの値</typeparam>
        /// <param name="self">自分自身</param>
        /// <returns>選択された値</returns>
        public static T SelectedVal<T>(this ComboBox self) where T : struct
        {
            return (T)self.SelectedItem;
        }

        /// <summary>
        /// コンボボックスで選択されている値(オブジェクト)を返す.
        /// </summary>
        /// <typeparam name="T">コンボボックスアイテムの値</typeparam>
        /// <param name="self">自分自身</param>
        /// <returns>選択された値</returns>
        public static T SelectedCmbItem<T>(this ComboBox self)
        {
            var cmbItem = self.SelectedObj<CmbItem<T>>();
            return null == cmbItem
                ? default(T)
                : cmbItem.Value;
        }

        /// <summary>
        /// チェックボックスを更新イベント付きで初期化.
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <param name="value">新しい値</param>
        public static void Init(this CheckBox self, bool value)
        {
            // 値が同じ場合値の変更イベントが走らない為、一度逆の値に変更する.
            if (self.Checked == value)
            {
                self.Checked = !value;
            }

            // 値をセット.
            self.Checked = value;
        }
    }
}
