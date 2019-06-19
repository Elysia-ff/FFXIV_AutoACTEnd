using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            ActGlobals.oFormActMain.BeforeLogLineRead += new LogLineEventDelegate(OnBeforeLogRead);
        }

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.BeforeLogLineRead -= OnBeforeLogRead;

            lblStatus.Text = Define.plugInUnloaded;
        }
        #endregion

        private void OnBeforeLogRead(bool isImport, LogLineEventArgs logInfo)
        {
            string log = logInfo.logLine;
            string[] split = log.Split(Define.logSeparater);

            //            0  1                                 2
            // By Me      00|2018-12-15T01:49:32.0000000+09:00|00b9||전투 시작 10초 전! (Ellie)|10d2374e9711bbce03161c326d068b3d
            // By Another 00|2018-12-15T02:25:45.0000000+09:00|0139||전투 시작 20초 전! ('� 요맘때요맘때'��)|c9b454051d56ece188bbe7fa2a62fcd0

            if (split.Length < (int)Define.Code.Max)
                return;

            // Match found
            string code = split[(int)Define.Code.Code];
            if (code.Equals(Define.codeByMe) || code.Equals(Define.codeByParty) || code.Equals(Define.codeByAlliance))
            {
                ActGlobals.oFormActMain.EndCombat(false);

                string time = split[(int)Define.Code.Date];
                string timeStamp = GetTimeStamp(time);
                string message = split[(int)Define.Code.Message];
                string item = string.Format(Define.matchFoundFormat, timeStamp, message);
                listBox1.Items.Add(item);
            }
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
