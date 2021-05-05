using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "WebLoaderData", menuName = "ScriptableObjects/WebLoaderData", order = 1)]

[Serializable]
public class WebLoaderData : ScriptableObject
{
    public string bundleURL;
    public int version;
}
