using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Timer = System.Threading.Timer;

namespace SemaphoreAndThreads
{
    internal class Work
    {
        private static Form1 _parent { get; set; }
        //private Semaphore semaphore { get; set; }
        private static Semaphore semaphore { get; set; }
        public string Name { get; set; }
        public string NameCounter { get; set; }
        private int counter { get; set; }
        public bool StopFlag { get; set; }
        public Thread t { get; set; }

        public Work(Semaphore s, int i, Form1 parent)
        {
            Name = $"Thread {i}";
            NameCounter = $"{Name} -> 0";
            counter = 0;
            semaphore = s;
            t = new Thread(Count);
            t.IsBackground = true;
            _parent = parent;
            StopFlag = false;
        }

        private void Count(object obj)
        {
            _parent.ThreadsInQueue.Invoke(delegate
            {
                _parent.ThreadsInQueue.Items.Add(Name);
            });
            try
            {
                semaphore.WaitOne();
                _parent.ThreadsInQueue.Invoke(delegate
                {
                    int qIndex = _parent.ThreadsInQueue.Items.IndexOf(Name);
                    if (qIndex >= 0) _parent.ThreadsInQueue.Items.RemoveAt(qIndex);
                });
                int i = -1;
                while (true)
                {
                    if (StopFlag) break;
                    counter++;
                    NameCounter = $"{Name} -> {counter}";
                    _parent.WorkingThreads.Invoke(delegate
                    {
                        if (counter == 1) _parent.WorkingThreads.Items.Add(NameCounter);
                        i = _parent.WorkingThreads.Items.IndexOf($"{Name} -> {counter - 1}");
                        if (i != null && i >= 0)
                        {
                            _parent.WorkingThreads.Items[i] = NameCounter;
                        }
                    });
                    Thread.Sleep(1000);
                }
            }
            finally
            {
                _parent.WorkingThreads.Invoke(delegate
                {
                    _parent.WorkingThreads.Items.RemoveAt(_parent.WorkingThreads.Items.IndexOf(NameCounter));
                });
                semaphore.Release();
            }
        }

        //public void ChangeSemaphore(Semaphore semaphore)
        //{
        //    this.semaphore = semaphore;
        //    if(_parent == null) return;
        //    _parent.ThreadsInQueue.Invoke(delegate
        //    {
        //        _parent.ThreadsInQueue.Items.Clear();
        //    });
        //}

        public static void ChangeSemaphore(Semaphore semaphore)
        {
            Work.semaphore = semaphore;
            if (_parent == null) return;
            _parent.ThreadsInQueue.Invoke(delegate
            {
                _parent.ThreadsInQueue.Items.Clear();
            });
        }
    }
}
