copyReplacingVariables: varDict
	| t1 t2 | 
	t1 _ variable copyReplacingVariables: varDict.
	t2 _ value copyReplacingVariables: varDict.
	^self class new variable: t1 value: t2