copyReplacingVariables: varDict 
	| t1 t2 t3 |
	t1 _ selectorOrFalse copyReplacingVariables: varDict.
	t2 _ block copyReplacingVariables: varDict.
	t3 _ arguments collect: [:a | a copyReplacingVariables: varDict].
	^self class new
		selector: t1
		arguments: t3
		precedence: precedence
		temporaries: temporaries copy
		block: t2
		encoder: encoder
		primitive: primitive