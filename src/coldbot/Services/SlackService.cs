using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LakseBot.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;

namespace LakseBot.Services
{
    public class SlackService
    {
        private static string BOT_THIES_WEBHOOK = System.Environment.GetEnvironmentVariable("BOT_THIES_WEBHOOK");
        private static string BOT_LAKSEBOT_WEBHOOK = System.Environment.GetEnvironmentVariable("BOT_LAKSEBOT_WEBHOOK");
        private static string BOT_MAGIC_WEBHOOK = System.Environment.GetEnvironmentVariable("BOT_LAKSEBOT_WEBHOOK");

        private static HttpClient client = new HttpClient();

        private readonly ILogger<SlackService> logger;
        private readonly IHostingEnvironment env;

        public SlackService(ILogger<SlackService> logger, IHostingEnvironment env)
        {
            this.logger = logger;
            this.env = env;
        }

        public async void SendMessage(string text, string channel)
        {
            string slackUrl = channelMapper(channel);

            if (!String.IsNullOrEmpty(slackUrl))
            {

                var payload = new Payload()
                {
                    Text = text
                };

                var jsonString = JsonConvert.SerializeObject(payload);

                logger.LogInformation($"Sending message to server: {jsonString}");

                jsonString = jsonString.Replace(@"\\n", @"\n");

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var slackResponse = await client.PostAsync(slackUrl, content);
            }
        }

        private string channelMapper(string channel)
        {
            if (channel.ToLower().Equals("GAC3TKTV5".ToLower()))
            {
                logger.LogInformation($"Returning laksebot webhook '{BOT_LAKSEBOT_WEBHOOK}'.");
                return BOT_LAKSEBOT_WEBHOOK;
            }
            else if (channel.ToLower().Equals("GA0Q1SLGK".ToLower()))
            {
                logger.LogInformation($"Returning magic webhook '{BOT_MAGIC_WEBHOOK}'.");
                return BOT_THIES_WEBHOOK;
            }
            else if (channel.Equals("TEST"))
            {
                logger.LogInformation($"Returning thies webhook '{BOT_THIES_WEBHOOK}'.");
                return BOT_THIES_WEBHOOK;
            }
            else
            {
                logger.LogInformation($"I do not have a webhook for channel {channel}, but I did carry out the command.");
                return String.Empty;
            }
        }
    }
}