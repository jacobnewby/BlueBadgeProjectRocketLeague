using RocketLeague.Data;
using RocketLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeague.Services
{
    public class CarService
    {
        private readonly Guid _userID;

        public CarService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateCar(CarCreate model)
        {
            var entity =
                new Car()
                {
                    OwnerID = _userID,
                    CarName = model.CarName,
                    CarColor = model.CarColor,
                    CarRarity = model.CarRarity
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cars.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CarListItem> GetCars()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cars
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                            new CarListItem
                            {
                                CarID = e.CarID,
                                CarName = e.CarName,
                                CarColor = e.CarColor,
                                CarRarity = e.CarRarity,
                            }
                        );
                return query.ToArray();
            }
        }

        public CarDetails GetCarById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cars
                    .Single(e => e.CarID == id && e.OwnerID == _userID);
                return
                    new CarDetails
                    {
                        CarID = entity.CarID,
                        CarName = entity.CarName,
                        CarColor = entity.CarColor,
                        CarRarity = entity.CarRarity,
                    };
            }
        }

        public bool UpdateCar(CarEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cars
                        .Single(e => e.CarID == model.CarID && e.OwnerID == _userID);

                entity.CarID = model.CarID;
                entity.CarName = model.CarName;
                entity.CarColor = model.CarColor;
                entity.CarRarity = model.CarRarity;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCar(int CarId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cars
                        .Single(e => e.CarID == CarId && e.OwnerID == _userID);

                ctx.Cars.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}