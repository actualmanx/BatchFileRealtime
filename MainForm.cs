using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Text;
using System.Collections.Generic;
using Utility.ModifyRegistry;

namespace Bat_launcher
{
	/// <summary>
	/// A simple form to launch a process using ProcessCaller
	/// and display all StdOut and StdErr in a RichTextBox.
	/// </summary>
	/// <remarks>
    /// Special thanks to Chad Christensen for suggestions
    /// on using the RichTextBox.
    /// Note there are a lot of issues with scrolling on a
    /// RichTextBox, depending upon if the cursor (selection point) 
    /// is in the RichTextBox or not, and if it is hidden or not.
    /// I've disabled the RichTextBox tabstop so that the cursor isn't
    /// automatically placed in the text box.
    /// Now setting or unsetting:
    ///    richTextBox1.HideSelection
    /// will affect if the textbox is always repositioned at the bottom
    ///   when new text is entered.
	/// </remarks>
    public class AceNewzForm : System.Windows.Forms.Form
    { 
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        // Note: richtext box can hold much longer text than a plain textbox.
        private System.Windows.Forms.RichTextBox RichTextBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem OpenFileToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel fileStripStatusLabel1;
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
         
        /// <summary>
        /// Default constructor
        /// </summary>
        public AceNewzForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            /* old way - reading from a config file now we use registry
            fileStripStatusLabel1.Text = System.Configuration.ConfigurationManager.AppSettings["FileLocation"]; */
            fileStripStatusLabel1.Text = myRegistry.Read("File Location");
        }
        ModifyRegistry myRegistry = new ModifyRegistry();
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

		#region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AceNewzForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.fileStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Location = new System.Drawing.Point(417, 277);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&Start";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(336, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.RichTextBox1.HideSelection = false;
            this.RichTextBox1.Location = new System.Drawing.Point(12, 27);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.ReadOnly = true;
            this.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RichTextBox1.Size = new System.Drawing.Size(480, 237);
            this.RichTextBox1.TabIndex = 0;
            this.RichTextBox1.TabStop = false;
            this.RichTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(504, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileToolStripMenuItem.Image")));
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.OpenFileToolStripMenuItem.Text = "Open File";
            this.OpenFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Bat files (*.bat)|*.bat|All files (*.*)|*.*";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 310);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(504, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // fileStripStatusLabel1
            // 
            this.fileStripStatusLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.fileStripStatusLabel1.Name = "fileStripStatusLabel1";
            this.fileStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // AceNewzForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(504, 332);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AceNewzForm";
            this.Text = "Bat Launcher";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private ProcessCaller processCaller;

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                this.btnOk.Enabled = false;
                string directoryName = Path.GetDirectoryName(fileStripStatusLabel1.Text);
                // Environment.CurrentDirectory = @"D:/xampp/htdocs/nnplus/misc/update_scripts/win_scripts/";
                Environment.CurrentDirectory = directoryName;
                processCaller = new ProcessCaller(this) { FileName = fileStripStatusLabel1.Text, Arguments = "" };
                processCaller.StdErrReceived += new DataReceivedHandler(writeStreamInfo);
                processCaller.StdOutReceived += new DataReceivedHandler(writeStreamInfo);
                processCaller.Completed += new EventHandler(processCompletedOrCanceled);
                processCaller.Cancelled += new EventHandler(processCompletedOrCanceled);
                // processCaller.Failed += no event handler for this one, yet.
                this.RichTextBox1.Text = "Started Process.  Please stand by.." + Environment.NewLine;
                // the following function starts a process and returns immediately,
                // thus allowing the form to stay responsive.
                processCaller.Start();
            }

            catch (DirectoryNotFoundException)
            {
                this.RichTextBox1.Text = "Error: The directory specified could not be found.";

            }
            catch (IOException)
            {
                this.RichTextBox1.Text = "Error: A file in the directory could not be accessed.";

            }
            catch (ArgumentNullException)
            {
                this.RichTextBox1.Text = "Error: The argument cannot be null or empty.";
            }

        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (processCaller != null)
            {
                processCaller.Cancel();
            }
        }

        /// <summary>
        /// Handles the events of StdErrReceived and StdOutReceived.
        /// </summary>
        /// <remarks>
        /// If stderr were handled in a separate function, it could possibly
        /// be displayed in red in the richText box, but that is beyond 
        /// the scope of this demo.
        /// </remarks>
        private void writeStreamInfo(object sender, DataReceivedEventArgs e)
        {
            this.RichTextBox1.AppendText(e.Text + Environment.NewLine);
        }

        
        
        private void processCompletedOrCanceled(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.btnOk.Enabled = true;
        }


        [STAThread]
        static void Main(string[] args)         
        {
            Application.Run(new AceNewzForm());

 

            
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                myRegistry.Write("File Location", openFileDialog1.FileName);
                fileStripStatusLabel1.Text = myRegistry.Read("File Location");
                /*      old way to save to config file
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //remove old file file location
                config.AppSettings.Settings.Remove("FileLocation");
                //save the old location gone
                config.Save(ConfigurationSaveMode.Modified);
                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");

                // Add an Application Setting.
                config.AppSettings.Settings.Add("FileLocation", openFileDialog1.FileName);

                // Save the changes in App.config file.
                config.Save(ConfigurationSaveMode.Modified);

                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");
                fileStripStatusLabel1.Text = System.Configuration.ConfigurationManager.AppSettings["FileLocation"];*/
            }
                
                
            }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RichTextBox1.Text = "This tool can be used to open batch files and display the output in the screen.\nThe file selected will be kept for future use.\nSome of the code used in this program is from codeprojects.\nhttp://www.codeproject.com/Articles/4665/Launching-a-process-and-displaying-its-standard-ou\nRead and Write to the Registry\nhttps://www.codeproject.com/Articles/3389/Read-write-and-delete-from-registry-with-C";
        }
        }

    }

