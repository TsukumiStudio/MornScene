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
    public class WaitSceneCloseState : StateBehaviour
    {
        [SerializeField] private MornSceneType _scene;
        [SerializeField] private StateLink _next;
        private Scene _loadScene;

        public override void OnStateBegin()
        {
            _loadScene = SceneManager.GetSceneByName(_scene.ToScene());
        }

        public override void OnStateUpdate()
        {
            if (!_loadScene.isLoaded)
            {
                Transition(_next);
            }
        }
    }
}
#endif // USE_MORNSTATE || USE_ARBOR
