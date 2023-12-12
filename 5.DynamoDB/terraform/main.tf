provider "aws" {
  region = "us-east-1"
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
    created_by = "terraform"
  }
}
