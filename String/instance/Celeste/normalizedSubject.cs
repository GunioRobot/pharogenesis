normalizedSubject
	| res |
	res _ self.
	(res asLowercase beginsWith: 're:')
		ifTrue: [res _ res copyFrom: 4 to: res size].
	^ res withBlanksCondensed