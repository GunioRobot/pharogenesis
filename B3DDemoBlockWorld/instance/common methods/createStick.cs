createStick

    | faces |

   faces := B3DIndexedMesh vrmlCreateBoxFaces.
   ^(B3DSimpleMesh withAll: faces) asIndexedMesh