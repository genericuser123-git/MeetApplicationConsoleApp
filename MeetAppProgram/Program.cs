using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Serialization;

namespace MeetAppProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new RestClient("http://localhost:64560/api/values");
            client.UseJson();

            Menu actions = new Menu();

            actions.Print();

            string var = Console.ReadLine();

                switch (var)
            {

                case "1":
                    actions.PostNewMeeting(client);
                    Console.ReadLine();
                    break;
                case "2":
                    actions.DeactivateMeeting(client);
                    Console.ReadLine();
                    break;
                case "3":
                    actions.AddNewParticipant(client);
                    Console.ReadLine();
                    break;
                case "4":
                    actions.DeleteParticipant(client);
                    Console.ReadLine();
                    break;
                case "5":
                    actions.RequestAllMeetings(client);
                    Console.ReadLine();
                    break;
            }
        }
    }
}
