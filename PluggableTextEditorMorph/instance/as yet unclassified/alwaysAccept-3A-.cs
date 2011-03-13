alwaysAccept: aBoolean
	"Set the always accept flag."

	aBoolean
		ifTrue: [self setProperty: #alwaysAccept toValue: true]
		ifFalse: [self removeProperty: #alwaysAccept]