using Project.Tools.Help;
using Zenject;

namespace Project.Installer
{
    public class ProjectContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AddressableLoader>().AsSingle();
        }
    }
}
