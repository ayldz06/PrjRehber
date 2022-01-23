using Experimental.System.Messaging;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RaporApi.context;
using RaporApi.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RaporApi
{
    public class msqm : BackgroundService
    {
        private const string QueueName = @".\private$\KonumRaporMQ";
        private string urlRaporBilgileri = "https://localhost:44396/api/Rapor";

        private MessageQueue GetMQueye()
        {
            MessageQueue queue = null;
            if (MessageQueue.Exists(QueueName))
            {
                queue = new MessageQueue(QueueName);
            }
            else
            {
                try
                {
                    queue = MessageQueue.Create(QueueName, true);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return queue;
        }

        public bool msmqGet()
        {
            bool result = false;
            try
            {
                MessageQueue queue;
                queue = GetMQueye();
                Message _message = new Message();
                _message.Body = "Rapor";
                _message.Label = "Rapor Talep Edildi";
                _message.Recoverable = true;
                _message.TimeToBeReceived = new TimeSpan(1, 0, 0);
                _message.UseDeadLetterQueue = true;
                queue.Send(_message, MessageQueueTransactionType.Single);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public Task listeningMSMQAsync()
        {
            MessageQueue queue = GetMQueye();
            if (queue.CanRead)
            {
                using (MessageQueueTransaction tran = new MessageQueueTransaction())
                {
                    Message msg;
                      try { msg= queue.Receive(tran); _ = GetRporDatalariAsync(); } catch { msg = null; };
                }
            }
          
            return Task.CompletedTask;
        }

        public async Task<List<KonumRapor>> GetRporDatalariAsync()
        {
            List<KonumRapor> _konumRapor = new List<KonumRapor>();
            using var client = new HttpClient();
            var response = await client.GetAsync(urlRaporBilgileri);
            string result = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<KonumRapor>>(result);
            List<KonumRapor> list = await Task.Run(() => data.ToList());
            return list;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _ = listeningMSMQAsync();
                   await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
