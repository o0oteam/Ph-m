using System;
using System.Net;
using System.Text;
using Assets.Scripts.Networking.Interfaces;
using Assets.Scripts.Networking.MessageObjects.Implements;
using Assets.Scripts.Networking.MessageObjects.Interfaces;
using Mina.Core.Session;
using Mina.Filter.Codec;
using Mina.Filter.Codec.TextLine;
using Mina.Filter.Logging;
using Mina.Transport.Socket;
using UnityEngine;

namespace Assets.Scripts.Networking
{
    public class Networking
    {
		public string IpAddress = "104.155.238.125";
		
        private static Networking _instance;
        public static Networking Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new Networking();
                }
                return _instance;
            }
        }


        private  IoSession session;
        private  INetworkListener listener;
        

        private Networking()
        {
            State = ConnectingState.NeverConnect;    
        }
        


        public enum ConnectingState
        {            
            NeverConnect,
            Connecting,
            Connected,
            Disconnected,
        }

        private ConnectingState _state;
        public ConnectingState State {
            get
            {
                return _state;;
            }
            set
            {
                Debug.LogWarning(string.Format("Changed from state: {0} to state: {1}",_state, value));
                _state = value;
            } }
        public  void SetListener(INetworkListener listener)
        {
            if (listener != null)
            {
                this.listener = listener;
                State = ConnectingState.NeverConnect;
                Connect();
            }
        }
        private void Connect()
        {
            var connector = new AsyncSocketConnector();
            connector.FilterChain.AddLast("codec", new ProtocolCodecFilter(new TextLineCodecFactory(Encoding.UTF8)));            
            connector.FilterChain.AddLast("logger", new LoggingFilter());

            connector.ConnectTimeoutInMillis = 10000;
            connector.SessionConfig.KeepAlive = true;
            connector.SessionConfig.SendBufferSize = 1024;
            connector.SessionConfig.ReceiveBufferSize = 1024 * 3;
            connector.MessageReceived += Connector_MessageReceived;
            connector.MessageSent += Connector_MessageSent;
            connector.SessionOpened += Connector_SessionOpened;
            connector.SessionClosed += Connector_SessionClosed;            
			IPAddress address = IPAddress.Parse(IpAddress);            
            for (var i = 0; i < 5; i++)
            {
                try
                {
                    var connectFuture = connector.Connect(new IPEndPoint(address, 6667));//.Await();
                    State = ConnectingState.Connecting;
                    Debug.LogWarning("Session: " + connectFuture.Session);
                    return;
                }catch(Exception e)
                {
					Debug.LogWarning("Error on connect: \n" + e.StackTrace);
                }
            }
        }

        private void Connector_SessionClosed(object sender, IoSessionEventArgs e)
        {
            State = ConnectingState.Disconnected;
        }

        private void Connector_SessionOpened(object sender, Mina.Core.Session.IoSessionEventArgs e)
        {
            session = e.Session;
            State = ConnectingState.Connected;
        }

        private void Connector_MessageSent(object sender, Mina.Core.Session.IoSessionMessageEventArgs e)
        {
            
        }

        private void Connector_MessageReceived(object sender, Mina.Core.Session.IoSessionMessageEventArgs e)
        {
            if (listener != null)
            {
                IPacket packet = Packet.GetPacket(e.Message.ToString());
                if (packet != null)
                {
                    listener.HandleMessage(packet);
                }
            }
        }

        public bool SendMessage(IPacket packet)
        {
            if (session == null)
            {
                return false;
            }
            var message = packet.Build();
            session.Write(message).Await();
            return true;
        }
    }
}
