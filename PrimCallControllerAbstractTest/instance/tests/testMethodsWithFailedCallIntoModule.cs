testMethodsWithFailedCallIntoModule
	| methodRefs |
	methodRefs := pcc methodsWithFailedCallIntoModule: self failModuleName.
	self assert: methodRefs size = 1 & (methodRefs first methodSymbol = self failedCallSelector)