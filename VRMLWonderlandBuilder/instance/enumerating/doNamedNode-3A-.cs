doNamedNode: node
	| lastName |
	progress value:'Creating ', node name,' ...'.
	lastName _ attributes at: #currentName ifAbsent:[nil].
	attributes at: #currentName put: node name.
	super doNamedNode: node.
	lastName
		ifNil:[attributes removeKey: #currentName]
		ifNotNil:[attributes at: #currentName put: lastName].