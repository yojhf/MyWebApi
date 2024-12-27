using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyRankingServicesController : ControllerBase
    {
        // 객체 형태로 전달 - 데이터 - JSON 형태로 반환
        //[HttpGet]
        //public Subject Get()
        //{
        //    return new Subject{ Kor = 95, Eng = 100, Total =  195};
        //}

        // 컬렉션 형태로 전달 - JSON 형태로 반환
        //[HttpGet]
        //public List<Student> Get()
        //{
        //    var students = new List<Student> {
        //        new Student { Id = 1, Name = "ㅎㄱㄷ", Score = 3 },
        //        new Student { Id = 2, Name = "ㅂㄷㅅ", Score = 2 },
        //        new Student { Id = 3, Name = "ㅇㄲㅈ", Score = 1 },
        //    }; 

        //    return students;
        //}

        // 복합 형식 전달
        [HttpGet]
        public MyRankingDto Get()
        {
            var students = new List<Student> {
                new Student { Id = 1, Name = "ㅎㄱㄷ", Score = 3 },
                new Student { Id = 2, Name = "ㅂㄷㅅ", Score = 2 },
                new Student { Id = 3, Name = "ㅇㄲㅈ", Score = 1 },
            };

            var sub = new Subject{ Kor = 95, Eng = 100, Total = 195};

            return new MyRankingDto { Subject = sub, Student = students };
        }
    }

    /// <summary>
    /// 과목 - 모델 클래스
    /// </summary>
    public class Subject
    { 
        public int Kor {  get; set; }
        public int Eng {  get; set; }
        public int Total { get; set; }
    }

    // 학생정보
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }

    // 성적정보 : 복합형식 (과목(객체) + 학생들(컬렉션))
    public class MyRankingDto
    { 
        public Subject Subject { get; set; }

        public List<Student> Student { get; set; }
    }

    // 뷰페이지
    public class MyRankingServicesTestController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }
    }
}
