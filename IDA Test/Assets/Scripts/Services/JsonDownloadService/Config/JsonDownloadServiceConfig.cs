using UnityEngine;

namespace IDATest
{
    [CreateAssetMenu(fileName = "JsonDownloadServiceConfig", menuName = "Game/Services/New JsonDownloadServiceConfig", order = 0)]
    public class JsonDownloadServiceConfig : ScriptableObject
    {
        public string downloadUrl;
        public string jsonName;
    }
}