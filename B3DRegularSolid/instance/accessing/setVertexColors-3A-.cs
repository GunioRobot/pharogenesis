setVertexColors: aCollection

  "  the following condition is required to hold:
     vertexColors size = faces size
       and: [(1 to: faces size) allSatisfy:
                 [:idx | (vertexColors at: idx) size = (faces at: idx) size]]
  "

   vertexColors := aCollection

  