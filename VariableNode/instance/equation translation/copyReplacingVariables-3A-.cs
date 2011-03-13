copyReplacingVariables: varDict 
	(key isMemberOf: Symbol)
		ifTrue: [^(varDict at: key ifAbsent: [^self copy])
				copyReplacingVariables: Dictionary new]
		ifFalse: [^self copy]