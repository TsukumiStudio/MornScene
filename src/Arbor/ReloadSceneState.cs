#if USE_ARBOR
using Arbor;
#else
using MornLib;
using StateBehaviour = MornLib.MornStateBehaviour;
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
