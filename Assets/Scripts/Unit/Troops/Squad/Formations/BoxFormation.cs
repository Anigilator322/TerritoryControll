using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public class BoxFormation : FormationBase
    {
        [SerializeField] private int _unitWidth = 5;
        [SerializeField] private int _unitDepth = 5;
        [SerializeField] private bool _hollow = false;
        [SerializeField] private float _nthOffset = 0;

        public override IEnumerable<Vector2> EvaluatePoints()
        {
            var middleOffset = new Vector2(_unitWidth * 0.5f, _unitDepth * 0.5f);

            for (var x = 0; x < _unitDepth; x++)
            {
                for (var z = 0; z < _unitWidth; z++)
                {
                    if (_hollow && x != 0 && x != _unitWidth - 1 && z != 0 && z != _unitDepth - 1) continue;
                    var pos = new Vector2(x + (z % 2 == 0 ? 0 : _nthOffset), z);

                    pos -= middleOffset;

                    pos += GetNoise(pos);

                    pos *= Spread;

                    yield return pos;
                }
            }
        }
    }
}