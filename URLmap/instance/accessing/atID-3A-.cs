atID: id
	"Return page of a given key."
	| idString |
	idString _ id isInteger ifTrue: [id printString] ifFalse: [id].
	^ pages detect: [:page | page coreID = idString] ifNone: [self
atID: '1']