updateListsAndCodeIn: aWindow
	| aMethod |
	aMethod _ classOfMethod compiledMethodAt: selectorOfMethod ifAbsent: [^ false].
	aMethod == currentCompiledMethod
		ifFalse:
			[self reformulateList].
	^ true
