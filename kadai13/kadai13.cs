using System; 
using System.IO; 
using System.Data.SQLite;


namespace Kadai
{
	//⑬odbcドライバを使用して、TESTテーブルから情報を取得するクラスを作成してください。

	class Kadai13
	{
		public static void Main()
		{
			SQLiteConnection connection = new SQLiteConnection();
			connection.ConnectionString = "Data Source=kadaiDb.db;";
			connection.Open();
			
			SQLiteCommand command = connection.CreateCommand();
			command.CommandText = "SELECT * FROM TEST";
			SQLiteDataReader reader = command.ExecuteReader();
			
			while(reader.Read())
			{
    			Console.WriteLine("index:{0}  id:{1}  content:{2}", reader["indexno"], reader["id"], reader["content"]);
			}
			connection.Close();
		}
	}
}
