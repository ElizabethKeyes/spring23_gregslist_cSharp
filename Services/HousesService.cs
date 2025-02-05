using gregslist_cSharp.Controllers;

namespace gregslist_cSharp.Services;

public class HousesService
{
  private readonly HousesRepository _housesRepo;
  public HousesService(HousesRepository housesRepo)
  {
    _housesRepo = housesRepo;
  }

  internal House CreateHouse(House houseData)
  {
    int id = _housesRepo.CreateHouse(houseData);
    House house = this.GetHouseById(id);
    return house;
  }

  internal string DeleteHouse(int houseId)
  {
    House house = this.GetHouseById(houseId);
    int rowsAffected = _housesRepo.DeleteHouse(houseId);
    return $"{house.Bedrooms} bedroom house has been removed at id {houseId}";
  }

  internal House EditHouse(int houseId, House houseData)
  {
    House ogHouse = this.GetHouseById(houseId);
    ogHouse.Bedrooms = houseData.Bedrooms ?? ogHouse.Bedrooms;
    ogHouse.Bathrooms = houseData.Bathrooms ?? ogHouse.Bathrooms;
    ogHouse.Price = houseData.Price ?? ogHouse.Price;
    ogHouse.Description = houseData.Description ?? ogHouse.Description;
    _housesRepo.EditHouse(ogHouse);
    return ogHouse;
  }

  internal House GetHouseById(int houseId)
  {
    House house = _housesRepo.GetHouseById(houseId);
    if (house == null)
    {
      throw new Exception($"No house found at id {houseId}");
    }
    return house;
  }

  internal List<House> GetHouses()
  {
    List<House> houses = _housesRepo.GetHouses();
    return houses;
  }
}