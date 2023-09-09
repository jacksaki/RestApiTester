using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.Models
{
    public class S3Downloader
    {
        public async Task<string>DownloadTextAsync(string bucket, string key)
        {
            using(var client = new AmazonS3Client())
            {
                var res = await client.GetObjectAsync(new GetObjectRequest()
                {
                    BucketName = bucket,
                    Key = key,
                });
                using (var sr = new System.IO.StreamReader(res.ResponseStream))
                {
                    return await sr.ReadToEndAsync();
                }
            }
        }
    }
}
