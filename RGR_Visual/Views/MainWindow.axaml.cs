using Avalonia.Controls;
using RGR_Visual.ViewModels;
using RGR_Visual.Models;
using System;

namespace RGR_Visual.Views
{
    public partial class MainWindow : Window
    {
        QueryEditor editor;
        public MainWindow()
        {
            InitializeComponent();
            this.FindControl<Button>("DeleteBtn").Click += delegate
            {
                Delete();
            };
            editor = new QueryEditor();
            this.FindControl<Button>("EditorBtn").Click += delegate
            {
                OpenEditor();
            };
        }
        public void Delete()
        {
            var context = this.DataContext as MainWindowViewModel;
            var tables = this.FindControl<TabControl>("Tables");
            int index = tables.SelectedIndex;
            try
            {
                switch (index)
                {
                    case 0:
                        context.Db.Horses.Remove((Horse)this.FindControl<DataGrid>("Horses").SelectedItem);
                        break;
                    case 1:
                        context.Db.Trainers.Remove((Trainer)this.FindControl<DataGrid>("Trainers").SelectedItem);
                        break;
                    case 2:
                        context.Db.Jockeys.Remove((Jockey)this.FindControl<DataGrid>("Jockeys").SelectedItem);
                        break;
                    case 3:
                        context.Db.Owners.Remove((Owner)this.FindControl<DataGrid>("Owners").SelectedItem);
                        break;
                    case 4:
                        context.Db.Races.Remove((Race)this.FindControl<DataGrid>("Races").SelectedItem);
                        break;
                    case 5:
                        context.Db.Results.Remove((Result)this.FindControl<DataGrid>("Results").SelectedItem);
                        break;
                    case 6:
                        context.Db.Racecourses.Remove((Racecourse)this.FindControl<DataGrid>("Racecourses").SelectedItem);
                        break;
                }
                context.Error = "";
            }
            catch (Exception ex)
            {
                context.Error += "Не удалось удалить строку: " + ex.Message + "\n";
            }
        }
        public void OpenEditor()
        {
            editor.Show();
        }
    }
}
