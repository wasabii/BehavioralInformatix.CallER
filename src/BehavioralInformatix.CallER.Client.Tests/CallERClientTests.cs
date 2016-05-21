using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BehavioralInformatix.CallER.Client.Tests
{

    [TestClass]
    public class CallERClientTests
    {

        [TestMethod]
        public async Task TestMethod1()
        {
            var c = new CallERClient(new Uri("https://callerapi.behavioralinformatix.com:8443/"), "dsJ@hw3!6@82KGw23$ns", 3526153);
            //var s = await c.PostJobAsync(
            //    new Uri("https://drive.google.com/uc?export=download&id=0Bz69ubgLdcLTMVQ4LVJwbjZtcWc"),
            //    new CallERJob()
            //    {
            //        Channels = 1,
            //        CallDirection = CallERCallDirection.Outgoing,
            //    });
            var s = await c.GetProcessAsync(269047);
            var r = await c.GetProcessResultAsync(s.ProcessId);
        }

    }

}
