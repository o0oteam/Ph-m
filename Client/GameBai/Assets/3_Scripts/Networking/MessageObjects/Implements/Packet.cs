using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Assets.Scripts.Networking.MessageObjects.Interfaces;
using Assets.Scripts.Utils;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.Networking.MessageObjects.Implements
{
    public abstract class Packet : IPacket
    {
        public const int OK = 0;
        public const int SYSTEM_TYPE = 1;
        public const int ROOM_TYPE = 2;
        public const int GAME_TYPE = 3;

        public int type { get; private set; }
        public int id { get; private set; }

        public int resultCode { get; set; }

        public string debugMessage { get; set; }

        
        public Packet(int type, int id)
        {
            this.type = type;
            this.id = id;
        }
       

        public string Build()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Packet GetPacket(string data)
        {
            //Packet packet = JsonConvert.DeserializeObject<Packet>(data);
            var jsonObject = JSON.Parse(data);
            int packetId = jsonObject["id"].AsInt;
            int packetType = jsonObject["type"].AsInt;
            
            Type type = GetPacketType(packetId, packetType);
            if (type != null)
            {
                return JsonConvert.DeserializeObject(data, type) as Packet;
            }
            return null;

        }

        public static Type GetPacketType(int type, int id)
        {
            switch (type)
            {
                case SYSTEM_TYPE:
                    return SystemPacket.GetPacketType(id);
            }
            return null;
        }
    }
}
