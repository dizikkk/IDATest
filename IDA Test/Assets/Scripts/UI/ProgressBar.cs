using UnityEngine;
using UnityEngine.UI;

namespace IDATest
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]
        private Image progressBarImage;

        public void UpdateProgressBar(float value)
        {
            progressBarImage.fillAmount = value;
        }
    }
}