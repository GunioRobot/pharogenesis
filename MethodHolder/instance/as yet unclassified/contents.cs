contents
	contents _ methodClass sourceCodeAt: methodSelector ifAbsent: [''].
	currentCompiledMethod _ methodClass compiledMethodAt: methodSelector ifAbsent: [nil].
	Preferences browseWithPrettyPrint ifTrue:
		[contents _ methodClass compilerClass new
			format: contents in: methodClass notifying: nil decorated: Preferences colorWhenPrettyPrinting].
	self showDiffs ifTrue:
		[contents _ self diffFromPriorSourceFor: contents].

	contents _ contents asText makeSelectorBoldIn: methodClass.
	
	^ contents