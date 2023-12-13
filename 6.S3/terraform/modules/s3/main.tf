resource "aws_s3_bucket" "this" {
    bucket = var.bucket_name
    
}

resource "aws_s3_bucket_versioning" "versioning_example" {
  bucket = aws_s3_bucket.this.id
  versioning_configuration {
    status = "Enabled"
  }
}
