using FinanceAppl.Operations;
using Microsoft.AspNetCore.Mvc;
using Server.Operations;

namespace Server.Controllers
{
    public class OperationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public OperationRepository OperationsRepository = new OperationRepository();

        [HttpPost]
        public IActionResult RegisterOperation([FromBody] Operation operation)
        {
            Operation savedOperation = OperationsRepository.SaveOperation(operation);
            if (savedOperation != null) return Ok(savedOperation);
            else return BadRequest();
        }


        [HttpPost]
        public List<Operation> GetOperations(string id)
        {
            return OperationsRepository.SearchByUserID(int.Parse(id));
        }
    }
}
