copyReplacingVariables: varDict
	| t1 t2 t3 |  
	t1 _ receiver copyReplacingVariables: varDict.
	t2 _ selector copyReplacingVariables: varDict.
	t3 _ arguments collect: [:a | a copyReplacingVariables: varDict].
	^self class new receiver: t1 selector: t2 arguments: t3 precedence: precedence