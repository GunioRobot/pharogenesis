testMethodsWithFailedCallForClass
	| methodRefs |
	methodRefs := pcc methodsWithFailedCallForClass: self class.
	self assert: methodRefs size = 1 & (methodRefs asArray first methodSymbol = self failedCallSelector)