dirListUrl
	| listURL |
	listURL _ self altUrl.
	listURL last ~= $/
		ifTrue: [listURL _ listURL , '/'].
	^ listURL