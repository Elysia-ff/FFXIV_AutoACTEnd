using System.Windows.Forms;
using Advanced_Combat_Tracker;

namespace AutoACTEnd
{
    public partial class AutoACTEnd : UserControl, IActPluginV1
    {
        public AutoACTEnd()
        {
            InitializeComponent();
        }

        private Label lblStatus;

        #region IActPluginV1 Method
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            pluginScreenSpace.Controls.Add(this);
            Dock = DockStyle.Fill;
            lblStatus = pluginStatusText;
            lblStatus.Text = Define.plugInLoaded;

            ActGlobals.oFormActMain.BeforeLogLineRead -= OnBeforeLogRead;
            ActGlobals.oFormActMain.BeforeLogLineRead += OnBeforeLogRead;
        }

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.BeforeLogLineRead -= OnBeforeLogRead;

            lblStatus.Text = Define.plugInUnloaded;
        }
        #endregion

        private void OnBeforeLogRead(bool isImport, LogLineEventArgs logInfo)
        {
            string log = logInfo.originalLogLine;
            string[] split = log.Split(Define.logSeparater);

            if (split.Length < 5)
                return;

            string idx = split[0];
            if (idx.Equals("00"))
            {
                //            0  1                                 2
                // By Me      00|2018-12-15T01:49:32.0000000+09:00|00b9||전투 시작 10초 전! (Ellie)|10d2374e9711bbce03161c326d068b3d
                // By Another 00|2018-12-15T02:25:45.0000000+09:00|0139||전투 시작 20초 전! ('� 요맘때요맘때'��)|c9b454051d56ece188bbe7fa2a62fcd0

                // Match found
                string param = split[2];
                if (param.Equals(Define.codeByMe) || param.Equals(Define.codeByParty) || param.Equals(Define.codeByAlliance))
                {
                    ExecuteEndEncounter(split[1], split[4]);
                }
            }
            else if (idx.Equals("33"))
            {
                // 0  1                                 2        3
                // 33|2019-12-03T20:41:11.3260000+09:00|80037586|80000004|1AF3|00|00|00|45f847035f506788423f9d873ecc74a6
                string key = split[3];

                if (Define.wipeCodes.ContainsKey(key))
                {
                    string message = string.Format(Define.dateFormat, key, Define.wipeCodes[key]);
                    ExecuteEndEncounter(split[1], message);
                }
            }
        }

        private void ExecuteEndEncounter(string time, string message)
        {
            ActGlobals.oFormActMain.EndCombat(false);

            string timeStamp = GetTimeStamp(time);
            string item = string.Format(Define.matchFoundFormat, timeStamp, message);
            listBox1.Items.Add(item);
        }

        private string GetTimeStamp(string log)
        {
            string date = log.Substring(0, 10);
            string time = log.Substring(11, 8);
            string timeStamp = string.Format(Define.dateFormat, date, time);

            return timeStamp;
        }
    }
}
