addLast: aFace
	lastFace isNil
		ifTrue:[firstFace _ aFace]
		ifFalse:[lastFace nextFace: aFace].
	aFace prevFace: lastFace.
	aFace nextFace: nil.
	lastFace _ aFace.
	B3DScanner doDebug ifTrue:[self validate].