provider "aws" {
  region = "us-east-1"
}


module "aws_dynamodb_table" {
  source = "./modules/dynamodb"

  count = length(var.tables)

  db_name = var.tables[count.index]
  tags = local.tags
}

locals {
  tags = {
    created_by = "terraform"
  }
}
