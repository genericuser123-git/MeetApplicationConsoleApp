using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MeetAppProgram
{
    class Menu
    {
        public List<string> variants;

        public Menu ()
        {
            variants = new List<string>();
            variants.Add("1. Создать встречу");
            variants.Add("2. Отменить встречу");
            variants.Add("3. Добавить участника");
            variants.Add("4. Удалить участника");
            variants.Add("5. Вывести список встреч");
        }

        public void Print()
        {
            Console.WriteLine("Выберите действие:");
            foreach (string action in variants)
            {
                Console.WriteLine(action);
            }
        }

        public void PostNewMeeting(RestClient client)
        {

            Console.WriteLine("Введите название встречи:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите число (в формате DD):");
            string day = Console.ReadLine();
            Console.WriteLine("Введите месяц (в формате MM):");
            string month = Console.ReadLine();
            Console.WriteLine("Введите год (в формате YYYY):");
            string year = Console.ReadLine();
            Console.WriteLine("Введите время - часы (в формате HH):");
            string hour = Console.ReadLine();
            Console.WriteLine("Введите время - минуты (в формате MM):");
            string minutes = Console.ReadLine();

            var request = new RestRequest(String.Concat("/PostNewMeeting/",name,"/",year,"/",month,"/",day,"/",hour,"/",minutes), Method.POST);
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Запрос выполнен успешно!");
            }
            else
            {
                Console.WriteLine("Произошла ошибка!");
            }

        }


        public void AddNewParticipant(RestClient client)
        {
            Console.WriteLine("Введите имя нового участника:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите e-mail нового участника:");
            string mail = Console.ReadLine();
            Console.WriteLine("Введите id встречи");
            string meetingid = Console.ReadLine();
            var request = new RestRequest(String.Concat("/AddNewParticipant/",  name, "/", mail, "/", meetingid), Method.POST);
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Запрос выполнен успешно!");
            }
            else
            {
                Console.WriteLine("Произошла ошибка!");
            }
        }

        public void DeactivateMeeting(RestClient client)
        {
            Console.WriteLine("Введите номер встречи в БД:");
            string id = Console.ReadLine();
            var request = new RestRequest(String.Concat("/UpdateMeetingState/", id), Method.POST);
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Запрос выполнен успешно!");
            }
            else
            {
                Console.WriteLine("Произошла ошибка!");
            }
        }



        public void DeleteParticipant(RestClient client)
        {
            Console.WriteLine("Введите номер участника в БД:");
            string id = Console.ReadLine();
            var request = new RestRequest(String.Concat("/DeleteParticipant/", id), Method.POST);
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Запрос выполнен успешно!");
            }
            else
            {
                Console.WriteLine("Произошла ошибка!");
            }
        }

        public void RequestAllMeetings(RestClient client)
        {
                    var request = new RestRequest("", Method.POST);
                    request.RequestFormat = DataFormat.Json;
                    var response = client.Get(request);
                    Console.WriteLine("Список встреч с участниками:");
                    Console.WriteLine(response.Content);
            

        }
    }
}
