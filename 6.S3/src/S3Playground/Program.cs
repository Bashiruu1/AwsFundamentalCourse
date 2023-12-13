using System.Text;
using Amazon.S3;
using Amazon.S3.Model;

var s3Client = new AmazonS3Client();

// await using var inputStream = new FileStream("./movies.csv", FileMode.Open, FileAccess.Read);
//
// var putObjectRequest = new PutObjectRequest
// {
//     BucketName = "usman-aws-fundamentals-s3-buckets",
//     Key = "files/movies.csv",
//     ContentType = "text/csv",
//     InputStream = inputStream
// };
//
// var response = await s3Client.PutObjectAsync(putObjectRequest);

var getObjectRequest = new GetObjectRequest
{
    BucketName = "usman-aws-fundamentals-s3-buckets",
    Key = "files/movies.csv"
};

var response = await s3Client.GetObjectAsync(getObjectRequest);
using var memoryStream = new MemoryStream();
response.ResponseStream.CopyTo(memoryStream);

var text = Encoding.UTF8.GetString(memoryStream.ToArray());
Console.WriteLine(text);

