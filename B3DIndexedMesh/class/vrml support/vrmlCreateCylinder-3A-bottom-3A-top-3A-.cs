vrmlCreateCylinder: doSide bottom: doBottom top: doTop
	| faces |
	faces _ #().
	doSide ifTrue:[faces _ faces, self vrmlCreateCylinderFaces].
	doBottom ifTrue:[faces _ faces, self vrmlCreateBottomFaces].
	doTop ifTrue:[faces _ faces, self vrmlCreateTopFaces].
	^(B3DSimpleMesh withAll: faces) asIndexedMesh