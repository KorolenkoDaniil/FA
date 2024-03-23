using FinanceApplication.core.Operations;
using Microsoft.AspNetCore.Mvc;

namespace FinanceServer.Controllers
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
            Console.WriteLine(operation);
            if (OperationsRepository.SaveOperation(operation)) return Ok();
            else return BadRequest();
        }

        [HttpPost]
        public List<Operation> GetOperations(string id)
        {
            return OperationsRepository.SearchByUserID(int.Parse(id));
        }
    }
}
