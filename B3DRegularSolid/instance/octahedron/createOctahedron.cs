createOctahedron

    | sqrtFrom2 |

    sqrtFrom2 := 2.0 sqrt.
    vertices := OrderedCollection new: 6.
    vertices add: (B3DVector3 x: 0.0 y: 0.0 z: sqrtFrom2);
              add: (B3DVector3 x: sqrtFrom2 y: 0.0 z: 0.0);
              add: (B3DVector3 x: 0.0 y: sqrtFrom2 z: 0.0);
              add: (B3DVector3 x: 0.0 y: 0.0 z: sqrtFrom2 negated);
              add: (B3DVector3 x: sqrtFrom2 negated y: 0.0 z: 0.0);
              add: (B3DVector3 x: 0.0 y: sqrtFrom2 negated z: 0.0).
    faces := OrderedCollection new: 8.
    faces add: #(1 2 3);
           add: #(1 3 5);
           add: #(1 5 6);
           add: #(1 6 2);
           add: #(2 6 4);
           add: #(2 4 3);
           add: #(4 6 5);
           add: #(3 4 5).
   faceNormals :=
         faces collect: [:f | self normalForFace: f].
   faces := faces asArray.
