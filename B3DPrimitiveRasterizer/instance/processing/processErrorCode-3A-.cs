processErrorCode: errCode
	errCode = 0 ifTrue:[^true]. "This is allowed!"
	(errCode = B3DNoMoreEdges) 
		ifTrue:[^state growEdges].
	(errCode = B3DNoMoreFaces)
		ifTrue:[^state growFaces].
	(errCode = B3DNoMoreAttrs)
		ifTrue:[^state growAttrs].
	(errCode = B3DNoMoreAET)
		ifTrue:[^state growAET].
	(errCode = B3DNoMoreAdded)
		ifTrue:[^state growAdded].
	self error:'Unknown rasterizer error code ', errCode printString.