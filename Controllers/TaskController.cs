using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<ModelTask> modelTasks = new List<ModelTask>();

        [HttpGet]
        public ActionResult<List<ModelTask>> SearchTasks()
        {
            return Ok(modelTasks);
        }
        [HttpPost]
        public ActionResult<List<ModelTask>> AddTask(ModelTask nova)
        {
            if (nova.Id == 0 && modelTasks.Count > 0) 
                nova.Id = modelTasks[modelTasks.Count - 1].Id + 1;

            if (modelTasks.Count >= 10)
            {
                modelTasks.Add(nova);
                return Ok("Número máximo de caracteres na task atingido. Não é possível adicionar mais Caracteres.");
            }
            return Ok(modelTasks);
        }
    }
}
