using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Networking.MessageObjects.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Networking.Implements
{
    public abstract class PacketListener : MonoBehaviour
    {
        public void AcceptPacket(IPacket packet)
        {
            if (packet == null)
            {
                return;
            }          
            ReceivedPacket(packet);
        }

        public abstract void ReceivedPacket(IPacket packet);
    }
}
