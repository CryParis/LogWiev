using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace _3._LogView
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
            EventLog[] remoteEventLogs;

            remoteEventLogs = EventLog.GetEventLogs(".");
            Console.WriteLine("Number of logs on computer: " + remoteEventLogs.Length);
            label6.Text = "0";

            foreach (EventLog log in remoteEventLogs)
            {
                //Console.WriteLine("Log: " + log.Log);
                comboBox1.Items.Add(log.Log);
            }
        }


        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CLEAN THE DATAGRID
            this.dataGridViewEvents.DataSource = null;
            this.dataGridViewEvents.Rows.Clear();


            //GET THE VALUE OF THE COMBOBOX
            Object selectedItem = comboBox1.SelectedItem;
            Console.WriteLine(selectedItem.ToString()); //just for trying to get the correct data
            string EventName = selectedItem.ToString();


            EventLog alog = new EventLog();
            alog.Log = EventName;
            alog.MachineName = "."; //My machine

            //Counting the number of logs in total in the system
            label6.Text = ("" + alog.Entries.Count);

            //SETTING SOME PROPESTIES TO DATAGRIDVIEW 
            dataGridViewEvents.ColumnCount = 4;
            dataGridViewEvents.Columns[0].Name = "#";
            dataGridViewEvents.Columns[1].Name = "Date and Time / дата и время";
            dataGridViewEvents.Columns[2].Name = "Source / источник";
            dataGridViewEvents.Columns[3].Name = "ID";


            dataGridViewEvents.Columns[0].Width = 40;
            dataGridViewEvents.Columns[1].Width = 120;
            dataGridViewEvents.Columns[2].Width = 350;
            dataGridViewEvents.Columns[3].Width = 80;

            int i = 1;

            //FILL DATAGRID
            foreach (EventLogEntry entry in alog.Entries)
            {
                
                string[] row = new string[] { (i++).ToString(), entry.TimeGenerated.ToString(), entry.Source, entry.EventID.ToString() };
                
                dataGridViewEvents.Rows.Add(row);

            }

        }

        private void dataGridViewEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = dataGridViewEvents.SelectedCells[3].Value.ToString();
           string Kind = comboBox1.SelectedItem.ToString();


            EventLog alog = new EventLog();
            alog.Log = Kind;
            alog.MachineName = "."; //My machine

            foreach (EventLogEntry entry in alog.Entries)
            {
                if (entry.EventID.ToString() == ID)
                {
                    string date = entry.TimeGenerated.ToString();
                    string source = entry.Source;
                    string message = entry.Message;
                    string machine = entry.MachineName;


                    MessageBox.Show(
                        "[+] ID: "+ID+ "\n\n" +
                        "[+] дата и время: " + date + "\n\n" +
                        "[+] источник: " + source + "\n\n" +
                        "[+] сообщение: " + message + "\n\n" +
                        "[+] компьютер: " + machine + "\n\n"
                        );
                    break;
                }
            }
        }
    }
}
