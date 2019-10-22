using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
            Stream fs = model.File.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);

            var entity =
                new Build()
                {
                    FileContent = bytes,
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
                                    FileContent = e.FileContent,
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

        public IEnumerable<BuildListItem> GetBuildsForHomePage()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Builds
                        .Select(
                            e =>
                                new BuildListItem
                                {
                                    FileContent = e.FileContent,
                                    BuildName = e.BuildName,
                                }
                        );
                return query.ToList();
            }
        }

        public IEnumerable<BuildListItem> GetRandomBuilds()
         {
            var list = GetBuildsForHomePage().ToList();
            Random rnd = new Random();
            var build1 = rnd.Next(list.Count);
            var build2 = rnd.Next(list.Count);
            return new List<BuildListItem> { list[build1], list[build2] };
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
