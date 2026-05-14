#if USE_MORNSTATE || USE_ARBOR
#if USE_MORNSTATE
using MornLib;
using StateBehaviour = MornLib.MornStateBehaviour;
#elif USE_ARBOR
using Arbor;
#endif
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornLib
{
    [Serializable]
    public class RollbackSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneRollbackKey _key;
        [SerializeField] private LoadSceneMode _loadSceneMode;

        public override void OnStateBegin()
        {
            if (_key.TryGetRollbackScene(out var sceneName))
            {
                SceneManager.LoadSceneAsync(sceneName, _loadSceneMode);
            }
            else
            {
                MornSceneGlobal.Logger.LogError($"RollbackSceneAction: Not found scene key: {_key}");
            }
        }
    }
}
#endif // USE_MORNSTATE || USE_ARBOR
