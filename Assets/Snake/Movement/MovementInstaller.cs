using Zenject;

namespace Snake
{
    public class MovementInstaller : MonoInstaller<MovementInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<MovementHandler>()
                .AsSingle();
        }
    }
}