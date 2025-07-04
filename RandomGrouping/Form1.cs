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


        }

        /// <summary>
        /// 座號列表
        /// </summary>
        CheckBox[] SeatList ;
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
                    Checked= CurrentSettings.IsSeatClick[a]
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
                IsSeatClick = Enumerable.Repeat(true, 30).ToArray()
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
        }

        //    function shuffleAndGroup()
        //    {
        //        // 定義數字範圍
        //        let numbers = [];
        //        for (let i = 1; i <= 15; i++)
        //        {
        //            numbers.push(i);
        //        }
        //        numbers.push(17);
        //        for (let i = 19; i <= 30; i++)
        //        {
        //            numbers.push(i);
        //        }

        //        // 隨機打散數字
        //        numbers = numbers.sort(() => Math.random() - 0.5);

        //        // 分組
        //        let groups = [];
        //        for (let i = 0; i < numbers.length; i += 2)
        //        {
        //            let group = numbers.slice(i, i + 2);
        //            groups.push(group);
        //        }

        //        // 顯示結果
        //        document.body.innerHTML += "<h3>隨機分組結果：</h3>";
        //        groups.forEach((group, index) => {
        //            document.body.innerHTML += `第 ${ index + 1}
        //        組: ${ group.join(", ")}< br >`;
        //        });
        //    }

        //    // 執行函式
        //    shuffleAndGroup();

    }
}
