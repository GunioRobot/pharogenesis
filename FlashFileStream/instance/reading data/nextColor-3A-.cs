nextColor: usingAlpha
	| r g b baseColor |
	r _ self nextByte / 255.0.
	g _ self nextByte / 255.0.
	b _ self nextByte / 255.0.
	baseColor _ Color r: r g: g b: b.
	^usingAlpha 
		ifTrue:[baseColor alpha: self nextByte / 255.0]
		ifFalse:[baseColor]