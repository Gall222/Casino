using Leopotam.Ecs;
using Components;
using UnityEngine;
using Data;
using System.Collections.Generic;

namespace Systems
{
    public class GameInitSystem : IEcsInitSystem
    {
        EcsWorld _world;
        private SceneDataComponent _sceneData;

        public void Init()
        {
            _sceneData.SetScore(10);
            CreateHolders();
        }

        private void CreateHolders()
        {
            var topHolder = _world.NewEntity();
            ref HolderComponent topHolderComponent = ref topHolder.Get<HolderComponent>();
            var topHolredView = _sceneData.TopItemsHolderContent.GetComponent<HolderView>();
            topHolderComponent.direction = Vector3.left;
            topHolderComponent.content = topHolredView.content;
            topHolderComponent.transform = _sceneData.TopItemsHolderContent.transform;
            topHolderComponent.items = new List<ItemMovableComponent>();
            topHolderComponent.stopPosition = topHolredView.stopPosition.gameObject;
            
            var bottomHolder = _world.NewEntity();
            ref HolderComponent bottomHolderComponent = ref bottomHolder.Get<HolderComponent>();
            var bottomHolredView = _sceneData.BottomItemsHolderContent.GetComponent<HolderView>();
            bottomHolderComponent.direction = Vector3.right;
            bottomHolderComponent.content = bottomHolredView.content;
            bottomHolderComponent.transform = _sceneData.BottomItemsHolderContent.transform;
            bottomHolderComponent.items = new List<ItemMovableComponent>();
            bottomHolderComponent.stopPosition = bottomHolredView.stopPosition.gameObject;
        }
    }
}