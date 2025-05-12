using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

public class PdfHelper
{
    /// <summary>
    /// Открывает выбранный пользователем PDF-файл
    /// </summary>
    public  void OpenPdf(string filePath)
    {
        if (File.Exists(filePath))
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть файл:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show($"Файл не найден:\n{filePath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}


