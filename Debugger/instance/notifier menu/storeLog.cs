storeLog
	| logFileName |
	logFileName := Preferences debugLogTimestamp
		ifTrue: ['PharoDebug-' , Time totalSeconds printString , '.log']
		ifFalse: ['PharoDebug.log'].
 	Smalltalk logError: labelString printString inContext: contextStackTop to: logFileName
 