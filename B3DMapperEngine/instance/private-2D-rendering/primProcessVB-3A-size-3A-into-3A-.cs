primProcessVB: vertexArray size: arraySize into: array
	| left right top bottom vtx flags w x y |
	<primitive: 'b3dMapVertexBuffer' module: 'Squeak3D'>
	1 to: arraySize do:[:i|
		vtx _ vertexArray at: i.
		flags _ vtx clipFlags.
		w _ vtx rasterPosW.
		w isZero ifFalse:[w _ 1.0 / w].
		(flags anyMask: OutLeftBit) 
			ifTrue:[x _ -1.0]
			ifFalse:[(flags anyMask: OutRightBit) 
				ifTrue:[x _ 1.0]
				ifFalse:[x _ vtx rasterPosX * w]].
		(flags anyMask: OutTopBit) 
			ifTrue:[y _ -1.0]
			ifFalse:[(flags anyMask: OutBottomBit) 
				ifTrue:[y _ 1.0]
				ifFalse:[y _ vtx rasterPosY * w]].
		i = 1 ifTrue:[
			left _ right _ x.
			top _ bottom _ y.
		].
		left _ left min: x.
		right _ right max: x.
		top _ top min: y.
		bottom _ bottom max: y.
	].
	array at: 1 put: left.
	array at: 2 put: top.
	array at: 3 put: right.
	array at: 4 put: bottom.
