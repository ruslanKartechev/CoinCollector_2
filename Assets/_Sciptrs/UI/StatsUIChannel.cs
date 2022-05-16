using UnityEngine;
using System;
namespace MyGame.UI
{

    [CreateAssetMenu(fileName = "StatsUIChannel", menuName = "SO/StatsUIChannel", order = 1)]

    public class StatsUIChannel : ScriptableObject
    {
        public Action<int> Update;
        public Action Show;
        public Action Hide;

        public void RaiseEventUpdate(int val)
        {
            if(Update != null)
            {
                Update.Invoke(val);
            }
            else
            {
                Debug.Log("Update action is null");
            }
        }

        public void RaiseEventShow()
        {
            if (Show != null)
            {
                Show.Invoke();
            }
            else
            {
                Debug.Log("Show action is null");
            }
        }



        public void RaiseEventHide()
        {
            if (Hide != null)
            {
                Hide.Invoke();
            }
            else
            {
                Debug.Log("Show action is null");
            }
        }
    }
}
