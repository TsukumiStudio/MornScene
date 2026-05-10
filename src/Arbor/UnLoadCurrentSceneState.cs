#if USE_ARBOR || USE_MORNSTATE
#if USE_ARBOR
using Arbor;
#elif USE_MORNSTATE
using MornLib;
using StateBehaviour = MornLib.MornStateBehaviour;
#endif
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace MornLib
{
    [Serializable]
    public class UnLoadCurrentSceneState : StateBehaviour
    {
        [SerializeField] private StateLink _next;
        private AsyncOperation _task;

        public override void OnStateBegin()
        {
            _task = SceneManager.UnloadSceneAsync(gameObject.scene);
        }

        public override void OnStateUpdate()
        {
            if (_task == null || _task.isDone)
                Transition(_next);
        }
    }
}
#endif
