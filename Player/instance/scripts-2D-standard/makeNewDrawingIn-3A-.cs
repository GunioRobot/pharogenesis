makeNewDrawingIn: paintPlacePlayer
	| paintPlace |
	((paintPlacePlayer == nil or: [((paintPlace _ paintPlacePlayer costume) isKindOf: PasteUpMorph) not])
		or: [paintPlace isInWorld not])
			ifTrue:
				[^ self inform: 'Error: not a plausible
place in which to make
a new drawing'].
	paintPlace makeNewDrawingWithin
	
	