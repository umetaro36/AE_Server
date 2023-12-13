using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Net.WebSockets;
using WebSocketSharp.Server;

//namespace WebSocketSharp.Server
//{
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

    //public void LoadScene()
    //{
    //    server.WebSocketServices["/"].Sessions.Broadcast("シーン変える");
    //    Debug.Log("シーン変える");
    //}
        
    }

//}

//public class ToClient : WebSocketBehavior
//{
//    Sessions.Broadcast(e.Data);
//}

    public class Echo : WebSocketBehavior
    {
        protected override void OnOpen()
        //接続時に呼ばれる
        {
            Debug.Log("<color=cyan>接続</color>");
        }
        protected override void OnMessage(MessageEventArgs e)
        //データ受信時に呼ばれる
        {
            Debug.Log(e.Data);
            Sessions.Broadcast(e.Data);
        }
        //protected void Send(byte[] data)
        //{
        //    if (server == null)
        //    {
        //        var msg = "The session has not started yet.";

        //        throw new InvalidOperationException(msg);
        //    }

        //    server.Send(data);
        //}
    }
//}
