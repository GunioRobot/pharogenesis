prettyNameForProcess: aProcess 
	| nameAndRules |
	aProcess ifNil: [ ^'<nil>' ].
	nameAndRules _ self nameAndRulesFor: aProcess.
	^ aProcess browserPrintStringWith: nameAndRules first