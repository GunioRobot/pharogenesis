remove: aFace
	(B3DScanner doDebug and:[(self includes: aFace) not]) 
		ifTrue:[^self error:'Face not in list'].
	B3DScanner doDebug ifTrue:[self validate].
	aFace prevFace isNil
		ifTrue:[firstFace _ aFace nextFace]
		ifFalse:[aFace prevFace nextFace: aFace nextFace].
	aFace nextFace isNil
		ifTrue:[lastFace _ aFace prevFace]
		ifFalse:[aFace nextFace prevFace: aFace prevFace].
	^aFace