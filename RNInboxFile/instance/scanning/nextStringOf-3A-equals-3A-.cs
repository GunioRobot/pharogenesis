nextStringOf: aStream equals: aString

	aString do:
		[: c | (c == (aStream next) ) ifFalse: [^false]].
	^true