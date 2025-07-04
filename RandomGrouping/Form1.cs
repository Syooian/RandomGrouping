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
        /// �y���C��
        /// </summary>
        CheckBox[] SeatList;
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
        /// ��l�Ƶe���ƭ�
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

                Debug.WriteLine($"��X�ռ�: {CurrentSettings.GroupCount}");
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
                    Debug.WriteLine($"Ū���]�w�ɥ���: {ex.Message}");
                }
            }

            //�S���]�w�ɡA�άO�]�w��Ū�����~�ɡA�ϥιw�]�]�w
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

            /// <summary>
            /// ��X�ռ�
            /// </summary>
            public int GroupCount { get; set; }
        }

        /// <summary>
        /// ��X���X
        /// </summary>
        /// <param name="S"></param>
        /// <param name="E"></param>
        void Picking(object S, EventArgs E)
        {
            var GetList = GetGroupList();

            OutputTextBox.Text = "";
            for (int a = 0; a < GetList.Length; a++)
            {
                OutputTextBox.Text += $"�� {a + 1} �աG{GetList[a]}\r\n";
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
                    Debug.WriteLine("�Ѿl�ռƤ���");
                    break;
                }

                //����Ӹ��X
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

                Debug.WriteLine($"�� {a + 1} �աG{Groups[a]}");
            }

            return Groups.ToArray();
        }
    }
}
