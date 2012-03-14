namespace FLV_Binder_GUI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerButtonsVideos = new System.Windows.Forms.SplitContainer();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.buttonBind = new System.Windows.Forms.Button();
            this.groupBoxAddVideos = new System.Windows.Forms.GroupBox();
            this.buttonFromFile = new System.Windows.Forms.Button();
            this.buttonFromTwitch = new System.Windows.Forms.Button();
            this.splitContainerListboxReorganize = new System.Windows.Forms.SplitContainer();
            this.listBoxVideos = new System.Windows.Forms.ListBox();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.axShockwaveFlashPreview = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerButtonsVideos)).BeginInit();
            this.splitContainerButtonsVideos.Panel1.SuspendLayout();
            this.splitContainerButtonsVideos.Panel2.SuspendLayout();
            this.splitContainerButtonsVideos.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.groupBoxAddVideos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerListboxReorganize)).BeginInit();
            this.splitContainerListboxReorganize.Panel1.SuspendLayout();
            this.splitContainerListboxReorganize.Panel2.SuspendLayout();
            this.splitContainerListboxReorganize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlashPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerButtonsVideos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axShockwaveFlashPreview);
            this.splitContainer1.Size = new System.Drawing.Size(929, 465);
            this.splitContainer1.SplitterDistance = 338;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainerButtonsVideos
            // 
            this.splitContainerButtonsVideos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerButtonsVideos.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerButtonsVideos.IsSplitterFixed = true;
            this.splitContainerButtonsVideos.Location = new System.Drawing.Point(0, 0);
            this.splitContainerButtonsVideos.Name = "splitContainerButtonsVideos";
            this.splitContainerButtonsVideos.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerButtonsVideos.Panel1
            // 
            this.splitContainerButtonsVideos.Panel1.Controls.Add(this.groupBoxActions);
            this.splitContainerButtonsVideos.Panel1.Controls.Add(this.groupBoxAddVideos);
            // 
            // splitContainerButtonsVideos.Panel2
            // 
            this.splitContainerButtonsVideos.Panel2.Controls.Add(this.splitContainerListboxReorganize);
            this.splitContainerButtonsVideos.Size = new System.Drawing.Size(338, 465);
            this.splitContainerButtonsVideos.SplitterDistance = 114;
            this.splitContainerButtonsVideos.TabIndex = 0;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxActions.Controls.Add(this.buttonBind);
            this.groupBoxActions.Location = new System.Drawing.Point(3, 61);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(332, 50);
            this.groupBoxActions.TabIndex = 1;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // buttonBind
            // 
            this.buttonBind.Location = new System.Drawing.Point(10, 20);
            this.buttonBind.Name = "buttonBind";
            this.buttonBind.Size = new System.Drawing.Size(75, 23);
            this.buttonBind.TabIndex = 0;
            this.buttonBind.Text = "Bind!";
            this.buttonBind.UseVisualStyleBackColor = true;
            this.buttonBind.Click += new System.EventHandler(this.buttonBind_Click);
            // 
            // groupBoxAddVideos
            // 
            this.groupBoxAddVideos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAddVideos.Controls.Add(this.buttonFromFile);
            this.groupBoxAddVideos.Controls.Add(this.buttonFromTwitch);
            this.groupBoxAddVideos.Location = new System.Drawing.Point(3, 3);
            this.groupBoxAddVideos.Name = "groupBoxAddVideos";
            this.groupBoxAddVideos.Size = new System.Drawing.Size(332, 52);
            this.groupBoxAddVideos.TabIndex = 0;
            this.groupBoxAddVideos.TabStop = false;
            this.groupBoxAddVideos.Text = "Add Videos";
            // 
            // buttonFromFile
            // 
            this.buttonFromFile.Location = new System.Drawing.Point(9, 19);
            this.buttonFromFile.Name = "buttonFromFile";
            this.buttonFromFile.Size = new System.Drawing.Size(75, 23);
            this.buttonFromFile.TabIndex = 1;
            this.buttonFromFile.Text = "File";
            this.buttonFromFile.UseVisualStyleBackColor = true;
            this.buttonFromFile.Click += new System.EventHandler(this.buttonFromFile_Click);
            // 
            // buttonFromTwitch
            // 
            this.buttonFromTwitch.Location = new System.Drawing.Point(90, 19);
            this.buttonFromTwitch.Name = "buttonFromTwitch";
            this.buttonFromTwitch.Size = new System.Drawing.Size(75, 23);
            this.buttonFromTwitch.TabIndex = 0;
            this.buttonFromTwitch.Text = "TwitchTV";
            this.buttonFromTwitch.UseVisualStyleBackColor = true;
            this.buttonFromTwitch.Click += new System.EventHandler(this.buttonFromTwitch_Click);
            // 
            // splitContainerListboxReorganize
            // 
            this.splitContainerListboxReorganize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerListboxReorganize.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerListboxReorganize.IsSplitterFixed = true;
            this.splitContainerListboxReorganize.Location = new System.Drawing.Point(0, 0);
            this.splitContainerListboxReorganize.Name = "splitContainerListboxReorganize";
            // 
            // splitContainerListboxReorganize.Panel1
            // 
            this.splitContainerListboxReorganize.Panel1.Controls.Add(this.listBoxVideos);
            // 
            // splitContainerListboxReorganize.Panel2
            // 
            this.splitContainerListboxReorganize.Panel2.Controls.Add(this.buttonRandom);
            this.splitContainerListboxReorganize.Panel2.Controls.Add(this.buttonRemove);
            this.splitContainerListboxReorganize.Panel2.Controls.Add(this.buttonDown);
            this.splitContainerListboxReorganize.Panel2.Controls.Add(this.buttonUp);
            this.splitContainerListboxReorganize.Size = new System.Drawing.Size(338, 347);
            this.splitContainerListboxReorganize.SplitterDistance = 280;
            this.splitContainerListboxReorganize.TabIndex = 0;
            // 
            // listBoxVideos
            // 
            this.listBoxVideos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxVideos.FormattingEnabled = true;
            this.listBoxVideos.Location = new System.Drawing.Point(0, 0);
            this.listBoxVideos.Name = "listBoxVideos";
            this.listBoxVideos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxVideos.Size = new System.Drawing.Size(280, 347);
            this.listBoxVideos.TabIndex = 0;
            this.listBoxVideos.SelectedIndexChanged += new System.EventHandler(this.listBoxVideos_SelectedIndexChanged);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(3, 160);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(48, 47);
            this.buttonRandom.TabIndex = 3;
            this.buttonRandom.Text = "Random";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(3, 109);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(48, 45);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(3, 56);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(48, 47);
            this.buttonDown.TabIndex = 1;
            this.buttonDown.Text = "Down";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(3, 3);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(48, 47);
            this.buttonUp.TabIndex = 0;
            this.buttonUp.Text = "Up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // axShockwaveFlashPreview
            // 
            this.axShockwaveFlashPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axShockwaveFlashPreview.Enabled = true;
            this.axShockwaveFlashPreview.Location = new System.Drawing.Point(0, 0);
            this.axShockwaveFlashPreview.Name = "axShockwaveFlashPreview";
            this.axShockwaveFlashPreview.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlashPreview.OcxState")));
            this.axShockwaveFlashPreview.Size = new System.Drawing.Size(587, 465);
            this.axShockwaveFlashPreview.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 465);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "Main";
            this.Text = "Twitch FLV GUI";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerButtonsVideos.Panel1.ResumeLayout(false);
            this.splitContainerButtonsVideos.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerButtonsVideos)).EndInit();
            this.splitContainerButtonsVideos.ResumeLayout(false);
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxAddVideos.ResumeLayout(false);
            this.splitContainerListboxReorganize.Panel1.ResumeLayout(false);
            this.splitContainerListboxReorganize.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerListboxReorganize)).EndInit();
            this.splitContainerListboxReorganize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlashPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainerButtonsVideos;
        private System.Windows.Forms.GroupBox groupBoxAddVideos;
        private System.Windows.Forms.Button buttonFromFile;
        private System.Windows.Forms.Button buttonFromTwitch;
        private System.Windows.Forms.SplitContainer splitContainerListboxReorganize;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button buttonBind;
        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlashPreview;
        private System.Windows.Forms.ListBox listBoxVideos;
        private System.Windows.Forms.Button buttonRandom;
    }
}

