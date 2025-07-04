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
        /// �y���C��
        /// </summary>
        CheckBox[] SeatList ;
        /// <summary>
        /// ��l�ƦC��
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
                    Debug.WriteLine($"Ū���]�w�ɥ���: {ex.Message}");
                }
            }

            //�S���]�w�ɡA�άO�]�w��Ū�����~�ɡA�ϥιw�]�]�w
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
                Debug.WriteLine($"�x�s�]�w�ɥ���: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ���������e�ƥ�
        /// </summary>
        /// <param name="S"></param>
        /// <param name="E"></param>
        void OnFormClosing(object S, FormClosingEventArgs E)
        {
            //�x�s�]�w��
            SaveSettings();
        }

        /// <summary>
        /// �]�w�ɵ��c
        /// </summary>
        struct Settings
        {
            /// <summary>
            /// �y���O�_�Ŀ�
            /// </summary>
            public bool[] IsSeatClick { get; set; }
        }

        //    function shuffleAndGroup()
        //    {
        //        // �w�q�Ʀr�d��
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

        //        // �H�������Ʀr
        //        numbers = numbers.sort(() => Math.random() - 0.5);

        //        // ����
        //        let groups = [];
        //        for (let i = 0; i < numbers.length; i += 2)
        //        {
        //            let group = numbers.slice(i, i + 2);
        //            groups.push(group);
        //        }

        //        // ��ܵ��G
        //        document.body.innerHTML += "<h3>�H�����յ��G�G</h3>";
        //        groups.forEach((group, index) => {
        //            document.body.innerHTML += `�� ${ index + 1}
        //        ��: ${ group.join(", ")}< br >`;
        //        });
        //    }

        //    // ����禡
        //    shuffleAndGroup();

    }
}
