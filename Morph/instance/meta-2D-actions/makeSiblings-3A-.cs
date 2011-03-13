makeSiblings: count
	"Make multiple sibling, and return the list"

	| aPosition anInstance listOfNewborns |
	aPosition _ self position.
	listOfNewborns _ (1 to: count asInteger) asArray collect: 
		[:anIndex |
			anInstance _ self usableSiblingInstance.
			owner addMorphFront: anInstance.
			aPosition _ aPosition + (10@10).
			anInstance position: aPosition.
			anInstance].
	self currentWorld startSteppingSubmorphsOf: self topRendererOrSelf owner.
	^ listOfNewborns