replaceSubmorph: oldMorph by: newMorph
	| index itsPosition |
	oldMorph stopStepping.
	itsPosition _ oldMorph position.
	index _ submorphs indexOf: oldMorph.
	oldMorph privateDelete.
	self privateAddMorph: newMorph atIndex: index.
	newMorph position: itsPosition.
	self autoLineLayout
		ifTrue:
			[self fixLayout]