using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class SpriteLoader : MonoBehaviour
{
    [SerializeField] AssetReference spriteToLoad;
    [SerializeField] Image objSprite;

    private async void Start()
    {
        AsyncOperationHandle<Sprite> loadHandle = spriteToLoad.LoadAssetAsync<Sprite>();
        await loadHandle.Task;
        if (loadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = loadHandle.Result;
            objSprite.sprite = sprite;
            Addressables.Release(loadHandle);
        }
    }
}
