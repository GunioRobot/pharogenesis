primitiveYield
"primitively do the equivalent of Process>yield"
	| activeProc priority processLists processList |
	activeProc _ self fetchPointer: ActiveProcessIndex
						 ofObject: self schedulerPointer.
	priority _ self quickFetchInteger: PriorityIndex ofObject: activeProc.
	processLists _ self fetchPointer: ProcessListsIndex ofObject: self schedulerPointer.
	processList _ self fetchPointer: priority - 1 ofObject: processLists.

	(self isEmptyList: processList) ifFalse:[
		self addLastLink: activeProc toList: processList.
		self transferTo: self wakeHighestPriority]