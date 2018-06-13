using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestory : MonoBehaviour
{
    public float time = 1;

    private void Awake()
    {
        GameObject.Destroy(gameObject, time);
    }
}
