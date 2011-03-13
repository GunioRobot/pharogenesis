debugProcess: aProcess
	| uiPriority oldPriority |
	uiPriority := Processor activeProcess priority.
	aProcess priority >= uiPriority ifTrue: [
		oldPriority := ProcessBrowser setProcess: aProcess toPriority: uiPriority - 1
	].
	ProcessBrowser debugProcess: aProcess.