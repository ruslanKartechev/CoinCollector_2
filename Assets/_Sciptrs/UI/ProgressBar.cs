using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
namespace CommonGame.UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _barFill;
        [SerializeField] private float _fillTime = 0.1f;
        [SerializeField] private bool _useText = true;
        [SerializeField] private TextMeshProUGUI _text;

        private void Start()
        {
            _text.text = "";
        }
        public async Task FillAsync(float amount)
        {
            float start = _barFill.fillAmount;
            amount = Mathf.Clamp01(amount);
            float elapsed = 0f;
            while(elapsed <= _fillTime)
            {
                float fill = Mathf.Lerp(start, amount, elapsed / _fillTime);
                _barFill.fillAmount = fill;
                if (_useText)
                    _text.text = ((int)(fill * 100)).ToString(); ;
                elapsed += Time.deltaTime;
                await Task.Yield();
            }
            _barFill.fillAmount = amount;
            if (_useText)
                _text.text = ((int)(amount * 100)).ToString(); ;

        }

        public void Fill(float amount)
        {
            _barFill.fillAmount = amount;
            if (_useText)
                _text.text = ((int)(amount * 100)).ToString(); ;

        }

        public async void SetBarColor(Color color)
        {
            await Task.Delay(1000);
        }
    }
}
