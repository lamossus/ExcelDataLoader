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
		private const int MAX_COMMAND_SIZE = 4<<20;
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

		public void BulkInsert(DataTable dataTable, string tableName, MySqlConnection con, Dictionary<int, int> mapping, bool clearTable = true)
		{
			StringBuilder comString = new StringBuilder($"INSERT INTO {tableName} VALUES ");

			int columnCount = GetColumnNames(tableName, con).Count;

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

						comString.Append('(');
						
						for (int j = 0; j < columnCount; j++)
						{
							string value = mapping.Keys.Contains(j) ? $"'{MySqlHelper.EscapeString(row[mapping[j]].ToString())}'" : "NULL";
							comString.Append(value);
							if (j != columnCount - 1)
								comString.Append(',');
						}

						comString.Append(')');

						if (currentBatchSize == _batchSize || comString.Length * 2 + 510 > MAX_COMMAND_SIZE || i == dataTable.Rows.Count - 1)
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
		public List<string> GetColumnNames(string tableName, MySqlConnection con)
		{
			List<string> columnNames = new List<string>();
			con.Open();
			using (var com = new MySqlCommand($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}';", con))
			{
				com.CommandType = CommandType.Text;
				using (var dr = com.ExecuteReader())
				{
					while (dr.Read())
						columnNames.Add(dr.GetString(0));
				}				
			}
			con.Close();
			return columnNames;
		}
		public List<string> GetTableNames(MySqlConnection con)
		{
			List<string> tableNames = new List<string>();
			con.Open();
			using (var com = new MySqlCommand("SHOW TABLES;", con))
			{
				com.CommandType = CommandType.Text;
				using (var dr = com.ExecuteReader())
				{
					while (dr.Read())
						tableNames.Add(dr.GetString(0));
				}
			}
			con.Close();
			return tableNames;
		}
	}
}
