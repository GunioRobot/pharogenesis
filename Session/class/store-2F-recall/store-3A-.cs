store: aSession
	| newID |
	[	newID := SmallInteger maxVal atRandom.
		Sessions includesKey: newID ] whileTrue.
	Sessions at: newID put: aSession.
	^newID