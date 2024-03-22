
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LearnAspNet.Modal;
namespace LearnAspNet.Controllers
{
    [Route("keys")]
    [ApiController]
    public class KeyPairController: ControllerBase
    {
        private readonly KeyPairContext _context;

        public KeyPairController(KeyPairContext dbContext)
        {
            _context = dbContext;
        }

        //GET Keys
        [HttpGet()]
        public async Task<IActionResult> GetData()
        {
            var keyPairs = await _context.KeyPairs.ToListAsync();
            return Ok(keyPairs);
        }

        // GET keys/{key}
        [HttpGet("{key}")]
        public ActionResult<string> Get(string key)
        {
            var kvp = _context.KeyPairs.FirstOrDefault(k => k.Key == key);
            if (kvp != null)
            {
                return Ok(kvp);
            }
            else
            {
                return NotFound();
            }
        }

        // POST or PUT /keys
        [HttpPost]
        [HttpPut]
        public ActionResult Post([FromBody] KeyPair _keyPiar)
        {
            if (_context.KeyPairs.Any(k => k.Key == _keyPiar.Key))
            {
                return Conflict();
            }
            else
            {
                _context.KeyPairs.Add(_keyPiar);
                _context.SaveChanges();
                return Ok();
            }
        }

        // PATCH /keys/{key}/{value}
        [HttpPatch("{key}/{value}")]
        public ActionResult Patch(string key, string value)
        {
            var _keyPiar = _context.KeyPairs.FirstOrDefault(k => k.Key == key);
            if (_keyPiar != null)
            {
                _keyPiar.Value = value;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE /keys/{key}
        [HttpDelete("{key}")]
        public ActionResult Delete(string key)
        {
            var _keyPiar = _context.KeyPairs.FirstOrDefault(k => k.Key == key);
            if (_keyPiar != null)
            {
                _context.KeyPairs.Remove(_keyPiar);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}