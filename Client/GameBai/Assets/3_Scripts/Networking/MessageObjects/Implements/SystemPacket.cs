using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Networking.MessageObjects.Implements.Login;

namespace Assets.Scripts.Networking.MessageObjects.Implements
{
    public abstract class SystemPacket : Packet
    {

        public const int LOGIN_PACKET_ID = 1;
        public const int REGISTER_PACKET_ID = 2;

        public SystemPacket(int id) : base(SYSTEM_TYPE, id) 
        {            
        }

        public static Type GetPacketType(int id)
        {
            switch (id)
            {
                case LOGIN_PACKET_ID:
                    return typeof (LoginPacket);
            }
            return null;
        }
        
    }
}
