allEntries

	| answer |

	answer _ self sendToSwikiProjectServer: {
		'action: listallprojects'.
	}.
	(answer beginsWith: 'OK') ifFalse: [^#()].
	^self parseListEntries: answer