testMethodsWithEnabledCallIntoModuleForClass
	"precondition: all enabled"
	| methodRefs |
	methodRefs := pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClass: self class.
	self assert: methodRefs size = self numOfCallsExampleModule.
	methodRefs := pcc methodsWithEnabledCallIntoModule: nil forClass: self class.
	self assert: methodRefs size = 1 & (methodRefs first methodSymbol allButFirst = 'ExternalCallWithoutModule')