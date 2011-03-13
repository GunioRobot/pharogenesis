universalTilesString
	^ (myWorld valueOfProperty: #universalTiles ifAbsent: [false])
		ifTrue: ['<yes>new tiles in viewers and scripts']
		ifFalse: ['<no>new tiles in viewers and scripts']