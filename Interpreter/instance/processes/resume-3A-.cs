resume: aProcess

	| activeProc activePriority newPriority |
	self inline: false.
	activeProc _ self fetchPointer: ActiveProcessIndex
						 ofObject: self schedulerPointer.
	activePriority _ self quickFetchInteger: PriorityIndex ofObject: activeProc.
	newPriority   _ self quickFetchInteger: PriorityIndex ofObject: aProcess.
	newPriority > activePriority ifTrue: [
		self putToSleep: activeProc.
		self transferTo: aProcess.
	] ifFalse: [
		self putToSleep: aProcess.
	].