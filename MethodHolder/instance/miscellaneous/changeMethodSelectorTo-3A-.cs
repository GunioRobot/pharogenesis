changeMethodSelectorTo: aSelector
	"Change my method selector as noted.  Reset currentCompiledMethod"

	methodSelector _ aSelector.
	currentCompiledMethod _ methodClass compiledMethodAt: aSelector ifAbsent: [nil]