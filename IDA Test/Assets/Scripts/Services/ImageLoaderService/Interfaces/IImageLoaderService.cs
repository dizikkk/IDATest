using Cysharp.Threading.Tasks;
using UnityEngine;

namespace IDATest
{
    public interface IImageLoaderService
    {
        public UniTask<Sprite> LoadImage(string url);
    }
}