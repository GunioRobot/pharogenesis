internalPop: nItems thenPushBool: cond
	self inline: true.
	cond
		ifTrue: [self internalPop: nItems thenPush: trueObj]
		ifFalse: [self internalPop: nItems thenPush: falseObj]