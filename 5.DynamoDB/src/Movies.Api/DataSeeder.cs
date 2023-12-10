using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

namespace Movies.Api;

public class DataSeeder
{
    public async Task ImportDataAsync()
    {
        var dynamoDbClient = new AmazonDynamoDBClient();
        var lines = await File.ReadAllLinesAsync("./movies.csv");
        for (var i = 0; i < lines.Length; i++)
        {
            if (i == 0)
            {
                continue; //Skip header
            }

            var line = lines[i];
            var commaSplit = line.Split(',');

            var title = commaSplit[0];
            var year = int.Parse(commaSplit[1]);
            var ageRestriction = int.Parse(commaSplit[2]);
            var rottenTomatoes = int.Parse(commaSplit[3]);

            var movie1 = new MovieYearTitle
            {
                Id = Guid.NewGuid(),
                Title = title,
                AgeRestriction = ageRestriction,
                ReleaseYear = year,
                RottenTomatoesPercentage = rottenTomatoes
            };
            
            var movie2 = new MovieTitleRotten
            {
                Id = Guid.NewGuid(),
                Title = title,
                AgeRestriction = ageRestriction,
                ReleaseYear = year,
                RottenTomatoesPercentage = rottenTomatoes
            };
            
            var asJsonMovieYearTitle = JsonSerializer.Serialize(movie1);
            var asJsonMovieTitleRotten = JsonSerializer.Serialize(movie2);

            var attributeMapMovieYearTitle = Document.FromJson(asJsonMovieYearTitle).ToAttributeMap();
            var attributeMapMovieTitleRotten = Document.FromJson(asJsonMovieTitleRotten).ToAttributeMap();

            var transactionRequest = new TransactWriteItemsRequest
            {
                TransactItems = new List<TransactWriteItem>
                {
                    new()
                    {
                        Put = new Put
                        {
                            TableName = "movies-year-title",
                            Item = attributeMapMovieYearTitle
                        }
                    },
                    new()
                    {
                        Put = new Put
                        {
                            TableName = "movies-title-rotten",
                            Item = attributeMapMovieTitleRotten
                        }
                    }
                }
            };

            

            var response = await dynamoDbClient.TransactWriteItemsAsync(transactionRequest);
            
            EnsureSuccess(response.HttpStatusCode);
            
            await Task.Delay(300);
        }
    }

    private static void EnsureSuccess(HttpStatusCode httpStatusCode)
    {
        if (httpStatusCode >= HttpStatusCode.BadRequest)
        {
            throw new Exception("I failed somewhere...");
        }
    }
}
