using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using XlLineStyle = Microsoft.Office.Interop.Excel.XlLineStyle;

namespace CarShowroomWorkstation.MVVM
{
    class DataBaseViewModel : INotifyPropertyChanged
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();
        private Clients _selectedClient;
        private Orders _selectedOrder;
        private Cars _selectedCars;

        private string carsTextChanged;
        private string clientsTextChanged;
        private string dateTextChanged;

        public ObservableCollection<Clients> Clients { get; set; }
        public ObservableCollection<Orders> Orders { get; set; }
        public ObservableCollection<Cars> Cars { get; set; }

        public ICommand ExcelExport => new RelayCommand(o => ExportToExcel());

        public ICommand WordExport => new RelayCommand(o => ExportToWord());

        private void ExportToWord()
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application()
            {
                DisplayAlerts = WdAlertLevel.wdAlertsNone
            };
            string template = $"{Guid.NewGuid().ToString().Substring(0, 8)}.docx";

            StreamWriter streamWriter = new StreamWriter(Path.Combine(Environment.CurrentDirectory, template), false);
            streamWriter.Close();
            Document document = wordApp.Documents.Open(Path.Combine(Environment.CurrentDirectory, template));

            FillWordDock(_carShowroomEntities.Cars.ToList(), wordApp, 1);
            FillWordDock(_carShowroomEntities.Clients.ToList(), wordApp, 2);
            FillWordDock(_carShowroomEntities.Orders.ToList(), wordApp, 2);

