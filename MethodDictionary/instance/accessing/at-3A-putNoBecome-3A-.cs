at: key putNoBecome: value

	"Set the value at key to be value. Answer the resulting MethodDictionary"
	| index |
	index _ self findElementOrNil: key.
	(self basicAt: index) == nil
		ifTrue: 
			[tally _ tally + 1.
			self basicAt: index put: key]
		ifFalse:
			[(array at: index) flushCache].
	array at: index put: value.
	^self fullCheckNoBecome