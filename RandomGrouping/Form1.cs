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
        /// �y���C��
        /// </summary>
        CheckBox[] SeatList = new CheckBox[30];
        /// <summary>
        /// ��l�ƦC��
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
