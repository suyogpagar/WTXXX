using System;
using System.IO;
using System.Windows.Forms;

public class FileHandler : Form
{
    private TextBox textBox;
    private Button openButton, saveButton, closeButton;
    private OpenFileDialog openFileDialog;
    private SaveFileDialog saveFileDialog;
    private string currentFilePath;

    public FileHandler()
    {
        textBox = new TextBox { Multiline = true, Dock = DockStyle.Fill };
        openButton = new Button { Text = "Open File" };
        saveButton = new Button { Text = "Save File" };
        closeButton = new Button { Text = "Close File" };

        openFileDialog = new OpenFileDialog();
        saveFileDialog = new SaveFileDialog();

        openButton.Click += OpenFile;
        saveButton.Click += SaveFile;
        closeButton.Click += CloseFile;

        var panel = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true };
        panel.Controls.Add(openButton);
        panel.Controls.Add(saveButton);
        panel.Controls.Add(closeButton);

        Controls.Add(panel);
        Controls.Add(textBox);
    }

    private void OpenFile(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            currentFilePath = openFileDialog.FileName;
            textBox.Text = File.ReadAllText(currentFilePath);
        }
    }

    private void SaveFile(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(currentFilePath))
        {
            File.WriteAllText(currentFilePath, textBox.Text);
        }
        else if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            currentFilePath = saveFileDialog.FileName;
            File.WriteAllText(currentFilePath, textBox.Text);
        }
    }

    private void CloseFile(object sender, EventArgs e)
    {
        textBox.Clear();
        currentFilePath = null;
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new FileHandler());
    }
}

