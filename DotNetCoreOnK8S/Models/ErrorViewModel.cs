using System;

namespace DotNetCoreOnK8S.Models
{
    public class ErrorViewModel:BaseViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
