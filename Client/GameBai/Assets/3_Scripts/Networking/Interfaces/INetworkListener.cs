using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Networking.MessageObjects.Interfaces;
using JetBrains.Annotations;

namespace Assets.Scripts.Networking.Interfaces
{
     public interface INetworkListener
     {
         void HandleMessage(IPacket packet);
     }
}
