testMethodsWithDisabledCallIntoModuleForClasses
	"precondition: all enabled"
	| methodRefs |
	self methodRefsToExampleModule
		do: [:ref | pcc disableCallIn: ref].
	methodRefs := pcc methodsWithDisabledCallIntoModule: self exampleModuleName forClasses: {self class}.
	self assert: methodRefs size = self numOfCallsExampleModule.
	"postcondition"
	self methodRefsToExampleModule
		do: [:ref | pcc enableCallIn: ref].
	methodRefs := pcc methodsWithDisabledCallIntoModule: nil forClasses: {self class}.
	self assert: methodRefs size = 1 & (methodRefs first methodSymbol allButFirst = 'DisabledExternalCallWithoutModule')