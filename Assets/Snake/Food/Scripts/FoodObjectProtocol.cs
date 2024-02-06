namespace Snake
{
    public struct FoodObjectProtocol
    {
        public FoodModel FoodModel;
        public SceneObjectProtocol SceneObjectProtocol;

        public FoodObjectProtocol(
            FoodModel foodModel,
            SceneObjectProtocol sceneObjectProtocol = new SceneObjectProtocol())
        {
            FoodModel = foodModel;
            SceneObjectProtocol = sceneObjectProtocol;
        }
    }
}