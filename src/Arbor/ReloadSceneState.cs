#if USE_ARBOR
﻿using Arbor;
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