            wordApp.Visible = true;
        }

        private void FillWordDock<T>(List<T> list, Microsoft.Office.Interop.Word.Application wordApp, int tableNum)
        {//TODO исправить ошибку с выводом
            PropertyInfo[] propertyInfo = typeof(T).GetProperties();
            //Добавляем параграф в конец документа
            var Paragraph = wordApp.ActiveDocument.Paragraphs.Add();
            //Получаем диапазон
            var tableRange = Paragraph.Range;

            wordApp.ActiveDocument.Tables.Add(tableRange, list.Count, propertyInfo.Length);

            var table = wordApp.ActiveDocument.Tables[wordApp.ActiveDocument.Tables.Count];
            table.set_Style("Сетка таблицы");
            table.ApplyStyleHeadingRows = true;
            table.ApplyStyleLastRow = false;
            table.ApplyStyleFirstColumn = true;
            table.ApplyStyleLastColumn = false;
            table.ApplyStyleRowBands = true;
            table.ApplyStyleColumnBands = false;

            for (int k = 1; k <= propertyInfo.Length; k++)
            {
                wordApp.Application.Selection.Tables[tableNum].Cell(1, k).Range.Text = propertyInfo[k - 1].Name.ToString();
                wordApp.Application.Selection.Tables[tableNum].Cell(1, k).Range.Font.Color = WdColor.wdColorWhite;
                wordApp.Application.Selection.Tables[tableNum].Cell(1, k).Range.Shading.ForegroundPatternColor = WdColor.wdColorRed;
            }

            for (int c = 0; c < list.Count; c++)
            {
                for (int j = 0; j < propertyInfo.Length; j++)
                {
                    try
                    {
                        string result = propertyInfo[j].GetValue(list[c]).ToString();
                        wordApp.Application.Selection.Tables[1].Cell(c + 2, j + 1).Range.Text = result.Substring(0, (result.Length > 18) ? 18 : result.Length);
                    }
                    catch
                    {
                        wordApp.Application.Selection.Tables[1].Cell(c + 2, j + 1).Range.Text = list[c].GetType().GetProperties()[j].MetadataToken.ToString();
                    }
                    wordApp.Application.Selection.Tables[1].Cell(c + 2, j + 1).Range.Font.Color = WdColor.wdColorWhite;
                    wordApp.Application.Selection.Tables[1].Cell(c + 2, j + 1).Range.Shading.ForegroundPatternColor = WdColor.wdColorGray375;
                }
            }
        }

        private void ExportToExcel()
        {
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application
            {
                DisplayAlerts = false
            };
            const string template = "Export.xlsx";

            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Clients");
                excel.Workbook.Worksheets.Add("Cars");
                excel.Workbook.Worksheets.Add("Orders");

                FileInfo excelFile = new FileInfo(Path.Combine(Environment.CurrentDirectory, template));
                excel.SaveAs(excelFile);
            }

            Workbook workBook = application.Workbooks.Open(Path.Combine(Environment.CurrentDirectory, template));

            FillExcelSheet((application.Sheets[1] as Worksheet), _carShowroomEntities.Clients.ToList());
            FillExcelSheet((application.Sheets[2] as Worksheet), _carShowroomEntities.Cars.ToList());
            FillExcelSheet((application.Sheets[3] as Worksheet), _carShowroomEntities.Orders.ToList());

            application.Visible = true;
        }

        private void FillExcelSheet<T>(Worksheet worksheet, List<T> list)
        {
            PropertyInfo[] propertyInfo = typeof(T).GetProperties();
            for (int i = 1; i <= propertyInfo.Length; i++)
            {
                worksheet.Cells[1, i] = propertyInfo[i - 1].Name;
                worksheet.Cells[1, i].Interior.Color = Color.Red;
                worksheet.Cells[1, i].Font.Color = Color.White;
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < propertyInfo.Length; j++)
                {
                    try
                    {
                        worksheet.Cells[i + 2, j + 1] = propertyInfo[j].GetValue(list[i]).ToString();
                    }
                    catch
                    {
                        worksheet.Cells[i + 2, j + 1] = list[i].GetType().GetProperties()[j].MetadataToken.ToString();
                    }
                    worksheet.Cells[i + 2, j + 1].Font.Color = Color.White;
                    worksheet.Cells[i + 2, j + 1].Interior.Color = Color.FromArgb(63, 63, 70);
                }
            }

            var cells = worksheet.get_Range("A1", Convert.ToChar(64 + propertyInfo.Length) + "1");

            cells.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous; // внутренние вертикальные
            cells.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous; // внутренние горизонтальные            
            cells.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous; // верхняя внешняя
            cells.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous; // правая внешняя
            cells.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous; // левая внешняя
            cells.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
        }

        public Clients SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        public string DateTextChanged
        {
            get { return this.dateTextChanged; }
            set
            {
                if (this.dateTextChanged != value)
                {
                    this.dateTextChanged = value;
                    ObservableCollection<Orders> collection = new ObservableCollection<Orders>();
                    foreach (var item in _carShowroomEntities.Orders)
                    {
                        if (item.DateOfIssue.ToString("MM/dd/yyyy").Replace('.', '/').Contains(dateTextChanged))
                        {
                            collection.Add(item);
                        }
                    }
                    this.Orders = collection; 
                    OnPropertyChanged("DateTextChanged");
                    OnPropertyChanged("Orders");
                }
            }
        }

        public string ClientsTextChanged
        {
            get { return this.clientsTextChanged; }
            set
            {
                if (this.clientsTextChanged != value)
                {
                    this.clientsTextChanged = value;
                    Clients = new ObservableCollection<Clients>(_carShowroomEntities.Clients
                        .Where(x => x.Name.StartsWith(clientsTextChanged) || x.Surname.StartsWith(clientsTextChanged)));
                    OnPropertyChanged("CarsTextChanged");
                    OnPropertyChanged("Clients");
                }
            }
        }

        public string CarsTextChanged
        {
            get { return this.carsTextChanged; }
            set
            {
                if (this.carsTextChanged != value)
                {
                    this.carsTextChanged = value;
                    Cars = new ObservableCollection<Cars>(_carShowroomEntities.Cars
                        .Where(x => x.Mark.StartsWith(carsTextChanged) || x.Model.StartsWith(carsTextChanged)));
                    OnPropertyChanged("CarsTextChanged");
                    OnPropertyChanged("Cars");
                }
            }
        }

        public Orders SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public Cars SelectedCar
        {
            get { return _selectedCars; }
            set
            {
                _selectedCars = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        public DataBaseViewModel()
        {
            Clients = new ObservableCollection<Clients>();
            Orders = new ObservableCollection<Orders>();
            Cars = new ObservableCollection<Cars>();

            foreach (var item in _carShowroomEntities.Clients)
                Clients.Add(item);
            foreach (var item in _carShowroomEntities.Orders)
                Orders.Add(item);
            foreach (var item in _carShowroomEntities.Cars)
                Cars.Add(item);

            _selectedClient = new Clients();
            _selectedOrder = new Orders();
            _selectedCars = new Cars();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
