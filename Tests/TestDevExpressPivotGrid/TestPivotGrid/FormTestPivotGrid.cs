using DevExpress.XtraPivotGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPivot
{
    public partial class FrmTest : Form
    {
        ObservableCollection<Order> _orderList;
        string[] _customerList;
        string[] _categoryList;

        public FrmTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _orderList = new ObservableCollection<Order>();
            _customerList = GenerateCustomerList();
            _categoryList = GenerateCategoryList();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string customerName = _customerList[new Random().Next(0, _customerList.Length)];
            var date = new DateTime();
            int qtyItemsToAdd = int.Parse(txtTotal.Text);
            for (int i = 1; i <= qtyItemsToAdd; i++)
            {
                if (i % 250 == 0)
                {
                    customerName = _customerList[new Random().Next(0, _customerList.Length)];
                    this.Text = $"Adding {i} of {qtyItemsToAdd}";
                    Application.DoEvents();
                }

                date = new DateTime(date.Year == 2017 ? 2018 : 2017, 1, 1);
                var category = _categoryList[new Random().Next(0, _categoryList.Length)];
                var price = double.Parse((new Random().Next(12, 998)).ToString() + "," + (new Random().Next(0, 99)).ToString());
                _orderList.Add(new Order(customerName, date, category, price));
            }

            this.Text = "Loading items to Pivot Grid...";
            Application.DoEvents();
            pivotGridControl2.DataSource = _orderList;
            pivotGridControl2.Fields.Clear();
            pivotGridControl2.Fields.AddRange(CreateFields());
            UpdateFormTitle();
            Cursor.Current = Cursors.Default;
        }

        private void UpdateFormTitle()
        {
            Text = $"Pivot Test - Current # of records: {string.Format("{0:n0}", _orderList.Count)}";
        }

        private static PivotGridField[] CreateFields()
        {
            var fieldCustomer = new PivotGridField("Customer", PivotArea.RowArea);
            
            var fieldYear = new PivotGridField("Date", PivotArea.ColumnArea);
            fieldYear.Caption = "Year";
            fieldYear.GroupInterval = PivotGroupInterval.DateYear;

            var fieldCategory = new PivotGridField("Category", PivotArea.ColumnArea);
            fieldCategory.Caption = "Product Category";

            var fieldPrice = new PivotGridField("Price", PivotArea.DataArea);
            fieldPrice.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            fieldPrice.CellFormat.FormatString = "c0";

            fieldCustomer.AreaIndex = 0;
            fieldCategory.AreaIndex = 0;
            fieldYear.AreaIndex = 1;

            return new PivotGridField[] { fieldCustomer, fieldCategory, fieldYear, fieldPrice };
        }
        private string[] GenerateCustomerList()
        {
            return new string[]
            {
                "Tiago Fabri Turetta",
                "Jairo Rodrigues Valim",
                "Lucas Gouvea",
                //"Rafael Modolo",
                //"Douglas Moraes",
                //"Jamile Nunes Santos",
                //"Ana Valeria Moreira",
                //"Roberta de Lima Silva",
                "Keoma Trindade de Souza"
            };
        }
        private string[] GenerateCategoryList()
        {
            return new string[]
            {
                "Eletronics",
                "Appliances",
                "Video Games"
            };
        }
    }

    class Order
    {
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        public Order()
        { }

        public Order(string customer, DateTime date, string category, double price)
        {
            Customer = customer;
            Date = date;
            Category = category;
            Price = price;
        }
    }
}
