setTarget: evt

	| rootMorphs |
	rootMorphs _ self world rootMorphsAt: evt hand targetOffset.
	rootMorphs size > 1
		ifTrue: [target _ rootMorphs at: 2]
		ifFalse: [target _ nil. ^ self].
