durationName

	self durationChoices do: [:c |
		(c first isDigit and: [c asNumber = sampleDuration]) ifTrue: [^ c]].
	sampleDuration = 9999 ifTrue: [^ 'held'].
	^ sampleDuration printString
