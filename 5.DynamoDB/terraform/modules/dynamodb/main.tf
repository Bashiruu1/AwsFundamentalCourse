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

  # These have some limitations at the moment with terraform it seems.. 
  # you must reference partition/sort types and no other column

  
  # dynamic "global_secondary_index" {
  #   for_each = var.table_config.create_gsi ? [1] : []
  #   content {
  #     name               = "email-id-index"
  #     hash_key           = "email"
  #     range_key          = "id"
  #     write_capacity     = 5
  #     read_capacity      = 5
  #     projection_type    = "ALL"
  #   }
  # }
  
  # dynamic "local_secondary_index" {
  #   for_each = var.table_config.create_lsi ? [1] : []
  #   content {
  #     name = "rotten-index"
  #     range_key = "RottenTomatoesPercentage"
  #     non_key_attributes = [ "ALL" ]
  #     projection_type = "ALL"
  #   }
  # }
}
