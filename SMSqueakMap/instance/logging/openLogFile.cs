openLogFile
	"Pick the newest logfile available and open it."

	| fileName |
	fileName _ self logFileName.
	fileName ifNil: [^nil].
	^(self directory oldFileNamed: fileName)
		converter: Latin1TextConverter new;
		yourself.
