using Microsoft.AspNetCore.Mvc;

namespace ApiHelloWorld.Components
{
    public class PointComponent
    {
        // Empty
    }

    #region Interface
    // 리포지토리 인터페이스 - Point와 관련된 기능정의
    public interface IPointRepository
    {
        void Add(int id);
        Point Get(int id);

        int GetTotalPointGetBuyUserId(int userId = 1234);
        PointSatuts GetPointStatusGetBuyUser();
    }

    // 리포지토리 클래스 - Point와 관련된 기능구현
    public class PointRepository : IPointRepository
    {
        public int GetTotalPointGetBuyUserId(int userId = 1234)
        {
            return 1234;
        }

        public PointSatuts GetPointStatusGetBuyUser()
        { 
            return new PointSatuts() { Gold = 0, Siver = 0, Bronze = 0};
        }

        // 데이터 Insert
        public void Add(int id)
        {
            throw new NotImplementedException();
        }

        // 데이터 Select
        public Point Get(int id)
        {
            throw new NotImplementedException();
        }
    }
    public class PointRepositoryInMemory : IPointRepository
    {
        public int GetTotalPointGetBuyUserId(int userId = 1234)
        {
            return 9871;
        }

        public PointSatuts GetPointStatusGetBuyUser()
        {
            return new PointSatuts() { Gold = 10, Siver = 123, Bronze = 456 };
        }

        public void Add(int id)
        {
            throw new NotImplementedException();
        }

        public Point Get(int id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPointLogRepository
    {

    }

    public class PointLogRepository : IPointLogRepository
    {

    }
    #endregion

    #region Controller
    // Point View 페이지
    public class PointController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }
    }

    // Point Web API 서비스
    [Route("api/[controller]")]
    public class PointServiceController : ControllerBase
    {
        private IPointRepository repository;

        // 생성자
        public PointServiceController(IPointRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var json = new { Point = 4567 };

            return Ok(json);
        }

        [HttpGet]
        [Route("{userId:int}")]
        public IActionResult Get(int userId)
        {
            // userId를 입력받아 데이터 베이스에 있는 포인트를 반환
            var myPoint = repository.GetTotalPointGetBuyUserId(userId);

            var json = new { Point = myPoint };

            return Ok(json);
        }
    }

    // PointLog View 페이지
    public class PointLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
    public class PointLogServiceController : ControllerBase
    {

    }


    // PointStatus View 페이지
    public class PointStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    // PointStatus Web API 서비스
    [Route("api/[controller]")]
    public class PointStatusServiceController : ControllerBase
    {
        private IPointRepository repository;

        // 생성자
        public PointStatusServiceController(IPointRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // userId를 입력받아 데이터 베이스에 있는 포인트를 반환
            var pointSatuts = repository.GetPointStatusGetBuyUser();

            return Ok(pointSatuts);
        }
    }
    #endregion

    #region Class
    // Point 모델 클래스 : Point 테이블과 일대일 매핑
    public class Point
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public int TotalPoint { get; set; }
    }

    // PointLog 모델 클래스 : PointLog 테이블과 일대일 매핑
    public class PointLog
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public int TotalPoint { get; set; }
        public DateTimeOffset Created { get; set; }
    }

    // 포인트 상태 정보를 금, 은, 동으로 하는 모델 클래스
    public class PointSatuts
    { 
        public int Gold { get; set; }
        public int Siver { get; set; }
        public int Bronze { get; set; }
    }
    #endregion
}
