methodClass: aClass methodSelector: aSelector
	methodClass _ aClass.
	methodSelector _ aSelector.
	currentCompiledMethod _ aClass compiledMethodAt: aSelector ifAbsent: [nil]