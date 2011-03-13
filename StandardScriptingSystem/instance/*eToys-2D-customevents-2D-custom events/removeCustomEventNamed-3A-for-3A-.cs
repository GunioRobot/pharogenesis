removeCustomEventNamed: aSymbol for: registrant
	| registration helpString |
	registration := self customEventsRegistry at: aSymbol ifAbsent: [ ^nil ].
	helpString := registration removeKey: registrant ifAbsent: [].
	registration isEmpty ifTrue: [ self customEventsRegistry removeKey: aSymbol ].
	^helpString