logStream
	logfile ifNil: [logfile _ StandardFileStream new open: (filename,'.log') forWrite: true;
				 setToEnd]
		ifNotNil: [logfile closed ifTrue: [logfile open; setToEnd]].
	^ logfile