suspendProcess
	| nameAndRules priority |
	selectedProcess isSuspended
		ifTrue: [^ self].
	nameAndRules _ self nameAndRulesForSelectedProcess.
	nameAndRules second
		ifFalse: [PopUpMenu inform: 'Nope, won''t suspend ' , nameAndRules first.
			^ self].
	priority _ selectedProcess priority.
	self class suspendedProcesses at: selectedProcess put: priority.
	"Need to take the priority down below mine so that I can keep control after signaling the Semaphore"
	(selectedProcess suspendingList isKindOf: Semaphore)
		ifTrue: [selectedProcess priority: 1.
			selectedProcess suspendingList signal].
	[selectedProcess suspend]
		on: Error
		do: [:ex | self class suspendedProcesses removeKey: selectedProcess].
	selectedProcess priority: priority.
	self updateProcessList