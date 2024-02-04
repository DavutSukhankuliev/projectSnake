using SDTCore;
using Zenject;

namespace Snake
{
    public class CommandInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CommandStorage>()
                .AsSingle();
        }
    }
}