﻿using log4net.Core;
using System;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public string UserName => _loggingEvent.UserName;
        public object MessageObj => _loggingEvent.MessageObject;
    }
}