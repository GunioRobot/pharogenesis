newFromStream: s
	| len |
	len _ s nextInt32.
	len < 0
		ifTrue: [^ (self new: len negated) readCompressedFrom: s]
		ifFalse: [^ s nextInto: (self new: len)]