namespace SemaphoreAndThreads
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CreatedThreads = new ListBox();
            ThreadsInQueue = new ListBox();
            WorkingThreads = new ListBox();
            CreateThread = new Button();
            SemaphoreCapacity = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)SemaphoreCapacity).BeginInit();
            SuspendLayout();
            // 
            // CreatedThreads
            // 
            CreatedThreads.FormattingEnabled = true;
            CreatedThreads.ItemHeight = 15;
            CreatedThreads.Location = new Point(169, 42);
            CreatedThreads.Name = "CreatedThreads";
            CreatedThreads.Size = new Size(105, 244);
            CreatedThreads.TabIndex = 0;
            CreatedThreads.DoubleClick += StartThread;
            // 
            // ThreadsInQueue
            // 
            ThreadsInQueue.FormattingEnabled = true;
            ThreadsInQueue.ItemHeight = 15;
            ThreadsInQueue.Location = new Point(280, 42);
            ThreadsInQueue.Name = "ThreadsInQueue";
            ThreadsInQueue.Size = new Size(105, 244);
            ThreadsInQueue.TabIndex = 1;
            // 
            // WorkingThreads
            // 
            WorkingThreads.FormattingEnabled = true;
            WorkingThreads.ItemHeight = 15;
            WorkingThreads.Location = new Point(390, 42);
            WorkingThreads.Name = "WorkingThreads";
            WorkingThreads.Size = new Size(105, 244);
            WorkingThreads.TabIndex = 2;
            WorkingThreads.DoubleClick += StopThread;
            // 
            // CreateThread
            // 
            CreateThread.Location = new Point(12, 16);
            CreateThread.Name = "CreateThread";
            CreateThread.Size = new Size(108, 23);
            CreateThread.TabIndex = 3;
            CreateThread.Text = "Add a thread";
            CreateThread.UseVisualStyleBackColor = true;
            CreateThread.Click += AddThread;
            // 
            // SemaphoreCapacity
            // 
            SemaphoreCapacity.Location = new Point(12, 74);
            SemaphoreCapacity.Name = "SemaphoreCapacity";
            SemaphoreCapacity.Size = new Size(108, 23);
            SemaphoreCapacity.TabIndex = 4;
            SemaphoreCapacity.ValueChanged += SemaphoreResize;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 56);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 5;
            label1.Text = "Max semaphore capacity:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(169, 16);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 6;
            label2.Text = "Threads created:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(280, 16);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 7;
            label3.Text = "Threads in queue:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(390, 16);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 8;
            label4.Text = "Working threads:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(543, 298);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SemaphoreCapacity);
            Controls.Add(CreateThread);
            Controls.Add(WorkingThreads);
            Controls.Add(ThreadsInQueue);
            Controls.Add(CreatedThreads);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)SemaphoreCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ListBox CreatedThreads;
        public ListBox ThreadsInQueue;
        public ListBox WorkingThreads;
        private Button CreateThread;
        private NumericUpDown SemaphoreCapacity;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}