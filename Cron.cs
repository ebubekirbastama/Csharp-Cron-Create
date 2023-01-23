using System;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace Excel_Okuma_Programı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
// Bu kod ile php dosyası çalıştıran her yarım saatde çalışan bir görev oluştturuyoruz...
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "EBS Php Çalıştırma";
                TimeTrigger timeTrigger = new TimeTrigger();
                timeTrigger.Repetition.Interval = TimeSpan.FromMinutes(30);
                timeTrigger.StartBoundary = DateTime.Now.AddDays(1);
                timeTrigger.EndBoundary = DateTime.Now.AddDays(7);
                td.Triggers.Add(timeTrigger);
                td.Actions.Add(new ExecAction("C:\\xampp\\php\\php.exe", "C:\\xampp\\htdocs\\EBS\\EBSScanner\\DBKayit.php", null));
                ts.RootFolder.RegisterTaskDefinition(@"EBS Php Otomatik Çalıştırma", td);

            }
        }

    }
}
