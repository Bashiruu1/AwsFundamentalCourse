variable "table_config" {
  type = object({
    create_gsi = bool
    create_lsi = bool
  })
}

variable "table_name" {
  type = string
}

variable "tags" {
  type = map(string)
  default = {}
}
