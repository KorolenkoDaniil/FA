using Server.Operations;
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

        public bool SaveOperation(Operation wallet)
        {
            if (OperationsDB.Insert(wallet) != 0) return true;
            else return false;
        }


        public List<Operation> SearchByUserID(int userId)
        {
            List<Operation> UsersOperationsList = OperationsDB.Table<Operation>().Where(u => u.UserID == userId).ToList();
            return UsersOperationsList;
        }
    }
}
