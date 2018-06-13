using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace SkillSimulatorMHW.Masters
{
    /// <summary>
    /// CSV入出力のユーティリティ処理
    /// </summary>
    public class CsvIo
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CsvIo()
        {
            this.Delimiter = ",";
            this.Encoding = Encoding.GetEncoding("Shift_JIS");
            this.IsHeaderSkip = true;
            this.Cells = new List<List<string>>(); 
        }

        /// <summary>
        /// データ
        /// </summary>
        private List<List<string>> Cells { get; set; }

        /// <summary>
        /// 列数
        /// </summary>
        /// <returns>列配列</returns>
        public int ColumnCount
        {
            get
            {
                if (0 == this.RowCount)
                {
                    return 0;
                }

                return this.Cells[1].Count;
            }
        }

        /// <summary>
        /// デリミタ
        /// </summary>
        public string Delimiter { get; set; }

        /// <summary>
        /// 文字列エンコーディング
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// ヘッダ行の読み飛ばし
        /// </summary>
        public bool IsHeaderSkip { get; set; }

        /// <summary>
        /// 行数
        /// </summary>
        public int RowCount
        {
            get
            {
                return this.Cells.Count;
            }
        }

        /// <summary>
        /// 値へのアクセス
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <returns>値</returns>
        public string this[int row, int col]
        {
            get
            {
                return this.Cells[row][col];
            }

            set
            {
                this.Cells[row][col] = value;
            }
        }

        /// <summary>
        /// 列データ取得
        /// </summary>
        /// <param name="col">列</param>
        /// <returns>列配列</returns>
        public List<string> Columns(int col)
        {
            var list = new List<string>();
            foreach (var row in this.Cells)
            {
                if (col < row.Count)
                {
                    list.Add(row[col]);
                }
                else
                {
                    list.Add(string.Empty);
                }
            }

            return list;
        }

        /// <summary>
        /// CSVの行毎のオブジェクトを取得
        /// </summary>
        /// <returns>オブジェクトリスト</returns>
        public List<CsvRow> AllRows()
        {
            return this.Cells
                .Select(row => new CsvRow(row))
                .ToList();
        }

        /// <summary>
        /// ファイル読み込み
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        public void Read(string filePath)
        {
            var parser = new TextFieldParser(filePath, this.Encoding)
            {
                TextFieldType = FieldType.Delimited
            };

            parser.SetDelimiters(this.Delimiter);

            var rowIndex = 0;
            this.Cells = new List<List<string>>();
            while (parser.EndOfData == false)
            {
                var columns = parser.ReadFields().ToList();

                this.Cells.Add(new List<string>());
                foreach (string item in columns)
                {
                    this.Cells[rowIndex].Add(item);
                }

                rowIndex++;
            }

            if (this.IsHeaderSkip && (0 < this.Cells.Count))
            {
                this.Cells.RemoveAt(0);
            }
        }

        /// <summary>
        /// 行取得
        /// </summary>
        /// <param name="row">行</param>
        /// <returns>行配列</returns>
        public List<string> Rows(int row)
        {
            return this.Cells[row];
        }

        /// <summary>
        /// CSVの１行毎のデータ
        /// </summary>
        public class CsvRow
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="values">行データ</param>
            public CsvRow(List<string> values)
            {
                this.Values = values;
            }

            /// <summary>
            /// 値.
            /// </summary>
            private List<string> Values { get; set; }

            /// <summary>
            /// 値へのアクセス
            /// </summary>
            /// <param name="col">列</param>
            /// <returns>値</returns>
            public string this[int col]
            {
                get
                {
                    return this.Values[col];
                }

                set
                {
                    this.Values[col] = value;
                }
            }

            /// <summary>
            /// オーバーライド.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Join(",", this.Values);
            }
        }
    }
}
