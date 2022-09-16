using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDataLoader
{
	internal class ExcelLoader
	{
		public event EventHandler<double>? OnProgress;

		public DataTable GetExcelData(string excelFilePath, int skipRows = 0)
		{
			DataSet ds = new DataSet();

			using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
			{
				using (var reader = ExcelReaderFactory.CreateReader(stream))
				{
					int readRows = 0;
					int rowCount = 0;

					do
					{
						rowCount += reader.RowCount - skipRows;
					} while (reader.NextResult());

					ds = reader.AsDataSet(new ExcelDataSetConfiguration()
					{
						ConfigureDataTable = _ => new ExcelDataTableConfiguration()
						{
							UseHeaderRow = false,
							FilterRow = rowReader =>
							{
								if (rowReader.Depth >= skipRows)
								{
									readRows++;
									double progress = (double)readRows / rowCount;

									OnProgress?.Invoke(this, progress);
									return true;
								}

								return false;
							}
						}
					});
				}
			}

			while (ds.Tables.Count > 1)
			{
				DataTable dt = ds.Tables[1];
				ds.Tables[0].Merge(dt);
				ds.Tables.Remove(dt);
			}

			return ds.Tables[0];
		}
		public DataTable GetExcelPreview(string excelFilePath, int columnCount, int rowCount, int skipRows = 0)
		{
			DataTable dt = new DataTable();

			for (int i = 0; i < columnCount; i++)
				dt.Columns.Add();

			using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
			{
				using (var reader = ExcelReaderFactory.CreateReader(stream))
				{
					while (skipRows > 0)
					{
						reader.Read();
						skipRows--;
					}

					for (int i = 0; i < rowCount; i++)
					{
						bool end = reader.Read();
						if (!end)
							break;
						DataRow row = dt.NewRow();
						for (int j = 0; j < columnCount; j++)
							row[j] = reader.GetValue(j);
						dt.Rows.Add(row);
					}
				}
			}

			return dt;
		}
	}
}
