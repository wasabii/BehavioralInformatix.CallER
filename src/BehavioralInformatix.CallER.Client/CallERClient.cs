using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BehavioralInformatix.CallER.Client.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BehavioralInformatix.CallER.Client
{

    public class CallERClient
    {

        public const string DEFAULT_URI = "https://callerapi.behavioralinformatix.com/";

        readonly HttpClient http;
        Uri uri;
        string token;
        long clientId;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CallERClient()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="http"></param>
        /// <param name="uri"></param>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        public CallERClient(HttpClient http, Uri uri, string token, long clientId)
            : this()
        {
            Contract.Requires<ArgumentNullException>(http != null);
            Contract.Requires<ArgumentNullException>(uri != null);
            Contract.Requires<ArgumentNullException>(token != null);
            Contract.Requires<ArgumentOutOfRangeException>(clientId > 0);

            this.http = http;
            Uri = uri;
            Token = token;
            ClientId = clientId;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        public CallERClient(Uri uri, string token, long clientId)
            : this(new HttpClient(), uri, token, clientId)
        {
            Contract.Requires<ArgumentNullException>(uri != null);
            Contract.Requires<ArgumentNullException>(token != null);
            Contract.Requires<ArgumentOutOfRangeException>(clientId > 0);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        public CallERClient(string token, long clientId)
            : this(new Uri(DEFAULT_URI), token, clientId)
        {
            Contract.Requires<ArgumentNullException>(token != null);
            Contract.Requires<ArgumentOutOfRangeException>(clientId > 0);
        }

        /// <summary>
        /// Gets the URI base of the CallER API.
        /// </summary>
        public Uri Uri
        {
            get { return uri; }
            set { Contract.Requires<ArgumentNullException>(value != null); uri = value; }
        }

        /// <summary>
        /// Gets the configured authentication token.
        /// </summary>
        public string Token
        {
            get { return token; }
            set { Contract.Requires<ArgumentNullException>(value != null); token = value; }
        }

        /// <summary>
        /// Client ID with which to communicate with the CallER service.
        /// </summary>
        public long ClientId
        {
            get { return clientId; }
            set { Contract.Requires<ArgumentOutOfRangeException>(value > 0); clientId = value; }
        }

        /// <summary>
        /// Sends a <see cref="HttpRequestMessage"/> and properly handles errors.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        async Task<TResult> SendAsync<TResult>(HttpRequestMessage request)
        {
            Contract.Requires<ArgumentNullException>(request != null);

            request.Headers.Add("X-Auth-Token", Token);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // send request and return response if successful
            var response = await http.SendAsync(request);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());

            // throw response as exception
            throw new CallERErrorException(response.StatusCode, JsonConvert.DeserializeObject<CallERError>(await response.Content.ReadAsStringAsync()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="paths"></param>
        /// <returns></returns>
        async Task<TResult> GetAsync<TResult>(params object[] paths)
        {
            using (var message = new HttpRequestMessage(HttpMethod.Get, Uri.Combine(paths)))
            {
                return await SendAsync<TResult>(message);
            }
        }

        /// <summary>
        /// Returns a client's details.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<CallERClientInfo> GetClientAsync()
        {
            return await GetAsync<CallERClientInfo>("client", clientId);
        }

        /// <summary>
        /// Sends a new caller request with a URL for data.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task<CallERProcessInfo> PostJobAsync(Uri url, CallERJob job)
        {
            Contract.Requires<ArgumentNullException>(url != null);
            Contract.Requires<ArgumentNullException>(job != null);

            // build submission URI
            var uri = new UriBuilder(Uri.Combine("client", clientId, "process", "url"));
            uri.AppendQuery("url", url);
            AppendJobArgs(uri, job);

            // submit request
            using (var message = new HttpRequestMessage(HttpMethod.Post, uri.Uri))
                return await SendAsync<CallERProcessInfo>(message);
        }

        /// <summary>
        /// Sends a new caller request with an audio file upload.
        /// </summary>
        /// <param name="media"></param>
        /// <param name="mediaType"></param>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task<CallERProcessInfo> PostJobAsync(Stream media, string mediaType, CallERJob job)
        {
            Contract.Requires<ArgumentNullException>(media != null);
            Contract.Requires<ArgumentNullException>(mediaType != null);
            Contract.Requires<ArgumentNullException>(job != null);

            // build submission URI
            var uri = new UriBuilder(Uri.Combine("client", clientId, "process", "audio"));
            AppendJobArgs(uri, job);

            // submit request
            using (var message = new HttpRequestMessage(HttpMethod.Post, uri.Uri))
            {
                message.Content = new StreamContent(media);
                message.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
                return await SendAsync<CallERProcessInfo>(message);
            }
        }

        /// <summary>
        /// Appends the values from the <see cref="CallERJob"/> to the <see cref="UriBuilder"/>.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="job"></param>
        void AppendJobArgs(UriBuilder uri, CallERJob job)
        {
            Contract.Requires<ArgumentNullException>(uri != null);
            Contract.Requires<ArgumentNullException>(job != null);

            // serialize job as JSON and append as query args
            foreach (var arg in JObject.FromObject(job).Properties())
                if (arg.Value != null)
                    uri.AppendQuery(arg.Name, JTokenToQueryArgValue(arg.Value));
        }

        /// <summary>
        /// Converts the given <see cref="JToken"/> into a query arg format.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        string JTokenToQueryArgValue(JToken token)
        {
            Contract.Requires<ArgumentNullException>(token != null);

            switch (token.Type)
            {
                case JTokenType.Array:
                    return string.Join(",", ((JArray)token).Select(i => (string)i));
                case JTokenType.Object:
                    throw new NotSupportedException();
                default:
                    return (string)token;
            }
        }

        /// <summary>
        /// Returns process info for all submitted jobs.
        /// </summary>
        /// <returns></returns>
        public async Task<CallERProcessInfo[]> GetProcesses()
        {
            return await GetAsync<CallERProcessInfo[]>("client", clientId, "process");
        }

        /// <summary>
        /// Returns process info for <paramref name="processId"/>.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="processId"></param>
        /// <returns></returns>
        public async Task<CallERProcessInfo> GetProcessAsync(long processId)
        {
            return await GetAsync<CallERProcessInfo>("client", clientId, "process", processId);
        }

        /// <summary>
        /// Returns process results for <paramref name="processId"/>.
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        public async Task<CallERProcessResult> GetProcessResultAsync(long processId)
        {
            return await GetAsync<CallERProcessResult>("client", clientId, "process", processId, "result");
        }

        /// <summary>
        /// Returns status of the service.
        /// </summary>
        /// <returns></returns>
        public async Task<CallERStatus> GetStatus()
        {
            return await GetAsync<CallERStatus>("status");
        }

    }

}
