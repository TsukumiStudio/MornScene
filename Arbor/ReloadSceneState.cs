#if USE_ARBOR
using Arbor;
using UnityEngine.SceneManagement;

namespace MornLib
{
    public class ReloadSceneState : StateBehaviour
    {
        public override void OnStateBegin()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
#endif