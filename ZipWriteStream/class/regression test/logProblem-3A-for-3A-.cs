logProblem: reason for: aFile
	| errFile |
	errFile _ FileStream fileNamed:'problems.log'.
	errFile position: errFile size.
	errFile cr; nextPutAll: aFile name;
			cr; nextPutAll: reason.
	errFile close.
	Transcript show:' failed (', reason,')'.
	aFile close.
	^false