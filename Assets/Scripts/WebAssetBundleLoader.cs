using System;
using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

public class WebAssetBundleLoader : MonoBehaviour
{
    [SerializeField] GameObject errorScreen;

    [SerializeField] TextAsset jsonFile;
    [SerializeField] WebLoaderData webLoaderData;

    void Start()
    {
        StartCoroutine(DownloadAndCache());
        JsonUtility.FromJsonOverwrite(jsonFile.text, webLoaderData);
    }

    IEnumerator DownloadAndCache()
    {
        // Wait for the Caching system to be ready
        while (!Caching.ready)
            yield return null;

        // Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
        using (WWW www = WWW.LoadFromCacheOrDownload(webLoaderData.bundleURL, webLoaderData.version))
        {
            yield return www;
            if (www.error != null) errorScreen.SetActive(true);

            AssetBundle bundle = www.assetBundle;
            GameObject[] asset = bundle.LoadAllAssets<GameObject>();
            for (int i = 0; i < asset.Length; i++) Instantiate(asset[i]);

            webLoaderData.version = Caching.GetVersionFromCache(webLoaderData.bundleURL);
            bundle.Unload(false);


        }

        File.WriteAllText(AssetDatabase.GetAssetPath(jsonFile), JsonUtility.ToJson(webLoaderData));
    }

}
