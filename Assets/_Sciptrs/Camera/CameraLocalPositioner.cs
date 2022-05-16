using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame
{
    public class CameraLocalPositioner : CameraCheckpointPositioner
    {
        [SerializeField] private bool _useInitPos = false;
        [SerializeField] private Transform _initialPosition;

        [SerializeField] private bool _useFinishPos = false;
        [SerializeField] private Transform _levelFinishPosition;

        [SerializeField] private bool _useDefaultPos = false;
        [SerializeField] private Transform _defaultPostion;
        [SerializeField] private float _moveTime = 0.5f;
        private CameraMoverBase _mover;
        public override void Init(CameraMoverBase mover)
        {
            _mover = mover;
        }

        public override void SetInitialPosition()
        {
            if (!_useInitPos)
                return;
            if (_initialPosition != null)
                _mover?.SetPositionLocal(_initialPosition.localPosition, _initialPosition.localRotation, _moveTime);
        }
        public override void SetFinishPosition()
        {
            if (!_useFinishPos)
                return;
            if (_levelFinishPosition != null)
                _mover?.SetPositionLocal(_levelFinishPosition.localPosition, _levelFinishPosition.localRotation, _moveTime);

        }
        public override void SetDefaultPosition()
        {
            if (!_useDefaultPos)
                return;
            if(_defaultPostion != null)
                _mover?.SetPositionLocal(_defaultPostion.localPosition, _defaultPostion.localRotation, _moveTime);

        }

    }
}