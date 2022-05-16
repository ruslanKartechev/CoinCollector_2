using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame.Controlls
{
    public class PointAndClickControlls : ControllManagerBase
    {
        [SerializeField] private InputClickChannelSO _inputClickChannel;
        private Coroutine _inputTaking;
        public override void DisableControlls()
        {
            if (_inputTaking != null)
                StopCoroutine(_inputTaking);
        }

        public override void EnableControlls()
        {
            if (_inputTaking != null)
                StopCoroutine(_inputTaking);
            _inputTaking = StartCoroutine(InputTaking());
        }

        private IEnumerator InputTaking()
        {
            while (true)
            {
                
                if (Input.GetMouseButtonDown(0))
                {
                    _inputClickChannel.MousePosition = Input.mousePosition;
                    _inputClickChannel.RaiseEventClick();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    _inputClickChannel.MousePosition = Input.mousePosition;
                    _inputClickChannel.RaiseEventRelease();
                }
                
                yield return null;
            }
        }

    }
}