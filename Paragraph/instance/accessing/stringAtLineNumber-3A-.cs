stringAtLineNumber: aNumber
	(aNumber > lastLine or: [aNumber < 1]) ifTrue: [^ nil].
	^ (text string copyFrom: (lines at: aNumber) first to: (lines at: aNumber) last) copyWithout: Character cr