using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace IDATest
{
    public class LevelCard : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        
        [SerializeField]
        private Button button;
        
        [SerializeField]
        private TextMeshProUGUI imageName;
        
        [SerializeField]
        private TextMeshProUGUI progressCounterText;
        
        [SerializeField]
        private ProgressBar progressBar;
        
        [SerializeField] 
        private TextMeshProUGUI completedText;
        
        [SerializeField] 
        private TextMeshProUGUI unavailableImageText;
        
        private LocalSaveLoad localSaveLoad;
        private IImageLoaderService imageLoaderService;
        private IChangeScreenService changeScreenService;
        private LevelData levelData;
        private float startedCounter;
        private float currentProgress;
        
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
        
        public void Init(LevelData levelData)
        {
            this.levelData = levelData;
            
            if (localSaveLoad.ProjectData.levelCounter.ContainsKey(levelData.id))
                currentProgress = levelData.counter - localSaveLoad.ProjectData.levelCounter[this.levelData.id];
            
            startedCounter = this.levelData.counter;
            button.onClick.AddListener(HandleButtonClick);
            RefreshLevelCardData();            
            CheckOnComplete();
        }

        private async void RefreshLevelCardData()
        {
            imageName.text = levelData.imageName;
            progressCounterText.text = $"{currentProgress}/{startedCounter}";
            progressBar.UpdateProgressBar(currentProgress/startedCounter);
            completedText.gameObject.SetActive(false);
            button.enabled = false;
            image.sprite = await imageLoaderService.LoadImage(levelData.imageUrl);
            unavailableImageText.gameObject.SetActive(false);
            button.enabled = true;
        }
        
        private void CheckOnComplete()
        {
            if (currentProgress < startedCounter) return;
            completedText.gameObject.SetActive(true);
            button.enabled = false;
            button.onClick.RemoveAllListeners();
        }
        
        private void HandleButtonClick()
        {
            changeScreenService.ShowLevelScreen(levelData);
        }
    }
}