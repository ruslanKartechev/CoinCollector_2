using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CommonGame.UI
{
    public class StartPage : PageWithButton
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Animator _anim;

        private void Awake()
        {
            HidePage();
            _button.onClick.AddListener(OnClick);
        }

        public override void ShowPage()
        {
            _canvas.enabled = true;
            _button.interactable = true;
            _anim.StopPlayback();

        }
        public override void HidePage()
        {
            _canvas.enabled = false;
            _button.interactable = true;
            _anim.StartPlayback();
        }

        public override void SetHeader(string Text)
        {
            _header.text = Text;
        }

    }
}