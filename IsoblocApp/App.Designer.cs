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

        private readonly Color blackColor = Color.FromArgb(0x00, 0x00, 0x00);
        private readonly Color buttonColor = Color.FromArgb(0xAC, 0xBA, 0xFF);
        private readonly Color progressColor = Color.FromArgb(0x52, 0xB1, 0xFF);

        private readonly Color darkAppColor = Color.FromArgb(0x1F, 0x1F, 0x1F);
        private readonly Color darkSectionColor = Color.FromArgb(0x38, 0x38, 0x38);
        private readonly Color darkSecondColor = Color.FromArgb(0x94, 0x94, 0x94);
        private readonly Color darkFirstColor = Color.FromArgb(0xF6, 0xF6, 0xF6);

        private readonly Color lightAppColor = Color.FromArgb(0x1F, 0x1F, 0x1F);
        private readonly Color lightSectionColor = Color.FromArgb(0x38, 0x38, 0x38);
        private readonly Color lightSecondColor = Color.FromArgb(0x94, 0x94, 0x94);
        private readonly Color lightFirstColor = Color.FromArgb(0xF6, 0xF6, 0xF6);

        private readonly Color appColor = Color.FromArgb(0x1F, 0x1F, 0x1F);
        private readonly Color sectionColor = Color.FromArgb(0x38, 0x38, 0x38);
        private readonly Color secondColor = Color.FromArgb(0x94, 0x94, 0x94);
        private readonly Color firstColor = Color.FromArgb(0xF6, 0xF6, 0xF6);

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            mainLayout = new TableLayoutPanel();
            gridLayout = new TableLayoutPanel();
            titlePanel = new Panel();
            projectPanel = new Panel();
            renderPanel = new Panel();
            blocsPanel = new Panel();
            resultPanel = new Panel();
            // 
            // mainLayout
            // 
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.ColumnCount = 1;
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(this.titlePanel, 0, 0);
            mainLayout.Controls.Add(this.gridLayout, 0, 1);
            // 
            // gridLayout
            // 
            gridLayout.Dock = DockStyle.Fill;
            gridLayout.ColumnCount = 2;
            gridLayout.RowCount = 2;
            gridLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gridLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gridLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            gridLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            resources.ApplyResources(gridLayout, "tableLayoutPanel");
            gridLayout.Controls.Add(projectPanel, 0, 0);
            gridLayout.Controls.Add(renderPanel, 1, 0);
            gridLayout.Controls.Add(blocsPanel, 0, 1);
            gridLayout.Controls.Add(resultPanel, 1, 1);
            // 
            // titlePanel
            // 
            titlePanel.Dock = DockStyle.Fill;
            resources.ApplyResources(titlePanel, "titlePanel");
            // 
            // projectPanel
            // 
            projectPanel.Dock = DockStyle.Fill;
            projectPanel.BackColor = sectionColor;
            resources.ApplyResources(projectPanel, "projectPanel");
            // 
            // renderPanel
            // 
            renderPanel.Dock = DockStyle.Fill;
            renderPanel.BackColor = sectionColor;
            resources.ApplyResources(renderPanel, "renderPanel");
            // 
            // blocsPanel
            // 
            blocsPanel.Dock = DockStyle.Fill;
            blocsPanel.BackColor = sectionColor;
            resources.ApplyResources(blocsPanel, "blocsPanel");
            // 
            // resultPanel
            // 
            resultPanel.Dock = DockStyle.Fill;
            resultPanel.BackColor = sectionColor;
            resources.ApplyResources(resultPanel, "resultPanel");
            // 
            // App
            // 
            BackColor = appColor;
            resources.ApplyResources(this, "$this");
            Controls.Add(mainLayout);
            WindowState = FormWindowState.Maximized;
            Load += App_Load_1;
            mainLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel gridLayout;
        private Panel titlePanel;
        private Panel projectPanel;
        private Panel renderPanel;
        private Panel blocsPanel;
        private Panel resultPanel;
    }
}
