testMethodsWithEnabledCallIntoModule
	| methodRefs |
	methodRefs := pcc methodsWithEnabledCallIntoModule: self exampleModuleName.
	self assert: methodRefs size = self numOfCallsExampleModule