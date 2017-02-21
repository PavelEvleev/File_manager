using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace File_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    

    public partial class MainWindow : Window
    {
        ObservableCollection<FileModel> _files;
        ObservableCollection<Drive> _drives;
        public MainWindow()
        {
            InitializeComponent();
            InitDrives(_drives);
        }
        private void InitDrives(ObservableCollection<Drive> _drives)
        {
            _drives = new ObservableCollection<Drive>();
            DriveInfo[] drive = DriveInfo.GetDrives();
            foreach(var d in drive)
            {
                _drives.Add(new Drive() {
                    Name = d.Name,
                    Label = d.VolumeLabel,
                    TotalFreeSpace = d.TotalFreeSpace / 1024,
                    TotalSize = d.TotalSize / 1024,
                    AvailableFreeSpace = d.AvailableFreeSpace / 1024
                });
            }
            
        }
        
        private void InitFiles(ObservableCollection<FileModel> _files , string directory)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            _files = new ObservableCollection<FileModel>();
            AddDir(_files, dir);
            AddFiles(_files, dir);

        }

        private void AddDir(ObservableCollection<FileModel> filesCollection, DirectoryInfo dir)
        {
            DirectoryInfo[] folders = dir.GetDirectories();
            foreach(var f in folders)
            {
                filesCollection.Add(new FileModel() {
                    FileName=f.Name,
                    IsDirectory=true,
                    FullPath=f.FullName,
                    Attributes=f.Attributes.ToString(),
                });
            }
        }

        private void AddFiles(ObservableCollection<FileModel> filesCollection, DirectoryInfo dir)
        {
            FileInfo[] files = dir.GetFiles();
            foreach (var file in files)
            {
                filesCollection.Add(new FileModel()
                {
                    FileName = file.Name,
                    Date = file.LastAccessTime,
                    Size = file.Length,
                    FullPath = file.FullName,
                    Extension = file.Extension,
                    Attributes = file.Attributes.ToString(),
                });
            }
        }
    }
}
