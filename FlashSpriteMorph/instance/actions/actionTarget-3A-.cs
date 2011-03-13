actionTarget: target
	"Set the context (e.g., the receiver) of the following actions."
	| rcvr lastSlash nextSlash loc |
	target = '' ifTrue:[^self].
	target first = $/
		ifTrue:[rcvr := self flashPlayer ifNil:[self]. lastSlash := 1.] "absoute path"
		ifFalse:[rcvr := self. lastSlash := 0]. "relative path"
	[lastSlash > target size] whileFalse:[
		nextSlash := target findString:'/' startingAt: lastSlash+1.
		nextSlash = 0 ifTrue:[nextSlash := target size + 1].
		loc := target copyFrom: lastSlash+1 to: nextSlash-1.
		(loc size = 2 and:[loc = '..']) ifTrue:[
			[rcvr := rcvr owner.
			rcvr isFlashSprite] whileFalse.
		] ifFalse:[
			rcvr := rcvr submorphs detect:[:m| m knownName = loc] ifNone:[rcvr owner].
			rcvr := rcvr submorphs detect:[:m| m isFlashSprite].
		].
		lastSlash := nextSlash].
	^rcvr