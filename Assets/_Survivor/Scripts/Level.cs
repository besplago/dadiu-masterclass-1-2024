using UnityEngine;
using UnityEngine.Assertions;

namespace _Survivor.Scripts
{
    public class Level : MonoBehaviour
    {
        public static LevelConfig CurrentLevel { get; private set; }

        [RuntimeInitializeOnLoadMethod]
        private static void ResetDomain()
        {
            CurrentLevel = null;
        }

        [SerializeField] private LevelConfig config;


        private void Awake()
        {
            Assert.IsNotNull(config, "Missing level config");
            CurrentLevel = config;
        }

        private void Start()
        {
            var hero = Hero.Instance;
            Assert.IsNotNull(hero, "missing hero");

            var spawnPoint = FindAnyObjectByType<HeroSpawnPoint>();
            Assert.IsNotNull(spawnPoint, "Missing HeroSpawnPoint");
            hero.Teleport(spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }
}