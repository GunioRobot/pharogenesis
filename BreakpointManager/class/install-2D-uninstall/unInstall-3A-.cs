unInstall: breakMethod 

	| who oldMethod |
	oldMethod _ self installed at: breakMethod ifAbsent:[^self].
	who _ breakMethod who.
	(who first methodDictionary at: who last) == breakMethod
		ifTrue:[	who first methodDictionary at: who last put: oldMethod].
	self installed removeKey: breakMethod