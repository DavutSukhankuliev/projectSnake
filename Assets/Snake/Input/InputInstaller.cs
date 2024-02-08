using UnityEngine;
using Zenject;

namespace Snake
{
    public class InputInstaller : MonoInstaller<InputInstaller>
    {
        public override void InstallBindings()
        {
            //todo: if VR headset attached condition input
            Container
                .BindInterfacesAndSelfTo<KeyboardInput>()
                .AsSingle();
        }
    }
}