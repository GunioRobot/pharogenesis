createBody

  " return a B3DSimpleMesh that represents an dodecahedron
    The solid is point symmetric to the origin of the coordinate system. It is therefore sufficient to compute 10 of its 20 vertrices. The other vertices are obtained by multiplication with -1. "
   | points meshFaces normal vertices normalFor |

   normalFor := [ :v |  | v1 v2 v3 d1 d2 |
		v1 _ v at: 1.
		v2 _ v at: 2.
		v3 _ v at: 3.
		d1 _ v3 - v1.
		d2 _ v2 - v1.
		d1 safelyNormalize.
		d2 safelyNormalize.
		(d1 cross: d2) safelyNormalize.
        ].
   points := Array new: 10.
   1 to: 5 do: 
         [:idx |  
         points at: idx put: (B3DVector3
               x: (Float pi * (idx * 2 + 1) / 5) cos * 2
               y: (Float pi * (idx * 2 + 1) / 5) sin * 2
               z: 1.0 + 5.0 sqrt / 2 + 1.0).
         points at: idx + 5 put: (B3DVector3
               x: (Float pi * (idx * 2 + 1) / 5) cos * (1.0 + 5.0 sqrt)
               y: (Float pi * (idx * 2 + 1) / 5) sin * (1.0 + 5.0 sqrt)
               z: 1.0 + 5.0 sqrt / 2 - 1.0)].
   1 to: 10 do: [:idx | points at: idx put: (points at: idx)
            / (points at: idx) squaredLength sqrt * (0.81573786516665 / 0.79465447229177)].
   meshFaces := OrderedCollection new: 12.

    vertices := points copyFrom: 1  to: 5. 
    normal := normalFor value: vertices.
   
    meshFaces add: (B3DSimpleMeshFace
                           withAll: (vertices collect: [:p | (B3DSimpleMeshVertex new) position: p; normal: normal])).
         vertices := vertices collect: [:p | p negated].
         normal := normalFor value: vertices.

    meshFaces add: (B3DSimpleMeshFace
                       withAll: (vertices collect: [:p | (B3DSimpleMeshVertex new) position: p; normal: normal])). 

  1 to: 5
      do: 
         [ :idx | 
         vertices := Array
                  with: (points at: idx)
                  with: (points at: idx + 5)
                  with: (points at: idx + 2 \\ 5 + 1 + 5) negated
                  with: (points at: idx \\ 5 + 1 + 5)
                  with: (points at: idx \\ 5 + 1).
         normal := normalFor value: vertices.
         meshFaces add: (B3DSimpleMeshFace
                               withAll: (vertices collect: [:p | (B3DSimpleMeshVertex new)
                                                                         position: p; 
                                                                         normal: normal])).
         vertices := vertices collect: [:p | p negated].
         normal := normalFor value: vertices.
         meshFaces add: (B3DSimpleMeshFace
                              withAll: (vertices collect: [:p | B3DSimpleMeshVertex new
                                                               position: p;
                                                               normal: normal])).
         ].

  ^B3DSimpleMesh withAll: meshFaces
 
 
