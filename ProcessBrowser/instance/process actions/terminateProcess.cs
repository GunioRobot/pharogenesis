terminateProcess
	| nameAndRules |
	nameAndRules _ self nameAndRulesForSelectedProcess.
	nameAndRules second
		ifFalse: [PopUpMenu inform: 'Nope, won''t kill ' , nameAndRules first.
			^ self].
	self class terminateProcess: selectedProcess.	
	self updateProcessList