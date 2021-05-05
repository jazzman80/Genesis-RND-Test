using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BudledObjectLoader : MonoBehaviour
{
    [SerializeField] private string bundleURL;

    private IEnumerator Start()
    {
        using (WWW web = new WWW(bundleURL))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;

            if (remoteAssetBundle == null)
            {
                Debug.LogError("Failed to download AssetBundle!");
                yield break;
            }

            GameObject[] asset = remoteAssetBundle.LoadAllAssets<GameObject>();

            for (int i = 0; i < asset.Length; i++) Instantiate(asset[i]);
            remoteAssetBundle.Unload(false);
        }
        
    }
}
