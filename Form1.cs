using System;
using System.IO;
using System.Windows.Forms;

namespace SaveFTLCorrectly
{
    public partial class Form1 : Form
    {


        private static string FTLFolder = @"B:\Program Files (x86)\Steam\steamapps\common\FTL Faster Than Light\";
        private static string FTLBackUpFolder = @"B:\Program Files (x86)\Steam\steamapps\common\FTL Backup Folder\";




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(FTLBackUpFolder))
            {
                Directory.CreateDirectory(FTLBackUpFolder);
            }

        }

        private void button1_Click(object sender, EventArgs e)//save game
        {
            if (!Directory.Exists(FTLBackUpFolder))
            {
                Directory.CreateDirectory(FTLBackUpFolder);
            }

            string[] directoriesInSourceDirectory = Directory.GetDirectories(FTLFolder);
            string[] filesInSourceDirectory = Directory.GetFiles(FTLFolder);

            foreach (string directory in directoriesInSourceDirectory)
            {
                try
                {
                    string directoryNameOnly = Path.GetDirectoryName(directory);
                    if (!Directory.Exists(FTLBackUpFolder + directoryNameOnly))
                    {
                        Directory.CreateDirectory(FTLBackUpFolder + directoryNameOnly);
                    }
                    else
                    {
                        Directory.Delete(FTLBackUpFolder + directoryNameOnly);
                        Directory.CreateDirectory(FTLBackUpFolder + directoryNameOnly);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                foreach (string file in filesInSourceDirectory)
                {
                    try
                    {
                        string fileNameOnly = Path.GetDirectoryName(directory);

                        if (!File.Exists(FTLBackUpFolder + fileNameOnly))
                        {
                            File.Copy(FTLFolder, FTLBackUpFolder + fileNameOnly);
                        }
                        else
                        {
                            File.Delete(FTLBackUpFolder + fileNameOnly);
                            File.Copy(FTLFolder, FTLBackUpFolder + fileNameOnly);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }




            //string[] filesinFTLFolder = Directory.GetFiles(FTLFolder);

            //foreach (string file in filesinFTLFolder)
            //{
            //    string sourceFileNameOnly = Path.GetFileName(file);
            //    string destinationFileName = FTLBackUpFolder+sourceFileNameOnly;


            //    File.Move(file, destinationFileName);
            //}
        }

        private void button2_Click(object sender, EventArgs e)//load game
        {

        }

        //public static void Copy(string sourceDirectory, string destinationDirectory)
        //{

            








        //    // Get the subdirectories for the specified directory.
        //    DirectoryInfo dir = new DirectoryInfo(sourceDirectory);

        //    if (!dir.Exists)
        //    {
        //        throw new DirectoryNotFoundException(
        //            "Source directory does not exist or could not be found: "
        //            + sourceDirectory);
        //    }

        //    DirectoryInfo[] dirs = dir.GetDirectories();

        //    // If the destination directory doesn't exist, create it.       
        //    Directory.CreateDirectory(destinationDirectory);

        //    // Get the files in the directory and copy them to the new location.
        //    FileInfo[] files = dir.GetFiles();
        //    foreach (FileInfo file in files)
        //    {
        //        string tempPath = Path.Combine(destinationDirectory, file.Name);
        //        file.CopyTo(tempPath, false);
        //    }

            
        //}
    }
}
