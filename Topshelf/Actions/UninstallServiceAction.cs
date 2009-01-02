// Copyright 2007-2008 The Apache Software Foundation.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Topshelf.Actions
{
    using log4net;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// Uninstalls the host as a win service
    /// </summary>
    public class UninstallServiceAction :
        IAction
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(UninstallServiceAction));

        public void Do(IInstallationConfiguration configuration, IServiceLocator serviceLocator)
        {
            if(!HostServiceInstaller.IsInstalled(configuration))
            {
                string message = string.Format("The {0} service has not been installed.", configuration.Settings.ServiceName);
                _log.Error(message);

                return;
            }

            _log.Info("Received serice uninstall notification");
            new HostServiceInstaller(configuration)
                .Unregister();
        }
    }
}