using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Lyre;

namespace NativeMessaging
{
   class Program
   {
      private static async Task Main(string[] args)
      {

         var host = new NativeMessagingHost();
         String strHostName = string.Empty;
         IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
         IPAddress[] addr = ipEntry.AddressList;
         String address = addr[1].ToString();


         try
         {
            while (true)
            {
               var response = await host.Read<dynamic>();

               if (response.command == "GET_IP")
               {
                  // Get the Name of HOST  

                  await host.Write(new { message = $"{address}" });
               }
               else
               {
                  await host.Write(new { message = $"Invalid Command!" });
               }
               // Echo response
               //await host.Write(new { value = $"You said {response.value} at {response.dateTime}", dateTime = DateTime.Now });
            }
         }
         catch (EndOfStreamException)
         {
            // Disconnected
         }
         catch (Exception exception)
         {
            await host.Write(new Message($"Error: {exception}"));

            Console.WriteLine($"Oh 💩: {exception}");
            Environment.FailFast("Oh 💩", exception);
         }

      }
   }
}