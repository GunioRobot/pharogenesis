userScriptsDo: aBlock
	self scripts do:
		[:aUserScript | aBlock value: aUserScript]