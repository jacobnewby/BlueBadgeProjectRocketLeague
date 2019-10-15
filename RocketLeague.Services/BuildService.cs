using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketLeague.Data;
using RocketLeague.Models;

namespace RocketLeague.Services
{
    public class BuildService
    {
        private readonly Guid _userID;

        public BuildService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateBuild(BuildCreate model)
        {
            var entity =
                new Build()
                {

                    OwnerID = _userID,
                    BuildName = model.BuildName,
                    CarID = model.CarID,
                    DecalID = model.DecalID,
                    WheelsID = model.WheelsID,
                    GoalID = model.GoalID,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Builds.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BuildListItem> GetBuilds()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Builds
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new BuildListItem
                                {
                                    BuildID = e.BuildID,
                                    BuildName = e.BuildName,
                                    CarName = e.Car.CarName,
                                    DecalName = e.Decal.DecalName,
                                    WheelsName = e.Wheels.WheelsName,
                                    GoalName = e.Goal.GoalName,
                                }
                        );

                return query.ToArray();
            }
        }

        public BuildDetails GetBuildById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Builds
                        .Single(e => e.BuildID == id && e.OwnerID == _userID);
                return
                    new BuildDetails
                    {
                        BuildID = entity.BuildID,
                        BuildName = entity.BuildName,
                        CarName = entity.Car.CarName,
                        DecalName = entity.Decal.DecalName,
                        WheelsName = entity.Wheels.WheelsName,
                        GoalName = entity.Goal.GoalName,
                    };
            }
        }

        public bool UpdateBuild(BuildEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Builds
                        .Single(e => e.BuildID == model.BuildID && e.OwnerID == _userID);

                entity.BuildName = model.BuildName;
                entity.CarID = model.CarID;
                entity.DecalID = model.DecalID;
                entity.WheelsID = model.WheelsID;
                entity.GoalID = model.GoalID;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBuild(int buildId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Builds
                        .Single(e => e.BuildID == buildId && e.OwnerID == _userID);

                ctx.Builds.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
