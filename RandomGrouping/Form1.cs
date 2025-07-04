using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RandomGrouping
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            LoadSettings();

            InitPanel();

            InitSettings();
        }

        /// <summary>
        /// 座號列表
        /// </summary>
        CheckBox[] SeatList;
        /// <summary>
        /// 初始化列表
        /// </summary>
        void InitPanel()
        {
            SeatList = new CheckBox[CurrentSettings.IsSeatClick.Length];

            for (int a = 0; a < SeatList.Length; a++)
            {
                SeatList[a] = new CheckBox()
                {
                    Text = (a + 1).ToString(),
                    Size = new Size(170, 35),
                    BackColor = Color.FromArgb(255, 255, 190),
                    Checked = CurrentSettings.IsSeatClick[a]
                };

                var SeatID = a;
                SeatList[a].CheckedChanged += (sender, e) =>
                {
                    CurrentSettings.IsSeatClick[SeatID] = SeatList[SeatID].Checked;
                };

                SeatsLayoutPanel.Controls.Add(SeatList[a]);
            }
        }

        /// <summary>
        /// 初始化畫面數值
        /// </summary>
        void InitSettings()
        {
            InputGroupCount.Text = CurrentSettings.GroupCount.ToString();
            InputGroupCount.TextChanged += (Sender, E) =>
            {
                //Debug.WriteLine($"Input A : {Sender.}, {E}");

                if (int.TryParse(InputGroupCount.Text, out int GetNumber))
                {
                    CurrentSettings.GroupCount = GetNumber;
                }
                else
                {
                    InputGroupCount.Text = CurrentSettings.GroupCount.ToString();
                }

                Debug.WriteLine($"抽出組數: {CurrentSettings.GroupCount}");
            };
        }

        /// <summary>
        /// 
        /// </summary>
        Settings CurrentSettings;
        /// <summary>
        /// 
        /// </summary>
        const string SettingsFileName = "Settings";
        /// <summary>
        /// 
        /// </summary>
        void LoadSettings()
        {
            if (File.Exists(SettingsFileName))
            {
                try
                {
                    CurrentSettings = JsonSerializer.Deserialize<Settings>(File.ReadAllText(SettingsFileName));

                    return;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"讀取設定檔失敗: {ex.Message}");
                }
            }

            //沒有設定檔，或是設定檔讀取錯誤時，使用預設設定
            CurrentSettings = new Settings
            {
                IsSeatClick = Enumerable.Repeat(true, 30).ToArray(),
                GroupCount = 20
            };
        }

        /// <summary>
        /// 
        /// </summary>
        void SaveSettings()
        {
            var Json = JsonSerializer.Serialize(CurrentSettings);
            Debug.WriteLine(Json);

            try
            {
                File.WriteAllText(SettingsFileName, Json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"儲存設定檔失敗: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 視窗關閉前事件
        /// </summary>
        /// <param name="S"></param>
        /// <param name="E"></param>
        void OnFormClosing(object S, FormClosingEventArgs E)
        {
            //儲存設定檔
            SaveSettings();
        }

        /// <summary>
        /// 設定檔結構
        /// </summary>
        struct Settings
        {
            /// <summary>
            /// 座號是否勾選
            /// </summary>
            public bool[] IsSeatClick { get; set; }

            /// <summary>
            /// 抽出組數
            /// </summary>
            public int GroupCount { get; set; }
        }

        /// <summary>
        /// 抽出號碼
        /// </summary>
        /// <param name="S"></param>
        /// <param name="E"></param>
        void Picking(object S, EventArgs E)
        {
            var GetList = GetGroupList();

            OutputTextBox.Text = "";
            for (int a = 0; a < GetList.Length; a++)
            {
                OutputTextBox.Text += $"第 {a + 1} 組：{GetList[a]}\r\n";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        string[] GetGroupList()
        {
            var GetSeatList = new List<string>();
            for (int a = 0; a < SeatList.Length; a++)
            {
                if (SeatList[a].Checked)
                {
                    GetSeatList.Add(SeatList[a].Text);
                }
            }

            var Random = new Random();
            var RandomIndex = 0;

            var Groups = new List<string>();
            for (int a = 0; a < int.Parse(InputGroupCount.Text); a++)
            {
                if (GetSeatList.Count < 2)
                {
                    Debug.WriteLine("剩餘組數不足");
                    break;
                }

                //取兩個號碼
                for (int b = 0; b < 2; b++)
                {
                    RandomIndex = Random.Next(GetSeatList.Count);

                    var GetSeat = GetSeatList[RandomIndex];

                    if (Groups.Count() == a)
                        Groups.Add(GetSeat);
                    else
                        Groups[a] += ", " + GetSeat;

                    GetSeatList.RemoveAt(RandomIndex);
                }

                Debug.WriteLine($"第 {a + 1} 組：{Groups[a]}");
            }

            return Groups.ToArray();
        }
    }
}
