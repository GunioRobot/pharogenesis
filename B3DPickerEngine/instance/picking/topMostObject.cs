topMostObject
	"Return the top most of all picked objects"
	^pickList isEmpty
		ifTrue:[nil]
		ifFalse:[pickList first key]