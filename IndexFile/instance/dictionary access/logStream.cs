logStream

	logfile ifNil: [
		^logfile _ (StandardFileStream fileNamed: filename,'.log') setToEnd
	].
	logfile closed ifTrue: [logfile open; setToEnd].
	^ logfile