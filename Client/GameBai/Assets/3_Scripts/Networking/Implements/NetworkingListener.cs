using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Networking.Interfaces;
using Assets.Scripts.Networking.MessageObjects.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Networking.Implements
{
    public class NetworkingListener : MonoBehaviour, INetworkListener
    {

        private Queue<IPacket> _queue; 
        void Awake()
        {
            _queue = new Queue<IPacket>();
            Networking.Instance.SetListener(this);            
        }

        void Update()
        {
            while (_queue.Count > 0)
            {
                IPacket packet = _queue.Dequeue();
                if (packet != null)
                {
                    //SendMessage("ReceivePacket", packet);
                    var packetListeners = GameObject.FindObjectsOfType<PacketListener>();
                    if (packetListeners != null && packetListeners.Length > 0)
                    {
                        foreach (var listener in packetListeners)
                        {
                            listener.AcceptPacket(packet);   
                        }
                    }
                }
            }
        }

        public void HandleMessage(IPacket packet)
        {
            _queue.Enqueue(packet);
        }
    }
}
