using System;
using System.Net;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace IDATest
{
    public class JsonDownloadService : IJsonDownloadService
    {
        private string downloadUrl;
        private string jsonName;
        private JsonDownloadServiceConfig config;
        
        public JsonDownloadService(JsonDownloadServiceConfig config)
        {
            this.config = config;
            downloadUrl = config.downloadUrl;
            jsonName = config.jsonName;
        }
        
        public async UniTask Download()
        {
            WebClient client = new();
            await client.DownloadFileTaskAsync(new Uri(downloadUrl), Application.dataPath + $"/{jsonName}.json");
        }
    }
}