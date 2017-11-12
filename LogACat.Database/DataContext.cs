using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LogACat.Database
{
	public class DataContext
	{
		IDbConnection _db;

		public string ConnectionString
		{
			get { return _db.ConnectionString; }
			set { _db.ConnectionString = value; }
		}

		public DataContext()
		{
			_db = new SqlConnection();
		}

		public DataContext(string connectionString)
		{
			_db = new SqlConnection(connectionString);
		}


		public IEnumerable<FilePost> GetAllFilePosts(string connectionString)
		{
			// Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jonas\Projekt\Privat\LogACat\LogACat.Database\LogACat.mdf;Integrated Security=True
			return _db.Query<FilePost>("SELECT * FROM [dbo].[FilePost]");
		}
	}
}
