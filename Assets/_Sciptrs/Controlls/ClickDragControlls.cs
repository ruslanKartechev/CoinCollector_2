using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CommonGame.Controlls
{
    public class ClickDragControlls : ControllManagerBase
    {
        [SerializeField] private InputClickChannelSO _clickChannel;
        private Coroutine _inputCheck;

        public override void DisableControlls()
        {
            if (_inputCheck != null)
                StopCoroutine(_inputCheck);
        }

        public override void EnableControlls()
        {
            if (_inputCheck != null)
                StopCoroutine(_inputCheck);
            _inputCheck = StartCoroutine(InputCheck());
        }

        private IEnumerator InputCheck()
        {
            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _clickChannel?.RaiseEventClick();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    _clickChannel?.RaiseEventRelease();

                }


                yield return null;
            }
        }
        
    }
}