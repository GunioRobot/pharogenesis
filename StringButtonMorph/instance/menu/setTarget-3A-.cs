setTarget: evt 
	| rootMorphs |
	rootMorphs _ self world rootMorphsAt: evt hand targetOffset.
	target _ rootMorphs size > 1
		ifTrue: [rootMorphs second]
		ifFalse: [nil]