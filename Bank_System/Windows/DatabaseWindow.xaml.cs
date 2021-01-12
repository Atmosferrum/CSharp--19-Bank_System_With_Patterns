using Database;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace Bank_System.Windows
{
    /// <summary>
    /// Interaction logic for DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {
        SqlConnection connection;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;

        public DatabaseWindow()
        {
            InitializeComponent();
            ConnectToDB();
        }

        public void ConnectToDB()
        {
            BankDBEntities dbEntity = new BankDBEntities();

            var data1 = from c in dbEntity.Clients
                        from d in dbEntity.Departments
                        where c.DepartmentID == d.DepartmentID
                        select new
                        {
                            c.ClientID,
                            c.Status,
                            c.Name,
                            c.LastName,
                            c.Deposit,
                            c.Percent,
                            c.Accummulation,
                            c.Balance,
                            d.DepartmentName,
                            c.DateOfDeposit
                        };

            var data2 = dbEntity.Clients.Join(
                dbEntity.Departments,
                client => client.DepartmentID,
                department => department.DepartmentID,
                (client, department) => new
                {
                    client.ClientID,
                    client.Status,
                    client.Name,
                    client.LastName,
                    client.Deposit,
                    client.Percent,
                    client.Accummulation,
                    client.Balance,
                    department.DepartmentName,
                    client.DateOfDeposit
                });

            var list = data2.Select(c => new
            {
                c.ClientID,
                c.Status,
                c.Name,
                c.LastName,
                c.Deposit,
                c.Percent,
                c.Accummulation,
                c.Balance,
                c.DepartmentName,
                c.DateOfDeposit
            }).ToList();

            foreach (var item in data2)
            {
                System.Console.WriteLine(item);
            }


            connection = new SqlConnection(Starter.ConnectionCreator().ConnectionString);
            dataTable = new DataTable();
            dataAdapter = new SqlDataAdapter();

            dataAdapter.SelectCommand = new SqlCommand(Starter.SelectFromDB(), connection);

            dataAdapter.Fill(dataTable);

            dbEntity.Clients.Load();
            dbEntity.Departments.Load();
            DG_Database_View.DataContext = list;
        }
    }
}
