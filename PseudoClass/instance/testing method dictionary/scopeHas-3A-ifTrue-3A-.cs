scopeHas: varName ifTrue: assocBlock
	(self exists and: [self realClass scopeHas: varName ifTrue: assocBlock]) ifTrue: [^ true].
	assocBlock value: (Smalltalk 
		associationAt: varName asSymbol
		ifAbsent: [^ false]).
	^ true