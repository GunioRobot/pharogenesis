mouseLeaveDragging: anEvent onItem: aMorph 
	anEvent hand hasSubmorphs ifFalse: ["no d&d"
		^ self].
	(self wantsDroppedMorph: anEvent hand firstSubmorph event: anEvent )
		ifTrue: 
			[self resetPotentialDropMorph]