using Core.Points.Spawn;
using Core.Units;
using System.Collections.Generic;
using System.Linq;
namespace Core.Enemy
{
    public class PointObjectPool
    {
        public Dictionary<Owner, List<Point>> PointsByOwner { get; private set; } = new Dictionary<Owner, List<Point>>()
        {
            { Owner.Enemy, new List<Point>() },
            { Owner.Player, new List<Point>() },
            { Owner.Neutral, new List<Point>() }
        };
        //public readonly Point EnemyMainPoint;
        //public readonly Point PlayerMainPoint;
        //public PointsGraph Graph;

        public static PointObjectPool _Instance = null;

        public void Subscribe(PointSpawner spawner)
        {
            spawner.PointSpawned -= AddPoint;
            spawner.PointSpawned += AddPoint;
        }
        public void Subscribe(Point point)
        {
            point.OwnerChanged -= ChangeOwner;
            point.OwnerChanged += ChangeOwner;
        }

        public Point GetPointWithMaxHealth(Owner owner)
        {
            return PointsByOwner[owner].OrderByDescending(p => p.PointHealth.Health).FirstOrDefault();
        }

        public Point GetPointWithMinHealth(Owner owner)
        {
            return PointsByOwner[owner].OrderBy(p => p.PointHealth.Health).FirstOrDefault();
        }

        public static PointObjectPool Instance()
        {
            if (_Instance == null)
            {
                _Instance = new PointObjectPool();
            }
            return _Instance;
        }

        private PointObjectPool()
        {
            Initialize();
        }

        private void Initialize()
        {
        }

        private void AddPoint(Point point)
        {
            bool contains = false;
            PointsByOwner.Values.ToList().ForEach(
                p => { if (p.Contains(point)) 
                { 
                    contains = true; 
                    return; 
                } 
            });
            if (contains) return;
            PointsByOwner[point.Owner].Add(point);
        }

        private void ChangeOwner(Point point)
        {
            PointsByOwner.Values.ToList().ForEach(p => p.Remove(point));
            PointsByOwner[point.Owner].Add(point);            
        }
    }
}
