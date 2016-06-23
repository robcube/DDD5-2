//===============================================================================
// Copyright © 2010 Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.AspNet.SignalR.Client;

namespace QueueProcessor
{
    class InboundMessageProcessor
    {
        static HubConnection _connection;
        static IHubProxy _hubProxy;

        public static void ProcessMessage(byte[] message)
        {
            var tw = Encoding.UTF8.GetString(message);
            Console.WriteLine("InboundMessageProcessor Recieved Message: " + tw);

            var nvc = System.Web.HttpUtility.ParseQueryString(tw);

            _connection = new HubConnection("http://localhost:50852/");
            _hubProxy = _connection.CreateHubProxy("StatusHub");

            lock (_connection)
            {
                if (_connection.State == ConnectionState.Disconnected)
                {
                    _connection.Start().Wait(2000); // wait 2 seconds
                }
            }

            _hubProxy.Invoke("Send", nvc[0], nvc[1]);

            return;
        }

        public static void SaveFailedMessage(byte[] message, SqlConnection con, Exception errorInfo)
        {
            Console.WriteLine("InboundMessageProcessor Recieved Failed Message");
            return;
        }
    }
}
