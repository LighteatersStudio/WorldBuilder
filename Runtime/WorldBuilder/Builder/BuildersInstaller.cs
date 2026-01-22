using BusinessLogic.WorldBuilder.AddressablesManagement;
using BusinessLogic.WorldBuilder.EntityNode;
using UnityEngine;
using Zenject;

namespace BusinessLogic.WorldBuilder.Builder
{
    public abstract class BuildersInstaller : Installer
    {
        private IAssetPathBuilder _commonAssetPathBuilder;
        private IAssetPathBuilder CommonAssetPathBuilder =>
            _commonAssetPathBuilder ??= new CommonAssetPathBuilder(Container.Resolve<BundleName>());
        
        private AddressablesLoader _addressablesLoader;
        private AddressablesLoader AddressablesLoader => _addressablesLoader ??= new AddressablesLoader();

        public override void InstallBindings()
        {
            InstallEntityBuilder<PlaceholderNodeController, AddressablesLoader, PlaceholderEntityInstaller>(
                CommonAssetPathBuilder, AddressablesLoader);
            
            InstallCustomBuilders();
        }
        
        protected void InstallEntityBuilder<TEntity>()
        {
            InstallEntityBuilder<TEntity, AddressablesLoader, EntityInstaller<TEntity>>(CommonAssetPathBuilder, AddressablesLoader);
        }
        
        protected void InstallEntityBuilder<TEntity>(IAssetPathBuilder assetPathBuilder)
        {
            InstallEntityBuilder<TEntity,AddressablesLoader,  EntityInstaller<TEntity>>(assetPathBuilder, AddressablesLoader);
        }
        
        protected void InstallEntityBuilder<TEntity, TPrefabLoader, TInstaller>(IAssetPathBuilder assetPathBuilder, TPrefabLoader prefabLoader) 
            where TInstaller : InstallerBase 
            where TPrefabLoader : IPrefabLoader
        {
            
            Container.BindFactory<GameObject, Transform, TEntity, EntityFactory<TEntity>>()
                .FromSubContainerResolve()
                .ByInstaller<TInstaller>()
                .AsSingle();

            Container.Bind<EntityBuilder<TEntity, TPrefabLoader>>()
                .FromNew()
                .AsTransient()
                .WithArguments(assetPathBuilder, prefabLoader);
        }
        
        protected void InstallEntityBuilderWithContext<TEntity, TContext>()
        {
            InstallEntityBuilderWithContext<TEntity, AddressablesLoader,TContext, EntityInstaller<TEntity, TContext>>(CommonAssetPathBuilder, AddressablesLoader);
        }
        
        protected void InstallEntityBuilderWithContext<TEntity, TContext>(IAssetPathBuilder assetPathBuilder)
        {
            InstallEntityBuilderWithContext<TEntity, AddressablesLoader, TContext, EntityInstaller<TEntity, TContext>>(assetPathBuilder, AddressablesLoader);
        }

        protected void InstallEntityBuilderWithContext<TEntity, TPrefabLoader, TContext, TInstaller>(
            IAssetPathBuilder assetPathBuilder, TPrefabLoader prefabLoader)
            where TInstaller : InstallerBase
            where TPrefabLoader : IPrefabLoader
        {

            Container.BindFactory<GameObject, Transform, TContext, TEntity, EntityFactory<TEntity, TContext>>()
                .FromSubContainerResolve()
                .ByInstaller<TInstaller>()
                .AsSingle();

            Container.Bind<EntityBuilder<TEntity, TPrefabLoader, TContext>>()
                .FromNew()
                .AsTransient()
                .WithArguments(assetPathBuilder, prefabLoader);
        }

        protected abstract void InstallCustomBuilders();
    }
}