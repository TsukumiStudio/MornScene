#if USE_ARBOR || USE_MORNSTATE
#if USE_ARBOR
using Arbor;
#elif USE_MORNSTATE
using MornLib;
using StateBehaviour = MornLib.MornStateBehaviour;
using StateLink = MornLib.StateLink;
#endif
using UnityEngine.SceneManagement;
using System;

namespace MornLib
{
    [Serializable]
    public class ReloadSceneState : StateBehaviour
    {
        public override void OnStateBegin()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
#endif
