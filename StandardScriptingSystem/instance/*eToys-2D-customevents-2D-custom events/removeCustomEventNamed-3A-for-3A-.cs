removeCustomEventNamed: aSymbol for: registrant
	| registration helpString |
	registration _ self customEventsRegistry at: aSymbol ifAbsent: [ ^nil ].
	helpString _ registration removeKey: registrant ifAbsent: [].
	registration isEmpty ifTrue: [ self customEventsRegistry removeKey: aSymbol ].
	^helpString