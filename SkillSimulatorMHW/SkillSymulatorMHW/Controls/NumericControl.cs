using System;
using System.Windows.Forms;

namespace SkillSimulatorMHW.Controls
{
    /// <summary>
    /// 数値入力コントロール
    /// </summary>
    public partial class NumericControl : UserControl
    {
        /// <summary>
        /// 値.
        /// </summary>
        private int _value;

        /// <summary>
        /// 最大値.
        /// </summary>
        private int _max;

        /// <summary>
        /// 最小値.
        /// </summary>
        private int _min;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public NumericControl()
        {
            this._max = 99;
            this._min = 0;
            this.EnableMax = false;
            this.EnableMin = false;

            InitializeComponent();

            this.Value = 0;
        }

        /// <summary>
        /// 値
        /// </summary>
        public int Value
        {
            get
            {
                return this._value;
            }

            set
            {
                // 新旧の値を格納.
                var newValue = value;
                var oldValue = this._value;

                if (this.EnableMax && this.Max < newValue)
                {
                    // 最大を超えている場合.
                    newValue = this.Max;
                }
                else if (this.EnableMin && newValue < this.Min)
                {
                    // 最小に満たない場合.
                    newValue = this.Min;
                }

                // 新しい値を格納して反映.
                this._value = newValue;
                this.txtbVal.Text = this._value.ToString();

                // ボタンの制御.
                this.btnPlus.Enabled = !this.EnableMax || this._value < this.Max;
                this.btnMinus.Enabled = !this.EnableMin || this.Min < this._value;

                // 新旧で値が異なる場合はイベント発火.
                if (oldValue != newValue)
                {
                    this.ValueChange(this._value);
                }
            }
        }

        /// <summary>
        /// 最大の有効/無効.
        /// </summary>
        private bool EnableMax { get; set; }

        /// <summary>
        /// 最大.
        /// </summary>
        public int Max
        {
            get
            {
                return this._max;
            }

            set
            {
                this.EnableMax = true;
                this._max = value;
                this.Value = this._value;
            }

        }

        /// <summary>
        /// 最小の有効/無効.
        /// </summary>
        private bool EnableMin { get; set; }

        /// <summary>
        /// 最小.
        /// </summary>
        public int Min
        {
            get
            {
                return this._min;
            }

            set
            {
                this.EnableMin = true;
                this._min = value;
                this.Value = this._value;
            }
        }

        /// <summary>
        /// 値変更イベント.
        /// </summary>
        public Action<int> ValueChange = delegate { };
        
        /// <summary>
        /// ＋ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnPlusClick(object sender, EventArgs e)
        {
            this.Value = this._value + 1;
        }

        /// <summary>
        /// －ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallBackBtnMinusClick(object sender, EventArgs e)
        {
            this.Value = this._value - 1;
        }
    }
}
