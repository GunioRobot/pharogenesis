suppressingHeadersString
	| string |
	string _ 'suppress header'.
	^ SuppressWorthlessHeaderFields
		ifTrue: ['<yes>' , string]
		ifFalse: ['<no>' , string]