using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Web.Administration;

namespace Encore.Build.Infrastructure.Services
{
    public class WebAdministrationService : IWebAdministrationService
    {
        ServerManager _serverManager;

        public WebAdministrationService()
        {
            _serverManager = new ServerManager();
        }

        public void StartSite(string siteName)
        {
            _serverManager.Sites.FirstOrDefault(s => s.Name == siteName).Start();
        }

        public void StopSite(string siteName)
        {
            _serverManager.Sites.FirstOrDefault(s => s.Name == siteName).Stop();
        }
    }
}
