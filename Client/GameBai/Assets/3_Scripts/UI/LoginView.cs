using Assets.Scripts.Networking;
using Assets.Scripts.Networking.Implements;
using Assets.Scripts.Networking.MessageObjects.Implements;
using Assets.Scripts.Networking.MessageObjects.Implements.Login;
using Assets.Scripts.Networking.MessageObjects.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class LoginView : PacketListener
    {

        public InputField UserName;
        public InputField Password;
        public Button LoginButton;
        public Text ErrorMessage;

        // Use this for initialization
        void Start () {
		    LoginButton.onClick.AddListener(Login);            
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        void Login()
        {
            Networking.Instance.SendMessage(new LoginPacket() {username = UserName.text, password = Password.text});
        }

        public override void ReceivedPacket(IPacket packet)
        {
            if (packet.GetType() == typeof (LoginPacket))
            {
                var loginPacket = packet as LoginPacket;
                if (loginPacket.resultCode != Packet.OK)
                {
                    ErrorMessage.text = loginPacket.debugMessage;
                }
                else
                {
                    ErrorMessage.text = "Login success";
                }
            }
        }
    }
}
