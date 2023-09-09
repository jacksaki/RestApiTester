using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.Models
{
    public class RestApiExecutor
    {
        public RestApiExecutor()
        {

        }
        private async Task ExecutePreActionAsync(RequestParameter p)
        {
            if (p.ActionParameter.DeleteS3File)
            {
                await new S3Remover().DeleteFileAsync(p.ActionParameter.DeleteS3Bucket, p.ActionParameter.DeleteS3Key);
            }
        }
        private async Task<string> GetRawContentAsync(HttpResponseMessage response)
        {
            using (var sr = new System.IO.StreamReader(await response.Content.ReadAsStreamAsync()))
            {
                return await sr.ReadToEndAsync();
            }
        }
        public async Task<ApiResponse> GetResultAsync(RequestParameter p)
        {
            await ExecutePreActionAsync(p);
            var rp = new ApiResponseParameter(p);
            var t = await p.GetResponseTypeAsync();
            rp.StartDate = DateTime.Now;
            HttpResponseMessage response = null;
            if(p.RequestMethod == RequestMethod.Get)
            {
                response = await _client.GetAsync(p.GetUrl());
            }
            else if(p.RequestMethod == RequestMethod.Post)
            {
                response = await _client.PostAsync(p.GetUrl(), p.GetContent());
            }
            rp.HttpStatus = response.StatusCode;
            rp.EndDate = DateTime.Now;
            rp.RawContent = await GetRawContentAsync(response);
            if (p.ActionParameter.ShowS3File)
            {
                rp.S3Text = await new S3Downloader().DownloadTextAsync(p.ActionParameter.ShowS3Bucket, p.ActionParameter.ShowS3Key);
            }
            return ApiResponse.Create(rp);
        }

        private static HttpClient _client = new HttpClient();
    }
}
