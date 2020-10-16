using System;
using System.Collections.Generic;
using System.Text;

namespace Field.BLL.Communication
{
    public class Communicator : ICommunicator
    {
        public string Send(string url, string postData, string contentType)
        {
            throw new NotImplementedException();
        }

        public string SendGZip(string url, string postData, Encoding encoding, string contentType, int prvTimeOut)
        {
            throw new NotImplementedException();
        }

        public string SendWrappedGZip(string url, string postData, int prvTimeOut)
        {
            throw new NotImplementedException();
        }

        public string SendWrappedGZipRaw(string url, string postData, int prvTimeOut)
        {
            throw new NotImplementedException();
        }
    }
}
