actionTarget: target
	"Set the context (e.g., the receiver) of the following actions."
	| rcvr lastSlash nextSlash loc |
	target = '' ifTrue:[^self].
	target first = $/
		ifTrue:[rcvr _ self flashPlayer ifNil:[self]. lastSlash _ 1.] "absoute path"
		ifFalse:[rcvr _ self. lastSlash _ 0]. "relative path"
	[lastSlash > target size] whileFalse:[
		nextSlash _ target findString:'/' startingAt: lastSlash+1.
		nextSlash = 0 ifTrue:[nextSlash _ target size + 1].
		loc _ target copyFrom: lastSlash+1 to: nextSlash-1.
		(loc size = 2 and:[loc = '..']) ifTrue:[
			[rcvr _ rcvr owner.
			rcvr isFlashSprite] whileFalse.
		] ifFalse:[
			rcvr _ rcvr submorphs detect:[:m| m knownName = loc] ifNone:[rcvr owner].
			rcvr _ rcvr submorphs detect:[:m| m isFlashSprite].
		].
		lastSlash _ nextSlash].
	^rcvr