think
	| move |
	self isThinking ifTrue: [^nil].
	self startThinking.
	[(move := self thinkStep) isNil] whileTrue.
	^move