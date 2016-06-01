using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAudio.Wave;
using Newtonsoft.Json.Linq;

namespace BehavioralInformatix.CallER.Client.Tests
{

    [TestClass]
    public class CallERClientTests
    {

        [TestMethod]
        public async Task TestMethod1()
        {
            var t = await GetMediaAsWav(File.OpenRead(@"C:\Users\wasabi\Downloads\Sale recordings (Sept'15)\9-1-2015_20-2_JosueMijares_6167382541_SSFV.wav"));
            var c = new CallERClient(new Uri("https://callerapi.behavioralinformatix.com:8443"), "dsJ@hw3!6@82KGw23$ns", 3526153);
            //var s = await c.PostJobAsync(
            //    new Uri("http://foo.com"),
            //    new CallERJob()
            //    {
            //        Channels = (short)t.Item2,
            //        CallDirection = CallERCallDirection.Outgoing,
            //    });
             var s = await c.GetProcessAsync(269075);
            var r = await c.GetProcessResultAsync(s.ProcessId);
            var st = JObject.FromObject(r).ToString(Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"C:\users\wasabi\out.json", st);
        }

        /// <summary>
        /// Gets the job's media PCM data.
        /// </summary>
        /// <returns></returns>
        static async Task<Tuple<byte[], int>> GetMediaAsWav(Stream src)
        {
            // convert PCM stream into WAV
            using (var dst = new MemoryStream())
            using (var pcm = new WaveFileReader(src))
            using (var cnv = new WaveFormatConversionStream(new WaveFormat(8000, 16, pcm.WaveFormat.Channels), pcm))
            using (var wav = new WaveFileWriter(dst, cnv.WaveFormat))
            {
                // run the conversion into the memory stream
                await cnv.CopyToAsync(wav, 65536 - (65536 % cnv.BlockAlign));
                await wav.FlushAsync();
                wav.Close();

                // execute the recognition
                return Tuple.Create(dst.ToArray(), cnv.WaveFormat.Channels);
            }
        }

    }

}
