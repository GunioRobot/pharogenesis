comment: aString

	aString isEmpty
		ifTrue: [comment _ nil]
		ifFalse: [comment _ aString].
