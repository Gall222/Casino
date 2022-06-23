using Components;
using Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class Startup : MonoBehaviour
    {
        public StaticData staticData;
        public SceneDataComponent sceneData;
        EcsWorld world;
        EcsSystems systems;

        void Start()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);

            systems
                .Add(new GameInitSystem())
                .Add(new HoldersSystem())
                .Add(new MoveSystem())
                .Add(new ScoreSystem())
                .Inject(staticData)
                .Inject(sceneData)
                .Init();

        }


        void Update()
        {
            systems.Run();
        }

        private void OnDestroy()
        {
            systems.Destroy();
            world.Destroy();
        }
    }
}