handleError: anInteger 
	errorToken isNil ifTrue: [errorToken := currentToken].
	(currentToken id first = self emptySymbolTokenId 
		or: [self hasErrorHandler not]) ifTrue: [self reportError: anInteger].
	self findErrorHandlerIfNoneUseErrorNumber: anInteger