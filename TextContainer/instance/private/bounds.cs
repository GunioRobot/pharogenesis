bounds
	| bounds |
	self fillsOwner ifFalse: [^ textMorph textBounds].
	bounds _ textMorph owner bounds.
	textMorph owner submorphsBehind: textMorph do:
		[:m | bounds _ bounds merge: m fullBounds].
	^ bounds