copyReplacingVariables: varDict 
	| t1 |
	t1 _ statements collect: [:s | s copyReplacingVariables: varDict].
	^(self copy) statements: t1; yourself