removeFromSelectorsVisited: aSelector
	"remove aSelector from my history list"

	self selectorsVisited remove: aSelector ifAbsent: []