replaceSubmorph: oldMorph by: newMorph
	super replaceSubmorph: oldMorph by: newMorph.
	self autoLineLayout
		ifTrue:
			[self fixLayout]