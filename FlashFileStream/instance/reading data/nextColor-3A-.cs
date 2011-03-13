nextColor: usingAlpha
	| r g b baseColor |
	r := self nextByte / 255.0.
	g := self nextByte / 255.0.
	b := self nextByte / 255.0.
	baseColor := Color r: r g: g b: b.
	^usingAlpha 
		ifTrue:[baseColor alpha: self nextByte / 255.0]
		ifFalse:[baseColor]