variable "tables_map" {
  type = map(object({
    create_gsi = bool
    create_lsi = bool
  }))

  default = {
    customers = {
      create_gsi = true
      create_lsi = false
    }
    movies = {
      create_gsi = false
      create_lsi = false
    }
    movies-title-rotten = {
      create_gsi = false
      create_lsi = true
    }
    movies-year-title = {
      create_gsi = false
      create_lsi = false
    }
  }
}
