using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Survivor.Scripts
{
    [CreateAssetMenu(menuName = "Game/Level")]
    public class LevelConfig : ScriptableObject
    {
        public string sceneName;

        public async void LoadLevel()
        {
            Debug.Log("Loading level " + name, this);

            if (!SceneManager.GetSceneByName("Game").isLoaded)
            {
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
            }

            if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                if (asyncLoad != null)
                {
                    asyncLoad.allowSceneActivation = true;

                    while (!asyncLoad.isDone)
                    {
                        await Task.Yield();
                    }
                }
            }

            var gameScene = SceneManager.GetSceneByName("Game");
            if (gameScene.IsValid())
            {
                SceneManager.SetActiveScene(gameScene);
            }
            else
            {
                Debug.LogWarning("Game Scene is not loaded");
            }
        }
    }
}