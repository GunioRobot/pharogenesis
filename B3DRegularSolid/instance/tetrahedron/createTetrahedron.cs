createTetrahedron

    vertices := OrderedCollection new: 4.
    vertices add: (B3DVector3 x: 0.0 y: 0.0 z: 3.0 sqrt);
              add: (B3DVector3 x: 0.0 y: 6.0 sqrt * 2/3 z: 3.0 sqrt negated/ 3.0);
              add: (B3DVector3 x: 2.0 sqrt negated y: 6.0 sqrt negated/3  z: 3.0 sqrt negated/ 3.0);
              add: (B3DVector3 x: 2.0 sqrt y: 6.0 sqrt negated/3  z: 3.0 sqrt negated/ 3.0).
    faces := OrderedCollection new: 4.
    faces add: #(1 2 3);
           add: #(1 3 4);
           add: #(1 4 2);
           add: #(2 4 3).
   faceNormals :=
         faces collect: [:f | self normalForFace: f].
   faces := faces asArray.
