asB3DVector3
	| wValue |
	wValue _ self w.
	wValue = 0.0 ifTrue:[^B3DVector3 zero].
	^B3DVector3 x: self x / wValue y: self y / wValue z: self z / wValue