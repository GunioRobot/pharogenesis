addFirst: aFace
	firstFace isNil
		ifTrue:[lastFace _ aFace]
		ifFalse:[firstFace prevFace: aFace].
	aFace nextFace: firstFace.
	aFace prevFace: nil.
	firstFace _ aFace.
	B3DScanner doDebug ifTrue:[self validate].