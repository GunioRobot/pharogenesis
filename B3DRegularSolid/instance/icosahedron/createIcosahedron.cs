createIcosahedron

   | points |

  points := self computeEssentialPoints20.
  vertices := Array new: 12.
  1 to: points size do: 
     [:idx | vertices at: idx put: (points at: idx).
            vertices at: idx + 6 put: (points at: idx) negated].

  faces := OrderedCollection new: 20.
  faceNormals := OrderedCollection new: 20.
	1 to: 5
		do: 
		  [ :idx |  | a |
              a := Array with: 6 with: idx with: idx \\ 5 + 1.
              faces add: a.
              faceNormals add: (self normalForFace: a).

              a := Array with: idx \\5 + 1 with: idx with: idx + 2 \\5 + 1 + 6.
              faces add: a.
              faceNormals add: (self normalForFace: a).

              a := Array with: idx + 6 with: idx \\5 + 1 + 6 with: idx + 2 \\5 + 1.
              faces add: a.
              faceNormals add: (self normalForFace: a).

              a := Array with: idx \\ 5 + 1 + 6 with: idx + 6 with: 12.
              faces add: a.
              faceNormals add: (self normalForFace: a).
           ].

  faces := faces asArray.