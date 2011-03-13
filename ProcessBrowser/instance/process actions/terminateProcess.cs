terminateProcess
	| nameAndRules |
	nameAndRules _ self nameAndRulesForSelectedProcess.
	nameAndRules second
		ifFalse: [PopUpMenu inform: 'Nope, won''t kill ' , nameAndRules first.
			^ self].
	selectedProcess
		ifNotNil: [self class suspendedProcesses
		removeKey: selectedProcess
		ifAbsent: [].selectedProcess terminate].
	
	self updateProcessList