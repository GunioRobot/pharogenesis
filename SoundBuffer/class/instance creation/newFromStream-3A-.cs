newFromStream: s

	| len |
	len _ s nextInt32.
	^ s nextWordsInto: (self new: len)