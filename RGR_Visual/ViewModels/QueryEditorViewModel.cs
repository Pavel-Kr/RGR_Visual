using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ReactiveUI;
using RGR_Visual.Models;

namespace RGR_Visual.ViewModels
{
    public class QueryEditorViewModel : ViewModelBase
    {
        public ObservableCollection<string> Tables { get; }
        public ObservableCollection<string> ChosenTables { get; }
        public ObservableCollection<string> Rows { get; }
        public ObservableCollection<string> ChosenRows { get; }
        string selectedTable;
        string selectedChosen;
        string selectedRow;
        string selectedRowChosen;
        public string SelectedTable
        {
            get => selectedTable;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedTable, value);
            }
        }
        public string SelectedChosen
        {
            get => selectedChosen;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedChosen, value);
            }
        }
        public string SelectedRow
        {
            get => selectedRow;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedRow, value);
            }
        }
        public string SelectedRowChosen
        {
            get => selectedRowChosen;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedRowChosen, value);
            }
        }
        public QueryEditorViewModel()
        {
            Tables = new ObservableCollection<string>(new List<string> { "Лошадь", "Тренер", "Владелец", "Жокей", "Забег", "Результат", "Ипподром" });
            Rows = new ObservableCollection<string>();
            ChosenTables = new ObservableCollection<string>();
            ChosenRows = new ObservableCollection<string>();
        }
        public void Choose()
        {
            string item = SelectedTable;
            Tables.Remove(SelectedTable);
            ChosenTables.Add(item);
            switch (item)
            {
                case "Лошадь":
                    string[] attrs = Horse.GetAttr();
                    foreach(string attr in attrs)
                    {
                        Rows.Add(attr);
                    }
                    break;
                case "Тренер":
                    Rows.Add(Trainer.GetAttr());
                    break;
                case "Владелец":
                    Rows.Add(Owner.GetAttr());
                    break;
                case "Жокей":
                    Rows.Add(Jockey.GetAttr());
                    break;
                case "Забег":
                    attrs = Race.GetAttr();
                    foreach (string attr in attrs)
                    {
                        Rows.Add(attr);
                    }
                    break;
                case "Результат":
                    attrs = Result.GetAttr();
                    foreach (string attr in attrs)
                    {
                        Rows.Add(attr);
                    }
                    break;
                case "Ипподром":
                    Rows.Add(Racecourse.GetAttr());
                    break;
            }
        }
        public void Delete()
        {
            string item = SelectedChosen;
            ChosenTables.Remove(SelectedChosen);
            Tables.Add(item);
            switch (item)
            {
                case "Лошадь":
                    string[] attrs = Horse.GetAttr();
                    foreach (string attr in attrs)
                    {
                        if (Rows.Contains(attr)) Rows.Remove(attr);
                        else if (ChosenRows.Contains(attr)) ChosenRows.Remove(attr);
                    }
                    break;
                case "Тренер":
                    if (Rows.Contains(Trainer.GetAttr())) Rows.Remove(Trainer.GetAttr());
                    else if (ChosenRows.Contains(Trainer.GetAttr())) ChosenRows.Remove(Trainer.GetAttr());
                    break;
                case "Владелец":
                    if (Rows.Contains(Owner.GetAttr())) Rows.Remove(Owner.GetAttr());
                    else if (ChosenRows.Contains(Owner.GetAttr())) ChosenRows.Remove(Owner.GetAttr());
                    break;
                case "Жокей":
                    if (Rows.Contains(Jockey.GetAttr())) Rows.Remove(Jockey.GetAttr());
                    else if (ChosenRows.Contains(Jockey.GetAttr())) ChosenRows.Remove(Jockey.GetAttr());
                    Rows.Add(Jockey.GetAttr());
                    break;
                case "Забег":
                    attrs = Race.GetAttr();
                    foreach (string attr in attrs)
                    {
                        if (Rows.Contains(attr)) Rows.Remove(attr);
                        else if (ChosenRows.Contains(attr)) ChosenRows.Remove(attr);
                    }
                    break;
                case "Результат":
                    attrs = Result.GetAttr();
                    foreach (string attr in attrs)
                    {
                        if (Rows.Contains(attr)) Rows.Remove(attr);
                        else if (ChosenRows.Contains(attr)) ChosenRows.Remove(attr);
                    }
                    break;
                case "Ипподром":
                    if (Rows.Contains(Racecourse.GetAttr())) Rows.Remove(Racecourse.GetAttr());
                    else if (ChosenRows.Contains(Racecourse.GetAttr())) ChosenRows.Remove(Racecourse.GetAttr());
                    Rows.Add(Racecourse.GetAttr());
                    break;
            }
        }
        public void ChooseRow()
        {
            string item = SelectedRow;
            Rows.Remove(SelectedRow);
            ChosenRows.Add(item);
        }
        public void DeleteRow()
        {
            string item = SelectedRowChosen;
            ChosenRows.Remove(SelectedRowChosen);
            Rows.Add(item);
        }
    }
}