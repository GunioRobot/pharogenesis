putToSleep: aProcess
	"Save the given process on the scheduler process list for its priority."

	| priority processLists processList |
	priority _ self quickFetchInteger: PriorityIndex ofObject: aProcess.
	processLists _ self fetchPointer: ProcessListsIndex ofObject: self schedulerPointer.
	processList _ self fetchPointer: priority - 1 ofObject: processLists.
	self addLastLink: aProcess toList: processList.