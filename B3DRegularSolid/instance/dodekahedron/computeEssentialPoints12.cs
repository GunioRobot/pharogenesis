computeEssentialPoints12

  " return the ten essential points of a dodecahedron.
    The solid is point symmetric to the origin of the coordinate system. It is therefore sufficient to compute 10 of its 20 vertices. The other vertices are obtained by multiplication with -1. "
   | points  |

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
   ^points
