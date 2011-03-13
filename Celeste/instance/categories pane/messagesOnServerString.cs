messagesOnServerString
	| string |
	string _ 'leave messages on server'.
	^ DeleteInboxAfterFetching 
		ifTrue: ['<no>' , string]
		ifFalse: ['<yes>' , string]