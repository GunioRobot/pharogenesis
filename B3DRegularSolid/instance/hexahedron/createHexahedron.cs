createHexahedron

    | sqrtFrom2 |

    sqrtFrom2 := 2.0 sqrt/ 2.0.
    vertices := OrderedCollection new: 8.
    vertices add: (B3DVector3 x: 1.0 y: 1.0 z: 1.0) * sqrtFrom2;
              add: (B3DVector3 x: -1.0 y: 1.0 z: 1.0) * sqrtFrom2;
              add: (B3DVector3 x: -1.0 y: -1.0 z: 1.0) * sqrtFrom2;
              add: (B3DVector3 x: 1.0 y: -1.0 z: 1.0) * sqrtFrom2;
              add: (B3DVector3 x: -1.0 y: -1.0 z: -1.0) * sqrtFrom2;
              add: (B3DVector3 x:  1.0 y: -1.0 z: -1.0) * sqrtFrom2;
              add: (B3DVector3 x:  1.0 y:  1.0 z: -1.0) * sqrtFrom2;
              add: (B3DVector3 x: -1.0 y:  1.0 z: -1.0) * sqrtFrom2.
    faces := OrderedCollection new: 6.
    faces add: #(1 2 3 4);
           add: #(1 4 6 7);
           add: #(1 7 8 2);
           add: #(2 8 5 3);
           add: #(5 8 7 6);
           add: #(3 5 6 4).
   faceNormals :=
         faces collect: [:f | self normalForFace: f].
   faces := faces asArray.