using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Core.Units
{
    public class PointConsts : MonoBehaviour
    {
        [SerializeField] private Color _PlayerColor;
        [SerializeField] private Color _EnemyColor;
        [SerializeField] private Color _NeutrallColor;
        public static PointConsts instance = null; 

        void Awake()
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
        public Color GetColor(Owner owner)
        {
            switch (owner)
            {
                case Owner.Player:
                    return _PlayerColor;
                case Owner.Enemy:
                    return _EnemyColor;
                case Owner.Neutral:
                    return _NeutrallColor;
                default:
                    return _NeutrallColor;
            }
        }
        private void Initialize()
        {
        }

    }
}
