using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class ResponseMODEL
    {
        public bool IsApproved { get; set; }

        public string TittleMessage { get; set; }

        public string ShortMessage { get; set; }

        public string DetailedMessage { get; set; }

        public dynamic ObjectResult { get; set; }

        public static ResponseMODEL Instance(bool _IsApproved, string _TittleMessage, string _ShortMessage, string _DetailedMessage = "", dynamic _ObjectResult = null)
        {
            ResponseMODEL model = new ResponseMODEL
            {
                IsApproved = _IsApproved,
                TittleMessage = _TittleMessage,
                ShortMessage = _ShortMessage,
                DetailedMessage = _DetailedMessage,
                ObjectResult = _ObjectResult
            };
            return model;
        }
    }

}

