provider "aws" {
  region = "us-east-1"

  default_tags {
    tags = local.tags
  }
}

locals {
  tags = {
    environment = "test"
  }
}

module "s3-bucket" {
  source = "./modules/s3"
  bucket_name = "usman-aws-fundamentals-s3-buckets"
}
