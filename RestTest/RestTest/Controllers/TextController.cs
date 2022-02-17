using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestTest.Models;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace RestTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly textDBContext _context;
        public TextController(textDBContext context)
        {
            _context = context;
        }

        //Get
        [HttpGet("GetText")]
        public async Task<ActionResult<IEnumerable<Text>>>GetText()
        {
            return await _context.Texts.ToListAsync();
        }

        //POST: API/ReadText
        [HttpPost("ReadText")]
        [Produces("application/json")]
        public IActionResult UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];                
                if (file.Length > 0)
                {
                    var str = file.Length.ToString();       
                    return Ok(str); ;
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpPost("GetInputText")]
        [Produces("application/json")]
        public IActionResult GetInputText()
        {
            var str = Request.ContentLength.Value;            
            return Ok(str);
        }
      

    }
}
