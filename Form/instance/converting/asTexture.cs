asTexture
	| newForm |
	newForm _ B3DTexture extent: self extent depth: 32.
	(BitBlt current toForm: newForm)
		colorMap: (self colormapIfNeededForDepth: 32);
		copy: (self boundingBox)
		from: 0@0 in: self
		fillColor: nil rule: Form over.
	newForm interpolate: false.
	newForm wrap: false.
	newForm envMode: 0.
	^newForm