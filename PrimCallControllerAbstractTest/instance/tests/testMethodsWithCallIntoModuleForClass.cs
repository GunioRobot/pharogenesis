testMethodsWithCallIntoModuleForClass
	"precondition: all enabled"
	| methodRefs |
	pcc disableCallIn: self methodRefsToExampleModule first.
	methodRefs := pcc methodsWithCallIntoModule: self exampleModuleName forClass: self class.
	self assert: methodRefs size = self numOfCallsExampleModule.
	"postcondition"
	pcc enableCallIn: self methodRefsToExampleModule first.
	methodRefs := pcc methodsWithCallIntoModule: nil forClass: self class.
	self
		assert: (methodRefs size = 2
				and: [| methodCoreStrings | 
					methodCoreStrings := methodRefs
								collect: [:mRef | mRef methodSymbol allButFirst asString].
					(methodCoreStrings includes: 'ExternalCallWithoutModule')
						and: [methodCoreStrings includes: 'DisabledExternalCallWithoutModule']])