using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RandomGrouping
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            InitPanel();
        }

        /// <summary>
        /// 座號列表
        /// </summary>
        CheckBox[] SeatList = new CheckBox[30];
        /// <summary>
        /// 初始化列表
        /// </summary>
        void InitPanel()
        {
            for (int a = 0; a < SeatList.Length; a++)
            {
                SeatList[a] = new CheckBox()
                {
                    Text = (a + 1).ToString(),
                    Size = new Size(170, 35),
                    BackColor = Color.FromArgb(255, 255, 190),
                };

                SeatsLayoutPanel.Controls.Add(SeatList[a]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
