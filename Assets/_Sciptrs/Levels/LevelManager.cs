using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CommonGame.Events;
namespace CommonGame
{
    [ExecuteInEditMode]
    public class LevelManager : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private LevelLoader mLoader;
        [SerializeField] private LevelLoadChannelSO _levelLoadChannel;

        const string PREFS_KEY_LEVEL_ID = "CurrentLevelCount";
        const string PREFS_KEY_LAST_INDEX = "LastLevelIndex";
        public int CurrentLevelCount => PlayerPrefs.GetInt(PREFS_KEY_LEVEL_ID, 0) + 1;

        [HideInInspector] public bool editorMode = false;
        [HideInInspector] public int CurrentLevelIndex;
        [HideInInspector] public List<LevelData> Levels = new List<LevelData>();

        private void Awake()
        {
            if (_levelLoadChannel)
            {
                _levelLoadChannel.LoadNext = NextLevel;
                _levelLoadChannel.LoadLevel = LoadLevel;
                _levelLoadChannel.LoadLast = LoadLast;
                _levelLoadChannel.ReloadCurrentLevel = ReloadCurrent;
            }

        }
        private void Start()
        {
            if (mLoader == null)
                mLoader = GetComponent<SimpleLevelLoader>();
        }

        public void LoadLevel(int index)
        {
            InitLevel(index, false);
        }

        public void LoadLast()
        {
#if !UNITY_EDITOR
        editorMode = false;
#endif
            InitLevel(PlayerPrefs.GetInt("LastLevelIndex"), true);
        }
        public void ReloadCurrent()
        {
            InitLevel(CurrentLevelIndex, false);
        }
        public void NextLevel()
        {
            if (!editorMode)
                PlayerPrefs.SetInt(PREFS_KEY_LEVEL_ID, (PlayerPrefs.GetInt(PREFS_KEY_LEVEL_ID) + 1));
            InitLevel(CurrentLevelIndex + 1);
        }
        public void PrevLevel()
        {
            InitLevel(CurrentLevelIndex - 1);
        }
        public void InitLevel(int levelIndex, bool indexCheck = true)
        {
            if (indexCheck)
                levelIndex = GetCorrectedIndex(levelIndex);
            if (Levels[levelIndex].lvlPF == null)
            {
                Debug.Log("<color=red>There is no prefab attached!</color>");
                return;
            }
            var level = Levels[levelIndex];
            if (level.lvlPF)
            {
                CurrentLevelIndex = levelIndex;
                SetLevelParams(level, levelIndex);
            }
        }
        private void SetLevelParams(LevelData level,int index)
        {
            if (level.lvlPF)
            {
#if UNITY_EDITOR
                if(Application.isPlaying == false)
                {
                    mLoader.ClearLevel();
                    PrefabUtility.InstantiatePrefab(level.lvlPF, mLoader.transform);
                    return;
                }
                else
                {
                    mLoader.ClearLevel();
                    LevelStateSO state = mLoader.Load(level);
                    state.CurrentLevel = index;
                }
#else
                    mLoader.ClearLevel();
                    LevelStateSO state = mLoader.Load(level);
                    state.CurrentLevel = index;
#endif
                _levelLoadChannel.OnLevelLoaded?.Invoke(index);
                Debug.Log("on loaded update");
            }
        }

        public void ClearListAtIndex(int levelIndex)
        {
            Levels[levelIndex].lvlPF = null;
        }

        private int GetCorrectedIndex(int levelIndex)
        {
            if (editorMode)
                return levelIndex > Levels.Count - 1 || levelIndex <= 0 ? 0 : levelIndex;
            else
            {
                int levelId = PlayerPrefs.GetInt(PREFS_KEY_LEVEL_ID);
                if (levelId > Levels.Count - 1)
                {
                    if (Levels.Count > 1)
                    {
                        while (true)
                        {
                            levelId = UnityEngine.Random.Range(0, Levels.Count);
                            if (levelId != CurrentLevelIndex) return levelId;
                        }
                    }
                    else return UnityEngine.Random.Range(0, Levels.Count);
                }
                return levelId;
            }
        }
        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt("LastLevelIndex", CurrentLevelIndex);
            PlayerPrefs.Save();
        }
        private void OnDestroy()
        {
            PlayerPrefs.SetInt(PREFS_KEY_LAST_INDEX, CurrentLevelIndex);
            PlayerPrefs.Save();
        }
    }

}
