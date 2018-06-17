using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBaseAttr
{
    public string AssetName { get; protected set; }
    public int Atk { get; protected set; }
    public float AtkRange { get; protected set; }
    public float AtkTime { get; protected set; }

    public WeaponBaseAttr(string _assetName, int _atk, float _atkRange, float _atkTime)
    {
        AssetName = _assetName;
        Atk = _atk;
        AtkRange = _atkRange;
        AtkTime = Mathf.Clamp(_atkTime, 0.0000001f, float.MaxValue); 
    }
}
