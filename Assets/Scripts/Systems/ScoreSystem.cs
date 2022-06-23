using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class ScoreSystem : IEcsRunSystem
    {
        private SceneDataComponent sceneData;
        EcsFilter<HolderComponent, ReadyToCount> holdersFilter;

        public void Run()
        {
            GetScore();

        }

        private void GetScore()
        {
            if (holdersFilter.GetEntitiesCount() != 2) { return; }

            ref HolderComponent TopHolderComponent = ref holdersFilter.Get1(1);
            ref HolderComponent BottomHolderComponent = ref holdersFilter.Get1(0);

            int rate = 1;

            if (TopHolderComponent.items[2].itemName == BottomHolderComponent.items[0].itemName)
            {
                rate++;

            }
            if (TopHolderComponent.items[1].itemName == BottomHolderComponent.items[1].itemName)
            {
                rate++;

            }
            if (TopHolderComponent.items[0].itemName == BottomHolderComponent.items[2].itemName)
            {
                rate++;

            }
            sceneData.SetScore(sceneData.Score * rate);
            ref EcsEntity topEntity = ref holdersFilter.GetEntity(0) ;
            ref EcsEntity bottomEntity = ref holdersFilter.GetEntity(1);
            topEntity.Del<ReadyToCount>();
            bottomEntity.Del<ReadyToCount>();
            sceneData.isPlayButtonAnable = true;
        }

    }
}