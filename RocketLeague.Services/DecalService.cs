using RocketLeague.Data;
using RocketLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeague.Services
{
    public class DecalService
    {
        private readonly Guid _userID;

        public DecalService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateDecal(DecalCreate model)
        {
            var entity =
                new Decal()
                {
                    OwnerID = _userID,
                    DecalName = model.DecalName,
                    DecalColor = model.DecalColor,
                    DecalRarity = model.DecalRarity,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Decals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DecalListItem> GetDecals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Decals
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                            new DecalListItem
                            {
                                DecalID = e.DecalID,
                                DecalName = e.DecalName,
                                DecalColor = e.DecalColor,
                                DecalRarity = e.DecalRarity,
                            }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateDecal(DecalEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Decals
                        .Single(e => e.DecalID == model.DecalID && e.OwnerID == _userID);

                entity.DecalID = model.DecalID;
                entity.DecalName = model.DecalName;
                entity.DecalColor = model.DecalColor;
                entity.DecalRarity = model.DecalRarity;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDecal(int DecalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Decals
                        .Single(e => e.DecalID == DecalId && e.OwnerID == _userID);

                ctx.Decals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}