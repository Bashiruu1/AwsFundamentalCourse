provider "aws" {
  region = "us-east-1"

  default_tags {
    tags = local.tags
  }
}

module "s3-bucket" {
  source      = "./modules/s3"
  bucket_name = "usman-aws-fundamentals-s3-buckets"
}

module "aws_dynamodb_table" {
  source = "./modules/dynamodb"

  for_each = var.tables_map

  table_name   = each.key
  table_config = each.value
  tags         = local.tags
}

locals {
  tags = {
    created_by  = "terraform"
    environment = "test"
  }
}
