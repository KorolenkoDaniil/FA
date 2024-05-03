using Server.Models.Categories1;
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


        public Operation SaveOperation(Operation operation)
        {
            var existingOperation = OperationsDB.Table<Operation>().FirstOrDefault(oper => oper.Id == operation.Id);

            if(existingOperation != null)
                OperationsDB.Update(operation);
            else
                OperationsDB.Insert(operation);

            return OperationsDB.Table<Operation>().FirstOrDefault(oper => oper.Id == operation.Id);
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
