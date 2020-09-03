using System.Data.SQLite;
namespace TabuOyunu
{
    class Database
    {
        public SQLiteConnection baglanti;
        
        public Database()
        {
            baglanti = new SQLiteConnection("Data Source=TabuKelimeleri.db");            
        }
        
        public void openConnection()
        {
            if(baglanti.State != System.Data.ConnectionState.Open)
            {
                baglanti.Open();
            }
        }
        public void closeConnection()
        {
            if(baglanti.State != System.Data.ConnectionState.Closed)
            {
                baglanti.Close();
            }
        }
    }
}
