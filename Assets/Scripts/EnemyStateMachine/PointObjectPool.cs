using Core.Units;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Enemy
{
    public class PointObjectPool : MonoBehaviour
    {
        [SerializeField] public List<Point> Points;

        public readonly Point EnemyMainPoint;
        public readonly Point PlayerMainPoint;
        public PointsGraph _graph;

        public static PointObjectPool instance = null;

        void Start()
        {
            if (instance == null)
            { 
                instance = this; 
            }
            else if (instance == this)
            { 
                Destroy(gameObject); 
            }

            
            DontDestroyOnLoad(gameObject);

            Initialize();
        }
        private void Initialize()
        {
            MakeGraph();

            //add listeners to every point
        }
        private void AddPoint(Point point)
        {
            Points.Add(point);
            MakeGraph();
        }
        private void MakeGraph()
        {
            _graph = new PointsGraph(Points);
        }
    }
}
