setHostName
	| newHostname |
	newHostname _ FillInTheBlank request: 'host to connect to' initialAnswer: hostname.
	newHostname size > 0 ifTrue: [ hostname _ newHostname ].