translateBy: amount

  position := position + amount

  " Multiple mesh faces of a mesh may share the same vertex instances. Inplace modification is therefore too dangerous. "