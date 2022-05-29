using Avalonia.Controls;
using RGR_Visual.ViewModels;
using RGR_Visual.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RGR_Visual.Views
{
    public partial class MainWindow : Window
    {
        QueryEditor editor;
        QueryEditorViewModel context;
        public MainWindow()
        {
            InitializeComponent();
            this.FindControl<Button>("DeleteBtn").Click += delegate
            {
                Delete();
            };
            this.FindControl<Button>("EditorBtn").Click += delegate
            {
                OpenEditor();
            };
            context = new QueryEditorViewModel();
            this.FindControl<Button>("test").Click += delegate
            {
                test1();
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
            editor = new QueryEditor { DataContext = context };
            editor.Show();
        }
        public void CreateGrid(TabItemModel tab)
        {
            var context = this.DataContext as MainWindowViewModel;
            DataGrid grid = new DataGrid();
            foreach(string header in tab.DataGridHeaders)
            {
                var column = new DataGridTextColumn();
                column.Header = header;
            }
            TabItem item = new TabItem();
            item.Header = tab.Header;
            item.Content = grid;
            context.Tabs.Add(tab);
            var items = this.FindControl<TabControl>("testTab").Items;
            var items1 = (ObservableCollection<TabItem>)items;
            items1.Add(item);
            this.FindControl<TabControl>("testTab").Items = items;
        }
        public void test1()
        {
            CreateGrid(new TabItemModel { Header = "aaaa", DataGridHeaders = new System.Collections.ObjectModel.ObservableCollection<string>(new List<string> { "test1", "test2" }) });
        }
    }
}
