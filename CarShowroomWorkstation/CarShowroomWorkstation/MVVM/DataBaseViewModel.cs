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

        public ICommand WordExport => new RelayCommand(o => FillWordDock());

        private void FillWordDock()
        {//TODO рефакторить
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application()
            {
                DisplayAlerts = WdAlertLevel.wdAlertsNone
            };
            string template = $"{Guid.NewGuid().ToString().Substring(0, 8)}.docx";
            StreamWriter streamWriter = new StreamWriter(Path.Combine(Environment.CurrentDirectory, template), false);
            streamWriter.Close();
            Document document = wordApp.Documents.Open(Path.Combine(Environment.CurrentDirectory, template));

            object oMissing = System.Reflection.Missing.Value;
            wordApp.ActiveDocument.Paragraphs.Add(ref oMissing);
            wordApp.ActiveDocument.Paragraphs.Add(ref oMissing);
            wordApp.ActiveDocument.Paragraphs.Add(ref oMissing);
            wordApp.ActiveDocument.Paragraphs.Add(ref oMissing);

            var wordparagraph = wordApp.ActiveDocument.Paragraphs[2];
            Microsoft.Office.Interop.Word.Range wordrange = wordparagraph.Range;

            List<Clients> clients = _carShowroomEntities.Clients.ToList();
            PropertyInfo[] propertyInfo = clients.First().GetType().GetProperties();

            Object defaultTableBehavior = WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehavior = WdAutoFitBehavior.wdAutoFitWindow;
            Table wordtable1 = wordApp.ActiveDocument.Tables.Add(wordrange, clients.Count, propertyInfo.Length,
              ref defaultTableBehavior, ref autoFitBehavior);

            wordtable1.set_Style("Сетка таблицы");
            wordtable1.ApplyStyleHeadingRows = true;
            wordtable1.ApplyStyleLastRow = false;
            wordtable1.ApplyStyleFirstColumn = true;
            wordtable1.ApplyStyleLastColumn = false;
            wordtable1.ApplyStyleRowBands = true;
            wordtable1.ApplyStyleColumnBands = false;

            for (int k = 1; k <= propertyInfo.Length; k++)
            {
                wordtable1.Cell(1, k).Range.Text = propertyInfo[k - 1].Name.ToString();
                wordtable1.Cell(1, k).Range.Font.Color = WdColor.wdColorWhite;
                wordtable1.Cell(1, k).Range.Shading.ForegroundPatternColor = WdColor.wdColorRed;
            }

            for (int c = 0; c < clients.Count; c++)
            {
                for (int j = 0; j < propertyInfo.Length; j++)
                {
                    try
                    {
                        string result = propertyInfo[j].GetValue(clients[c]).ToString();
                        wordtable1.Cell(c + 2, j + 1).Range.Text = result.Substring(0, (result.Length > 18) ? 18 : result.Length);
                    }
                    catch
                    {
                        wordtable1.Cell(c + 2, j + 1).Range.Text = clients[c].GetType().GetProperties()[j].MetadataToken.ToString();
                    }
                    wordtable1.Cell(c + 2, j + 1).Range.Font.Color = WdColor.wdColorWhite;
                    wordtable1.Cell(c + 2, j + 1).Range.Shading.ForegroundPatternColor = WdColor.wdColorGray375;
                }
            }


            List<Cars> cars = _carShowroomEntities.Cars.ToList();
            PropertyInfo[] propertyInfo2 = cars.First().GetType().GetProperties();
            Table wordtable2 = wordApp.ActiveDocument.Tables.Add(wordApp.Selection.Range, cars.Count, propertyInfo2.Length, ref defaultTableBehavior, ref autoFitBehavior);

            for (int k = 1; k <= propertyInfo2.Length; k++)
            {
                wordtable2.Cell(1, k).Range.Text = propertyInfo2[k - 1].Name.ToString();
                wordtable2.Cell(1, k).Range.Font.Color = WdColor.wdColorWhite;
                wordtable2.Cell(1, k).Range.Shading.ForegroundPatternColor = WdColor.wdColorRed;
            }

            for (int c = 0; c < cars.Count; c++)
            {
                for (int j = 0; j < propertyInfo2.Length; j++)
                {
                    try
                    {
                        string result = propertyInfo2[j].GetValue(cars[c]).ToString();
                        wordtable2.Cell(c + 2, j + 1).Range.Text = result.Substring(0, (result.Length > 18) ? 18 : result.Length);
                    }
                    catch
                    {
                        wordtable2.Cell(c + 2, j + 1).Range.Text = cars[c].GetType().GetProperties()[j].MetadataToken.ToString();
                    }
                    wordtable2.Cell(c + 2, j + 1).Range.Font.Color = WdColor.wdColorWhite;
                    wordtable2.Cell(c + 2, j + 1).Range.Shading.ForegroundPatternColor = WdColor.wdColorGray375;
                }
            }

            object unit;
            object extend;
            unit = WdUnits.wdStory;
            extend = WdMovementType.wdMove;
            wordApp.Selection.EndKey(ref unit, ref extend);

            List<Orders> orders = _carShowroomEntities.Orders.ToList();
            PropertyInfo[] propertyInfo3 = orders.First().GetType().GetProperties();
            Table wordtable3 = wordApp.ActiveDocument.Tables.Add(wordApp.Selection.Range, orders.Count, propertyInfo3.Length, ref defaultTableBehavior, ref autoFitBehavior);

            for (int k = 1; k <= propertyInfo3.Length; k++)
            {
                wordtable3.Cell(1, k).Range.Text = propertyInfo3[k - 1].Name.ToString();
                wordtable3.Cell(1, k).Range.Font.Color = WdColor.wdColorWhite;
                wordtable3.Cell(1, k).Range.Shading.ForegroundPatternColor = WdColor.wdColorRed;
            }

            for (int c = 0; c < orders.Count; c++)
            {
                for (int j = 0; j < propertyInfo3.Length; j++)
                {
                    try
                    {
                        string result = propertyInfo3[j].GetValue(orders[c]).ToString();
                        wordtable3.Cell(c + 2, j + 1).Range.Text = result.Substring(0, (result.Length > 18) ? 18 : result.Length);
                    }
                    catch
                    {
                        wordtable3.Cell(c + 2, j + 1).Range.Text = orders[c].GetType().GetProperties()[j].MetadataToken.ToString();
                    }
                    wordtable3.Cell(c + 2, j + 1).Range.Font.Color = WdColor.wdColorWhite;
                    wordtable3.Cell(c + 2, j + 1).Range.Shading.ForegroundPatternColor = WdColor.wdColorGray375;
                }
            }

            wordApp.Visible = true;
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
