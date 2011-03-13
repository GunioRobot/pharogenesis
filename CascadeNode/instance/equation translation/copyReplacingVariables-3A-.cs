copyReplacingVariables: varDict 
	| t1 t2 |
	t1 _ receiver copyReplacingVariables: varDict.
	t2 _ messages collect: [:m | m copyReplacingVariables: varDict].
	^self class new receiver: t1 messages: t2