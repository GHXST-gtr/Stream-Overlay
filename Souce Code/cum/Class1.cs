using BepInEx;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace StreamOverlay
{
    [BepInPlugin("org.GHXST.Stream.Overlay", "tutorialtest", "1.0.0")]
    public class Class1 : BaseUnityPlugin
    {
        private static bool Code;

        private static bool Player;

        private static bool Name;

        private static bool Gamemode;

        private void Awake()
        {
        }
        public void OnGUI()
        {
            GUI.skin.label.fontSize = 30;
            GUI.skin.label.fontStyle = FontStyle.Bold;
            GUI.color = Color.magenta;
            Code = GUI.Toggle(new Rect(5f, 5f, 110f, 20f), Code, "Code");
            Player = GUI.Toggle(new Rect(5f, 25f, 140f, 20f), Player, "Player Count");
            Name = GUI.Toggle(new Rect(5f, 45f, 110f, 20f), Name, "Name");
            Gamemode = GUI.Toggle(new Rect(5f, 65f, 130f, 20f), Gamemode, "Gamemode");
            if (Code)
                if (PhotonNetwork.InRoom)
                {
                    GUI.Label(new Rect(850f, 5f, 400f, 300f), "Current Code:" + PhotonNetwork.CurrentRoom.Name + "");
                }
                else
                {
                    GUI.Label(new Rect(850f, 5f, 400f, 300f), "Not In Room!");
                }
            if (Player)
                if (PhotonNetwork.InRoom)
                {
                    GUI.Label(new Rect(900f, 35f, 400f, 300f), "Current Player's:" + PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "");
                }
                else
                {
                    GUI.Label(new Rect(900f, 35f, 400f, 300f), " ");
                }
            if (Name)
                GUI.Label(new Rect(15f, 1035f, 120f, 60f), PhotonNetwork.LocalPlayer.NickName);
            if (Gamemode)
                if (PhotonNetwork.InRoom)
                {
                    GUI.Label(new Rect(1750f, 10f, 200f, 40f), GorillaGameManager.instance.GameMode());
                }
                else
                {
                    GUI.Label(new Rect(1750f, 10f, 200f, 40f), " ");
                }
        }

    }
}