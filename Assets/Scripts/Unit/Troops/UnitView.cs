using Core.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitView : MonoBehaviour
{
    private Unit _troop;

    private void Start()
    {
        TryGetComponent<Unit>(out _troop);
        TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer);

        if (_troop == null || spriteRenderer == null)
            return;

        spriteRenderer.color = PointConsts.instance.GetColor(_troop.Owner);
    }


}
