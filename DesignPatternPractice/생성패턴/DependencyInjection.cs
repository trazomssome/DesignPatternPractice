using System;

namespace ConsoleApplication1
{
    public interface IDatabaseProvider
    {
        void Open(); void Close();
    }
    public class MSSqlProvider : IDatabaseProvider
    {
        public void Close()
        {
            Console.WriteLine("MSSQL 데이타베이스에 연결이 닫혔습니다.");
        }

        public void Open()
        {
            Console.WriteLine("MSSQL 데이타베이스에 연결이 열렸습니다");
        }
    }

    public class OracleProvider : IDatabaseProvider
    {
        public void Close()
        {
            Console.WriteLine("Oracle 데이타베이스에 연결이 닫혔습니다.");
        }

        public void Open()
        {
            Console.WriteLine("Oracle 데이타베이스에 연결이 열렸습니다");
        }
    }

    public class OledbProvider : IDatabaseProvider
    {
        public void Close()
        {
            Console.WriteLine("Oledb 데이타베이스에 연결이 닫혔습니다.");
        }

        public void Open()
        {
            Console.WriteLine("Oledb 데이타베이스에 연결이 열렸습니다");
        }
    }

    /// <summary>    
    /// 데이타베이스에 연결하기 위한 공급자를 제공합니다. 기본값은 MSSQL입니다.    
    /// </summary>    
    public class DatabaseConnector
    {
        public IDatabaseProvider Connector { get; set; }
        public void Open() { Connector.Open(); }
        public void Close() { Connector.Close(); }
        public DatabaseConnector() : this(new MSSqlProvider()) { }
        public DatabaseConnector(IDatabaseProvider provider)
        {
            Connector = provider;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var databaseConnector = new DatabaseConnector();
            databaseConnector.Connector = new OracleProvider();
            databaseConnector.Open();

            // do somthing or query...            

            databaseConnector.Close();
            Console.ReadKey();
        }
    }
}