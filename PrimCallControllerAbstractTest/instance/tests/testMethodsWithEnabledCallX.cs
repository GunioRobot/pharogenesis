testMethodsWithEnabledCallX
	| methodRefs |
	methodRefs := pcc methodsWithEnabledCall: self singularCallName.
	self assert: methodRefs size = 1 & (methodRefs first methodSymbol = self singularCallName)