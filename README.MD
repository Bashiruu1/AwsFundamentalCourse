dotnet new sln -n AwsFundamentalsCourse

## Sqs Project to start

```shell
dotnet new console -o 3.Sqs/src/SqsPublisher
dotnet new console -o 3.Sqs/src/SqsConsumer

dotnet sln AwsFundamentalsCourse.sln add 3.Sqs/src/SqsPublisher/SqsPublisher.csproj
dotnet sln AwsFundamentalsCourse.sln add 3.Sqs/src/SqsConsumer/SqsConsumer.csproj
dotnet sln AwsFundamentalsCourse.sln add 4.Sns/src/Customers.Consumers/Customers.Consumers.csproj
dotnet sln AwsFundamentalsCourse.sln add 3.Sqs/src/Customers.Api/Customers.Api.csproj
```

## Sns Project to start

Copy the other projects over into 4.Sns/src folder..

```shell
dotnet new console -o 4.Sns/src/SnsPublisher

dotnet sln AwsFundamentalsCourse.sln add 4.Sns/src/SnsPublisher/SnsPublisher.csproj
dotnet sln AwsFundamentalsCourse.sln add 4.Sns/src/SqsConsumer/SqsConsumer.csproj
dotnet sln AwsFundamentalsCourse.sln add 4.Sns/src/Customers.Consumers/Customers.Consumers.csproj
dotnet sln AwsFundamentalsCourse.sln add 4.Sns/src/Customers.Api/Customers.Api.csproj
```

# Installing Packages

```shell
dotnet add package AWSSDK.SQS
dotnet add package MediatR
```
