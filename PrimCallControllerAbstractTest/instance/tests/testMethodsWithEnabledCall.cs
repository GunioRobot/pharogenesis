testMethodsWithEnabledCall
	| methodRefs |
	methodRefs := pcc methodsWithEnabledCall.
	self assert: methodRefs size > 0