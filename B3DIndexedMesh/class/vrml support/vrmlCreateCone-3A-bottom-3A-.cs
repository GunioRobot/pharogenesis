vrmlCreateCone: doSide bottom: doBottom
	| faces |
	faces _ #().
	doSide ifTrue:[faces _ faces, self vrmlCreateConeFaces].
	doBottom ifTrue:[faces _ faces, self vrmlCreateBottomFaces].
	^(B3DSimpleMesh withAll: faces) asIndexedMesh