suspendProcess
	| nameAndRules |
	selectedProcess isSuspended
		ifTrue: [^ self].
	nameAndRules _ self nameAndRulesForSelectedProcess.
	nameAndRules second
		ifFalse: [PopUpMenu inform: 'Nope, won''t suspend ' , nameAndRules first.
			^ self].
	self class suspendProcess: selectedProcess.
	self updateProcessList