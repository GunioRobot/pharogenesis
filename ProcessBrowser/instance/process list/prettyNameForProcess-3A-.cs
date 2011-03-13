prettyNameForProcess: aProcess 
	| nameAndRules |
	nameAndRules _ self nameAndRulesFor: aProcess.
	^ aProcess browserPrintStringWith: nameAndRules first