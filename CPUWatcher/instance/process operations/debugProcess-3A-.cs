debugProcess: aProcess
	| uiPriority oldPriority |
	uiPriority _ Processor activeProcess priority.
	aProcess priority >= uiPriority ifTrue: [
		oldPriority _ ProcessBrowser setProcess: aProcess toPriority: uiPriority - 1
	].
	ProcessBrowser debugProcess: aProcess.