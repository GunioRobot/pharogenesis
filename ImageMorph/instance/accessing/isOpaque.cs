isOpaque
	"Return true if the receiver is marked as being completely opaque"
	extension == nil ifTrue:[^false].
	^self valueOfProperty: #isOpaque ifAbsent:[false]