using RocketLeague.Data;
using RocketLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeague.Services
{
    public class GoalService
    {
        private readonly Guid _userID;

        public GoalService(Guid userID)
        {
            _userID = userID;
        }

        public bool GoalCar(GoalCreate model)
        {
            var entity =
                new Goal()
                {
                    OwnerID = _userID,
                    GoalName = model.GoalName,
                    GoalColor = model.GoalColor,
                    GoalRarity = model.GoalRarity,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Goals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GoalListItem> GetGoals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Goals
                    .Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                            new GoalListItem
                            {
                                GoalID = e.GoalID,
                                GoalName = e.GoalName,
                                GoalColor = e.GoalColor,
                                GoalRarity = e.GoalRarity,
                            }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateGoal(GoalEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Goals
                        .Single(e => e.GoalID == model.GoalID && e.OwnerID == _userID);

                entity.GoalID = model.GoalID;
                entity.GoalName = model.GoalName;
                entity.GoalColor = model.GoalColor;
                entity.GoalRarity = model.GoalRarity;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGoal(int GoalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Goals
                        .Single(e => e.GoalID == GoalId && e.OwnerID == _userID);

                ctx.Goals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}