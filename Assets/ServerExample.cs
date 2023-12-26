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

            Debug.Log(e.Data);
            //Sessions.Broadcast(e.Data);   //クライアントにデータを返信

        }
    }
    
}
