matchingEntries: criteria
	| result |
	eToyUserListUrl ifNil:[^self entries].
	result _ self sendToSwikiProjectServer: {
		'action: listmatchingprojects'.
	}  , criteria.
	(result beginsWith: 'OK')
		ifFalse: [^self entries]. "If command not supported"
	^self parseListEntries: result