storeLog
	| logFileName |
	logFileName := Preferences debugLogTimestamp
		ifTrue: ['SqueakDebug-' , Time totalSeconds printString , '.log']
		ifFalse: ['SqueakDebug.log'].
	Smalltalk logError: labelString printString inContext: contextStackTop to: logFileName
