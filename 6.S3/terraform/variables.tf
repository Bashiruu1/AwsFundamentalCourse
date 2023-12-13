variable "tables_map" {
  type = map(object({
    create_gsi = bool
    create_lsi = bool
  }))

  default = {
    customers = {
      create_gsi = false
      create_lsi = false
    }
  }
}
