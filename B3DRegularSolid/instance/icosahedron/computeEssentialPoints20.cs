computeEssentialPoints20

  " return the six essential points of a icosahedron. 
The solid is point symmetric to the origin of the coordinate system. It is therefore sufficient to compute 6 of its 12 vertices. The other vertices are obtained by multiplication with -1.  "
   | points  |

   points := Array new: 6.
   1 to: 5 do: 
         [:idx |  
         points at: idx put: (B3DVector3
               x: (Float pi * idx * 2 / 5) cos * 5.0 sqrt * 2 / 5
               y: (Float pi * idx * 2 / 5) sin * 5.0 sqrt * 2 / 5
               z: 5.0 sqrt / 5).
         ].
   points at: 6 put: (B3DVector3 x: 0.0 y: 0.0 z: 1.0).
   ^points
