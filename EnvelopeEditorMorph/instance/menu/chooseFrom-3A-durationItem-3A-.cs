chooseFrom: chooserMorph durationItem: item
	| str |
	(item first isDigit and: [item asNumber ~= 0])
		ifTrue: [sampleDuration _ item asNumber].
	item = 'other' ifTrue:
		[str _ FillInTheBlank request: 'duration in milliseconds'
						initialAnswer: sampleDuration printString.
		sampleDuration _ str asNumber].
	item = 'held' ifTrue: [sampleDuration _ 9999].
	sound duration: sampleDuration / 1000.0.
	chooserMorph contentsClipped: 'duration: ' , self durationName