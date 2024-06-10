using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace IDATest
{
    public class ImageLoaderService : IImageLoaderService
    {
        public async UniTask<Sprite> LoadImage(string url)
        {
            using UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
            await webRequest.SendWebRequest();
            
            if (webRequest.isDone == false)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                Texture texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
                return Sprite.Create((Texture2D)texture, new Rect(0,0, texture.width, texture.height), Vector2.zero);
            }
            return null;
        }
    }
}