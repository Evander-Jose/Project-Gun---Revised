using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Object Pool Type")]
public class ObjectPoolType : ScriptableObject
{
    public GameObject prefab;
    public int objectPoolSize;
}
