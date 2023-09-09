using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.Models
{
    public class S3Remover
    {
        public async Task DeleteFileAsync(string bucket, string key)
        {
            using(var client = new Amazon.S3.AmazonS3Client())
            {
                await client.DeleteObjectAsync(new Amazon.S3.Model.DeleteObjectRequest()
                {
                    BucketName = bucket,
                    Key = key,
                });
            }
        }
    }
}
