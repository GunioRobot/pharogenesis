updateSelectorsVisitedfrom: oldSelector to: newSelector
	"Update the list of selectors visited."

	newSelector == oldSelector ifTrue: [^ self].
	self selectorsVisited remove: newSelector ifAbsent: [].
		
	(selectorsVisited includes:  oldSelector)
		ifTrue:
			[selectorsVisited add: newSelector after: oldSelector]
		ifFalse:
			[selectorsVisited add: newSelector]
