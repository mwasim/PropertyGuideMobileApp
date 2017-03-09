using Ninject;
using PropertyGuide.DataAccessLayer;
using PropertyGuide.DataLayer;
using PropertyGuide.DataLayer.Contracts;
using PropertyGuide.DataAccessLayer.Contracts;
using PropertyGuide.Flickr.Contracts;

namespace PropertyGuide.Infrastructure
{
    public static class IoCContainer
    {
        static IKernel kernel = new StandardKernel();

        public static void Initialize()
        {
            kernel.Bind<IUserRepositoryAsync>().To<UserRepositoryAsync>();
            kernel.Bind<IUserTypeRepositoryAsync>().To<UserTypeRepositoryAsync>();
            kernel.Bind<IPropertyRepositoryAsync>().To<PropertyRepositoryAsync>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IUserTypeRepository>().To<UserTypeRepository>();
            kernel.Bind<IPropertyRepository>().To<PropertyRepository>();

            kernel.Bind<IUserTypeDatabaseAsync>()
                .To<UserTypeDatabaseAsync>()
                .WithConstructorArgument(CommonUtils.Utils.DatabaseFilePath);
            kernel.Bind<IUserDatabaseAsync>()
                .To<UserDatabaseAsync>()
                .WithConstructorArgument(CommonUtils.Utils.DatabaseFilePath);
            kernel.Bind<IPropertyDatabaseAsync>()
                .To<PropertyDatabaseAsync>()
                .WithConstructorArgument(CommonUtils.Utils.DatabaseFilePath);

            kernel.Bind<IUserTypeDatabase>()
               .To<UserTypeDatabase>()
               .WithConstructorArgument(CommonUtils.Utils.DatabaseFilePath);
            kernel.Bind<IUserDatabase>()
                .To<UserDatabase>()
                .WithConstructorArgument(CommonUtils.Utils.DatabaseFilePath);
            kernel.Bind<IPropertyDatabase>()
                .To<PropertyDatabase>()
                .WithConstructorArgument(CommonUtils.Utils.DatabaseFilePath);

            kernel.Bind<IFlickrRequest>().To<Flickr.FlickrRequest>();
        }

        public static T Get<T>()
        {
            return kernel.Get<T>();
        }
    }
}
