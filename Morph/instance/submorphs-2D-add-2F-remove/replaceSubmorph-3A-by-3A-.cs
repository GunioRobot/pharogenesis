replaceSubmorph: oldMorph by: newMorph
	| index itsPosition w |
	oldMorph stopStepping.
	itsPosition _ oldMorph referencePositionInWorld.
	index _ submorphs indexOf: oldMorph.
	oldMorph privateDelete.
	self privateAddMorph: newMorph atIndex: index.
	newMorph referencePositionInWorld: itsPosition.
	(w _ newMorph world) ifNotNil:
		[w startSteppingSubmorphsOf: newMorph]