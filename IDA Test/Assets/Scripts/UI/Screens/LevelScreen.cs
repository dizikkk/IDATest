using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace IDATest
{
    public class LevelScreen : Screen
    {
        [SerializeField]
        private Button homeButton;
        
        [SerializeField]
        private Button imageButton;
        
        [SerializeField]
        private Image image;
        
        [SerializeField]
        private TextMeshProUGUI progressText;
        
        private LocalSaveLoad localSaveLoad;
        private IChangeScreenService changeScreenService;
        private IImageLoaderService imageLoaderService;
        private LevelData levelData;
        
        [Inject]
        private void Construct(
            LocalSaveLoad localSaveLoad, 
            IChangeScreenService changeScreenService, 
            IImageLoaderService imageLoaderService)
        {
            this.localSaveLoad = localSaveLoad;
            this.changeScreenService = changeScreenService;
            this.imageLoaderService = imageLoaderService;
        }
        
        public override async void Show(LevelData levelData)
        {
            homeButton.onClick.AddListener(HandleHomeButtonClicked);
            imageButton.onClick.AddListener(HandleImageButtonClicked);
            
            if (!localSaveLoad.ProjectData.levelCounter.ContainsKey(levelData.id))
                localSaveLoad.ProjectData.levelCounter.Add(levelData.id, levelData.counter);

            this.levelData = levelData;
            progressText.text = localSaveLoad.ProjectData.levelCounter[levelData.id].ToString();
            image.sprite = await imageLoaderService.LoadImage(levelData.imageUrl);
        }
        
        public override void Hide()
        {
            homeButton.onClick.RemoveAllListeners();
            imageButton.onClick.RemoveAllListeners();
            gameObject.SetActive(false);
        }
        
        private void HandleHomeButtonClicked()
        {
            image.sprite = null;
            changeScreenService.ShowMenuScreen();
        }
        
        private void HandleImageButtonClicked()
        {
            localSaveLoad.ProjectData.levelCounter[levelData.id]--;
            progressText.text = localSaveLoad.ProjectData.levelCounter[levelData.id].ToString();
            
            if (localSaveLoad.ProjectData.levelCounter[levelData.id] <= 0)
                changeScreenService.ShowMenuScreen();
        }
    }
}