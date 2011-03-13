bounds
	| bounds theText |
	self fillsOwner ifFalse: [^ textMorph textBounds].
	theText _ textMorph.
	bounds _ theText owner innerBounds.
	bounds _ bounds insetBy: (textMorph valueOfProperty: #margins ifAbsent: [1@1]).
	theText owner submorphsBehind: theText do:
		[:m | bounds _ bounds merge: m fullBounds].
	^ bounds