using System;
using System.Collections.Generic;
using System.Text;

namespace Field.BLL.Communication
{
	public interface ICommunicator
	{
		string Send(string url, string postData, string contentType);
		string SendGZip(string url, string postData, Encoding encoding, string contentType, int prvTimeOut);
		string SendWrappedGZip(string url, string postData, int prvTimeOut);
		string SendWrappedGZipRaw(string url, string postData, int prvTimeOut);
		//string SendSoap(string url, string action, string postData, string contentType);
	}
}
