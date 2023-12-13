resource "aws_dynamodb_table" "table" {
  name           = var.table_name
  hash_key       = "pk"
  range_key      = "sk"
  billing_mode   = "PROVISIONED"
  read_capacity  = 5
  write_capacity = 5

  attribute {
    name = "pk"
    type = "S"
  }

  attribute {
    name = "sk"
    type = "S"
  }
}
