using UnityEngine;
using TMPro;
namespace MyGame.UI
{
    [System.Serializable]
    public class TextStatsUI
    {
        [SerializeField] private TextMeshProUGUI _text;

        public virtual void Show()
        {
            _text.gameObject.SetActive(true);

        }
        public virtual void Hide()
        {
            _text.gameObject.SetActive(false);

        }
        public virtual void Update(int value)
        {
            _text.text = value.ToString();
        }
    }
}