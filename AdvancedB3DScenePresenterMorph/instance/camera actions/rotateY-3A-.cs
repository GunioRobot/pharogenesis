rotateY: angle
	| camera matrix |
     scene isNil ifTrue: [^self].
	camera := scene defaultCamera.
	matrix := B3DMatrix4x4
		rotatedBy: angle
		around: camera up
		centeredAt: camera target.
	camera position: (matrix localPointToGlobal: camera position).
	self changed.