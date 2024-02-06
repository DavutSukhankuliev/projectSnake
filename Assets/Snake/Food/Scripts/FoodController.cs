using System.Collections.Generic;
using Zenject;

namespace Snake
{
    public class FoodController
    {
        private readonly IInstantiator _instantiator;
        private readonly FoodConfig _config;

        private List<FoodCreateCommand> _foods = new List<FoodCreateCommand>();

        public FoodController(
            IInstantiator instantiator,
            FoodConfig config)
        {
            _instantiator = instantiator;
            _config = config;
        }

        public void CreateFood(string id)
        {
            var foodmodel = _config.Get(id);
            var sceneobject = new SceneObjectProtocol();

            var protocol = new FoodObjectProtocol(foodmodel,sceneobject);
            var command = _instantiator.Instantiate<FoodCreateCommand>(new object[] { protocol });
            command.Execute();
            
            _foods.Add(command);
        }
    }
}