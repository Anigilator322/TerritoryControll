using System;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public abstract class FormationBase : MonoBehaviour
    {
        [SerializeField][Range(0, 1)] protected float _noise = 0;
        [SerializeField] protected float Spread = 1;
        public abstract IEnumerable<Vector2> EvaluatePoints();

        public Vector2 GetNoise(Vector2 pos)
        {
            var noise = Mathf.PerlinNoise(pos.x * _noise, pos.y * _noise);

            return new Vector2(noise, noise);
        }
    }
}