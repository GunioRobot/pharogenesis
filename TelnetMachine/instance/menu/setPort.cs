setPort
	| portString |
	portString _ port printString.
	portString _ FillInTheBlank request: 'port to connect on' initialAnswer: portString.
	portString _ portString withBlanksTrimmed.
	portString isEmpty ifFalse: [ port _ portString asNumber asInteger ].