testMethodsWithEnabledCallIntoModuleForClasses
	"precondition: all enabled"
	| methodRefs |
	methodRefs := pcc methodsWithEnabledCallIntoModule: self exampleModuleName forClasses: {self class}.
	self assert: methodRefs size = self numOfCallsExampleModule.
	methodRefs := pcc methodsWithEnabledCallIntoModule: nil forClasses: {self class}.
	self assert: methodRefs size = 1 & (methodRefs first methodSymbol allButFirst = 'ExternalCallWithoutModule')