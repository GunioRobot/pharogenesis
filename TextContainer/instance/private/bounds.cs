bounds
	| bounds theText |
	self fillsOwner ifFalse: [^ textMorph textBounds].
	theText _ textMorph meOrMyDropShadow.
	bounds _ theText owner bounds.
	theText owner submorphsBehind: theText do:
		[:m | bounds _ bounds merge: m fullBounds].
	^ bounds