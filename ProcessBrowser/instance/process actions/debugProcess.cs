debugProcess
	| nameAndRules |
	nameAndRules _ self nameAndRulesForSelectedProcess.
	nameAndRules third
		ifFalse: [PopUpMenu inform: 'Nope, won''t debug ' , nameAndRules first.
			^ self].
	self class debugProcess: selectedProcess.