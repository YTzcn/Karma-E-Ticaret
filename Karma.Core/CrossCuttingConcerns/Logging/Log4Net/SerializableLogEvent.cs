using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;

namespace Karma.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        //public object Message => _loggingEvent.MessageObject;
        //public string UserNamae => _loggingEvent.UserName;
        public object logDetail => _loggingEvent.MessageObject;
        public DateTime log_date => DateTime.Now;
        public object audit => _loggingEvent.Level;

    }
}
