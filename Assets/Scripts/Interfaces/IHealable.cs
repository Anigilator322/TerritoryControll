using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Units
{
    public interface IHealable
    {
        void ApplyHeal(int heal);
    }
}
