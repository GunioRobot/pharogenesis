copyReplacingVariables: varDict 
	^self class new expr: (expr copyReplacingVariables: varDict)