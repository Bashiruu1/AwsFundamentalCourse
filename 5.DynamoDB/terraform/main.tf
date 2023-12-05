provider "aws" {
  region = "us-east-1"
}


module "aws_dynamodb_table" {
  source = "./modules/dynamodb"
  db_name = "customers"
}
