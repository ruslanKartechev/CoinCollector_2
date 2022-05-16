using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonGame.UI
{
    public class ProgressPage : PageBase
    {
        [SerializeField] protected Canvas _canvas;
        [SerializeField] protected ProgressBar _bar;

        private void Start()
        {
            HidePage();
        }

        public virtual void SetProgress(float progress)
        {
            _bar.Fill(progress);
        }

        public override void ShowPage()
        {
            _canvas.enabled = true;
        }

        public override void HidePage()
        {
            _canvas.enabled = false;

        }


    }
}