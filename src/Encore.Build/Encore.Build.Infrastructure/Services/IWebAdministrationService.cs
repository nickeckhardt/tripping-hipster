using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encore.Build.Infrastructure.Services
{
    public interface IWebAdministrationService
    {
        void StartSite(string siteName);
        void StopSite(string siteName);
    }
}
