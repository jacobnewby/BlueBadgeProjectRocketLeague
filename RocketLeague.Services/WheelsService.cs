using RocketLeague.Data;
using RocketLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeague.Services
{
    public class WheelsService
    {
        private readonly Guid _userID;

        public WheelsService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateWheels(WheelsCreate model)
        {
            var entity =
                new Wheels()
                {
                    OwnerID = _userID,
                    WheelsName = model.WheelsName,
                    WheelsColor = model.WheelsColor,
                    WheelsRarity = model.WheelsRarity
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Wheelss.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WheelsListItem> GetWheels()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Wheelss
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                            new WheelsListItem
                            {
                                WheelsID = e.WheelsID,
                                WheelsName = e.WheelsName,
                                WheelsColor = e.WheelsColor,
                                WheelsRarity = e.WheelsRarity,
                            }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateWheels(WheelsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Wheelss
                        .Single(e => e.WheelsID == model.WheelsID && e.OwnerID == _userID);

                entity.WheelsID = model.WheelsID;
                entity.WheelsName = model.WheelsName;
                entity.WheelsColor = model.WheelsColor;
                entity.WheelsRarity = model.WheelsRarity;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWheels(int WheelsId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Wheelss
                        .Single(e => e.WheelsID == WheelsId && e.OwnerID == _userID);

                ctx.Wheelss.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}