namespace IsoblocApp
{
    partial class App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            mainLayout = new TableLayoutPanel();
            titlePanel = new Panel();
            darkModeButton = new Button();
            titleLabel = new Label();
            gridLayout = new TableLayoutPanel();
            resultPanel = new Panel();
            resultDataGridView = new DataGridView();
            resultExportButton = new Button();
            projectPanel = new Panel();
            projectDataGridView = new DataGridView();
            projectNameLabel = new Label();
            projectFileLabel = new Label();
            projectCloseButton = new Button();
            projectImportButton = new Button();
            projectCalculateButton = new Button();
            renderPanel = new Panel();
            renderTableLayoutPanel = new TableLayoutPanel();
            renderWestPictureBox = new PictureBox();
            renderSouthPictureBox = new PictureBox();
            renderEastPictureBox = new PictureBox();
            renderNorthPictureBox = new PictureBox();
            blocPanel = new Panel();
            blocAjouterButton = new Button();
            blocDataGridView = new DataGridView();
            mainLayout.SuspendLayout();
            titlePanel.SuspendLayout();
            gridLayout.SuspendLayout();
            resultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resultDataGridView).BeginInit();
            projectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)projectDataGridView).BeginInit();
            renderPanel.SuspendLayout();
            renderTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)renderWestPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)renderSouthPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)renderEastPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)renderNorthPictureBox).BeginInit();
            blocPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)blocDataGridView).BeginInit();
            SuspendLayout();
            // 
            // mainLayout
            // 
            resources.ApplyResources(mainLayout, "mainLayout");
            mainLayout.Controls.Add(titlePanel, 0, 0);
            mainLayout.Controls.Add(gridLayout, 0, 1);
            mainLayout.Name = "mainLayout";
            // 
            // titlePanel
            // 
            titlePanel.Controls.Add(darkModeButton);
            titlePanel.Controls.Add(titleLabel);
            resources.ApplyResources(titlePanel, "titlePanel");
            titlePanel.Name = "titlePanel";
            // 
            // darkModeButton
            // 
            resources.ApplyResources(darkModeButton, "darkModeButton");
            darkModeButton.Name = "darkModeButton";
            darkModeButton.UseVisualStyleBackColor = true;
            darkModeButton.Click += DarkModeButton_Click;
            // 
            // titleLabel
            // 
            resources.ApplyResources(titleLabel, "titleLabel");
            titleLabel.Name = "titleLabel";
            titleLabel.Tag = "first-text";
            // 
            // gridLayout
            // 
            resources.ApplyResources(gridLayout, "gridLayout");
            gridLayout.Controls.Add(resultPanel, 1, 1);
            gridLayout.Controls.Add(projectPanel, 0, 0);
            gridLayout.Controls.Add(renderPanel, 1, 0);
            gridLayout.Controls.Add(blocPanel, 0, 1);
            gridLayout.Name = "gridLayout";
            // 
            // resultPanel
            // 
            resultPanel.Controls.Add(resultDataGridView);
            resultPanel.Controls.Add(resultExportButton);
            resources.ApplyResources(resultPanel, "resultPanel");
            resultPanel.Name = "resultPanel";
            resultPanel.Tag = "section";
            // 
            // resultDataGridView
            // 
            resources.ApplyResources(resultDataGridView, "resultDataGridView");
            resultDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultDataGridView.BorderStyle = BorderStyle.None;
            resultDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultDataGridView.MultiSelect = false;
            resultDataGridView.Name = "resultDataGridView";
            resultDataGridView.DataError += DataGridView_DataError;
            // 
            // resultExportButton
            // 
            resources.ApplyResources(resultExportButton, "resultExportButton");
            resultExportButton.Name = "resultExportButton";
            resultExportButton.UseVisualStyleBackColor = true;
            resultExportButton.Click += ResultExportButton_Click;
            // 
            // projectPanel
            // 
            projectPanel.Controls.Add(projectDataGridView);
            projectPanel.Controls.Add(projectNameLabel);
            projectPanel.Controls.Add(projectFileLabel);
            projectPanel.Controls.Add(projectCloseButton);
            projectPanel.Controls.Add(projectImportButton);
            projectPanel.Controls.Add(projectCalculateButton);
            resources.ApplyResources(projectPanel, "projectPanel");
            projectPanel.Name = "projectPanel";
            projectPanel.Tag = "section";
            // 
            // projectDataGridView
            // 
            resources.ApplyResources(projectDataGridView, "projectDataGridView");
            projectDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            projectDataGridView.BorderStyle = BorderStyle.None;
            projectDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            projectDataGridView.MultiSelect = false;
            projectDataGridView.Name = "projectDataGridView";
            projectDataGridView.CellContentClick += ProjectDataGridView_CellContentClick;
            projectDataGridView.CellValueChanged += ProjectDataGridView_CellValueChanged;
            projectDataGridView.DataError += DataGridView_DataError;
            // 
            // projectNameLabel
            // 
            resources.ApplyResources(projectNameLabel, "projectNameLabel");
            projectNameLabel.Name = "projectNameLabel";
            projectNameLabel.Tag = "first-text";
            // 
            // projectFileLabel
            // 
            resources.ApplyResources(projectFileLabel, "projectFileLabel");
            projectFileLabel.Name = "projectFileLabel";
            projectFileLabel.Tag = "first-text";
            // 
            // projectCloseButton
            // 
            resources.ApplyResources(projectCloseButton, "projectCloseButton");
            projectCloseButton.Name = "projectCloseButton";
            projectCloseButton.UseVisualStyleBackColor = true;
            projectCloseButton.Click += ProjectCloseButton_Click;
            // 
            // projectImportButton
            // 
            resources.ApplyResources(projectImportButton, "projectImportButton");
            projectImportButton.Name = "projectImportButton";
            projectImportButton.UseVisualStyleBackColor = true;
            projectImportButton.Click += ProjectImportButton_Click;
            // 
            // projectCalculateButton
            // 
            resources.ApplyResources(projectCalculateButton, "projectCalculateButton");
            projectCalculateButton.Name = "projectCalculateButton";
            projectCalculateButton.UseVisualStyleBackColor = true;
            // 
            // renderPanel
            // 
            renderPanel.Controls.Add(renderTableLayoutPanel);
            resources.ApplyResources(renderPanel, "renderPanel");
            renderPanel.Name = "renderPanel";
            renderPanel.Tag = "section";
            // 
            // renderTableLayoutPanel
            // 
            resources.ApplyResources(renderTableLayoutPanel, "renderTableLayoutPanel");
            renderTableLayoutPanel.Controls.Add(renderWestPictureBox, 1, 1);
            renderTableLayoutPanel.Controls.Add(renderSouthPictureBox, 0, 1);
            renderTableLayoutPanel.Controls.Add(renderEastPictureBox, 1, 0);
            renderTableLayoutPanel.Controls.Add(renderNorthPictureBox, 0, 0);
            renderTableLayoutPanel.Name = "renderTableLayoutPanel";
            // 
            // renderWestPictureBox
            // 
            resources.ApplyResources(renderWestPictureBox, "renderWestPictureBox");
            renderWestPictureBox.Image = Properties.Resources.render;
            renderWestPictureBox.Name = "renderWestPictureBox";
            renderWestPictureBox.TabStop = false;
            renderWestPictureBox.Tag = "render";
            // 
            // renderSouthPictureBox
            // 
            resources.ApplyResources(renderSouthPictureBox, "renderSouthPictureBox");
            renderSouthPictureBox.Image = Properties.Resources.render;
            renderSouthPictureBox.Name = "renderSouthPictureBox";
            renderSouthPictureBox.TabStop = false;
            renderSouthPictureBox.Tag = "render";
            // 
            // renderEastPictureBox
            // 
            resources.ApplyResources(renderEastPictureBox, "renderEastPictureBox");
            renderEastPictureBox.Image = Properties.Resources.render;
            renderEastPictureBox.Name = "renderEastPictureBox";
            renderEastPictureBox.TabStop = false;
            renderEastPictureBox.Tag = "render";
            // 
            // renderNorthPictureBox
            // 
            resources.ApplyResources(renderNorthPictureBox, "renderNorthPictureBox");
            renderNorthPictureBox.Image = Properties.Resources.render;
            renderNorthPictureBox.Name = "renderNorthPictureBox";
            renderNorthPictureBox.TabStop = false;
            renderNorthPictureBox.Tag = "render";
            // 
            // blocPanel
            // 
            blocPanel.Controls.Add(blocAjouterButton);
            blocPanel.Controls.Add(blocDataGridView);
            resources.ApplyResources(blocPanel, "blocPanel");
            blocPanel.Name = "blocPanel";
            blocPanel.Tag = "section";
            // 
            // blocAjouterButton
            // 
            resources.ApplyResources(blocAjouterButton, "blocAjouterButton");
            blocAjouterButton.Name = "blocAjouterButton";
            blocAjouterButton.UseVisualStyleBackColor = true;
            blocAjouterButton.Click += BlocAjouterButton_Click;
            // 
            // blocDataGridView
            // 
            resources.ApplyResources(blocDataGridView, "blocDataGridView");
            blocDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            blocDataGridView.BorderStyle = BorderStyle.None;
            blocDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            blocDataGridView.MultiSelect = false;
            blocDataGridView.Name = "blocDataGridView";
            blocDataGridView.CellContentClick += BlocDataGridView_CellContentClick;
            blocDataGridView.CellValueChanged += BlocDataGridView_CellValueChanged;
            blocDataGridView.CurrentCellDirtyStateChanged += BlocDataGridView_CurrentCellDirtyStateChanged;
            blocDataGridView.DataError += DataGridView_DataError;
            // 
            // App
            // 
            resources.ApplyResources(this, "$this");
            Controls.Add(mainLayout);
            Name = "App";
            Tag = "app";
            WindowState = FormWindowState.Maximized;
            mainLayout.ResumeLayout(false);
            titlePanel.ResumeLayout(false);
            gridLayout.ResumeLayout(false);
            resultPanel.ResumeLayout(false);
            resultPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)resultDataGridView).EndInit();
            projectPanel.ResumeLayout(false);
            projectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)projectDataGridView).EndInit();
            renderPanel.ResumeLayout(false);
            renderTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)renderWestPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)renderSouthPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)renderEastPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)renderNorthPictureBox).EndInit();
            blocPanel.ResumeLayout(false);
            blocPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)blocDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel gridLayout;
        private Panel titlePanel;
        private Panel projectPanel;
        private Panel renderPanel;
        private Panel blocPanel;
        private Label titleLabel;
        private Button projectImportButton;
        private Button projectCloseButton;
        private TableLayoutPanel renderTableLayoutPanel;
        private PictureBox renderWestPictureBox;
        private PictureBox renderSouthPictureBox;
        private PictureBox renderEastPictureBox;
        private PictureBox renderNorthPictureBox;
        private Panel resultPanel;
        private Button resultExportButton;
        internal DataGridView blocDataGridView;
        internal Button darkModeButton;
        internal DataGridView projectDataGridView;
        internal DataGridView resultDataGridView;
        internal Label projectFileLabel;
        internal Label projectNameLabel;
        internal Button projectCalculateButton;
        internal Button blocAjouterButton;
    }
}
