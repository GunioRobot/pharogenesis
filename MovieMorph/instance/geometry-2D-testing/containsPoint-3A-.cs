containsPoint: p

	| frame |
	frame _ self currentFrame.
	((frame ~~ nil) and: [playMode = #stop])
		ifTrue: [^ frame containsPoint: p]
		ifFalse: [^ super containsPoint: p].
