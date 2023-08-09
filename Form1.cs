using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;

namespace SemaphoreAndThreads
{
    public partial class Form1 : Form
    {
        //private Semaphore _semaphore;
        private static Semaphore _semaphore;
        private List<Work> _items;
        private int size;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += StopAllThreads;
            size = 3;
            this.SemaphoreCapacity.Value = size;
            _semaphore = new Semaphore(size, 99);
            _items = new List<Work>();
        }

        private void AddThread(object sender, EventArgs e)
        {
            _items.Add(new Work(_semaphore, _items.Count, this));
            CreatedThreads.Items.Add(_items.Last().Name);
        }

        private void StartThread(object sender, EventArgs e)
        {
            if (CreatedThreads.SelectedItem == null) return;
            string tmp = this.CreatedThreads.SelectedItem.ToString();
            Work t = _items.Find(x => x.Name.Equals(tmp));
            t.t.Start();
            this.CreatedThreads.Items.Remove(tmp);
        }

        private void StopThread(object sender, EventArgs e)
        {
            if (WorkingThreads.SelectedItem == null) return;
            string s = (sender as ListBox).SelectedItem.ToString();
            Stop(s);
        }

        private void SemaphoreResize(object sender, EventArgs e)
        {
            if (size > (int)SemaphoreCapacity.Value)
            {
                if (WorkingThreads.Items.Count != 0 && WorkingThreads.Items.Count > (int)SemaphoreCapacity.Value)
                {
                    for (int i = (int)SemaphoreCapacity.Value, j = 0; i < size; i++, j++)
                    {
                        Stop(WorkingThreads.Items[j].ToString());
                    }
                }
                if ((int)SemaphoreCapacity.Value > 0 && (int)SemaphoreCapacity.Value > WorkingThreads.Items.Count)
                {
                    _semaphore = new Semaphore((int)SemaphoreCapacity.Value - WorkingThreads.Items.Count, 99);
                }
                if ((int)SemaphoreCapacity.Value > 0 && (int)SemaphoreCapacity.Value <= WorkingThreads.Items.Count)
                {
                    _semaphore = new Semaphore(0, 99);
                }
                ReassignSemaphore(_semaphore);
            }
            if (size < (int)SemaphoreCapacity.Value)
            {
                if (_items == null) return;
                for (int i = size; i < (int)SemaphoreCapacity.Value; i++)
                {
                    _semaphore.Release();
                }
            }
            size = (int)SemaphoreCapacity.Value;
        }

        private void ReassignSemaphore(Semaphore semaphore)
        {
            if (_items == null) return;
            Work.ChangeSemaphore(semaphore);
        }

        //private void ReassignSemaphore(Semaphore semaphore)
        //{
        //    if (_items == null) return;
        //    _items.ForEach(item => item.ChangeSemaphore(semaphore));
        //}


        //private void SemaphoreResize(object sender, EventArgs e)
        //{
        //    if (size > (int)SemaphoreCapacity.Value)
        //    {
        //        for (int i = (int)SemaphoreCapacity.Value, j = 0; i < size; i++, j++)
        //        {
        //            WorkingThreads.Items.RemoveAt(j);
        //        }
        //    }
        //    if (size < (int)SemaphoreCapacity.Value)
        //    {
        //        if (_items == null) return;
        //        for (int i = size; i < (int)SemaphoreCapacity.Value; i++)
        //        {
        //            _semaphore.Release();
        //        }
        //    }
        //    size = (int)SemaphoreCapacity.Value;
        //}

        private void Stop(string name)
        {
            string tmp = name;
            tmp = tmp.Substring(0, tmp.IndexOf("-") - 1);
            Work t = _items.Find(x => x.Name.Equals(tmp));
            //t.t.Interrupt();
            t.StopFlag = true;
        }

        private void StopAllThreads(object sender, EventArgs e)
        {
            if (_items == null) return;
            _items.ForEach(x => x.StopFlag = true);
        }
    }
}