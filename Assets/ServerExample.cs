using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Net.WebSockets;
using WebSocketSharp.Server;

namespace WebSocketSharp.Server
{
    
    public class ServerExample : MonoBehaviour
    {
        
        private WebSocketServer server;

        void Start()
        {
            server = new WebSocketServer(3000);

            server.AddWebSocketService<Echo>("/");
            server.Start();
            Debug.Log("サーバ起動");

        }

        void OnDestroy()
        {
            Debug.Log("サーバ停止");
            server.Stop();
            server = null;
        }

        public void Idly()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("Idly状態に変更");
            Debug.Log("Idly状態に変更");
        }

        public void LookAtPlayer()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("LookAtPlayer状態に変更");
            Debug.Log("LookAtPlayer状態に変更");
        }

        //--------------------ここからLoadSceneOpperation(シーン遷移用)-----------------------------
        public void Break4()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("LoadScene：Break4");
            Debug.Log("シーン遷移：Break_4characters");
        }

        public void Break5()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("LoadScene：Break5");
            Debug.Log("シーン遷移：Break_5characters");
        }

        public void GazeOn100()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("LoadScene：1");
            Debug.Log("シーン遷移：100GazeOn");
        }

        public void Random()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("LoadScene：2");
            Debug.Log("シーン遷移：Random");
        }

        public void Tracking()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("LoadScene：3");
            Debug.Log("シーン遷移：Tracking");
        }

        public void Escape()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("LoadScene：4");
            Debug.Log("シーン遷移：Escape");
        }

        public void Gaze0ff100()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("LoadScene：5");
            Debug.Log("シーン遷移：100GazeOff");
        }

        public void End()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("LoadScene：6");
            Debug.Log("シーン遷移：End");
        }

        //--------------------ここから実験Introduction：Agent制御用-----------------------------
        public void EntryAgent()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("EntryAgent");
            Debug.Log("EntryAgent");
        }

        public void Explain()
        {
            server.WebSocketServices["/"].Sessions.Broadcast("Explain");
            Debug.Log("Explain");
        }

    }

    //public MessageEventArgs e;

    public class Echo : WebSocketBehavior
    {
        private DemoController demoController;

        protected override void OnOpen()   //protected override 
        //接続時に呼ばれる
        {
            Debug.Log("<color=cyan>接続</color>");
        }
        protected override void OnMessage(MessageEventArgs e)   //データ受信時に呼ばれる　
        {

            //Debug.Log(e.Data);
            //Sessions.Broadcast(e.Data);   //クライアントにデータを返信

        }
    }
    
}
