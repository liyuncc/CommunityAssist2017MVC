using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssist2017MVC.Models
{
    public class Message
    {
        public Message() { } //This is a constructor
        public Message(string msg) //This is a constructor
        {
            MessageText = msg;
        }
        public string MessageText { set; get; }
    }
}