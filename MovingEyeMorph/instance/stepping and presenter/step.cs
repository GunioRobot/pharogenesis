step
	| cp |
	cp _ self globalPointToLocal: World primaryHand position.
	(inner containsPoint: cp)
		ifTrue: [iris position: (cp - (iris extent // 2))]
		ifFalse: [self irisPos: cp].
	self changed "cover up gribblies if embedded in Flash"