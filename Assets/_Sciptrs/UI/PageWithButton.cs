using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; 
namespace CommonGame.UI
{
    public class PageWithButton : PageBase
    {
        [SerializeField] protected TextMeshProUGUI _header;
        [SerializeField] protected TextMeshProUGUI _btnText;
        [SerializeField] protected Button _button;
        public event Action OnButtonClick;

        
        public override void HidePage()
        {

        }

        public override void ShowPage()
        {

        }

        public virtual void OnClick()
        {
            OnButtonClick?.Invoke();
        }
        public virtual void SetHeader(string Text)
        {
            _header.text = Text;
        }
    
    }
}