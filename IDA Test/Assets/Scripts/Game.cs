using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using IDATest;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
    private IJsonDownloadService jsonDownloadService;
    private IlevelDataLoadService levelDataLoadService;
    private LocalSaveLoad localSaveLoad;
    private IGameFactory gameFactory;

    [Inject]
    private void Construct(
        IJsonDownloadService jsonDownloadService,
        IlevelDataLoadService levelDataLoadService,
        LocalSaveLoad localSaveLoad,
        IGameFactory gameFactory)
    {
        this.jsonDownloadService = jsonDownloadService;
        this.levelDataLoadService = levelDataLoadService;
        this.localSaveLoad = localSaveLoad;
        this.gameFactory = gameFactory;
    }
    
    private async void Start()
    {
        await DownloadGameData();//TODO: подождать процесс скачивания файла, чтобы потом уже читать из него 
        LoadGameData();
        gameFactory.CreateUI();
    }

    private UniTask DownloadGameData() => jsonDownloadService.Download();

    private void LoadGameData() => levelDataLoadService.Load();
    
#if UNITY_EDITOR
    private void OnApplicationQuit() => localSaveLoad?.HandleOnApplicationQuit();
#endif

#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
        private void OnApplicationPause(bool pauseStatus)
        {
            localSaveLoad?.HandleApplicationPause(pauseStatus);
        }
#endif
}
