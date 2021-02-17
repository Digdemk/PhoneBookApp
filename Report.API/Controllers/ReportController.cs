using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Report.API.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Controllers
{
  
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly ReportContext _reportContext;

        private ConsumerConfig _config;
        public ReportController(ConsumerConfig config, ReportContext reportContext)
        {
            _reportContext = reportContext;
            _config = config;
        }

        [HttpGet("getmessage")]

        public IActionResult GetMessage()
        {
            using (var consumer = new ConsumerBuilder<Null, string>(_config).Build())
            {
                consumer.Subscribe("temp-topic-ex");
                while (true)
                {
                    var cr = consumer.Consume();
                    var msg = cr.Message.Value;
                    return Ok(msg);
                }
            }
        }













    }
}
