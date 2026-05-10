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
    public class ChangeSceneState : StateBehaviour
    {
        [SerializeField, NoLabel] private MornSceneType _scene;

        public override void OnStateBegin()
        {
            if (SceneManager.sceneCount > 1)
            {
                SceneManager.UnloadSceneAsync(gameObject.scene);
                SceneManager.LoadScene(_scene.ToScene(), LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.LoadScene(_scene.ToScene());
            }
        }
    }
}
