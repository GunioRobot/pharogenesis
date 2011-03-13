printOn: aStream indent: level

	aStream nextPut: $[.
	self printArgumentsOn: aStream indent: level.
	self printTemporariesOn: aStream indent: level.
	self printStatementsOn: aStream indent: level.
	aStream nextPut: $]