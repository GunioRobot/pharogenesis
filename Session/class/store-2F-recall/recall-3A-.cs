recall: id
	| aSession |
	aSession := Sessions at: id ifAbsent: [self error: 'Non-existent session'].
	aSession isViable ifFalse: [self error: 'Your session data has expired. Please restart the operation.'].
	aSession touch.
	^aSession

