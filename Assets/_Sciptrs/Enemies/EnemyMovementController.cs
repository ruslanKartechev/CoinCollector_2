using UnityEngine;
using System;
using CommonGame;
namespace MyGame
{
    [System.Serializable]
    public class EnemyMovementController : IMoveObservable, IPushbackTarget, IMoveManager
    {
        [SerializeField] private bool InspectorSetings = false;
        [SerializeField] private PawnMoveSettings _settings;
        [Space(5)]
        [SerializeField] private LayerMask _moveBlockLayers;

        private SimplePlayerMover _mover;
        private MovePositionValidator _positionValidator;
        private IViewTransform _view;

        private event Action OnStart;
        private event Action OnStop;
        public void Init(PawnMoveSettings settings, IViewTransform view)
        {
            _mover = new SimplePlayerMover();
            _mover.OnMoveEvent = OnPositionChange;
            _mover.OnRotationEvent = OnRotationChange;
            _mover.OnStopped = OnMoveFinished;
            #region Settings
            if (InspectorSetings)
            {
                _mover.Settings = _settings;
            }
            else
            {
                _settings = settings;
                _mover.Settings = settings;
            }
            #endregion
            _mover.Init(_settings.StartPosition, _settings.StartAngle);
            _positionValidator = new RaycastPositionValidator(_moveBlockLayers);

            #region ViewNotify
            _view = view;
            if (_view != null)
            {
                _view.Update2Position(_settings.StartPosition);
                _view.UpdateYAngle(_settings.StartAngle);
            }
            else
            {
                Debug.Log("No IViewTransform to update");
            }
            #endregion
        }

        public void Move(Vector3 movePos)
        {
            Vector3 allowedPos = _positionValidator.GetCorrectedPosition(movePos, _mover.CurrentPosition, _settings.DeadZone);
            StartMoving(allowedPos, allowedPos);
        }

        public async void StartMoving(Vector3 movePos, Vector3 lookPos)
        {
            OnStart?.Invoke();
            await _mover.MoveTo(movePos, lookPos);
        }

        #region UpdatingView
        private void OnPositionChange()
        {
            _view?.Update2Position(_mover.CurrentPosition);
        }

        private void OnRotationChange()
        {
            _view?.UpdateYAngle(_mover.CurrentAngle);
        }

        #endregion

        private void OnMoveFinished()
        {
            OnStop?.Invoke();
        }


        #region Observable
        public void SubscribeToStart(Action action)
        {
            OnStart += action;
        }

        public void SubscribeToStop(Action action)
        {
            OnStop += action;
        }

        public void UnsubscribeToStart(Action action)
        {
            OnStop -= action;
        }

        public void UnsubscribeToStop(Action action)
        {
            OnStop -= action;
        }
        #endregion

        public async void PushBack(Vector3 collisionPoint)
        {
            Vector3 direction = (collisionPoint - _mover.CurrentPosition).normalized;
            Vector3 allowedPos = collisionPoint - direction * _settings.DeadZone;
            await _mover.MoveOnly(allowedPos);
            OnStop?.Invoke();
        }
        public void Stop()
        {
            _mover.StopAll();
            OnStop?.Invoke();
        }


    }



}