insert: aFace before: nextFace
	"Insert the given face before nextFace."
	B3DScanner doDebug ifTrue:[
		(self includes: nextFace) ifFalse:[^self error:'Face not in collection'].
		(self includes: aFace) ifTrue:[^self error:'Face already in collection'].
	].
	aFace nextFace: nextFace.
	aFace prevFace: nextFace prevFace.
	aFace prevFace nextFace: aFace.
	nextFace prevFace: aFace.
	B3DScanner doDebug ifTrue:[self validate].