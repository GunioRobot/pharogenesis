terminateProcess: aProcess
	aProcess ifNotNil: [
		self suspendedProcesses
			removeKey: aProcess
			ifAbsent: [].
		aProcess terminate
	].
