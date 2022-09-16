using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDataLoader
{
	internal class SqlLoader
	{
		private int _batchSize = 25000;
		public int BatchSize
		{
			get => _batchSize;
			set
			{
				if (value < 1)
					value = 1;
				_batchSize = value;
			}
		}

		public EventHandler<double>? OnProgress;

		public void BulkInsert(DataTable dataTable, string tableName, MySqlConnection con, Dictionary<string, int> mapping, bool clearTable = true)
		{
			StringBuilder comString = new StringBuilder($"INSERT INTO {tableName} VALUES ");

			con.Open();
			using (var tran = con.BeginTransaction(IsolationLevel.Serializable))
			{
				try
				{
					if (clearTable)
					{
						using (var com = new MySqlCommand($"TRUNCATE TABLE {tableName};", con))
						{
							com.CommandType = CommandType.Text;
							com.Transaction = tran;
							com.ExecuteNonQuery();
						}
					}

					int rowsUploaded = 0;
					int currentBatchSize = 0;
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						DataRow row = dataTable.Rows[i];

						currentBatchSize++;

						int id = Convert.ToInt32(row[mapping["id"]]);
						string ogrn = row[mapping["ogrn"]].ToString();
						string inn = row[mapping["inn"]].ToString();
						string name = MySqlHelper.EscapeString(row[mapping["name"]].ToString());

						comString.Append($"({id},'{ogrn}','{inn}','{name}')");

						if (currentBatchSize == _batchSize || i == dataTable.Rows.Count - 1)
						{
							comString.Append(';');

							using (var com = new MySqlCommand(comString.ToString(), con))
							{
								com.CommandType = CommandType.Text;
								com.Transaction = tran;
								com.ExecuteNonQuery();
								rowsUploaded += currentBatchSize;
								double progress = (double)rowsUploaded / dataTable.Rows.Count;
								OnProgress?.Invoke(this, progress);
							}

							currentBatchSize = 0;
							comString = new StringBuilder($"INSERT INTO {tableName} VALUES ");
						}
						else
							comString.Append(',');
					}

					tran.Commit();
				}
				catch
				{
					tran.Rollback();
					throw;
				}
			}
			con.Close();
		}
		public int GetRowCount(string tableName, MySqlConnection con)
		{
			int rows = 0;
			con.Open();
			using (MySqlCommand com = new MySqlCommand($"SELECT COUNT(1) FROM {tableName};", con))
			{
				com.CommandType = CommandType.Text;
				rows = Convert.ToInt32(com.ExecuteScalar());
			}
			con.Close();
			return rows;
		}
	}
}
