changePriority
	| str newPriority nameAndRules |
	nameAndRules _ self nameAndRulesForSelectedProcess.
	nameAndRules third
		ifFalse: [PopUpMenu inform: 'Nope, won''t change priority of ' , nameAndRules first.
			^ self].
	str _ FillInTheBlank request: 'New priority' initialAnswer: selectedProcess priority asString.
	newPriority _ str asNumber asInteger.
	newPriority
		ifNil: [^ self].
	(newPriority < 1
			or: [newPriority > Processor highestPriority])
		ifTrue: [PopUpMenu inform: 'Bad priority'.
			^ self].
	self class setProcess: selectedProcess toPriority: newPriority.
	self updateProcessList