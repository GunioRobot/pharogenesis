matchesKey: aString andMatchesDate: aDate

	aString = 'recurring' ifTrue: [^ true].
	^ super matchesKey: aString andMatchesDate: aDate