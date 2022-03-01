using GameOfChance.API.Extensions;
using GameOfChance.Common;
using GameOfChance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameOfChance.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        protected void SetNewValues(BaseRequest model)
        {
            model.CreatedBy = CurrentLoggedInUser();
            model.CreatedDate = DateTime.UtcNow.ToString(Constants.DateTimeFormat);
        }

        protected string CurrentLoggedInUser()
        {
            // Get the user Id from claims
            var userId = User.GetUserId();
            return userId;
        }
    }
}
