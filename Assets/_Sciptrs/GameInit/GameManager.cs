using UnityEngine;
using CommonGame.Controlls;
using CommonGame.Sound;
using CommonGame.UI;
using CommonGame.Events;
using CommonGame.Data;
namespace CommonGame
{
    [DefaultExecutionOrder(-10)]
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LevelLoadChannelSO _loadChannel;
        [SerializeField] private UISystem _UISystem;
        [SerializeField] private DataGameMain _settings;
        
        private void Start()
        {
            if(_UISystem != null)
            {
                _UISystem.SelfInit = false;
                _UISystem.Init();
            }
            _loadChannel?.LoadLast();
        }
    }


}
