using IsoblocApp.Extensions;
using IsoblocApp.Models;
using Microsoft.VisualBasic;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IsoblocApp;

public partial class App : Form
{
    private bool isDarkTheme = true;

    private readonly List<Bloc> blocCollection = BlocExtension.ReadFromFile();
    private readonly List<Project> projectCollection = ProjectExtension.ReadFromFile();

    private Project? currentProject = null;

    private readonly DataTable blocTable = new("Blocs");
    private readonly DataTable projectTable = new("Projets");
    private readonly DataTable resultTable = new("Resultats");

    private readonly Color blackColor = Color.FromArgb(0x00, 0x00, 0x00);
    private readonly Color whiteColor = Color.FromArgb(0xFF, 0xFF, 0xFF);
    private readonly Color buttonColor = Color.FromArgb(0xAC, 0xBA, 0xFF);
    private readonly Color progressColor = Color.FromArgb(0x52, 0xB1, 0xFF);
    private readonly Color renderColor = Color.FromArgb(0x35, 0x35, 0x35);

    private readonly Color darkAppColor = Color.FromArgb(0x1F, 0x1F, 0x1F);
    private readonly Color darkSectionColor = Color.FromArgb(0x38, 0x38, 0x38);
    private readonly Color darkSecondColor = Color.FromArgb(0x94, 0x94, 0x94);
    private readonly Color darkFirstColor = Color.FromArgb(0xF6, 0xF6, 0xF6);

    private readonly Color lightAppColor = Color.FromArgb(0xF6, 0xF6, 0xF6);
    private readonly Color lightSectionColor = Color.FromArgb(0xE8, 0xE8, 0xE8);
    private readonly Color lightSecondColor = Color.FromArgb(0x38, 0x38, 0x38);
    private readonly Color lightFirstColor = Color.FromArgb(0x1F, 0x1F, 0x1F);

    private Color AppColor { get => isDarkTheme ? darkAppColor : lightAppColor; }
    private Color SectionColor { get => isDarkTheme ? darkSectionColor : lightSectionColor; }
    private Color SecondColor { get => isDarkTheme ? darkSecondColor : lightSecondColor; }
    private Color FirstColor { get => isDarkTheme ? darkFirstColor : lightFirstColor; }

    public App()
    {
        InitializeComponent();
        InitializeProjectTable();
        InitializeBlocTable();
        InitializeResultTable();
        InitializeElements();
        UpdateCurrentProject();
        UpdateProjectTableRows();
        UpdateBlocTableRows();
        ApplyTheme();
    }

    private void InitializeProjectTable()
    {
        DataGridViewButtonColumn selectColumn = new()
        {
            Name = "SELECT",
            HeaderText = "",
            Text = "\u2714",
            UseColumnTextForButtonValue = true,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        };

        DataGridViewButtonColumn deleteColumn = new()
        {
            Name = "DELETE",
            HeaderText = "",
            Text = "\u2716",
            UseColumnTextForButtonValue = true,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        };

        projectTable.Columns.Add("NOM", typeof(string));
        projectTable.Columns.Add("FICHIER", typeof(string));
        projectTable.Columns.Add("DATE", typeof(string));
        projectTable.Columns.Add("RENDU", typeof(string));

        projectDataGridView.Columns.Add(selectColumn);
        projectDataGridView.DataSource = projectTable;
        projectDataGridView.Columns.Add(deleteColumn);

        projectDataGridView.Columns["FICHIER"].ReadOnly = true;
        projectDataGridView.Columns["DATE"].ReadOnly = true;
        projectDataGridView.Columns["RENDU"].ReadOnly = true;
    }

    private void InitializeBlocTable()
    {
        blocTable.Columns.Add("CHECKBOX", typeof(bool));
        blocTable.Columns.Add("TYPE", typeof(string));
        blocTable.Columns.Add("LONGUEUR", typeof(int));
        blocTable.Columns.Add("HAUTEUR", typeof(int));
        blocTable.Columns.Add("EPAISSEUR", typeof(int));
        blocTable.Columns.Add("RESERVATION", typeof(string));

        DataGridViewButtonColumn deleteColumn = new()
        {
            Name = "DELETE",
            HeaderText = "",
            Text = "\u2716",
            UseColumnTextForButtonValue = true,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        };

        blocDataGridView.DataSource = blocTable;
        blocDataGridView.Columns.Add(deleteColumn);

        var checkboxColumn = blocDataGridView.Columns["CHECKBOX"];
        checkboxColumn.HeaderText = "";
        checkboxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    }

