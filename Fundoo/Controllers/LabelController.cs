using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fundoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        ILabelBL label;

        public LabelController(ILabelBL label)
        {
            this.label = label;
        }
        //[Authorize]
        [HttpPost]
        public IActionResult AddLabel(LabelModel labelmodel)
        {
            try
            {
                if (label.AddLabel(labelmodel))
                {
                    return this.Ok(new { Success = true, message = "Label Added Successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to add label" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
