using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CommonGame.Controlls
{
    public class KeyboardControlls : ControllManagerBase
    {
        [SerializeField] private InputMoveChannelSO _inputChannel;
        [SerializeField] private InputAttackChannelSO _attackChannel;
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

                if (Input.GetKey(KeyCode.W))
                {
                    _inputChannel.RaiseEventUp();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    _inputChannel.RaiseEventRight();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    _inputChannel.RaiseEventDown();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    _inputChannel.RaiseEventLeft();
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _attackChannel.RaiseEventAttack();
                }
                yield return null;
            }
        }

    }
}