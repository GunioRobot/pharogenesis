next
	| iFace face |
	iFace _ faces at: (start _ start + 1).
	face _ B3DPrimitiveFace new.
	face 
		v0: (vertices at: iFace p1Index)
		v1: (vertices at: iFace p2Index)
		v2: (vertices at: iFace p3Index).
	face texture: texture.
	face initializePass1.
	B3DScanner doDebug ifTrue:[
		face validateVertexOrder.
		face validateDepthSetup].
	^face