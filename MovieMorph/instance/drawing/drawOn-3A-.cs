drawOn: aCanvas

	| frame |
	frame _ self currentFrame.
	frame ~~ nil
		ifTrue: [^ frame drawOn: aCanvas]
		ifFalse: [^ super drawOn: aCanvas].
