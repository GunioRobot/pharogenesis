matchesDate: aDate

	dayPosted > aDate ifTrue: [^ false].
	dayDone ifNil: [^ true].
	^ dayDone >= aDate