namespace gregslist_cSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
  private readonly HousesService _housesService;

  public HousesController(HousesService housesService)
  {
    _housesService = housesService;
  }

  [HttpPost]
  public ActionResult<House> CreateHouse([FromBody] House houseData)
  {
    try
    {
      House house = _housesService.CreateHouse(houseData);
      return Ok(house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{houseId}")]
  public ActionResult<string> DeleteHouse(int houseId)
  {
    try
    {
      string message = _housesService.DeleteHouse(houseId);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{houseId}")]
  public ActionResult<House> EditHouse(int houseId, [FromBody] House houseData)
  {
    try
    {
      House house = _housesService.EditHouse(houseId, houseData);
      return Ok(house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<House>> GetHouses()
  {
    try
    {
      List<House> houses = _housesService.GetHouses();
      return Ok(houses);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{houseId}")]
  public ActionResult<House> GetHouseById(int houseId)
  {
    try
    {
      House house = _housesService.GetHouseById(houseId);
      return Ok(house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


}
