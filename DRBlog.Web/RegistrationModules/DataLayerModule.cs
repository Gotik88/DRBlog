using DRBlog.Core.Data;
using DRBlog.Core.Infrastructure.DependencyInjection;
using DRBlog.Core.Infrastructure.DependencyInjection.Module;
using DRBlog.Data;

namespace DRBlog.Web.Modules
{
    public class DataLayerModule : IIoCModule
    {
        public void Load(IoCContainer container)
        {
            // var dataSettingsManager = new DataSettingsManager();
            // var dataProviderSettings = dataSettingsManager.LoadSettings();
            //  builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
            // builder.Register(x => new EfDataProviderManager(x.Resolve<DataSettings>())).As<BaseDataProviderManager>().InstancePerDependency();


            // builder.Register(x => (IEfDataProvider)x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();
            //  builder.Register(x => (IEfDataProvider)x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IEfDataProvider>().InstancePerDependency();

            /* if (dataProviderSettings != null && dataProviderSettings.IsValid())
             {
                 var efDataProviderManager = new EfDataProviderManager(dataSettingsManager.LoadSettings());
                 var dataProvider = (IEfDataProvider)efDataProviderManager.LoadDataProvider();
                 dataProvider.InitConnectionFactory();

                 builder.Register<IDbContext>(c => new NopObjectContext(dataProviderSettings.DataConnectionString)).InstancePerHttpRequest();
             }
             else
             {
                 builder.Register<IDbContext>(c => new NopObjectContext(dataSettingsManager.LoadSettings().DataConnectionString)).InstancePerHttpRequest();
             }*/


            container.RegisterGeneric(typeof(EfRepository<>), typeof(IRepository<>), ComponentLifeStyle.PerWebRequest);
        }
    }
}