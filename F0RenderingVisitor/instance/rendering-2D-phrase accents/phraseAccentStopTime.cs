phraseAccentStopTime
	| lastEvent |
	lastEvent _ (phrase ifNil: [clause phrases last]) lastSyllable events last.
	^ (self timeForEvent: lastEvent) + lastEvent duration