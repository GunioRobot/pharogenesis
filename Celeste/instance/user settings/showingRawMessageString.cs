showingRawMessageString
	| string |
	string _ 'show raw message'.
	^ SuppressWorthlessHeaderFields
		ifTrue: ['<no>' , string]
		ifFalse: ['<yes>' , string]