createDodekahedron

   | points |

  points := self computeEssentialPoints12.
  vertices := Array new: 20.
  1 to: points size do: 
     [:idx | vertices at: idx put: (points at: idx).
            vertices at: idx + 10 put: (points at: idx) negated].
  faces := OrderedCollection new: 12.
  faceNormals := OrderedCollection new: 12.
  faces add: (1 to: 5) asArray.
  faceNormals add: 
            (self normalForFace: (1 to: 5)).
  faces add: (11 to: 15) asArray.
  faceNormals add: 
            (self normalForFace: (11 to: 15)).
  
  1 to: 5 do:
     [:idx |  | a |
         a := Array with: idx 
                      with: idx + 5
                      with: idx + 2 \\ 5 + 1 + 5 + 10
                      with: idx \\ 5 + 1 + 5
                      with:  idx \\ 5 + 1.
         faces add: a.
         faceNormals add: (self normalForFace: a).
         a := Array with: idx + 10
                      with: idx + 5 + 10
                      with: idx + 2 \\ 5 + 1 + 5 
                      with: idx \\ 5 + 1 + 5 + 10
                      with:  idx \\ 5 + 1 + 10.
         faces add: a.
         faceNormals add: (self normalForFace: a).
     ].
   faces := faces asArray.

  
  
