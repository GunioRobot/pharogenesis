form
	form isNil ifTrue: 
		[self morph isNil ifTrue: [^nil].
		^self morph form].
	^form