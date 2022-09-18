using Microsoft.AspNetCore.Mvc;

namespace Lesson1.Controllers
{
    [Route("/api")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private KVDB _Db;

        public TestController(KVDB db)
        {
            _Db = db;
        }


        [HttpGet("get")]
        public IActionResult Get([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            List<WeatherModel> response = new List<WeatherModel>();

            IEnumerable<KeyValuePair<DateTime, WeatherModel>> converted = _Db.DB.Where(f => (f.Key >= from) && (f.Key <= to));

            foreach (KeyValuePair<DateTime, WeatherModel> i in converted)
            {
                response.Add(i.Value);
            }

            return Ok(response);
        }


        [HttpPost("post")]
        public IActionResult Post([FromQuery] DateTime date, [FromQuery] uint wind, [FromQuery] uint uvindex, [FromQuery] uint cloudcover, [FromQuery] uint prec, [FromQuery] int temp)
        {
            if (wind > 12)
            {
                return BadRequest("Format error at wind");
            }

            if (uvindex > 11)
            {
                return BadRequest("Format error at uvindex");
            }

            if (cloudcover > 4)
            {
                return BadRequest("Format error at cloudcover");
            }

            if (prec > 3)
            {
                return BadRequest("Format error at prec");
            }
            
            if (!_Db.DB.ContainsKey(date))
            {
                _Db.DB.Add(date, new WeatherModel(date, wind, uvindex, cloudcover, prec, temp));
            }
            

            return Ok("Request OK. Data added");
        }

        [HttpPut("put")]
        public IActionResult Put([FromQuery] DateTime date, [FromQuery] uint wind, [FromQuery] uint uvindex, [FromQuery] uint cloudcover, [FromQuery] uint prec, [FromQuery] int temp)
        {
            if (wind > 12)
            {
                return BadRequest("Format error at wind");
            }

            if (uvindex > 11)
            {
                return BadRequest("Format error at uvindex");
            }

            if (cloudcover > 4)
            {
                return BadRequest("Format error at cloudcover");
            }

            if (prec > 3)
            {
                return BadRequest("Format error at prec");
            }

            if (_Db.DB.ContainsKey(date))
            {
                _Db.DB.Remove(date);
                _Db.DB.Add(date, new WeatherModel(date, wind, uvindex, cloudcover, prec, temp));
            }

            return Ok("Request OK. Data updated");
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime date)
        {
            if (_Db.DB.ContainsKey(date))
            {
                _Db.DB.Remove(date);
                return Ok("Request OK. Data updated");
            }

            return BadRequest("Key not found");
        }
    }
}
