addMorph: newMorph asElementNumber: aNumber
	"add the given morph so that it becomes the aNumber'th element of my submorph list"

	(aNumber <= submorphs size)
		ifTrue:
			[self addMorph: newMorph inFrontOf: (submorphs at: aNumber)]
		ifFalse:
			[self addMorphBack: newMorph]
