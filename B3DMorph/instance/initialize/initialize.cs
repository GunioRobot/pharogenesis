initialize
	super initialize.
	geometry _ B3DBox from: (-0.7@-0.7@-0.7) to: (0.7@0.7@0.7).
	camera _ B3DCamera new.
	(self confirm:'Put me into a clipping frame?')
		ifTrue:[camera position: 0@0@1.5]
		ifFalse:[camera position: 0@0@2. color _ nil].
	camera nearDistance: 0.1.
	camera farDistance: 5.0.
	self extent: 100@100.
	texture _ (Form extent: 100@100) asTexture.
	angle _ 0.