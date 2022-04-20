using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerForWork
{
    public partial class Form1 : Form
    {
        int hour, min, sec, msec;
        bool activ;
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            activ = false;
 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (activ)
            {
                msec++;
                if (msec >= 10)
                {
                    sec++;
                    msec = 0;

                }
                if (sec >= 60)
                {
                    min++;
                    sec = 0;

                }
                if (min >= 60)
                {
                    sec = 0;
                    min++;
                }
                if (min >= 60)
                {
                    hour++;
                    min = 0;

                }
            }
            StringFormat();
            
        }    

        private void StringFormat()
        {
            label1.Text = Convert.ToString(hour);
            label3.Text = Convert.ToString(min);
            label5.Text = String. Format("{0,00}",sec);
            label7.Text = Convert.ToString(msec);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            activ = false;
            ResetTime();
            
          
        }
        private void ResetTime()
        {
            sec = 0;
            msec = 0;
            min = 0;
            hour = 0;
            label5.Text = "0";
            label1.Text= "0";
            label3.Text = "0";
            label7.Text = "0";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           if (button2.BackColor == System.Drawing.Color.Aqua)
           {
              button2.BackColor = System.Drawing.Color.CadetBlue;
           }
           else
           {
             button2.BackColor = System.Drawing.Color.Aqua;
           }
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            activ = true;
            timer1.Start(); 
            timer2.Start();
        }
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer2.Interval = 1000;
            button1.MouseEnter += (s, e) =>
                button1.BackColor = Color.Green;
            button1.MouseLeave += (s, e) =>
            {
                button1.BackColor = Color.FromKnownColor(KnownColor.Control);
            }; 
            button3.MouseEnter += (s, e) =>
                button3.BackColor = Color.Green;
            button3.MouseLeave += (s, e) =>
            {
                button3.BackColor = Color.FromKnownColor(KnownColor.Control);
            };
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetTime();
            activ = false;
        }
    }
}
