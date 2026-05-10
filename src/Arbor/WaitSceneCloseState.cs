#if USE_ARBOR
using Arbor;
#else
using MornLib;
using StateBehaviour = MornLib.MornStateBehaviour;
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
