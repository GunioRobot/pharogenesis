addFront: aFace
	"Add the given face as the new front face.
	Make sure the sort order stays okay."
	| backFace minZ tempFace |
	firstFace == lastFace ifFalse:["firstFace == lastFace denotes 0 or 1 elements"
		backFace _ firstFace nextFace.
		minZ _ firstFace minZ.
		[backFace notNil and:[backFace minZ < minZ]] 
			whileTrue:[backFace _ backFace nextFace].
		"backFace contains the face before which firstFace has to be added"
		firstFace nextFace == backFace ifFalse:[
			tempFace _ firstFace.
			self remove: tempFace.
			backFace == nil 
				ifTrue:[self addLast: tempFace]
				ifFalse:[self insert: tempFace before: backFace].
		].
	].
	^self addFirst: aFace