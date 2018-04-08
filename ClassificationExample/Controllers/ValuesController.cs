using Microsoft.AspNetCore.Mvc;

namespace ClassificationExample.Controllers
{
    [Route("api/[controller]")]
    public class ClassifyController : Controller
    {
        private readonly IUsersClassificationService _classificationService;

        public ClassifyController(IUsersClassificationService classificationService)
        {
            _classificationService = classificationService;
        }

        [HttpGet]
        public UserType Classify(UserStatistics statistics)
        {
            var result = _classificationService.ClassifyUser(statistics);
            return result;
        }
    }
}