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

## DynamoDB Project to start

Copy the Customers.Api project over into 5.DynamoDB/src folder..

```shell
dotnet sln AwsFundamentalsCourse.sln add 5.DynamoDB/src/Customers.Api/Customers.Api.csproj
dotnet sln AwsFundamentalsCourse.sln add 5.DynamoDB/src/Movies.Api/Movies.Api.csproj
```

To generate the dynamoDB table please run the following terraform command below

```shell
cd "cd 5.DynamoDB/terraform/"
terraform plan
terraform apply --auto-approve=true
```

To destroy the resources run these commands

```shell
terraform plan -destroy
terraform apply -destroy --auto-approve=true

```

## S3 Project to start

Copy the Customers.Api project over into 6.S3/src folder..

```shell
dotnet sln AwsFundamentalsCourse.sln add 6.S3/src/Customers.Api/Customers.Api.csproj
dotnet sln AwsFundamentalsCourse.sln add 6.S3/src/S3Playground/S3Playground.csproj
```

# Installing Packages

```shell
dotnet add package AWSSDK.SQS
dotnet add package MediatR
```
