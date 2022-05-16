
using UnityEngine;
using CommonGame.UI;
namespace MyGame.UI
{
    public class PlayerStatsPage : PageBase
    {
        public Canvas _canvas;
        [SerializeField] private TextStatsUI _healthUI;
        [SerializeField] private TextStatsUI _scoreUI;
        [SerializeField] private StatsUIChannel _healthChannel;
        [SerializeField] private StatsUIChannel _scoreChannel;
        private void Awake()
        {
            HidePage();
            _healthChannel.Show = _healthUI.Show;
            _healthChannel.Hide = _healthUI.Hide;
            _healthChannel.Update = _healthUI.Update;

            _scoreChannel.Show = _scoreUI.Show;
            _scoreChannel.Hide = _scoreUI.Hide;
            _scoreChannel.Update = _scoreUI.Update;
        }

        public override void ShowPage()
        {
            _healthUI.Show();
            _scoreUI.Show();
            _canvas.enabled = true;
         
        }

        public override void HidePage()
        {
            _healthUI.Hide();
            _scoreUI.Hide();
            _canvas.enabled = false;
        }


    }
}