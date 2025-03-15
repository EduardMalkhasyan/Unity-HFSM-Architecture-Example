using Project.Player.State;
using Project.State;
using Project.Tools.Help;
using Sirenix.Utilities;
using System.Reflection;
using Zenject;

namespace Project.Installer
{
    public class SceneContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallAssemblyTypes<AbstractMainGameState>(ScopeTypes.Singleton);
            InstallAssemblyTypes<AbstractPlayerGameState>(ScopeTypes.Singleton);
        }

        private void InstallAssemblyTypes<T>(ScopeTypes scopeTypes)
        {
            var assembly = Assembly.GetAssembly(typeof(T));

            FindAssemblyTypes.FindDerivedTypesFromAssembly(assembly, typeof(T), true).ForEach(
                 (type) =>
                 {
                     if (type.IsAbstract == false)
                     {
                         Container.UnbindInterfacesTo(type);

                         switch (scopeTypes)
                         {
                             case ScopeTypes.Unset:
                                 Container.BindInterfacesAndSelfTo(type);
                                 break;
                             case ScopeTypes.Transient:
                                 Container.BindInterfacesAndSelfTo(type).AsTransient();
                                 break;
                             case ScopeTypes.Singleton:
                                 Container.BindInterfacesAndSelfTo(type).AsSingle();
                                 break;
                         }
                     }
                 });
        }
    }
}

