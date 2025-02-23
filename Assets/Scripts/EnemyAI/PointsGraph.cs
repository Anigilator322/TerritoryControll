using Core.Units;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Enemy
{
    public class PointNode
    {
        public Dictionary<Point, float> Edges;
        public Point originRef;

        public PointNode(Point origin, Dictionary<Point,float> edges)
        {
            originRef = origin;
            Edges = edges;
        }
    }

    public class PointsGraph
    {
        public List<PointNode> Nodes = new List<PointNode>();

        public PointsGraph(List<Point> points)
        {
            if (points == null)
                return;
            InitializeNodes(points);
        }
        private void InitializeNodes(List<Point> points)
        {
            for(int i = 0; i < points.Count; i++)
            {
                Dictionary<Point, float> edges = new Dictionary<Point, float>();
                for(int j = 0; j<points.Count; j++)
                {
                    if (i == j)
                        edges.Add(points[j], float.MaxValue);
                    edges.Add(points[j], Vector3.Distance(points[i].gameObject.transform.position,
                        points[j].gameObject.transform.position));
                }
                PointNode node = new PointNode(points[i], edges);
                Nodes.Add(node);
            }
        }

        private bool FindNode(Point point, out PointNode pointNode)
        {
            foreach(var node in Nodes)
            {
                if (node.originRef == point)
                {
                    pointNode = node;
                    return true;
                }
            }
            pointNode = null;
            return false;
        }

        public float GetWeight(Point origin, Point target)
        {
            if(FindNode(origin, out PointNode pointNode))
            {
                pointNode.Edges.TryGetValue(target, out float val);
                return val;
            }
            return int.MaxValue;
        }
        public bool TryGetNearestPointByOwner(Point origin, Owner owner,out Point target)
        {
            if (FindNode(origin, out PointNode pointNode))
            {
                foreach (var edge in pointNode.Edges)
                {
                    if (edge.Key.Owner == owner)
                    {
                        target = edge.Key;
                        return true;
                    }
                }
            }
            target = null;
            return false;
        }
    }
}
