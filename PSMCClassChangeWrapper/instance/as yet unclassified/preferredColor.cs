preferredColor
	"Answer the colour for the string. 
	If a conflict and unresolved answer red."
	
	^(self conflict
			ifNil: [true]
			ifNotNilDo: [:c | c isResolved])
		ifTrue: [super preferredColor]
		ifFalse: [Color red]