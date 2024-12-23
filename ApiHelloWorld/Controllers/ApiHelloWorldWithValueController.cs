using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiHelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiHelloWorldWithValueController : ControllerBase
    {
        // GET: api/<ApiHelloWorldWithValueController>
        [HttpGet]
        public IEnumerable<Value> Get()
        {
            //return new string[] { "ㅎㅇ", "ㅎㄱㄷ" };
            return new Value[] {
                new Value{Id = 1, Text = "ㅎㅇ" },
                new Value{Id = 2, Text = "ㅎㄱㄷ" }
            };
        }

        // GET api/<ApiHelloWorldWithValueController>/5
        [HttpGet("{id:int}")]
        public Value Get(int id)
        {
            //return $"값 : {id}";
            return new Value { Id = id, Text = $"값 : {id}"};
        }

        // POST api/<ApiHelloWorldWithValueController>
        [HttpPost]
        public IActionResult Post([FromBody] Value value)
        {
            // 모델 유효성 검사
            if (!ModelState.IsValid)
            { 
                // 400 에러 출력
                return BadRequest(ModelState);
            }

            // 넘어온 json 데이터를 처리 후 id 반환
            return CreatedAtAction("Get", new { id = value.Id, value});
        }

        // PUT api/<ApiHelloWorldWithValueController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiHelloWorldWithValueController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    // 새로운 클래스 Value를 만들어서 Value타입으로 데이터를 전송(xml, json 형태)
    // 모델 클래스
    public class Value
    { 
        public int Id { get; set; }
        [Required(ErrorMessage = "Text속성은 필수 입력 값입니다.")]
        public string Text { get; set; }

    }
}
