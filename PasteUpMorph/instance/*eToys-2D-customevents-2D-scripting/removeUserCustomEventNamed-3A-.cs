removeUserCustomEventNamed: aSymbol
	^self userCustomEventsRegistry removeKey: aSymbol ifAbsent: [].