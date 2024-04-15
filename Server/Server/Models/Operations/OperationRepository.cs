using Server.Operations;
using Server.Wallets;
using SQLite;

namespace FinanceAppl.Operations
{
    public class OperationRepository
    {
        string pathToOperationsDB;
        SQLiteConnection OperationsDB;

        public OperationRepository()
        {
            pathToOperationsDB = "D://FinAppDataBases//Users.db";
            OperationsDB = new SQLiteConnection(pathToOperationsDB);
            OperationsDB.CreateTable<Operation>();
        }

        public bool SaveOperation(Operation Operatarion)
        {
            if (OperationsDB.Insert(Operatarion) != 0) return true;
            else return false;
        }


        public List<Operation> SearchByUserID(int userId)
        {
            List<Operation> UserOperationsList = OperationsDB.Table<Operation>().Where(u => u.UserID == userId).ToList();
            Console.WriteLine("-----операции");
            foreach (var a in UserOperationsList)
                Console.WriteLine(a);
            Console.WriteLine("-----операции");

            return UserOperationsList;
        }

    }
}
