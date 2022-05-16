
using UnityEngine;
using CommonGame.Events;
namespace CommonGame.Sound
{
    public class MySoundEffect : MonoBehaviour, ISoundEffect
    {
        public string SoundName;
        public SoundFXChannelSO _soundChannel;

        public void PlayEffectOnce()
        {
            _soundChannel?.RaisePlay(SoundName);
        }

        public void StartEffect()
        {
            _soundChannel?.RaiseStartLoop(SoundName);
        }

        public void StopEffect()
        {
            _soundChannel?.RaiseStopLoop(SoundName);
        }
    }
}