using Microsoft.AspNetCore.Mvc;

namespace ClassificationExample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUsersClassificationService _classificationService;

        public ValuesController(IUsersClassificationService classificationService)
        {
            _classificationService = classificationService;
        }

        [HttpGet]
        public UserType Get(UserStatistics statistics)
        {
            var result = _classificationService.ClassifyUser(statistics);
            return result;
        }
    }
}