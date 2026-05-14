#if USE_MORNSTATE || USE_ARBOR
#if USE_MORNSTATE
using MornLib;
using StateBehaviour = MornLib.MornStateBehaviour;
#elif USE_ARBOR
using Arbor;
#endif
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace MornLib
{
    [Serializable]
    public class UnLoadSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneType _scene;
        [SerializeField] private StateLink _next;
        private AsyncOperation _task;

        public override void OnStateBegin()
        {
            _task = SceneManager.UnloadSceneAsync(_scene.ToScene());
        }

        public override void OnStateUpdate()
        {
            if (_task == null || _task.isDone)
            {
                Transition(_next);
            }
        }
    }
}
#endif // USE_MORNSTATE || USE_ARBOR