    private void InitializeResultTable()
    {
        resultTable.Columns.Add("TYPE", typeof(string));
        resultTable.Columns.Add("LONGUEUR", typeof(int));
        resultTable.Columns.Add("HAUTEUR", typeof(int));
        resultTable.Columns.Add("EPAISSEUR", typeof(int));
        resultTable.Columns.Add("RESERVATION", typeof(string));
        resultTable.Columns.Add("QUANTITE", typeof(int));

        resultDataGridView.DataSource = resultTable;
        resultDataGridView.ReadOnly = true;
    }

    private void InitializeElements()
    {
        foreach (Control control in GetAllControls(this))
        {
            if (control is Button btn)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = buttonColor;
                btn.ForeColor = blackColor;
            }
            else if (control is DataGridView dgv)
            {
                // Structure et bordures
                dgv.BorderStyle = BorderStyle.None;
                dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgv.RowTemplate.Height = 30;
                dgv.RowHeadersVisible = false;

                // En-tête de colonnes
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersHeight = 40;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Style des cellules
                dgv.DefaultCellStyle.Padding = new Padding(10, 3, 10, 3);
                dgv.DefaultCellStyle.BackColor = whiteColor;
                dgv.DefaultCellStyle.ForeColor = blackColor;
                dgv.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                // Comportement utilisateur
                dgv.AllowUserToResizeRows = false;
                dgv.AllowUserToAddRows = false;
            }
        }
    }

    private void UpdateBlocCollection()
    {
        blocCollection.Clear();

        foreach (DataRow row in blocTable.Rows)
        {
            if (row.RowState != DataRowState.Deleted)
            {
                blocCollection.Add(new Bloc
                {
                    Checked = (bool)row["CHECKBOX"],
                    Type = (string)row["TYPE"],
                    Longueur = (int)row["LONGUEUR"],
                    Hauteur = (int)row["HAUTEUR"],
                    Epaisseur = (int)row["EPAISSEUR"],
                    Reservation = (string)row["RESERVATION"]
                });
            }
        }

        blocCollection.WriteToFile();
    }

    private void UpdateCurrentProject()
    {
        projectNameLabel.Text = currentProject?.Name.ToUpper() ?? string.Empty;
        projectFileLabel.Text = currentProject?.Filepath ?? string.Empty;
        projectCloseButton.Visible = currentProject != null;
        projectCalculateButton.Visible = currentProject != null;
        resultExportButton.Visible = currentProject?.Results != null;

        UpdateResultTableRows();
    }

    private void UpdateProjectTableRows()
    {
        projectTable.Rows.Clear();

        foreach (var project in projectCollection)
        {
            projectTable.Rows.Add(project.Name, Path.GetFileName(project.Filepath), project.Date.ToString(), project.Results == null ? "" : $"{project.TotalBlocAmount} BLOCS ({project.StandardBlocAmount} STAND. / {project.SpecialBlocAmount} SPE.)");
        }
    }

    private void UpdateBlocTableRows()
    {
        blocTable.Rows.Clear();

        foreach (var bloc in blocCollection)
        {
            blocTable.Rows.Add(bloc.Checked, bloc.Type, bloc.Longueur, bloc.Hauteur, bloc.Epaisseur, bloc.Reservation);
        }
    }

    private void UpdateResultTableRows()
    {
        resultTable.Rows.Clear();

        foreach (var result in currentProject?.Results ?? [])
        {
            resultTable.Rows.Add(result.Bloc.Type, result.Bloc.Longueur, result.Bloc.Hauteur, result.Bloc.Epaisseur, result.Bloc.Reservation, result.Quantite);
        }
    }

    private void ApplyTheme()
    {
        darkModeButton.Text = isDarkTheme ? "DARK" : "LIGHT";

        foreach (Control control in GetAllControls(this))
        {
            switch (control.Tag?.ToString())
            {
                case "app":
                    control.BackColor = AppColor;
                    break;
                case "section":
                    control.BackColor = SectionColor;
                    break;
                case "first":
                    control.BackColor = FirstColor;
                    break;
                case "first-text":
                    control.ForeColor = FirstColor;
                    break;
                case "second":
                    control.BackColor = SecondColor;
                    break;
                case "second-text":
                    control.ForeColor = SecondColor;
                    break;
                case "cell":
                    control.BackColor = whiteColor;
                    control.ForeColor = blackColor;
                    break;
                case "render":
                    control.BackColor = renderColor;
                    break;
            }

            if (control is DataGridView dataGridView)
            {
                dataGridView.BackgroundColor = SectionColor;
                dataGridView.ColumnHeadersDefaultCellStyle.BackColor = SectionColor;
                dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = SecondColor;
                dataGridView.RowHeadersDefaultCellStyle.BackColor = SectionColor;
                dataGridView.RowHeadersDefaultCellStyle.ForeColor = SecondColor;
                dataGridView.GridColor = SectionColor;
            }
        }
    }

    private static IEnumerable<Control> GetAllControls(Control parent)
    {
        yield return parent;

        foreach (Control child in parent.Controls)
        {
            foreach (var descendant in GetAllControls(child))
            {
                yield return descendant;
            }
        }
    }

    private void BlocDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (blocDataGridView.IsCurrentCellDirty)
        {
            blocDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }

    private void ProjectDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= projectDataGridView.Rows.Count ||
            e.ColumnIndex < 0 || e.ColumnIndex >= projectDataGridView.Columns.Count)
            return;

        var project = projectCollection[e.RowIndex];
        project.Name = projectDataGridView.Rows[e.RowIndex].Cells["NOM"].Value?.ToString() ?? "";

        UpdateCurrentProject();
        projectCollection.WriteToFile();
    }

    private void BlocDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= blocDataGridView.Rows.Count ||
            e.ColumnIndex < 0 || e.ColumnIndex >= blocDataGridView.Columns.Count)
            return;

        UpdateBlocCollection();
    }

    private void ProjectDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= projectDataGridView.Rows.Count ||
            e.ColumnIndex < 0 || e.ColumnIndex >= projectDataGridView.Columns.Count)
            return;

        if (e.ColumnIndex == 0)
        {
            currentProject = projectCollection[e.RowIndex];
            UpdateCurrentProject();
        }
        else if (e.ColumnIndex == 1)
        {
            if (MessageBox.Show($"Êtes-vous sûr de vouloir supprimer le projet '{projectCollection[e.RowIndex].Name}' ?", "Supprimer un projet", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                projectTable.Rows[e.RowIndex].Delete();
                UpdateCurrentProject();
                projectCollection.RemoveAt(e.RowIndex);
                projectCollection.WriteToFile();
            }
        }
    }

    private void BlocDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= blocDataGridView.Rows.Count ||
            e.ColumnIndex < 0 || e.ColumnIndex >= blocDataGridView.Columns.Count)
            return;

        if (e.RowIndex < blocCollection.Count && e.ColumnIndex == 0)
        {
            if (MessageBox.Show($"Êtes-vous sûr de vouloir supprimer le bloc '{blocCollection[e.RowIndex].Type}' ?", "Supprimer un bloc", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                blocTable.Rows[e.RowIndex].Delete();
                blocCollection.RemoveAt(e.RowIndex);
                blocCollection.WriteToFile();
            }
        }
    }

    private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        e.ThrowException = false;

        MessageBox.Show(
            $"Une erreur de format s'est produite\nVeuillez vérifier votre saisie\n\n{e.Exception?.Message}",
            "Erreur",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );
    }

    private void DarkModeButton_Click(object sender, EventArgs e)
    {
        isDarkTheme = !isDarkTheme;
        ApplyTheme();
    }

    private void ProjectImportButton_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new()
        {
            Title = "Choisir un fichier",
            Filter = "Tous les fichiers (*.dwg)|*.dwg",
            DefaultExt = "dwg"
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openFileDialog.FileName;


            projectCollection.Add(new Project
            {
                Name = Path.GetFileNameWithoutExtension(filePath),
                Filepath = filePath,
                Date = DateTime.Now,
                Results = null
            });
            UpdateProjectTableRows();
            UpdateCurrentProject();
            projectCollection.WriteToFile();
        }
    }

    private void ProjectCloseButton_Click(object sender, EventArgs e)
    {
        currentProject = null;
        UpdateCurrentProject();
    }

    private void ResultExportButton_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog = new()
        {
            Filter = "Fichier CSV (*.csv)|*.csv",
            DefaultExt = "csv"
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string csvFile = saveFileDialog.FileName;

            try
            {
                using var writer = new StreamWriter(csvFile);
                writer.WriteLine("Type;Longueur;Hauteur;Epaisseur;Reservation,Quantite");

                foreach (var result in currentProject?.Results ?? [])
                {
                    var line = $"{result.Bloc.Type.ToLower()};{result.Bloc.Longueur};{result.Bloc.Hauteur};{result.Bloc.Epaisseur};{result.Bloc.Reservation.ToLower()};{result.Quantite}";
                    writer.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BlocAjouterButton_Click(object sender, EventArgs e)
    {
        string nom = Interaction.InputBox("Veuillez saisir le nom du bloc:", "Ajouter un bloc").ToUpper();
        string pattern = @"^[A-Za-z]\d{2}$";

        if (nom == "")
        {
            return;
        }

        if (!Regex.IsMatch(nom, pattern))
        {
            MessageBox.Show(
                $"Erreur: le nom du bloc doit être au format 'B01'\nVeuillez réessayer",
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        else if (blocCollection.Select(b => b.Type).Contains(nom))
        {
            MessageBox.Show(
                $"Erreur: le bloc existe déjà dans la liste\nVeuillez réessayer",
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        else
        {
            blocTable.Rows.Add(false, nom, 0, 0, 0, "");
            UpdateBlocCollection();
        }
    }
}
