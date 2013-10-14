using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using Ninject;
using Encore.Build.Infrastructure.Services;

namespace Encore.Build.Service
{
    public partial class BuildService : ServiceBase
    {
        FileSystemWatcher _siteWatcher;
        static BuildService _buildService;
        static IKernel _kernel;
        private readonly IWebAdministrationService _webAdminService;

        public BuildService(IWebAdministrationService webAdminService)
        {
            _webAdminService = webAdminService;
        }

        void SiteWatcherChanged(object sender, FileSystemEventArgs e)
        {
            var siteName = new FileInfo(e.FullPath).Directory.Name;
            _webAdminService.StopSite(siteName);
            Console.WriteLine("Change");
            _webAdminService.StartSite(siteName);
        }

        static void Main(string[] args)
        {
            _kernel = new StandardKernel(new BuildServiceModule());
            _buildService = new BuildService(_kernel.Get<IWebAdministrationService>());

            if (Environment.UserInteractive)
            {
                _buildService.OnStart(args);
                Console.WriteLine("press any key to stop");
                Console.Read();
                _buildService.OnStop();
            }
            else
            {
                ServiceBase.Run(_buildService);
            }

        }

        protected override void OnStart(string[] args)
        {
            _siteWatcher = new FileSystemWatcher(@"C:\Code\Encore\Default Web Site");
            _siteWatcher.EnableRaisingEvents = true;
            _siteWatcher.Changed += new FileSystemEventHandler(SiteWatcherChanged);
        }

        protected override void OnStop()
        {
        }
    }
}
