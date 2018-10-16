using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteInput.Core.Network
{
    public class NetworkStrategyFactory
    {
        #region Singleton

        private static NetworkStrategyFactory _instance = new NetworkStrategyFactory();
        public static NetworkStrategyFactory Instance
        {
            get { return _instance; }
        }

        static NetworkStrategyFactory()
        {
        }

        private NetworkStrategyFactory()
        {
        }

        #endregion

        #region Factory Methods

        public INetworkStrategy CreateDotNetworkStrategy()
        {
            return new DotNetNetworkStrategy();
        }

        public INetworkStrategy CreateUWPworkStrategy()
        {
            return new UWPNetworkStrategy();
        }

        #endregion
    }
}
