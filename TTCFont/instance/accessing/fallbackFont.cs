fallbackFont
	^ fallbackFont
		ifNil: [fallbackFont _ FixedFaceFont new errorFont fontSize: self height]