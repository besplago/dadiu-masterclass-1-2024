using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

namespace _Survivor.Scripts
{
    public class LevelLoader : MonoBehaviour
    {
        [FormerlySerializedAs("Level")] public LevelConfig level;

        private void Awake()
        {
            Assert.IsNotNull(level, "Missing Level");
            level.LoadLevel();
        }
    }
}