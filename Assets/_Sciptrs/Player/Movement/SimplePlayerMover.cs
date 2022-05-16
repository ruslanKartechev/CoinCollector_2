using UnityEngine;
using CommonGame;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Threading;
namespace MyGame
{
    [System.Serializable]
    public class SimplePlayerMover
    {
        public Action OnMoveEvent;
        public Action OnRotationEvent;
        public Action OnStopped;
        private PawnMoveSettings _movementSettings;

        private Vector3 _currentPosition;
        private float _currentAngle;
        
        private float _currentSpeed;
        private float _currentAngularSpeed;
        
        private CancellationTokenSource _moveToken;
        private CancellationTokenSource _rotateToken;
        private bool IsMoving;

        public PawnMoveSettings Settings { get => _movementSettings; set => _movementSettings = value; }
        public Vector3 CurrentPosition { get => _currentPosition; set => _currentPosition = value; }
        public float CurrentAngle { get => _currentAngle; set => _currentAngle = value; }


        public void Init(Vector3 startPosition, float startAngle)
        {
            _currentPosition = startPosition;
            _currentSpeed = _movementSettings.NormalSpeed;
            _currentAngularSpeed = _movementSettings.RotationSpeed;
            _currentAngle = startAngle;
        }


        public async Task MoveTo(Vector3 movePositision, Vector3 lookPosition)
        {
            if(IsMoving == false)
            {
                StopAll();
                await RotateOnly(_currentPosition, lookPosition);
                await MoveOnly(movePositision);
            }
            else
            {
                StopAll();
                List<Task> tasks = new List<Task>(2);
                tasks.Add(RotateOnly(_currentPosition, lookPosition));
                tasks.Add(MoveOnly(movePositision));
                await Task.WhenAll(tasks);
            }


        }

        public void StopAll()
        {
            IsMoving = false;
            _moveToken?.Cancel();
            _rotateToken?.Cancel();
        }

        public async Task MoveOnly(Vector3 position)
        {
            _moveToken?.Cancel();
            _moveToken = new CancellationTokenSource();
            await MovementRoutine(position, _moveToken);
        }

        public async Task RotateOnly(Vector3 startPos,  Vector3 position)
        {
            _rotateToken?.Cancel();
            _rotateToken = new CancellationTokenSource();
            Vector3 lookVector = position - startPos;
            float targetAngle = Vector3.SignedAngle(Vector3.forward, lookVector, Vector3.up);
            if((_currentAngle < -90 && targetAngle > 90))
            {
                await RotatingRoutine(-180,_rotateToken);
                _currentAngle = 180;
                await RotatingRoutine(targetAngle, _rotateToken);
            }
            else if((targetAngle < -90 && _currentAngle > 90))
            {
                await RotatingRoutine(180, _rotateToken);
                _currentAngle = -180;
                await RotatingRoutine(targetAngle, _rotateToken);
            }
            else
            {
                await RotatingRoutine(targetAngle, _rotateToken);
            }
        }



        #region Moving
        private async Task MovementRoutine(Vector3 targetPos, CancellationTokenSource token)
        {
            IsMoving = true;
            if (targetPos == _currentPosition)
            {
                OnMovingEnd();
                return;
            }
            Vector3 startPos = _currentPosition;
            float distance = (targetPos - _currentPosition).magnitude;
            float time = distance / _currentSpeed;
            float elapsed = 0f;
          
            if(time == float.NaN)
            {
                OnMovingEnd();
                return;
            }
            while (elapsed <= time && token.IsCancellationRequested == false)
            {
                Vector3 pos = Vector3.Lerp(startPos, targetPos, elapsed / time);
                SetPosition(pos);
                elapsed += Time.deltaTime;
                await Task.Yield();
            }
            if(token.IsCancellationRequested == false)
            {
                SetPosition(targetPos);
                OnMovingEnd();
            }
        }

        private void SetPosition(Vector3 position)
        {
            _currentPosition = new Vector3(position.x, _currentPosition.y, position.z);
            OnMoveEvent?.Invoke();
        }

        private void OnMovingEnd()
        {
            OnStopped?.Invoke();
            IsMoving = false;
        }
        #endregion

        #region Rotating
        private async Task RotatingRoutine(float targetAngle, CancellationTokenSource token)
        {

            float startAngle = _currentAngle;
            if(startAngle == targetAngle)
            {
                return;
            }
            float time = Mathf.Abs(targetAngle - startAngle) / _currentAngularSpeed;
            if(time == float.NaN)
            {
                Debug.Log($"Rotation time is Nan");
                return;
            }
            float elapsed = 0f;
            while(elapsed <= time && token.IsCancellationRequested == false)
            {
                float angle = Mathf.Lerp(startAngle, targetAngle, elapsed/time);
                SetAngle(angle);
                elapsed += Time.deltaTime;
                await Task.Yield();
            }

            if (token.IsCancellationRequested == false)
            {
                SetAngle(targetAngle);
            }
        }


        private void SetAngle(float angle)
        {
            _currentAngle = angle;
            OnRotationEvent?.Invoke();
        }
        #endregion
    }

}