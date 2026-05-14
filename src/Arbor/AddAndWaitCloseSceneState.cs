#if USE_MORNSTATE || USE_ARBOR
#if USE_MORNSTATE
using MornLib;
using StateBehaviour = MornLib.MornStateBehaviour;
#elif USE_ARBOR
using Arbor;
#endif
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornLib
{
    [Serializable]
    public class AddAndWaitCloseSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneType _scene;
        [SerializeField] private StateLink _next;

        public override async void OnStateBegin()
        {
            await SceneManager.LoadSceneAsync(_scene.ToScene(), LoadSceneMode.Additive);
            var scene = SceneManager.GetSceneByName(_scene.ToScene());
            while (scene.isLoaded)
            {
                await UniTask.Yield(CancellationTokenOnEnd);
            }

            Transition(_next);
        }
    }
}
#endif // USE_MORNSTATE || USE_ARBOR
