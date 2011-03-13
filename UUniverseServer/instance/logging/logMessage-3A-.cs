logMessage: message
	| line |
	logfile ifNil: [ ^self ].
	line := message maybeLogMessage.
	line ifNil: [ ^self ].
	logfile
		print: DateAndTime now;
		space;
		nextPutAll: line; 
		cr.
	logfile flush.