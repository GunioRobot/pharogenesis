initialStopTime
	| lastEvent |
	lastEvent _ 	clause phrases first words first lastSyllable events last.
	^ (self timeForEvent: lastEvent) + lastEvent duration