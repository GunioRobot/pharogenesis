testMethodsWithFailedCallIntoModuleForClass
	| methodRefs |
	methodRefs := pcc methodsWithFailedCallIntoModule: self failModuleName forClass: self class.
	self assert: methodRefs size = 1 & (methodRefs first methodSymbol = self failedCallSelector)