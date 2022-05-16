using UnityEngine;
using TMPro;
using System.Threading;
using System.Threading.Tasks;
namespace CommonGame.UI
{
    [System.Serializable]
    public class FinishScoreOutput
    {
        public TextMeshProUGUI _text;
        public float OutputTime = 1f;
        private CancellationTokenSource _token;

        public async Task ShowScore(int score)
        {
            _text.gameObject.SetActive(true);
            _token?.Cancel();
            _token = new CancellationTokenSource();
            await ShowingRoutine(score);
        }
        public void Disable()
        {
            _token?.Cancel();
            _text.gameObject.SetActive(false);
        }
        private async Task ShowingRoutine (int score)
        {
            float elapsed = 0f;
            int start = 0;
            while(elapsed <= OutputTime && _token.IsCancellationRequested == false)
            {
                int val = (int)Mathf.Lerp(start, score, elapsed / OutputTime);
                _text.text = "FINAL SCORE:\n" + val.ToString();
                elapsed += Time.deltaTime;
                await Task.Yield();
            }
            if(this != null && _token.IsCancellationRequested == false)
            {
                _text.text = "FINAL SCORE:\n" + score.ToString();
            }
        }
    }
}