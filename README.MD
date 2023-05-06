dotnet new sln -n AwsFundamentalsCourse

dotnet new console -n SqsPublisher -o src/SqsPublisher \
dotnet sln AwsFundamentalsCourse.sln add 3.Sqs/src/SqsPublisher/SqsPublisher.csproj

dotnet new console -n SqsConsumer -o src/SqsConsumer \
dotnet sln AwsFundamentalsCourse.sln add 3.Sqs/src/SqsConsumer/SqsConsumer.csproj

# Installing Packages

dotnet add package AWSSDK.SQS
