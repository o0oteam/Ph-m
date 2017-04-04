using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Networking.MessageObjects.Implements.Login
{
    public class LoginPacket : SystemPacket
    {

        public string username;
        public string password;

        public LoginPacket() : base(LOGIN_PACKET_ID)
        {
            
        }
    }
}
