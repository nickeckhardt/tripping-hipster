using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using Encore.Build.Infrastructure.Services;

namespace Encore.Build.Service
{
    public class BuildServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWebAdministrationService>().To<WebAdministrationService>();
        }
    }
}
